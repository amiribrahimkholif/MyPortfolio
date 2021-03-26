using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;
        public HomeController(IUnitOfWork<Owner>owner,
            IUnitOfWork<PortfolioItem>portfolio)
        {
            _owner = owner;
            _portfolio = portfolio;
        }

        public IUnitOfWork<PortfolioItem> Portfolio { get; }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PortfolioItems = _portfolio.Entity.GetAll().ToList()
            };
            return View(homeViewModel);
        }
    }
}
