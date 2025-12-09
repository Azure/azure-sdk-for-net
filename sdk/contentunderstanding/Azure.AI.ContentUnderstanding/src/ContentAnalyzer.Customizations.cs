// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for ContentAnalyzer to customize LRO response handling.
    /// </summary>
    [CodeGenSuppress("FromLroResponse", typeof(Response))]
    public partial class ContentAnalyzer
    {
        /// <summary>
        /// Converts a response to a ContentAnalyzer using the LRO result path.
        /// </summary>
        /// <remarks>
        /// EMITTER-FIX: Emitter does not correctly handle LongRunningResourceCreateOrReplace operations per TypeSpec spec.
        /// Per https://github.com/Azure/typespec-azure/blob/2a6f2b44ea0fec68c65957c3accc77f74e92545d/packages/typespec-azure-core/lib/operations.tsp#L131,
        /// LongRunningResourceCreateOrReplace PUT operations return Resource directly via ResourceCreatedOrOkResponse&lt;Resource&gt;.
        /// The emitter incorrectly assumes all LRO responses are wrapped in "result" property. This customization fixes the deserialization
        /// for CreateAnalyzer/Async and CopyAnalyzer/Async operations which have ContentAnalyzer in the root element.
        /// Tracked in TypeSpec Client Generator Core: https://github.com/Azure/typespec-azure/issues/3630
        /// </remarks>
        /// <param name="response"> The response from the service. </param>
        internal static ContentAnalyzer FromLroResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            JsonElement rootElement = document.RootElement;

            // EMITTER-FIX: CreateAnalyzer/Async and CopyAnalyzer/Async operations return ContentAnalyzer directly in root element
            // per LongRunningResourceCreateOrReplace spec, not wrapped in "result" property
            return DeserializeContentAnalyzer(rootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
