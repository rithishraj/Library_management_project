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
    public class IssuedBookController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetIssuedBook()
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Issued_book_details", con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        public IHttpActionResult GetIssuedBookById(int id)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Issued_book_details where issued_id = " + id, con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        [HttpPost]
        public IHttpActionResult PostIssuedBook([FromBody] Issued_book_details issued_Book_Details)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("insert into Issued_book_details values(@p2,@p3,@p4,@p5)", con);

                cmd.Parameters.AddWithValue("@p2", issued_Book_Details.Member_Id);
                cmd.Parameters.AddWithValue("@p3", issued_Book_Details.Book_Id);
                cmd.Parameters.AddWithValue("@p4", issued_Book_Details.Issue_start_date);
                cmd.Parameters.AddWithValue("@p5", issued_Book_Details.Issue_end_date);



                cmd.ExecuteNonQuery();
                return Ok("New Employee Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpPut]
        public IHttpActionResult PutIssuedBook([FromUri] int cid, [FromBody] Issued_book_details issued_Book_Details)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("update Issue_book_details set Issue_Id= @p1, Member_Id = @p2, Book_Id = @p3, Issue_start_date = @p4,Issue_end_date =@p5 ,Return_date =@p6 where Issue_Id = " + cid, con);
                cmd.Parameters.AddWithValue("@p1", issued_Book_Details.Issue_Id);
                cmd.Parameters.AddWithValue("@p2", issued_Book_Details.Member_Id);
                cmd.Parameters.AddWithValue("@p3", issued_Book_Details.Book_Id);
                cmd.Parameters.AddWithValue("@p4", issued_Book_Details.Issue_start_date);
                cmd.Parameters.AddWithValue("@p5", issued_Book_Details.Issue_end_date);
                cmd.Parameters.AddWithValue("@p6", issued_Book_Details.Return_date);
                cmd.ExecuteNonQuery();
                return Ok("New Employee Details saved successfuly");





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
            //alt+shift+down
            SqlCommand cmd = new SqlCommand("delete from Issued_Book_Details where Issue_Id = " + id, con);
            //  SqlDataAdapter da = new SqlDataAdapter("delete from Category where Category_Id" + id, con);
            //  DataSet ds = new DataSet();
            //  da.Fill(ds, "tab1");
            //  return Ok(ds.Tables["tab1"]);
            cmd.ExecuteNonQuery();
            return Ok("success fully deleted");







        }





    }
}