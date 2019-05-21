using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.Keyvault.Keys
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

        public virtual Response<Key> Create(string name, JsonWebKeyType keyType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateAsync(string name, JsonWebKeyType keyType, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }


        public virtual Response<Key> CreateECKey(ECKey ecKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateECKeyAsync(ECKey ecKey, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> CreateRSAKey(RSAKey rsaKey, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> CreateRSAKeyAsync(RSAKey rsaKey, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> Update(KeyBase key, IList<string> keyOps = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> UpdateAsync(KeyBase key, IList<string> keyOps = null, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> Get(string name, string version = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> GetAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
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

        public virtual Response<DeletedKey> Delete(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<DeletedKey>> DeleteAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<DeletedKey>> GetBatchDeletedKeys(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<DeletedKey>> GetBatchDeletedKeysAsync(CancellationToken cancellationToken = default)
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

        public virtual Response<byte[]> Backup(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<byte[]>> BackupAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Key> Restore(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Key>> RestoreAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
