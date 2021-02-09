// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Provides a credential based on a shared access signature for a given
    ///   Event Hub instance.
    /// </summary>
    ///
    internal sealed class EventHubsSharedAccessKeyCredential
    {
        /// <summary>
        ///   The name of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        /// <value>
        ///   This will only be populated when the credential is created using a shared key, not when created
        ///   using a precomputed shared access signature.
        /// </value>
        ///
        public string SharedAccessKeyName { get; private set; }

        /// <summary>
        ///   The value of the shared access key to be used for authorization, as
        ///   reported by the Azure portal.
        /// </summary>
        ///
        /// <value>
        ///   This will only be populated when the credential is created using a shared key, not when created
        ///   using a precomputed shared access signature.
        /// </value>
        ///
        public string SharedAccessKey { get; private set; }

        /// <summary>
        ///   The value of the precomputed shared access signature to be used for authorization.
        /// </summary>
        ///
        /// <value>
        ///   This will only be populated when the credential is created using a precomputed shared access signature, not when created
        ///   using a shared key.
        /// </value>
        ///
        public string SharedAccessSignature { get; private set; }

        /// <summary>
        ///   A reference to a corresponding SharedAccessSignatureCredential.
        /// </summary>
        ///
        private SharedAccessSignatureCredential SharedAccessSignatureCredential { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsSharedAccessKeyCredential" /> class.
        /// </summary>
        ///
        /// <param name="sharedAccessKeyName">The name of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        /// <param name="sharedAccessKey">The value of the shared access key to be used for authorization, as reported by the Azure portal.</param>
        ///
        public EventHubsSharedAccessKeyCredential(string sharedAccessKeyName,
                                                  string sharedAccessKey)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessKeyName, nameof(sharedAccessKeyName));
            Argument.AssertNotNullOrEmpty(sharedAccessKey, nameof(sharedAccessKey));

            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsSharedAccessKeyCredential" /> class.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature"> The shared access signature that forms the basis of this security token.</param>
        ///
        public EventHubsSharedAccessKeyCredential(string sharedAccessSignature)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessSignature, nameof(sharedAccessSignature));
            SharedAccessSignature = sharedAccessSignature;
        }

        /// <summary>
        ///   Allows the rotation of Shared Access Signatures.
        /// </summary>
        ///
        /// <param name="keyName">The name of the shared access key that the signature should be based on.</param>
        /// <param name="keyValue">The value of the shared access key for the signature.</param>
        ///
        public void UpdateSharedAccessKey(string keyName,
                                          string keyValue)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            Argument.AssertNotNullOrEmpty(keyValue, nameof(keyValue));

            SharedAccessKeyName = keyName;
            SharedAccessKey = keyValue;
            SharedAccessSignature = null;

            SharedAccessSignatureCredential?.UpdateSharedAccessKey(keyName, keyValue);
        }

        /// <summary>
        ///   Allows the rotation of Shared Access Signatures.
        /// </summary>
        ///
        /// <param name="sharedAccessSignature"> The shared access signature that forms the basis of this security token.</param>
        ///
        public void UpdateSharedAccessSignature(string sharedAccessSignature)
        {
            Argument.AssertNotNullOrEmpty(sharedAccessSignature, nameof(sharedAccessSignature));

            SharedAccessSignature = sharedAccessSignature;
            SharedAccessKeyName = null;
            SharedAccessKey = null;

            SharedAccessSignatureCredential?.UpdateSharedAccessSignature(sharedAccessSignature);
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Coverts to shared access signature credential.
        ///   It retains a reference to the generated SharedAccessSignatureCredential.
        /// </summary>
        ///
        /// <param name="eventHubResource">The Event Hubs resource to which the token is intended to serve as authorization.</param>
        /// <param name="signatureValidityDuration">The duration that the signature should be considered valid; if not specified, a default will be assumed.</param>
        ///
        /// <returns>A new <see cref="SharedAccessSignatureCredential" /> based on the requested shared access key.</returns>
        ///
        internal SharedAccessSignatureCredential AsSharedAccessSignatureCredential(string eventHubResource,
                                                                                   TimeSpan? signatureValidityDuration = default)
        {
            SharedAccessSignatureCredential = string.IsNullOrEmpty(SharedAccessSignature)
                ? new SharedAccessSignatureCredential(new SharedAccessSignature(eventHubResource, SharedAccessKeyName, SharedAccessKey, signatureValidityDuration))
                : new SharedAccessSignatureCredential(new SharedAccessSignature(SharedAccessSignature));

            return SharedAccessSignatureCredential;
        }
    }
}
