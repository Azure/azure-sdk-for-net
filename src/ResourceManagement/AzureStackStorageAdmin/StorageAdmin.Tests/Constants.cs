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

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    internal class Constants
    {
        public const string ApiVersionParameter = "api-version=2015-12-01-preview";
        public const string ResourceGroupName = "resourceGroup1";
        public const string FarmId = "farm_01";
        public const string ShareType = "shares";
        public const string NodeType = "nodes";
        public const string TableServiceType = "tableservices";
        public const string BlobServiceType = "blobservices";
        public const string ManagementServiceType = "managementservices";

        public const string AccountContainerServerInstanceType = "accountcontainerserverinstances";
        public const string BlobFrontendInstanceType = "blobfrontendinstances";
        public const string BlobServerInstanceType = "blobserverinstances";
        public const string HealthMonitoringServerInstanceType = "healthmonitoringserverinstances";
        public const string MetricsServerInstanceType = "metricsserverinstances";
        public const string TableFrontendInstanceType = "tablefrontendinstances";
        public const string TableMasterInstanceType = "tablemasterinstances";
        public const string TableServerInstanceType = "tableserverinstances";

        public const string SingleInstanceName = "default";
        public const string ShareName = "||localhost|abc";
        public const string ShareAName = "||localhost|smb1";
        public readonly static Guid FaultId = Guid.Parse("AF71E845-2463-4610-8626-13465EFA150E");
        public const string NodeId = "defaultNode";
        public const string BaseUri = "http://management.azure.com";
        public const string TokenString = "abc123";
        public const string RoleInstanceId = "woss-node-1";
        public const string TableMasterRole = "tablemaster";
        public const string ListSummary = "summary=true";
        public const string AcquisitionId = "D6AE96E1-62B1-4F43-91F6-680E3990D76D";
        public const string LocationName = "redmond";
        public const string QuotaName = "SRP_DefaultQuota";
    }
}
