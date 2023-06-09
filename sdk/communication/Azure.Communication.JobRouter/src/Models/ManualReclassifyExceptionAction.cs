// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ManualReclassifyExceptionAction")]
    [CodeGenSuppress("ManualReclassifyExceptionAction")]
    [CodeGenSuppress("ManualReclassifyExceptionAction", typeof(string))]
    public partial class ManualReclassifyExceptionAction
    {
        /// <summary> Initializes a new instance of ManualReclassifyExceptionAction. </summary>
        public ManualReclassifyExceptionAction() : this(null, null, null, Array.Empty<WorkerSelector>().ToList())
        {
        }
    }
}
