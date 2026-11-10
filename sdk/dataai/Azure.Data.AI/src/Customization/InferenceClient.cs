// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        /// <summary> Generates embeddings for multimodal content using the supplied options. </summary>
        /// <param name="options"> The multimodal embedding options. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<MultimodalEmbeddingResult> MultiModalEmbed(MultimodalEmbeddingOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return MultiModalEmbed(options.Contents, options.Model, options.ModelVersion, options.VectorType, options.Dimensions, options.MultiDimensions, options.MaxNumVectors, options.OutputDataType, options.EncodingFormat, options.Delivery, cancellationToken);
        }

        /// <summary> Generates embeddings for multimodal content using the supplied options. </summary>
        /// <param name="options"> The multimodal embedding options. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<MultimodalEmbeddingResult>> MultiModalEmbedAsync(MultimodalEmbeddingOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return await MultiModalEmbedAsync(options.Contents, options.Model, options.ModelVersion, options.VectorType, options.Dimensions, options.MultiDimensions, options.MaxNumVectors, options.OutputDataType, options.EncodingFormat, options.Delivery, cancellationToken).ConfigureAwait(false);
        }
    }

#pragma warning disable SA1402 // Options type intentionally lives beside the client customization

    /// <summary> Options for a multimodal embedding request. </summary>
    public partial class MultimodalEmbeddingOptions
    {
        /// <summary> Initializes a new instance of <see cref="MultimodalEmbeddingOptions"/>. </summary>
        /// <param name="contents"> The content items to embed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="contents"/> is null. </exception>
        public MultimodalEmbeddingOptions(IEnumerable<EmbeddingContentItem> contents)
        {
            Argument.AssertNotNull(contents, nameof(contents));

            Contents = new List<EmbeddingContentItem>(contents);
        }

        /// <summary> The content items to embed. </summary>
        public IList<EmbeddingContentItem> Contents { get; }

        /// <summary> The model to use. </summary>
        public string Model { get; set; }

        /// <summary> The model version. </summary>
        public string ModelVersion { get; set; }

        /// <summary> The type of vectors to return. </summary>
        public EmbeddingVectorType? VectorType { get; set; }

        /// <summary> The number of dimensions of the dense vectors. </summary>
        public int? Dimensions { get; set; }

        /// <summary> The number of dimensions of the multi-vectors. </summary>
        public int? MultiDimensions { get; set; }

        /// <summary> The maximum number of vectors to return. </summary>
        public int? MaxNumVectors { get; set; }

        /// <summary> The data type of the output embeddings. </summary>
        public EmbeddingOutputDataType? OutputDataType { get; set; }

        /// <summary> The encoding format of the output embeddings. </summary>
        public EmbeddingEncodingFormat? EncodingFormat { get; set; }

        /// <summary> How the embeddings are delivered. </summary>
        public EmbeddingDelivery? Delivery { get; set; }
    }
#pragma warning restore SA1402
#pragma warning restore SCME0002
}
