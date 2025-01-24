using BookNook.Application.Common.Interfaces;
using BookNook.Application.Services.Interface;
using BookNook.Domain.Entities;
using BookNook.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookNook.Web.Controllers
{

    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        public VillaNumberController(IVillaNumberService villaNumberService, IVillaService villaService ) 
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            var villaNumbers = _villaNumberService.GetAllVillaNumbers();
            return View(villaNumbers);
        }
        public IActionResult Create()
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            bool roomNumberExists = _villaNumberService.CheckVillaNumberExists(obj.VillaNumber.Villa_Number);
            
            if (ModelState.IsValid && !roomNumberExists) {

                _villaNumberService.CreateVillaNumber(obj.VillaNumber);
                TempData["success"] = "The villa number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            if (roomNumberExists)
            {
                TempData["error"] = "The villa number already exists.";
            }
            obj.VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber =_villaNumberService.GetVillaNumberById(villaNumberId)
        };
            
            if (villaNumberVM.VillaNumber == null)   
            {
                return RedirectToAction("Error", "Home");  
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Update(VillaNumberVM villaNumberVM)
        {
            if (ModelState.IsValid)
            {
                _villaNumberService.UpdateVillaNumber(villaNumberVM.VillaNumber);
                TempData["success"] = "The villa number has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
           
            villaNumberVM.VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(villaNumberVM);
        }


        public IActionResult Delete(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _villaService.GetAllVillas().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                VillaNumber = _villaNumberService.GetVillaNumberById(villaNumberId)
            };
           
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }

        [HttpPost]
        public IActionResult Delete(VillaNumberVM villaNumberVM)
        {
            VillaNumber? objFromDb = _villaNumberService.GetVillaNumberById(villaNumberVM.VillaNumber.Villa_Number);
                
            if (objFromDb is not null)
            {
                _villaNumberService.DeleteVillaNumber(objFromDb.Villa_Number);
                TempData["success"] = "The villa number has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa number could not be deleted.";
            return View();
        }

    }
}
