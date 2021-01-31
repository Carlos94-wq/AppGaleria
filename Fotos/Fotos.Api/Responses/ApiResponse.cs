using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotos.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; }

        public ApiResponse(T data)
        {
            this.Data = data;
            Data = data;
        }

       
    }
}
