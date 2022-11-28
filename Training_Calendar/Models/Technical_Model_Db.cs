using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_Calendar.Models
{
    public class Technical_Model_Db
    {
        [Key]
        public int Training_Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string DateString { get; set; }
        public string Program { get; set; }
        public string Facillator { get; set; }
        public string Details { get; set; }
    }
}