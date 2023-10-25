// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    internal partial class TrainResult
    {
        /// <summary> Model identifier. </summary>
        [CodeGenMember("ModelId")]
        public string ModelId { get; }
    }
}
