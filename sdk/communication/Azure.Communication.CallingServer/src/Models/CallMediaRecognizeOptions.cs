// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Call Media Recognize Configurations.
    /// </summary>
    public abstract class CallMediaRecognizeOptions
    {
        /// <summary>
        /// Creates a new instance of the CallMediaRecognizeOptions.
        /// </summary>
        /// <param name="recognizeInputType"></param>
        protected CallMediaRecognizeOptions(RecognizeInputType recognizeInputType)
        {
            RecognizeInputType = recognizeInputType;
        }

        /// <summary>
        /// Recognize Input Type.
        /// </summary>
        public RecognizeInputType RecognizeInputType { get; }

        /// <summary>
        /// Should stop current Operations?.
        /// </summary>
        public bool StopCurrentOperations { get; set; }

        /// <summary>
        /// Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// PlaySource information.
        /// </summary>
        public PlaySource Prompt { get; set; }

        /// <summary> Determines if we interrupt the prompt and start recognizing. </summary>
        public bool InterruptPromptAndStartRecognition { get; set; }
        /// <summary> Time to wait for first input after prompt (if any). </summary>
        public TimeSpan InitialSilenceTimeout { get; set; }
        /// <summary> Target participant of DTFM tone recognition. </summary>
        public CommunicationIdentifier TargetParticipant { get; set; }
    }
}
