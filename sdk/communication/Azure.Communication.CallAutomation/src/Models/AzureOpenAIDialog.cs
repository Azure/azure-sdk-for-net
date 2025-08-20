// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The AzureOpenAIDialog. </summary>
    [CodeGenModel("AzureOpenAIDialog")]
    [CodeGenSuppress("AzureOpenAIDialog")]
    public partial class AzureOpenAIDialog : BaseDialog
    {
        /// <summary> Initializes a new instance of AzureOpenAIDialogInternal. </summary>
        /// <param name="context"> Dialog context. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        public AzureOpenAIDialog(IDictionary<string, object> context) : base(DialogInputType.AzureOpenAI)
        {
            Argument.AssertNotNull(context, nameof(context));

            Context = context;
        }

        internal AzureOpenAIDialog(DialogInputType kind, IDictionary<string, object> context) : base(DialogInputType.AzureOpenAI, context)
        {
        }
    }
}
