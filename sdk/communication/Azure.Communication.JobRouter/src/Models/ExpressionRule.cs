// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExpressionRule")]
    public partial class ExpressionRule : RouterRule
    {
        /// <summary> The available expression languages that can be configured. </summary>
        public string Language { get; }
    }
}
