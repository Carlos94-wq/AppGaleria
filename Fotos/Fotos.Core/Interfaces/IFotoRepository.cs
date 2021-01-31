using Fotos.Core.Dtos;
using Fotos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fotos.Core.Interfaces
{
    public interface IFotoRepository
    {
        IEnumerable<Entities.Fotos> GetFotos();
        Task<Entities.Fotos> GetFoto(int id);
        Task<int> Add(FotoDto fotos);
    }
}
