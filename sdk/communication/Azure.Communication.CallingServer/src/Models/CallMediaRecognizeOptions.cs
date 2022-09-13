// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Optional elements for Recognize.
    /// </summary>
    public class CallMediaRecognizeOptions
    {
        /// <summary>
        /// Initializes a RecognizeOptions object.
        /// </summary>
        /// <param name="recognizeInputType"></param>
        /// <param name="recognizeConfigurations"></param>
        public CallMediaRecognizeOptions(RecognizeInputType recognizeInputType, RecognizeOptions recognizeConfigurations)
        {
            RecognizeInputType = recognizeInputType;
            RecognizeOptions = recognizeConfigurations;
        }
        /// <summary>
        /// Recognize Input Type.
        /// </summary>
        public RecognizeInputType RecognizeInputType { get; }

        /// <summary>
        /// Recognize Configurations.
        /// </summary>
        public RecognizeOptions RecognizeOptions { get; }

        /// <summary>
        /// Should stop current Operations?.
        /// </summary>
        public bool? InterruptCallMediaOperation { get; set; }

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
