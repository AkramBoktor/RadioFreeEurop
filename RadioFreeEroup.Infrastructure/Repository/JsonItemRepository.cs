using Microsoft.EntityFrameworkCore;
using RadioFreeEroup.Domain.Entities;
using RadioFreeEroup.Domain.IJsonItem;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEroup.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RadioFreeEroup.Infrastructure.Repository
{
    public class JsonItemRepository : GenericRepository<JsonItem>,IJsonItemRepository
    {
        public JsonItemRepository(JsonItemContext context) : base(context) { }


    }
}

