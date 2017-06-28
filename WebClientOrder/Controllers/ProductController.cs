using DomainEntityOrder.DomainService;
using DomainModelOrder;
using DomainModelOrder.Constant;
using DomainModelOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientOrder.Controllers
{
    public class ProductController : Controller
    {
        private IProductService pro;
        public ProductController(IProductService inPro)
        {
            pro = inPro;
        }
        // GET: Product
        public ActionResult Index(ProductSearchViewModel productSearch, string page)
        {
            var pp = new PaginationViewModel
            {
                CurrntPage = (string.IsNullOrEmpty(page) || int.Parse(page) == 0) ? 1 : int.Parse(page),
                PageSize = GlobalConsts.PageSize,
            };

            ProductPageViewModel pageModel = new ProductPageViewModel
            {
                Products = pro.GetAll(),
                ProductSearch = productSearch,
                Pagination = pp,
            };
            return View(pageModel);
        }

        public JsonResult Insert(ProductModel pModel)
        {
            if (pModel == null
                || string.IsNullOrEmpty(pModel.SKU)
                || string.IsNullOrEmpty(pModel.ProductName)
                )
            {
                return Json("fail");
            }

            pModel.ProductID = Guid.NewGuid();
            pModel.Status = 0;
            pModel.CreateTime = DateTime.Now;
            pModel.UpdateTime = DateTime.Now;
            pro.Insert(pModel);
            return Json("success");
        }

        public JsonResult Delete(string pid)
        {
           pro.Delete( new Guid(pid) );
           return Json("success");

        }
    }
}