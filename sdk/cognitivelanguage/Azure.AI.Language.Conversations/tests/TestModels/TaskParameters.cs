// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Base parameters object for a text analysis task. </summary>
    public partial class TaskParameters
    {
        /// <summary> Initializes a new instance of TaskParameters. </summary>
        public TaskParameters()
        {
        }

        /// <summary> Initializes a new instance of TaskParameters. </summary>
        /// <param name="loggingOptOut"></param>
        internal TaskParameters(bool? loggingOptOut)
        {
            LoggingOptOut = loggingOptOut;
        }

        /// <summary> Gets or sets the logging opt out. </summary>
        public bool? LoggingOptOut { get; set; }
    }
}
