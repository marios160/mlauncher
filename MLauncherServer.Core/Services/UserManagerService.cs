using NLog;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MLauncherServer.Core.Services
{
    public interface IUserManagerService
    {
        Task ProcessUsers();
    }

    public class UserManagerService : IUserManagerService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IDatabaseProvider _databaseProvider;

        public UserManagerService(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task ProcessUsers()
        {
            var userList = await _databaseProvider.GetWaitingUsers();

            Logger.Info($"{userList.Count()} waiting users found");

            foreach (var user in userList)
            {
                //TODO: logs
                AddFirewallException(user.IP);
                await _databaseProvider.UpdateUserStatus(user.Id);
            }
        }

        private void AddFirewallException(string ip)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "iptables",
                Arguments = $"-A INPUT -s {ip} -j ACCEPT"
            };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }
    }
}
