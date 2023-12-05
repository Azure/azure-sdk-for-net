// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.AI.DocumentIntelligence
{
    internal static class DeserializationHelpers
    {
        internal static T FromOperationResponse<T>(Response response, Func<JsonElement, T> deserializationFunc, string resultPropertyName)
        {
            using var document = JsonDocument.Parse(response.Content);

            // If this response is the outcome of a long-running operation, the result of the operation
            // needs to be deserialized from the "result" property instead of the root element. Without
            // this workaround, the generated code fails for long-running operations.

            if (document.RootElement.TryGetProperty(resultPropertyName, out var result))
            {
                return deserializationFunc(result);
            }
            else
            {
                return deserializationFunc(document.RootElement);
            }
        }
    }
}
