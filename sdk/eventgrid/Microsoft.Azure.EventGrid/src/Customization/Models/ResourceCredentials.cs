// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Microsoft.Azure.EventGrid.Models
{
    public class ResourceCredentials : ServiceClientCredentials
    {
        readonly string resourceKey;

        public ResourceCredentials(string resourceKey)
        {
            this.resourceKey = resourceKey;
        }

        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
        }

        public override async Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("aeg-sas-key", this.resourceKey);
            await base.ProcessHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
