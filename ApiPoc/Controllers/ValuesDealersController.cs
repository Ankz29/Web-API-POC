using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiPoc.Models;
using System.Web.Mvc;
namespace ApiPoc.Controllers
{

    public class ValuesDealersController : ApiController
    {
        // GET api/values
        public IEnumerable<Values> Get(int Zip)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=SLP160161-ANKIT\SQLEXPRESS; Initial Catalog=PTAC_Dealer_DB; Integrated Security= true";
            con.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = "select * from [PTAC_Dealer_TB] where [SUBFZIP] ='" + Zip + "' ";
            cmd.Connection = con;
            SqlDataReader rd = cmd.ExecuteReader();

            //List<Data> model = new List<Data>();
            List<Values> modelData = new List<Values>();

            while (rd.Read())
            {
                Values model = new Values();
                model.DealerName = rd[0].ToString();
                model.Address = rd[1].ToString();
                model.City = rd[2].ToString();
                model.State = rd[3].ToString();
                model.Zip = rd[4].ToString();
                model.PhoneNumber = rd[5].ToString();
                model.PhoneNumber2 = rd[6].ToString();
                modelData.Add(model);
            }

            return modelData;

        }


        // GET api/values/5
        //public string Get(string Zip)
        //{


        //     SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @"Data Source=SLP160161-ANKIT\SQLEXPRESS; Initial Catalog=PTAC_Dealer_DB; Integrated Security= true";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "select * from [PTAC_Dealer_TB] ";
        //    cmd.Connection = con;
        //    SqlDataReader rd = cmd.ExecuteReader();

        //     //List<Data> model = new List<Data>();
        //    Values modelData = new Values();
        //    while (rd.Read())
        //    {

        //        modelData.Description = rd[0].ToString();
        //        modelData.Address = rd[1].ToString();
        //        modelData.City = rd[2].ToString();
        //        modelData.State = rd[3].ToString();
        //        modelData.Zip = rd[4].ToString();
        //        modelData.PhoneNumber = rd[5].ToString();
        //        modelData.PhoneNumber2 = rd[6].ToString();
        //    }
        //    return (modelData.ToString());
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
