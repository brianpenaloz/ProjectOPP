using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ProjectOPP.Models
{
    public class Rol
    {
        public int ID { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
}