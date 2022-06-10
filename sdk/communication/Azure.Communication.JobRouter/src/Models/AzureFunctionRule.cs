// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("AzureFunctionRule")]
    [CodeGenSuppress("AzureFunctionRule", typeof(string))]
    public partial class AzureFunctionRule : RouterRule
    {
        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUrl"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUrl"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="functionAppUrl"/> is empty. </exception>
        public AzureFunctionRule(string functionAppUrl)
            : this(null, functionAppUrl, null)
        {
            Argument.AssertNotNullOrWhiteSpace(functionAppUrl, nameof(functionAppUrl));
            ValidateUrl(functionAppUrl);
        }

        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUrl"> URL for custom azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUrl"/> is null. </exception>
        public AzureFunctionRule(Uri functionAppUrl)
            : this(null, functionAppUrl?.AbsoluteUri, null)
        {
            if (functionAppUrl == null)
            {
                throw new ArgumentNullException(nameof(functionAppUrl), "cannot be set to empty or null");
            }
        }

        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUrl"> URL for custom azure function. </param>
        /// <param name="credential"> Access credentials to Azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUrl"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="functionAppUrl"/> is empty. </exception>
        public AzureFunctionRule(string functionAppUrl, AzureFunctionRuleCredential credential)
            : this(null, functionAppUrl, credential)
        {
            Argument.AssertNotNullOrWhiteSpace(functionAppUrl, nameof(functionAppUrl));
            ValidateUrl(functionAppUrl);
        }

        /// <summary> Initializes a new instance of AzureFunctionRule. </summary>
        /// <param name="functionAppUrl"> URL for custom azure function. </param>
        /// <param name="credential"> Access credentials to Azure function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionAppUrl"/> is null. </exception>
        public AzureFunctionRule(Uri functionAppUrl, AzureFunctionRuleCredential credential)
            : this(null, functionAppUrl?.AbsoluteUri, credential)
        {
            if (functionAppUrl == null)
            {
                throw new ArgumentNullException(nameof(functionAppUrl), "cannot be set to empty or null");
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
