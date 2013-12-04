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
using System.Net.Http;
using Microsoft.WindowsAzure.Common;

namespace Microsoft.WindowsAzure
{
    /// <summary>
    /// Base class for credentials associated with a particular subscription.
    /// </summary>
    public abstract class SubscriptionCloudCredentials
        : CloudCredentials
    {
        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management API.
        /// </summary>
        public abstract string SubscriptionId { get; }
    }
}
