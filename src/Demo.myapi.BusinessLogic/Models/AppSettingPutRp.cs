using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.myapi.BusinessLogic.Models
{
    public class AppSettingPutRp
    {
        [Required]
        public string Value { get; set; }
    }
}
