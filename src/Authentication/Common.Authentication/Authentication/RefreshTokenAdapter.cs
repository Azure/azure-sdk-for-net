using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Common.Authentication.Authentication
{
    public class RefreshTokenAdapter : Rest.ITokenProvider
    {
        RefreshTokenProvider _provider;
        AdalConfiguration _config;
        string _userId;

        public RefreshTokenAdapter(RefreshTokenProvider provider, string userId, AdalConfiguration config)
        {
            _provider = provider;
            _userId = userId;
            _config = config;
        }

        public async Task<AuthenticationHeaderValue> GetAuthenticationHeaderAsync(CancellationToken cancellationToken)
        {
            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var task = new Task<IAccessToken>(
                () =>
                {
                    var taskToken = _provider.GetAccessToken(_config, ShowDialog.Never, _userId, null,
                        AzureAccount.AccountType.RefreshToken);
                    return taskToken;
                });
            task.Start(scheduler);
            var token = await task.ConfigureAwait(false);
            return new AuthenticationHeaderValue("Bearer", token.AccessToken);
        }
    }
}
