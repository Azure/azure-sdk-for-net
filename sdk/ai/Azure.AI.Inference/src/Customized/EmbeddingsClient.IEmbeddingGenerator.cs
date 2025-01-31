// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

#nullable enable

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Implementation of .NET's IEmbeddingGenerator<> exchange type for embedding generation services

    public partial class EmbeddingsClient : IEmbeddingGenerator<string, Embedding<float>>
    {
        // TODO: This is currently provided as an explicit implementation of IEmbeddingGenerator on EmbeddingsClient,
        // which enables an instance to simply be used anywhere an IEmbeddingGenerator is desired. Alternatively, it could
        // be exposed as an AsEmbeddingGenerator() method that would return a new wrapper instance implementing IEmbeddingGenerator.

        /// <summary>The lazily-instantiated metadata.</summary>
        private EmbeddingGeneratorMetadata? _metadata;

        /// <inheritdoc />
        EmbeddingGeneratorMetadata IEmbeddingGenerator<string, Embedding<float>>.Metadata => _metadata ??= new("az.ai.inference", _endpoint);

        /// <inheritdoc />
        object? IEmbeddingGenerator<string, Embedding<float>>.GetService(Type serviceType, object? serviceKey)
        {
            Argument.AssertNotNull(serviceType, nameof(serviceType));
            return
                serviceKey is not null ? null :
                serviceType.IsInstanceOfType(this) ? this :
                null;
        }

        /// <inheritdoc />
        async Task<GeneratedEmbeddings<Embedding<float>>> IEmbeddingGenerator<string, Embedding<float>>.GenerateAsync(
            IEnumerable<string> values, EmbeddingGenerationOptions? options, CancellationToken cancellationToken)
        {
            EmbeddingsOptions azureAIOptions = ToAzureAIOptions(values, options, EmbeddingEncodingFormat.Base64);

            EmbeddingsResult embeddings = (await EmbedAsync(azureAIOptions, cancellationToken).ConfigureAwait(false)).Value;

            GeneratedEmbeddings<Embedding<float>> result = new(embeddings.Data.Select(e =>
                new Embedding<float>(ParseBase64Floats(e.Embedding))
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
        void IDisposable.Dispose() => GC.SuppressFinalize(this);

        private static float[] ParseBase64Floats(BinaryData binaryData)
        {
            ReadOnlySpan<byte> base64 = binaryData.ToMemory().Span;

            // Remove quotes around base64 string.
            if (base64.Length < 2 || base64[0] != (byte)'"' || base64[base64.Length - 1] != (byte)'"')
            {
                ThrowInvalidData();
            }

            base64 = base64.Slice(1, base64.Length - 2);

            // Decode base64 string to bytes.
            byte[] bytes = ArrayPool<byte>.Shared.Rent(Base64.GetMaxDecodedFromUtf8Length(base64.Length));
            OperationStatus status = Base64.DecodeFromUtf8(base64, bytes.AsSpan(), out int bytesConsumed, out int bytesWritten);
            if (status != OperationStatus.Done || bytesWritten % sizeof(float) != 0)
            {
                ThrowInvalidData();
            }

            // Interpret bytes as floats
            float[] vector = new float[bytesWritten / sizeof(float)];
            bytes.AsSpan(0, bytesWritten).CopyTo(MemoryMarshal.AsBytes(vector.AsSpan()));
            if (!BitConverter.IsLittleEndian)
            {
                Span<int> ints = MemoryMarshal.Cast<float, int>(vector.AsSpan());
#if NET
                BinaryPrimitives.ReverseEndianness(ints, ints);
#else
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] = BinaryPrimitives.ReverseEndianness(ints[i]);
                }
#endif
            }

            ArrayPool<byte>.Shared.Return(bytes);
            return vector;

            static void ThrowInvalidData() =>
                throw new FormatException("The input is not a valid Base64 string of encoded floats.");
        }

        /// <summary>Converts an extensions options instance to an OpenAI options instance.</summary>
        private static EmbeddingsOptions ToAzureAIOptions(IEnumerable<string> inputs, EmbeddingGenerationOptions? options, EmbeddingEncodingFormat format)
        {
            EmbeddingsOptions result = new(inputs)
            {
                Dimensions = options?.Dimensions,
                Model = options?.ModelId,
                EncodingFormat = format,
            };

            if (options?.AdditionalProperties is { } props)
            {
                foreach (KeyValuePair<string, object?> prop in props)
                {
                    if (prop.Value is not null)
                    {
                        result.AdditionalProperties[prop.Key] = new BinaryData(
                            JsonSerializer.SerializeToUtf8Bytes(prop.Value, AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(object))));
                    }
                }
            }

            return result;
        }
    }
}
