// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Legacy appliance configuration to be returned by import legacy config cmdlet
    /// </summary>
    public class LegacyApplianceConfiguration
    {
        /// <summary>
        /// Gets or sets the unique identifier for the config which being imported
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Gets or sets the local time at which config is imported
        /// </summary>
        public DateTime ImportedOn { get; set; }

        /// <summary>
        /// Get or sets the name of the config file which is imported
        /// </summary>
        public string ConfigFile { get; set; }

        /// <summary>
        /// Gets or sets the name of target appliance 
        /// </summary>
        public string TargetApplianceName { get; set; }

        /// <summary>
        /// Gets or sets the config metadata from legacy appliance which needs to be migrated
        /// </summary>
        public LegacyApplianceDetails Details { get; set; }

        /// <summary>
        /// Gets or sets the o/p result of import config
        /// </summary>
        public string Result { get; set; }
    }
}