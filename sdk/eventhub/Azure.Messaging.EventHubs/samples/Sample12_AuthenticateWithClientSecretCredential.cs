// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of publishing and reading from an Event Hub using an Azure Active Directory application
    ///   with a client secret for authorization.
    /// </summary>
    ///
    /// <remarks>
    ///   This sample requires a service principal in addition to the Event Hubs environment used for
    ///   samples.  The following script may be used to create all the resources needed to run this sample that can be found at:
    ///   https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/identity-tests-azure-setup.ps1
    /// </remarks>
    ///
    /// <seealso href="https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals"/>
    /// <seealso href="https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow"/>
    ///
    public class Sample12_AuthenticateWithClientSecretCredential : IEventHubsIdentitySample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample12_AuthenticateWithClientSecretCredential);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of interacting with an Event Hub using an Azure Active Directory application with client secret for authorization.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="tenantId">The Azure Active Directory tenant that holds the service principal.</param>
        /// <param name="clientId">The Azure Active Directory client identifier of the service principal.</param>
        /// <param name="secret">The Azure Active Directory secret of the service principal.</param>
        ///
        public async Task RunAsync(string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string tenantId,
                                   string clientId,
                                   string secret)
        {
            int eventsPublished = 0;
            int eventsRead = 0;

            // Service principal authentication is a means for applications to authenticate against Azure Active
            // Directory and consume Azure services. This is advantageous compared to using a connection string for
            // authorization, as it offers a far more robust mechanism for transparently updating credentials in place,
            // without an application being explicitly aware or involved.
            //
            // For this example, we'll take advantage of a service principal to publish and receive events.  To do so, we'll make
            // use of the ClientSecretCredential from the Azure.Identity library to enable the Event Hubs clients to perform authorization
            // using a service principal.

            ClientSecretCredential credential = new ClientSecretCredential(tenantId, clientId, secret);

            // To start, we'll publish a small number of events using a producer client.  To ensure that our client is appropriately closed, we'll
            // take advantage of the asynchronous dispose when we are done or when an exception is encountered.

            await using (var producerClient = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential))
            {
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("The middle event is this one")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));

                await producerClient.SendAsync(eventBatch);

                eventsPublished = eventBatch.Count;
                Console.WriteLine("The event batch has been published.");
            }

            // With our events published, we'll create a consumer client to read them.  We'll stop reading after we've received all events in the
            // batch.

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential))
            {
                // To ensure that we do not wait for an indeterminate length of time, we'll stop reading after we receive three events.  For a
                // fresh Event Hub, those will be the three that we had published.  We'll also ask for cancellation after 30 seconds, just to be
                // safe.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(60));

                await foreach (PartitionEvent partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
                {
                    Console.WriteLine($"Event Read: { Encoding.UTF8.GetString(partitionEvent.Data.EventBody.ToBytes().ToArray()) }");
                    eventsRead++;

                    if (eventsRead >= eventsPublished)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
