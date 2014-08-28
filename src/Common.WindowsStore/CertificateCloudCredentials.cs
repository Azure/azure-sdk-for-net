//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Credentials using a management certificate from the app store to authorize requests.
    /// </summary>
    public sealed class CertificateCloudCredentials
        : SubscriptionCloudCredentials
    {
        // The Microsoft Azure Subscription ID.
        private readonly string _subscriptionId = null;

        /// <summary>
        /// Gets subscription ID which uniquely identifies Microsoft Azure 
        /// subscription. The subscription ID forms part of the URI for 
        /// every call that you make to the Service Management API.
        /// </summary>
        public override string SubscriptionId
        {
            get { return _subscriptionId; }
        }

        /// <summary>
        /// Initializes a new instance of the CertificateCloudCredentials
        /// class.
        /// </summary>
        /// <param name="subscriptionId">The Subscription ID.</param>
        public CertificateCloudCredentials(string subscriptionId)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            else if (subscriptionId.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("subscriptionId");
            }

            _subscriptionId = subscriptionId;
        }

        /// <summary>
        /// Attempt to create certificate credentials from a collection of
        /// settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>
        /// CertificateCloudCredentials is created, null otherwise.
        /// </returns>
        public static CertificateCloudCredentials Create(IDictionary<string, object> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            string subscriptionId = ConfigurationHelper.GetString(settings, "SubscriptionId", false);

            if (subscriptionId != null)
            {
                return new CertificateCloudCredentials(subscriptionId);
            }

            return null;
        }
    }
}
