using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codefirst_net.Models
{
    public class ClientProductViewModel
    {
        public int ClientId { get; set; }
        public List<SelectListItem> Clients { get; set; }
        public int ProductId { get; set; }
        public List<SelectListItem> Products { get; set; }
    }

}