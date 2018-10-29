// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure
{
    /// <summary>
    /// Class for token based credentials associated with a particular subscription.
    /// </summary>
    public class AnonymousCloudCredentials : SubscriptionCloudCredentials
    {
        /// <summary>
        /// Gets an empty subscription Id.
        /// </summary>
        public override string SubscriptionId
        {
            get { return string.Empty; }
        }
    }
}
