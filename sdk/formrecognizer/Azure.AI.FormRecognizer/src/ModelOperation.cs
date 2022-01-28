// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("GetOperationResponse")]
    public partial class ModelOperation
    {
        /// <summary> Operation result upon success. </summary>
        //TODO service is looking into fixing this so it has different return types that we can adapt.
        [CodeGenMember("Result")]
        public DocumentModel Result { get; }

        /// <summary> Encountered error. </summary>
        [CodeGenMember("Error")]
        private readonly JsonElement _error;

        /// <summary>
        /// Gets the error that occurred during the operation. The value is <c>null</c> if the operation succeeds.
        /// </summary>
        public ResponseError Error => _error.ValueKind == JsonValueKind.Undefined ? null : JsonSerializer.Deserialize<ResponseError>(_error.GetRawText());
    }
}
