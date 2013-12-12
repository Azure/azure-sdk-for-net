﻿//
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
    /// Platform-specific interface enabling cloud configuration support.
    /// </summary>
    public interface ICloudConfigurationProvider
    {
        string GetSetting(string name);

        IDictionary<string, object> GetConnectionInfo(Type type, string name, out string settingsName, out string settingsValue);

        /// <summary>
        /// Registers platform-specific cloud configuration providers with the
        /// common runtime.
        /// </summary>
        void RegisterDefaultCloudCredentialsProviders();
    }
}
