// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.DocumentIntelligence
{
    public partial class DocumentModelDetails
    {
        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DocumentModelDetails FromResponse(Response response)
        {
            return DeserializationHelpers.FromOperationResponse(response, e => DeserializeDocumentModelDetails(e), "result");
        }
    }
}
