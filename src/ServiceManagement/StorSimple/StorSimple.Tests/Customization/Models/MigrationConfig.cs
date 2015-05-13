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

using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Represents the o/p of get all migration plan
    /// </summary>
    public class MigrationConfig
    {
        /// <summary>
        /// Gets or sets Config uploaded
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Gets or sets the target device name associated with config uploaded
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Constructs the migration config(s) imported
        /// </summary>
        /// <param name="migrationPlan">Migration Plan</param>
        public MigrationConfig(MigrationPlan migrationPlan)
        {
            LegacyConfigId = migrationPlan.ConfigId;
            DeviceName = migrationPlan.DeviceName;
        }
    }
}