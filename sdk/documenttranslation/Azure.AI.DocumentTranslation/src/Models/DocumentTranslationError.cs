// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
{
    [CodeGenModel("ErrorV2")]
    public partial class DocumentTranslationError
    {
        /// <summary> Enums containing high level error codes. </summary>
        [CodeGenMember("Code")]
        public DocumentTranslationErrorCode? ErrorCode { get; }
    }
}
