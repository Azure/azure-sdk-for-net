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
    [CodeGenModel("AzureOpenAIDialogUpdate")]
    [CodeGenSuppress("AzureOpenAIDialogUpdate")]
    public partial class AzureOpenAIDialogUpdate : DialogUpdateBase
    {
        /// <summary> Initializes a new instance of AzureOpenAIDialogInternal. </summary>
        /// <param name="context"> Dialog context. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="context"/> is null. </exception>
        public AzureOpenAIDialogUpdate(IDictionary<string, object> context) : base(DialogInputType.AzureOpenAI)
        {
            Argument.AssertNotNull(context, nameof(context));

            Context = context;
        }

        internal AzureOpenAIDialogUpdate(DialogInputType kind, IDictionary<string, object> context) : base(DialogInputType.AzureOpenAI, context)
        {
        }
    }
}
