using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotos.Api.Interfaces
{
    public interface IUploadFile
    {
        Task<string> Upload(byte[] contenido, string extension, string contenendor, string ConentType);
    }
}
