// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample11_CloudEvents : ServiceBusLiveTestBase
    {
        [Test]
        public async Task RoundTripCloudEvent()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusCloudEvents
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                DefaultAzureCredential credential = new();
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                var credential = TestEnvironment.Credential;
#endif

                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

                // create the sender
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a payload using the CloudEvent type
                var cloudEvent = new CloudEvent(
                    "/cloudevents/example/source",
                    "Example.Employee",
                    new Employee { Name = "Homer", Age = 39 });
                ServiceBusMessage message = new ServiceBusMessage(new BinaryData(cloudEvent))
                {
                    ContentType = "application/cloudevents+json"
                };

                // send the message
                await sender.SendMessageAsync(message);

                // create a receiver that we can use to receive and settle the message
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);

                // receive the message
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                // deserialize the message body into a CloudEvent
                CloudEvent receivedCloudEvent = CloudEvent.Parse(receivedMessage.Body);

                // deserialize to our Employee model
                Employee receivedEmployee = receivedCloudEvent.Data.ToObjectFromJson<Employee>();

                // prints 'Homer'
                Console.WriteLine(receivedEmployee.Name);

                // prints '39'
                Console.WriteLine(receivedEmployee.Age);

                // complete the message, thereby deleting it from the service
                await receiver.CompleteMessageAsync(receivedMessage);
                #endregion

                Assert.AreEqual("Homer", receivedEmployee.Name);
                Assert.AreEqual("application/cloudevents+json", receivedMessage.ContentType);
                Assert.AreEqual(39, receivedEmployee.Age);
                Assert.IsNull(await CreateNoRetryClient().CreateReceiver(queueName).ReceiveMessageAsync());
            }
        }

        private class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
