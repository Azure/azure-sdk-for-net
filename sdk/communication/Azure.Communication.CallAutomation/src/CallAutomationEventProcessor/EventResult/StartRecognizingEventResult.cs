// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="StartRecognizingEventResult"/> is returned from WaitForEvent of <see cref="StartRecognizingResult"/>.</summary>
    public class StartRecognizingEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccessEvent { get; internal set; }

        /// <summary>
        /// <see cref="RecognizeCompleted"/> event will be returned once the recognize is completed successfully.
        /// </summary>
        public RecognizeCompleted SuccessEvent { get; }

        /// <summary>
        /// <see cref="RecognizeFailed"/> event will be returned once the recognize is completed unsuccessfully.
        /// </summary>
        public RecognizeFailed FailureEvent { get; }

        internal StartRecognizingEventResult(bool isSuccessEvent, RecognizeCompleted successEvent, RecognizeFailed failureEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            SuccessEvent = successEvent;
            FailureEvent = failureEvent;
        }
    }
}
