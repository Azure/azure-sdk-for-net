// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Networks.Tests
{
    using Microsoft.Rest;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class MockServiceClientCredentials : ServiceClientCredentials
    {
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            base.InitializeServiceClient(client);
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
