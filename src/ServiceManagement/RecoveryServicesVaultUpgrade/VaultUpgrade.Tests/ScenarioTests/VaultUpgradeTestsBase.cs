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

using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade.Models;
using Microsoft.WindowsAzure.Management.RecoveryServicesVaultUpgrade;
using Newtonsoft.Json;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace VaultUpgrade.Tests
{
    public class VaultUpgradeTestsBase : TestBase
    {
        public static string VaultLocation = "Southeast Asia";
        public static string MyCloudService;
        public static string MyVaultName;
        public static string MyVaultType;
        public static string MyResourceNamespace;

        protected static CustomRequestHeaders RequestHeaders = new CustomRequestHeaders
        {
            ClientRequestId = Guid.NewGuid().ToString(),
        };
        protected readonly RecordedDelegationHandler CustomHttpHandler = new RecordedDelegationHandler { StatusCodeToReturn = HttpStatusCode.OK };

        public RecoveryServicesVaultUpgradeManagementClient GetRecoveryServicesVaultUpgradeClient(RecordedDelegationHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetRecoveryServicesVaultUpgradeManagementClient().WithHandler(handler); ;
        }
    }
}