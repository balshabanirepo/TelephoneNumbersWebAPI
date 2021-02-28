using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneNumbersWebAPI.Models
{
    public class TelephoneDirectory
    {
        [Key]
        public int Id { get; set; }
       
        public string PhoneNumber { get; set; }

      
    }
}
