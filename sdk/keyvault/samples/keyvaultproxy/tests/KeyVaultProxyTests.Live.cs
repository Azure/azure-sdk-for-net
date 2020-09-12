// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Diagnostics;
using Azure.Security.KeyVault.Secrets;
using Xunit;

namespace AzureSamples.Security.KeyVault.Proxy
{
    public partial class KeyVaultProxyTests : IClassFixture<SecretsFixture>, IDisposable
    {
        private readonly SecretsFixture _fixture;
        private readonly AzureEventSourceListener _logger;

        public KeyVaultProxyTests(SecretsFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
            _logger = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
        }

        public void Dispose() => _logger.Dispose();

        [LiveFact]
        public async Task CachesSameResponse(bool isAsync)
        {
            Response<KeyVaultSecret> response;
            if (isAsync)
            {
                response = await _fixture.Client.GetSecretAsync(_fixture.SecretName);
            }
            else
            {
                response = _fixture.Client.GetSecret(_fixture.SecretName);
            }

            string clientRequestId = response.GetRawResponse().ClientRequestId;
            if (isAsync)
            {
                response = await _fixture.Client.GetSecretAsync(_fixture.SecretName);
            }
            else
            {
                response = _fixture.Client.GetSecret(_fixture.SecretName);
            }

            Assert.Equal(clientRequestId, response.GetRawResponse().ClientRequestId);
        }

        [LiveFact]
        public async Task CachesDifferentResponse(bool isAsync)
        {
            string getClientRequestId;
            if (isAsync)
            {
                Response<KeyVaultSecret> response = await _fixture.Client.GetSecretAsync(_fixture.SecretName);
                getClientRequestId = response.GetRawResponse().ClientRequestId;
            }
            else
            {
                Response<KeyVaultSecret> response = _fixture.Client.GetSecret(_fixture.SecretName);
                getClientRequestId = response.GetRawResponse().ClientRequestId;
            }

            string listClientRequestId = null;
            if (isAsync)
            {
                AsyncPageable<SecretProperties> response = _fixture.Client.GetPropertiesOfSecretsAsync();
                await foreach (Page<SecretProperties> page in response.AsPages())
                {
                    listClientRequestId = page.GetRawResponse().ClientRequestId;
                    break;
                }
            }
            else
            {
                Pageable<SecretProperties> response = _fixture.Client.GetPropertiesOfSecrets();
                foreach (Page<SecretProperties> page in response.AsPages())
                {
                    listClientRequestId = page.GetRawResponse().ClientRequestId;
                    break;
                }
            }

            Assert.NotEqual(getClientRequestId, listClientRequestId);
        }

        [LiveFact]
        public async Task RequestsWhenExpired(bool isAsync)
        {
            _fixture.Ttl = TimeSpan.FromMilliseconds(10);

            Response<KeyVaultSecret> response;
            if (isAsync)
            {
                response = await _fixture.Client.GetSecretAsync(_fixture.SecretName);
            }
            else
            {
                response = _fixture.Client.GetSecret(_fixture.SecretName);
            }

            string clientRequestId = response.GetRawResponse().ClientRequestId;
            await Task.Delay(100);

            if (isAsync)
            {
                response = await _fixture.Client.GetSecretAsync(_fixture.SecretName);
            }
            else
            {
                response = _fixture.Client.GetSecret(_fixture.SecretName);
            }

            Assert.NotEqual(clientRequestId, response.GetRawResponse().ClientRequestId);
        }

        [LiveFact(Synchronicity = Synchronicity.Asynchronous)]
        public async Task ConcurrentRequests(bool isAsync)
        {
            List<Task<Response<KeyVaultSecret>>> tasks = new List<Task<Response<KeyVaultSecret>>>(10);
            for (int i = 0; i < tasks.Capacity; ++i)
            {
                Task<Response<KeyVaultSecret>> task = _fixture.Client.GetSecretAsync(_fixture.SecretName);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            string[] clientRequestIds = tasks.Select(task => task.Result.GetRawResponse().ClientRequestId).ToArray();
            Assert.All(clientRequestIds, value => Assert.Equal(clientRequestIds[0], value));
        }
    }
}
