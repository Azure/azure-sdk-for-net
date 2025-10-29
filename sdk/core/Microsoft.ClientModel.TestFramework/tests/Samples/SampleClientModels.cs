// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.Samples;

// Sample client for demonstration purposes
public class SampleClient
{
    private readonly Uri _endpoint;
    private readonly AuthenticationTokenProvider _credential;
    private readonly ClientPipeline _pipeline;

    public SampleClient(Uri endpoint, AuthenticationTokenProvider credential, SampleClientOptions? options = null)
    {
        _endpoint = endpoint;
        _credential = credential;
        options ??= new SampleClientOptions();

        _pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { new ApiKeyAuthenticationPolicy(_credential) },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
    }

    // Virtual methods for sync/async testing
    public virtual ClientResult<SampleData> GetData(string id, CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "GET";
        request.Uri = new Uri($"{_endpoint}/data/{id}");

        _pipeline.Send(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        var data = ModelReaderWriter.Read<SampleData>(response.Content)!;
        return ClientResult.FromValue(data, response);
    }

    public virtual async Task<ClientResult<SampleData>> GetDataAsync(string id, CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "GET";
        request.Uri = new Uri($"{_endpoint}/data/{id}");

        await _pipeline.SendAsync(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        var data = ModelReaderWriter.Read<SampleData>(response.Content)!;
        return ClientResult.FromValue(data, response);
    }

    // Service method takes input data and processes it
    // and returns `ClientResult<T>` holding the processed result
    public virtual ClientResult<SampleData> ProcessData(SampleData input, CancellationToken cancellationToken = default)
    {
        // Create a message that can be sent via the client pipeline.
        using PipelineMessage message = _pipeline.CreateMessage();

        // Modify the request as needed to invoke the service operation.
        PipelineRequest request = message.Request;
        request.Method = "POST";
        request.Uri = new Uri($"{_endpoint}/process");
        request.Headers.Add("Accept", "application/json");

        // Add request body content that will be written using methods
        // defined by the model's implementation of the IJsonModel<T> interface.
        request.Content = BinaryContent.Create(input);

        // Send the message.
        _pipeline.Send(message);

        // Obtain the response from the message Response property.
        PipelineResponse response = message.Response!;

        // If the response is considered an error response, throw an
        // exception that exposes the response details.
        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        // Read the content from the response body and create an instance of
        // a model from it, to include in the type returned by this method.
        SampleData processed = ModelReaderWriter.Read<SampleData>(response.Content)!;

        // Return a ClientResult<T> holding the model instance and the HTTP
        // response details.
        return ClientResult.FromValue(processed, response);
    }

    public virtual async Task<ClientResult<SampleData>> ProcessDataAsync(SampleData input, CancellationToken cancellationToken = default)
    {
        // Create a message that can be sent via the client pipeline.
        using PipelineMessage message = _pipeline.CreateMessage();

        // Modify the request as needed to invoke the service operation.
        PipelineRequest request = message.Request;
        request.Method = "POST";
        request.Uri = new Uri($"{_endpoint}/process");
        request.Headers.Add("Accept", "application/json");

        // Add request body content that will be written using methods
        // defined by the model's implementation of the IJsonModel<T> interface.
        request.Content = BinaryContent.Create(input);

        // Send the message.
        await _pipeline.SendAsync(message);

        // Obtain the response from the message Response property.
        PipelineResponse response = message.Response!;

        // If the response is considered an error response, throw an
        // exception that exposes the response details.
        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        // Read the content from the response body and create an instance of
        // a model from it, to include in the type returned by this method.
        SampleData processed = ModelReaderWriter.Read<SampleData>(response.Content)!;

        // Return a ClientResult<T> holding the model instance and the HTTP
        // response details.
        return ClientResult.FromValue(processed, response);
    }

    public virtual ClientResult<SampleData> AnalyzeData(string dataId, CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "POST";
        request.Uri = new Uri($"{_endpoint}/analyze/{dataId}");
        request.Headers.Add("Accept", "application/json");

        _pipeline.Send(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        var result = ModelReaderWriter.Read<SampleData>(response.Content)!;
        return ClientResult.FromValue(result, response);
    }

    public virtual async Task<ClientResult<SampleData>> AnalyzeDataAsync(string dataId, CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "POST";
        request.Uri = new Uri($"{_endpoint}/analyze/{dataId}");
        request.Headers.Add("Accept", "application/json");

        await _pipeline.SendAsync(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        var result = ModelReaderWriter.Read<SampleData>(response.Content)!;
        return ClientResult.FromValue(result, response);
    }

    // Additional methods for specific samples
    public virtual async Task<ClientResult<SampleData>> GetSecureDataAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "GET";
        request.Uri = new Uri($"{_endpoint}/secure-data");

        await _pipeline.SendAsync(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        var data = ModelReaderWriter.Read<SampleData>(response.Content)!;
        return ClientResult.FromValue(data, response);
    }

    public virtual async Task<ClientResult> HealthCheckAsync(CancellationToken cancellationToken = default)
    {
        using PipelineMessage message = _pipeline.CreateMessage();
        PipelineRequest request = message.Request;
        request.Method = "GET";
        request.Uri = new Uri($"{_endpoint}/health");

        await _pipeline.SendAsync(message);
        PipelineResponse response = message.Response!;

        if (response.IsError)
        {
            throw new ClientResultException(response);
        }

        return ClientResult.FromResponse(response);
    }
}

// Sample client options
public class SampleClientOptions : ClientPipelineOptions
{
    public const string ServiceVersion = "1.0";
}

// Sample data models
public class SampleData : IJsonModel<SampleData>
{
    public string Id { get; set; } = "";
    public bool Success { get; set; }
    public int Value { get; set; }

    SampleData IJsonModel<SampleData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => FromJson(reader);

    SampleData IPersistableModel<SampleData>.Create(BinaryData data, ModelReaderWriterOptions options)
        => FromJson(new Utf8JsonReader(data));

    string IPersistableModel<SampleData>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => options.Format;

    void IJsonModel<SampleData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ToJson(writer);

    BinaryData IPersistableModel<SampleData>.Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options);

    private void ToJson(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("id");
        writer.WriteStringValue(Id);
        writer.WritePropertyName("success");
        writer.WriteBooleanValue(Success);
        writer.WritePropertyName("value");
        writer.WriteNumberValue(Value);
        writer.WriteEndObject();
    }

    private static SampleData FromJson(Utf8JsonReader reader)
    {
        var data = new SampleData();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "id":
                        data.Id = reader.GetString()!;
                        break;
                    case "success":
                        data.Success = reader.GetBoolean();
                        break;
                    case "value":
                        data.Value = reader.GetInt32();
                        break;
                }
            }
        }

        return data;
    }
}

public class SampleResource : IJsonModel<SampleResource>
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Status { get; set; } = "";
    public int Value { get; set; }
    public Dictionary<string, string> Tags { get; set; } = new();

    public SampleResource() { }

    public SampleResource(string id)
    {
        Id = id;
    }

    SampleResource IJsonModel<SampleResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => FromJson(reader);

    SampleResource IPersistableModel<SampleResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        => FromJson(new Utf8JsonReader(data));

    string IPersistableModel<SampleResource>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => options.Format;

    void IJsonModel<SampleResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ToJson(writer);

    BinaryData IPersistableModel<SampleResource>.Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options);

    private void ToJson(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("id");
        writer.WriteStringValue(Id);
        writer.WritePropertyName("name");
        writer.WriteStringValue(Name);
        if (!string.IsNullOrEmpty(Status))
        {
            writer.WritePropertyName("status");
            writer.WriteStringValue(Status);
        }
        writer.WritePropertyName("value");
        writer.WriteNumberValue(Value);
        if (Tags.Count > 0)
        {
            writer.WritePropertyName("tags");
            writer.WriteStartObject();
            foreach (var tag in Tags)
            {
                writer.WritePropertyName(tag.Key);
                writer.WriteStringValue(tag.Value);
            }
            writer.WriteEndObject();
        }
        writer.WriteEndObject();
    }

    private static SampleResource FromJson(Utf8JsonReader reader)
    {
        var resource = new SampleResource();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "id":
                        resource.Id = reader.GetString()!;
                        break;
                    case "name":
                        resource.Name = reader.GetString()!;
                        break;
                    case "status":
                        resource.Status = reader.GetString()!;
                        break;
                    case "value":
                        resource.Value = reader.GetInt32();
                        break;
                    case "tags":
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                        {
                            if (reader.TokenType == JsonTokenType.PropertyName)
                            {
                                var key = reader.GetString()!;
                                reader.Read();
                                var value = reader.GetString()!;
                                resource.Tags[key] = value;
                            }
                        }
                        break;
                }
            }
        }

        return resource;
    }
}

// Simple API key authentication policy for samples
public class ApiKeyAuthenticationPolicy : PipelinePolicy
{
    private readonly AuthenticationTokenProvider _credential;

    public ApiKeyAuthenticationPolicy(AuthenticationTokenProvider credential)
    {
        _credential = credential;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ApplyAuthentication(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        await ApplyAuthenticationAsync(message);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }

    private void ApplyAuthentication(PipelineMessage message)
    {
        var options = new GetTokenOptions(new Dictionary<string, object>
        {
            { GetTokenOptions.ScopesPropertyName, new string[] { "https://example.com/.default" } }
        });
        var token = _credential.GetToken(options, CancellationToken.None);
        message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");
    }

    private async ValueTask ApplyAuthenticationAsync(PipelineMessage message)
    {
        var options = new GetTokenOptions(new Dictionary<string, object>
        {
            { GetTokenOptions.ScopesPropertyName, new string[] { "https://example.com/.default" } }
        });
        var token = await _credential.GetTokenAsync(options, CancellationToken.None);
        message.Request.Headers.Set("Authorization", $"Bearer {token.TokenValue}");
    }
}
