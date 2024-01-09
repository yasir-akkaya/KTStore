using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KTStore.Data;
using KTStore.Models;
using KTStore.Areas.Admin.Services.Interfaces;
using KTStore.GenericModels;

namespace KTStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        // SONRADAN EKLENDİ////////////////////////////////////////////

        private readonly UploadImage uploadImage;
        public CategoryController(ICategoryService categoryService, UploadImage uploadImage)
        {
            this.categoryService = categoryService;
            this.uploadImage = uploadImage;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            var list = await categoryService.GetAllCategoriesAsync();
            return View(list);
        }

        //// GET: Admin/Category/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Categories == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category);
        //}

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string image = uploadImage.Image(files, "category");
                category.Image = image == null ? "empty.jpg" : image;
                categoryService.AddCategoryAsync(category);
                TempData["Message"] = "Category added successfully";
            }
            else
            {
            TempData["Message"] = "Category can't added";

            }
            
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id = 0)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;

                string image = uploadImage.Image(files, "category");
                if (image!=null)
                {
                    category.Image = image;
                }

                var result =await categoryService.UpdateCategoryAsync(category);
                TempData["Message"] = "Category edited successfully";
            }
            else
            {
            TempData["Message"] = "Category can't edited";

            }

            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryService.DeleteCategoryAsync(id);
            if (result)
            {
                TempData["Message"] = "Category deleted successfully";
            }
            else
            {
                TempData["Message"] = "Category can't deleted";

            }
            return RedirectToAction("Index");
        }

        //// POST: Admin/Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        //    }
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category != null)
        //    {
        //        _context.Categories.Remove(category);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryExists(int id)
        //{
        //  return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
