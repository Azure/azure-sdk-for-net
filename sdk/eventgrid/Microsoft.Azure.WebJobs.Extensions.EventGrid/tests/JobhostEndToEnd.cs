// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.Common;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    public class JobhostEndToEnd
    {
        private static string _functionOut = null;

        [Theory]
        [TestCase("EventGridParams.TestEventGridToString_Single")]
        [TestCase("EventGridParams.TestEventGridToBinaryData_Single")]
        [TestCase("EventGridParams.TestEventGridToJObject_Single")]
        [TestCase("EventGridParams.TestEventGridToNuget_Single")]
        [TestCase("EventGridParams.TestEventGridToValidCustom_Single")]
        public async Task ConsumeEventGridEventTest_Single(string functionName)
        {
            JObject eve = JObject.Parse(FakeData.EventGridEvent);
            var args = new Dictionary<string, object>{
                { "value", eve }
            };

            var expectOut = (string)eve["subject"];

            var host = TestHelpers.NewHost<EventGridParams>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);

            var categories = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.Category);
            CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.Extensions.EventGrid.Config.EventGridExtensionConfigProvider");
            _functionOut = null;
        }

        [Theory]
        [TestCase("CloudEventParams.TestEventGridToString_Single")]
        [TestCase("CloudEventParams.TestEventGridToBinaryData_Single")]
        [TestCase("CloudEventParams.TestEventGridToJObject_Single")]
        [TestCase("CloudEventParams.TestEventGridToNuget_Single")]
        [TestCase("CloudEventParams.TestEventGridToValidCustom_Single")]
        public async Task ConsumeCloudEventTest_Single(string functionName)
        {
            JObject eve = JObject.Parse(FakeData.CloudEvent);
            var args = new Dictionary<string, object>{
                { "value", eve }
            };

            var expectOut = (string)eve["subject"];

            var host = TestHelpers.NewHost<CloudEventParams>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);
            _functionOut = null;
        }

        [Theory]
        [TestCase("EventGridParams.TestEventGridToCollection_Batch")]
        [TestCase("EventGridParams.TestEventGridToStringCollection_Batch")]
        [TestCase("EventGridParams.TestEventGridToBinaryDataCollection_Batch")]
        [TestCase("EventGridParams.TestEventGridToJObjectCollection_Batch")]
        [TestCase("EventGridParams.TestEventGridToCustomCollection_Batch")]
        public async Task ConsumeEventGridEventTests_Batch(string functionName)
        {
            JArray events = JArray.Parse(FakeData.MultipleEventGridEvents);
            var args = new Dictionary<string, object>
            {
                { "values", events as JArray }
            };

            var expectOut = string.Join(", ", events.Select(ev => ev["subject"]));

            var host = TestHelpers.NewHost<EventGridParams>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);
            _functionOut = null;
        }

        [Theory]
        [TestCase("CloudEventParams.TestEventGridToCollection_Batch")]
        [TestCase("CloudEventParams.TestEventGridToStringCollection_Batch")]
        [TestCase("CloudEventParams.TestEventGridToBinaryDataCollection_Batch")]
        [TestCase("CloudEventParams.TestEventGridToJObjectCollection_Batch")]
        [TestCase("CloudEventParams.TestEventGridToCustomCollection_Batch")]
        public async Task ConsumeCloudEventTests_Batch(string functionName)
        {
            JArray events = JArray.Parse(FakeData.MultipleCloudEvents);
            var args = new Dictionary<string, object>
            {
                { "values", events as JArray }
            };

            var expectOut = string.Join(", ", events.Select(ev => ev["subject"]));

            var host = TestHelpers.NewHost<CloudEventParams>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);
            _functionOut = null;
        }

        [Test]
        public void InvalidParamsTests()
        {
            JObject eve = JObject.Parse(FakeData.EventGridEvent);
            var args = new Dictionary<string, object>{
                { "value", eve }
            };

            var host = TestHelpers.NewHost<EventGridParams>();

            // when invoked
            var invocationException = Assert.ThrowsAsync<FunctionInvocationException>(() => host.GetJobHost().CallAsync("EventGridParams.TestEventGridToCustom", args));
            Assert.AreEqual(@"Exception binding parameter 'value'", invocationException.InnerException.Message);

            // when indexed
            host = TestHelpers.NewHost<InvalidParam>();
            var indexException = Assert.ThrowsAsync<FunctionIndexingException>(() => host.StartAsync());
            Assert.AreEqual($"Can't bind EventGridTrigger to type '{typeof(int)}'.", indexException.InnerException.Message);
        }

        [Theory]
        [TestCase("CloudEventParamsBackCompat.TestCloudEventToString")]
        [TestCase("CloudEventParamsBackCompat.TestCloudEventToJObject")]
        public async Task ConsumeCloudEventTest(string functionName)
        {
            JObject eve = JObject.Parse(FakeData.CloudEventBackCompat);
            var args = new Dictionary<string, object>{
                { "value", eve }
            };

            var expectOut = (string)eve["eventType"];

            var host = TestHelpers.NewHost<CloudEventParamsBackCompat>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);
            _functionOut = null;
        }

        [Theory]
        [TestCase("DirectInvocation.TestString", "StringDataEvent")]
        [TestCase("DirectInvocation.TestEventGridEvent", "EventGridEvent")]
        public async Task ConsumeDirectInvocation(string functionName, string argument)
        {
            string value = (string)(typeof(FakeData)).GetField(argument).GetValue(null);

            JObject eve = JObject.Parse(value);
            var args = new Dictionary<string, object>{
                { "value", value }
            };

            var expectOut = (string)eve["subject"];
            var host = TestHelpers.NewHost<DirectInvocation>();

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(_functionOut, expectOut);
            _functionOut = null;
        }

        [Theory]
        [TestCase("TriggerParamResolve.TestJObject", "EventGridEvent", @"https://shunsouthcentralus.blob.core.windows.net/debugging/shunBlob.txt")]
        [TestCase("TriggerParamResolve.TestString", "StringDataEvent", "goodBye world")]
        [TestCase("TriggerParamResolve.TestArray", "ArrayDataEvent", "ConfusedDev")]
        [TestCase("TriggerParamResolve.TestPrimitive", "PrimitiveDataEvent", "123")]
        [TestCase("TriggerParamResolve.TestDataFieldMissing", "MissingDataEvent", "")]
        public async Task ValidTriggerDataResolveTests(string functionName, string argument, string expectedOutput)
        {
            var host = TestHelpers.NewHost<TriggerParamResolve>();

            var args = new Dictionary<string, object>{
                { "value", JToken.Parse((string)typeof(FakeData).GetField(argument).GetValue(null)) }
            };

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(expectedOutput, _functionOut);
            _functionOut = null;
        }

        [Theory]
        [TestCase("BindingDataTests.TestBindingData_Single", "StringDataEvent", "goodBye world")]
        [TestCase("BindingDataTests.TestBindingData_Batch", "StringDataEvents", "Perfectly balanced, as all things should be")]
        public async Task InputBindingDataTests(string functionName, string argument, string expectedOutput)
        {
            var host = TestHelpers.NewHost<BindingDataTests>();

            var args = new Dictionary<string, object>{
                { "value", JToken.Parse((string)typeof(FakeData).GetField(argument).GetValue(null)) }
            };

            await host.GetJobHost().CallAsync(functionName, args);
            Assert.AreEqual(expectedOutput, _functionOut);
            _functionOut = null;
        }

        [Test]
        public void OutputBindingInvalidCredentialTests()
        {
            // validation is done at indexing time
            var host = TestHelpers.NewHost<OutputBindingParams>();
            // appsetting is missing
            var indexException = Assert.ThrowsAsync<FunctionIndexingException>(() => host.StartAsync());
            Assert.AreEqual($"Unable to resolve the value for property '{nameof(EventGridAttribute)}.{nameof(EventGridAttribute.TopicEndpointUri)}'. Make sure the setting exists and has a valid value.", indexException.InnerException.Message);

            var configuration = new Dictionary<string, string>
                {
                    { "eventGridUri" , "this could be anything...so lets try yolo" },
                    { "eventgridKey" , "thisismagic" },
                };

            host = TestHelpers.NewHost<OutputBindingParams>(configuration: configuration);
            indexException = Assert.ThrowsAsync<FunctionIndexingException>(() => host.StartAsync());
            Assert.AreEqual($"The '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be a valid absolute Uri.", indexException.InnerException.Message);

            configuration = new Dictionary<string, string>
                {
                    { "eventGridUri" , "https://pccode.westus2-1.eventgrid.azure.net/api/events" },
                    // invalid sas token
                    { "eventgridKey" , "" }
                };

            host = TestHelpers.NewHost<OutputBindingParams>(configuration: configuration);
            indexException = Assert.ThrowsAsync<FunctionIndexingException>(() => host.StartAsync());
            Assert.AreEqual($"The '{nameof(EventGridAttribute.TopicKeySetting)}' property must be the name of an application setting containing the Topic Key.", indexException.InnerException.Message);
        }

        [Theory]
        [TestCase("SingleEvent", "0")]
        [TestCase("SingleEventWithConnection", "0")]
        [TestCase("SingleEventString", "0")]
        [TestCase("SingleEventBinaryData", "0")]
        [TestCase("SingleEventJObject", "0")]
        [TestCase("SingleReturnEvent", "0")]
        // space separated string as event ids
        [TestCase("ArrayEvent", "0 1 2 3 4")]
        [TestCase("CollectorEvent", "0 1 2 3")]
        [TestCase("AsyncCollectorEvent", "0 1 2 3 4 5 6")]
        [TestCase("StringEvents", "0 1 2 3 4")]
        [TestCase("BinaryDataEvents", "0 1 2 3 4")]
        [TestCase("ByteArrayEvents", "0 1 2 3 4")]
        [TestCase("JObjectEvents", "0 1 2 3 4")]
        public async Task OutputBindingParamsTests(string functionName, string expectedCollection)
        {
            List<EventGridEvent> egOutput = new List<EventGridEvent>();

            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TestLoggerProvider());

            var configuration = new Dictionary<string, string>
                {
                    { "eventGridUri" , "https://pccode.westus2-1.eventgrid.azure.net/api/events" },
                    { "eventgridKey" , "thisismagic" },
                    { "eventGridConnection:topicEndpointUri" , "https://pccode.westus2-1.eventgrid.azure.net/api/events" },
                };

            // use moq eventgridclient for test extension
            var configSection = new ConfigurationBuilder().AddInMemoryCollection(configuration).Build();

            var mockFactory = new Mock<EventGridAsyncCollectorFactory>(configSection, new MockComponentFactory());

            mockFactory.Setup(x => x.CreateCollector(It.IsAny<EventGridAttribute>()))
                .Returns((EventGridAttribute attr) =>
                {
                    var mockClient = new Mock<EventGridPublisherClient>();
                    mockClient.Setup(x => x.SendEventsAsync(It.IsAny<IEnumerable<EventGridEvent>>(), It.IsAny<CancellationToken>()))
                        .Returns((IEnumerable<EventGridEvent> events, CancellationToken cancel) =>
                        {
                            foreach (EventGridEvent eve in events)
                            {
                                egOutput.Add(eve);
                            }

                            return Task.FromResult<Response>(new MockResponse(200));
                        });
                    return new EventGridAsyncCollector(mockClient.Object);
                });
            var customExtension = new EventGridExtensionConfigProvider(mockFactory.Object, new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), loggerFactory);

            var host = TestHelpers.NewHost<OutputBindingParams>(customExtension, configuration: configuration);

            await host.GetJobHost().CallAsync($"OutputBindingParams.{functionName}");

            var expectedEvents = new HashSet<string>(expectedCollection.Split(' '));
            foreach (EventGridEvent eve in egOutput)
            {
                Assert.True(expectedEvents.Remove(eve.Data.ToObjectFromJson<string>()));
            }
            Assert.True(expectedEvents.Count == 0);
        }

        private class MockComponentFactory : AzureComponentFactory
        {
            public override TokenCredential CreateTokenCredential(IConfiguration configuration)
            {
                return new MockCredential();
            }

            public override object CreateClientOptions(Type optionsType, object serviceVersion, IConfiguration configuration)
            {
                throw new NotImplementedException();
            }

            public override object CreateClient(Type clientType, IConfiguration configuration, TokenCredential credential, object clientOptions)
            {
                throw new NotImplementedException();
            }
        }

        public class EventGridParams
        {
            // different argument types

            public void TestEventGridToString_Single([EventGridTrigger] string value)
            {
                _functionOut = (string)JObject.Parse(value)["subject"];
            }

            public void TestEventGridToBinaryData_Single([EventGridTrigger] BinaryData value)
            {
                _functionOut = (string)JObject.Parse(value.ToString())["subject"];
            }

            public void TestEventGridToStringCollection_Batch([EventGridTrigger] string[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => (string)JObject.Parse(v)["subject"]));
            }

            public void TestEventGridToBinaryDataCollection_Batch([EventGridTrigger] BinaryData[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => (string)JObject.Parse(v.ToString())["subject"]));
            }

            public void TestEventGridToJObject_Single([EventGridTrigger] JObject value)
            {
                _functionOut = (string)value["subject"];
            }

            public void TestEventGridToJObjectCollection_Batch([EventGridTrigger] JObject[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => v["subject"]));
            }

            public void TestEventGridToNuget_Single([EventGridTrigger] EventGridEvent value)
            {
                _functionOut = value.Subject;
                Assert.IsNotNull(value.Data);
            }

            public void TestEventGridToCollection_Batch([EventGridTrigger] EventGridEvent[] values)
            {
                _functionOut = string.Join(", ", values.Select(ev => ev.Subject));
            }

            public void TestEventGridToCustom([EventGridTrigger] InvalidPoco value)
            {
                _functionOut = value.Name;
            }

            public void TestEventGridToValidCustom_Single([EventGridTrigger] ValidPoco value)
            {
                _functionOut = value.Subject;
            }

            public void TestEventGridToCustomCollection_Batch([EventGridTrigger] ValidPoco[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => v.Subject));
            }
        }

        [Theory]
        [TestCase("SingleEvent", "0")]
        [TestCase("SingleEventString", "0")]
        [TestCase("SingleEventBinaryData", "0")]
        [TestCase("SingleEventJObject", "0")]
        [TestCase("SingleReturnEvent", "0")]
        // space separated string as event ids
        [TestCase("ArrayEvent", "0 1 2 3 4")]
        [TestCase("CollectorEvent", "0 1 2 3")]
        [TestCase("AsyncCollectorEvent", "0 1 2 3 4 5 6")]
        [TestCase("StringEvents", "0 1 2 3 4")]
        [TestCase("BinaryDataEvents", "0 1 2 3 4")]
        [TestCase("ByteArrayEvents", "0 1 2 3 4")]
        [TestCase("JObjectEvents", "0 1 2 3 4")]
        public async Task OutputCloudEventBindingParamsTests(string functionName, string expectedCollection)
        {
            List<CloudEvent> cloudEvents = new List<CloudEvent>();

            var mockFactory = new Mock<EventGridAsyncCollectorFactory>();
            mockFactory.Setup(x => x.CreateCollector(It.IsAny<EventGridAttribute>()))
                .Returns((EventGridAttribute attr) =>
                {
                    var mockClient = new Mock<EventGridPublisherClient>();
                    mockClient.Setup(x => x.SendEventsAsync(It.IsAny<IEnumerable<CloudEvent>>(), It.IsAny<CancellationToken>()))
                        .Returns((IEnumerable<CloudEvent> events, CancellationToken cancel) =>
                        {
                            foreach (CloudEvent eve in events)
                            {
                                cloudEvents.Add(eve);
                            }

                            return Task.FromResult<Response>(new MockResponse(200));
                        });
                    return new EventGridAsyncCollector(mockClient.Object);
                });

            ILoggerFactory loggerFactory = new LoggerFactory();
            var provider = new TestLoggerProvider();
            loggerFactory.AddProvider(provider);
            // use moq eventgridclient for test extension
            var customExtension = new EventGridExtensionConfigProvider(mockFactory.Object, new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), loggerFactory);

            var configuration = new Dictionary<string, string>
                {
                    { "eventGridUri" , "https://pccode.westus2-1.eventgrid.azure.net/api/events" },
                    { "eventgridKey" , "thisismagic" }
                };

            var host = TestHelpers.NewHost<OutputCloudEventBindingParams>(customExtension, configuration: configuration);

            await host.GetJobHost().CallAsync($"OutputCloudEventBindingParams.{functionName}");

            var categories = provider.GetAllLogMessages().Select(p => p.Category);
            CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.Extensions.EventGrid.Config.EventGridExtensionConfigProvider");

            var expectedEvents = new HashSet<string>(expectedCollection.Split(' '));
            foreach (CloudEvent eve in cloudEvents)
            {
                Assert.True(expectedEvents.Remove(eve.Data.ToObjectFromJson<string>()));
            }
            Assert.AreEqual(0, expectedEvents.Count);
        }

        [Test]
        public void InvalidOutputEvent()
        {
            var mockFactory = new Mock<EventGridAsyncCollectorFactory>();
            mockFactory.Setup(x => x.CreateCollector(It.IsAny<EventGridAttribute>()))
                .Returns((EventGridAttribute attr) =>
                {
                    var mockClient = new Mock<EventGridPublisherClient>();
                    return new EventGridAsyncCollector(mockClient.Object);
                });

            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TestLoggerProvider());
            // use moq eventgridclient for test extension
            var customExtension = new EventGridExtensionConfigProvider(mockFactory.Object, new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), loggerFactory);

            var configuration = new Dictionary<string, string>
                {
                    { "eventGridUri" , "https://pccode.westus2-1.eventgrid.azure.net/api/events" },
                    { "eventgridKey" , "thisismagic" }
                };

            var host = TestHelpers.NewHost<OutputCloudEventBindingParams>(customExtension, configuration: configuration);
            Assert.That(
                async () => await host.GetJobHost().CallAsync($"OutputCloudEventBindingParams.InvalidEvent"),
                Throws.InstanceOf<FunctionInvocationException>().And.InnerException.InnerException.InstanceOf<InvalidOperationException>()
                    .And.InnerException.InnerException.Message.Contains(nameof(TestEvent)));
        }

        public class CloudEventParams
        {
            // different argument types

            public void TestEventGridToString_Single([EventGridTrigger] string value)
            {
                _functionOut = (string)JObject.Parse(value)["subject"];
            }

            public void TestEventGridToBinaryData_Single([EventGridTrigger] BinaryData value)
            {
                _functionOut = (string)JObject.Parse(value.ToString())["subject"];
            }

            public void TestEventGridToStringCollection_Batch([EventGridTrigger] string[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => (string)JObject.Parse(v)["subject"]));
            }

            public void TestEventGridToBinaryDataCollection_Batch([EventGridTrigger] BinaryData[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => (string)JObject.Parse(v.ToString())["subject"]));
            }

            public void TestEventGridToJObject_Single([EventGridTrigger] JObject value)
            {
                _functionOut = (string)value["subject"];
            }

            public void TestEventGridToJObjectCollection_Batch([EventGridTrigger] JObject[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => v["subject"]));
            }

            public void TestEventGridToNuget_Single([EventGridTrigger] CloudEvent value)
            {
                _functionOut = value.Subject;
                Assert.IsNotNull(value.Data);
            }

            public void TestEventGridToCollection_Batch([EventGridTrigger] CloudEvent[] values)
            {
                _functionOut = string.Join(", ", values.Select(ev => ev.Subject));
            }

            public void TestEventGridToCustom([EventGridTrigger] InvalidPoco value)
            {
                _functionOut = value.Name;
            }

            public void TestEventGridToValidCustom_Single([EventGridTrigger] ValidPoco value)
            {
                _functionOut = value.Subject;
            }

            public void TestEventGridToCustomCollection_Batch([EventGridTrigger] ValidPoco[] values)
            {
                _functionOut = string.Join(", ", values.Select(v => v.Subject));
            }
        }

        public class InvalidParam
        {
            public void TestEventGridToValueType([EventGridTrigger] int value)
            {
                _functionOut = "failure";
            }
        }

        public class InvalidPoco
        {
            public string Name { get; set; }
            // in the json payload, Subject is a String, this should cause JObject conversion to fail
            public int Subject { get; set; }
        }

        public class ValidPoco
        {
            public string Name { get; set; }
            public string Subject { get; set; }
        }

        public class TriggerParamResolve
        {
            public void TestJObject(
                [EventGridTrigger] JObject value,
                [BindingData("{data.fileUrl}")] string autoResolve)
            {
                _functionOut = autoResolve;
            }

            public void TestString(
                [EventGridTrigger] JObject value,
                [BindingData("{data}")] string autoResolve)
            {
                _functionOut = autoResolve;
            }

            public void TestDataFieldMissing(
                [EventGridTrigger] JObject value,
                [BindingData("{data}")] string autoResolve)
            {
                _functionOut = autoResolve;
            }

            // auto resolve only works for string
            public void TestArray(
                [EventGridTrigger] JObject value)
            {
                JArray data = (JArray)value["data"];
                _functionOut = (string)value["data"][0];
            }

            public void TestPrimitive(
                [EventGridTrigger] JObject value)
            {
                int data = (int)value["data"];
                _functionOut = data.ToString();
            }
        }

        public class BindingDataTests
        {
            public void TestBindingData_Single([EventGridTrigger] JObject value, object data)
            {
                _functionOut = data.ToString();
            }

            public void TestBindingData_Batch([EventGridTrigger] JObject[] value, object[] data)
            {
                _functionOut = string.Join(", ", data.Select(d => d.ToString()));
            }
        }

        public class CloudEventParamsBackCompat
        {
            public void TestCloudEventToString([EventGridTrigger] string value)
            {
                _functionOut = (string)JObject.Parse(value)["eventType"];
            }

            public void TestCloudEventToJObject([EventGridTrigger] JObject value)
            {
                _functionOut = (string)value["eventType"];
            }
        }

        public class OutputBindingParams
        {
            public void SingleEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out EventGridEvent single)
            {
                single = new EventGridEvent("", "", "", data: "0");
            }

            public void SingleEventWithConnection([EventGrid(Connection = "eventGridConnection")] out EventGridEvent single)
            {
                single = new EventGridEvent("", "", "", data: "0");
            }

            public void SingleEventString([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out string single)
            {
                single = @"
                {
                    ""id"" : ""id"",
                    ""data"" : ""0"",
                    ""eventType"" : ""custom"",
                    ""subject"" : ""custom"",
                    ""dataVersion"" : ""1""
                }";
            }

            public void SingleEventBinaryData([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out BinaryData single)
            {
                single = new BinaryData(@"
                {
                    ""id"" : ""id"",
                    ""data"" : ""0"",
                    ""eventType"" : ""custom"",
                    ""subject"" : ""custom"",
                    ""dataVersion"" : ""1""
                }");
            }

            public void SingleEventJObject([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out JObject single)
            {
                single = new JObject(
                    new JProperty("id", "id"),
                    new JProperty("data", "0"),
                    new JProperty("eventType", "custom"),
                    new JProperty("subject", "custom"),
                    new JProperty("dataVersion", "1")
                );
            }

            public void SingleCloudEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out CloudEvent single)
            {
                single = new CloudEvent("source", "type", jsonSerializableData: "0");
            }

            [return: EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")]
            public EventGridEvent SingleReturnEvent()
            {
                return new EventGridEvent("", "", "", data: "0");
            }

            [return: EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")]
            public EventGridEvent SingleReturnCloudEvent()
            {
                return new EventGridEvent("", "", "", data: "0");
            }

            public void ArrayEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out EventGridEvent[] array)
            {
                array = new EventGridEvent[5];
                for (int i = 0; i < 5; i++)
                {
                    array[i] = new EventGridEvent("", "", "", data: i.ToString());
                }
            }

            public void CollectorEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] ICollector<EventGridEvent> collector)
            {
                for (int i = 0; i < 4; i++)
                {
                    collector.Add(new EventGridEvent("", "", "", data: i.ToString()));
                }
            }

            public async Task AsyncCollectorEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] IAsyncCollector<EventGridEvent> asyncCollector)
            {
                for (int i = 0; i < 7; i++)
                {
                    await asyncCollector.AddAsync(new EventGridEvent("", "", "", data: i.ToString()));

                    if (i % 3 == 0)
                    {
                        // flush mulitple times, test whether the internal buffer is cleared
                        await asyncCollector.FlushAsync();
                    }
                }
            }

            public void StringEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out string[] strings)
            {
                strings = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    strings[i] = $@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""eventType"" : ""custom"",
                        ""subject"" : ""custom"",
                        ""dataVersion"" : ""1""
                    }}";
                }
            }

            public void BinaryDataEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out BinaryData[] data)
            {
                data = new BinaryData[5];
                for (int i = 0; i < 5; i++)
                {
                    data[i] = new BinaryData($@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""eventType"" : ""custom"",
                        ""subject"" : ""custom"",
                        ""dataVersion"" : ""1""
                    }}");
                }
            }

            public void ByteArrayEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out byte[][] data)
            {
                data = new byte[5][];
                for (int i = 0; i < 5; i++)
                {
                    data[i] = new BinaryData($@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""eventType"" : ""custom"",
                        ""subject"" : ""custom"",
                        ""dataVersion"" : ""1""
                    }}").ToArray();
                }
            }

            public void JObjectEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out JObject[] jobjects)
            {
                jobjects = new JObject[5];
                for (int i = 0; i < 5; i++)
                {
                    jobjects[i] = new JObject(
                        new JProperty("id", i.ToString()),
                        new JProperty("data", i.ToString()),
                        new JProperty("eventType", "custom"),
                        new JProperty("subject", "custom"),
                        new JProperty("dataVersion", "1")
                    );
                }
            }
        }

        public class OutputCloudEventBindingParams
        {
            public void SingleEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out CloudEvent single)
            {
                single = new CloudEvent("", "", "0");
            }

            public void InvalidEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out TestEvent single)
            {
                single = new();
            }

            public void SingleEventString([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out string single)
            {
                single = @"
                {
                    ""id"" : ""i"",
                    ""data"" : ""0"",
                    ""source"" : ""custom"",
                    ""type"" : ""custom"",
                    ""specversion"" : ""1.0""
                }";
            }

            public void SingleEventBinaryData([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out BinaryData single)
            {
                single = new BinaryData(@"
                {
                    ""id"" : ""i"",
                    ""data"" : ""0"",
                    ""source"" : ""custom"",
                    ""type"" : ""custom"",
                    ""specversion"" : ""1.0""
                }");
            }

            public void SingleEventJObject([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out JObject single)
            {
                single = new JObject(
                    new JProperty("id", "id"),
                    new JProperty("data", "0"),
                    new JProperty("type", "custom"),
                    new JProperty("source", "custom"),
                    new JProperty("specversion", "1.0")
                );
            }

            [return: EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")]
            public CloudEvent SingleReturnEvent()
            {
                return new CloudEvent("", "", "0");
            }

            public void ArrayEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out CloudEvent[] array)
            {
                array = new CloudEvent[5];
                for (int i = 0; i < 5; i++)
                {
                    array[i] = new CloudEvent("", "", i.ToString());
                }
            }

            public void CollectorEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] ICollector<CloudEvent> collector)
            {
                for (int i = 0; i < 4; i++)
                {
                    collector.Add(new CloudEvent("", "", i.ToString()));
                }
            }

            public async Task AsyncCollectorEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] IAsyncCollector<CloudEvent> asyncCollector)
            {
                for (int i = 0; i < 7; i++)
                {
                    await asyncCollector.AddAsync(new CloudEvent("", "", i.ToString()));
                    if (i % 3 == 0)
                    {
                        // flush mulitple times, test whether the internal buffer is cleared
                        await asyncCollector.FlushAsync();
                    }
                }
            }

            public void StringEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out string[] strings)
            {
                strings = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    strings[i] = $@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""source"" : ""custom"",
                        ""type"" : ""custom"",
                        ""specversion"" : ""1.0""
                    }}";
                }
            }

            public void BinaryDataEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out BinaryData[] data)
            {
                data = new BinaryData[5];
                for (int i = 0; i < 5; i++)
                {
                    data[i] = new BinaryData($@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""source"" : ""custom"",
                        ""type"" : ""custom"",
                        ""specversion"" : ""1.0""
                    }}");
                }
            }

            public void ByteArrayEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out byte[][] data)
            {
                data = new byte[5][];
                for (int i = 0; i < 5; i++)
                {
                    data[i] = new BinaryData($@"
                    {{
                        ""id"" : ""{i}"",
                        ""data"" : ""{i}"",
                        ""source"" : ""custom"",
                        ""type"" : ""custom"",
                        ""specversion"" : ""1.0""
                    }}").ToArray();
                }
            }

            // assume converter is applied correctly with other output binding types
            public void JObjectEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out JObject[] jobjects)
            {
                jobjects = new JObject[5];
                for (int i = 0; i < 5; i++)
                {
                    jobjects[i] = new JObject(
                        new JProperty("id", i.ToString()),
                        new JProperty("data", i.ToString()),
                        new JProperty("source", "custom"),
                        new JProperty("type", "custom"),
                        new JProperty("specversion", "1.0")
                    );
                }
            }
        }

        public class DirectInvocation
        {
            public static void TestString([EventGridTrigger] string value)
            {
                _functionOut = (string)JObject.Parse(value)["subject"];
            }

            public static void TestEventGridEvent([EventGridTrigger] EventGridEvent value)
            {
                _functionOut = value.Subject;
            }
        }
    }

    #pragma warning disable SA1402
    public class TestEvent
    #pragma warning restore SA1402
    {
    }
}
