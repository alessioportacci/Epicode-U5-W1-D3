﻿using System.Web;
using System.Web.Mvc;

namespace Epicode_U5_W1_D3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
