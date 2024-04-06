// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public partial class CancelExceptionAction
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        public CancelExceptionAction()
        {
            Kind = ExceptionActionKind.Cancel;
        }

        /// <summary>
        /// A note that will be appended to the jobs' Notes collection with the
        /// current timestamp.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Indicates the outcome of the job, populate this field with your own
        /// custom values.
        /// </summary>
        public string DispositionCode { get; set; }
    }
}
