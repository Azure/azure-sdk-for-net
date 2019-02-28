// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Http;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Samples
{
    [Category("Live")]
    public partial class BaseSamples
    {
        [Test]
        public async Task HelloWorld()
        {
            var cancellation = new CancellationTokenSource();
            var options = new HttpPipeline.Options();
            HttpPipeline pipeline = HttpPipeline.Create(options, sdkName: "test", sdkVersion: "1.0");

            using (HttpMessage message = pipeline.CreateMessage(options, cancellation: default)) {
                var uri = new Uri(@"https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/src/SDKs/Azure.Base/data-plane/Azure.Base.sln");
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);

                await pipeline.SendMessageAsync(message).ConfigureAwait(false);

                Response response = message.Response;
                if (response.Status == 200) {
                    var reader = new StreamReader(response.ContentStream);
                    string responseText = reader.ReadToEnd();
                }
                else throw new RequestFailedException(response);
            }
        }
    }
}
