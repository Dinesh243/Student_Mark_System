//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Mark_System.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Records
    {
        public int Student_Id { get; set; }
        public string Roll_No { get; set; }
        public string Name { get; set; }
        public int Tamil { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int Social { get; set; }
        public int Total { get; set; }
        public decimal Avarge { get; set; }
        public bool Is_Deleted { get; set; }
        public System.DateTime Created_Time_Stamp { get; set; }
        public System.DateTime Updated_Time_Stamp { get; set; }
    }
}
