//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_management_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issued_book_details
    {
        public int Issue_Id { get; set; }
        public Nullable<int> Member_Id { get; set; }
        public Nullable<int> Book_Id { get; set; }
        public Nullable<System.DateTime> Issue_start_date { get; set; }
        public Nullable<System.DateTime> Issue_end_date { get; set; }
        public Nullable<System.DateTime> Return_date { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
