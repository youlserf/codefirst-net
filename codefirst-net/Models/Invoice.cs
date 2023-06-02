using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace codefirst_net.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        // Navigation property for related products through the Details table
        public virtual ICollection<Detail> Details { get; set; }
    }
}