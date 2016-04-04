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
// using System.Web.Script.Serialization;
using Microsoft.Azure.Management.SiteRecoveryVault;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Common.Internals;
using Hyak.Common.TransientFaultHandling;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using Xunit;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Microsoft.Azure.Test.HttpRecorder;
////using SiteRecovery.Tests.ScenarioTests;

namespace SiteRecovery.Tests
{
    public class SiteRecoveryTestsBase : TestBase
    {
        public static string MyCloudService;
        public static string MyVaultName;
        public static string MyResourceGroupName;
        public static string VaultKey;
        public static string VaultLocation = "Southeast Asia";
        public static readonly string HyperVReplicaAzure = "HyperVReplicaAzure";
        public static readonly string HyperVReplica = "HyperVReplica";



        protected static CustomRequestHeaders RequestHeaders = new CustomRequestHeaders
        {
            ClientRequestId = Guid.NewGuid().ToString(),
            Culture = "en"
        };

        protected readonly RecordedDelegationHandler CustomHttpHandler
            = new RecordedDelegationHandler { StatusCodeToReturn = HttpStatusCode.OK };

        public SiteRecoveryVaultManagementClient GetRecoveryServicesClient(RecordedDelegationHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetSiteRecoveryVaultManagementClient().WithHandler(handler); ;
        }

        public SiteRecoveryManagementClient GetSiteRecoveryClient(RecordedDelegationHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetSiteRecoveryManagementClient().WithHandler(handler);
        }

        public string GenerateAgentAuthenticationHeader(string clientRequestId)
        {
            CikTokenDetails cikTokenDetails = new CikTokenDetails();

            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddHours(-1);
            cikTokenDetails.NotBeforeTimestamp = TimeZoneInfo.ConvertTimeToUtc(currentDateTime);
            cikTokenDetails.NotAfterTimestamp = cikTokenDetails.NotBeforeTimestamp.AddHours(6);
            cikTokenDetails.ClientRequestId = clientRequestId;
            cikTokenDetails.Version = new Version(1, 2);
            cikTokenDetails.PropertyBag = new Dictionary<string, object>();

            string shaInput = JsonConvert.SerializeObject(cikTokenDetails);

            HMACSHA256 sha = new HMACSHA256(Encoding.UTF8.GetBytes(VaultKey));
            cikTokenDetails.Hmac =
                Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(shaInput)));
            cikTokenDetails.HashFunction = CikSupportedHashFunctions.HMACSHA256.ToString();

            return JsonConvert.SerializeObject(cikTokenDetails);
        }

        #region CIK

        public class CikTokenDetails
        {
            public DateTime NotBeforeTimestamp { get; set; }
            public DateTime NotAfterTimestamp { get; set; }
            public string ClientRequestId { get; set; }
            public string HashFunction { get; set; }
            public string Hmac { get; set; }
            public Version Version { get; set; }
            public Dictionary<string, object> PropertyBag { get; set; }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("NotBeforeTimestamp: " + NotBeforeTimestamp);
                sb.AppendLine("NotAfterTimestamp: " + NotAfterTimestamp);
                sb.AppendLine("ClientRequestId: " + ClientRequestId);
                sb.AppendLine("Hmac: " + Hmac);
                return sb.ToString();
            }
        }

        public enum CikSupportedHashFunctions
        {
            HMACSHA256,

            HMACSHA384,

            HMACSHA512
        }

        #endregion
    }
}