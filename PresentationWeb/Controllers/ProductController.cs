using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace PresentationWeb.Controllers
{

    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices _productService;
        private readonly ICartServices _CartService;

        public ProductController(IProductServices productService, ICartServices cartService)
        {
            _productService = productService;
            _CartService = cartService;
        }

        [HttpGet]
        [Route("Products")]
        public IActionResult Products(SortOrder sortOrder, int page = 1, int pageSize = 8, string searchName = null)
        {

            #region initial data

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Grocery Ecommerce Template",
            //    Price = 5,
            //    ImgPath = "~/img2/product-img-2.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Bakery & Biscuits",
            //    Price = 5,
            //    ImgPath = "~/img2/product-img-3.jpg",

            //}); ;


            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Snack & Munchies",
            //    Price = 12,
            //    ImgPath = "~/img2/product-img-4.jpg",

            //}); ;




            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Salted Instant Popcorn",
            //    Price = 21,
            //    ImgPath = "~/img2/product-img-5.jpg",

            //}); ;


            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Blueberry Yogurt",
            //    Price = 16,
            //    ImgPath = "~/img2/product-img-6.jpg",

            //}); ;




            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Grocery Ecommerce Template",
            //    Price = 25,
            //    ImgPath = "~/img2/product-img-2.jpg",

            //}); ;

            #endregion






            IEnumerable<ProductDTO> prods;

            if (searchName != null)
            {
                prods = _productService.Get()
                    .Where(p => p.Name.ToLower().Contains(searchName.ToLower()));
            }
            else
            {
                prods = _productService.Get();
            }

            ViewBag.NameSort = sortOrder == SortOrder.NameAsc ? SortOrder.NameDesc : SortOrder.NameAsc;
            ViewBag.PriceSort = sortOrder == SortOrder.PriceAsc ? SortOrder.PriceDesc : SortOrder.PriceAsc;

            prods = sortOrder switch
            {
                SortOrder.NameDesc => prods.OrderByDescending(s => s.Name),

                SortOrder.PriceAsc => prods.OrderBy(s => s.Price),
                SortOrder.PriceDesc => prods.OrderByDescending(s => s.Price),

                _ => prods.OrderBy(s => s.Name)

            ,
            };




            var allProductsCount = prods.Count();
            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }
            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }


            var products = prods.
                Skip((page - 1) * pageSize).Take(pageSize).ToList();

            //var products = _productService.Get(page, pageSize);

            if (products.Count() == 0)
            {
                return NotFound();
            }
            var pagedRs = new PageResponseDTO<ProductDTO>(page, pageSize, products);

            return View(pagedRs);
        }

        [HttpGet]
        [Route("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var prod = _productService.Get(id);
            return View(prod);
        }



        [HttpPost]
        [Route("AddCart")]
        public IActionResult AddCart(CartDTO dto)
        {
            dto.UserId = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);

            try
            {
                var dtos = _CartService.Create(dto);
                ViewBag.Success = "Add To Cart";

            }
            catch (Exception a)
            {
                ViewBag.Error = a.Message;
                return RedirectToAction("GetProduct", new { id = dto.ProductId });
            }
            return RedirectToAction("GetProduct" , new {id=dto.ProductId});
        }



        [HttpGet]
        [Route("GetCart")]
        public IActionResult GetCart()
        {
            var uid = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            var dtos = _CartService.GetByUserId(uid);
            return View(dtos);
        }




    

    }
}