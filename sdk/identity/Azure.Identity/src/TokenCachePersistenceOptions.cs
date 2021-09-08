// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the token cache.
    /// </summary>
    /// <example>
    /// <para>
    ///
    /// </para>
    /// <code snippet="Snippet:CustomChainedTokenCredential" language="csharp">
    /// // Authenticate using managed identity if it is available; otherwise use the Azure CLI to authenticate.
    ///
    /// var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());
    ///
    /// var eventHubProducerClient = new EventHubProducerClient(&quot;myeventhub.eventhubs.windows.net&quot;, &quot;myhubpath&quot;, credential);
    /// </code>
    /// </example>
    public class TokenCachePersistenceOptions
    {
        /// <summary>
        /// Name uniquely identifying the <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If set to true the token cache may be persisted as an unencrypted file if no OS level user encryption is available. When set to false the token cache
        /// will throw a <see cref="CredentialUnavailableException"/> in the event no OS level user encryption is available.
        /// </summary>
        public bool UnsafeAllowUnencryptedStorage { get; set; }
    }
}
