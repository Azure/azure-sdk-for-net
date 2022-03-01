// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class BasePrediction
    {
        /// <summary> The type of the project. </summary>
        [CodeGenMember("ProjectKind")]
        public ProjectKind ProjectKind { get; set; }
    }
}
