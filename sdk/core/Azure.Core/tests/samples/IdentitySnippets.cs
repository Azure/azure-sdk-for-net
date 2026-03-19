// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// These snippet definitions are duplicated from Azure.Identity tests to support
// XML doc code examples in the Identity types that now live in Azure.Core.
// The snippet generator requires definitions to be in the same sdk/* directory tree.

#nullable disable

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Tests.Samples
{
    public class IdentitySnippets
    {
        private const string AUTH_RECORD_PATH = "path/to/auth_record";

        // Fake types so snippets compile without adding package dependencies.
        // Only the type names appear in the generated docs (no namespaces).
        private class BlobClient
        {
            public BlobClient(Uri uri, TokenCredential credential) { }
        }

        private class EventHubProducerClient
        {
            public EventHubProducerClient(string ns, string path, TokenCredential credential) { }
        }

#pragma warning disable CS0618 // Snippet uses obsolete ManagedIdentityCredential constructor
        [Test]
        [Ignore("Snippet only")]
        public void CustomChainedTokenCredential()
        {
            #region Snippet:CustomChainedTokenCredential

            // Authenticate using managed identity if it is available; otherwise use the Azure CLI to authenticate.

            var credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new AzureCliCredential());

            var eventHubProducerClient = new EventHubProducerClient("myeventhub.eventhubs.windows.net", "myhubpath", credential);

            #endregion
        }

        [Test]
        [Ignore("Snippet only")]
        public void UserAssignedManagedIdentityWithClientId()
        {
            string userAssignedClientId = "<your managed identity client ID>";

            #region Snippet:UserAssignedManagedIdentityWithClientId

            // When deployed to an Azure host, DefaultAzureCredential will authenticate the specified user-assigned managed identity.

            //@@string userAssignedClientId = "<your managed identity client ID>";
            var credential = new DefaultAzureCredential(
                new DefaultAzureCredentialOptions
                {
                    ManagedIdentityClientId = userAssignedClientId
                });

            var blobClient = new BlobClient(
                new Uri("https://myaccount.blob.core.windows.net/mycontainer/myblob"),
                credential);

            #endregion
        }

        [Test]
        [Ignore("Snippet only")]
        public async Task AuthenticationRecord_TokenCachePersistenceOptions()
        {
            #region Snippet:AuthenticationRecord_TokenCachePersistenceOptions

            const string TOKEN_CACHE_NAME = "MyTokenCache";
            InteractiveBrowserCredential credential;
            AuthenticationRecord authRecord;

            // Check if an AuthenticationRecord exists on disk.
            // If it does not exist, get one and serialize it to disk.
            // If it does exist, load it from disk and deserialize it.
            if (!File.Exists(AUTH_RECORD_PATH))
            {
                // Construct a credential with TokenCachePersistenceOptions specified to ensure that the token cache is persisted to disk.
                // We can also optionally specify a name for the cache to avoid having it cleared by other applications.
                credential = new InteractiveBrowserCredential(
                    new InteractiveBrowserCredentialOptions { TokenCachePersistenceOptions = new TokenCachePersistenceOptions { Name = TOKEN_CACHE_NAME } });

                // Call AuthenticateAsync to fetch a new AuthenticationRecord.
                authRecord = await credential.AuthenticateAsync();

                // Serialize the AuthenticationRecord to disk so that it can be re-used across executions of this initialization code.
                using var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Create, FileAccess.Write);
                await authRecord.SerializeAsync(authRecordStream);
            }
            else
            {
                // Load the previously serialized AuthenticationRecord from disk and deserialize it.
                using var authRecordStream = new FileStream(AUTH_RECORD_PATH, FileMode.Open, FileAccess.Read);
                authRecord = await AuthenticationRecord.DeserializeAsync(authRecordStream);

                // Construct a new client with our TokenCachePersistenceOptions with the addition of the AuthenticationRecord property.
                // This tells the credential to use the same token cache in addition to which account to try and fetch from cache when GetToken is called.
                credential = new InteractiveBrowserCredential(
                    new InteractiveBrowserCredentialOptions
                    {
                        TokenCachePersistenceOptions = new TokenCachePersistenceOptions { Name = TOKEN_CACHE_NAME },
                        AuthenticationRecord = authRecord
                    });
            }

            // Construct our client with the credential which is connected to the token cache
            // with the capability of silent authentication for the account specified in the AuthenticationRecord.
            var client = new SecretClient(new Uri("https://myvault.vault.azure.net/"), credential);

            #endregion
        }
#pragma warning restore CS0618
    }
}
