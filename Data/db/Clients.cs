﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace coursedb.Data.db
{
    public partial class Clients
    {
        public Clients()
        {
            Orders = new HashSet<Orders>();
        }

        public int Clientid { get; set; }
        public string Clientname { get; set; }

        [NotMapped]
        public int OrderCount { get; set; }
        [NotMapped]
        public bool HasActive { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}