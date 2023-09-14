using Library_management_project.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Member = Library_management_project.Models.Member;

namespace Library_Management.Controllers
{
    public class MemberController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetMember()
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Member", con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        public IHttpActionResult GetMemberById(int id)
        {
            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Member where MemberId = " + id, con);
            DataSet ds = new DataSet(); da.Fill(ds, "tab1");
            return Ok(ds.Tables["tab1"]);





        }
        [HttpPost]
        public IHttpActionResult PostMember(Member member)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("insert into Member values(@p1,@p2,@p3,@p4,@p5,@p6)", con);
                cmd.Parameters.AddWithValue("@p1", member.Member_Id);
                cmd.Parameters.AddWithValue("@p2", member.Name);
                cmd.Parameters.AddWithValue("@p3", member.Email);
                cmd.Parameters.AddWithValue("@p4", member.Password);
                cmd.Parameters.AddWithValue("@p5", member.Address);
                cmd.Parameters.AddWithValue("@p6", member.Role);
                cmd.ExecuteNonQuery();
                return Ok("New Member Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpPut]
        public IHttpActionResult PutMember([FromUri] int cid, [FromBody] Member member)
        {
            if (ModelState.IsValid)
            {





                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("update Member set Member_Id= @p1, Name = @p2, Email = @p3, Password = @p4,Address=@p5 ,Role =@p6 where Member_Id = " + cid, con);
                cmd.Parameters.AddWithValue("@p1", member.Member_Id);
                cmd.Parameters.AddWithValue("@p2", member.Name);
                cmd.Parameters.AddWithValue("@p3", member.Email);
                cmd.Parameters.AddWithValue("@p4", member.Password);
                cmd.Parameters.AddWithValue("@p5", member.Address);
                cmd.Parameters.AddWithValue("@p6", member.Role);
                cmd.ExecuteNonQuery();
                return Ok("New Employee Details saved successfuly");





            }
            else
            {
                return BadRequest("not valid requests" + ModelState);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {







            string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //alt+shift+down
            SqlCommand cmd = new SqlCommand("delete from Member where Member_Id = " + id, con);
            //  SqlDataAdapter da = new SqlDataAdapter("delete from Category where Category_Id" + id, con);
            //  DataSet ds = new DataSet();
            //  da.Fill(ds, "tab1");
            //  return Ok(ds.Tables["tab1"]);
            cmd.ExecuteNonQuery();
            return Ok("success fully deleted");







        }
        [HttpPut]
        public IHttpActionResult Checkout(int id)
        {
            {
                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("UPDATE Book SET Available_Quantity = Available_Quantity - 1 WHERE Book_Id=" + id, con);
                cmd.ExecuteNonQuery();
                return Ok("Book Checked out");
            }



        }
        [HttpPut]
        public IHttpActionResult returnbookr([FromUri] int rid, [FromBody] Member member)
        {
            {
                string constr = @"initial catalog=Library;Data source=LAPTOP-8VOAQEUN\SQLEXPRESS; integrated security=false; user id=arun; password=1234";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                //alt+shift+down
                SqlCommand cmd = new SqlCommand("UPDATE Book SET Available_Quantity = Available_Quantity +1 WHERE Book_Id=" + rid, con);
                cmd.ExecuteNonQuery();
                return Ok("Book Checked out");
            }



        }



    }
}