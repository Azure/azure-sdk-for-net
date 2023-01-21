// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary><see cref="CancelAllMediaOperationsEventResult"/> is returned from WaitForEvent of <see cref="CancelAllMediaOperationsResult"/>.</summary>
    public class CancelAllMediaOperationsEventResult : EventResultBase
    {
        /// <summary>
        /// <see cref="PlayCanceled"/> event will be returned when the play is successfully cancelled.
        /// </summary>
        public PlayCanceled PlayCanceledSucessEvent { get; }

        /// <summary>
        /// <see cref="RecognizeCanceled"/> event will be returned when the Recognize is successfully cancelled.
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
