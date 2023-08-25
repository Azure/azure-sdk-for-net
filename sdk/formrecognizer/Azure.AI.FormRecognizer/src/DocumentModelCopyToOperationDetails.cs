// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentModelCopyToOperationDetails
    {
        /// <summary>
        /// Initializes a new instance of DocumentModelCopyToOperationDetails. Used by the <see cref="DocumentAnalysisModelFactory"/>
        /// for mocking.
        /// </summary>
        internal DocumentModelCopyToOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, Uri resourceLocation, string serviceVersion, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentModelDetails result)
            : base(operationId, status, percentCompleted, createdOn, lastUpdatedOn, DocumentOperationKind.DocumentModelCopyTo, resourceLocation, serviceVersion, tags, error)
        {
            Result = result;
        }
    }
}
