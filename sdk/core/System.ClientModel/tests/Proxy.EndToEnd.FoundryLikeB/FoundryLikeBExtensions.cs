// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAILike;
using OpenAILike.Responses;

namespace FoundryLikeB
{
    /// <summary>
    /// Registers the complete set of serialization proxies supplied by FoundryLikeB. There is one helper per library,
    /// not one per proxy, so the library owns its registrations and stays independent of other libraries. The helpers
    /// return <see langword="void"/>: mutate the options on separate lines rather than chaining. The method names are
    /// provisional working names, not final API.
    /// </summary>
    public static class FoundryLikeBExtensions
    {
        /// <summary>
        /// Registers all serialization proxies supplied by this library on the client options, before an
        /// <see cref="OpenAIClient"/> is constructed from them.
        /// </summary>
        public static void AddBingSerializationExtensions(this OpenAIClientOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
        }

        /// <summary>
        /// Registers all serialization proxies supplied by this library on the client options, before a
        /// <see cref="ResponsesClient"/> is constructed from them.
        /// </summary>
        public static void AddBingSerializationExtensions(this ResponsesClientOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
        }

        /// <summary>Registers all serialization proxies supplied by this library for direct <see cref="ModelReaderWriter"/> use.</summary>
        public static void AddBingSerializationExtensions(this ModelReaderWriterOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            options.AddProxy<ResponseTool>(new BingGroundingToolProxy());
        }
    }
}
