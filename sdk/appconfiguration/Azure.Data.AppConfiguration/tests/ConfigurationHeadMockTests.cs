// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;
using NUnit.Framework;
using System;

namespace Azure.Data.AppConfiguration.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public partial class ConfigurationMockTests: ClientTestBase
    {
        class HeadRequestPolicy : SynchronousHttpPipelinePolicy
        {
            public readonly static HttpPipelinePolicy Shared = new HeadRequestPolicy();

            private HeadRequestPolicy() { }

            public override void OnSendingRequest(HttpPipelineMessage message)
                => message.Request.Method = RequestMethod.Head;          
        }

        class HeadRequestTransport : MockTransport
        {
            static readonly Func<MockRequest, MockResponse> Impl = (MockRequest) =>
            {
                var response = new MockResponse(200);
                response.ContentStream = Stream.Null;
                return response;
            };

            public readonly static HttpPipelineTransport Shared = new HeadRequestTransport();

            private HeadRequestTransport() : base(Impl) {
            }
        }

        [Test]
        public async Task HeadRequest()
        {
            ConfigurationClient service = CreateTestService(HeadRequestTransport.Shared, headRequests: true);

            Response<ConfigurationSetting> typedRetting = await service.GetAsync(s_testSetting.Key);
            Response response = typedRetting.GetRawResponse();

            Assert.AreEqual(response.Status, 200);
        }
    }
}
