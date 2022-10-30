using DTO;
using Helper.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationWeb.Models;
using Services;
using Services.Abstract;
using System.Diagnostics;

namespace PresentationWeb.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminProductController : Controller
    {
        private readonly IProductServices _productService;

        public AdminProductController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult Update(int id)
        {
            var res = _productService.Get(id);
            return View(res);
        }

        [HttpPost]
        public IActionResult UpdateDTO(ProductDTO product)
        {
            if (string.IsNullOrEmpty(product.ImgPath))
            {
                product.ImgPath = "~/img2/Fruits.jpg";
            }
            var res = _productService.Update(product);

            return View("Update", res);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductDTO product)
        {
            if (string.IsNullOrEmpty(product.ImgPath))
            {
                product.ImgPath = "~/img2/Fruits.jpg";
            }
            _productService.Create(product);

            return View();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);

        }




        [HttpGet]
        
        public IActionResult Products(int page = 1, int pageSize = 4, SortOrder order = SortOrder.NameAsc, string search = null, bool changeSort = false)
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input

            int allProductsCount;
            var res = _productService.GetFilter(out allProductsCount, page, pageSize, order, search);

            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }
            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }

            if (changeSort)
            {
                ViewBag.NameSort = order == SortOrder.NameAsc ? SortOrder.NameDesc : SortOrder.NameAsc;
                ViewBag.PriceSort = order == SortOrder.PriceAsc ? SortOrder.PriceDesc : SortOrder.PriceAsc;
            }
            else
            {
                ViewBag.NameSort = order;
                ViewBag.PriceSort = order;
            }

            var pagedRs = new PageResponseDTO<ProductDTO>(page, pageSize, res);

            return View(pagedRs);
        }

    }
    }
