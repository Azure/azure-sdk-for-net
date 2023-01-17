// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// <summary> CancelAllMediaOperationsEventResult is returned from WaitForEvent of CancelAllMediaOperationsResult. </summary>
    /// </summary>
    public class CancelAllMediaOperationsEventResult : EventResultBase
    {
        /// <summary>
        /// PlayCanceled event will be returned when the play is successfully cancelled.
        /// </summary>
        public PlayCanceled PlayCanceledSucessEvent { get; }

        /// <summary>
        /// PlayCanceled event will be returned when the Recognize is successfully cancelled.
        /// </summary>
        public RecognizeCanceled RecognizeCanceledSucessEvent { get; }

        internal CancelAllMediaOperationsEventResult(bool isSuccessEvent, PlayCanceled playCanceledSucessEvent, RecognizeCanceled recognizeCanceledSucessEvent)
        {
            IsSuccessEvent = isSuccessEvent;
            PlayCanceledSucessEvent = playCanceledSucessEvent;
            RecognizeCanceledSucessEvent = recognizeCanceledSucessEvent;
        }
    }
}
