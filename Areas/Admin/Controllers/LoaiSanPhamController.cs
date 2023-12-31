﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom18WebBanHoa.Models;

namespace Nhom18WebBanHoa.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiSanPham

        QuanLyBanHoaEntities1 db = new QuanLyBanHoaEntities1();
        public ActionResult Index()
        {
            var lsp = db.Loai_San_Pham.ToList();
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View(lsp);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Loai_San_Pham lsp)
        {
            db.Loai_San_Pham.Add(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Details(int id)
        {
            var lsp = db.Loai_San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpGet]

        public ActionResult Delete(int id)
        {

            var lsp = db.Loai_San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpPost]

        public ActionResult Delete(Loai_San_Pham llsp)
        {
            var lsp = db.Loai_San_Pham.Where(n => n.id == llsp.id).FirstOrDefault();
            db.Loai_San_Pham.Remove(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult Edit(int id)
        {

            var lsp = db.Loai_San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpPost]

        public ActionResult Edit(int id, Loai_San_Pham lsp)
        {
            db.Entry(lsp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}