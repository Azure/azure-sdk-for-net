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
        public bool IsSuccess { get; internal set; }

        /// <summary>
        /// <see cref="RecognizeCompletedEventData"/> event will be returned once the recognize is completed successfully.
        /// </summary>
        public RecognizeCompletedEventData SuccessResult { get; }

        /// <summary>
        /// <see cref="RecognizeFailedEventData"/> event will be returned once the recognize is completed unsuccessfully.
        /// </summary>
        public RecognizeFailedEventData FailureResult { get; }

        internal StartRecognizingEventResult(bool isSuccess, RecognizeCompletedEventData successResult, RecognizeFailedEventData failureResult)
        {
            IsSuccess = isSuccess;
            SuccessResult = successResult;
            FailureResult = failureResult;
        }
    }
}
