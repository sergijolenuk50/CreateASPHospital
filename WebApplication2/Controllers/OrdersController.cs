using Core.Interfaces;
using Core.Services;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication2.Controllers
{
    //public class OrdersController : Controller
    //{
    //}
        [Authorize]
        public class OrdersController : Controller
        {
            private readonly IOrdersServices ordersService;
        private readonly RoleManager<IdentityRole> userManager;
            private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            public OrdersController(IOrdersServices ordersService)
            {
                this.ordersService = ordersService;
           // this.userManager = userManager;
            }
            public IActionResult Index()
            {
           // userManager.CreateAsync(new IdentityRole());
                return View(ordersService.GetOrders(UserId));
            }

            public IActionResult Create()
            {
                ordersService.Create(UserId);
                return RedirectToAction(nameof(Index));
            }
        }
}
