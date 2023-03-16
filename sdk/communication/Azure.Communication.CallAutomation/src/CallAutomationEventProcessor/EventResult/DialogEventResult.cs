// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="DialogEventResult"/> is returned from WaitForEvent of <see cref="PlayResult"/>.</summary>
    public class DialogEventResult : EventResultBase
    {
        /// <summary>
        /// <see cref="DialogCompleted"/> event will be returned once the dialog is completed successfully.
        /// </summary>
        public DialogCompleted DialogCompletedSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogConsent"/> event will be returned once the dialog consent is received.
        /// </summary>
        public DialogConsent DialogConsentSuccessEvent { get; }

        /// <summary>
        /// <see cref="DialogFailed"/> event will be returned once the dialog failed.
        /// </summary>
        public DialogFailed FailureEvent { get; }

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

        internal DialogEventResult(
            bool isSuccessEvent,
            DialogCompleted successEvent,
            DialogConsent dialogConsentSuccessEvent,
            DialogFailed failureEvent,
            DialogHangup dialogHangupSuccessEvent,
            DialogStarted dialogStartedSuccessEvent,
            DialogTransfer dialogTransferSuccessEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            DialogCompletedSuccessEvent = successEvent;
            FailureEvent = failureEvent;
            DialogConsentSuccessEvent = dialogConsentSuccessEvent;
            DialogHangupSuccessEvent = dialogHangupSuccessEvent;
            DialogStartedSuccessEvent = dialogStartedSuccessEvent;
            DialogTransferSuccessEvent = dialogTransferSuccessEvent;
        }
    }
}
