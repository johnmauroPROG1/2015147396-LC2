﻿using _2015104916.Entities.Entities;
using _2015104916.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Persistence.Repositories
{
    public class CinturonRepository : Repository<Cinturon>, ICinturonRepository
    {
        public CinturonRepository(_2015147396DbContext context) : base(context)
        {

        }
    }
}
