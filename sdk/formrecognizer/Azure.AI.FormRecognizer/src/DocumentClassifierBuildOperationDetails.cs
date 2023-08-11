﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentClassifierBuildOperationDetails
    {
        /// <summary>
        /// Initializes a new instance of DocumentClassifierBuildOperationDetails. Used by the <see cref="DocumentAnalysisModelFactory"/>
        /// for mocking.
        /// </summary>
        internal DocumentClassifierBuildOperationDetails(string operationId, DocumentOperationStatus status, int? percentCompleted, DateTimeOffset createdOn, DateTimeOffset lastUpdatedOn, Uri resourceLocation, string serviceVersion, IReadOnlyDictionary<string, string> tags, ResponseError error, DocumentClassifierDetails result)
            : base(operationId, status, percentCompleted, createdOn, lastUpdatedOn, DocumentOperationKind.DocumentClassifierBuild, resourceLocation, serviceVersion, tags, error)
        {
            Result = result;
        }
    }
}
