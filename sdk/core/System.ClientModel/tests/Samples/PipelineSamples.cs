// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.Samples;

public class PipelineSamples
{
    [Test]
    public void CanReadAndWriteSampleResource()
    {
        SampleResource resource = new("123");

        IPersistableModel<SampleResource> persistableModel = resource;
        IJsonModel<SampleResource> jsonModel = resource;

        BinaryData persistableModelData = persistableModel.Write(ModelReaderWriterOptions.Json);
        SampleResource persistableModelResource = persistableModel.Create(persistableModelData, ModelReaderWriterOptions.Json);

        Assert.AreEqual("""{"id":"123"}""", persistableModelData.ToString());
        Assert.AreEqual("123", persistableModelResource.Id);

        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);
        jsonModel.Write(writer, ModelReaderWriterOptions.Json);
        writer.Flush();

        BinaryData jsonModelData = BinaryData.FromBytes(stream.ToArray());
        Utf8JsonReader reader = new(jsonModelData);
        SampleResource jsonModelResource = jsonModel.Create(ref reader, ModelReaderWriterOptions.Json);

        Assert.AreEqual("""{"id":"123"}""", jsonModelData.ToString());
        Assert.AreEqual("123", persistableModelResource.Id);
    }

    #region Snippet:ReadmeSampleClient
    public class SampleClient
    {
        private readonly Uri _endpoint;
        private readonly ApiKeyCredential _credential;
        private readonly ClientPipeline _pipeline;

        public SampleClient(Uri endpoint, ApiKeyCredential credential, SampleClientOptions? options = default)
        {
            options ??= new SampleClientOptions();

            _endpoint = endpoint;
            _credential = credential;

            ApiKeyAuthenticationPolicy authenticationPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);
            _pipeline = ClientPipeline.Create(options,
                perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
                perTryPolicies: new PipelinePolicy[] { authenticationPolicy },
                beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);
        }

        public ClientResult<SampleResource> GetResource(string id)
        {
            PipelineMessage message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

            PipelineRequest request = message.Request;
            request.Method = "GET";
            request.Uri = new Uri("https://www.example.com/");
            request.Headers.Add("Accept", "application/json");

            _pipeline.Send(message);

            PipelineResponse response = message.Response!;

            if (response.IsError)
            {
                throw new ClientResultException(response);
            }

            SampleResource resource = ModelReaderWriter.Read<SampleResource>(response.Content)!;
            return ClientResult.FromValue(resource, response);
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

        private void ToJson(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WriteEndObject();
        }

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
