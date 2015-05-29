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
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

namespace Microsoft.WindowsAzure.Management.StorSimple
{
    /// <summary>
    /// Class represents the list of migration plan in a particular status
    /// </summary>
    public class MigrationPlanInfoMsgList : MigrationCommonModelFormatter
    {
        /// <summary>
        /// Gets or sets the list of migration plan in the given state
        /// </summary>
        public List<MigrationPlanInfoMsg> MigrationTimeEstimationInfoList { get; set; }

        /// <summary>
        /// Gets or sets the migration estimation state
        /// </summary>
        public MigrationPlanStatus MigrationTimeEstimationStatus { get; set; }

        /// <summary>
        /// Constructs MigrationPlanInfoMsgList of specified migration plan status
        /// </summary>
        /// <param name="status">migration plan status</param>
        public MigrationPlanInfoMsgList(MigrationPlanStatus status)
        {
            this.MigrationTimeEstimationStatus = status;
            this.MigrationTimeEstimationInfoList = new List<MigrationPlanInfoMsg>();
        }

        /// <summary>
        /// Converts migration plan list to string desired format
        /// </summary>
        /// <returns>migration plan list to string desired format</returns>
        public override string ToString()
        {
            StringBuilder consoleOp = new StringBuilder();
            if (null != MigrationTimeEstimationInfoList && 0 < MigrationTimeEstimationInfoList.Count)
            {
                if (MigrationPlanStatus.NotStarted == MigrationTimeEstimationStatus ||
                    MigrationPlanStatus.InProgress == MigrationTimeEstimationStatus)
                {
                    List<string> volumeContainerNameList =
                        MigrationTimeEstimationInfoList.Select(dc => dc.CloudConfigurationName).ToList();
                    consoleOp.AppendLine("CloudConfigurationName(s) : " + ConcatStringList(volumeContainerNameList));
                }
                else
                {
                    foreach (var migrationPlanInfoMsg in MigrationTimeEstimationInfoList)
                    {
                        consoleOp.AppendLine(migrationPlanInfoMsg.ToString());
                    }
                }
            }
            else
            {
                consoleOp.Append("None");
            }

            return consoleOp.ToString();
        }
    }
}