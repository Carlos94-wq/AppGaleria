using Fotos.Api.Interfaces;
using Fotos.Api.Responses;
using Fotos.Core.Dtos;
using Fotos.Core.Entities;
using Fotos.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fotos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {
        private readonly IFotoRepository repository;
        private readonly IUploadFile upload;
        private readonly string Folder = "Fotos";

        public FotoController(IFotoRepository repository, IUploadFile upload)
        {
            this.repository = repository;
            this.upload = upload;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var all = this.repository.GetFotos();
            var response = new ApiResponse<IEnumerable<Core.Entities.Fotos>>(all);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var all = await this.repository.GetFoto(id);
            var response = new ApiResponse<Core.Entities.Fotos>(all);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> POST([FromForm] List<FotoDto> dtos)
        {
            var Rows = 0;

            foreach (var item in dtos)
            {
                using (var stream = new MemoryStream())
                {
                    await item.Fotos.CopyToAsync(stream);
                    var contenido = stream.ToArray();              
                    var extension = Path.GetExtension(item.Fotos.FileName);
                    item.UrlFoto = await upload.Upload(contenido, extension, Folder, item.Fotos.ContentType);
                }

                Rows = await this.repository.Add(item);
            }

            var response = new ApiResponse<int>(Rows);
            return Ok(response);
        }
    }
}
