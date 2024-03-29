﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net_MVC_Workshop2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        [HttpGet()]
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost()]
        public JsonResult Index(Models.BookSearchArg book)
        {
            Models.BookServices bookService = new Models.BookServices();
            ViewBag.SearchResult = bookService.GetBookByCondtioin(book);
            var result = bookService.GetBookByCondtioin(book);
            return Json(result);
        }
        [HttpPost()]
        public JsonResult BookClass(Models.BookClass bookclass)
        {
            Models.BookServices bookService = new Models.BookServices();
            var result = bookService.GetBookClass(bookclass);
            return Json(result);
        }
        [HttpPost()]
        public JsonResult BookKeeper(Models.BookKeeper bookkeeper)
        {
            Models.BookServices bookService = new Models.BookServices();
            var result = bookService.GetBookKeeper(bookkeeper);
            return Json(result);
        }
        [HttpPost()]
        public JsonResult BookStatus(Models.BookStatus bookstatus)
        {
            Models.BookServices bookService = new Models.BookServices();
            var result = bookService.GetBookStatus(bookstatus);
            return Json(result);
        }
        [HttpPost()]
        public JsonResult Insert(Models.BookSearchArg Book)
        {
            
                Models.BookServices bookService = new Models.BookServices();
                bookService.InsertBook(Book);
                return Json(Book);
        }
        [HttpPost()]
        public JsonResult Delete(string BookId)
        {
            try
            {
                Models.BookServices bookService = new Models.BookServices();
                bookService.DeleteBookById(BookId);
                return this.Json(true);
            }

            catch (Exception ex)
            {
                return this.Json(false);
            }
        }
        [HttpGet()]
        public JsonResult Update(string BookId)
        {
            try
            {
                Models.BookServices bookService = new Models.BookServices();
                bookService.GetBookUpdateByCondtioin(BookId);
                var result = bookService.GetBookUpdateByCondtioin(BookId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(false);
            }
        }
        [HttpPost()]
        public JsonResult Update(Models.BookSearchArg Book)
        {
            try
            {
                Models.BookServices bookService = new Models.BookServices();
                bookService.UpdateBookById(Book);
                return this.Json(true);
            }
            catch (Exception ex)
            {
                return this.Json(false);
            }
        }


    }
}