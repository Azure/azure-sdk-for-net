// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class AudienceErrorHandlingPolicyTests : SyncAsyncPolicyTestBase
    {
        private const string AadAudienceErrorCode = "AADSTS500011"; // Must match code in AudienceErrorHandlingPolicy

        public AudienceErrorHandlingPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        private static string ExpectedErrorMessage(bool isAudienceConfigured)
        {
            string leading = "Unable to authenticate to Azure App Configuration.";
            string detail = isAudienceConfigured
                ? " An incorrect token audience was provided."
                : " No authentication token audience was provided.";
            string guidance = $" Please set {nameof(ConfigurationClientOptions)}.{nameof(ConfigurationClientOptions.Audience)} to the appropriate audience for the target cloud. For details on how to configure the authentication token audience visit https://aka.ms/appconfig/client-token-audience.";
            return leading + detail + guidance;
        }

        private class ThrowingPolicy : HttpPipelinePolicy
        {
            private readonly string _message;
            public ThrowingPolicy(string message) => _message = message;
            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                throw new Exception(_message);
            }
            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                throw new Exception(_message);
            }
        }

        [Test]
        public void WrapsError_NoAudienceConfigured() => AssertWrapsError(isAudienceConfigured: false);

        [Test]
        public void WrapsError_WrongAudienceConfigured() => AssertWrapsError(isAudienceConfigured: true);

        [Test]
        public void NonAudienceError_PassesThrough()
        {
            var transport = new MockTransport(new MockResponse(200));
            var pipeline = new HttpPipeline(
                transport,
                new HttpPipelinePolicy[]
                {
                    new AudienceErrorHandlingPolicy(isAudienceConfigured: true), // value irrelevant since code won't match
                    new ThrowingPolicy("Simulated failure WITHOUT code")
                },
                responseClassifier: null);

            var requestUri = new Uri("http://example.com");

            Exception ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                if (IsAsync)
                {
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(requestUri);
                    await pipeline.SendAsync(message, CancellationToken.None);
                }
                else
                {
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(requestUri);
                    pipeline.Send(message, CancellationToken.None);
                }
            });

            Assert.IsNotInstanceOf<RequestFailedException>(ex); // Should not be wrapped
            Assert.AreEqual("Simulated failure WITHOUT code", ex.Message);
        }

        private void AssertWrapsError(bool isAudienceConfigured)
        {
            var transport = new MockTransport(new MockResponse(200)); // Transport won't be reached because throwing policy throws first.
            var pipeline = new HttpPipeline(
                transport,
                new HttpPipelinePolicy[]
                {
                    new AudienceErrorHandlingPolicy(isAudienceConfigured),
                    new ThrowingPolicy($"Simulated authentication failure {AadAudienceErrorCode}: Resource principal not found")
                },
                responseClassifier: null);

            var requestUri = new Uri("http://example.com");
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                if (IsAsync)
                {
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(requestUri);
                    await pipeline.SendAsync(message, CancellationToken.None);
                }
                else
                {
                    var message = pipeline.CreateMessage();
                    message.Request.Method = RequestMethod.Get;
                    message.Request.Uri.Reset(requestUri);
                    pipeline.Send(message, CancellationToken.None);
                }
            });

            Assert.NotNull(ex);
            StringAssert.Contains(ExpectedErrorMessage(isAudienceConfigured), ex.Message);
            Assert.NotNull(ex.InnerException);
            StringAssert.Contains(AadAudienceErrorCode, ex.InnerException.Message);
        }
    }
}
