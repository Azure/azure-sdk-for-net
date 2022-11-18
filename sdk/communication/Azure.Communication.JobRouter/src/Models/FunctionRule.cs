// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("FunctionRule")]
    [CodeGenSuppress("FunctionRule")]
    [CodeGenSuppress("FunctionRule", typeof(string))]
    public partial class FunctionRule : RouterRule
    {
        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUri"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUri"/> is null. </exception>
        public FunctionRule(Uri functionAppUri)
            : this(null, functionAppUri, null)
        {
            if (functionAppUri == null)
            {
                throw new ArgumentNullException(nameof(functionAppUri), "cannot be set to empty or null");
            }
        }

        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUri"> URL for custom azure function. </param>
        /// <param name="credential"> Access credentials to Azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUri"/> is null. </exception>
        public FunctionRule(Uri functionAppUri, FunctionRuleCredential credential)
            : this(null, functionAppUri, credential)
        {
            if (functionAppUri == null)
            {
                throw new ArgumentNullException(nameof(functionAppUri), "cannot be set to empty or null");
            }
        }

        internal static void ValidateUrl(string urlEndpoint)
        {
            try
            {
                var uri = new Uri(urlEndpoint);
            }
            catch (UriFormatException e)
            {
                throw e;
            }
        }
    }
}
