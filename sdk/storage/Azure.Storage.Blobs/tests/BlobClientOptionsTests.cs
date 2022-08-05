// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class BlobClientOptionsTests
    {
        [Test]
        public void SetGeoRedundancyMode()
        {
            const string primaryHost = "foo.blob.core.windows.net";
            var primaryUri = new Uri("https://" + primaryHost);
            const string secondaryHost = "foo-secondary.blob.core.windows.net";
            var secondaryUri = new Uri("https://" + secondaryHost);

            // set mode that changes first request
            var options = new BlobClientOptions
            {
                GeoRedundantSecondaryUri = secondaryUri,
                GeoRedundantReadMode = GeoRedundantReadMode.SecondaryOnly,
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
