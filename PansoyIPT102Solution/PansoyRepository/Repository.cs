using Dapper;
using Microsoft.Data.SqlClient;
using Repository.Interface;

namespace Repository
{
    public class Repository<M> : IRepository<M>
    {
        private SqlConnection CreateConnection(string connectionString)
        => new SqlConnection(connectionString);

        public async Task<IEnumerable<M>> ObtainAllAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            )
        {
            using var connection = CreateConnection(connectionString);
            return await connection.QueryAsync<M>(
                storedProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
        }

        public async Task<M> ObtainByIdAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            )

        {
            using var connection = CreateConnection(connectionString);
            return await connection.QueryFirstOrDefault
                (
                storedProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
        }

        public async Task<bool> CreateAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            )

        {
            using var connection = CreateConnection(connectionString);
            var result = await connection.ExecuteAsync(
                storedProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );
            return result > 0;
        }

        public async Task<bool> UpdateAsync(
            string connectionString,
            string storedProcedureName,
            DynamicParameters parameters = null
            )

        {
            using var connection = CreateConnection(connectionString);
            var result = await connection.ExecuteAsync(
                storedProcedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );

            return result > 0;
        }

        public async Task<bool> DeleteAsync(
             string connectionString,
             string procedureName,
             DynamicParameters parameters = null
             )

        {
            using var connection = CreateConnection(connectionString);
            var result = await connection.ExecuteAsync(
                procedureName,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
                );

            return result > 0;
        }

    }

}

