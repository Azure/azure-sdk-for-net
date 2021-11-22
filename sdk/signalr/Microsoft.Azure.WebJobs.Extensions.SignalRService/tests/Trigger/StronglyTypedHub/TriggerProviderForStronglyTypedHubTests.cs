// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using SignalRServiceExtension.Tests.Utils;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class TriggerProviderForStronglyTypedHubTests
    {
        private const string CustomConnectionStringSetting = "ConnectionStringSetting";

        [Fact]
        public void ResolveAttributeParameterTest()
        {
            var bindingProvider = CreateBindingProvider();
            var attribute = new SignalRTriggerAttribute();
            var parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.TestFunction), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            var resolvedAttribute = bindingProvider.GetParameterResolvedAttribute(attribute, parameter);
            Assert.Equal(nameof(TestStronglyTypedHub), resolvedAttribute.HubName);
            Assert.Equal(Category.Messages, resolvedAttribute.Category);
            Assert.Equal(nameof(TestStronglyTypedHub.TestFunction), resolvedAttribute.Event);
            Assert.Equal(new string[] { "arg0", "arg1" }, resolvedAttribute.ParameterNames);

            // With SignalRIgoreAttribute
            parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.TestFunctionWithIgnore), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            resolvedAttribute = bindingProvider.GetParameterResolvedAttribute(attribute, parameter);
            Assert.Equal(new string[] { "arg0", "arg1" }, resolvedAttribute.ParameterNames);

            // With ILogger and CancellationToken
            parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.TestFunctionWithSpecificType), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            resolvedAttribute = bindingProvider.GetParameterResolvedAttribute(attribute, parameter);
            Assert.Equal(new string[] { "arg0", "arg1" }, resolvedAttribute.ParameterNames);
        }

        [Fact]
        public void ResolveConnectionAttributeParameterTest()
        {
            var bindingProvider = CreateBindingProvider();
            var attribute = new SignalRTriggerAttribute();
            var parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.OnConnected), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            var resolvedAttribute = bindingProvider.GetParameterResolvedAttribute(attribute, parameter);
            Assert.Equal(nameof(TestStronglyTypedHub), resolvedAttribute.HubName);
            Assert.Equal(Category.Connections, resolvedAttribute.Category);
            Assert.Equal(Event.Connected, resolvedAttribute.Event);
            Assert.Equal(new string[] { "arg0", "arg1" }, resolvedAttribute.ParameterNames);

            parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.OnDisconnected), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            resolvedAttribute = bindingProvider.GetParameterResolvedAttribute(attribute, parameter);
            Assert.Equal(nameof(TestStronglyTypedHub), resolvedAttribute.HubName);
            Assert.Equal(Category.Connections, resolvedAttribute.Category);
            Assert.Equal(Event.Disconnected, resolvedAttribute.Event);
            Assert.Equal(new string[] { "arg0", "arg1" }, resolvedAttribute.ParameterNames);
        }

        [Fact]
        public void ResolveAttributeParameterConflictTest()
        {
            var bindingProvider = CreateBindingProvider();
            var attribute = new SignalRTriggerAttribute(string.Empty, string.Empty, string.Empty, new string[] { "arg0" });
            var parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.TestFunction), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            Assert.ThrowsAny<Exception>(() => bindingProvider.GetParameterResolvedAttribute(attribute, parameter));
        }

        [Fact]
        public void WebhookFailedTest()
        {
            var bindingProvider = CreateBindingProvider(new Exception());
            var parameter = typeof(TestStronglyTypedHub).GetMethod(nameof(TestStronglyTypedHub.OnConnected), BindingFlags.Instance | BindingFlags.NonPublic).GetParameters()[0];
            var context = new TriggerBindingProviderContext(parameter, default);
            Assert.ThrowsAsync<NotSupportedException>(() => bindingProvider.TryCreateAsync(context));
        }

        private SignalRTriggerBindingProvider CreateBindingProvider(Exception exception = null, string connectionStringSetting = Constants.AzureSignalRConnectionStringName)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            configuration[connectionStringSetting] = "Endpoint=http://localhost;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;";
            configuration["Serverless_ExpressionBindings_HubName"] = "test_hub";
            configuration["Serverless_ExpressionBindings_HubCategory"] = "connections";
            configuration["Serverless_ExpressionBindings_HubEvent"] = "connected";
            var dispatcher = new TestTriggerDispatcher();
            return new SignalRTriggerBindingProvider(dispatcher, new DefaultNameResolver(configuration), new ServiceManagerStore(configuration, NullLoggerFactory.Instance, null), exception);
        }
    }
}
