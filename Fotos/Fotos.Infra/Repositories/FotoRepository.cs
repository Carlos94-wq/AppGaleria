using Dapper;
using Fotos.Core.Dtos;
using Fotos.Core.Entities;
using Fotos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotos.Infra.Repositories
{
    public class FotoRepository : IFotoRepository
    {
        private readonly IDbConnection db;

        public FotoRepository( IDbConnection db )
        {
            this.db = db;
        }

        public IEnumerable<Core.Entities.Fotos> GetFotos()
        {
            using (var con = this.db)
            {
                con.Open();
                var Foto = this.db.Query<Core.Entities.Fotos>(
                    sql: "spFotos",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        Accion = 1
                    }
                );

                return Foto;
            }
        }

        public async Task<Core.Entities.Fotos> GetFoto(int id)
        {
            using (var con = this.db)
            {
                con.Open();
                var Fotos = await this.db.QueryAsync<Core.Entities.Fotos>(
                    sql: "spFotos",
                    commandType: CommandType.StoredProcedure,
                    param: new
                    {
                        Accion = 1,
                        IdFoto = id
                    }
                ).ConfigureAwait(false);

                return Fotos.FirstOrDefault();
            }
        }

        public async Task<int> Add(FotoDto fotos)
        {
           var Rows = await this.db.ExecuteAsync(sql: "spFotos", commandType: CommandType.StoredProcedure, param: new
            {
                Accion = 3,
                Foto = fotos.UrlFoto
            });

            return Rows;
        }
    }
}
