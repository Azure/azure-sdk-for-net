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
        public async Task FlattenedCallsSerializeRequestAndDeserializeResponse(bool async, string kind)
        {
            var contents = new[] { new EmbeddingContentItem(EmbeddingContentKind.Text) { Id = "item-1", Content = "document" } };
            EmbeddingVectorKind vectorKind = kind == "link" ? EmbeddingVectorKind.Dense : new EmbeddingVectorKind(kind);
            int? multiDimensions = kind == "dense_multi" ? 2 : null;
            int? maxVectorCount = kind == "multi" || kind == "dense_multi" ? 3 : null;
            EmbeddingDelivery delivery = kind == "link" ? EmbeddingDelivery.Link : EmbeddingDelivery.Inline;
            using var handler = new EmbeddingHandler(contents, kind, new Dictionary<string, object>
            {
                ["model"] = "test-model",
                ["modelVersion"] = "v1",
                ["vectorKind"] = vectorKind.ToString(),
                ["dimensions"] = 2,
                ["multiDimensions"] = multiDimensions,
                ["maxNumVectors"] = maxVectorCount,
                ["outputDataKind"] = "float16",
                ["encodingFormat"] = "float",
                ["delivery"] = delivery.ToString()
            });
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<MultimodalEmbeddingResult> response = async
                ? await client.GetMultimodalEmbeddingsAsync(contents, model: "test-model", modelVersion: "v1",
                    vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                    maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                    encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery)
                : client.GetMultimodalEmbeddings(contents, model: "test-model", modelVersion: "v1",
                    vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                    maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                    encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            MultimodalEmbeddingResult result = response.Value;
            Assert.That(result.Model, Is.EqualTo("test-model"));
            Assert.That(result.ModelVersion, Is.EqualTo("v1"));
            Assert.That(result.OutputDataKind, Is.EqualTo(EmbeddingOutputDataKind.Float16));
            if (kind == "link")
            {
                Assert.That(result.Data, Is.Empty);
                Assert.That(result.Output.Uri, Is.EqualTo(new Uri("https://example.blob.core.windows.net/results/output.json")));
                Assert.That(result.Output.SasToken, Is.EqualTo("fake-sas"));
                Assert.That(result.Output.RecordCount, Is.EqualTo(1));
                Assert.That(result.Output.SizeInBytes, Is.EqualTo(100));
                Assert.That(result.Output.ExpiresOn, Is.EqualTo(new DateTimeOffset(2026, 11, 9, 12, 15, 0, TimeSpan.Zero)));
                return;
            }

            Assert.That(result.Output, Is.Null);
            Assert.That(result.Data, Has.Count.EqualTo(1));
            Assert.That(result.Data[0].Index, Is.EqualTo(0));
            Assert.That(result.Data[0].Id, Is.EqualTo("item-1"));
            Assert.That(result.Data[0].ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
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
            var contents = new[]
            {
                new EmbeddingContentItem(EmbeddingContentKind.Text) { Id = "item-1", Content = "document" }
            };
            using var handler = new EmbeddingHandler(contents, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<MultimodalEmbeddingResult> response = async
                ? await client.GetMultimodalEmbeddingsAsync(contents)
                : client.GetMultimodalEmbeddings(contents);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data[0], Is.TypeOf<MultimodalDenseEmbedding>());
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task FlattenedCallsAcceptTextAndImageContents(bool async)
        {
            var contents = new[]
            {
                new EmbeddingContentItem(EmbeddingContentKind.Text) { Id = "item-1", Content = "document" },
                new EmbeddingContentItem(EmbeddingContentKind.Image)
                {
                    Id = "item-2",
                    Uri = new Uri("https://example.blob.core.windows.net/images/input.png"),
                    SasToken = "fake-sas"
                }
            };
            using var handler = new EmbeddingHandler(contents, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<MultimodalEmbeddingResult> response = async
                ? await client.GetMultimodalEmbeddingsAsync(contents)
                : client.GetMultimodalEmbeddings(contents);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data, Has.Count.EqualTo(2));
            Assert.That(response.Value.Data[0].ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
            Assert.That(response.Value.Data[1].ContentKind, Is.EqualTo(EmbeddingContentKind.Image));
            Assert.That(response.Value.Data[1], Is.TypeOf<MultimodalDenseEmbedding>());
        }

        [Test]
        public void WarningCodeNumberPreservesNumberWireName()
        {
            var warning = InferenceModelFactory.MultimodalEmbeddingWarning(
                code: EmbeddingWarningCode.InputTruncated, codeNumber: 1001);
            BinaryData serialized = ModelReaderWriter.Write(warning, ModelReaderWriterOptions.Json, AzureDataAIContext.Default);
            using JsonDocument json = JsonDocument.Parse(serialized.ToString());
            Assert.That(json.RootElement.GetProperty("number").GetInt32(), Is.EqualTo(1001));
            Assert.That(json.RootElement.TryGetProperty("codeNumber", out _), Is.False);
            var roundTrip = ModelReaderWriter.Read<MultimodalEmbeddingWarning>(
                serialized, ModelReaderWriterOptions.Json, AzureDataAIContext.Default);
            Assert.That(roundTrip.CodeNumber, Is.EqualTo(1001));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedCallsRequireContents(bool async)
        {
            var client = new InferenceClient(new Uri("https://example.inference.azure.com"), new AzureKeyCredential("api-key"));
            if (async)
            {
                Assert.ThrowsAsync<ArgumentNullException>(() => client.GetMultimodalEmbeddingsAsync((IEnumerable<EmbeddingContentItem>)null));
            }
            else
            {
                Assert.Throws<ArgumentNullException>(() => client.GetMultimodalEmbeddings((IEnumerable<EmbeddingContentItem>)null));
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedCallsHonorCancellation(bool async)
        {
            var contents = new[]
            {
                new EmbeddingContentItem(EmbeddingContentKind.Text) { Id = "item-1", Content = "document" }
            };
            using var handler = new EmbeddingHandler(contents, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            if (async)
            {
                Assert.CatchAsync<OperationCanceledException>(() => client.GetMultimodalEmbeddingsAsync(contents, cancellationToken: cancellation.Token));
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => client.GetMultimodalEmbeddings(contents, cancellationToken: cancellation.Token));
            }
        }

        [Test]
        public void ContentUriPreservesUrlWireName()
        {
            var item = new EmbeddingContentItem(EmbeddingContentKind.Image)
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
            private readonly IReadOnlyList<EmbeddingContentItem> _contents;
            private readonly IReadOnlyDictionary<string, object> _expectedOptions;
            private readonly string _kind;

            public EmbeddingHandler(IReadOnlyList<EmbeddingContentItem> contents, string kind,
                IReadOnlyDictionary<string, object> expectedOptions = null)
            {
                _contents = contents;
                _expectedOptions = expectedOptions ?? new Dictionary<string, object>();
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
                Assert.That(body.GetProperty("contents").GetArrayLength(), Is.EqualTo(_contents.Count));
                JsonElement content = body.GetProperty("contents")[0];
                Assert.That(content.GetProperty("kind").GetString(), Is.EqualTo("text"));
                Assert.That(content.TryGetProperty("type", out _), Is.False);
                Assert.That(content.GetProperty("id").GetString(), Is.EqualTo("item-1"));
                Assert.That(content.GetProperty("content").GetString(), Is.EqualTo("document"));
                if (_contents.Count == 2)
                {
                    JsonElement image = body.GetProperty("contents")[1];
                    Assert.That(image.GetProperty("kind").GetString(), Is.EqualTo("image"));
                    Assert.That(image.GetProperty("url").GetString(), Is.EqualTo(_contents[1].Uri.AbsoluteUri));
                    Assert.That(image.GetProperty("sasToken").GetString(), Is.EqualTo("fake-sas"));
                    Assert.That(image.TryGetProperty("uri", out _), Is.False);
                    Assert.That(image.TryGetProperty("type", out _), Is.False);
                }
                foreach (string property in new[]
                {
                    "model", "modelVersion", "vectorKind", "dimensions", "multiDimensions",
                    "maxNumVectors", "outputDataKind", "encodingFormat", "delivery"
                })
                {
                    _expectedOptions.TryGetValue(property, out object expected);
                    bool present = body.TryGetProperty(property, out JsonElement value);
                    Assert.That(present, Is.EqualTo(expected != null), property);
                    if (present)
                    {
                        Assert.That(value.GetRawText(), Is.EqualTo(JsonSerializer.Serialize(expected)), property);
                    }
                }
                Assert.That(body.TryGetProperty("outputDataType", out _), Is.False);
                Assert.That(body.TryGetProperty("outputDtype", out _), Is.False);
                Assert.That(body.TryGetProperty("vectorType", out _), Is.False);
                Assert.That(body.TryGetProperty("maxVectorCount", out _), Is.False);

                var data = new Dictionary<string, object>
                {
                    ["index"] = 0,
                    ["id"] = "item-1",
                    ["contentKind"] = "text",
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
                var responseData = new List<object>();
                if (_kind != "link")
                {
                    responseData.Add(data);
                    if (_contents.Count == 2)
                    {
                        responseData.Add(new
                        {
                            index = 1,
                            id = "item-2",
                            contentKind = "image",
                            kind = "dense",
                            embedding = new[] { 0.25f, 0.5f }
                        });
                    }
                }
                var response = new Dictionary<string, object>
                {
                    ["object"] = "list",
                    ["model"] = "test-model",
                    ["modelVersion"] = "v1",
                    ["outputDataKind"] = "float16",
                    ["data"] = responseData,
                    ["usage"] = new { totalTokens = 2, imageCount = _contents.Count - 1 }
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
                        sizeInBytes = 100,
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
