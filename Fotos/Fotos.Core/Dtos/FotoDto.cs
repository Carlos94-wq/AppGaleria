using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fotos.Core.Dtos
{
    public class FotoDto
    {
        public int IdFoto { get; set; }
        public IFormFile Fotos { get; set; }
        public DateTime FechaCarga { get; set; }

        public string UrlFoto { get; set; }
    }
}
