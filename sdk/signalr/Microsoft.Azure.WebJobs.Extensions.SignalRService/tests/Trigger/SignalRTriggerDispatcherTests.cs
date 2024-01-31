// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Serverless.Protocols;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Options;
using Moq;
using SignalRServiceExtension.Tests.Utils;
using Xunit;
using ExecutionContext = Microsoft.Azure.WebJobs.Extensions.SignalRService.ExecutionContext;

namespace SignalRServiceExtension.Tests
{
    public class SignalRTriggerDispatcherTests
    {
        public static IEnumerable<object[]> AttributeData()
        {
            yield return new object[] { "connections", "connected", false };
            yield return new object[] { "connections", "disconnected", false };
            yield return new object[] { "connections", Guid.NewGuid().ToString(), true };
            yield return new object[] { "messages", Guid.NewGuid().ToString(), false };
            yield return new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true };
        }

        [Theory]
        [MemberData(nameof(AttributeData))]
        public async Task DispatcherMappingTest(string category, string @event, bool throwException)
        {
            var resolve = new TestRequestResolver();
            var dispatcher = new SignalRTriggerDispatcher(resolve);
            var key = (hub: Guid.NewGuid().ToString(), category, @event);
            var tcs = new TaskCompletionSource<ITriggeredFunctionExecutor>(TaskCreationOptions.RunContinuationsAsynchronously);
            var executorMoc = new Mock<ITriggeredFunctionExecutor>();
            executorMoc.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new FunctionResult(true)));
            var executor = executorMoc.Object;
            if (throwException)
            {
                Assert.ThrowsAny<Exception>(() => dispatcher.Map(key, new ExecutionContext { Executor = executor, SignatureValidationOptions = null }));
                return;
            }

            dispatcher.Map(key, new ExecutionContext { Executor = executor, SignatureValidationOptions = null });
            var request = TestHelpers.CreateHttpRequestMessage(key.hub, key.category, key.@event, Guid.NewGuid().ToString());
            await dispatcher.ExecuteAsync(request);
            executorMoc.Verify(e => e.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()), Times.Once);

            // We can handle different word cases
            request = TestHelpers.CreateHttpRequestMessage(key.hub.ToUpper(), key.category.ToUpper(), key.@event.ToUpper(), Guid.NewGuid().ToString());
            await dispatcher.ExecuteAsync(request);
            executorMoc.Verify(e => e.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
        }

        [Theory]
        [MemberData(nameof(AttributeData))]
        public async Task ResolverInfluenceTests(string category, string @event, bool throwException)
        {
            if (throwException)
            {
                return;
            }
            var resolver = new TestRequestResolver();
            var dispatcher = new SignalRTriggerDispatcher(resolver);
            var key = (hub: Guid.NewGuid().ToString(), category, @event);
            var tcs = new TaskCompletionSource<ITriggeredFunctionExecutor>(TaskCreationOptions.RunContinuationsAsynchronously);
            var executorMoc = new Mock<ITriggeredFunctionExecutor>();
            executorMoc.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new FunctionResult(true)));
            var executor = executorMoc.Object;
            dispatcher.Map(key, new ExecutionContext { Executor = executor, SignatureValidationOptions = null });

            // Test content type
            resolver.ValidateContentTypeResult = false;
            var request = TestHelpers.CreateHttpRequestMessage(key.hub, key.category, key.@event, Guid.NewGuid().ToString());
            var res = await dispatcher.ExecuteAsync(request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, res.StatusCode);
            resolver.ValidateContentTypeResult = true;

            // Test signature
            resolver.ValidateSignatureResult = false;
            request = TestHelpers.CreateHttpRequestMessage(key.hub, key.category, key.@event, Guid.NewGuid().ToString());
            res = await dispatcher.ExecuteAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, res.StatusCode);
            resolver.ValidateSignatureResult = true;

            // Test GetInvocationContext
            resolver.GetInvocationContextResult = false;
            request = TestHelpers.CreateHttpRequestMessage(key.hub, key.category, key.@event, Guid.NewGuid().ToString());
            res = await dispatcher.ExecuteAsync(request);
            Assert.Equal(HttpStatusCode.InternalServerError, res.StatusCode);
            resolver.GetInvocationContextResult = true;
        }

        private class TestRequestResolver : IRequestResolver
        {
            public bool ValidateContentTypeResult { get; set; } = true;

            public bool ValidateSignatureResult { get; set; } = true;

            public bool GetInvocationContextResult { get; set; } = true;

            public bool ValidateContentType(HttpRequestMessage request) => ValidateContentTypeResult;

            public bool ValidateSignature(HttpRequestMessage request, IOptionsMonitor<SignatureValidationOptions> signatureValidationOptions) => ValidateSignatureResult;

            public bool TryGetInvocationContext(HttpRequestMessage request, out InvocationContext context)
            {
                context = new InvocationContext();
                return GetInvocationContextResult;
            }

            public Task<(T Message, IHubProtocol Protocol)> GetMessageAsync<T>(HttpRequestMessage request) where T : ServerlessMessage, new()
            {
                return Task.FromResult<(T, IHubProtocol)>((new T(), new JsonHubProtocol()));
            }
        }
    }
}