﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[Table(Name = "TUsers")]
    public class TUsers
    {
        [PrimaryKey, Identity]
        public int ID { get; set; }
        public string NID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Users { get; set; }
        public string Telephone { get; set; }
        public string Role { get; set; }
        public string Date { get; set; }
    }
}
