using AngularFirst.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularFirst.Controllers
{
    public class HomeController : Controller
    {
        Data_access_layer.db dblayer = new Data_access_layer.db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show_data()
        {

            return View();
        }

        public ActionResult update_data(int id)

        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult Add_record(Register rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_data()
        {
            DataSet ds = dblayer.Get_record();
            List<Register> listrs = new List<Register>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new Register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_databyid(int id)
        {
            DataSet ds = dblayer.Get_recordbyid(id);
            List<Register> listrs = new List<Register>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new Register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),
                    Email = dr["Email"].ToString(),
                    Password = dr["Password"].ToString(),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString(),
                    City = dr["City"].ToString(),
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update_record(Register rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.Update_record(rs);
                res = "Update";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_record(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.Deletedata(id);
                res = "Deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ContentResult Upload()
        //{
        //    string path = Server.MapPath("~/Upload");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }
        //    foreach(string key in Request.Files)
        //    {
        //        HttpPostedFileBase postedFile = Request.Files[key];
        //        postedFile.SaveAs(path + postedFile.FileName);
        //    }
        //    return Content("Success");
        //}
    }
}