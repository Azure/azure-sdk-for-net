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

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Newtonsoft.Json;    

    /// <summary>
    /// Types of environment in Intune
    /// </summary>
    public enum EnvironmentType
    {
        OneBox,
        Dogfood,
        CTIP,
        Prod
    }

    /// <summary>
    /// Azure Active directory related operations helper class.
    /// </summary>
    public class AADClientHelper
    {
        public const string AadAuthDogfoodEnpoint = "https://login.windows-ppe.net/";

        public const string AadAuthProductionEnpoint = "https://login.microsoftonline.com/";

        public const string AadGraphDogfoodEnpoint = "https://graph.ppe.windows.net/";

        public const string AadGraphProductionEnpoint = "https://graph.windows.net/";

        public const string ARMClientIdForUserAuth = "1950a258-227b-4e31-a9cf-717495945fc2";

        public const string ARMResourceUrl = "https://management.azure.com/";

        private string userName;
        private string password;
        private string tenantName;
        private EnvironmentType environment;
        private string novaSessionId;
        private UserCredential userCredential;
        private string authEndpoint;
        private string graphEndpoint;
        private string aadTokenForArm;
        private DateTimeOffset nextTokenRenewal;

        public string TenantId { get; private set; }

        public string UserId { get; private set; }

        public string AADTokenForARM
        {
            get
            {
                if (this.aadTokenForArm == null || DateTime.UtcNow.AddMinutes(3) > this.nextTokenRenewal)
                {
                    AuthenticationResult authActionResult = this.AuthenticateUser(ARMResourceUrl);
                    this.aadTokenForArm = authActionResult.AccessToken;
                    this.nextTokenRenewal = authActionResult.ExpiresOn;
                }

                return this.aadTokenForArm;
            }

            private set
            {
                this.aadTokenForArm = value;
            }
        }

        public AADClientHelper()
        {
            var orgIdAuth = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            var parts = orgIdAuth.Split(new char[] { ';' }).ToList();
            var authParams = new Dictionary<string, string>();
            parts.ForEach(a => { var splitVal = a.Split(new char[] { '=' }); authParams.Add(splitVal[0], splitVal[1]); });
            EnvironmentType enType = EnvironmentType.Dogfood;
            if (authParams["Environment"] == "Dogfood")
            {
                enType = EnvironmentType.Dogfood;
            }
            else if (authParams["Environment"] == "Prod")
            {
                enType = EnvironmentType.Prod;
            }

            InitializeAADClient(authParams["UserId"], authParams["Password"], enType);
        }
        private void InitializeAADClient(string userName, string password, EnvironmentType env)
        {
            this.userName = userName;
            this.password = password;
            this.environment = env;
            this.tenantName = userName.Split(new char[] { '@' })[1];
            this.userCredential = new UserCredential(this.userName, this.password);

            if (env == EnvironmentType.OneBox)
            {
                this.novaSessionId = this.GetNovaSessionId();
            }

            this.authEndpoint = this.GetAadAuthEndpoint();
            this.graphEndpoint = this.GetAadGraphEndpoint();

            // we don't need aad token for ARM in one box.
            if (env != EnvironmentType.OneBox)
            {
                AuthenticationResult authActionResult = this.AuthenticateUser(ARMResourceUrl);
                this.aadTokenForArm = authActionResult.AccessToken;
                this.nextTokenRenewal = authActionResult.ExpiresOn;
                this.TenantId = authActionResult.TenantId;
                this.UserId = authActionResult.UserInfo.UniqueId;
            }
        }

        private string GetNovaSessionId()
        {
            // ItPro.20.msods.msol-nova.com
            var segments = this.tenantName.Split(new char[] { '.' });
            if (segments.Length == 5)
            {
                return segments[1];
            }
            else
            {
                throw new ArgumentException("Given oneBox tenant doesn't have Nova tenant pattern.");
            }
        }

        private string GetAadAuthEndpoint()
        {
            string baseEndpoint = string.Empty;

            switch (this.environment)
            {
                case EnvironmentType.Dogfood:
                    {
                        baseEndpoint = AadAuthDogfoodEnpoint;
                        break;
                    }
                case EnvironmentType.CTIP:
                case EnvironmentType.Prod:
                    {
                        baseEndpoint = AadAuthProductionEnpoint;
                        break;
                    }
                case EnvironmentType.OneBox:
                    {
                        baseEndpoint = string.Format("https://{0}.ests.msol-nova.com/", this.novaSessionId);
                        break;
                    }
                default:
                    {
                        throw new Exception("No supported AAD Auth endpoint for Environment:" + this.environment);
                    }
            }

            return baseEndpoint + this.tenantName;
        }

        private string GetAadGraphEndpoint()
        {
            string endpoint;

            switch (this.environment)
            {
                case EnvironmentType.Dogfood:
                    {
                        endpoint = AadGraphDogfoodEnpoint;
                        break;
                    }
                case EnvironmentType.CTIP:
                case EnvironmentType.Prod:
                    {
                        endpoint = AadGraphProductionEnpoint;
                        break;
                    }
                case EnvironmentType.OneBox:
                    {
                        endpoint = string.Format("https://graph.{0}.msods.msol-nova.com/", this.novaSessionId);
                        break;
                    }
                default:
                    {
                        throw new Exception("No supported AAD Graph endpoint for Environment:" + this.environment);
                    }
            }

            return endpoint;
        }

        /// <summary>
        /// Get Token for User Async.
        /// </summary>
        /// <returns>Token for user.</returns>
        private async Task<string> GetAccessTokenForUserAsync(string targetResource)
        {
            var authenticationContext = new AuthenticationContext(this.authEndpoint, false);

            var authResult = await authenticationContext.AcquireTokenAsync(
                targetResource,
                ARMClientIdForUserAuth,
                this.userCredential);

            return authResult.AccessToken;
        }

        /// <summary>
        /// Get Token for User.
        /// </summary>
        /// <returns>Token for user.</returns>
        private AuthenticationResult AuthenticateUser(string targetResourceUrl)
        {
            var authenticationContext = new AuthenticationContext(this.authEndpoint, false);

            return authenticationContext.AcquireToken(
                targetResourceUrl,
                ARMClientIdForUserAuth,
                this.userCredential);
        }

        /// <summary>
        /// Gets the UserGroups from AAD Graph.
        /// </summary>
        /// <returns>List with Group Ids and DisplayNames</returns>
        public async Task<List<Dictionary<string, string>>> GetUserGroups()
        {
            return await this.GetUserGroups(false);
        }

        /// <summary>
        /// Gets the UserGroups from AAD Graph.
        /// </summary>
        /// <returns>List with Group Ids and DisplayNames</returns>
        public async Task<List<Dictionary<string, string>>> GetUserGroups(bool getAll)
        {
            string responseContent;
            ODataResponse odataResponse;
            List<Dictionary<string, string>> groupList = new List<Dictionary<string, string>>();
            string graphServicePricipalId = "00000002-0000-0000-c000-000000000000";
            string accessToken = await this.GetAccessTokenForUserAsync(graphServicePricipalId);
            string skipToken = string.Empty;

            do
            {
                responseContent = await this.ExecuteGraphRequest(accessToken, skipToken);

                odataResponse = JsonConvert.DeserializeObject<ODataResponse>(responseContent);

                foreach (var group in odataResponse.Value.Where(x => x.SecurityEnabled))
                {
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("DisplayName", group.DisplayName);
                    dict.Add("ID", group.ObjectId);
                    groupList.Add(dict);
                }

                if (!string.IsNullOrEmpty(odataResponse.NextLink))
                {
                    skipToken = odataResponse.NextLink.Substring(odataResponse.NextLink.IndexOf("?") + 1);
                }
                else
                {
                    skipToken = string.Empty;
                }
            }
            while (getAll && !string.IsNullOrEmpty(skipToken));

            return groupList;
        }

        private async Task<string> ExecuteGraphRequest(string token, string skipToken = null)
        {
            string responseContent;
            string noSkipTokenFormatString = "{0}{1}/groups?api-version=1.6";
            string withSkipTokenformatString = "{0}{1}/groups?api-version=1.6&{2}";
            HttpWebRequest request;

            if (string.IsNullOrEmpty(skipToken))
            {
                request = WebRequest.Create(string.Format(noSkipTokenFormatString, this.graphEndpoint, this.tenantName)) as HttpWebRequest;
            }
            else
            {
                request = WebRequest.Create(string.Format(withSkipTokenformatString, this.graphEndpoint, this.tenantName, skipToken)) as HttpWebRequest;
            }
            request.Accept = "application/json;";
            request.Headers.Add(HttpRequestHeader.Authorization, (new AuthenticationHeaderValue("Bearer", token)).ToString());

            WebResponse response = await request.GetResponseAsync();
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                responseContent = await streamReader.ReadToEndAsync();
            }

            return responseContent;
        }
    }

    internal class UserGroup
    {
        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("displayName", Required = Required.Always)]
        public string DisplayName { get; set; }

        [JsonProperty("securityEnabled", Required = Required.Always)]
        public bool SecurityEnabled { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("mailNickname")]
        public string MailNickname { get; set; }

        [JsonProperty("mailEnabled")]
        public bool MailEnabled { get; set; }

        public UserGroup(string groupName)
        {
            this.Description = groupName;
            this.DisplayName = groupName;
            this.MailEnabled = true;
            this.SecurityEnabled = true;
            this.MailNickname = groupName;
        }
    }

    internal class ODataResponse
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }

        [JsonProperty("odata.nextlink")]
        public string NextLink { get; set; }

        public List<UserGroup> Value { get; set; }
    }
}
