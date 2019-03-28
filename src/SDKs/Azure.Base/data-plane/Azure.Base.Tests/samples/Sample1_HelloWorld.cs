﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Base.Samples
{
    [Category("Live")]
    public partial class BaseSamples
    {
        [Test]
        public async Task HelloWorld()
        {
            var pipeline = new HttpPipeline(new HttpClientTransport());

            var request = pipeline.CreateRequest();

            var uri = new Uri(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/src/SDKs/Azure.Base/data-plane/README.md");
            request.SetRequestLine(HttpVerb.Get, uri);
            request.AddHeader("Host", uri.Host);

            Response response = await pipeline.SendRequestAsync(request, cancellationToken: default).ConfigureAwait(false);

            if (response.Status == 200) {
                var reader = new StreamReader(response.ContentStream);
                string responseText = reader.ReadToEnd();
            }
            else throw new RequestFailedException(response);
        }
    }
}
