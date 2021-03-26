using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersMVC
{
    public class CustomActionFilter: FilterAttribute, IActionFilter, IResultFilter
    {
        private Stopwatch watch = new Stopwatch();
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            watch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            watch.Stop();

            filterContext.HttpContext.Response.Write($"Action executed: {filterContext.ActionDescriptor.ActionName},\t" +
                                                     $"{watch.ElapsedMilliseconds}");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            watch.Start();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            watch.Stop();

            filterContext.HttpContext.Response.Write($"Result executed: ,\t" +
                                                     $"{watch.ElapsedMilliseconds}");
        }
    }
}