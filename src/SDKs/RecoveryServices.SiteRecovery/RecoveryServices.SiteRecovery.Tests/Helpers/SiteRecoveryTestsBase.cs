// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Newtonsoft.Json;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace SiteRecovery.Tests
{
    public class SiteRecoveryTestsBase : TestBase
    {
        public static string MyVaultName;
        public static string MyResourceGroupName;
        public static string VaultKey;
        public static string ResourceNamespace;
        public static string ResourceType;

        protected readonly RecordedDelegatingHandler CustomHttpHandler
            = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

        public string GenerateAgentAuthenticationHeader(string clientRequestId)
        {
            CikTokenDetails cikTokenDetails = new CikTokenDetails();

            DateTime currentDateTime = DateTime.Now;
            currentDateTime = currentDateTime.AddHours(-1);
            cikTokenDetails.NotBeforeTimestamp = TimeZoneInfo.ConvertTime(currentDateTime, TimeZoneInfo.Utc);
            cikTokenDetails.NotAfterTimestamp = cikTokenDetails.NotBeforeTimestamp.AddHours(6);
            cikTokenDetails.ClientRequestId = clientRequestId;
            cikTokenDetails.Version = new System.Version(1, 2);
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
            public System.Version Version { get; set; }
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