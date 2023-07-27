// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="StartRecognizingEventResult"/> is returned from WaitForEvent of <see cref="StartRecognizingCallMediaResult"/>.</summary>
    public class StartRecognizingEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="RecognizeCompleted"/> event will be returned once the recognize is completed successfully.
        /// </summary>
        public RecognizeCompleted SuccessResult { get; }

        /// <summary>
        /// <see cref="RecognizeFailed"/> event will be returned once the recognize is completed unsuccessfully.
        /// </summary>
        public RecognizeFailed FailureResult { get; }

        internal StartRecognizingEventResult(bool isSuccess, RecognizeCompleted successResult, RecognizeFailed failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
