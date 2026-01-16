// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.WebPubSubForSocketIOTriggerBinding;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class SocketIOTriggerBindingTests
    {
        private readonly WebPubSubForSocketIOTriggerBindingProvider _provider;
        private readonly IConfiguration _configuration;

        public SocketIOTriggerBindingTests()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddInMemoryCollection()
                .Build();
            _configuration["testhub"] = "testchat";
            var resolver = new DefaultNameResolver(_configuration);
            var mockDispater = new Mock<IWebPubSubForSocketIOTriggerDispatcher>(MockBehavior.Strict);
            var config = new SocketIOFunctionsOptions();
            _provider = new WebPubSubForSocketIOTriggerBindingProvider(mockDispater.Object, resolver, config, null);
        }

        public static void ConnectObj([SocketIOTrigger("testchat", "connect")] JObject req) { }

        public static void Connect([SocketIOTrigger("testchat", "connect")] SocketIOConnectRequest req,
            string @namespace,
            string socketId,
            IDictionary<string, string[]> claims,
            IDictionary<string, string[]> query,
            IDictionary<string, string[]> headers,
            WebPubSubClientCertificate[] clinetCertificates)
        { }

        public static void ConnectedObj([SocketIOTrigger("testchat", "connected")] JObject req) { }

        public static void Connected([SocketIOTrigger("testchat", "connected")] SocketIODisconnectedRequest req,
            string @namespace,
            string socketId,
            string reason)
        { }

        public static void DisconnectObj([SocketIOTrigger("testchat", "disconnected")] JObject req) { }

        public static void Disconnect([SocketIOTrigger("testchat", "disconnected")] SocketIODisconnectedRequest req,
            string @namespace,
            string socketId,
            string reason)
        { }

        public static void MessageObj([SocketIOTrigger("testchat", "target")] JObject req) { }

        public static void Message([SocketIOTrigger("testchat", "target")] SocketIOMessageRequest req,
            [SocketIOParameter] string paramKey1,
            [SocketIOParameter] int paramKey2)
        { }

        [TestCase]
        public async Task TriggerConnectEventTest()
        {
            var parameter = GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(Connect));
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);

            var triggerEvent = new SocketIOTriggerEvent
            {
                ConnectionContext = new SocketIOSocketContext(WebPubSubEventType.System, "connect", "testchat", "conn1", "uid", "ns", "sid", "signature", "origin", null),
                Request = new SocketIOConnectRequest(
                    "ns",
                    "sid",
                    new Dictionary<string, string[]> { ["k"] = new[] { "claim" } },
                    new Dictionary<string, string[]> { ["k"] = new[] { "query" } },
                    new[] { new WebPubSubClientCertificate("thumbprint") },
                    new Dictionary<string, string[]> { ["k"] = new[] { "headers" } })
            };

            var triggerData = await binding.BindAsync(triggerEvent, null);

            var provider = triggerData.ValueProvider;
            var result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(triggerEvent.Request));

            var bindingData = triggerData.BindingData;
            Assert.That(bindingData[NamespaceBindingName], Is.EqualTo("ns"));
            Assert.That(bindingData[SocketIdBindingName], Is.EqualTo("sid"));
            Assert.That(bindingData[ClaimsBindingName], Is.EqualTo(((SocketIOConnectRequest)triggerEvent.Request).Claims));
            Assert.That(bindingData[QueryBindingName], Is.EqualTo(((SocketIOConnectRequest)triggerEvent.Request).Query));
            Assert.That(bindingData[HeadersBindingName], Is.EqualTo(((SocketIOConnectRequest)triggerEvent.Request).Headers));
            Assert.That(bindingData[ClientCertificatesBindingName], Is.EqualTo(((SocketIOConnectRequest)triggerEvent.Request).ClientCertificates));

            // Test JOBject
            provider = new SocketIOTriggerValueProvider(GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(ConnectObj)), triggerEvent);
            result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(JObject.FromObject(triggerEvent.Request)));
        }

        [TestCase]
        public async Task TriggerConnectedEventTest()
        {
            var parameter = GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(Connected));
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);

            var triggerEvent = new SocketIOTriggerEvent
            {
                ConnectionContext = new SocketIOSocketContext(WebPubSubEventType.System, "connected", "testchat", "conn1", "uid", "ns", "sid", "signature", "origin", null),
                Request = new SocketIOConnectedRequest("ns", "sid")
            };

            var triggerData = await binding.BindAsync(triggerEvent, null);

            var provider = triggerData.ValueProvider;
            var result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(triggerEvent.Request));

            var bindingData = triggerData.BindingData;
            Assert.That(bindingData[NamespaceBindingName], Is.EqualTo("ns"));
            Assert.That(bindingData[SocketIdBindingName], Is.EqualTo("sid"));

            provider = new SocketIOTriggerValueProvider(GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(ConnectedObj)), triggerEvent);
            result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(JObject.FromObject(triggerEvent.Request)));
        }

        [TestCase]
        public async Task TriggerDisconnectEventTest()
        {
            var parameter = GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(Disconnect));
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);

            var triggerEvent = new SocketIOTriggerEvent
            {
                ConnectionContext = new SocketIOSocketContext(WebPubSubEventType.System, "disconnect", "testchat", "conn1", "uid", "ns", "sid", "signature", "origin", null),
                Request = new SocketIODisconnectedRequest("ns", "sid", "reason")
            };

            var triggerData = await binding.BindAsync(triggerEvent, null);

            var provider = triggerData.ValueProvider;
            var result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(triggerEvent.Request));

            var bindingData = triggerData.BindingData;
            Assert.That(bindingData[NamespaceBindingName], Is.EqualTo("ns"));
            Assert.That(bindingData[SocketIdBindingName], Is.EqualTo("sid"));
            Assert.That(bindingData[ReasonBindingName], Is.EqualTo("reason"));

            provider = new SocketIOTriggerValueProvider(GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(DisconnectObj)), triggerEvent);
            result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(JObject.FromObject(triggerEvent.Request)));
        }

        [TestCase]
        public async Task TriggerMessageEventTest()
        {
            var parameter = GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(Message));
            var context = new TriggerBindingProviderContext(parameter, CancellationToken.None);
            var binding = await _provider.TryCreateAsync(context);

            var triggerEvent = new SocketIOTriggerEvent
            {
                ConnectionContext = new SocketIOSocketContext(WebPubSubEventType.User, "target", "testchat", "conn1", "uid", "ns", "sid", "signature", "origin", null),
                Request = new SocketIOMessageRequest("ns", "sid", "payload", "ev", new object[] { "param1", 2 })
            };

            var triggerData = await binding.BindAsync(triggerEvent, null);

            var provider = triggerData.ValueProvider;
            var result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(triggerEvent.Request));

            var bindingData = triggerData.BindingData;
            Assert.That(bindingData[NamespaceBindingName], Is.EqualTo("ns"));
            Assert.That(bindingData[SocketIdBindingName], Is.EqualTo("sid"));
            Assert.That(bindingData["paramKey1"], Is.EqualTo("param1"));
            Assert.That(bindingData["paramKey2"], Is.EqualTo(2));

            provider = new SocketIOTriggerValueProvider(GetParameterOrFirst(typeof(SocketIOTriggerBindingTests), nameof(MessageObj)), triggerEvent);
            result = await provider.GetValueAsync();
            Assert.That(result, Is.EqualTo(JObject.FromObject(triggerEvent.Request)));
        }

        [TestCaseSource(nameof(InvalidTriggerBindingsParameters))]
        public async Task TestGetValueByName_Invalid(ParameterInfo parameter)
        {
            var triggerEvent = NewTestEvent();
            var provider = new SocketIOTriggerValueProvider(parameter, triggerEvent);
            var result = await provider.GetValueAsync();

            Assert.That(result, Is.Null);
        }

        public static IEnumerable<object[]> InvalidTriggerBindingsParameters
        {
            get { return InvalidTriggerBindings.GetParameters(); }
        }

        private static class InvalidTriggerBindings
        {
            public static void Func1([SocketIOTrigger("testchat", "connect")] string[] connectionContext)
            { }

            public static void Func2([SocketIOTrigger("testchat", "message")] int connectionContext)
            { }

            public static IEnumerable<ParameterInfo[]> GetParameters()
            {
                var type = typeof(InvalidTriggerBindings);

                return new[]
                {
                    new[] { GetParameterOrFirst(type, "Func1", "connectionContext") },
                    new[] { GetParameterOrFirst(type, "Func2", "connectionContext") }
                };
            }
        }

        private static ParameterInfo GetParameterOrFirst(Type type, string methodName, string parameterName = null)
        {
            var methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (!string.IsNullOrEmpty(parameterName))
            {
                return methodInfo.GetParameters().First(x => x.Name == parameterName);
            }

            return methodInfo.GetParameters().First();
        }

        private static SocketIOTriggerEvent NewTestEvent()
        {
            var sioContext = new SocketIOSocketContext(WebPubSubEventType.User, "message", "testhub", "conn1", "uid", "ns", "sid", "signature", "origin", null);
            return new SocketIOTriggerEvent
            {
                ConnectionContext = sioContext,
                Request = new SocketIOMessageRequest(
                    "namespace",
                    "socketId",
                    "payload",
                    "ev",
                    new[] { "arg1", "arg2" }),
            };
        }
    }
}
