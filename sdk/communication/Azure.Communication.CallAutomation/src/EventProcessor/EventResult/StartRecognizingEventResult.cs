// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> StartRecognizingEventResult is returned from WaitForEvent of StartRecognizingResult. </summary>
    /// </summary>
    public class StartRecognizingEventResult : EventResultBase
    {
        /// <summary>
        /// RecognizeCompleted event will be returned once the recognize is completed successfully.
        /// </summary>
        public RecognizeCompleted SuccessEvent { get; }

        /// <summary>
        /// RecognizeFailed event will be returned once the recognize is completed unsuccessfully.
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
