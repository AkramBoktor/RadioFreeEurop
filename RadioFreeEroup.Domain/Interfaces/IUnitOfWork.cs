using RadioFreeEroup.Domain.IJsonItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEroup.Domain.Interfaces
{
    public interface IUnitOfWork  : IDisposable
    {
        IJsonItemRepository JsonItemRepository { get; }

        int CompleteAsync();
    }
}
