// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class FunctionRouterRule
    {
        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUri"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUri"/> is null. </exception>
        public FunctionRouterRule(Uri functionAppUri)
        {
            Argument.AssertNotNull(functionAppUri, nameof(functionAppUri));

            Kind = RouterRuleKind.Function;
            FunctionUri = functionAppUri;
        }

        /// <summary> Credentials used to access Azure function rule. </summary>
        public FunctionRouterRuleCredential Credential { get; set; }
    }
}
