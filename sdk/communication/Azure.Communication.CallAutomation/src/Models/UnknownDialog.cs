// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The UnknownBaseDialog. </summary>
    [CodeGenModel("UnknownBaseDialog")]
    internal partial class UnknownDialog : BaseDialog
    {
        /// <summary> Initializes a new instance of UnknownBaseDialog. </summary>
        /// <param name="kind"> Determines the type of the dialog. </param>
        /// <param name="context"> Dialog context. </param>
        internal UnknownDialog(DialogInputType kind, IDictionary<string, object> context) : base(kind, context)
        {
        }
    }
}
