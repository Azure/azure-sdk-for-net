// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("OperationInfo")]
    public partial class ModelOperationInfo
    {
        /// <summary>
        /// Date and time (UTC) when the operation was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the operation was last updated.
        /// </summary>
        [CodeGenMember("LastUpdatedDateTime")]
        public DateTimeOffset LastUpdatedOn { get; }

        /// <summary>
        /// A list of user-defined key-value tag attributes associated with the model.
        /// </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary> API version used to create this operation. </summary>
        internal string ApiVersion { get; }
    }
}
