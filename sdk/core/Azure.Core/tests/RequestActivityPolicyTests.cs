// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestActivityPolicyTests : SyncAsyncPolicyTestBase
    {
        public RequestActivityPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [NonParallelizable]
        public async Task ActivityIsCreatedForRequest()
        {
            Activity activity = null;
            KeyValuePair<string, object> startEvent = default;
            using var testListener = new TestDiagnosticListener("Azure.Pipeline");

            MockTransport mockTransport = CreateMockTransport(_ =>
            {
                activity = Activity.Current;
                startEvent = testListener.Events.Dequeue();
                return new MockResponse(201);
            });

            using Request request = mockTransport.CreateRequest();
            request.Method = RequestMethod.Get;
            request.UriBuilder.Uri = new Uri("http://example.com");
            request.Headers.Add("User-Agent", "agent");

            Task<Response> requestTask = SendRequestAsync(mockTransport, request, RequestActivityPolicy.Shared);

            await requestTask;

            KeyValuePair<string, object> stopEvent = testListener.Events.Dequeue();

            Assert.AreEqual("Azure.Core.Http.Request.Start", startEvent.Key);
            Assert.AreEqual("Azure.Core.Http.Request.Stop", stopEvent.Key);

            Assert.AreEqual("Azure.Core.Http.Request", activity.OperationName);
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.status_code", "201"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.url", "http://example.com/"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.method", "GET"));
            CollectionAssert.Contains(activity.Tags, new KeyValuePair<string, string>("http.user_agent", "agent"));
        }
    }
}
