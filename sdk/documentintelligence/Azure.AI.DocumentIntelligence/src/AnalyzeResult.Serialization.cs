// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.DocumentIntelligence
{
    public partial class AnalyzeResult
    {
        // AnalyzeResult.FromResponse was not included in the generated code, but it should be.
        // This is just a workaround while this issue is not fixed or while we don't implement
        // deserialization manually.

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static AnalyzeResult FromResponse(Response response)
        {
            return null;
        }
    }
}
