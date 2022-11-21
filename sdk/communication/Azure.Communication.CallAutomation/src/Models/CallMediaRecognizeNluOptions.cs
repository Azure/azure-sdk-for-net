// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for Nlu.
    /// </summary>
    public class CallMediaRecognizeNluOptions : CallMediaRecognizeOptions
    {
        /// <summary> Initializes a new instance of CallMediaRecognizeDtmfOptions. </summary>
        public CallMediaRecognizeNluOptions(NluRecognizer nluRecognizer) : base(RecognizeInputType.Nlu, null)
        {
            NluRecognizer = nluRecognizer;
        }

        /// <summary>
        /// True if using LUIS for NLU, otherwise defaults to Nuance.
        /// </summary>
        public NluRecognizer NluRecognizer { get; }

        /// <summary>
        /// Uri to send NLU results.
        /// </summary>
        public Uri CallbackUri { get; set; }

        /// <summary>
        /// Whether to play dialog response from NLU as audio.
        /// </summary>
        public bool PlayDialog { get; set; }

        /// <summary>
        /// Whether to play intent as audio.
        /// </summary>
        public bool PlayIntent { get; set; }
    }
}
