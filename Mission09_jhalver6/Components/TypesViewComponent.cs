﻿using Microsoft.AspNetCore.Mvc;
using Mission09_jhalver6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jhalver6.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }       

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["BookCategory"];
            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
