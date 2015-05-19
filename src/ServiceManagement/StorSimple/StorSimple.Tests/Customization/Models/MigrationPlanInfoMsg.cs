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
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Management.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Migration plan per volume container 
    /// </summary>
    public class MigrationPlanInfoMsg : MigrationCommonModelFormatter
    {
        /// <summary>
        /// Gets or sets the bandwidth available (in MBps) while computing the estimate
        /// </summary>
        public int AssumedBandwidthInMbps { get; set; }

        /// <summary>
        /// Gets or sets the volume container for which the estimated is done
        /// </summary>
        public string CloudConfigurationName { get; set; }

        /// <summary>
        /// Gets or sets the estimated time for entire backup sets of the given volume container to migrate
        /// </summary>
        public TimeSpan EstimatedTimeForAllBackups { get; set; }

        /// <summary>
        /// Gets or sets the estimated time for migration of the largest backup in the given volume container
        /// </summary>
        public TimeSpan EstimatedTimeForLargestBackup { get; set; }

        /// <summary>
        /// Gets or sets the message/recommendation returned while estimating the plan
        /// </summary>
        public string PlanMessageInfo { get; set; }

        /// <summary>
        /// Status of migration plan
        /// </summary>
        public MigrationPlanStatus Status { get; set; }

        /// <summary>
        /// Constructs the migration plan, from the actual plan returned from service
        /// </summary>
        /// <param name="migrationPlanInfo">migration plan</param>
        public MigrationPlanInfoMsg(MigrationPlanInfo migrationPlanInfo)
        {
            AssumedBandwidthInMbps = migrationPlanInfo.AssumedBandwidthInMbps;
            CloudConfigurationName = migrationPlanInfo.DataContainerName;
            EstimatedTimeForAllBackups = new TimeSpan(0, migrationPlanInfo.EstimatedTimeInMinutes, 0);
            EstimatedTimeForLargestBackup = new TimeSpan(0, migrationPlanInfo.EstimatedTimeInMinutesForLargestBackup, 0);
            PlanMessageInfo = GetPlanMessageInfo(new List<HcsMessageInfo>(migrationPlanInfo.PlanMessageInfoList));
            Status = migrationPlanInfo.PlanStatus;
        }

        /// <summary>
        /// Prepares the recommendations/messages from the service
        /// </summary>
        /// <param name="planMessageInfoList">message from service</param>
        /// <returns>Recommendations/Messages from the service</returns>
        private string GetPlanMessageInfo(List<HcsMessageInfo> planMessageInfoList)
        {
            StringBuilder consoleOp = new StringBuilder();
            foreach (var hcsMessageInfo in planMessageInfoList)
            {
                string consoleStrOp = HcsMessageInfoToString(hcsMessageInfo);
                if (!string.IsNullOrEmpty(consoleStrOp))
                {
                    consoleOp.AppendLine(consoleStrOp);
                }
            }

            return consoleOp.ToString();
        }

        /// <summary>
        /// Converts the migration plan per data container to a string of desired format
        /// </summary>
        /// <returns>The string representation of per data container migration plan in desired format</returns>
        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            consoleOp.Append(
                this.IntendAndConCat("CloudConfigurationName", CloudConfigurationName));

            consoleOp.AppendLine();
            consoleOp.AppendLine(
                this.IntendAndConCat("EstimatedTimeForLatestBackup", FormatTimeSpan(EstimatedTimeForLargestBackup)));
            consoleOp.AppendLine(
                this.IntendAndConCat("EstimatedTimeForAllBackups", FormatTimeSpan(EstimatedTimeForAllBackups)));

            if (!string.IsNullOrEmpty(PlanMessageInfo))
            {
                consoleOp.AppendLine(
                    this.IntendAndConCat("PlanMessageInfo", PlanMessageInfo));
            }

            if (MigrationPlanStatus.Completed == Status)
            {
                consoleOp.AppendLine(string.Format(Resources.MigrationTimeEstimationBWMsg, (AssumedBandwidthInMbps/8)));
            }


            return consoleOp.ToString();
        }
    }
}