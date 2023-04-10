using System.Threading;
using System.Threading.Tasks;

namespace Goulash.Core;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string apiKey, CancellationToken cancellationToken);
}
