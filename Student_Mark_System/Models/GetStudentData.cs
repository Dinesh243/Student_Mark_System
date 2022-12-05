using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Mark_System.Models
{
    public class GetStudentData
    {
        [Key]
        public int Student_Id { get; set; }
        [Required]
        public string Roll_No { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public int Tamil { get; set; }
        [Required]
        public int English { get; set; }
        [Required]
        public int Maths { get; set; }
        [Required]
        public int Science { get; set; }
        [Required]
        public int Social { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public decimal Avarge { get; set; }        
        public bool Is_Deleted { get; set; }        
        public System.DateTime Created_Time_Stamp { get; set; }        
        public System.DateTime Updated_Time_Stamp { get; set; }
       
    }
}