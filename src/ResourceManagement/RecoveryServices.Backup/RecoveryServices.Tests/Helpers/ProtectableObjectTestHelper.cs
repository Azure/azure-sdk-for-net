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

using Microsoft.Azure;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecoveryServices.Tests.Helpers
{
    public class ProtectableObjectTestHelper
    {
        RecoveryServicesBackupManagementClient Client { get; set; }

        public ProtectableObjectTestHelper(RecoveryServicesBackupManagementClient client)
        {
            Client = client;
        }

        public ProtectableObjectListResponse ListProtectableObjects(ProtectableObjectListQueryParameters queryParams, PaginationRequest paginationParams)
        {
            string rsVaultRgName = CommonTestHelper.GetSetting(TestConstants.RsVaultRgName);
            string rsVaultName = CommonTestHelper.GetSetting(TestConstants.RsVaultName);

            ProtectableObjectListResponse response = Client.ProtectableObjects.List(rsVaultRgName, rsVaultName, queryParams,
                paginationParams, CommonTestHelper.GetCustomRequestHeaders());

            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.ItemList);
            return response;
        }
    }
}
