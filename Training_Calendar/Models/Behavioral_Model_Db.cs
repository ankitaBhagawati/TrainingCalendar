using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Calendar.Models
{
    public class Behavioral_Model_Db
    {
        [Key]
        public int Training_Id { get; set; }
        public DateTime Date { get; set; }

        public string DateString { get; set; }
        public string Program { get; set; }
        public string Details { get; set; }
    }
}