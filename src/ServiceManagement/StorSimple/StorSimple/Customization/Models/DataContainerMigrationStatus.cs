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

using System.Collections.Generic;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Volume container migration status for the containers imported by the specific config
    /// </summary>
    public class DataContainerMigrationStatus
    {
        /// <summary>
        /// Gets or sets the config id whose volume container confirm status is fetched
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state for all volume containers whose MigrationState is Completed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationCompleted { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state for all volume containers whose MigrationState is InProgress
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationInprogress { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state for all volume containers whose MigrationState is Failed
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationFailed { get; set; }

        /// <summary>
        /// Gets or sets the list of migration state for all volume containers whose MigrationState is NotStarted
        /// </summary>
        public LegacyDataContainerMigrationStatus MigrationNotStarted { get; set; }

        /// <summary>
        /// Constructs the overall volume container migration status object
        /// </summary>
        /// <param name="configId">ConfigId corresponding to current instance of migration</param>
        /// <param name="overallStatusList">Overall list of status obtained from service</param>
        public DataContainerMigrationStatus(string configId, List<MigrationDataContainerStatus> overallStatusList)
        {
            this.LegacyConfigId = configId;
            this.MigrationNotStarted = new LegacyDataContainerMigrationStatus(overallStatusList,
                MigrationStatus.NotStarted);
            this.MigrationInprogress = new LegacyDataContainerMigrationStatus(overallStatusList,
                MigrationStatus.InProgress);
            this.MigrationFailed = new LegacyDataContainerMigrationStatus(overallStatusList, MigrationStatus.Failed);
            this.MigrationCompleted = new LegacyDataContainerMigrationStatus(overallStatusList,
                MigrationStatus.Completed);
        }

    }
}