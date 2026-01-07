// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Call Media Recognize Options.
    /// </summary>
    public abstract class CallMediaRecognizeOptions
    {
        private static readonly TimeSpan _defaultInitialSilenceTimeout = TimeSpan.FromSeconds(5);

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
        /// If not provided, a default of 5 seconds is set.
        /// </summary>
        public TimeSpan InitialSilenceTimeout { get; set; } = _defaultInitialSilenceTimeout;

        /// <summary>
        /// Target participant of DTFM tone recognition.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary> Speech language to be recognized, If not set default is en-US. </summary>
        public string SpeechLanguage { get; set; }

        /// <summary> Endpoint where the speech custom model was deployed. </summary>
        public string SpeechModelEndpointId { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
