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

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Helper class used for deserialization of OLEDB Connection Strings.
    /// </summary>
    internal class ConnectionStringSettingsFormat : ICloudSettingsFormat
    {
        /// <summary>
        /// Gets the setting name.
        /// </summary>
        public string Name
        {
            get { return "connection"; }
        }

        /// <summary>
        /// Deserializes OLEDB Connection String.
        /// </summary>
        /// <param name="settings">OLEDB Connection String.</param>
        /// <returns>Dictionary representation of the Connection String.</returns>
        public IDictionary<string, object> Parse(string settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            else if (settings.Length == 0)
            {
                throw CloudExtensions.CreateArgumentEmptyException("settings");
            }

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string> setting in ConnectionStringParser.Parse(settings))
            {
                parameters[setting.Key] = setting.Value;
            }
            return parameters;
        }
    }
}
