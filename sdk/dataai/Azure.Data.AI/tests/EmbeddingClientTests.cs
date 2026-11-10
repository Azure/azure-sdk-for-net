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
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Data.AI.Tests
{
    public class EmbeddingClientTests
    {
        [TestCase(false, "dense", false)]
        [TestCase(true, "dense", false)]
        [TestCase(false, "multi", false)]
        [TestCase(true, "multi", false)]
        [TestCase(false, "dense_multi", false)]
        [TestCase(true, "dense_multi", false)]
        [TestCase(false, "link", false)]
        [TestCase(true, "link", false)]
        [TestCase(false, "dense", true)]
        [TestCase(true, "dense", true)]
        [TestCase(false, "multi", true)]
        [TestCase(true, "multi", true)]
        [TestCase(false, "dense_multi", true)]
        [TestCase(true, "dense_multi", true)]
        [TestCase(false, "link", true)]
        [TestCase(true, "link", true)]
        public async Task FlattenedCallsSerializeRequestAndDeserializeResponse(bool async, string kind, bool anonymous)
        {
            var contents = new[] { new EmbeddingsInputContent { Kind = EmbeddingContentKind.Text, Id = "item-1", Content = "document" } };
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
                ["maxVectorCount"] = maxVectorCount,
                ["outputDataKind"] = "float16",
                ["encodingFormat"] = "float",
                ["delivery"] = delivery.ToString()
            });
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<EmbeddingResult> response;
            if (anonymous)
            {
                var inputs = new object[] { new { kind = "text", id = "item-1", content = "document" } };
                response = async
                    ? await client.GetEmbeddingsAsync(inputs, model: "test-model", modelVersion: "v1",
                        vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                        maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                        encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery)
                    : client.GetEmbeddings(inputs, model: "test-model", modelVersion: "v1",
                        vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                        maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                        encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery);
            }
            else
            {
                response = async
                    ? await client.GetEmbeddingsAsync(contents, model: "test-model", modelVersion: "v1",
                        vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                        maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                        encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery)
                    : client.GetEmbeddings(contents, model: "test-model", modelVersion: "v1",
                        vectorKind: vectorKind, dimensions: 2, multiDimensions: multiDimensions,
                        maxVectorCount: maxVectorCount, outputDataKind: EmbeddingOutputDataKind.Float16,
                        encodingFormat: EmbeddingEncodingFormat.Float, delivery: delivery);
            }

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            EmbeddingResult result = response.Value;
            Assert.That(result.Model, Is.EqualTo("test-model"));
            Assert.That(result.ModelVersion, Is.EqualTo("v1"));
            Assert.That(result.OutputDataKind, Is.EqualTo(EmbeddingOutputDataKind.Float16));
            Assert.That(result.Usage, Is.TypeOf<MultimodalEmbeddingUsage>());
            using JsonDocument resultJson = JsonDocument.Parse(
                ModelReaderWriter.Write(result, ModelReaderWriterOptions.Json, AzureDataAIContext.Default).ToString());
            Assert.That(resultJson.RootElement.GetProperty("usage").GetProperty("kind").GetString(), Is.EqualTo("multimodal"));
            Assert.That(result.Usage.TotalTokens, Is.EqualTo(2));
            Assert.That(((MultimodalEmbeddingUsage)result.Usage).ImageCount, Is.EqualTo(contents.Length - 1));
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
            Assert.That(resultJson.RootElement.GetProperty("data")[0].GetProperty("kind").GetString(), Is.EqualTo("multimodal_" + kind));
            switch (kind)
            {
                case "dense":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalDenseEmbedding>());
                    Assert.That(((MultimodalDenseEmbedding)result.Data[0]).ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
                    Assert.That(((MultimodalDenseEmbedding)result.Data[0]).VectorKind, Is.EqualTo(EmbeddingVectorKind.Dense));
                    AssertVector(((MultimodalDenseEmbedding)result.Data[0]).Embedding);
                    break;
                case "multi":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalMultiVectorEmbedding>());
                    var multi = (MultimodalMultiVectorEmbedding)result.Data[0];
                    Assert.That(multi.ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
                    Assert.That(multi.VectorKind, Is.EqualTo(EmbeddingVectorKind.Multi));
                    Assert.That(multi.Shape, Is.EqualTo(new[] { 1, 2 }));
                    AssertVector(multi.MultiEmbedding, multiVector: true);
                    break;
                case "dense_multi":
                    Assert.That(result.Data[0], Is.TypeOf<MultimodalDenseAndMultiVectorEmbedding>());
                    var combined = (MultimodalDenseAndMultiVectorEmbedding)result.Data[0];
                    Assert.That(combined.ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
                    Assert.That(combined.VectorKind, Is.EqualTo(EmbeddingVectorKind.DenseAndMulti));
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
                new EmbeddingsInputContent { Id = "item-1", Content = "document" }
            };
            using var handler = new EmbeddingHandler(contents, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<EmbeddingResult> response = async
                ? await client.GetEmbeddingsAsync(contents)
                : client.GetEmbeddings(contents);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data[0], Is.TypeOf<MultimodalDenseEmbedding>());
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task FlattenedCallsAcceptTextAndImageInputs(bool async)
        {
            var contents = new[]
            {
                new EmbeddingsInputContent { Id = "item-1", Content = "document" },
                new EmbeddingsInputContent
                {
                    Kind = EmbeddingContentKind.Image,
                    Id = "item-2",
                    Uri = new Uri("https://example.blob.core.windows.net/images/input.png"),
                    SasToken = "fake-sas"
                }
            };
            using var handler = new EmbeddingHandler(contents, "dense", new Dictionary<string, object>
            {
                ["vectorKind"] = "dense",
                ["outputDataKind"] = "float32",
                ["encodingFormat"] = "float",
                ["delivery"] = "inline"
            }, useTokenCredential: true);
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient, useTokenCredential: true);

            Response<EmbeddingResult> response = async
                ? await client.GetEmbeddingsAsync(inputs: contents,
                    vectorKind: EmbeddingVectorKind.Dense, outputDataKind: EmbeddingOutputDataKind.Float32,
                    encodingFormat: EmbeddingEncodingFormat.Float, delivery: EmbeddingDelivery.Inline)
                : client.GetEmbeddings(inputs: contents,
                    vectorKind: EmbeddingVectorKind.Dense, outputDataKind: EmbeddingOutputDataKind.Float32,
                    encodingFormat: EmbeddingEncodingFormat.Float, delivery: EmbeddingDelivery.Inline);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data, Has.Count.EqualTo(2));
            Assert.That(((MultimodalDenseEmbedding)response.Value.Data[0]).ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
            Assert.That(((MultimodalDenseEmbedding)response.Value.Data[1]).ContentKind, Is.EqualTo(EmbeddingContentKind.Image));
            Assert.That(response.Value.Data[1], Is.TypeOf<MultimodalDenseEmbedding>());
        }

        [TestCase(false, 2560, false)]
        [TestCase(true, 2560, false)]
        [TestCase(false, null, false)]
        [TestCase(true, null, false)]
        [TestCase(false, 2560, true)]
        [TestCase(true, 2560, true)]
        [TestCase(false, null, true)]
        [TestCase(true, null, true)]
        public async Task FlattenedCallsAcceptQueryAndImageWithModelSettings(bool async, int? dimensions, bool anonymous)
        {
            var contents = new[]
            {
                new EmbeddingsInputContent
                {
                    Kind = EmbeddingContentKind.Query,
                    Id = "map-question",
                    Content = "Which walking route follows the lake?"
                },
                new EmbeddingsInputContent
                {
                    Kind = EmbeddingContentKind.Image,
                    Id = "trail-map",
                    Uri = new Uri("https://example.blob.core.windows.net/images/trail.png"),
                    SasToken = "fake-sas"
                }
            };
            using var handler = new EmbeddingHandler(contents, "dense", new Dictionary<string, object>
            {
                ["model"] = "microsoft-embedding-1-large",
                ["modelVersion"] = "test-model-version",
                ["dimensions"] = dimensions,
                ["delivery"] = "inline"
            }, useTokenCredential: true);
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient, useTokenCredential: true);

            Response<EmbeddingResult> response;
            if (anonymous)
            {
                response = async
                    ? await client.GetEmbeddingsAsync(
                        inputs: new object[]
                        {
                            new { id = "map-question", kind = "query", content = "Which walking route follows the lake?" },
                            new { id = "trail-map", kind = "image", url = contents[1].Uri.AbsoluteUri, sasToken = "fake-sas" }
                        },
                        model: "microsoft-embedding-1-large",
                        modelVersion: "test-model-version",
                        dimensions: dimensions,
                        delivery: EmbeddingDelivery.Inline)
                    : client.GetEmbeddings(
                        inputs: new object[]
                        {
                            new { id = "map-question", kind = "query", content = "Which walking route follows the lake?" },
                            new { id = "trail-map", kind = "image", url = contents[1].Uri.AbsoluteUri, sasToken = "fake-sas" }
                        },
                        model: "microsoft-embedding-1-large",
                        modelVersion: "test-model-version",
                        dimensions: dimensions,
                        delivery: EmbeddingDelivery.Inline);
            }
            else
            {
                response = async
                    ? await client.GetEmbeddingsAsync(
                        inputs: contents,
                        model: "microsoft-embedding-1-large",
                        modelVersion: "test-model-version",
                        dimensions: dimensions,
                        delivery: EmbeddingDelivery.Inline)
                    : client.GetEmbeddings(
                        inputs: contents,
                        model: "microsoft-embedding-1-large",
                        modelVersion: "test-model-version",
                        dimensions: dimensions,
                        delivery: EmbeddingDelivery.Inline);
            }

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Model, Is.EqualTo("microsoft-embedding-1-large"));
            Assert.That(response.Value.ModelVersion, Is.EqualTo("test-model-version"));
            Assert.That(response.Value.Output, Is.Null);
            Assert.That(response.Value.Data, Has.Count.EqualTo(2));
            for (int index = 0; index < contents.Length; index++)
            {
                var item = (MultimodalDenseEmbedding)response.Value.Data[index];
                Assert.That(item.Index, Is.EqualTo(index));
                Assert.That(item.Id, Is.EqualTo(contents[index].Id));
                Assert.That(item.ContentKind, Is.EqualTo(contents[index].Kind));
                Assert.That(item, Is.TypeOf<MultimodalDenseEmbedding>());
                AssertVector(((MultimodalDenseEmbedding)item).Embedding, dimensions: dimensions ?? 2);
            }
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task ObjectCallsAcceptDictionaryOrJsonAndTypedItems(bool async, bool jsonElement)
        {
            var query = new Dictionary<string, object>
            {
                ["id"] = "item-1",
                ["kind"] = "query",
                ["content"] = "document"
            };
            using JsonDocument json = JsonDocument.Parse(BinaryData.FromObjectAsJson(query));
            var expected = new[]
            {
                new EmbeddingsInputContent { Kind = EmbeddingContentKind.Query, Id = "item-1", Content = "document" },
                new EmbeddingsInputContent
                {
                    Kind = EmbeddingContentKind.Image,
                    Id = "item-2",
                    Uri = new Uri("https://example.blob.core.windows.net/images/input.png"),
                    SasToken = "fake-sas"
                }
            };
            var contents = new object[] { jsonElement ? (object)json.RootElement : query, expected[1] };
            using var handler = new EmbeddingHandler(expected, "dense", useTokenCredential: true);
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient, useTokenCredential: true);

            Response<EmbeddingResult> response = async
                ? await client.GetEmbeddingsAsync(contents)
                : client.GetEmbeddings(contents);

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(response.Value.Data, Has.Count.EqualTo(2));
            Assert.That(((MultimodalDenseEmbedding)response.Value.Data[0]).ContentKind, Is.EqualTo(EmbeddingContentKind.Query));
            Assert.That(((MultimodalDenseEmbedding)response.Value.Data[1]).ContentKind, Is.EqualTo(EmbeddingContentKind.Image));
        }

        [TestCase(false, "anonymous")]
        [TestCase(true, "anonymous")]
        [TestCase(false, "dictionary")]
        [TestCase(true, "dictionary")]
        [TestCase(false, "json")]
        [TestCase(true, "json")]
        public async Task ObjectCallsDefaultOmittedKindToText(bool async, string inputKind)
        {
            var text = new { id = "item-1", content = "document" };
            using JsonDocument json = JsonDocument.Parse(BinaryData.FromObjectAsJson(text));
            object input = inputKind == "json" ? json.RootElement
                : inputKind == "dictionary" ? new Dictionary<string, object> { ["id"] = text.id, ["content"] = text.content }
                : text;
            var expected = new[] { new EmbeddingsInputContent { Id = text.id, Content = text.content } };
            using var handler = new EmbeddingHandler(expected, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Response<EmbeddingResult> response = async
                ? await client.GetEmbeddingsAsync(new[] { input })
                : client.GetEmbeddings(new[] { input });

            Assert.That(handler.RequestCount, Is.EqualTo(1));
            Assert.That(((MultimodalDenseEmbedding)response.Value.Data[0]).ContentKind, Is.EqualTo(EmbeddingContentKind.Text));
        }

        [TestCaseSource(nameof(InvalidAnonymousInputs))]
        public void ObjectCallsRejectInvalidInputsBeforeSending(bool async, object[] inputs, Type exceptionType)
        {
            using var handler = new EmbeddingHandler(Array.Empty<EmbeddingsInputContent>(), "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);

            Exception error = async
                ? Assert.ThrowsAsync(exceptionType, () => client.GetEmbeddingsAsync(inputs: inputs))
                : Assert.Throws(exceptionType, () => client.GetEmbeddings(inputs: inputs));

            Assert.That(((ArgumentException)error).ParamName, Is.EqualTo("inputs"));
            Assert.That(handler.RequestCount, Is.Zero);
        }

        private static IEnumerable<TestCaseData> InvalidAnonymousInputs()
        {
            foreach (bool async in new[] { false, true })
            {
                yield return new TestCaseData(async, null, typeof(ArgumentNullException));
                yield return new TestCaseData(async, new object[] { null }, typeof(ArgumentNullException));
                yield return new TestCaseData(async, new object[] { 1 }, typeof(ArgumentException));
                yield return new TestCaseData(async, new object[] { new { kind = (string)null } }, typeof(ArgumentException));
                yield return new TestCaseData(async, new object[] { new { kind = "" } }, typeof(ArgumentException));
                yield return new TestCaseData(async, new object[] { new { kind = 1 } }, typeof(ArgumentException));
                yield return new TestCaseData(async, new object[] { new { kind = "text", content = 1 } }, typeof(ArgumentException));
            }
        }

        [Test]
        public void WarningCodeNumberUsesCodeNumberWireName()
        {
            var warning = InferenceModelFactory.MultimodalEmbeddingWarning(
                code: EmbeddingWarningCode.InputTruncated, codeNumber: 1001);
            BinaryData serialized = ModelReaderWriter.Write(warning, ModelReaderWriterOptions.Json, AzureDataAIContext.Default);
            using JsonDocument json = JsonDocument.Parse(serialized.ToString());
            Assert.That(json.RootElement.GetProperty("codeNumber").GetInt32(), Is.EqualTo(1001));
            Assert.That(json.RootElement.TryGetProperty("number", out _), Is.False);
            var roundTrip = ModelReaderWriter.Read<MultimodalEmbeddingWarning>(
                serialized, ModelReaderWriterOptions.Json, AzureDataAIContext.Default);
            Assert.That(roundTrip.CodeNumber, Is.EqualTo(1001));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FlattenedCallsRequireInputs(bool async)
        {
            var client = new InferenceClient(new Uri("https://example.inference.azure.com"), new AzureKeyCredential("api-key"));
            ArgumentNullException error = async
                ? Assert.ThrowsAsync<ArgumentNullException>(() => client.GetEmbeddingsAsync(inputs: (IEnumerable<EmbeddingsInputContent>)null))
                : Assert.Throws<ArgumentNullException>(() => client.GetEmbeddings(inputs: (IEnumerable<EmbeddingsInputContent>)null));
            Assert.That(error.ParamName, Is.EqualTo("inputs"));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public void FlattenedCallsHonorCancellation(bool async, bool anonymous)
        {
            var contents = new[]
            {
                new EmbeddingsInputContent { Kind = EmbeddingContentKind.Text, Id = "item-1", Content = "document" }
            };
            using var handler = new EmbeddingHandler(contents, "dense");
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);
            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            if (anonymous)
            {
                var inputs = new object[] { new { id = "item-1", kind = "text", content = "document" } };
                if (async)
                {
                    Assert.CatchAsync<OperationCanceledException>(() => client.GetEmbeddingsAsync(inputs, cancellationToken: cancellation.Token));
                }
                else
                {
                    Assert.Catch<OperationCanceledException>(() => client.GetEmbeddings(inputs, cancellationToken: cancellation.Token));
                }
            }
            else if (async)
            {
                Assert.CatchAsync<OperationCanceledException>(() => client.GetEmbeddingsAsync(contents, cancellationToken: cancellation.Token));
            }
            else
            {
                Assert.Catch<OperationCanceledException>(() => client.GetEmbeddings(contents, cancellationToken: cancellation.Token));
            }
        }

        [Test]
        public void ContentUriPreservesUrlWireName()
        {
            var item = new EmbeddingsInputContent
            {
                Kind = EmbeddingContentKind.Image,
                Uri = new Uri("https://example.blob.core.windows.net/images/input.png"),
                SasToken = "fake-sas"
            };
            using JsonDocument json = JsonDocument.Parse(
                ModelReaderWriter.Write(item, ModelReaderWriterOptions.Json, AzureDataAIContext.Default).ToString());

            Assert.That(json.RootElement.GetProperty("url").GetString(), Is.EqualTo(item.Uri.AbsoluteUri));
            Assert.That(json.RootElement.TryGetProperty("uri", out _), Is.False);
        }

        private static InferenceClient CreateClient(HttpClient httpClient, bool useTokenCredential = false)
        {
            var endpoint = new Uri("https://example.inference.azure.com");
            var options = new InferenceClientOptions { Transport = new HttpClientTransport(httpClient) };
            return useTokenCredential
                ? new InferenceClient(endpoint, new TestCredential(), options)
                : new InferenceClient(endpoint, new AzureKeyCredential("api-key"), options);
        }

        private static void AssertVector(BinaryData data, bool multiVector = false, int dimensions = 2)
        {
            using JsonDocument json = JsonDocument.Parse(data.ToString());
            JsonElement vector = multiVector ? json.RootElement[0] : json.RootElement;
            Assert.That(vector.GetArrayLength(), Is.EqualTo(dimensions));
            Assert.That(vector[0].GetSingle(), Is.EqualTo(0.25f));
            Assert.That(vector[1].GetSingle(), Is.EqualTo(0.5f));
        }

        private sealed class EmbeddingHandler : HttpMessageHandler
        {
            private readonly IReadOnlyList<EmbeddingsInputContent> _contents;
            private readonly IReadOnlyDictionary<string, object> _expectedOptions;
            private readonly string _kind;
            private readonly bool _useTokenCredential;

            public EmbeddingHandler(IReadOnlyList<EmbeddingsInputContent> contents, string kind,
                IReadOnlyDictionary<string, object> expectedOptions = null, bool useTokenCredential = false)
            {
                _contents = contents;
                _expectedOptions = expectedOptions ?? new Dictionary<string, object>();
                _kind = kind;
                _useTokenCredential = useTokenCredential;
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
                if (_useTokenCredential)
                {
                    Assert.That(request.Headers.Authorization?.Scheme, Is.EqualTo("Bearer"));
                    Assert.That(request.Headers.Authorization?.Parameter, Is.EqualTo("token"));
                    Assert.That(request.Headers.Contains("Ocp-Apim-Subscription-Key"), Is.False);
                }
                else
                {
                    Assert.That(request.Headers.GetValues("Ocp-Apim-Subscription-Key"), Is.EquivalentTo(new[] { "api-key" }));
                }
                Assert.That(request.Content.Headers.ContentType.MediaType, Is.EqualTo("application/json"));
                using JsonDocument json = JsonDocument.Parse(await request.Content.ReadAsStringAsync().ConfigureAwait(false));
                JsonElement body = json.RootElement;
                Assert.That(body.GetProperty("inputs").GetArrayLength(), Is.EqualTo(_contents.Count));
                for (int index = 0; index < _contents.Count; index++)
                {
                    JsonElement content = body.GetProperty("inputs")[index];
                    EmbeddingsInputContent expected = _contents[index];
                    bool hasKind = content.TryGetProperty("kind", out JsonElement actualKind);
                    Assert.That(hasKind, Is.EqualTo(expected.Kind.HasValue));
                    if (hasKind)
                    {
                        Assert.That(actualKind.GetString(), Is.EqualTo(expected.Kind.Value.ToString()));
                    }
                    Assert.That(content.GetProperty("id").GetString(), Is.EqualTo(expected.Id));
                    if (expected.Content != null)
                    {
                        Assert.That(content.GetProperty("content").GetString(), Is.EqualTo(expected.Content));
                    }
                    if (expected.Uri != null)
                    {
                        Assert.That(content.GetProperty("url").GetString(), Is.EqualTo(expected.Uri.AbsoluteUri));
                    }
                    if (expected.SasToken != null)
                    {
                        Assert.That(content.GetProperty("sasToken").GetString(), Is.EqualTo(expected.SasToken));
                    }
                    Assert.That(content.TryGetProperty("type", out _), Is.False);
                    Assert.That(content.TryGetProperty("uri", out _), Is.False);
                    Assert.That(content.TryGetProperty("sas_token", out _), Is.False);
                }
                foreach (string property in new[]
                {
                    "model", "modelVersion", "vectorKind", "dimensions", "multiDimensions",
                    "maxVectorCount", "outputDataKind", "encodingFormat", "delivery"
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
                Assert.That(body.TryGetProperty("maxNumVectors", out _), Is.False);
                Assert.That(body.TryGetProperty("contents", out _), Is.False);
                Assert.That(body.TryGetProperty("model_version", out _), Is.False);

                var vector = new[] { 0.25f, 0.5f };
                if (_expectedOptions.TryGetValue("dimensions", out object dimensions) && dimensions is int width)
                {
                    Array.Resize(ref vector, width);
                }
                var data = new Dictionary<string, object>
                {
                    ["index"] = 0,
                    ["id"] = _contents[0].Id,
                    ["contentKind"] = (_contents[0].Kind ?? EmbeddingContentKind.Text).ToString(),
                    ["kind"] = "multimodal_" + _kind,
                    ["vectorKind"] = _kind
                };
                if (_kind == "dense" || _kind == "dense_multi")
                {
                    data["embedding"] = vector;
                }
                if (_kind == "multi" || _kind == "dense_multi")
                {
                    data["shape"] = new[] { 1, 2 };
                    data["multiEmbedding"] = new[] { vector };
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
                            id = _contents[1].Id,
                            contentKind = (_contents[1].Kind ?? EmbeddingContentKind.Text).ToString(),
                            kind = "multimodal_dense",
                            vectorKind = "dense",
                            embedding = vector
                        });
                    }
                }
                var response = new Dictionary<string, object>
                {
                    ["object"] = "list",
                    ["model"] = _expectedOptions.TryGetValue("model", out object model) ? model : "test-model",
                    ["modelVersion"] = _expectedOptions.TryGetValue("modelVersion", out object modelVersion) ? modelVersion : "v1",
                    ["outputDataKind"] = "float16",
                    ["data"] = responseData,
                    ["usage"] = new { kind = "multimodal", totalTokens = 2, imageCount = _contents.Count - 1 }
                };
                if (_kind == "link")
                {
                    response["output"] = new
                    {
                        id = "0123456789abcdef0123456789abcdef",
                        url = "https://example.blob.core.windows.net/results/output.json",
                        sasToken = "fake-sas",
                        expiresAt = "2026-11-09T12:15:00Z",
                        recordCount = 1,
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

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                Assert.That(requestContext.Scopes, Is.EqualTo(new[] { "https://dbinference.azure.com/.default" }));
                return new AccessToken("token", DateTimeOffset.MaxValue);
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
