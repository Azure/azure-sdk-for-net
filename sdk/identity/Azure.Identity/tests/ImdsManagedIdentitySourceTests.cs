// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ImdsManagedIdentitySourceTests : ClientTestBase
    {
        private string _expectedResourceId = $"/subscriptions/{Guid.NewGuid().ToString()}/locations/MyLocation";

        public ImdsManagedIdentitySourceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void VerifyAuthenticateDoesNotLogTokenOnTaskCancelled()
        {
            var mockTransport = new MockTransport(request => CreateMockResponse(200, "secret").WithHeader("Content-Type", "application/json"));
            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.Zero;
            var pipeline = CredentialPipeline.GetInstance(options);
            var mockClient = new MockManagedIdentityClient(pipeline)
            {
                TokenFactory = () => { return new AccessToken("secret", DateTimeOffset.UtcNow.AddHours(24)); }
            };
            ImdsManagedIdentitySource source = new ImdsManagedIdentitySource(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = "mock-client-id" });

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await source.AuthenticateAsync(IsAsync, new TokenRequestContext(MockScopes.Default), new CancellationToken(true)));
            Assert.IsInstanceOf(typeof(TaskCanceledException), ex.InnerException);
            Assert.That(ex.Message, Does.Not.Contain("secret"));
        }

        private MockResponse CreateMockResponse(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            string jsonData = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"3600\" }}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            response.ContentStream = new MemoryStream(byteArray);
            return response;
        }
    }
}
