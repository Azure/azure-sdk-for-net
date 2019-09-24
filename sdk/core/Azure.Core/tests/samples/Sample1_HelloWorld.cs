// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Core.Samples
{
    [LiveOnly]
    public partial class BaseSamples
    {
        [Test]
        public async Task HelloWorld()
        {
            var pipeline = new HttpPipeline(new HttpClientTransport());

            Http.Request request = pipeline.CreateRequest();

            var uri = new Uri(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/README.md");
            request.Method = RequestMethod.Get;
            request.UriBuilder.Assign(uri);
            request.Headers.Add("Host", uri.Host);

            Response response = await pipeline.SendRequestAsync(request, cancellationToken: default).ConfigureAwait(false);

            if (response.Status == 200)
            {
                var reader = new StreamReader(response.ContentStream);
                _ = reader.ReadToEnd();
            }
            else
                throw await response.CreateRequestFailedExceptionAsync();
        }
    }
}
