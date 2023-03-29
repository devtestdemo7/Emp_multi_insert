using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    internal class repoclass
    {
        string conne = ConfigurationManager.ConnectionStrings["connection"].ToString();
        public repoclass()
        {
        }

        internal List<employee> getallemp()
        {
            using (var dc = new SqlConnection(conne))
            {
                return dc.Query<employee>("getemployee", commandType: CommandType.StoredProcedure).AsList();
            }
        }

        internal (List<employee>, List<education>, List<skil>, List<workexprence>, List<workplatfrom>) Getdetails(int id)
        {
            using (var d = new SqlConnection(conne))
            {
                var reader = d.QueryMultiple("getemployeeview", new { id }, commandType: System.Data.CommandType.StoredProcedure);
                return (
                      reader.Read<employee>().ToList(), reader.Read<education>().ToList(), reader.Read<skil>().ToList(), reader.Read<workexprence>().ToList(), reader.Read<workplatfrom>().ToList()
                   );
            }
        }

        internal List<country> getcountry()
        {
            using (var dc = new SqlConnection(conne))
            {
                return dc.Query<country>("getcountry", commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public int saveemployee(employee obj)
        {
            using (var dc = new SqlConnection(conne))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@fullname", obj.fullname);
                param.Add("@professio", obj.profession);
                param.Add("@bio ", obj.bio);
                param.Add("@dob ", obj.dob);
                param.Add("@address", obj.address);
                param.Add("@location", obj.location);
                param.Add("@phone", obj.phone);
                param.Add("@email", obj.email);
                param.Add("@website", obj.website);
                param.Add("@linkedin", obj.linkedin);
                param.Add("@twitter", obj.twitter);
                param.Add("@facebook", obj.facebook);
                param.Add("@instgram", obj.instgram);
                param.Add("@country_id", obj.country_id);
                param.Add("@profile_pic", obj.profile_pic);

                return dc.QueryFirstOrDefault<int>("addemployee", param,commandType:CommandType.StoredProcedure);
              

            }
        }

        internal bool saveworkplatfrom(workplatfrom sk, int data)
        {
            using (var dc = new SqlConnection(conne))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@platfromname", sk.platfromtitle);
                param.Add("@wp_description", sk.wp_description);
                param.Add("@emp_id", data);

                return dc.Execute("addworkplatfrom", param, commandType: CommandType.StoredProcedure) > 0;


            }
        }

        internal bool saveducation(education sk, int data)
        {
            using (var dc = new SqlConnection(conne))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@collcgename", sk.collagename);
                param.Add("@description", sk.description);
                param.Add("@starting", sk.stariingfrom);
                param.Add("@ending", sk.endingfrom);
                param.Add("@emp_id", data);

                return dc.Execute("addeducation", param, commandType: CommandType.StoredProcedure) > 0;


            }
        }

        internal bool saveworkexprance(workexprence sk, int data)
        {
            using (var dc = new SqlConnection(conne))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@companyname", sk.companyname);
                param.Add("@jobtitle", sk.jobtitle);
                param.Add("@joblocation", sk.joblocation);
                param.Add("@jobdescription", sk.jobdescription);
                param.Add("@jonstarting", sk.jobstariingfrom);
                param.Add("@jobending", sk.jobendingfrom);
                param.Add("@emp_id", data);

                return dc.Execute("addworkexprance", param, commandType: CommandType.StoredProcedure) > 0;


            }
        }

        internal bool saveskil(skil sk, int data)
        {
            using (var dc = new SqlConnection(conne))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@skilname", sk.skilname);
                param.Add("@percentage", sk.percentage);
                param.Add("@emp_id",data);
                
                return dc.Execute("addskil", param, commandType: CommandType.StoredProcedure)>0;


            }
        }
    }
}