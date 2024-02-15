// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.DocumentIntelligence
{
    public partial class DocumentClassifierDetails
    {
        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DocumentClassifierDetails FromResponse(Response response)
        {
            return DeserializationHelpers.FromOperationResponse(response, e => DeserializeDocumentClassifierDetails(e), "result");
        }
    }
}
