// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Indicates that it may be possible to retry the Job. If retry is unsuccessful, please contact Azure support via Azure Portal. </summary>
    [CodeGenModel("MediaJobRetry")]
    public enum MediaJobRetry
    {
        /// <summary> Issue needs to be investigated and then the job resubmitted with corrections or retried once the underlying issue has been corrected. </summary>
        DoNotRetry,
        /// <summary> Issue may be resolved after waiting for a period of time and resubmitting the same Job. </summary>
        MayRetry
    }
}
