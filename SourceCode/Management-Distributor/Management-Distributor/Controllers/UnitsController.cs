﻿using Management_Distributor.POCO;
using Management_Distributor.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Management_Distributor.Controllers
{
    public class UnitsController : Controller
    {

        private IUnitService unitService = null;

        public UnitsController(IUnitService _unitService)
        {
            unitService = _unitService;
        }

        public JsonResult FetchAll()
        {
            var data = unitService.GetAll();
            return Json(new { data }, JsonRequestBehavior.AllowGet);    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult   AddOrEdit(Unit unit)
        {
            if(unit.UnitId == 0)
            {
                if(unitService.Add(unit))
                {
                    return Json(new { success = true, message = "Created successfully!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Failed To create!" }, JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                if(unitService.Edit(unit))
                {
                    return Json(new { success = true, message = "Edited successfully!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Failed To Edit!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        
    }
}