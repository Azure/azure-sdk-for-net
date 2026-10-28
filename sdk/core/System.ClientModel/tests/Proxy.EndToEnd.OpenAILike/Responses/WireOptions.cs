// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAILike.Responses
{
    internal static class WireOptions
    {
        /// <summary>
        /// Snapshots the <see cref="ModelReaderWriterOptions"/> carried by <paramref name="pipelineOptions"/> at
        /// client construction, the way a generated client caches its "wire" options. Registrations added to the
        /// client options afterwards do not affect clients that were already built.
        /// </summary>
        public static ModelReaderWriterOptions Create(ClientPipelineOptions pipelineOptions)
            => pipelineOptions.ModelReaderWriterOptions is { } configuredOptions
                ? new ModelReaderWriterOptions("J", configuredOptions, ResponseToolsContext.Default)
                : new ModelReaderWriterOptions("J", ResponseToolsContext.Default);
    }
}
