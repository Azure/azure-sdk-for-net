// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Test.HttpRecorder;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Azure.Tests
{
    public class TestAzureCredentials : AzureCredentials
    {
        public TestAzureCredentials(ServicePrincipalLoginInformation servicePrincipalLoginInformation,
            string tenantId, AzureEnvironment environment)
            : base(servicePrincipalLoginInformation, tenantId, environment)
        {
        }

        public async override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                return;
            }
            await base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
