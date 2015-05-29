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
    /// Overall Migration plan for all data containers imported by the specific config
    /// </summary>
    public class MigrationPlanMsg
    {
        /// <summary>
        /// Gets or sets the unique identifier of config whose migration plan is fetched
        /// </summary>
        public string LegacyConfigId { get; set; }

        /// <summary>
        /// Gets or sets target device name
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets the plan(s) which are in completed state
        /// </summary>
        public MigrationPlanInfoMsgList MigrationTimeEstimationCompleted { get; set; }

        /// <summary>
        /// Gets or set the plan(s) which are in progress state
        /// </summary>
        public MigrationPlanInfoMsgList MigrationTimeEstimationInProgress { get; set; }

        /// <summary>
        /// Gets or sets the plan(s) which are in failed state
        /// </summary>
        public MigrationPlanInfoMsgList MigrationTimeEstimationFailed { get; set; }

        /// <summary>
        /// Gets or sets the plan(s) which are in not started state
        /// </summary>
        public MigrationPlanInfoMsgList MigrationTimeEstimationNotStarted { get; set; }

        /// <summary>
        /// Construct overall migration plan for a specified config
        /// </summary>
        /// <param name="migrationPlan"></param>
        public MigrationPlanMsg(MigrationPlan migrationPlan)
        {
            LegacyConfigId = migrationPlan.ConfigId;
            DeviceName = migrationPlan.DeviceName;
            MigrationTimeEstimationInProgress = new MigrationPlanInfoMsgList(MigrationPlanStatus.InProgress);
            MigrationTimeEstimationNotStarted = new MigrationPlanInfoMsgList(MigrationPlanStatus.NotStarted);
            MigrationTimeEstimationCompleted = new MigrationPlanInfoMsgList(MigrationPlanStatus.Completed);
            MigrationTimeEstimationFailed = new MigrationPlanInfoMsgList(MigrationPlanStatus.Failed);

            foreach (var migrationPlanInfo in migrationPlan.MigrationPlanInfo)
            {
                MigrationPlanInfoMsg migrationPlanInfoMsg = new MigrationPlanInfoMsg(migrationPlanInfo);

                if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.InProgress)
                {
                    MigrationTimeEstimationInProgress.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.NotStarted)
                {
                    MigrationTimeEstimationNotStarted.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Completed)
                {
                    MigrationTimeEstimationCompleted.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
                else if (migrationPlanInfo.PlanStatus == MigrationPlanStatus.Failed)
                {
                    MigrationTimeEstimationFailed.MigrationTimeEstimationInfoList.Add(migrationPlanInfoMsg);
                }
            }
        }
    }
}