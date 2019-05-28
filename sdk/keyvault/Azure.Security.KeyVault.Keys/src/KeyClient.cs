// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyClient
    {
        private readonly Uri _vaultUri;
        private const string ApiVersion = "7.0";
        private readonly HttpPipeline _pipeline;

        protected KeyClient()
        {

        }
        public KeyClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        public KeyClient(Uri vaultUri, TokenCredential credential, KeyClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));
            options = options ?? new KeyClientOptions();

            _pipeline = HttpPipeline.Build(options,
                    options.ResponseClassifier,
                    options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net//.Default"),
                    options.LoggingPolicy,
                    BufferResponsePolicy.Singleton);
        }

        public virtual Response<Key> CreateKey(string name, JsonWebKeyType keyType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateKeyAsync(string name, JsonWebKeyType keyType, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> CreateKey(KeyCreateOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateKeyAsync(KeyCreateOptions options, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> CreateEcKey(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateEcKeyAsync(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> CreateRsaKey(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateRsaKeyAsync(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> UpdateKey(KeyBase key, IList<string> keyOps = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> UpdateKeyAsync(KeyBase key, IList<string> keyOps = null, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> GetKey(string name, string version = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> GetKeyAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<Key>> GetAllKeys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<Key>> GetAllKeysAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<Key>> GetKeyVersions(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<Key>> GetKeyVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Response<DeletedKey> GetDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<DeletedKey>> GetDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<DeletedKey> DeleteKey(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<DeletedKey>> DeleteKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<DeletedKey>> GetAllDeletedKeys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<DeletedKey>> GetAllDeletedKeysAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Response PurgeDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response> PurgeDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> RecoverDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> RecoverDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<byte[]> BackupKey(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<byte[]>> BackupKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> RestoreKey(byte[] backup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> RestoreKeyAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> ImportKey(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> ImportKeyAsync(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> ImportKey(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> ImportKeyAsync(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
