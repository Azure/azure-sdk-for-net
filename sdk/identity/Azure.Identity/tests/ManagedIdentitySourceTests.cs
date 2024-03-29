// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    public class ManagedIdentitySourceTests : ClientTestBase
    {
        private string _expectedResourceId = $"/subscriptions/{Guid.NewGuid().ToString()}/locations/MyLocation";

        public ManagedIdentitySourceTests(bool isAsync) : base(isAsync)
        {
        }

        public static IEnumerable<object[]> ManagedIdentitySources()
        {
            var mockTransport = new MockTransport(request => CreateMockResponse(200, "secret").WithHeader("Content-Type", "application/json"));
            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.Zero;
            var pipeline = CredentialPipeline.GetInstance(options);
            var mockClient = new MockManagedIdentityClient(pipeline)
            {
                TokenFactory = () => { return new AccessToken("secret", DateTimeOffset.UtcNow.AddHours(24)); }
            };
            var miCredOptions = new ManagedIdentityClientOptions { Pipeline = pipeline };
            var endpoint = new Uri("https://localhost");

            yield return new object[] { new ImdsManagedIdentitySource(new ManagedIdentityClientOptions { Pipeline = pipeline, ClientId = "mock-client-id" }) };
            yield return new object[] { new AppServiceV2017ManagedIdentitySource(pipeline, endpoint, "mysecret", miCredOptions) };
            yield return new object[] { new AppServiceV2019ManagedIdentitySource(pipeline, endpoint, "mysecret", miCredOptions) };
            yield return new object[] { new AzureArcManagedIdentitySource(endpoint, miCredOptions) };
            yield return new object[] { new CloudShellManagedIdentitySource(endpoint, miCredOptions) };
            yield return new object[] { new ServiceFabricManagedIdentitySource(pipeline, endpoint, "myHeader", miCredOptions) };
        }

        [Test]
        [TestCaseSource(nameof(ManagedIdentitySources))]
        public void VerifyAuthenticateDoesNotLogTokenOnTaskCancelled(object miSource)
        {
            var source = (ManagedIdentitySource)miSource;
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await source.AuthenticateAsync(IsAsync, new TokenRequestContext(MockScopes.Default), new CancellationToken(true)));
            Assert.IsInstanceOf(typeof(TaskCanceledException), ex.InnerException);
            Assert.That(ex.Message, Does.Not.Contain("secret"));
            Assert.That(ex.Message, Does.Contain("Response from Managed Identity was successful, but the operation timed out prior to completion."));
        }

        [Test]
        public void FirstTokenRequestUses1secTimeoutWithNoRetries()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions() { Transport = mockTransport };
            var pipeline = CredentialPipeline.GetInstance(options);
            var cred = new DefaultAzureCredential(new DefaultAzureCredentialOptions
            {
                ExcludeAzureCliCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeAzurePowerShellCredential = true,
                ExcludeEnvironmentCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeVisualStudioCodeCredential = true,
                ExcludeVisualStudioCredential = true,
                ExcludeWorkloadIdentityCredential = true,
                Transport = mockTransport
            });

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            Assert.AreEqual(1, networkTimeouts.Count);
            var expectedTimeouts = new TimeSpan?[] { TimeSpan.FromSeconds(1) };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        private static MockResponse CreateMockResponse(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            string jsonData = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"3600\" }}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            response.ContentStream = new MemoryStream(byteArray);
            return response;
        }
    }
}
