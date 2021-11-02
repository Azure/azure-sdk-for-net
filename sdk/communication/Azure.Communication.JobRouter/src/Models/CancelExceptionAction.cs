// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter.Models
{
    public partial class CancelExceptionAction
    {
        /// <summary> Initializes a new instance of CancelExceptionAction. </summary>
        /// <param name="id"> Unique Id of the action within the exception rule. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., cancellation reason. </param>
        /// <param name="dispositionCode"> (Optional) Customer supplied disposition code for specifying any short label. </param>
        public CancelExceptionAction(string id, string note = default, string dispositionCode = default) : this(null, id, note, dispositionCode)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
        }
    }
}
