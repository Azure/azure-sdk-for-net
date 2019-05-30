// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Security.KeyVault.Secrets
{
    public class SecretClient
    {
        private readonly Uri _vaultUri;
        private const string ApiVersion = "7.0";
        private readonly HttpPipeline _pipeline;

        private const string SecretsPath = "/secrets/";
        private const string DeletedSecretsPath = "/deletedsecrets/";

        protected SecretClient()
        {

        }
        public SecretClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        public SecretClient(Uri vaultUri, TokenCredential credential, SecretClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));
            options = options ?? new SecretClientOptions();

            _pipeline = HttpPipeline.Build(options,
                    options.ResponseClassifier,
                    options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default"),
                    options.LoggingPolicy,
                    BufferResponsePolicy.Singleton);
        }

        public virtual async Task<Response<Secret>> GetAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, version);
        }

        public virtual Response<Secret> Get(string name, string version = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return SendRequest(HttpPipelineMethod.Get, () => new Secret(), cancellationToken, SecretsPath, name, version);
        }

        public virtual IAsyncEnumerable<Response<SecretBase>> GetAllVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Uri firstPageUri = new Uri(_vaultUri, $"{SecretsPath}{name}/versions?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => this.GetPageAsync(firstPageUri, ()=> new SecretBase(), cancellationToken));
        }

        public virtual IEnumerable<SecretBase> GetAllVersions(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<SecretBase>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, SecretsPath + $"?api-version={ApiVersion}");


            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => this.GetPageAsync(firstPageUri, () => new SecretBase(), cancellationToken));
        }

        public virtual IEnumerable<SecretBase> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<SecretBase>> UpdateAsync(SecretBase secret, CancellationToken cancellationToken = default)
        {
            if (secret?.Name == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Name)}");

            if (secret?.Version == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Version)}");

            return await SendRequestAsync(HttpPipelineMethod.Patch, secret, () => new SecretBase(), cancellationToken, SecretsPath, secret.Name, "/", secret.Version);
        }

        public virtual Response<SecretBase> Update(SecretBase secret, CancellationToken cancellationToken = default)
        {
            if (secret?.Name == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Name)}");

            if (secret?.Version == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Version)}");

            return SendRequest(HttpPipelineMethod.Patch, secret, () => new SecretBase(), cancellationToken, SecretsPath, secret.Name, secret.Version);
        }

        public virtual async Task<Response<Secret>> SetAsync(Secret secret, CancellationToken cancellationToken = default)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            if (secret.Name == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Name)}");

            if (secret.Value == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Value)}");;

            return await SendRequestAsync(HttpPipelineMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name);
        }

        public virtual Response<Secret> Set(Secret secret, CancellationToken cancellationToken = default)
        {
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            if (secret.Name == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Name)}");

            if (secret.Value == null) throw new ArgumentNullException($"{nameof(secret)}.{nameof(secret.Value)}"); ;

            return SendRequest(HttpPipelineMethod.Put, secret, () => new Secret(), cancellationToken, SecretsPath, secret.Name);
        }

        public virtual async Task<Response<Secret>> SetAsync(string name, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            return await SetAsync(new Secret(name, value), cancellationToken);
        }

        public virtual Response<Secret> Set(string name, string value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            return Set(new Secret(name, value), cancellationToken);
        }

        public virtual async Task<Response<DeletedSecret>> DeleteAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
        }

        public virtual Response<DeletedSecret> Delete(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return SendRequest(HttpPipelineMethod.Delete, () => new DeletedSecret(), cancellationToken, SecretsPath, name);
        }

        public virtual async Task<Response<DeletedSecret>> GetDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name);
        }

        public virtual Response<DeletedSecret> GetDeleted(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return SendRequest(HttpPipelineMethod.Get, () => new DeletedSecret(), cancellationToken, DeletedSecretsPath, name);
        }

        public virtual IAsyncEnumerable<Response<DeletedSecret>> GetAllDeletedAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = new Uri(_vaultUri, DeletedSecretsPath + $"?api-version={ApiVersion}");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetPageAsync(firstPageUri, () => new DeletedSecret(), cancellationToken));
        }

        public virtual IEnumerable<DeletedSecret> GetAllDeleted(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Secret>> RecoverDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Post, () => new Secret(), cancellationToken, DeletedSecretsPath, name, "recover");
        }

        public virtual Response<Secret> RecoverDeleted(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return SendRequest(HttpPipelineMethod.Post, () => new Secret(), cancellationToken, DeletedSecretsPath, name, "recover");
        }

        public virtual async Task<Response> PurgeDeletedAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return await SendRequestAsync(HttpPipelineMethod.Delete, cancellationToken, DeletedSecretsPath, name);
        }

        public virtual Response PurgeDeleted(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            return SendRequest(HttpPipelineMethod.Delete, cancellationToken, DeletedSecretsPath, name);
        }

        public virtual async Task<Response<byte[]>> BackupAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            var backup = await SendRequestAsync(HttpPipelineMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "/backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
        }

        public virtual Response<byte[]> Backup(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            var backup = SendRequest(HttpPipelineMethod.Post, () => new VaultBackup(), cancellationToken, SecretsPath, name, "backup");

            return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
        }

        public virtual async Task<Response<SecretBase>> RestoreAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return await SendRequestAsync(HttpPipelineMethod.Post, new VaultBackup { Value = backup }, () => new SecretBase(), cancellationToken, SecretsPath, "/restore");
        }

        public virtual Response<Secret> Restore(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

            return SendRequest(HttpPipelineMethod.Post, new VaultBackup { Value = backup }, () => new Secret(), cancellationToken, SecretsPath, "restore");
        }

        private async Task<Response<TResult>> SendRequestAsync<TContent, TResult>(HttpPipelineMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = await SendRequestAsync(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private Response<TResult> SendRequest<TContent, TResult>(HttpPipelineMethod method, TContent content, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TContent : Model
            where TResult : Model
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, path))
            {
                request.Content = HttpPipelineRequestContent.Create(content.Serialize());

                Response response = SendRequest(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private async Task<Response<TResult>> SendRequestAsync<TResult>(HttpPipelineMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(method, path))
            {
                Response response = await SendRequestAsync(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }

        private Response<TResult> SendRequest<TResult>(HttpPipelineMethod method, Func<TResult> resultFactory, CancellationToken cancellationToken, params string[] path)
            where TResult : Model
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, path))
            {
                Response response = SendRequest(request, cancellationToken);

                return this.CreateResponse(response, resultFactory());
            }
        }
        private async Task<Response> SendRequestAsync(HttpPipelineMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(method, path))
            {
                return await SendRequestAsync(request, cancellationToken);
            }
        }

        private Response SendRequest(HttpPipelineMethod method, CancellationToken cancellationToken, params string[] path)
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, path))
            {
                return SendRequest(request, cancellationToken);
            }
        }

        private async Task<Response> SendRequestAsync(Request request, CancellationToken cancellationToken)
        {
            var response = await _pipeline.SendRequestAsync(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                    return response;
                default:
                    throw await response.CreateRequestFailedExceptionAsync();
            }
        }
        private Response SendRequest(Request request, CancellationToken cancellationToken)
        {
            var response = _pipeline.SendRequest(request, cancellationToken);

            switch (response.Status)
            {
                case 200:
                case 201:
                    return response;
                default:
                    throw response.CreateRequestFailedException();
            }
        }

        private async Task<PageResponse<T>> GetPageAsync<T>(Uri pageUri, Func<T> itemFactory, CancellationToken cancellationToken)
                where T : Model
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, pageUri, addAPIVersion:false))
            {
                Response response = await SendRequestAsync(request, cancellationToken);

                // read the respose
                Page<T> responseAsPage = new Page<T>(itemFactory);
                responseAsPage.Deserialize(response.ContentStream);

                // convert from the Page<T> to PageResponse<T>
                return new PageResponse<T>(responseAsPage.Items.ToArray(), response, responseAsPage.NextLink.ToString());
            }
        }

        private Response<Page<T>> GetPage<T>(Uri pageUri, Func<T> itemFactory, CancellationToken cancellationToken)
            where T : Model
        {
            using (Request request = CreateRequest(HttpPipelineMethod.Get, pageUri))
            {
                Response response = SendRequest(request, cancellationToken);

                return this.CreateResponse(response, new Page<T>(itemFactory));
            }
        }

        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Method = method;
            request.UriBuilder.Uri = uri;

            if (addAPIVersion)
            {
                request.UriBuilder.AppendQuery("api-version", ApiVersion);
            }

            return request;
        }

        private Request CreateRequest(HttpPipelineMethod method, params string[] path)
        {
            Request request = _pipeline.CreateRequest();

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Names.Accept, "application/json");
            request.Method = method;
            request.UriBuilder.Uri = _vaultUri;

            foreach (var p in path)
            {
                request.UriBuilder.AppendPath(p);
            }

            request.UriBuilder.AppendQuery("api-version", ApiVersion);

            return request;
        }

        private Response<T> CreateResponse<T>(Response response, T result)
            where T : Model
        {
            result.Deserialize(response.ContentStream);

            return new Response<T>(response, result);
        }
    }
}
