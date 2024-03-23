// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class FunctionRouterRuleCredential
    {
        /// <summary> Initializes a new instance of AzureFunctionRuleCredential. </summary>
        /// <param name="functionKey"> Access key scoped to a particular function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="functionKey"/> is null. </exception>
        public FunctionRouterRuleCredential(string functionKey)
        {
            Argument.AssertNotNullOrWhiteSpace(functionKey, nameof(functionKey));
            FunctionKey = functionKey;
        }

        /// <summary> Initializes a new instance of AzureFunctionRuleCredential. </summary>
        /// <param name="appKey">
        /// Access key scoped to a Azure Function app.
        ///
        /// This key grants access to all functions under the app.
        /// </param>
        /// <param name="clientId">
        /// Client id, when AppKey is provided
        ///
        /// In context of Azure function, this is usually the name of the key.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="appKey"/> or <paramref name="clientId"/> is null. </exception>
        public FunctionRouterRuleCredential(string appKey, string clientId)
        {
            Argument.AssertNotNullOrWhiteSpace(appKey, nameof(appKey));
            Argument.AssertNotNullOrWhiteSpace(clientId, nameof(clientId));

            AppKey = appKey;
            ClientId = clientId;
        }

        /// <summary> Access key scoped to a particular function. </summary>
        internal string FunctionKey { get; }

        /// <summary>
        /// Access key scoped to a Azure Function app.
        /// This key grants access to all functions under the app.
        /// </summary>
        internal string AppKey { get; }

        /// <summary>
        /// Client id, when AppKey is provided
        /// In context of Azure function, this is usually the name of the key
        /// </summary>
        internal string ClientId { get; }
    }
}
