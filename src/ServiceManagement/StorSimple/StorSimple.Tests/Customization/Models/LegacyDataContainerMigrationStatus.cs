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
using Microsoft.WindowsAzure.Management.StorSimple.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Status migration for all data containers in one particular Migration state
    /// </summary>
    public class LegacyDataContainerMigrationStatus : MigrationCommonModelFormatter
    {
        /// <summary>
        /// List of migration status for the volume containers in the given migration state 
        /// </summary>
        public List<MigrationDataContainerStatus> StatusList { get; set; }

        /// <summary>
        /// Specified migration state
        /// </summary>
        private MigrationStatus migrationState;

        /// <summary>
        /// Constructor - Constructs LegacyDataContainerMigrationStatus object of given MigrationStatus, 
        /// by filtering from overall status list provided 
        /// </summary>
        /// <param name="overallStatusList">overall migration status</param>
        /// <param name="type">MigrationStatus of the list of stored</param>
        public LegacyDataContainerMigrationStatus(List<MigrationDataContainerStatus> overallStatusList,
            MigrationStatus type)
        {
            this.StatusList = new List<MigrationDataContainerStatus>();
            this.migrationState = type;
            if (null != overallStatusList)
            {
                this.StatusList.AddRange(overallStatusList.FindAll(status => type == status.Status));
            }
        }

        /// <summary>
        /// Converts migration status to the desired formatted string
        /// </summary>
        /// <returns>Migration status as string in desired format</returns>
        public override string ToString()
        {
            try
            {
                StringBuilder consoleop = new StringBuilder();
                if (null != this.StatusList && 0 < this.StatusList.Count)
                {
                    if (MigrationStatus.NotStarted == migrationState)
                    {
                        List<string> volumeContainerNameList =
                            StatusList.Select(dc => dc.CloudConfigurationName).ToList();
                        consoleop.AppendLine("CloudConfigurationName(s) : " + ConcatStringList(volumeContainerNameList));
                    }
                    else
                    {
                        foreach (var status in this.StatusList)
                        {
                            int maxLength = status.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                            consoleop.AppendLine(IntendAndConCat("CloudConfigurationName", status.CloudConfigurationName,
                                maxLength));
                            consoleop.AppendLine(IntendAndConCat("PercentageCompleted", status.PercentageCompleted,
                                maxLength));
                            consoleop.AppendLine(IntendAndConCat("MigrationStatus", status.Status.ToString(), maxLength));
                            if (null != status.BackupSets && 0 < status.BackupSets.Count)
                            {
                                consoleop.AppendLine(IntendAndConCat("BackupSets", string.Empty, maxLength));
                                foreach (MigrationBackupSet backupSet in status.BackupSets)
                                {
                                    consoleop.AppendLine(string.Format("\tPolicy : {0}, Created On : {1}, Status : {2}",
                                        backupSet.BackupPolicyName,
                                        backupSet.CreationTime.ToString("MM/dd/yyyy HH:mm:ss"),
                                        backupSet.Status.ToString()));
                                    string consoleStrOp = this.HcsMessageInfoToString(backupSet.Message);
                                    if (!string.IsNullOrEmpty(consoleStrOp))
                                    {
                                        consoleop.AppendLine("\t");
                                        consoleop.AppendLine(consoleStrOp);
                                    }
                                }
                            }
                            else
                            {
                                consoleop.AppendLine(Resources.MigrationBackupSetNotFound);
                            }

                            string statusStrOp = this.HcsMessageInfoToString(status.MessageInfo);
                            if (!string.IsNullOrEmpty(statusStrOp))
                            {
                                consoleop.AppendLine(IntendAndConCat("Messages", statusStrOp, maxLength));
                            }

                            consoleop.AppendLine();
                        }
                    }
                }
                else
                {
                    return string.Format(Resources.MigrationNoDataContainerInGivenStateOfMigration,
                        this.migrationState.ToString());
                }

                return consoleop.ToString();
            }
            catch (Exception)
            {
                // powershell will consume the exception, and no details will be displayed if the exception is thrown, hence handling and returning error string.
                return Resources.MigrationErrorInParsingDisplayContent;
            }
        }
    }
}