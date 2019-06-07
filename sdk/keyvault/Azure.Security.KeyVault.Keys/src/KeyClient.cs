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
    public partial class KeyClient
    {
        private readonly Uri _vaultUri;
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
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net//.default"),
                    options.LoggingPolicy,
                    BufferResponsePolicy.Singleton);
        }

        public virtual Response<Key> CreateKey(string name, KeyType keyType, KeyCreateOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyType == default) throw new ArgumentNullException(nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);

            return SendRequest(HttpPipelineMethod.Put, parameters, () => new Key(name), cancellationToken, KeysPath, name);
        }

        public virtual async Task<Response<Key>> CreateKeyAsync(string name, KeyType keyType, KeyCreateOptions keyOptions = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyType == default) throw new ArgumentNullException(nameof(keyType));

            var parameters = new KeyRequestParameters(keyType, keyOptions);
            
            return await SendRequestAsync(HttpPipelineMethod.Put, parameters, () => new Key(name), cancellationToken, KeysPath, name);
        }

        public virtual Response<Key> CreateEcKey(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            if (ecKey == default) throw new ArgumentNullException(nameof(ecKey));

            var parameters = new KeyRequestParameters(ecKey);

            return SendRequest(HttpPipelineMethod.Put, parameters, () => new Key(ecKey.Name), cancellationToken, KeysPath, ecKey.Name);
        }

        public virtual async Task<Response<Key>> CreateEcKeyAsync(EcKeyCreateOptions ecKey, CancellationToken cancellationToken = default)
        {
            if (ecKey == default) throw new ArgumentNullException(nameof(ecKey));

            var parameters = new KeyRequestParameters(ecKey);

            return await SendRequestAsync(HttpPipelineMethod.Put, parameters, () => new Key(ecKey.Name), cancellationToken, KeysPath, ecKey.Name);
        }

        public virtual Response<Key> CreateRsaKey(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            if (rsaKey == default) throw new ArgumentNullException(nameof(rsaKey));

            var parameters = new KeyRequestParameters(rsaKey);

            return SendRequest(HttpPipelineMethod.Put, parameters, () => new Key(rsaKey.Name), cancellationToken, KeysPath, rsaKey.Name);
        }

        public virtual async Task<Response<Key>> CreateRsaKeyAsync(RsaKeyCreateOptions rsaKey, CancellationToken cancellationToken = default)
        {
            if (rsaKey == default) throw new ArgumentNullException(nameof(rsaKey));

            var parameters = new KeyRequestParameters(rsaKey);

            return await SendRequestAsync(HttpPipelineMethod.Put, parameters, () => new Key(rsaKey.Name), cancellationToken, KeysPath, rsaKey.Name);
        }

        public virtual Response<Key> UpdateKey(KeyBase key, IEnumerable<KeyOperations> keyOperations, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key?.Name)) throw new ArgumentException($"{nameof(key.Name)} can't be empty or null");
            if (string.IsNullOrEmpty(key?.Version)) throw new ArgumentException($"{nameof(key.Version)} can't be empty or null");

            var parameters = new KeyRequestParameters(key, keyOperations);

            return SendRequest(HttpPipelineMethod.Patch, parameters, () => new Key(key.Name), cancellationToken, KeysPath, key.Name, key.Version);
        }

        public virtual async Task<Response<Key>> UpdateKeyAsync(KeyBase key, IEnumerable<KeyOperations> keyOperations, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key?.Name)) throw new ArgumentException($"{nameof(key.Name)} can't be empty or null");
            if (string.IsNullOrEmpty(key?.Version)) throw new ArgumentException($"{nameof(key.Version)} can't be empty or null");

            var parameters = new KeyRequestParameters(key, keyOperations);

            return await SendRequestAsync(HttpPipelineMethod.Patch, parameters, () => new Key(key.Name), cancellationToken, KeysPath, key.Name, key.Version);
        }

        public virtual Response<Key> GetKey(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return SendRequest(HttpPipelineMethod.Get, () => new Key(name), cancellationToken, KeysPath, name, version);
        }

        public virtual async Task<Response<Key>> GetKeyAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new Key(name), cancellationToken, KeysPath, name, version);
        }

        public virtual IEnumerable<Response<KeyBase>> GetKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new KeyBase(), cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<KeyBase>> GetKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new KeyBase(), cancellationToken));
        }

        public virtual IEnumerable<Response<KeyBase>> GetKeyVersions(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new KeyBase(), cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<KeyBase>> GetKeyVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = CreateFirstPageUri(KeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new KeyBase(), cancellationToken));
        }

        public virtual Response<DeletedKey> GetDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return SendRequest(HttpPipelineMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name);
        }

        public virtual async Task<Response<DeletedKey>> GetDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new DeletedKey(name), cancellationToken, DeletedKeysPath, name);
        }

        public virtual Response<DeletedKey> DeleteKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return SendRequest(HttpPipelineMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name);
        }

        public virtual async Task<Response<DeletedKey>> DeleteKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return await SendRequestAsync(HttpPipelineMethod.Delete, () => new DeletedKey(name), cancellationToken, KeysPath, name);
        }

        public virtual IEnumerable<Response<DeletedKey>> GetDeletedKeys(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => GetPage(firstPageUri, nextLink, () => new DeletedKey(), cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<DeletedKey>> GetDeletedKeysAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = CreateFirstPageUri(DeletedKeysPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, nextLink, () => new DeletedKey(), cancellationToken));
        }

        public virtual Response PurgeDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return SendRequest(HttpPipelineMethod.Delete, cancellationToken, DeletedKeysPath, name);
        }

        public virtual async Task<Response> PurgeDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return await SendRequestAsync(HttpPipelineMethod.Delete, cancellationToken, DeletedKeysPath, name);
        }

        public virtual Response<Key> RecoverDeletedKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return SendRequest(HttpPipelineMethod.Post, () => new Key(name), cancellationToken, DeletedKeysPath, name, "recover");
        }

        public virtual async Task<Response<Key>> RecoverDeletedKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            return await SendRequestAsync(HttpPipelineMethod.Post, () => new Key(name), cancellationToken, DeletedKeysPath, name, "recover");
        }

        public virtual Response<byte[]> BackupKey(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            var backup = SendRequest(HttpPipelineMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
        }

        public virtual async Task<Response<byte[]>> BackupKeyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            var backup = await SendRequestAsync(HttpPipelineMethod.Post, () => new KeyBackup(), cancellationToken, KeysPath, name, "backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
        }

        public virtual Response<Key> RestoreKey(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return SendRequest(HttpPipelineMethod.Post, new KeyBackup { Value = backup }, () => new Key(), cancellationToken, KeysPath, "restore");
        }

        public virtual async Task<Response<Key>> RestoreKeyAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return await SendRequestAsync(HttpPipelineMethod.Post, new KeyBackup { Value = backup }, () => new Key(), cancellationToken, KeysPath, "restore");
        }

        public virtual Response<Key> ImportKey(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyMaterial == default) throw new ArgumentNullException(nameof(keyMaterial));

            var keyImportOptions = new KeyImportOptions(name, keyMaterial);

            return SendRequest(HttpPipelineMethod.Put, keyImportOptions, () => new Key(name), cancellationToken, KeysPath, name);
        }

        public virtual async Task<Response<Key>> ImportKeyAsync(string name, JsonWebKey keyMaterial, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (keyMaterial == default) throw new ArgumentNullException(nameof(keyMaterial));

            var keyImportOptions = new KeyImportOptions(name, keyMaterial);

            return await SendRequestAsync(HttpPipelineMethod.Put, keyImportOptions, () => new Key(name), cancellationToken, KeysPath, name);
        }

        public virtual Response<Key> ImportKey(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            if (keyImportOptions == default) throw new ArgumentNullException(nameof(keyImportOptions));

            return SendRequest(HttpPipelineMethod.Put, keyImportOptions, () => new Key(keyImportOptions.Name), cancellationToken, KeysPath, keyImportOptions.Name);
        }

        public virtual async Task<Response<Key>> ImportKeyAsync(KeyImportOptions keyImportOptions, CancellationToken cancellationToken = default)
        {
            if (keyImportOptions == default) throw new ArgumentNullException(nameof(keyImportOptions));

            return await SendRequestAsync(HttpPipelineMethod.Put, keyImportOptions, () => new Key(keyImportOptions.Name), cancellationToken, KeysPath, keyImportOptions.Name);
        }
    }
}
