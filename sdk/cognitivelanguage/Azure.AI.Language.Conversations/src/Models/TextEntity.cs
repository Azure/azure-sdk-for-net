// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    [CodeGenModel("Entity")]
    public partial class TextEntity
    {
        /// <summary> Confidence score between 0 and 1 of the extracted entity. </summary>
        [CodeGenMember("confidenceScore")] // TODO: https://github.com/Azure/azure-sdk-for-net/issues/29143
        public double Confidence { get; set; }
    }
}
