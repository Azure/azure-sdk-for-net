// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Parameters object for a text analysis task using pre-built models. </summary>
    public partial class PreBuiltTaskParameters : TaskParameters
    {
        /// <summary> Initializes a new instance of PreBuiltTaskParameters. </summary>
        public PreBuiltTaskParameters()
        {
        }

        /// <summary> Initializes a new instance of PreBuiltTaskParameters. </summary>
        /// <param name="loggingOptOut"></param>
        /// <param name="modelVersion"></param>
        internal PreBuiltTaskParameters(bool? loggingOptOut, string modelVersion) : base(loggingOptOut)
        {
            ModelVersion = modelVersion;
        }

        /// <summary> Gets or sets the model version. </summary>
        public string ModelVersion { get; set; }
    }
}
