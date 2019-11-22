// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of how to produce and consume events with Azure.Identity.
    ///
    ///   A script may be used to create all the resources needed to run this sample that can be found at:
    ///
    ///   https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/identity-tests-azure-setup.ps1
    ///
    ///   An extract of this sample was taken from <see cref="Sample08_ConsumeEvents" />
    ///
    /// </summary>
    public class Sample12_AuthenticateWithClientSecretCredential : IEventHubsIdentitySample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample12_AuthenticateWithClientSecretCredential);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An example of creating an Event Hub client using a Azure Active Directory application with a client secret for authorization.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against</param>
        /// <param name="tenantId">The Azure Active Directory tenant that holds the service principal</param>
        /// <param name="clientId">The Azure Active Directory client identifier of the service principal</param>
        /// <param name="secret">The Azure Active Directory secret of the service principal</param>
        ///
        public async Task RunAsync(string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string tenantId,
                                   string clientId,
                                   string secret)
        {
            // Service principal authentication is a means for applications to authenticate
            // against Azure Active Directory and consume Azure services. This is advantageous compared
            // to signing in using fully privileged users as it allows to enforce role-based authorization
            // from the portal.
            //
            // Service principal authentication differs from managed identity authentication also because the principal to be used
            // will be able to authenticate with the portal without the need for the code to run within the portal.
            // The authentication between the Event Hubs client and the portal is performed through OAuth 2.0.
            // (see: https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals)

            // ClientSecretCredential allows performing service principal authentication passing
            // tenantId, clientId and clientSecret directly from the constructor.
            // (see: https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow)

            var credentials = new ClientSecretCredential(tenantId, clientId, secret);

            // EventHubProducerClient takes ClientSecretCredential from its constructor and tries to issue a token from Azure Active Directory.

            await using (EventHubProducerClient client = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credentials))
            {
                // It will then use that token to authenticate on the portal and enquiry the Hub properties.

                Console.WriteLine($"Contacting the hub using the token issued from client credentials.");

                var properties = await client.GetEventHubPropertiesAsync();

                Console.WriteLine($"Event Hub \"{ properties.Name }\" reached successfully.");
            }

            // The instances of "EventHubProducerClient" and "EventHubProducerClient" will be created
            // passing in "ClientSecretCredential" instead of the connection string. In this way, two things will happen:
            //
            // 1. An OAuth 2.0 token will be created by authenticating against Azure Active Directory using the tenant, client and the secret passed in
            // 2. Role-based authorization will be performed and the "Azure Event Hubs Data Owner" role will be needed to produce and consume events
            //
            // (see: https://docs.microsoft.com/en-us/azure/role-based-access-control/role-definitions)
            // (see: https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#azure-event-hubs-data-owner)

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credentials))
            {
                string firstPartition = (await consumerClient.GetPartitionIdsAsync()).First();

                PartitionEvent receivedEvent;

                ReadEventOptions readOptions = new ReadEventOptions
                {
                    MaximumWaitTime = TimeSpan.FromMilliseconds(150)
                };

                Stopwatch watch = Stopwatch.StartNew();
                bool wereEventsPublished = false;

                CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                await foreach (PartitionEvent currentEvent in consumerClient.ReadEventsFromPartitionAsync(firstPartition, EventPosition.Latest, readOptions, cancellationSource.Token))
                {
                    if (!wereEventsPublished)
                    {
                        await using (var producerClient = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credentials))
                        {
                            using EventDataBatch eventBatch = await producerClient.CreateBatchAsync(new CreateBatchOptions { PartitionId = firstPartition });
                            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));

                            await producerClient.SendAsync(eventBatch);
                            wereEventsPublished = true;

                            Console.WriteLine("The event batch has been published.");
                        }
                    }

                    if (currentEvent.Data != null)
                    {
                        receivedEvent = currentEvent;
                        watch.Stop();
                        break;
                    }
                }

                Console.WriteLine();
                Console.WriteLine($"The following event was consumed in { watch.ElapsedMilliseconds } milliseconds:");

                string message = (receivedEvent.Data == null) ? "No event was received." : Encoding.UTF8.GetString(receivedEvent.Data.Body.ToArray());
                Console.WriteLine($"\tMessage: \"{ message }\"");
            }

            Console.WriteLine();
        }
    }
}
