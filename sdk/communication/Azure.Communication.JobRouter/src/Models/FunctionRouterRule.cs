// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("FunctionRouterRule")]
    [CodeGenSuppress("FunctionRouterRule")]
    [CodeGenSuppress("FunctionRouterRule", typeof(string))]
    public partial class FunctionRouterRule : RouterRule
    {
        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUri"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUri"/> is null. </exception>
        public FunctionRouterRule(Uri functionAppUri)
            : this(null, functionAppUri, null)
        {
            if (functionAppUri == null)
            {
                throw new ArgumentNullException(nameof(functionAppUri), "cannot be set to empty or null");
            }
        }

        internal Uri FunctionUri { get; set; }
    }
}
