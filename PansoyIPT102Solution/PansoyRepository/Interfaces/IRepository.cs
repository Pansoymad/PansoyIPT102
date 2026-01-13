using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Repository.Interface
{
    public interface IRepository<M>
    {
        Task<IEnumerable<M>> ObtainAllAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            );

        Task<M> ObtainByIdAsync(
            string connectionString,

            string storedProcedureName,
            DynamicParameters parameters = null
            );

        Task<bool> CreateAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            );

        Task<bool> UpdateAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            );

        Task<bool> DeleteAsync(
            string connectionString,
            string procedureName,
            DynamicParameters parameters = null
            );
    }
}
