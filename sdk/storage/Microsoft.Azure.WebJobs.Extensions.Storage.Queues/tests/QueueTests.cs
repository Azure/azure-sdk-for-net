// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueTests
    {
        private const string TriggerQueueName = "input-queuetests";
        private const string QueueName = "output-queuetests";
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            queueServiceClient.GetQueueClient(TriggerQueueName).DeleteIfExists();
            queueServiceClient.GetQueueClient(QueueName).DeleteIfExists();
        }

        // Test binding to generics.
        public class GenericProgram<T>
        {
            public void Func([Queue(QueueName)] T q)
            {
                var x = (ICollector<string>)q;
                x.Add("123");
            }
        }

        [Test]
        public async Task TestGenericSucceeds()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<GenericProgram<ICollector<string>>>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            await host.GetJobHost().CallAsync<GenericProgram<ICollector<string>>>("Func");

            // Now peek at messages.
            var queue = queueServiceClient.GetQueueClient(QueueName);
            var msgs = (await queue.ReceiveMessagesAsync(10)).Value;

            Assert.AreEqual(1, msgs.Count());
            Assert.AreEqual("123", msgs[0].MessageText);
        }

        // Program with a static bad queue name (no { } ).
        // Use this to test queue name validation.
        public class ProgramWithStaticBadName
        {
            public const string BadQueueName = "test*"; // Don't include any { }

            // Queue paths without any { } are eagerly validated at indexing time.
            public void Func([Queue(BadQueueName)] ICollector<string> q)
            {
            }
        }

        [Test]
        public void Catch_Bad_Name_At_IndexTime()
        {
            IHost host = new HostBuilder()
               .ConfigureDefaultTestHost<ProgramWithStaticBadName>(builder =>
               {
                   builder.AddAzureStorageQueues();
               })
               .Build();

            string errorMessage = GetErrorMessageForBadQueueName(ProgramWithStaticBadName.BadQueueName, "name");

            TestHelpers.AssertIndexingError(() => host.GetJobHost().CallAsync<ProgramWithStaticBadName>("Func").GetAwaiter().GetResult(), "ProgramWithStaticBadName.Func", errorMessage);
        }

        private static string GetErrorMessageForBadQueueName(string value, string parameterName)
        {
            return "A queue name can contain only letters, numbers, and dash(-) characters - \"" + value + "\"" +
#if NET5_0
                $" (Parameter '{parameterName}')"; // from ArgumentException
#else
                Environment.NewLine + "Parameter name: " + parameterName; // from ArgumentException
#endif
        }

        // Program with variable queue name containing both %% and { }.
        // Has valid parameter binding.   Use this to test queue name validation at various stages.
        public class ProgramWithVariableQueueName
        {
            public const string QueueNamePattern = "q%key%-test{x}";

            // Queue paths without any { } are eagerly validated at indexing time.
            public void Func([Queue(QueueNamePattern)] ICollector<string> q)
            {
            }
        }

        [Test]
        public async Task Catch_Bad_Name_At_Runtime()
        {
            var nameResolver = new FakeNameResolver().Add("key", "1");
            IHost host = new HostBuilder()
               .ConfigureDefaultTestHost<ProgramWithVariableQueueName>(builder =>
               {
                   builder.AddAzureStorageQueues();
                   builder.UseQueueService(queueServiceClient);
               })
               .ConfigureServices(services =>
               {
                   services.AddSingleton<INameResolver>(nameResolver);
               })
               .Build();

            await host.GetJobHost().CallAsync<ProgramWithVariableQueueName>("Func", new { x = "1" }); // succeeds with valid char

            try
            {
                await host.GetJobHost().CallAsync<ProgramWithVariableQueueName>("Func", new { x = "*" }); // produces an error pattern.
                Assert.False(true, "should have failed");
            }
            catch (FunctionInvocationException e)
            {
                Assert.AreEqual("Exception binding parameter 'q'", e.InnerException.Message);

                string errorMessage = GetErrorMessageForBadQueueName("q1-test*", "name");
                Assert.AreEqual(errorMessage, e.InnerException.InnerException.Message);
            }
        }

        // The presence of { } defers validation until runtime. Even if there are illegal chars known at index time!
        [Test]
        public async Task Catch_Bad_Name_At_Runtime_With_Illegal_Static_Chars()
        {
            var nameResolver = new FakeNameResolver().Add("key", "$"); // Illegal

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<ProgramWithVariableQueueName>(builder =>
                {
                    builder.AddAzureStorageQueues();
                    builder.UseQueueService(queueServiceClient);
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver>(nameResolver);
                })
                .Build();
            try
            {
                await host.GetJobHost().CallAsync<ProgramWithVariableQueueName>("Func", new { x = "1" }); // produces an error pattern.
                Assert.False(true, "should have failed");
            }
            catch (FunctionInvocationException e) // Not an index exception!
            {
                Assert.AreEqual("Exception binding parameter 'q'", e.InnerException.Message);

                string errorMessage = GetErrorMessageForBadQueueName("q$-test1", "name");
                Assert.AreEqual(errorMessage, e.InnerException.InnerException.Message);
            }
        }

        public class ProgramWithTriggerAndBindingData
        {
            public class Poco
            {
                public string xyz { get; set; }
            }

            // BindingData is case insensitive.
            // And queue name is normalized to lowercase.
            // Connection="" is same as Connection=null
            public const string QueueOutName = "qName-{XYZ}";
            public void Func([QueueTrigger(QueueName, Connection = "")] Poco triggers, [Queue(QueueOutName)] ICollector<string> q)
            {
                q.Add("123");
            }
        }

        [Test]
        public async Task InvokeWithBindingData()
        {
            // Verify that queue binding pattern has uppercase letters in it. These get normalized to lowercase.
            Assert.AreNotEqual(ProgramWithTriggerAndBindingData.QueueOutName, ProgramWithTriggerAndBindingData.QueueOutName.ToLower());

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<ProgramWithTriggerAndBindingData>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            var trigger = new ProgramWithTriggerAndBindingData.Poco { xyz = "abc" };
            await host.GetJobHost().CallAsync<ProgramWithTriggerAndBindingData>("Func", new
            {
                triggers = QueuesModelFactory.QueueMessage("id", "receipt", JsonConvert.SerializeObject(trigger), 0)
            });

            // Now peek at messages.
            // queue name is normalized to lowercase.
            var queue = queueServiceClient.GetQueueClient("qname-abc");
            var msgs = (await queue.ReceiveMessagesAsync(10)).Value;

            Assert.AreEqual(1, msgs.Count());
            Assert.AreEqual("123", msgs[0].MessageText);
        }

        public class ProgramWithTriggerAndCompoundBindingData
        {
            public class Poco
            {
                public SubOject prop1 { get; set; }
                public string xyz { get; set; }
            }

            public class SubOject
            {
                public string xyz { get; set; }
            }

            // BindingData is case insensitive.
            // And queue name is normalized to lowercase.
            public const string QueueOutName = "qName-{prop1.xyz}";
            public void Func(
                [QueueTrigger(QueueName)] Poco triggers,
                [Queue(QueueOutName)] ICollector<string> q,
                string xyz, // {xyz}
                SubOject prop1) // Bind to a object
            {
                // binding to subobject work
                Assert.NotNull(prop1);
                Assert.AreEqual("abc", prop1.xyz);

                Assert.AreEqual("bad", xyz);

                q.Add("123");
            }
        }

        [Test]
        public async Task InvokeWithCompoundBindingData()
        {
            // Verify that queue binding pattern has uppercase letters in it. These get normalized to lowercase.
            Assert.AreNotEqual(ProgramWithTriggerAndBindingData.QueueOutName, ProgramWithTriggerAndBindingData.QueueOutName.ToLower());

            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<ProgramWithTriggerAndCompoundBindingData>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            var trigger = new ProgramWithTriggerAndCompoundBindingData.Poco
            {
                xyz = "bad",
                prop1 = new ProgramWithTriggerAndCompoundBindingData.SubOject
                {
                    xyz = "abc"
                }
            };

            await host.GetJobHost().CallAsync<ProgramWithTriggerAndCompoundBindingData>("Func", new
            {
                triggers = QueuesModelFactory.QueueMessage("id", "receipt", JsonConvert.SerializeObject(trigger), 0)
            });

            // Now peek at messages.
            // queue name is normalized to lowercase.
            var queue = queueServiceClient.GetQueueClient("qname-abc");
            var msgs = (await queue.ReceiveMessagesAsync(10)).Value;

            Assert.AreEqual(1, msgs.Count());
            Assert.AreEqual("123", msgs[0].MessageText);
        }

        public class ProgramSimple
        {
            public void Func([Queue(QueueName)] out string x)
            {
                x = "abc";
            }
        }

        public class ProgramSimple2
        {
            public const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=test;AccountKey=test";

            // Validate that we sanitize the error to remove a connection string if someone accidentally uses one.
            public void Func2([Queue(QueueName, Connection = ConnectionString)] out string x)
            {
                x = "abc";
            }
        }

        public class ProgramBadContract
        {
            public void Func([QueueTrigger(QueueName)] string triggers, [Queue("queuName-{xyz}")] ICollector<string> q)
            {
            }
        }

        [Test]
        public void Fails_BindingContract_Mismatch()
        {
            // Verify that indexing fails if the [Queue] trigger needs binding data that's not present.
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<ProgramBadContract>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            string expectedError = "Unable to resolve binding parameter 'xyz'. Binding expressions must map to either a value provided by the trigger or a property of the value the trigger is bound to, or must be a system binding expression (e.g. sys.randguid, sys.utcnow, etc.).";
            TestHelpers.AssertIndexingError(() => host.GetJobHost().CallAsync<ProgramBadContract>("Func").GetAwaiter().GetResult(),
                "ProgramBadContract.Func",
                expectedError);
        }

        public class ProgramCantBindToObject
        {
            public void Func([Queue(QueueName)] out object o)
            {
                o = null;
            }
        }

        [Test]
        public void Fails_Cant_Bind_To_Object()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<ProgramCantBindToObject>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            TestHelpers.AssertIndexingError(() => host.GetJobHost().CallAsync<ProgramCantBindToObject>("Func").GetAwaiter().GetResult(),
                "ProgramCantBindToObject.Func",
                "Object element types are not supported.");
        }

        [TestCase(typeof(int), "System.Int32")]
        [TestCase(typeof(DateTime), "System.DateTime")]
        [TestCase(typeof(IEnumerable<string>), "System.Collections.Generic.IEnumerable`1[System.String]")] // Should use ICollector<string> instead
        public void Fails_Cant_Bind_To_Types(Type typeParam, string typeName)
        {
            var m = this.GetType().GetMethod(nameof(Fails_Cant_Bind_To_Types_Worker), BindingFlags.Instance | BindingFlags.NonPublic);
            var m2 = m.MakeGenericMethod(typeParam);
            try
            {
                m2.Invoke(this, new object[] { typeName });
            }
            catch (TargetException e)
            {
                throw e.InnerException;
            }
        }

        private void Fails_Cant_Bind_To_Types_Worker<T>(string typeName)
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<GenericProgram<T>>(b =>
                {
                    b.AddAzureStorageQueues();
                    b.UseQueueService(queueServiceClient);
                })
                .Build();

            TestHelpers.AssertIndexingError(() => host.GetJobHost().CallAsync<GenericProgram<T>>("Func").GetAwaiter().GetResult(),
                "GenericProgram`1.Func",
                "Can't bind Queue to type '" + typeName + "'.");
        }

        [Test]
        public async Task Queue_IfBoundToCloudQueue_BindsAndCreatesQueue()
        {
            // Arrange
            var triggerQueue = await CreateQueue(queueServiceClient, TriggerQueueName);
            await triggerQueue.SendMessageAsync("ignore");

            // Act
            QueueClient result = await RunTriggerAsync<QueueClient>(typeof(BindToCloudQueueProgram),
                (s) => BindToCloudQueueProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(QueueName, result.Name);
            var queue = queueServiceClient.GetQueueClient(QueueName);
            Assert.True(await queue.ExistsAsync());
        }

        [Test]
        public async Task Queue_IfBoundToICollectorCloudQueueMessage_AddEnqueuesMessage()
        {
            // Arrange
            string expectedContent = Guid.NewGuid().ToString();
            var triggerQueue = await CreateQueue(queueServiceClient, TriggerQueueName);
            await triggerQueue.SendMessageAsync(expectedContent);

            // Act
            await RunTriggerAsync<object>(typeof(BindToICollectorCloudQueueMessageProgram),
                (s) => BindToICollectorCloudQueueMessageProgram.TaskSource = s);

            // Assert
            var queue = queueServiceClient.GetQueueClient(QueueName);
            IEnumerable<QueueMessage> messages = (await queue.ReceiveMessagesAsync(10)).Value;
            Assert.NotNull(messages);
            Assert.AreEqual(1, messages.Count());
            QueueMessage message = messages.Single();
            Assert.AreEqual(expectedContent, message.MessageText);
        }

        private static async Task<QueueClient> CreateQueue(QueueServiceClient client, string queueName)
        {
            var queue = client.GetQueueClient(queueName);
            await queue.CreateIfNotExistsAsync();
            return queue;
        }

        private async Task<TResult> RunTriggerAsync<TResult>(Type programType,
            Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.RunTriggerAsync<TResult>(b =>
            {
                b.AddAzureStorageQueues();
                b.UseQueueService(queueServiceClient);
            }, programType, setTaskSource);
        }

        private class BindToCloudQueueProgram
        {
            public static TaskCompletionSource<QueueClient> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] QueueMessage ignore,
                [Queue(QueueName)] QueueClient queue)
            {
                TaskSource.TrySetResult(queue);
            }
        }

        private class BindToICollectorCloudQueueMessageProgram
        {
            public static TaskCompletionSource<object> TaskSource { get; set; }

            public static void Run([QueueTrigger(TriggerQueueName)] QueueMessage message,
                [Queue(QueueName)] ICollector<QueueMessage> queue)
            {
                queue.Add(message);
                TaskSource.TrySetResult(null);
            }
        }
    }
}
