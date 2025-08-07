// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary> Trigger for an exception action on exceeding queue length. </summary>
    public partial class QueueLengthExceptionTrigger
    {
        /// <summary> Initializes a new instance of QueueLengthExceptionTrigger. </summary>
        /// <param name="threshold"> Threshold of number of jobs queued to for this trigger. Must be greater than 0</param>
        public QueueLengthExceptionTrigger(int threshold)
        {
            Kind = ExceptionTriggerKind.QueueLength;
            Threshold = threshold;
        }
    }
}
