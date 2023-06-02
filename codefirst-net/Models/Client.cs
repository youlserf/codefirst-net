using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codefirst_net.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}