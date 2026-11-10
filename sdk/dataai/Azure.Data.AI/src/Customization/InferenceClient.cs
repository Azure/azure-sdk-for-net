// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Data.AI
{
#pragma warning disable SCME0002
    // The generated settings-based constructor assumes token authentication and casts
    // InferenceClientSettings.CredentialProvider to TokenCredential. This service also
    // supports API-key authentication, where the key lives in Credential.Key and no
    // token provider is present, so the generated cast yields null and the bearer policy
    // throws before a request is ever sent. The replacement below picks the policy that
    // matches the configured credential.
    [CodeGenSuppress("InferenceClient", typeof(InferenceClientSettings))]
    public partial class InferenceClient
    {
        /// <summary> Initializes a new instance of InferenceClient from a <see cref="InferenceClientSettings"/>. </summary>
        /// <param name="settings"> The settings for InferenceClient. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="settings"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="settings"/> does not carry a usable credential. </exception>
        [Experimental("SCME0002")]
        public InferenceClient(InferenceClientSettings settings)
            : this(CreateAuthenticationPolicy(settings), settings?.Endpoint, settings?.Options)
        {
        }

        [Experimental("SCME0002")]
        private static HttpPipelinePolicy CreateAuthenticationPolicy(InferenceClientSettings settings)
        {
            Argument.AssertNotNull(settings, nameof(settings));

            if (settings.CredentialProvider is TokenCredential tokenCredential)
            {
                return new BearerTokenAuthenticationPolicy(tokenCredential, AuthorizationScopes);
            }

            string key = settings.Credential?.Key;
            if (!string.IsNullOrEmpty(key))
            {
                return new AzureKeyCredentialPolicy(new AzureKeyCredential(key), AuthorizationHeader);
            }

            throw new ArgumentException(
                $"The supplied {nameof(InferenceClientSettings)} does not contain a usable credential. Set either "
                + $"{nameof(InferenceClientSettings.Credential)}.{nameof(CredentialSettings.TokenProvider)} for Microsoft Entra ID "
                + $"authentication or {nameof(InferenceClientSettings.Credential)}.{nameof(CredentialSettings.Key)} for API key authentication.",
                nameof(settings));
        }

        /// <summary>
        /// Embeds text, queries and document images using loosely typed items, for example anonymous objects or dictionaries.
        /// Each item is serialized to JSON with <see cref="JsonSerializer"/> and must produce a JSON object that uses the wire
        /// property names <c>kind</c> (required), <c>id</c>, <c>content</c>, <c>url</c> and <c>sasToken</c> (all optional, string values).
        /// Property names are not renamed, so use these exact names. <see cref="EmbeddingContentItem"/> instances are used as-is.
        /// </summary>
        /// <param name="contents"> The items to embed. </param>
        /// <param name="model"> The model to use. </param>
        /// <param name="modelVersion"> The model version to use. </param>
        /// <param name="vectorKind"> The kind of vectors to return. </param>
        /// <param name="dimensions"> The number of dimensions of the returned vectors. </param>
        /// <param name="multiDimensions"> The number of dimensions of multi-vector embeddings. </param>
        /// <param name="maxVectorCount"> The maximum number of vectors per item. </param>
        /// <param name="outputDataKind"> The data kind of the returned vectors. </param>
        /// <param name="encodingFormat"> The encoding format of the returned vectors. </param>
        /// <param name="delivery"> How results are delivered. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> or one of its items is null. </exception>
        /// <exception cref="ArgumentException"> An item is not a JSON object or has a missing, non-string or empty <c>kind</c>. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("Serializes arbitrary objects with reflection-based System.Text.Json; members of the item types might be trimmed.")]
        [RequiresDynamicCode("Serializes arbitrary objects with reflection-based System.Text.Json.")]
#endif
        public virtual Response<MultimodalEmbeddingResult> GetMultimodalEmbeddings(IEnumerable<object> contents, string model = default, string modelVersion = default, EmbeddingVectorKind? vectorKind = default, int? dimensions = default, int? multiDimensions = default, int? maxVectorCount = default, EmbeddingOutputDataKind? outputDataKind = default, EmbeddingEncodingFormat? encodingFormat = default, EmbeddingDelivery? delivery = default, CancellationToken cancellationToken = default)
        {
            IEnumerable<EmbeddingContentItem> items = ConvertToContentItems(contents, nameof(contents));
            return GetMultimodalEmbeddings(items, model, modelVersion, vectorKind, dimensions, multiDimensions, maxVectorCount, outputDataKind, encodingFormat, delivery, cancellationToken);
        }

        /// <summary>
        /// Embeds text, queries and document images using loosely typed items, for example anonymous objects or dictionaries.
        /// Each item is serialized to JSON with <see cref="JsonSerializer"/> and must produce a JSON object that uses the wire
        /// property names <c>kind</c> (required), <c>id</c>, <c>content</c>, <c>url</c> and <c>sasToken</c> (all optional, string values).
        /// Property names are not renamed, so use these exact names. <see cref="EmbeddingContentItem"/> instances are used as-is.
        /// </summary>
        /// <param name="contents"> The items to embed. </param>
        /// <param name="model"> The model to use. </param>
        /// <param name="modelVersion"> The model version to use. </param>
        /// <param name="vectorKind"> The kind of vectors to return. </param>
        /// <param name="dimensions"> The number of dimensions of the returned vectors. </param>
        /// <param name="multiDimensions"> The number of dimensions of multi-vector embeddings. </param>
        /// <param name="maxVectorCount"> The maximum number of vectors per item. </param>
        /// <param name="outputDataKind"> The data kind of the returned vectors. </param>
        /// <param name="encodingFormat"> The encoding format of the returned vectors. </param>
        /// <param name="delivery"> How results are delivered. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> or one of its items is null. </exception>
        /// <exception cref="ArgumentException"> An item is not a JSON object or has a missing, non-string or empty <c>kind</c>. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("Serializes arbitrary objects with reflection-based System.Text.Json; members of the item types might be trimmed.")]
        [RequiresDynamicCode("Serializes arbitrary objects with reflection-based System.Text.Json.")]
#endif
        public virtual async Task<Response<MultimodalEmbeddingResult>> GetMultimodalEmbeddingsAsync(IEnumerable<object> contents, string model = default, string modelVersion = default, EmbeddingVectorKind? vectorKind = default, int? dimensions = default, int? multiDimensions = default, int? maxVectorCount = default, EmbeddingOutputDataKind? outputDataKind = default, EmbeddingEncodingFormat? encodingFormat = default, EmbeddingDelivery? delivery = default, CancellationToken cancellationToken = default)
        {
            IEnumerable<EmbeddingContentItem> items = ConvertToContentItems(contents, nameof(contents));
            return await GetMultimodalEmbeddingsAsync(items, model, modelVersion, vectorKind, dimensions, multiDimensions, maxVectorCount, outputDataKind, encodingFormat, delivery, cancellationToken).ConfigureAwait(false);
        }

#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("Serializes arbitrary objects with reflection-based System.Text.Json; members of the item types might be trimmed.")]
        [RequiresDynamicCode("Serializes arbitrary objects with reflection-based System.Text.Json.")]
#endif
        private static List<EmbeddingContentItem> ConvertToContentItems(IEnumerable<object> contents, string paramName)
        {
            Argument.AssertNotNull(contents, paramName);

            List<EmbeddingContentItem> items = new();
            int index = 0;
            foreach (object item in contents)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(paramName, $"Item at index {index} is null.");
                }
                items.Add(item as EmbeddingContentItem ?? ConvertToContentItem(item, paramName, index));
                index++;
            }
            return items;
        }

#if NET5_0_OR_GREATER
        [RequiresUnreferencedCode("Serializes arbitrary objects with reflection-based System.Text.Json; members of the item types might be trimmed.")]
        [RequiresDynamicCode("Serializes arbitrary objects with reflection-based System.Text.Json.")]
#endif
        private static EmbeddingContentItem ConvertToContentItem(object item, string paramName, int index)
        {
            byte[] json = item is JsonElement element
                ? JsonSerializer.SerializeToUtf8Bytes(element)
                : JsonSerializer.SerializeToUtf8Bytes(item, item.GetType());

            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                throw new ArgumentException($"Item at index {index} must serialize to a JSON object but serialized to {root.ValueKind}.", paramName);
            }

            if (!root.TryGetProperty("kind", out JsonElement kind) || kind.ValueKind != JsonValueKind.String || string.IsNullOrEmpty(kind.GetString()))
            {
                throw new ArgumentException($"Item at index {index} must have a non-empty string 'kind' property.", paramName);
            }

            foreach (string name in new[] { "id", "content", "url", "sasToken" })
            {
                if (root.TryGetProperty(name, out JsonElement value) && value.ValueKind != JsonValueKind.String && value.ValueKind != JsonValueKind.Null)
                {
                    throw new ArgumentException($"Property '{name}' of the item at index {index} must be a string.", paramName);
                }
            }

            return EmbeddingContentItem.DeserializeEmbeddingContentItem(root, ModelReaderWriterOptions.Json);
        }
    }

#pragma warning restore SCME0002
}
