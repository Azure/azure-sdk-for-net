// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class RequestRecorderTests : OperationTemplatesTestBase
    {
        [TestCase("/wrong", "?api-version=2023-12-01-preview", """{"format":"csv"}""")]
        [TestCase("/expected", "?api-version=wrong", """{"format":"csv"}""")]
        [TestCase("/expected", "?api-version=2023-12-01-preview", """{"format":"wrong"}""")]
        public void RejectsWrongPathVersionOrBody(string path, string query, string body)
        {
            var requests = new RequestRecorder();
            using var request = new HttpClientTransport().CreateRequest();
            request.Method = RequestMethod.Post;
            request.Uri.Reset(new Uri($"https://localhost{path}{query}"));
            requests.Record(request, body);

            Assert.Throws<AssertionException>(() =>
                requests.AssertRequest(0, "POST", "/expected", """{"format":"csv"}"""));
        }
    }
}
