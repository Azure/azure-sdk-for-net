// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A compatibility shim allowing a shared access signature to be used as a
    ///   renewable security token with the Track One types.
    /// </summary>
    ///
    /// <seealso cref="Authorization.EventHubTokenCredential"/>
    /// <seealso cref="TrackOne.TokenProvider" />
    ///
    internal sealed class TrackOneGenericTokenProvider : TokenProvider
    {
        /// <summary>The default scope to use for token acquisition with the Event Hubs service.</summary>
        private static readonly string[] EventHubsDefaultScopes = new[] { "https://eventhubs.azure.net/.default" };

        /// <summary>
        ///   The <see cref="EventHubTokenCredential" /> that forms the basis of this security token.
        /// </summary>
        ///
        public EventHubTokenCredential Credential { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneGenericTokenProvider"/> class.
        /// </summary>
        ///
        /// <param name="credential">The <see cref="EventHubTokenCredential" /> on which to base the token.</param>
        ///
        public TrackOneGenericTokenProvider(EventHubTokenCredential credential)
        {
            Argument.NotNull(credential, nameof(credential));
            Argument.NotNullOrEmpty(credential.Resource, nameof(credential.Resource));

            Credential = credential;
        }

        /// <summary>
        ///   Provides a security token based on a shared access signature which can be used for authorization against
        ///   an Event Hub.
        /// </summary>
        ///
        /// <param name="resource">The resource to which the token applies; this is also known as the token audience.</param>
        /// <param name="tokenValidityDuration">The duration that the token should be considered valid.</param>
        ///
        /// <returns>The security token.</returns>
        ///
        public async override Task<SecurityToken> GetTokenAsync(string resource,
                                                                TimeSpan tokenValidityDuration)
        {
            Argument.NotNullOrEmpty(resource, nameof(resource));
            Argument.NotNegative(tokenValidityDuration, nameof(tokenValidityDuration));

            // The resource of a token is assigned at the Event Hub level.  The resource being requested may be a child
            // of the Event Hub, such as a partition.  Ensure that the resource being requested is the same Event Hub associated
            // with the token or one of its children.
            //
            // Do not issue the token for a request that is a different Event Hub, or for a scope that is less restrictive than
            // an Event Hub, such as a top-level namespace.
            //
            // For example, if the token resource is: "amqps://myeventhubs.servicebus.net/someHub"
            //
            //    Allow:
            //      amqps://myeventhubs.servicebus.net/someHub
            //      amqps://myeventhubs.servicebus.net/someHub/partitions/0
            //
            //    Disallow:
            //      amqps://myeventhubs.servicebus.net
            //      https://my.eventhubs.servicebus.net/someHub
            //      amqps://myeventhubs.servicebus.net/otherHub
            //      amqps://notmine.servicebus.net/SomeHub

            if (resource.IndexOf(Credential.Resource, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ResourceMustMatchSharedAccessSignature, resource, Credential.Resource), nameof(resource));
            }

            var accessToken = await Credential.GetTokenAsync(new TokenRequest(EventHubsDefaultScopes), CancellationToken.None).ConfigureAwait(false);

            return new TrackOneGenericToken
            (
                Credential,
                accessToken.Token,
                resource,
                accessToken.ExpiresOn.UtcDateTime
            );
        }
    }
}
