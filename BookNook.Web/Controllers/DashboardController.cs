using BookNook.Application.Common.Interfaces;
using BookNook.Application.Common.Utility;
using BookNook.Application.Services.Implementation;
using BookNook.Application.Services.Interface;
using BookNook.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace BookNook.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService) 
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {
            return Json(await _dashboardService.GetTotalBookingRadialChartData());
        }
        public async Task<IActionResult> GetRegisteredUserChartData()
        {
            return Json(await _dashboardService.GetRegisteredUserChartData());
        }
        public async Task<IActionResult> GetRevenueChartData()
        {
            return Json(await _dashboardService.GetRevenueChartData());
        }

        public async Task<IActionResult> GetBookingPieChartData()
        {
            return Json(await _dashboardService.GetBookingPieChartData());
        }
        public async Task<IActionResult> GetMemberAndBookingLineChartData()
        {
            return Json(await _dashboardService.GetMemberAndBookingLineChartData());
        }

    }
}
