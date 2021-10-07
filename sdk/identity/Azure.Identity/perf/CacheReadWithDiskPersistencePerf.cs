// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Test.Perf;

namespace Azure.Identity.Perf
{
    public class CacheReadWithDiskPersistencePerf : PerfTest<CountOptions>
    {
        private IdentityPerfEnvironment _environment;
        private ClientSecretCredential _credential;
        private readonly TokenRequestContext _tokenRequestContext = new(new[] { "https://storage.azure.com/.default" });

        public CacheReadWithDiskPersistencePerf(CountOptions options) : base(options)
        {
            _environment = new IdentityPerfEnvironment();

            _credential = new ClientSecretCredential(
                _environment.TenantId,
                _environment.ClientId,
                _environment.ClientSecret,
                new ClientSecretCredentialOptions { TokenCachePersistenceOptions = new TokenCachePersistenceOptions() });

            _credential.GetToken(_tokenRequestContext);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _credential.GetToken(_tokenRequestContext);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _credential.GetTokenAsync(_tokenRequestContext).ConfigureAwait(false);
        }
    }
}
