// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Net.Http;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Mocks
{
    public class MockStringClient : IDisposable
    {
        private ClientPipeline _pipeline;
        private Uri _baseUri;

        protected MockStringClient()
        {
            // only used to generate dynamic proxy for testing
            _pipeline = null!;
            _baseUri = null!;
        }

        public MockStringClient(Uri serviceUri, ClientPipelineOptions? options = null)
        {
            _pipeline = ClientPipeline.Create(options);
            _baseUri = serviceUri ?? throw new ArgumentNullException(nameof(serviceUri));
        }

        public virtual Task<ClientResult> AddAsync(string id, string value, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));
            else if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));

            return SendSyncOrAsync(true, HttpMethod.Post, id, value, token).AsTask();
        }

        public virtual ClientResult Add(string id, string value, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));
            else if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));

            return SendSyncOrAsync(false, HttpMethod.Post, id, value, token).GetAwaiter().GetResult();
        }

        public virtual async Task<ClientResult<string?>> GetAsync(string id, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            try
            {
                ClientResult result = await SendSyncOrAsync(true, HttpMethod.Get, id, null, token)
                        .ConfigureAwait(false);

                var response = result.GetRawResponse();
                return ClientResult.FromOptionalValue<string?>(
                    response.Content.ToObjectFromJson<MockStringRestService.Entry>().data,
                    response);
            }
            catch (ClientResultException ex)
            {
                if (ex.GetRawResponse()?.Status == 404)
                {
                    return ClientResult.FromOptionalValue<string?>(null, ex.GetRawResponse()!);
                }

                throw;
            }
        }

        public virtual ClientResult<string?> Get(string id, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            try
            {
                ClientResult result = SendSyncOrAsync(false, HttpMethod.Get, id, null, token).GetAwaiter().GetResult();
                var response = result.GetRawResponse();
                return ClientResult.FromOptionalValue<string?>(
                    response.Content.ToObjectFromJson<MockStringRestService.Entry>().data,
                    response);
            }
            catch (ClientResultException ex)
            {
                if (ex.GetRawResponse()?.Status == 404)
                {
                    return ClientResult.FromOptionalValue<string?>(null, ex.GetRawResponse()!);
                }

                throw;
            }
        }

        public virtual async Task<ClientResult<bool>> RemoveAsync(string id, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            try
            {
                ClientResult result = await SendSyncOrAsync(true, HttpMethod.Delete, id, null, token);
                return ClientResult.FromValue(true, result.GetRawResponse());
            }
            catch (ClientResultException ex)
            {
                if (ex.GetRawResponse()?.Status == 404)
                {
                    return ClientResult.FromValue(false, ex.GetRawResponse()!);
                }

                throw;
            }
        }

        public virtual ClientResult<bool> Remove(string id, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            try
            {
                ClientResult result = SendSyncOrAsync(false, HttpMethod.Delete, id, null, token).GetAwaiter().GetResult();
                return ClientResult.FromValue(true, result.GetRawResponse());
            }
            catch (ClientResultException ex)
            {
                if (ex.GetRawResponse()?.Status == 404)
                {
                    return ClientResult.FromValue(false, ex.GetRawResponse()!);
                }

                throw;
            }
        }

        public void Dispose()
        {
            // no obvious way to dispose of the pipeline, nor the inner transport
        }

        private async ValueTask<ClientResult> SendSyncOrAsync(bool isAsync, HttpMethod method, string? id, string? value, CancellationToken token)
        {
            UriBuilder builder = new(_baseUri);
            if (id != null)
            {
                builder.Path += id;
            }

            PipelineMessage message = _pipeline.CreateMessage();
            message.Request.Method = method.Method;
            message.Request.Uri = builder.Uri;
            message.Apply(new RequestOptions()
            {
                CancellationToken = token,
                BufferResponse = true
            });

            if (value == null)
            {
                message.Request.Headers.Set("Content-Length", "0");
            }
            else
            {
                using MemoryStream stream = new();
                JsonExtensions.Serialize(stream, value);
                var data = BinaryData.FromBytes(new ReadOnlyMemory<byte>(stream.GetBuffer(), 0, (int)stream.Length));

                message.Request.Headers.Set("Content-Length", stream.Length.ToString(CultureInfo.InvariantCulture));
                message.Request.Headers.Set("Content-Type", "application/json");
                message.Request.Content = BinaryContent.Create(data);
            }

            if (isAsync)
            {
                await _pipeline.SendAsync(message).ConfigureAwait(false);
            }
            else
            {
                _pipeline.Send(message);
            }

            if (message.Response?.IsError == true)
            {
                if (message.Response.Content?.ToMemory().Length > 0)
                {
                    var error = message.Response.Content.ToObjectFromJson<MockStringRestService.Error>();
                    throw new ClientResultException($"Error {error.error}: {error.message}", message.Response);
                }

                throw new ClientResultException(message.Response);
            }

            return ClientResult.FromResponse(message.Response!);
        }
    }
}
