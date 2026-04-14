// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    /// <summary>
    /// Options controlling the storage of the token cache.
    /// </summary>
    /// <example>
    /// <para>
    /// This is an example showing how TokenCachePersistenceOptions and an AuthenticationRecord can be used together to enable silent authentication
    /// across executions of a client application.
    /// </para>
    /// <code snippet="Snippet:AuthenticationRecord_TokenCachePersistenceOptions" language="csharp">
    /// const string TOKEN_CACHE_NAME = &quot;MyTokenCache&quot;;
    /// InteractiveBrowserCredential credential;
    /// AuthenticationRecord authRecord;
    ///
    /// // Check if an AuthenticationRecord exists on disk.
    /// // If it does not exist, get one and serialize it to disk.
    /// // If it does exist, load it from disk and deserialize it.
    /// if (!File.Exists(AUTH_RECORD_PATH))
    /// {
    ///     // Construct a credential with TokenCachePersistenceOptions specified to ensure that the token cache is persisted to disk.
    ///     // We can also optionally specify a name for the cache to avoid having it cleared by other applications.
    ///     credential = new InteractiveBrowserCredential(
    ///         new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = new TokenCachePersistenceOptions { Name = TOKEN_CACHE_NAME } });
    ///
    ///     // Call AuthenticateAsync to fetch a new AuthenticationRecord.
    ///     authRecord = await credential.AuthenticateAsync();
    ///
    ///     // Serialize the AuthenticationRecord to disk so that it can be re-used across executions of this initialization code.
    ///     using var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Create, FileAccess.Write);
    ///     await authRecord.SerializeAsync(authRecordStream);
    /// }
    /// else
    /// {
    ///     // Load the previously serialized AuthenticationRecord from disk and deserialize it.
    ///     using var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Open, FileAccess.Read);
    ///     authRecord = await AuthenticationRecord.DeserializeAsync(authRecordStream);
    ///
    ///     // Construct a new client with our TokenCachePersistenceOptions with the addition of the AuthenticationRecord property.
    ///     // This tells the credential to use the same token cache in addition to which account to try and fetch from cache when GetToken is called.
    ///     credential = new InteractiveBrowserCredential(
    ///         new InteractiveBrowserCredentialOptions
    ///         {
    ///             TokenCachePersistenceOptions = new TokenCachePersistenceOptions { Name = TOKEN_CACHE_NAME },
    ///             AuthenticationRecord = authRecord
    ///         });
    /// }
    ///
    /// // Construct our client with the credential which is connected to the token cache
    /// // with the capability of silent authentication for the account specified in the AuthenticationRecord.
    /// var client = new SecretClient(new Uri(&quot;https://myvault.vault.azure.net/&quot;), credential);
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

        /// <summary>
        /// Creates a copy of the <see cref="TokenCachePersistenceOptions"/>.
        /// </summary>
        /// <returns></returns>
        internal TokenCachePersistenceOptions Clone() {
            return new TokenCachePersistenceOptions {
                Name = Name,
                UnsafeAllowUnencryptedStorage = UnsafeAllowUnencryptedStorage
            };
        }
    }
}
