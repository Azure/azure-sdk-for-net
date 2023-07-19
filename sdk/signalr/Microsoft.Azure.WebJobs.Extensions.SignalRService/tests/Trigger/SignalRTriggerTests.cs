// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Options;
using Moq;
using SignalRServiceExtension.Tests.Utils;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class SignalRTriggerTests
    {
        private const string ConnectionString = "Endpoint=http://localhost;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;";
        private static readonly IOptionsMonitor<SignatureValidationOptions> SignatureValidationOptions = Mock.Of<IOptionsMonitor<SignatureValidationOptions>>(o => o.CurrentValue == new SignatureValidationOptions() { RequireValidation = false });

        [Fact]
        public async Task BindAsyncTest()
        {
            var binding = CreateBinding(nameof(TestFunction), new string[0]);
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var context = new InvocationContext();
            var triggerContext = new SignalRTriggerEvent { Context = context, TaskCompletionSource = tcs };
            var result = await binding.BindAsync(triggerContext, null);
            Assert.Equal(context, await result.ValueProvider.GetValueAsync());
        }

        // Test CreateListenerAsync() in binding will call IDispatcher.Map()
        [Fact]
        public async Task CreateListenerTest()
        {
            var executor = new Mock<ITriggeredFunctionExecutor>().Object;
            var listenerFactoryContext =
                new ListenerFactoryContext(new FunctionDescriptor(), executor, CancellationToken.None);
            var parameterInfo = GetType().GetMethod(nameof(TestFunction), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            var dispatcher = new TestTriggerDispatcher();
            var hub = Guid.NewGuid().ToString();
            var method = Guid.NewGuid().ToString();
            var category = Guid.NewGuid().ToString();
            var binding = new SignalRTriggerBinding(parameterInfo, new SignalRTriggerAttribute(hub, category, method), dispatcher, SignatureValidationOptions, Mock.Of<ServiceHubContext>());
            await binding.CreateListenerAsync(listenerFactoryContext);
            Assert.Equal(executor, dispatcher.Executors[(hub, category, method)].Executor);
        }

        [Fact]
        public async Task BindingDataTestWithLessParameterNames()
        {
            var binding = CreateBinding(nameof(TestFunctionWithTwoStringArgument), "arg0");
            var context = new InvocationContext { Arguments = new object[] { Guid.NewGuid().ToString() } };
            var triggerContext = new SignalRTriggerEvent { Context = context };
            var result = await binding.BindAsync(triggerContext, null);
            var bindingData = result.BindingData;
            Assert.Equal(context.Arguments[0], bindingData["arg0"]);
            Assert.Equal(typeof(string), binding.BindingDataContract["arg0"]);
            Assert.False(bindingData.ContainsKey("arg1"));
        }

        [Fact]
        public async Task BindingDataTestWithExactParameterNames()
        {
            var binding = CreateBinding(nameof(TestFunctionWithTwoStringArgument), "arg0", "arg1");
            var context = new InvocationContext { Arguments = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } };
            var triggerContext = new SignalRTriggerEvent { Context = context };
            var result = await binding.BindAsync(triggerContext, null);
            var bindingData = result.BindingData;
            Assert.Equal(context.Arguments[0], bindingData["arg0"]);
            Assert.Equal(typeof(string), binding.BindingDataContract["arg0"]);
            Assert.Equal(context.Arguments[1], bindingData["arg1"]);
            Assert.Equal(typeof(string), binding.BindingDataContract["arg1"]);
        }

        [Fact]
        public async Task BindingDataTestWithMoreParameterNames()
        {
            var binding = CreateBinding(nameof(TestFunctionWithTwoStringArgument), "arg0", "arg1", "arg2");
            var context = new InvocationContext { Arguments = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } };
            var triggerContext = new SignalRTriggerEvent { Context = context };
            var result = await binding.BindAsync(triggerContext, null);
            var bindingData = result.BindingData;
            Assert.Equal(context.Arguments[0], bindingData["arg0"]);
            Assert.Equal(typeof(string), binding.BindingDataContract["arg0"]);
            Assert.Equal(context.Arguments[1], bindingData["arg1"]);
            Assert.Equal(typeof(string), binding.BindingDataContract["arg1"]);
            Assert.Equal(context.Arguments[2], bindingData["arg2"]);
            Assert.Equal(typeof(object), binding.BindingDataContract["arg2"]);
        }

        [Fact]
        public async Task BindingDataTestWithUnmatchedParameterNamesAndInvocation()
        {
            var binding = CreateBinding(nameof(TestFunctionWithTwoStringArgument), "arg0", "arg1", "arg2");
            // Less invocation arguments than ParameterNames
            var context = new InvocationContext { Arguments = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } };
            var triggerContext = new SignalRTriggerEvent { Context = context };
            await Assert.ThrowsAsync<SignalRTriggerParametersNotMatchException>(() => binding.BindAsync(triggerContext, null));
        }

        private SignalRTriggerBinding CreateBinding(string functionName, params string[] parameterNames)
        {
            var parameterInfo = GetType().GetMethod(functionName, BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            var dispatcher = new TestTriggerDispatcher();
            return new SignalRTriggerBinding(parameterInfo, new SignalRTriggerAttribute(string.Empty, string.Empty, string.Empty, parameterNames), dispatcher, SignatureValidationOptions, Mock.Of<ServiceHubContext>());
        }

        internal void TestFunction(InvocationContext context)
        {
        }

        internal void TestFunctionWithTwoStringArgument(InvocationContext context, string arg0, string arg1)
        {
        }
    }
}