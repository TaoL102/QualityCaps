using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualityCaps.ErrorHandler
{
    public class CustomHandleErrorAttribute:HandleErrorAttribute
    {

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public static void WriteErrorToFile(ExceptionContext e)
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "logErrors.txt";

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine("------------------------------------------------");
                sw.WriteLine("Error Logged : " + DateTime.Now.ToString());
                sw.WriteLine("------------------------------------------------");
                sw.WriteLine("Controller: " + e.Controller);
                sw.WriteLine("TargetSite: " + e.Exception.TargetSite);
                sw.WriteLine("Source: " + e.Exception.Source);
                sw.WriteLine("Message: " + e.Exception.Message);
                sw.WriteLine("InnerException: " + e.Exception.InnerException);
                sw.WriteLine("HelpLink: " + e.Exception.HelpLink);
                sw.WriteLine("HResult: " + e.Exception.HResult);
                sw.WriteLine("StackTrace: " + e.Exception.StackTrace);
                sw.WriteLine("Data: " + e.Exception.Data);
                sw.WriteLine("------------------------------------------------");
            }


        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = filterContext.Exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);

            }

            // Write error logging code 
            WriteErrorToFile(filterContext);

        }
    }
}