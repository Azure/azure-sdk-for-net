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
        /// Initializes a RecognizeOptions object.
        /// </summary>
        /// <param name="recognizeInputType"></param>
        /// <param name="recognizeConfigurations"></param>
        public RecognizeOptions(RecognizeInputType recognizeInputType, RecognizeConfigurations recognizeConfigurations)
        {
            RecognizeInputType = recognizeInputType;
            RecognizeConfigurations = recognizeConfigurations;
        }
        /// <summary>
        /// Recognize Input Type.
        /// </summary>
        public RecognizeInputType RecognizeInputType { get; }

        /// <summary>
        /// Recognize Configurations.
        /// </summary>
        public RecognizeConfigurations RecognizeConfigurations { get; }

        /// <summary>
        /// Should stop current Operations?.
        /// </summary>
        public bool? StopCurrentOperations { get; set; }

        /// <summary>
        /// Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// PlaySource information.
        /// </summary>
        public PlaySource Prompt { get; set; }
    }
}
