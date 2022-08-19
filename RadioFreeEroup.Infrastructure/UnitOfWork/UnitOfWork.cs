using Microsoft.EntityFrameworkCore;
using RadioFreeEroup.Domain.Entities;
using RadioFreeEroup.Domain.IJsonItem;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEroup.Infrastructure.Context;
using RadioFreeEroup.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEroup.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public Domain.IJsonItem.IJsonItemRepository JsonItemRepository { get; }
        private JsonItemContext context;

        public UnitOfWork(JsonItemContext Context, Domain.IJsonItem.IJsonItemRepository jsonItemRepository)
        {
            context = Context;
            JsonItemRepository = jsonItemRepository;
        }

   
        public int CompleteAsync()
        {
            return context.SaveChanges();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}


