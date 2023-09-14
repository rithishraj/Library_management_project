using Library_management_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
namespace Library_Management.Controllers
{

    public class ValuesController : ApiController
    {



        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Category", con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        [HttpGet]
        public IHttpActionResult GetCategoryById([FromUri] int cid)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Category where Category_id=" + cid, con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);







        }
        [HttpPost]





        public IHttpActionResult PostCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("insert into Category values(@p1,@p2,@p3)", con);
                cmd.Parameters.AddWithValue("@p1", category.Category_Id);
                cmd.Parameters.AddWithValue("@p2", category.Category_Name);
                cmd.Parameters.AddWithValue("@p3", category.Category_Description);





                cmd.ExecuteNonQuery();
                return Ok("New  Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpPut]
        public IHttpActionResult PutCategory([FromUri] int cid, [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("update Category set Category_Id=@p1, Category_Name=@p2,Category_Description=@p3 where Category_Id=" + cid, con);
                cmd.Parameters.AddWithValue("@p1", category.Category_Id);
                cmd.Parameters.AddWithValue("@p2", category.Category_Name);
                cmd.Parameters.AddWithValue("@p3", category.Category_Description);





                cmd.ExecuteNonQuery();
                return Ok("New Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {







            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("delete from Category where Category_Id =" + id, con);
            cmd.ExecuteNonQuery();
            return Ok("deleted");











        }







    }
}