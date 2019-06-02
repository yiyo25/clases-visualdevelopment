﻿using App.Data.DataAccess;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class ArtistRepository :GenericRepository<Artist>,IArtistRepository         
    {
        public ArtistRepository(DbContext context):base(context)
        {
        }


    }
}
