// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent;

namespace Azure.Tests
{
    public class TestAzureCredentials : AzureCredentials
    {
        public TestAzureCredentials(string username, string password, string clientId, string tenantId, AzureEnvironment environment) : base(username, password, clientId, tenantId, environment)
        {
        }

        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
#if !NETSTANDARD11
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return;
            }
#endif
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }


    }
}
