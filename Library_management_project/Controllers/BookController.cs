using Library_management_project.Models;
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
    public class BookController : ApiController
    {

        [HttpGet]

        public IHttpActionResult GetBook()
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Book", con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        [HttpGet]
        public IHttpActionResult GetBookById([FromUri] int cid)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Book where Category_Id=" + cid, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);







        }
        public IHttpActionResult PostBook([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("insert into Book values(@p1,@p2,@p3,@p4,@p5,@p6)", con);
                cmd.Parameters.AddWithValue("@p1", book.Book_Id);
                cmd.Parameters.AddWithValue("@p2", book.Book_Title);
                cmd.Parameters.AddWithValue("@p3", book.Book_Description);
                cmd.Parameters.AddWithValue("@p4", book.Author_Name);
                cmd.Parameters.AddWithValue("@p5", book.Category_Id);
                cmd.Parameters.AddWithValue("@p6", book.Available_Quantity);





                cmd.ExecuteNonQuery();
                return Ok("New Employee Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpPut]
        public IHttpActionResult Put([FromUri] int id, [FromBody] Book book)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("update Book set Book_Id=@p1,Book_Title=@p2,Book_Description=@p3,Author_Name=@p4, Available_Quantity=@p5 where Book_Id=" + id, con);
                cmd.Parameters.AddWithValue("@p1", book.Book_Id);
                cmd.Parameters.AddWithValue("@p2", book.Book_Title);
                cmd.Parameters.AddWithValue("@p3", book.Book_Description);
                cmd.Parameters.AddWithValue("@p4", book.Author_Name);
                cmd.Parameters.AddWithValue("@p5", book.Available_Quantity);





                cmd.ExecuteNonQuery();
                return Ok("New Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();



            SqlCommand cmd = new SqlCommand("delete from Book where Book_Id =" + id, con);
            cmd.ExecuteNonQuery();
            return Ok("deleted");
        }
    }
}

