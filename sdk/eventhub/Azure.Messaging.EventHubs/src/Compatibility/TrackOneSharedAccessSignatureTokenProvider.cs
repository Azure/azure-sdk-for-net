// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A compatibility shim allowing a shared access signature to be used as a
    ///   renewable security token with the Track One types.
    /// </summary>
    ///
    /// <seealso cref="Authorization.SharedAccessSignature"/>
    /// <seealso cref="TrackOne.TokenProvider" />
    ///
    internal sealed class TrackOneSharedAccessTokenProvider : TokenProvider
    {
        /// <summary>
        ///   The shared access signature that forms the basis of this security token.
        /// </summary>
        ///
        public SharedAccessSignature SharedAccessSignature { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneSharedAccessTokenProvider"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature on which to base tokens produced by the provider.</param>
        ///
        public TrackOneSharedAccessTokenProvider(SharedAccessSignature sharedAccessSignature)
        {
            Guard.ArgumentNotNull(nameof(sharedAccessSignature), sharedAccessSignature);
            Guard.ArgumentNotNullOrEmpty(nameof(sharedAccessSignature.SharedAccessKey), sharedAccessSignature.SharedAccessKey);

            SharedAccessSignature = sharedAccessSignature.Clone();
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
        public override Task<SecurityToken> GetTokenAsync(string resource,
                                                          TimeSpan tokenValidityDuration)
        {
            Guard.ArgumentNotNullOrEmpty(nameof(resource), resource);
            Guard.ArgumentNotNegative(nameof(tokenValidityDuration), tokenValidityDuration);

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

            if (resource.IndexOf(SharedAccessSignature.Resource, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.ResourceMustMatchSharedAccessSignature, resource, SharedAccessSignature.Resource), nameof(resource));
            }

            SharedAccessSignature.ExtendExpiration(tokenValidityDuration);

            return Task.FromResult<SecurityToken>(new TrackOneSharedAccessSignatureToken(SharedAccessSignature));
        }
    }
}
