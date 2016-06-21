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

using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace RecoveryServices.Backup.Tests.Helpers
{
    public class RecoveryPointTestHelpers
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public RecoveryPointTestHelpers(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public List<RecoveryPointResource> ListRecoveryPoints(string resourceGroupName, string resourceName, string containerUri, string itemUri, DateTime backupStartTime, DateTime backupEndTime)
        {
            string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
            string utcDateTimeFormat = ConfigurationManager.AppSettings["UTCDateTimeFormat"];

            RecoveryPointQueryParameters queryFilter = new RecoveryPointQueryParameters();
            queryFilter.StartDate = backupStartTime.ToString(utcDateTimeFormat);
            queryFilter.EndDate = backupEndTime.ToString(utcDateTimeFormat);
            var response = Client.RecoveryPoints.List(
                resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(), fabricName, containerUri, itemUri, queryFilter);

            return response.RecoveryPointList.RecoveryPoints.ToList();
        }

        public RecoveryPointResource GetRecoveryPointDetails(string resourceGroupName, string resourceName, string containerUri, string itemUri, string recoveryPointId)
        {
            string fabricName = ConfigurationManager.AppSettings["AzureBackupFabricName"];
            var response = Client.RecoveryPoints.Get(
                resourceGroupName, resourceName, CommonTestHelper.GetCustomRequestHeaders(), fabricName, containerUri, itemUri, recoveryPointId);
            return response.RecPoint;
        }
    }
}
