// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The base object for DialogUpdate. </summary>
    [CodeGenModel("DialogUpdateBase")]
    public abstract partial class DialogUpdateBase
    {
        /// <summary> Initializes a new instance of DialogUpdateBase. </summary>
        /// <param name="kind"> Determines the type of the dialog. </param>
        internal DialogUpdateBase(DialogInputType kind)
        {
            Kind = kind;
        }

        /// <summary> Determines the type of the dialog. </summary>
        internal DialogInputType Kind { get; }

        /// <summary> Dialog context. </summary>
        public IDictionary<string, object> Context { get; set; }
    }
}
