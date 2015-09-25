using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Adm.Facade;
using WebSite.Adm.Models;

namespace WebSite.Adm.Controllers
{
    [Authorize]
    public class BannerController : Controller
    {

        private IBannerFacade _bannerFacade;


        public BannerController(IBannerFacade bannerFacade)
        {
            _bannerFacade = bannerFacade;
        }


        public ActionResult Index()
        {
            return View(_bannerFacade.GetAll(0, 10));
        }

        public ActionResult Details(int id)
        {
            return View(_bannerFacade.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(BannerViewModel banner)
        {
            try
            {
                _bannerFacade.Add(banner);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(_bannerFacade.GetById(id));
        }


        [HttpPost]
        public ActionResult Edit(BannerViewModel banner)
        {
            try
            {
                _bannerFacade.Update(banner);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_bannerFacade.GetById(id));
        }

        [HttpPost]
        public ActionResult FileUpload(int id)
        {
            return Redirect("/banner/Edit/" + id);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection parameters)
        {
            try
            {
                _bannerFacade.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
                return View();
            }
        }
    }
}
