using Dapper;
using MLauncherServer.Core.Configuration;
using MLauncherServer.Core.Models;
using MySql.Data.MySqlClient;
using NLog;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MLauncherServer.Core.Services
{

    public interface IDatabaseProvider
    {
        Task<IEnumerable<UserDTO>> GetWaitingUsers();
        Task UpdateUserStatus(int id);
    }
    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly Appconfiguration _configuration;
        public DatabaseProvider(Appconfiguration appconfiguration)
        {
            _configuration = appconfiguration;
        }
        public async Task<IEnumerable<UserDTO>> GetWaitingUsers()
        {
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                return await connection.QueryAsync<UserDTO>("SELECT id, ip FROM user WHERE status='2';");
            }
        }

        public async Task UpdateUserStatus(int id)
        {
            using (var connection = new MySqlConnection(_configuration.ConnectionString))
            {
                await connection.ExecuteAsync("UPDATE user SET status=3 WHERE id=@id",
                    new
                    {
                        Id = id
                    });
            }
        }
    }
}
