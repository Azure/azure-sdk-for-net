// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("GetOperationResponse")]
    public partial class ModelOperation
    {
        // This property is set by the DocumentAnalysisModelFactory when mocking this class.
        private readonly ResponseError _mockError;

        /// <summary>
        /// Initializes a new instance of ModelOperation. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal ModelOperation(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, DocumentOperationKind kind, string resourceLocation, string apiVersion, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModel result) : base(operationId, status, percentCompleted, createdOn, lastUpdatedOn, kind, resourceLocation, apiVersion, tags)
        {
            _mockError = error;
            Result = result;
        }

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
        public ResponseError Error => _mockError
            ?? (_error.ValueKind == JsonValueKind.Undefined ? null : JsonSerializer.Deserialize<ResponseError>(_error.GetRawText()));
    }
}
