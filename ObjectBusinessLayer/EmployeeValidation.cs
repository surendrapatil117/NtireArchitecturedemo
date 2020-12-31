using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ObjectBusinessLayer
{
    public class EmployeeValidation
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Position")]
        public string Position { get; set; }

       
       

    }
    [MetadataType(typeof(EmployeeValidation))]
    public partial class Employee
    {
        public SelectList CityList { get; set; }

    }
}
