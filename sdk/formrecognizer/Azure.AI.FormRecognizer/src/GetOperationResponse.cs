// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("GetOperationResponse")]
    internal partial class GetOperationResponse
    {
        // The service returns a custom DocumentAnalysis.Error object but we want to expose
        // Core's ResponseError instead. To accomplish this, we keep the returned error as a
        // JsonElement and manually serialize it to ResponseError.
        [CodeGenMember("Error")]
        public JsonElement JsonError
        {
            get => throw new InvalidOperationException();
            private set
            {
                Error = value.ValueKind == JsonValueKind.Undefined
                    ? null
                    : JsonSerializer.Deserialize<ResponseError>(value.GetRawText());
            }
        }

        public ResponseError Error { get; private set; }

        public DocumentModelDetails Result { get; }
    }
}
