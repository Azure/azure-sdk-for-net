// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace TrackOne.Amqp.Management
{
    internal class AmqpServiceClient : ClientEntity
    {
        private static readonly string[] RequiredClaims = { ClaimConstants.Manage, ClaimConstants.Listen };
        private readonly AmqpEventHubClient eventHubClient;
        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> link;
        private readonly AsyncLock tokenLock = new AsyncLock();
        private SecurityToken token;

        public AmqpServiceClient(AmqpEventHubClient eventHubClient, string address)
            : base("AmqpServiceClient-" + StringUtility.GetRandomString())
        {
            this.eventHubClient = eventHubClient;
            Address = address;
            link = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(OpenLinkAsync, rrlink => rrlink.CloseAsync(TimeSpan.FromSeconds(10)));
        }

        private AmqpMessage CreateGetRuntimeInformationRequest()
        {
            AmqpMessage getRuntimeInfoRequest = AmqpMessage.Create();
            getRuntimeInfoRequest.ApplicationProperties = new ApplicationProperties();
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.EntityNameKey] = eventHubClient.EventHubName;
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.ManagementOperationKey] = AmqpClientConstants.ReadOperationValue;
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.ManagementEntityTypeKey] = AmqpClientConstants.ManagementEventHubEntityTypeValue;

            return getRuntimeInfoRequest;
        }

        private AmqpMessage CreateGetPartitionRuntimeInformationRequest(string partitionKey)
        {
            AmqpMessage getRuntimeInfoRequest = AmqpMessage.Create();
            getRuntimeInfoRequest.ApplicationProperties = new ApplicationProperties();
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.EntityNameKey] = eventHubClient.EventHubName;
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.PartitionNameKey] = partitionKey;
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.ManagementOperationKey] = AmqpClientConstants.ReadOperationValue;
            getRuntimeInfoRequest.ApplicationProperties.Map[AmqpClientConstants.ManagementEntityTypeKey] = AmqpClientConstants.ManagementPartitionEntityTypeValue;

            return getRuntimeInfoRequest;
        }

        public async Task<EventHubRuntimeInformation> GetRuntimeInformationAsync()
        {
            RequestResponseAmqpLink requestLink = await link.GetOrCreateAsync(
                TimeSpan.FromSeconds(AmqpClientConstants.AmqpSessionTimeoutInSeconds)).ConfigureAwait(false);

            // Create request and attach token.
            AmqpMessage request = CreateGetRuntimeInformationRequest();
            request.ApplicationProperties.Map[AmqpClientConstants.ManagementSecurityTokenKey] = await GetTokenString().ConfigureAwait(false);

            AmqpMessage response = await requestLink.RequestAsync(request, eventHubClient.ConnectionStringBuilder.OperationTimeout).ConfigureAwait(false);
            int statusCode = (int)response.ApplicationProperties.Map[AmqpClientConstants.ResponseStatusCode];
            string statusDescription = (string)response.ApplicationProperties.Map[AmqpClientConstants.ResponseStatusDescription];
            if (statusCode != (int)AmqpResponseStatusCode.Accepted && statusCode != (int)AmqpResponseStatusCode.OK)
            {
                AmqpSymbol errorCondition = AmqpExceptionHelper.GetResponseErrorCondition(response, (AmqpResponseStatusCode)statusCode);
                Error error = new Error { Condition = errorCondition, Description = statusDescription };
                throw AmqpExceptionHelper.ToMessagingContract(error);
            }

            AmqpMap infoMap = null;
            if (response.ValueBody != null)
            {
                infoMap = response.ValueBody.Value as AmqpMap;
            }

            if (infoMap == null)
            {
                throw new InvalidOperationException($"Return type mismatch in GetRuntimeInformationAsync. Response returned NULL or response isn't AmqpMap.");
            }

            return new EventHubRuntimeInformation()
            {
                Type = (string)infoMap[new MapKey("type")],
                Path = (string)infoMap[new MapKey("name")],
                CreatedAt = (DateTime)infoMap[new MapKey("created_at")],
                PartitionCount = (int)infoMap[new MapKey("partition_count")],
                PartitionIds = (string[])infoMap[new MapKey("partition_ids")],
            };
        }

        public async Task<EventHubPartitionRuntimeInformation> GetPartitionRuntimeInformationAsync(string partitionId)
        {
            RequestResponseAmqpLink requestLink = await link.GetOrCreateAsync(
                TimeSpan.FromSeconds(AmqpClientConstants.AmqpSessionTimeoutInSeconds)).ConfigureAwait(false);

            // Create request and attach token.
            AmqpMessage request = CreateGetPartitionRuntimeInformationRequest(partitionId);
            request.ApplicationProperties.Map[AmqpClientConstants.ManagementSecurityTokenKey] = await GetTokenString().ConfigureAwait(false);

            AmqpMessage response = await requestLink.RequestAsync(request, eventHubClient.ConnectionStringBuilder.OperationTimeout).ConfigureAwait(false);
            int statusCode = (int)response.ApplicationProperties.Map[AmqpClientConstants.ResponseStatusCode];
            string statusDescription = (string)response.ApplicationProperties.Map[AmqpClientConstants.ResponseStatusDescription];
            if (statusCode != (int)AmqpResponseStatusCode.Accepted && statusCode != (int)AmqpResponseStatusCode.OK)
            {
                AmqpSymbol errorCondition = AmqpExceptionHelper.GetResponseErrorCondition(response, (AmqpResponseStatusCode)statusCode);
                Error error = new Error { Condition = errorCondition, Description = statusDescription };
                throw AmqpExceptionHelper.ToMessagingContract(error);
            }

            AmqpMap infoMap = null;
            if (response.ValueBody != null)
            {
                infoMap = response.ValueBody.Value as AmqpMap;
            }

            if (infoMap == null)
            {
                throw new InvalidOperationException($"Return type mismatch in GetPartitionRuntimeInformationAsync. Response returned NULL or response isn't AmqpMap.");
            }

            return new EventHubPartitionRuntimeInformation()
            {
                Type = (string)infoMap[new MapKey(AmqpClientConstants.EntityTypeName)],
                Path = (string)infoMap[new MapKey(AmqpClientConstants.EntityNameKey)],
                PartitionId = (string)infoMap[new MapKey(AmqpClientConstants.PartitionNameKey)],
                BeginSequenceNumber = (long)infoMap[new MapKey(AmqpClientConstants.ManagementPartitionBeginSequenceNumber)],
                LastEnqueuedSequenceNumber = (long)infoMap[new MapKey(AmqpClientConstants.ManagementPartitionLastEnqueuedSequenceNumber)],
                LastEnqueuedOffset = (string)infoMap[new MapKey(AmqpClientConstants.ManagementPartitionLastEnqueuedOffset)],
                LastEnqueuedTimeUtc = (DateTime)infoMap[new MapKey(AmqpClientConstants.ManagementPartitionLastEnqueuedTimeUtc)],
                IsEmpty = (bool)infoMap[new MapKey(AmqpClientConstants.ManagementPartitionRuntimeInfoPartitionIsEmpty)]
            };
        }

        public string Address { get; }

        public override Task CloseAsync()
        {
            return link.CloseAsync();
        }

        private async Task<string> GetTokenString()
        {
            using (await tokenLock.LockAsync().ConfigureAwait(false))
            {
                // Expect maximum 5 minutes of clock skew between client and the service
                // when checking for token expiry.
                if (token == null || DateTime.UtcNow > token.ExpiresAtUtc.Subtract(TimeSpan.FromMinutes(5)))
                {
                    token = await eventHubClient.InternalTokenProvider.GetTokenAsync(
                        eventHubClient.ConnectionStringBuilder.Endpoint.AbsoluteUri,
                        eventHubClient.ConnectionStringBuilder.OperationTimeout).ConfigureAwait(false);
                }

                return token.TokenValue.ToString();
            }
        }

        internal void OnAbort()
        {
            if (link.TryGetOpenedObject(out RequestResponseAmqpLink innerLink))
            {
                innerLink?.Abort();
            }
        }

        private async Task<RequestResponseAmqpLink> OpenLinkAsync(TimeSpan timeout)
        {
            ActiveClientRequestResponseLink activeClientLink = await OpenRequestResponseLinkAsync(
                "svc", Address, null, AmqpServiceClient.RequiredClaims, timeout).ConfigureAwait(false);
            return activeClientLink.Link;
        }

        private async Task<ActiveClientRequestResponseLink> OpenRequestResponseLinkAsync(
            string type, string address, MessagingEntityType? entityType, string[] requiredClaims, TimeSpan timeout)
        {
            var timeoutHelper = new TimeoutHelper(timeout, true);
            AmqpSession session = null;
            try
            {
                // Don't need to get token for namespace scope operations, included in request
                bool isNamespaceScope = address.Equals(AmqpClientConstants.ManagementAddress, StringComparison.OrdinalIgnoreCase);

                AmqpConnection connection = await eventHubClient.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);

                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeoutHelper.RemainingTime().TotalMilliseconds);
                if (entityType != null)
                {
                    linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)entityType.Value);
                }

                // Create the link
                var link = new RequestResponseAmqpLink(type, session, address, linkSettings.Properties);

                DateTime authorizationValidToUtc = DateTime.MaxValue;

                if (!isNamespaceScope)
                {
                    // TODO: Get Entity level token here
                }

                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                // Redirected scenario requires entityPath as the audience, otherwise we
                // should always use the full EndpointUri as audience.
                return new ActiveClientRequestResponseLink(
                    link,
                    eventHubClient.ConnectionStringBuilder.Endpoint.AbsoluteUri, // audience
                    eventHubClient.ConnectionStringBuilder.Endpoint.AbsoluteUri, // endpointUri
                    requiredClaims,
                    false,
                    authorizationValidToUtc);
            }
            catch (Exception)
            {
                // Aborting the session will cleanup the link as well.
                session?.Abort();
                throw;
            }
        }
    }
}
