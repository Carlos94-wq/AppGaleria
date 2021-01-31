using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fotos.Api.Interfaces
{
    public class UploadFiles: IUploadFile
    {
        private readonly IWebHostEnvironment web;
        private readonly IHttpContextAccessor http;
        ///crea la url de recurso  determina la url del domindo
        public UploadFiles(IWebHostEnvironment web, IHttpContextAccessor http)
        {
            this.web = web;
            this.http = http;
        }

        public async Task<string> Upload(byte[] contenido, string extension, string contenendor, string ConentType)
        {
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(web.WebRootPath, contenendor);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);
            await File.WriteAllBytesAsync(ruta, contenido);

            var CurrentUrl = $"{http.HttpContext.Request.Scheme}://{http.HttpContext.Request.Host}";
            var BaseUrl = Path.Combine(CurrentUrl, contenendor, nombreArchivo).Replace("\\", "//");

            return BaseUrl;
        }
    }
}
