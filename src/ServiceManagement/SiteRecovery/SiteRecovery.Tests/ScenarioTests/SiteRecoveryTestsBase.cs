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
using Microsoft.WindowsAzure.Management.RecoveryServices;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.Azure.Common.Internals;
using Hyak.Common.TransientFaultHandling;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using Xunit;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Microsoft.Azure.Test.HttpRecorder;

namespace SiteRecovery.Tests
{
    public class SiteRecoveryTestsBase : TestBase
    {
        public static string VaultKey;
        public static string VaultLocation = "Southeast Asia";
        public static string MyCloudService;
        public static string MyVaultName;

        protected static CustomRequestHeaders RequestHeaders = new CustomRequestHeaders
        {
            ClientRequestId = Guid.NewGuid().ToString(),
        };
        protected readonly RecordedDelegationHandler CustomHttpHandler = new RecordedDelegationHandler { StatusCodeToReturn = HttpStatusCode.OK };

        public RecoveryServicesManagementClient GetRecoveryServicesClient(RecordedDelegationHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetRecoveryServicesManagementClient().WithHandler(handler); ;
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

        protected void ValidateResponse(JobResponse response)
        {
            Assert.NotNull(response.Job);
            Assert.NotNull(response.Job.ID);
            Assert.True(response.Job.Errors.Count < 1, "Errors found while doing planned failover operation");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        protected void WaitForJobToComplete(SiteRecoveryManagementClient client, string jobId)
        {
            var responseJob = client.Jobs.Get(jobId, RequestHeaders);
            while (responseJob.Job.StateDescription != "Completed")
            {
                // Sleep for 1 min
                System.Threading.Thread.Sleep(60 * 1000);
                responseJob = client.Jobs.Get(jobId, RequestHeaders);
            }

            Assert.NotEqual(responseJob.Job.State, "Failed");
        }
    }
}