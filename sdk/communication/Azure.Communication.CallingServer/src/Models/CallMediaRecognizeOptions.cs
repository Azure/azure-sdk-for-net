// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Call Media Recognize Options.
    /// </summary>
    public abstract class CallMediaRecognizeOptions
    {
        /// <summary>
        /// Creates a new instance of the CallMediaRecognizeOptions.
        /// </summary>
        /// <param name="inputType"></param>
        /// <param name="targetParticipant"></param>
        protected CallMediaRecognizeOptions(RecognizeInputType inputType, CommunicationIdentifier targetParticipant)
        {
            InputType = inputType;
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// Recognize Input Type.
        /// </summary>
        public RecognizeInputType InputType { get; }

        /// <summary>
        /// Interrupt current call media operation.
        /// </summary>
        public bool InterruptCallMediaOperation { get; set; }

        /// <summary>
        /// Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// PlaySource information.
        /// </summary>
        public PlaySource Prompt { get; set; }

        /// <summary>
        /// Determines if we interrupt the prompt and start recognizing.
        /// </summary>
        public bool InterruptPrompt { get; set; }

        /// <summary>
        /// Time to wait for first input after prompt (if any).
        /// </summary>
        public TimeSpan InitialSilenceTimeout { get; set; }

        /// <summary>
        /// Target participant of DTFM tone recognition.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }
    }
}
