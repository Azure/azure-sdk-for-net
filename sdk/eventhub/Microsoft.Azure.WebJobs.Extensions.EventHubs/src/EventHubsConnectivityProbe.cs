// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// DRAFT (Flex Consumption Network Troubleshooter): non-mutating connectivity probe for
    /// Event Hubs trigger dependencies. Reuses the extension's own <see cref="EventHubClientFactory"/>
    /// — which already resolves the connection (connection string, or fullyQualifiedNamespace +
    /// managed identity) — and calls GetPartitionIds to verify the app can reach and authenticate
    /// to the Event Hub from its network context. No events are produced or consumed.
    /// </summary>
    /// <remarks>
    /// This is the probe body that an SDK-level connectivity abstraction (e.g. a future
    /// IConnectivityValidator in Microsoft.Azure.WebJobs) would invoke. It intentionally does NOT
    /// depend on Microsoft.Extensions.Diagnostics.HealthChecks, so the extension takes no new
    /// package dependency. Target discovery (which Event Hub + connection) comes from the app's
    /// trigger bindings; the caller supplies them here.
    /// </remarks>
    internal sealed class EventHubsConnectivityProbe
    {
        private readonly EventHubClientFactory _clientFactory;

        public EventHubsConnectivityProbe(EventHubClientFactory clientFactory)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        /// <summary>
        /// Performs a non-mutating connectivity + auth probe against the given Event Hub.
        /// </summary>
        /// <param name="eventHubName">The Event Hub name, from the trigger binding.</param>
        /// <param name="connection">The connection setting name, from the trigger binding.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        public async Task<EventHubsConnectivityResult> ValidateAsync(
            string eventHubName, string connection, CancellationToken cancellationToken = default)
        {
            try
            {
                EventHubProducerClient producer = _clientFactory.GetEventHubProducerClient(eventHubName, connection);
                await producer.GetPartitionIdsAsync(cancellationToken).ConfigureAwait(false);
                return EventHubsConnectivityResult.Success();
            }
            catch (Exception ex)
            {
                // The exception carries the root cause (auth failure, DNS/firewall, missing private
                // endpoint, etc.). A shared decoder maps it to a structured status for the caller.
                return EventHubsConnectivityResult.Failure(ex);
            }
        }
    }

    /// <summary>
    /// Result of an <see cref="EventHubsConnectivityProbe"/> probe.
    /// </summary>
    internal sealed record EventHubsConnectivityResult
    {
        private EventHubsConnectivityResult(bool isHealthy, string details, Exception exception)
        {
            IsHealthy = isHealthy;
            Details = details;
            Exception = exception;
        }

        public bool IsHealthy { get; }

        public string Details { get; }

        public Exception Exception { get; }

        public static EventHubsConnectivityResult Success() => new(true, "Reachable.", null);

        public static EventHubsConnectivityResult Failure(Exception exception) =>
            new(false, exception?.Message, exception);
    }
}
