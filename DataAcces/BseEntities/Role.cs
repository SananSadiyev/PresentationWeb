﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.BseEntities
{
    public class Role :BaseEntities
    {
        public string Name { get; set; }

        public List<UserRole> UserRole { get; set; }
    }
}
