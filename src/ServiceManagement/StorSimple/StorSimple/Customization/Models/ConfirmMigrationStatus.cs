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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Class represents the List of ConfirmStatus for all data containers in a specific MigrationVolumeContainerConfirmStatus status
    /// </summary>
    public class ConfirmMigrationStatus : MigrationCommonModelFormatter
    {
        /// <summary>
        /// Gets or sets the list of confirmation status for volume container(s) in specified confirm state
        /// </summary>
        public List<MigrationContainerConfirmStatus> ConfirmStatus { get; set; }

        /// <summary>
        /// Gets or sets the confirm migration state
        /// </summary>
        public MigrationVolumeContainerConfirmStatus Status { get; set; }

        /// <summary>
        /// Constructor - Constructs ConfirmMigrationStatus object of given statusType specified, 
        /// by filtering from overallstatus list provided 
        /// </summary>
        /// <param name="statusType">MigrationStatus of the list of stored</param>
        /// <param name="overallStatus">overall migration status</param>        
        public ConfirmMigrationStatus(MigrationVolumeContainerConfirmStatus statusType,
            MigrationConfirmStatus overallStatus)
        {
            this.Status = statusType;
            if (null != overallStatus)
            {
                var statusList = new List<MigrationContainerConfirmStatus>(overallStatus.ContainerConfirmStatus);
                this.ConfirmStatus =
                    statusList.FindAll(status => GetMigrationVolumeContainerConfirmStatus(status.Status) == statusType);
            }
            else
            {
                this.ConfirmStatus = new List<MigrationContainerConfirmStatus>();
            }
        }

        /// <summary>
        /// Volume container Confirm migration status enums
        /// </summary>
        public enum MigrationVolumeContainerConfirmStatus
        {
            CommitOrRollbackNotStarted,
            CommitInProgress,
            CommitComplete,
            CommitFailed,
            RollbackInProgress,
            RollbackComplete,
            RollbackFailed,
        }

        /// <summary>
        /// Maps service enum to MigrationVolumeContainerConfirmStatus
        /// </summary>
        /// <param name="status">service confirm status enum</param>
        /// <returns>MigrationVolumeContainerConfirmStatus enum value corresponding to given service status</returns>
        private MigrationVolumeContainerConfirmStatus GetMigrationVolumeContainerConfirmStatus(
            MigrationDataContainerConfirmStatus status)
        {
            switch (status)
            {
                case MigrationDataContainerConfirmStatus.MigrationNotStarted:
                case MigrationDataContainerConfirmStatus.MigrationInProgress:
                case MigrationDataContainerConfirmStatus.MigrationComplete:
                case MigrationDataContainerConfirmStatus.MigrationFailed:
                {
                    return MigrationVolumeContainerConfirmStatus.CommitOrRollbackNotStarted;
                }
                case MigrationDataContainerConfirmStatus.CommitInProgress:
                {
                    return MigrationVolumeContainerConfirmStatus.CommitInProgress;
                }
                case MigrationDataContainerConfirmStatus.CommitComplete:
                {
                    return MigrationVolumeContainerConfirmStatus.CommitComplete;
                }
                case MigrationDataContainerConfirmStatus.CommitFailed:
                {
                    return MigrationVolumeContainerConfirmStatus.CommitFailed;
                }
                case MigrationDataContainerConfirmStatus.RollbackInProgress:
                {
                    return MigrationVolumeContainerConfirmStatus.RollbackInProgress;
                }
                case MigrationDataContainerConfirmStatus.RollbackComplete:
                {
                    return MigrationVolumeContainerConfirmStatus.RollbackComplete;
                }
                case MigrationDataContainerConfirmStatus.RollbackFailed:
                {
                    return MigrationVolumeContainerConfirmStatus.RollbackFailed;
                }
                default:
                {
                    throw new Exception("Migration Data Container Confirm Status not found.");
                }
            }
        }

        /// <summary>
        /// Compares two ContainerConfirmStatus based on status, used for sorting & group ContainerConfirmStatus based on their status
        /// </summary>
        private int CompareConfirmStatus(MigrationContainerConfirmStatus lhs, MigrationContainerConfirmStatus rhs)
        {
            return lhs.Status.CompareTo(rhs.Status);
        }

        /// <summary>
        /// Overridden to displays the content in the desired format
        /// </summary>
        /// <returns>String representing confirm migration status in desired format</returns>
        public override string ToString()
        {
            StringBuilder consoleop = new StringBuilder();
            if (null != ConfirmStatus && 0 < ConfirmStatus.Count)
            {
                if (MigrationVolumeContainerConfirmStatus.CommitOrRollbackNotStarted == Status)
                {
                    List<string> volumeContainerNameList =
                        ConfirmStatus.Select(dc => dc.CloudConfigurationName).ToList();
                    consoleop.AppendLine("CloudConfigurationName(s) : " + ConcatStringList(volumeContainerNameList));
                }
                else
                {
                    ConfirmStatus.Sort(CompareConfirmStatus);
                    foreach (var status in ConfirmStatus)
                    {
                        int maxLength = status.GetType().GetProperties().ToList().Max(t => t.Name.Length);
                        consoleop.AppendLine(
                            IntendAndConCat("CloudConfigurationName", status.CloudConfigurationName, maxLength));

                        consoleop.AppendLine(
                            IntendAndConCat("Operation", status.Operation, maxLength));
                        consoleop.AppendLine(
                            IntendAndConCat("PercentageCompleted", status.PercentageCompleted, maxLength));
                        if (null != status.StatusMessage && 0 < status.StatusMessage.Count)
                        {
                            consoleop.AppendLine(
                                IntendAndConCat("Messages", string.Empty, maxLength));
                            foreach (var msgInfo in status.StatusMessage)
                            {
                                string consoleStrOp = HcsMessageInfoToString(msgInfo);
                                if (!string.IsNullOrEmpty(consoleStrOp))
                                {
                                    consoleop.AppendLine("\t");
                                    consoleop.Append(consoleStrOp);
                                }
                            }
                        }

                        consoleop.AppendLine();
                    }
                }
            }
            else
            {
                consoleop.Append("None");
            }

            return consoleop.ToString();
        }
    }
}