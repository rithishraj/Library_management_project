using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Library_Management.Controllers
{
    public class searchController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Search(string str)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter($"select * from Book where Book_Title like '{str}%'", con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
    }
}