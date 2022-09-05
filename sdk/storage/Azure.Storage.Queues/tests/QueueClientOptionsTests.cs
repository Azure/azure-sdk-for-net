// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Queues.Tests
{
    public class QueueClientOptionsTests
    {
        [Test]
        public void SetGeoRedundancyMode()
        {
            const string primaryHost = "foo.dfs.core.windows.net";
            var primaryUri = new Uri("https://" + primaryHost);
            const string secondaryHost = "foo-secondary.dfs.core.windows.net";
            var secondaryUri = new Uri("https://" + secondaryHost);

            // set mode that changes first request
            var options = new QueueClientOptions
            {
                GeoRedundantSecondaryUri = secondaryUri,
                GeoRedundantReadMode = GeoRedundantReadMode.SecondaryThenPrimary,
                Transport = new MockTransport(new MockResponse(200))
            };
            // policy to observe change in pipeline (observe changed to secondary host)
            options.AddPolicy(
                new AssertMessageContentsPolicy(checkRequest: r => Assert.AreEqual(secondaryHost, r.Uri.Host))
                {
                    CheckRequest = true
                },
                HttpPipelinePosition.PerRetry);

            var request = new MockRequest()
            {
                Method = RequestMethod.Get,
            };
            // original request to primary host
            request.Uri.Reset(primaryUri);

            // Act
            options.Build().SendRequest(request, CancellationToken.None);

            // Assertion in pipeline
        }
    }
}
