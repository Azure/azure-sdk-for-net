// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System.ClientModel;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// A client for <see cref="MockRestService{TData}"/>.
/// </summary>
/// <typeparam name="TData">The type of data used by the client.</typeparam>
public class MockRestServiceClient<TData> : IDisposable where TData : class
{
    private ClientPipeline _pipeline;
    private Uri _baseUri;

    /// <summary>
    /// Only used to generate a dynamic proxy for testing. Do not use this yourself.
    /// </summary>
    internal MockRestServiceClient()
    {
        _pipeline = null!;
        _baseUri = null!;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MockRestServiceClient{TData}"/> class with the specified service URI and options.
    /// </summary>
    /// <param name="serviceUri">The service URI.</param>
    /// <param name="options">The client pipeline options.</param>
    public MockRestServiceClient(Uri serviceUri, ClientPipelineOptions? options = null)
    {
        _pipeline = ClientPipeline.Create(options);
        _baseUri = serviceUri ?? throw new ArgumentNullException(nameof(serviceUri));
    }

    /// <summary>
    /// Adds data asynchronously to the service with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="data">The data to add.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task<ClientResult> AddAsync(string id, TData data, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        ValidateData(data);
        return SendSyncOrAsync(true, HttpMethod.Post, id, data, token).AsTask();
    }

    /// <summary>
    /// Adds data synchronously to the service with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="data">The data to add.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    public virtual ClientResult Add(string id, TData data, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        ValidateData(data);
        return SendSyncOrAsync(false, HttpMethod.Post, id, data, token).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Gets data asynchronously from the service with the specified ID. Will return null if the data does not exist.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task<ClientResult<TData?>> GetAsync(string id, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        try
        {
            ClientResult result = await SendSyncOrAsync(true, HttpMethod.Get, id, default, token)
                .ConfigureAwait(false);

            PipelineResponse response = result.GetRawResponse();
            return ClientResult.FromOptionalValue(
                response.Content?.ToObjectFromJson<MockRestService<TData>.Entry>()?.data,
                response);
        }
        catch (ClientResultException ex)
        {
            if (ex.GetRawResponse()?.Status == 404)
            {
                return ClientResult.FromOptionalValue<TData>(default, ex.GetRawResponse()!);
            }

            throw;
        }
    }

    /// <summary>
    /// Gets data synchronously from the service with the specified ID. Will return null if the data does not exist.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    public virtual ClientResult<TData?> Get(string id, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        try
        {
            ClientResult result = SendSyncOrAsync(false, HttpMethod.Get, id, default, token).GetAwaiter().GetResult();
            PipelineResponse response = result.GetRawResponse();
            return ClientResult.FromOptionalValue(
                response.Content?.ToObjectFromJson<MockRestService<TData>.Entry>()?.data,
                response);
        }
        catch (ClientResultException ex)
        {
            if (ex.GetRawResponse()?.Status == 404)
            {
                return ClientResult.FromOptionalValue<TData?>(default, ex.GetRawResponse()!);
            }

            throw;
        }
    }

    /// <summary>
    /// Removes data asynchronously from the service with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual async Task<ClientResult<bool>> RemoveAsync(string id, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        try
        {
            ClientResult result = await SendSyncOrAsync(true, HttpMethod.Delete, id, default, token);
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

    /// <summary>
    /// Removes data synchronously from the service with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the data.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    public virtual ClientResult<bool> Remove(string id, CancellationToken token = default)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

        try
        {
            ClientResult result = SendSyncOrAsync(false, HttpMethod.Delete, id, default, token).GetAwaiter().GetResult();
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

    /// <summary>
    /// Disposes of the resources used by the client.
    /// </summary>
    public virtual void Dispose()
    {
        // no obvious way to dispose of the pipeline, nor the inner transport
    }

    /// <summary>
    /// Validates the data before sending it to the service.
    /// </summary>
    /// <param name="data">The data to validate.</param>
    protected virtual void ValidateData(TData? data)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }
    }

    /// <summary>
    /// Sends the request to the service synchronously or asynchronously. This will serialize the passed in data to JSON using the default
    /// serializer.
    /// </summary>
    /// <param name="isAsync">Indicates whether the request should be sent asynchronously.</param>
    /// <param name="method">The HTTP method.</param>
    /// <param name="id">The ID of the data.</param>
    /// <param name="data">The data to send.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    protected async ValueTask<ClientResult> SendSyncOrAsync(bool isAsync, HttpMethod method, string? id, TData? data, CancellationToken token)
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

        if (data == null)
        {
            message.Request.Headers.Set("Content-Length", "0");
        }
        else
        {
            using MemoryStream stream = new();
            JsonSerializer.Serialize(stream, data);
            var binaryData = BinaryData.FromBytes(new ReadOnlyMemory<byte>(stream.GetBuffer(), 0, (int)stream.Length));

            message.Request.Headers.Set("Content-Length", stream.Length.ToString(CultureInfo.InvariantCulture));
            message.Request.Headers.Set("Content-Type", "application/json");
            message.Request.Content = BinaryContent.Create(binaryData);
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
                var error = message.Response.Content.ToObjectFromJson<MockRestService<TData>.Error>();
                throw new ClientResultException($"Error {error?.error}: {error?.message}", message.Response);
            }

            throw new ClientResultException(message.Response);
        }

        return ClientResult.FromResponse(message.Response!);
    }
}
