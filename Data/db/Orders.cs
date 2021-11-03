﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace coursedb.Data.db
{
    public partial class Orders
    {
        public int Orderid { get; set; }
        public int Clientid { get; set; }
        public int Typeid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public byte? Eff { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Types Type { get; set; }
        public virtual Docs Docs { get; set; }

        public Orders()
        {
            Startdate = DateTime.Now;
            Enddate = DateTime.Now.AddDays(28);
        }
    }
}