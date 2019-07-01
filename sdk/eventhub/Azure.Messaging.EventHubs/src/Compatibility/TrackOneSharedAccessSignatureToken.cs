// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using TrackOne;

namespace Azure.Messaging.EventHubs.Compatibility
{
    /// <summary>
    ///   A compatibility shim allowing a shared access signature to be used as a
    ///   security token with the Track One types.
    /// </summary>
    ///
    /// <seealso cref="Authorization.SharedAccessSignature"/>
    /// <seealso cref="TrackOne.SecurityToken" />
    ///
    internal class TrackOneSharedAccessSignatureToken : SecurityToken
    {
        /// <summary>
        ///   The shared access signature that forms the basis of this security token.
        /// </summary>
        ///
        public SharedAccessSignature SharedAccessSignature { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="TrackOneSharedAccessSignatureToken"/> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature">The shared access signature on which to base the token.</param>
        ///
        public TrackOneSharedAccessSignatureToken(SharedAccessSignature sharedAccessSignature) :
            base(sharedAccessSignature?.Value, (sharedAccessSignature?.ExpirationUtc ?? default), sharedAccessSignature?.Resource, ClientConstants.SasTokenType)
        {
            Guard.ArgumentNotNull(nameof(sharedAccessSignature), sharedAccessSignature);
            SharedAccessSignature = sharedAccessSignature;
        }
    }
}
