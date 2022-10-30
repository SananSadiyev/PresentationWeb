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


        #region Gett All


        //[HttpGet("Product/Get/{id}")]
        //public IActionResult Get(int id, string message = null, bool isSuccess = true)
        //{
        //    if (!string.IsNullOrEmpty(message))
        //    {
        //        if (isSuccess)
        //            ViewBag.Success = message;
        //        else
        //            ViewBag.Error = message;
        //    }


        //    var res = _productService.Get(id);

        //    if (res == null)
        //    {
        //        ViewBag.Error = "Not Found!";
        //        return View();
        //    }
        //    return View(res);
        //}




        //[HttpGet]
        //public IActionResult GetAll(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null)
        //{
        //    if (!string.IsNullOrEmpty(search))
        //        ViewBag.Search = search;
        //    //to save search text in input


        //    var res = _productService.GetFilter(page, pageSize, order, search);

        //    var allProductsCount = res.Count();
        //    ViewBag.HasPrevious = true;
        //    ViewBag.HasNext = true;

        //    if (page * pageSize >= allProductsCount)
        //    {
        //        ViewBag.HasNext = false;
        //    }
        //    if (page <= 1)
        //    {
        //        ViewBag.HasPrevious = false;
        //    }


        //    ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
        //    ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;


        //    var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, res);

        //    return View(pagedRs);
        //}


        #endregion




        [HttpGet]
        [Route("Products")]
        public IActionResult Products(SortOrder sortOrder = SortOrder.NameAsc, int page = 1, int pageSize = 8, string searchName = null,bool price=false, bool name = false)
        {

            #region initial data

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Kiwi",
            //    Price = 1.89,
            //    ImgPath = "~/img2/Kiwi.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Orange",
            //    Price = 0.75,
            //    ImgPath = "~/img2/Orange.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "PepperR",
            //    Price = 3.99,
            //    ImgPath = "~/img2/PepperR.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Strawberries",
            //    Price = 8.99,
            //    ImgPath = "~/img2/Strawberries.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Tomato",
            //    Price = 9.99,
            //    ImgPath = "~/img2/Tomato.jpg",


            //}); ;

            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Pepper",
            //    Price = 3.99,
            //    ImgPath = "~/img2/PepperG.jpg",

            //}); ;


            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Bread",
            //    Price = 5.99,
            //    ImgPath = "~/img2/Bread.jpg",

            //}); ;




            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Ananas",
            //    Price = 0.99,
            //    ImgPath = "~/img2/Ananas.jpg",

            //}); ;


            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Avokado",
            //    Price = 2.99,
            //    ImgPath = "~/img2/Avokado.jpg",

            //}); ;




            //_productService.Create(new DTO.ProductDTO
            //{
            //    Name = "Banana",
            //    Price = 0.35,
            //    ImgPath = "~/img2/Banana.jpg",


            //}); ;

            #endregion



            var prods = _productService.Get();

            if (!string.IsNullOrEmpty(searchName))
            {
                ViewBag.Search = searchName;

                prods =prods.Where(p => p.Name.ToLower().Contains(searchName.ToLower()));
            }

          
            if (name) 
            {
                ViewBag.Sort = sortOrder == SortOrder.NameAsc ? SortOrder.NameDesc : SortOrder.NameAsc ;
            }
            else if(price)
            {
                ViewBag.Sort = sortOrder == SortOrder.PriceAsc ? SortOrder.PriceDesc : SortOrder.PriceAsc;

            }
            else
            {
                ViewBag.Sort = sortOrder;
            }


            prods = sortOrder switch
            {
                SortOrder.NameDesc => prods.OrderByDescending(s => s.Name),

                SortOrder.PriceAsc => prods.OrderBy(s => s.Price),
                SortOrder.PriceDesc => prods.OrderByDescending(s => s.Price),

                _ => prods.OrderBy(s => s.Name)

            
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


            var pagedRs = new PageResponseDTO<ProductDTO>(page, pageSize, products);

            return View(pagedRs);
        }

        [HttpGet]
        [Route("GetProduct/Get/{id}")]
        public IActionResult GetProduct(int id, string message = null, bool isSuccess = true)
        {

            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess) 
                    ViewBag.Success = message;
                else  
                    ViewBag.Error = message;
            }

                var res = _productService.Get(id);

                if (res == null)
                {
                    ViewBag.Error = "Not Found!";
                    return View();
                }
               
               
            
            var prod = _productService.Get(id);
                    return View(prod);
        }



        [HttpPost]
        [Route("AddCart")]
        public IActionResult AddCart(CartDTO dto)
        {
            bool isSuccess;
            string mes;

            try
            {

                dto.UserId = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
                var dtos = _CartService.Create(dto);
                mes = "Succesfuly added!";
                isSuccess = true;

            }
            catch (Exception ex)
            {
                mes = ex.Message;
                isSuccess = false;

                return RedirectToAction("Products", new
            {
                id = dto.ProductId,
                message = mes,
                isSuccess = isSuccess
            });
            }

            return RedirectToAction("Products", new
            {
                id = dto.ProductId,
                message = mes,
                isSuccess = isSuccess
            });
        }



        [HttpGet]
        [Route("GetCart")]
        public IActionResult GetCart(string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }
                var uid = Convert.ToInt32(HttpContext.User.FindFirst("Id").Value);
            var dtos = _CartService.GetByUserId(uid);
            return View(dtos);
        }








        [HttpPost]
        public IActionResult Buy(PayDTO dto)
        {
            _productService.Buy(dto.CartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Success! You paid " + dto.Sum + "$!",
                    isSuccess = true
                });
        }

        [HttpPost]
        public IActionResult Delete(PayDTO dto)
        {
            _productService.Delete(dto.CartId);

            return RedirectToAction("GetCart",
                new
                {
                    
                });
        }


    }
}
