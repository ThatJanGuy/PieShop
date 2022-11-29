﻿using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository ?? throw new ArgumentNullException(nameof(pieRepository));
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese Cakes";
            //return View(pieRepository.AllPies);

            PieListViewModel piesListViewModel = new PieListViewModel
                (pieRepository.AllPies, "All Pies");
            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = pieRepository.GetPieById(id);

            if (pie == null)
                return NotFound();
            
            return View(pie);  
            
        }
    }
}
