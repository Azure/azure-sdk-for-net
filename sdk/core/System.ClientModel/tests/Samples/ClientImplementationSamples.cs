// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class ClientImplementationSamples
{
    [Test]
    public void CanReadAndWriteSampleResource()
    {
        SampleResource resource = new("123");

        IPersistableModel<SampleResource> persistableModel = resource;
        IJsonModel<SampleResource> jsonModel = resource;

        BinaryData persistableModelData = persistableModel.Write(ModelReaderWriterOptions.Json);
        SampleResource? persistableModelResource = persistableModel.Create(persistableModelData, ModelReaderWriterOptions.Json);

        Assert.AreEqual("""{"id":"123"}""", persistableModelData.ToString());
        Assert.AreEqual("123", persistableModelResource?.Id);

        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);
        jsonModel.Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();

        BinaryData jsonModelData = BinaryData.FromBytes(stream.ToArray());
        Utf8JsonReader reader = new(jsonModelData);
        SampleResource? jsonModelResource = jsonModel.Create(ref reader, ModelReaderWriterOptions.Json);

        Assert.AreEqual("""{"id":"123"}""", jsonModelData.ToString());
        Assert.AreEqual("123", jsonModelResource?.Id);
    }

    [Test]
    public void ClientStatusCodeClassifier()
    {
        ClientPipeline _pipeline = ClientPipeline.Create();

        #region Snippet:ClientStatusCodeClassifier
        // Create a message that can be sent via the client pipeline.
        PipelineMessage message = _pipeline.CreateMessage();

        // Set a classifier that will categorize only responses with status codes
        // indicating success for the service operation as non-error responses.
        message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 202 });
        #endregion
    }

    #region Snippet:ReadmeSampleClient
    public class SampleClient
    {
        private readonly Uri _endpoint;
        private readonly ApiKeyCredential _credential;
        private readonly ClientPipeline _pipeline;

        // Constructor takes service endpoint, credential used to authenticate
        // with the service, and options for configuring the client pipeline.
        public SampleClient(Uri endpoint, ApiKeyCredential credential, SampleClientOptions? options = default)
        {
            // Default options are used if none are passed by the client's user.
            options ??= new SampleClientOptions();

            _endpoint = endpoint;
            _credential = credential;

            // Authentication policy instance is created from the user-provided
            // credential and service authentication scheme.
            ApiKeyAuthenticationPolicy authenticationPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);

            // Pipeline is created from user-provided options and policies
            // specific to the service client implementation.
            _pipeline = ClientPipeline.Create(options,
                perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
                perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
                beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        // Service method takes an input model representing a service resource
        // and returns `ClientResult<T>` holding an output model representing
        // the value returned in the service response.
        public ClientResult<SampleResource> UpdateResource(SampleResource resource)
        {
            // Create a message that can be sent via the client pipeline.
            using PipelineMessage message = _pipeline.CreateMessage();

            // Modify the request as needed to invoke the service operation.
            PipelineRequest request = message.Request;
            request.Method = "PATCH";
            request.Uri = new Uri($"https://www.example.com/update?id={resource.Id}");
            request.Headers.Add("Accept", "application/json");

            // Add request body content that will be written using methods
            // defined by the model's implementation of the IJsonModel<T> interface.
            request.Content = BinaryContent.Create(resource);

            // Send the message.
            _pipeline.Send(message);

            // Obtain the response from the message Response property.
            // The PipelineTransport ensures that the Response value is set
            // so that every policy in the pipeline can access the property.
            PipelineResponse response = message.Response!;

            // If the response is considered an error response, throw an
            // exception that exposes the response details.
            if (response.IsError)
            {
                throw new ClientResultException(response);
            }

            // Read the content from the response body and create an instance of
            // a model from it, to include in the type returned by this method.
            SampleResource updated = ModelReaderWriter.Read<SampleResource>(response.Content)!;

            // Return a ClientResult<T> holding the model instance and the HTTP
            // response details.
            return ClientResult.FromValue(updated, response);
        }
    }
    #endregion

    public class SampleClientOptions : ClientPipelineOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1;

        internal string Version { get; }

        public enum ServiceVersion
        {
            V1 = 1
        }

        public SampleClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }

    #region Snippet:ReadmeSampleModel
    public class SampleResource : IJsonModel<SampleResource>
    {
        public SampleResource(string id)
        {
            Id = id;
        }

        public string Id { get; init; }

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

        // Write the model JSON that will populate the HTTP request content.
        private void ToJson(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WriteEndObject();
        }

        // Read the JSON response content and create a model instance from it.
        private static SampleResource FromJson(Utf8JsonReader reader)
        {
            reader.Read(); // start object
            reader.Read(); // property name
            reader.Read(); // id value

            return new SampleResource(reader.GetString()!);
        }
    }
    #endregion
}
