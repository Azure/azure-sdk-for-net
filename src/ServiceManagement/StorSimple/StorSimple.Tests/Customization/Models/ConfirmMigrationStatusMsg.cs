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
    /// Overall Confirm Migration status msg for a specific config
    /// </summary>
    public class ConfirmMigrationStatusMsg
    {
        /// <summary>
        /// Gets or sets the config id whose volume container confirm status is fetched
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Commit Completed state
        /// </summary>
        public ConfirmMigrationStatus CommitComplete { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Commit inprogress state
        /// </summary>
        public ConfirmMigrationStatus CommitInProgress { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Commit failed state
        /// </summary>
        public ConfirmMigrationStatus CommitFailed { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Rollback completed state
        /// </summary>
        public ConfirmMigrationStatus RollbackComplete { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Rollback inprogress state
        /// </summary>
        public ConfirmMigrationStatus RollbackInProgress { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Rollback failed state
        /// </summary>
        public ConfirmMigrationStatus RollbackFailed { get; set; }

        /// <summary>
        /// Get or sets the overall confirm volume container status for the volume container(s) in Commit/Rollback not started state
        /// </summary>
        public ConfirmMigrationStatus CommitOrRollbackNotStarted { get; set; }

        /// <summary>
        /// Constructs ConfirmMigrationStatusMsg to be returned as an output of Get-AzureStorSimpleVolumeContainerConfirmStatus cmdlet
        /// </summary>
        /// <param name="configID">config id</param>
        /// <param name="overallStatus">overall status of migration</param>
        public ConfirmMigrationStatusMsg(string configID, MigrationConfirmStatus overallStatus)
        {
            this.LegacyConfigId = configID;
            this.CommitOrRollbackNotStarted =
                new ConfirmMigrationStatus(
                    ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitOrRollbackNotStarted,
                    overallStatus);

            this.CommitInProgress =
                new ConfirmMigrationStatus(
                    ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitInProgress, overallStatus);
            this.CommitFailed =
                new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitFailed,
                    overallStatus);
            this.CommitComplete =
                new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.CommitComplete,
                    overallStatus);

            this.RollbackInProgress =
                new ConfirmMigrationStatus(
                    ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackInProgress, overallStatus);
            this.RollbackFailed =
                new ConfirmMigrationStatus(ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackFailed,
                    overallStatus);
            this.RollbackComplete =
                new ConfirmMigrationStatus(
                    ConfirmMigrationStatus.MigrationVolumeContainerConfirmStatus.RollbackComplete, overallStatus);
        }
    }
}