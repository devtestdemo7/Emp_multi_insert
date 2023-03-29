using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
       public JsonResult getallemployee()
        {
            var dada = new repoclass().getallemp();
            return Json(new repoclass().getallemp(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            (List<employee> empl, List<education> edu, List<skil> slill, List<workexprence> work , List<workplatfrom> workdeas) = new repoclass().Getdetails(id);

            ViewData["employee"] = empl;
            ViewData["education"] = edu;
            ViewData["skil"] = slill;
            ViewData["woekexprences"] = work;
            ViewData["workplatfrom"] = workdeas;
            return View();
        }

        public JsonResult getcountry()
        {
            return Json(new repoclass().getcountry(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult create()
        {
            return View();
        }
        public JsonResult save(employee obj,string[] skilname,string[] percentage,string[] platfromtitle,string[] wp_description,string[] collagename,string[] description,string[] startingmonth,string[] startingyear,string[] endingmonth,string[] endingyear
            ,string[] companyname,string[] jobtitle,string[] joblocation,string[] jobdescription,string[] jobstartingmonth,string[] jobstartingyear,string[] jobendingmonth
,string[] jobendingyear)
        {

            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    // Get the complete folder path and store the file inside it.  
                    fname = Path.Combine(Server.MapPath("~/Image"), fname);
                  string  ffname = file.FileName;
                    file.SaveAs(fname);
                    obj.profile_pic=ffname;
                }
                
                var data = new repoclass().saveemployee(obj);

                for (int i = 0; i < skilname.Length; i++)
                {
                    skil sk = new skil();
                    sk.skilname = skilname[i];
                    sk.percentage = percentage[i];
                    new repoclass().saveskil(sk, data);

                }
                for (int i = 0; i < platfromtitle.Length; i++)
                {
                    workplatfrom sk = new workplatfrom();
                    sk.platfromtitle = platfromtitle[i];
                    sk.wp_description = wp_description[i];
                    new repoclass().saveworkplatfrom(sk, data);
                }

                for (int i = 0; i < collagename.Length; i++)
                {
                    education sk = new education();
                    sk.collagename = collagename[i];
                    sk.description = description[i];
                    sk.stariingfrom = startingyear[i] + '-' + startingmonth[i] + '-' + 01;
                    sk.endingfrom = endingyear[i] + '-' + endingmonth[i] + '-' + 01;
                    new repoclass().saveducation(sk, data);
                }
                for (int i = 0; i < companyname.Length; i++)
                {
                    workexprence sk = new workexprence();
                    sk.companyname = companyname[i];
                    sk.jobtitle = jobtitle[i];
                    sk.joblocation = joblocation[i];
                    sk.jobdescription = jobdescription[i];
                    sk.jobstariingfrom = jobstartingyear[i] + '-' + jobstartingmonth[i] + '-' + 01;
                    sk.jobendingfrom = jobendingyear[i] + '-' + jobendingmonth[i] + '-' + 01;
                    new repoclass().saveworkexprance(sk, data);
                }
            }
            return Json("sucess add",JsonRequestBehavior.DenyGet);
        }
    }
}