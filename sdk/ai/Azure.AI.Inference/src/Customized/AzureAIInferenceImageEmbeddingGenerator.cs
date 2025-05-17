// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference;

namespace Microsoft.Extensions.AI
{
    /// <summary>Represents an <see cref="IEmbeddingGenerator{DataContent, Embedding}"/> for an Azure.AI.Inference <see cref="ImageEmbeddingsClient"/>.</summary>
    internal sealed class AzureAIInferenceImageEmbeddingGenerator :
        IEmbeddingGenerator<DataContent, Embedding<float>>
    {
        /// <summary>Metadata about the embedding generator.</summary>
        private readonly EmbeddingGeneratorMetadata _metadata;

        /// <summary>The underlying <see cref="ImageEmbeddingsClient" />.</summary>
        private readonly ImageEmbeddingsClient _imageEmbeddingsClient;

        /// <summary>The number of dimensions produced by the generator.</summary>
        private readonly int? _dimensions;

        /// <summary>Initializes a new instance of the <see cref="AzureAIInferenceImageEmbeddingGenerator"/> class.</summary>
        /// <param name="imageEmbeddingsClient">The underlying client.</param>
        /// <param name="defaultModelId">
        /// The ID of the model to use. This can also be overridden per request via <see cref="EmbeddingGenerationOptions.ModelId"/>.
        /// Either this parameter or <see cref="EmbeddingGenerationOptions.ModelId"/> must provide a valid model ID.
        /// </param>
        /// <param name="defaultModelDimensions">The number of dimensions to generate in each embedding.</param>
        /// <exception cref="ArgumentNullException"><paramref name="imageEmbeddingsClient"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="defaultModelId"/> is empty or composed entirely of whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="defaultModelDimensions"/> is not positive.</exception>
        public AzureAIInferenceImageEmbeddingGenerator(
            ImageEmbeddingsClient imageEmbeddingsClient, string defaultModelId = null, int? defaultModelDimensions = null)
        {
            Argument.AssertNotNull(imageEmbeddingsClient, nameof(imageEmbeddingsClient));

            if (defaultModelId is not null)
            {
                Argument.AssertNotNullOrWhiteSpace(defaultModelId, nameof(defaultModelId));
            }

            if (defaultModelDimensions is { } modelDimensions)
            {
                Argument.AssertInRange(modelDimensions, 1, int.MaxValue, nameof(defaultModelDimensions));
            }

            _imageEmbeddingsClient = imageEmbeddingsClient;
            _dimensions = defaultModelDimensions;
            _metadata = new EmbeddingGeneratorMetadata("az.ai.inference", imageEmbeddingsClient.Endpoint, defaultModelId, defaultModelDimensions);
        }

        /// <inheritdoc />
        object IEmbeddingGenerator.GetService(Type serviceType, object serviceKey)
        {
            Argument.AssertNotNull(serviceType, nameof(serviceType));

            return
                serviceKey is not null ? null :
                serviceType == typeof(ImageEmbeddingsClient) ? _imageEmbeddingsClient :
                serviceType == typeof(EmbeddingGeneratorMetadata) ? _metadata :
                serviceType.IsInstanceOfType(this) ? this :
                null;
        }

        /// <inheritdoc />
        public async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
            IEnumerable<DataContent> values, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(values, nameof(values));

            var azureAIOptions = ToAzureAIOptions(values, options);

            var embeddings = (await _imageEmbeddingsClient.EmbedAsync(azureAIOptions, cancellationToken).ConfigureAwait(false)).Value;

            GeneratedEmbeddings<Embedding<float>> result = new(embeddings.Data.Select(e =>
                new Embedding<float>(AzureAIInferenceEmbeddingGenerator.ParseBase64Floats(e.Embedding))
                {
                    CreatedAt = DateTimeOffset.UtcNow,
                    ModelId = embeddings.Model ?? azureAIOptions.Model,
                }));

            if (embeddings.Usage is not null)
            {
                result.Usage = new()
                {
                    InputTokenCount = embeddings.Usage.PromptTokens,
                    TotalTokenCount = embeddings.Usage.TotalTokens
                };
            }

            return result;
        }

        /// <inheritdoc />
        void IDisposable.Dispose()
        {
            // Nothing to dispose. Implementation required for the IEmbeddingGenerator interface.
        }

        /// <summary>Converts an extensions options instance to an Azure.AI.Inference options instance.</summary>
        private ImageEmbeddingsOptions ToAzureAIOptions(IEnumerable<DataContent> inputs, EmbeddingGenerationOptions options)
        {
            IEnumerable<ImageEmbeddingInput> imageEmbeddingInputs = inputs.Select(dc => new ImageEmbeddingInput(dc.Uri));
            if (options?.RawRepresentationFactory?.Invoke(this) is not ImageEmbeddingsOptions result)
            {
                result = new ImageEmbeddingsOptions(imageEmbeddingInputs);
            }
            else
            {
                foreach (var input in imageEmbeddingInputs)
                {
                    result.Input.Add(input);
                }
            }

            result.Dimensions ??= options?.Dimensions ?? _dimensions;
            result.Model ??= options?.ModelId ?? _metadata.DefaultModelId;
            result.EncodingFormat = EmbeddingEncodingFormat.Base64;

            if (options?.AdditionalProperties is { } props)
            {
                foreach (var prop in props)
                {
                    if (prop.Value is not null)
                    {
                        byte[] data = JsonSerializer.SerializeToUtf8Bytes(prop.Value, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object)));
                        result.AdditionalProperties[prop.Key] = new BinaryData(data);
                    }
                }
            }

            return result;
        }
    }
}
