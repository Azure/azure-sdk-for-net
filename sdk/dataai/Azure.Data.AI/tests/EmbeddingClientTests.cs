// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Data.AI.Tests
{
    public class EmbeddingClientTests
    {
        [TestCase(false, "dense")]
        [TestCase(true, "dense")]
        [TestCase(false, "multi")]
        [TestCase(true, "multi")]
        [TestCase(false, "dense_multi")]
        [TestCase(true, "dense_multi")]
        [TestCase(false, "link")]
        [TestCase(true, "link")]
        public async Task OptionsCallsSerializeRequestAndDeserializeResponse(bool async, string kind)
        {
            var options = new MultimodalEmbeddingOptions(new[]
            {
                new EmbeddingContentItem(EmbeddingContentType.Text) { Id = "item-1", Content = "document" }
            })
            {
                Model = "test-model",
                ModelVersion = "v1",
                VectorType = kind == "link" ? EmbeddingVectorType.Dense : new EmbeddingVectorType(kind),
                Dimensions = 2,
                MultiDimensions = kind == "dense_multi" ? 2 : null,
                MaxNumVectors = kind == "multi" || kind == "dense_multi" ? 3 : null,
                OutputDataType = EmbeddingOutputDataType.Float16,
                EncodingFormat = EmbeddingEncodingFormat.Float,
                Delivery = kind == "link" ? EmbeddingDelivery.Link : EmbeddingDelivery.Inline
            };
            using var handler = new EmbeddingHandler(options, kind);
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<MultimodalEmbeddingResult> response = async
                ? await client.MultiModalEmbedAsync(options)
                : client.MultiModalEmbed(options);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            MultimodalEmbeddingResult result = response.Value;
            Assert.That(result.Model, Is.EqualTo("test-model"));
            Assert.That(result.ModelVersion, Is.EqualTo("v1"));
            Assert.That(result.OutputDataType, Is.EqualTo(EmbeddingOutputDataType.Float16));
            if (kind == "link")
            {
                Assert.That(result.Data, Is.Empty);
                Assert.That(result.Output.Uri, Is.EqualTo(new Uri("https://example.blob.core.windows.net/results/output.json")));
                Assert.That(result.Output.SasToken, Is.EqualTo("fake-sas"));
                Assert.That(result.Output.Records, Is.EqualTo(1));
                Assert.That(result.Output.ExpiresOn, Is.EqualTo(new DateTimeOffset(2026, 11, 9, 12, 15, 0, TimeSpan.Zero)));
                return;
            }

            Assert.That(result.Output, Is.Null);
            Assert.That(result.Data, Has.Count.EqualTo(1));
            Assert.That(result.Data[0].Index, Is.EqualTo(0));
            Assert.That(result.Data[0].Id, Is.EqualTo("item-1"));
            switch (kind)
            {
                case "dense":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalDenseEmbedding>());
                    AssertVector(((MultimodalDenseEmbedding)result.Data[0]).Embedding);
                    break;
                case "multi":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalMultiVectorEmbedding>());
                    var multi = (MultimodalMultiVectorEmbedding)result.Data[0];
                    Assert.That(multi.Shape, Is.EqualTo(new[] { 1, 2 }));
                    AssertVector(multi.MultiEmbedding, multiVector: true);
                    break;
                case "dense_multi":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalDenseAndMultiVectorEmbedding>());
                    var combined = (MultimodalDenseAndMultiVectorEmbedding)result.Data[0];
                    Assert.That(combined.Shape, Is.EqualTo(new[] { 1, 2 }));
                    AssertVector(combined.Embedding);
                    AssertVector(combined.MultiEmbedding, multiVector: true);
                    break;
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ConvenienceCallsOmitUnsetOptions(bool async)
        {
            var options = new MultimodalEmbeddingOptions(new[]
            {
                new EmbeddingContentItem(EmbeddingContentType.Text) { Id = "item-1", Content = "document" }
            });
            using var handler = new EmbeddingHandler(options, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<MultimodalEmbeddingResult> response = async
                ? await client.MultiModalEmbedAsync(options.Contents)
                : client.MultiModalEmbed(options.Contents);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data[0], Is.TypeOf<MultimodalDenseEmbedding>());
        }

        [Test]
        public void OptionsRequireContents()
        {
            Assert.Throws<ArgumentNullException>(() => new MultimodalEmbeddingOptions(null));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void OptionsCallsRequireOptions(bool async)
        {
            var client = new InferenceClient(new Uri("https://example.inference.azure.com"), new AzureKeyCredential("api-key"));
            if (async)
            {
                Assert.ThrowsAsync<ArgumentNullException>(() => client.MultiModalEmbedAsync((MultimodalEmbeddingOptions)null));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => client.MultiModalEmbed((MultimodalEmbeddingOptions)null));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void OptionsCallsHonorCancellation(bool async)
        {
            var options = new MultimodalEmbeddingOptions(new[]
            {
                new EmbeddingContentItem(EmbeddingContentType.Text) { Id = "item-1", Content = "document" }
            });
            using var handler = new EmbeddingHandler(options, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            if (async)
            {
                Assert.CatchAsync<OperationCanceledException>(() => client.MultiModalEmbedAsync(options, cancellation.Token));
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => client.MultiModalEmbed(options, cancellation.Token));
            }
        }

        [Test]
        public void ContentUriPreservesUrlWireName()
        {
            var item = new EmbeddingContentItem(EmbeddingContentType.Image)
            {
                Uri = new Uri("https://example.blob.core.windows.net/images/input.png"),
                SasToken = "fake-sas"
            };
            using JsonDocument json = JsonDocument.Parse(
                ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureDataAIContext.Default).ToString());

            Assert.That(json.RootElement.GetProperty("url").GetString(), Is.EqualTo(item.Uri.AbsoluteUri));
            Assert.That(json.RootElement.TryGetProperty("uri", out _), Is.False);
        }

        private static InferenceClient CreateClient(HttpClient httpClient) =>
            new InferenceClient(new Uri("https://example.inference.azure.com"), new AzureKeyCredential("api-key"),
                new InferenceClientOptions { Transport = new HttpClientTransport(httpClient) });

        private static void AssertVector(BinaryData data, bool multiVector = false)
        {
            using JsonDocument json = JsonDocument.Parse(data.ToString());
            JsonElement vector = multiVector ? json.RootElement[0] : json.RootElement;
            Assert.That(vector.GetArrayLength(), Is.EqualTo(2));
            Assert.That(vector[0].GetSingle(), Is.EqualTo(0.25f));
            Assert.That(vector[1].GetSingle(), Is.EqualTo(0.5f));
        }

        private sealed class EmbeddingHandler : HttpMessageHandler
        {
            private readonly MultimodalEmbeddingOptions _options;
            private readonly string _kind;

            public EmbeddingHandler(MultimodalEmbeddingOptions options, string kind)
            {
                _options = options;
                _kind = kind;
            }

            public int RequestCount { get; private set; }

#if NET6_0_OR_GREATER
            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken) =>
                SendAsync(request, cancellationToken).GetAwaiter().GetResult();
#endif

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                RequestCount++;
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
                Assert.That(request.RequestUri.AbsolutePath, Is.EqualTo("/inference/embedding"));
                Assert.That(request.RequestUri.Query, Is.EqualTo("?api-version=2026-11-01-preview"));
                Assert.That(request.Headers.GetValues("Ocp-Apim-Subscription-Key"), Is.EquivalentTo(new[] { "api-key" }));
                Assert.That(request.Content.Headers.ContentType.MediaType, Is.EqualTo("application/json"));
                using JsonDocument json = JsonDocument.Parse(await request.Content.ReadAsStringAsync().ConfigureAwait(false));
                JsonElement body = json.RootElement;
                Assert.That(body.GetProperty("contents").GetArrayLength(), Is.EqualTo(1));
                JsonElement content = body.GetProperty("contents")[0];
                Assert.That(content.GetProperty("type").GetString(), Is.EqualTo("text"));
                Assert.That(content.GetProperty("id").GetString(), Is.EqualTo("item-1"));
                Assert.That(content.GetProperty("content").GetString(), Is.EqualTo("document"));
                var expected = new Dictionary<string, object>
                {
                    ["model"] = _options.Model,
                    ["modelVersion"] = _options.ModelVersion,
                    ["vectorType"] = _options.VectorType?.ToString(),
                    ["dimensions"] = _options.Dimensions,
                    ["multiDimensions"] = _options.MultiDimensions,
                    ["maxNumVectors"] = _options.MaxNumVectors,
                    ["outputDtype"] = _options.OutputDataType?.ToString(),
                    ["encodingFormat"] = _options.EncodingFormat?.ToString(),
                    ["delivery"] = _options.Delivery?.ToString()
                };
                foreach (KeyValuePair<string, object> property in expected)
                {
                    bool present = body.TryGetProperty(property.Key, out JsonElement value);
                    Assert.That(present, Is.EqualTo(property.Value != null), property.Key);
                    if (present)
                    {
                        Assert.That(value.GetRawText(), Is.EqualTo(JsonSerializer.Serialize(property.Value)), property.Key);
                    }
                }
                Assert.That(body.TryGetProperty("outputDataType", out _), Is.False);

                var data = new Dictionary<string, object>
                {
                    ["index"] = 0,
                    ["id"] = "item-1",
                    ["type"] = "text",
                    ["kind"] = _kind
                };
                if (_kind == "dense" || _kind == "dense_multi")
                {
                    data["embedding"] = new[] { 0.25f, 0.5f };
                }
                if (_kind == "multi" || _kind == "dense_multi")
                {
                    data["shape"] = new[] { 1, 2 };
                    data["multiEmbedding"] = new[] { new[] { 0.25f, 0.5f } };
                }
                var response = new Dictionary<string, object>
                {
                    ["object"] = "list",
                    ["model"] = "test-model",
                    ["modelVersion"] = "v1",
                    ["outputDtype"] = "float16",
                    ["data"] = _kind == "link" ? Array.Empty<object>() : new object[] { data },
                    ["usage"] = new { totalTokens = 2 }
                };
                if (_kind == "link")
                {
                    response["output"] = new
                    {
                        id = "0123456789abcdef0123456789abcdef",
                        url = "https://example.blob.core.windows.net/results/output.json",
                        sasToken = "fake-sas",
                        expiresAt = "2026-11-09T12:15:00Z",
                        records = 1,
                        bytes = 100,
                        sha256 = new string('a', 64),
                        contentType = "application/json"
                    };
                }
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonSerializer.Serialize(response))
                };
            }
        }
    }
}
