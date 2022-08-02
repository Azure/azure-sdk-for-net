// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Optional elements for Recognize.
    /// </summary>
    public class RecognizeOptions
    {
        /// <summary>
        /// Recognize Input Type.
        /// </summary>
        public RecognizeInputType? RecognizeInputType { get; internal set; }

        /// <summary>
        /// Should stop current Operations?.
        /// </summary>
        public bool? StopCurrentOperations { get; internal set; }

        /// <summary>
        /// Operation Context.
        /// </summary>
        public string OperationContext { get; internal set; }

        /// <summary>
        /// PlaySource information.
        /// </summary>
        public PlaySource PlaySourceInfo { get; set; }
    }
}
