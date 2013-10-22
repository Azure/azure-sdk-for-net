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

namespace Microsoft.WindowsAzure.Common.Platform
{
    /// <summary>
    /// A cloud credentials provider.
    /// </summary>
    public interface ICloudCredentialsProvider
    {
        /// <summary>
        /// Creates a new credentials instance if the appropriate settings for
        /// this provider are present and valid.
        /// </summary>
        /// <param name="settings">Dictionary of configuration settings.</param>
        /// <returns>Returns a new instance if the provider supports the
        /// provided settings.</returns>
        CloudCredentials CreateCredentials(IDictionary<string, object> settings);
    }
}
