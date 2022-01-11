// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubTriggerBinding;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubTriggerValueProviderTests
    {
        [TestCaseSource(nameof(ValidTriggerBindingsParameters))]
        public async Task TestGetValueByName_Valid(ParameterInfo parameter)
        {
            var triggerEvent = NewTestEvent();
            var provider = new WebPubSubTriggerValueProvider(parameter, triggerEvent);
            var result = await provider.GetValueAsync();

            if (parameter.Name == "connectionContext")
            {
                if (parameter.ParameterType == typeof(WebPubSubConnectionContext))
                {
                    Assert.AreEqual(result, triggerEvent.ConnectionContext);
                }
                else if (parameter.ParameterType == typeof(JObject))
                {
                    Assert.AreEqual(result, JObject.FromObject(triggerEvent.ConnectionContext));
                }
            }
            else if (parameter.Name == "data")
            {
                Assert.AreEqual(result, triggerEvent.Data);
            }
            else if (parameter.Name == "dataType")
            {
                Assert.AreEqual(result, triggerEvent.DataType);
            }
        }

        [TestCaseSource(nameof(InvalidTriggerBindingsParameters))]
        public async Task TestGetValueByName_Invalid(ParameterInfo parameter)
        {
            var triggerEvent = NewTestEvent();
            var provider = new WebPubSubTriggerValueProvider(parameter, triggerEvent);
            var result = await provider.GetValueAsync();

            Assert.IsNull(result);
        }

        public static IEnumerable<object[]> ValidTriggerBindingsParameters
        {
            get { return ValidTriggerBindings.GetParameters(); }
        }

        public static IEnumerable<object[]> InvalidTriggerBindingsParameters
        {
            get { return InvalidTriggerBindings.GetParameters(); }
        }

        private static class ValidTriggerBindings
        {
            public static void Func1([WebPubSubTrigger("testchat", WebPubSubEventType.System, "connect")] WebPubSubConnectionContext connectionContext)
            { }

            public static void Func2([WebPubSubTrigger("testchat", WebPubSubEventType.User, "message")] WebPubSubConnectionContext connectionContext, BinaryData data, WebPubSubDataType dataType)
            { }

            public static void Func3([WebPubSubTrigger("testchat", WebPubSubEventType.System, "connect")] JObject connectionContext)
            { }

            public static IEnumerable<ParameterInfo[]> GetParameters()
            {
                var type = typeof(ValidTriggerBindings);

                return new[]
                {
                    new[] { GetParameterOrFirst(type, "Func1", "connectionContext") },
                    new[] { GetParameterOrFirst(type, "Func2", "connectionContext") },
                    new[] { GetParameterOrFirst(type, "Func3", "connectionContext") },
                    new[] { GetParameterOrFirst(type, "Func2", "data") },
                    new[] { GetParameterOrFirst(type, "Func2", "dataType") }
                };
            }
        }

        private static class InvalidTriggerBindings
        {
            public static void Func1([WebPubSubTrigger("testchat", WebPubSubEventType.System, "connect")] string[] connectionContext)
            { }

            public static void Func2([WebPubSubTrigger("testchat", WebPubSubEventType.User, "message")] int connectionContext)
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

        private static ParameterInfo GetParameterOrFirst(Type type, string methodName, string parameterName)
        {
            var methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
            if (!string.IsNullOrEmpty(parameterName))
            {
                return methodInfo.GetParameters().First(x => x.Name == parameterName);
            }

            return methodInfo.GetParameters().First();
        }

        private static WebPubSubTriggerEvent NewTestEvent()
        {
            return new WebPubSubTriggerEvent
            {
                ConnectionContext = new WebPubSubConnectionContext(WebPubSubEventType.User, "message", "testhub", "user1", "000000"),
                Reason = "reason",
                Data = BinaryData.FromString("message"),
                DataType = WebPubSubDataType.Text
            };
        }
    }
}
