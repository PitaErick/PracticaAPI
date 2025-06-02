
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace practica.controllers.Database
{
    public class SqlHelper
    {
        private readonly ContextDB _contextDB;
        private IDbContextTransaction? _transaction;
        public SqlHelper(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }
        public async Task IniciarTransaccion()
        {
            if (_transaction == null)
            {
                _transaction = await _contextDB.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransaccion()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransaccion()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task EjecutarSpAsync(string spName, SqlParameter[]? parametros = null)
        {
            string query = $"EXEC {spName}";
            if (parametros != null && parametros.Any())
            {
                query += " " + string.Join(",", parametros.Select((p) => p.ParameterName));
            }
            await _contextDB.Database.ExecuteSqlRawAsync(query, parametros ?? Array.Empty<SqlParameter>());
        }

        public async Task<List<T>> ListarAsync<T>(string spName, SqlParameter[]? parametros = null) where T : class
        {
            string query = $"EXEC {spName}";
            if (parametros != null && parametros.Any())
            {
                query += " " + string.Join(",", parametros.Select((p) => p.ParameterName));
            }
            return await _contextDB.Set<T>().FromSqlRaw(query, parametros ?? Array.Empty<SqlParameter>()).ToListAsync();

        }

        public async Task<T> ObtenerAsync<T>(string spName, SqlParameter[]? parametros = null) where T : class
        {
            string query = $"EXEC {spName}";
            if (parametros != null && parametros.Any())
            {
                query += " " + string.Join(",", parametros.Select((p) => p.ParameterName));
            }
            var result = await _contextDB.Set<T>().FromSqlRaw(query, parametros ?? Array.Empty<SqlParameter>()).ToListAsync();
            return result.Single();

        }
    }
}
