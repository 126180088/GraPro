﻿using System;
namespace GraPro.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string Pwd { get; set; }

        public DateTime StartTime { get; set; }
    }
}
