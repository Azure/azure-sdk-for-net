// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Analytics.Purview.Administration
{
    [CodeGenClient("AccountsClient")]
    public partial class PurviewAccountClient
    {
        /// <summary>
        /// Gets a service client for interacting with a collection.
        /// </summary>
        /// <param name="collectionName">The name of the collection to use.</param>
        /// <returns>A service client for interacting with a collection.</returns>
        public virtual PurviewCollection GetCollectionClient(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            return new PurviewCollection(ClientDiagnostics, Pipeline, _tokenCredential, _endpoint, collectionName);
        }

        /// <summary>
        /// Gets a service client for interacting with a resource set rule.
        /// </summary>
        /// <returns>A service client for interacting with a resource set rule.</returns>
        public virtual PurviewResourceSetRule GetResourceSetRuleClient()
        {
            return new PurviewResourceSetRule(ClientDiagnostics, Pipeline, _tokenCredential, _endpoint);
        }
    }
}
