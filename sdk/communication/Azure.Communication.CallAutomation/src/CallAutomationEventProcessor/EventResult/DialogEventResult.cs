// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="DialogEventResult"/> is returned from WaitForEvent of <see cref="DialogResult"/>.</summary>
    public class DialogEventResult
    {
        /// <summary>
        /// Indicates whether the returned event is considered successful or not.
        /// </summary>
        public bool IsSuccess { get; internal set; }
        /// <summary>
        /// <see cref="DialogCompleted"/> event will be returned once the dialog is completed successfully.
        /// </summary>
        public DialogCompleted DialogCompletedSuccessResult { get; }

        /// <summary>
        /// <see cref="DialogConsent"/> event will be returned once the dialog consent is received.
        /// </summary>
        public DialogConsent DialogConsentSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogFailed"/> event will be returned once the dialog failed.
        /// </summary>
        public DialogFailed FailureResult { get; }

        /// <summary>
        /// <see cref="DialogHangup"/> event will be returned once the dialog has hung up.
        /// </summary>
        public DialogHangup DialogHangupSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogStarted"/> event will be returned once the dialog has started.
        /// </summary>
        public DialogStarted DialogStartedSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogTransfer"/> event will be returned once the dialog has been transferred.
        /// </summary>
        public DialogTransfer DialogTransferSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogSensitivityUpdate"/> event will be returned once the dialog has its sensitivity updated.
        /// </summary>
        public DialogSensitivityUpdate DialogSensitivityUpdateEvent { get; }

        /// <summary>
        /// <see cref="DialogLanguageChange"/> event will be returned once the dialog has its language changed.
        /// </summary>
        public DialogLanguageChange DialogLanguageChangeEvent { get; }

        /// <summary>
        /// <see cref="DialogUpdated"/> event will be returned once the dialog has been updated
        /// </summary>
        public DialogUpdated DialogUpdatedEvent { get; }

        internal DialogEventResult(
            bool isSuccess,
            DialogCompleted successResult,
            DialogConsent dialogConsentSuccessEvent,
            DialogFailed failureResult,
            DialogHangup dialogHangupSuccessEvent,
            DialogStarted dialogStartedSuccessEvent,
            DialogTransfer dialogTransferSuccessEvent,
            DialogSensitivityUpdate dialogSensitivityUpdateEvent,
            DialogLanguageChange dialogLanguageChangeEvent,
            DialogUpdated dialogUpdatedEvent)
        {
            IsSuccess = isSuccess;
            DialogCompletedSuccessResult = successResult;
            FailureResult = failureResult;
            DialogConsentSuccessEvent = dialogConsentSuccessEvent;
            DialogHangupSuccessEvent = dialogHangupSuccessEvent;
            DialogStartedSuccessEvent = dialogStartedSuccessEvent;
            DialogTransferSuccessEvent = dialogTransferSuccessEvent;
            DialogSensitivityUpdateEvent = dialogSensitivityUpdateEvent;
            DialogLanguageChangeEvent = dialogLanguageChangeEvent;
            DialogUpdatedEvent = dialogUpdatedEvent;
        }
    }
}
