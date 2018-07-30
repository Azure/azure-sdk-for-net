// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using Microsoft.Rest.Azure.Authentication;
    using Microsoft.Azure.Test.HttpRecorder;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.ComponentModel;

    /// <summary>
    /// Test Environment class
    /// </summary>
    public class TestEnvironment
    {   
        /// <summary>
        /// Environment Variable that is set by the user to run test
        /// </summary>
        const string TestCSMOrgIdConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION";

        /// <summary>
        /// Environment variable that can also be used to set HttpRecorder mode
        /// </summary>
        const string AZURE_TEST_MODE_ENVKEY = "AZURE_TEST_MODE";

        /// <summary>
        /// Connection string used by Test Environment
        /// </summary>
        public ConnectionString ConnectionString { get; private set; }

        /// <summary>
        /// Credential dictionary to hold credentials for Management and Graph client
        /// </summary>
        public Dictionary<TokenAudience, TokenCredentials> TokenInfo { get; private set; }

        /// <summary>
        /// Base Uri used by the Test Environment
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// UserName used by the Test Environment
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Tenant used by the Test Environment
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Subscription Id used by the Test Environment
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Active TestEndpoint being used by the Test Environment
        /// </summary>
        public TestEndpoints Endpoints { get; set; }

        /// <summary>
        /// Holds default endpoints for all the supported environments
        /// </summary>
        public IDictionary<EnvironmentNames, TestEndpoints> EnvEndpoints;

        [DefaultValue(false)]
        public bool OptimizeRecordedFile { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TestEnvironment()
        {
            LoadDefaultEnvironmentEndpoints();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public TestEnvironment(string connectionString)
        {
            ConnectionString = new ConnectionString(connectionString);
            InitTestEndPoints();

            this.OptimizeRecordedFile = this.ConnectionString.GetValue<bool>(ConnectionStringKeys.OptimizeRecordedFileKey);
            this.SubscriptionId = this.ConnectionString.GetValue(ConnectionStringKeys.SubscriptionIdKey);
            this.UserName = this.ConnectionString.GetValue(ConnectionStringKeys.UserIdKey);
            this.Tenant = this.ConnectionString.GetValue(ConnectionStringKeys.AADTenantKey);
            if (string.IsNullOrEmpty(this.ConnectionString.GetValue(ConnectionStringKeys.BaseUriKey)))
            {
                this.BaseUri = this.Endpoints.ResourceManagementUri;
            }
            else
            {
                this.BaseUri = new Uri(this.ConnectionString.GetValue(ConnectionStringKeys.BaseUriKey));
            }

            SetupHttpRecorderMode();
            InitTokenDictionary();
            RecorderModeSettings();
        }

#region Helper Functions

        /// <summary>
        /// Initialize Token Dictionary with default value        
        /// </summary>
        private void InitTokenDictionary()
        {
            this.TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();

            this.ConnectionString.KeyValuePairs.TryGetValue(ConnectionStringKeys.RawTokenKey, out string rawTkn);
            this.ConnectionString.KeyValuePairs.TryGetValue(ConnectionStringKeys.RawGraphTokenKey, out string graphRawTkn);

            // We need TokenInfo to be non-empty as there are cases where have taken dependency on non-empty TokenInfo in MockContext
            if(string.IsNullOrEmpty(rawTkn))
            {
                rawTkn = ConnectionStringKeys.RawTokenKey;
            }

            if (string.IsNullOrEmpty(graphRawTkn))
            {
                graphRawTkn = ConnectionStringKeys.RawGraphTokenKey;
            }

            this.TokenInfo[TokenAudience.Management] = new TokenCredentials(rawTkn);
            this.TokenInfo[TokenAudience.Graph] = new TokenCredentials(graphRawTkn);
        }

        /// <summary>
        /// Initializes envEndpoints dictionary with all existing environments endpoints
        /// Also updates the applicable URI/endpoints provided as part of the connection string
        /// </summary>
        private void InitTestEndPoints()
        {
            LoadDefaultEnvironmentEndpoints();
            string envNameString = this.ConnectionString.GetValue(ConnectionStringKeys.EnvironmentKey);
            if (!string.IsNullOrEmpty(envNameString))
            {
                EnvironmentNames envName;
                Enum.TryParse<EnvironmentNames>(envNameString, out envName);
                this.Endpoints = new TestEndpoints(EnvEndpoints[envName], this.ConnectionString);
            }
            else
            {
                this.Endpoints = new TestEndpoints(EnvEndpoints[EnvironmentNames.Prod], this.ConnectionString);
            }
        }

        /// <summary>
        /// Load default endpoints info for all supported environments
        /// </summary>
        private void LoadDefaultEnvironmentEndpoints()
        {
            if (EnvEndpoints == null)
            {
                EnvEndpoints = new Dictionary<EnvironmentNames, TestEndpoints>();
                EnvEndpoints.Add(EnvironmentNames.Prod, new TestEndpoints(EnvironmentNames.Prod));
                EnvEndpoints.Add(EnvironmentNames.Dogfood, new TestEndpoints(EnvironmentNames.Dogfood));
                EnvEndpoints.Add(EnvironmentNames.Next, new TestEndpoints(EnvironmentNames.Next));
                EnvEndpoints.Add(EnvironmentNames.Current, new TestEndpoints(EnvironmentNames.Current));
                EnvEndpoints.Add(EnvironmentNames.Custom, new TestEndpoints(EnvironmentNames.Custom));
            }
        }

        /// <summary>
        /// Set HttpRecorderMode from connection string
        /// </summary>
        private void SetupHttpRecorderMode()
        {
            string testMode = Environment.GetEnvironmentVariable(AZURE_TEST_MODE_ENVKEY);

            if (string.IsNullOrEmpty(testMode))
            {   
                testMode = this.ConnectionString.GetValue(ConnectionStringKeys.HttpRecorderModeKey);
            }

            HttpRecorderMode recorderMode;
            //Ideally we should be throwing when incompatible environment (e.g. Environment=Foo) is provided in connection string
            //But currently we do not throw
            if (Enum.TryParse<HttpRecorderMode>(testMode, out recorderMode))
            {
                HttpMockServer.Mode = recorderMode;
            }
            else
            {
                //log incompatible recorder mode
            }
        }

        /// <summary>
        /// Take actions depending on the httprecorder mode
        /// e.g.
        /// Login if the recorder mode is set to Record
        /// Verify if the provided subscriptionId can be retrieved from the current user
        /// </summary>
        private void RecorderModeSettings()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                //Get Subscription Id from MockServer
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    this.SubscriptionId = HttpMockServer.Variables.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey);
                }
                else if (string.IsNullOrEmpty(this.SubscriptionId))
                {
                    throw new Exception(string.Format("Subscription Id is not present in the recorded mock or in connection string (e.g. {0}=<subscriptionId>)", ConnectionStringKeys.SubscriptionIdKey));
                }
            }
            else if ((HttpMockServer.Mode == HttpRecorderMode.Record) || (HttpMockServer.Mode == HttpRecorderMode.None))
            {
                //Restore/Add Subscription Id in MockServer from supplied connection string
                if(HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    HttpMockServer.Variables.UpdateDictionary(ConnectionStringKeys.SubscriptionIdKey, this.SubscriptionId);
                }
                else
                {
                    HttpMockServer.Variables.Add(ConnectionStringKeys.SubscriptionIdKey, this.SubscriptionId);
                }

                // If User has provided Access Token in RawToken/GraphToken Key-Value, we don't need to authenticate
                // We currently only check for RawToken and do not check if GraphToken is provided
                if(string.IsNullOrEmpty(this.ConnectionString.GetValue(ConnectionStringKeys.RawTokenKey)))
                { 
                    Login();
                }

                VerifySubscription();
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        private void Login()
        {
            string password = this.ConnectionString.GetValue(ConnectionStringKeys.PasswordKey);
            string spnClientId = this.ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalKey);
            string spnSecret = this.ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalSecretKey);
            //We use this because when login silently using userTokenProvider, we need to provide a well known ClientId for an app that has delegating permissions.
            //All first party app have that permissions, so we use PowerShell app ClientId
            string PowerShellClientId = "1950a258-227b-4e31-a9cf-717495945fc2";

            /*
            Currently we prioritize login as below:
            1) ServicePrincipal/ServicePrincipal Secret Key
            2) UserName / Password combination
            3) Interactive Login (where user will be presented with prompt to login)
           */
            #region Login
            #region aadSettings
            ActiveDirectoryServiceSettings aadServiceSettings = new ActiveDirectoryServiceSettings()
            {
                AuthenticationEndpoint = new Uri(this.Endpoints.AADAuthUri.ToString() + this.ConnectionString.GetValue(ConnectionStringKeys.AADTenantKey)),
                TokenAudience = this.Endpoints.AADTokenAudienceUri
            };
            ActiveDirectoryServiceSettings graphAADServiceSettings = new ActiveDirectoryServiceSettings()
            {
                AuthenticationEndpoint = new Uri(this.Endpoints.AADAuthUri.ToString() + this.ConnectionString.GetValue(ConnectionStringKeys.AADTenantKey)),
                TokenAudience = this.Endpoints.GraphTokenAudienceUri
            };
            #endregion

            if ((!string.IsNullOrEmpty(spnClientId)) && (!string.IsNullOrEmpty(spnSecret)))
            {

                Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await ApplicationTokenProvider
                                                                           .LoginSilentAsync(this.Tenant, spnClientId, spnSecret, aadServiceSettings).ConfigureAwait(continueOnCapturedContext: false));

                this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
            }
            else if ((!string.IsNullOrEmpty(this.UserName)) && (!string.IsNullOrEmpty(password)))
            {
#if FullNetFx
                Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                                                           .LoginSilentAsync(PowerShellClientId, this.Tenant, this.UserName, password, aadServiceSettings).ConfigureAwait(continueOnCapturedContext: false));

                this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
#else
                throw new NotSupportedException("Username/Password login is supported only in NET452 and above projects");
#endif
            }
            else
            {
#if FullNetFx
                InteractiveLogin(this.Tenant, PowerShellClientId,
                                    aadServiceSettings, graphAADServiceSettings);
#else
                throw new NotSupportedException("Interactive Login is supported only in NET452 and above projects");
#endif
            }
            #endregion
        }

        /// <summary>
        /// Run interactive login
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="aadServiceSettings"></param>
        /// <param name="graphAADServiceSettings"></param>
        private void InteractiveLogin(string tenant, string PsClientId, 
                                        ActiveDirectoryServiceSettings aadServiceSettings,
                                        ActiveDirectoryServiceSettings graphAADServiceSettings)
        {
#if FullNetFx
            ActiveDirectoryClientSettings clientSettings = new ActiveDirectoryClientSettings()
            {
                ClientId = PsClientId,
                ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                PromptBehavior = PromptBehavior.Always
            };

            TaskScheduler scheduler;
            if (SynchronizationContext.Current != null)
            {
                scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            }
            else
            {
                scheduler = TaskScheduler.Current;
            }

            Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                .LoginWithPromptAsync(this.Tenant,
                                clientSettings,
                                aadServiceSettings, () => { return scheduler; }).ConfigureAwait(continueOnCapturedContext: false));
            
            this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
            this.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey] = this.TokenInfo[TokenAudience.Management].CallerId;

            try
            {   
                Task<TokenCredentials> graphAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                .LoginWithPromptAsync(this.Tenant,
                                clientSettings,
                                graphAADServiceSettings, () => { return scheduler; }).ConfigureAwait(continueOnCapturedContext: true));
                this.TokenInfo[TokenAudience.Graph] = graphAuthResult.Result;
            }
            catch
            {
                // Not all accounts are registered to have access to Graph endpoints. 
            }
#endif
        }

        /// <summary>
        /// Retrieve subscriptions for current user and verify if the provided subscription Id matches from the retrieved subscription list
        /// </summary>
        private void VerifySubscription()
        {
#region
            string matchedSubscriptionId = string.Empty;
            StringBuilder sb = new StringBuilder();
            string callerId = string.Empty;
            string subs = string.Empty;

            List<SubscriptionInfo> subscriptionList = ListSubscriptions(this.BaseUri.ToString(), this.TokenInfo[TokenAudience.Management]);

            if (this.TokenInfo[TokenAudience.Management] != null)
            {
                try { callerId = this.TokenInfo[TokenAudience.Management].CallerId; } catch { }
            }

            if (!(string.IsNullOrEmpty(this.SubscriptionId)) && !(this.SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase)))
            {   
                if (subscriptionList.Any<SubscriptionInfo>())
                {
                    var matchedSubs = subscriptionList.Where((sub) => sub.SubscriptionId.Equals(this.SubscriptionId, StringComparison.OrdinalIgnoreCase));
                    if (matchedSubs.IsAny<SubscriptionInfo>())
                    {
                        matchedSubscriptionId = matchedSubs.FirstOrDefault().SubscriptionId;
                    }
                    else
                    {
                        foreach (SubscriptionInfo subInfo in subscriptionList)
                        {
                            subs += subInfo.SubscriptionId + ",";
                        }
                    }
                }

                if (string.IsNullOrEmpty(matchedSubscriptionId))
                {
                    sb.AppendLine(string.Format("SubscriptionList:'{0}' retrieved for the user/spn id '{1}', do not match with the provided subscriptionId '{2}' in connection string",
                        subs, callerId, this.SubscriptionId));

                    throw new Exception(sb.ToString());
                }
            }
            else
            {
                // The idea is in case if no match was found, we check if subscription Id was provided in connection string, if not
                // we then check if the retrieved subscription list has exactly 1 subscription, if yes we will just use that one.
                if (string.IsNullOrEmpty(this.SubscriptionId))
                {
                    if (subscriptionList.Count() == 1)
                    {
                       this.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey] = subscriptionList.First<SubscriptionInfo>().SubscriptionId;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.SubscriptionId))
                        {
                            sb.AppendLine("Retrieved subscription list has more than 1 subscription. Connection string has no subscription provided. Provide SubcriptionId info in connection string");
                            throw new Exception(sb.ToString());
                        }
                    }
                }
                else if(this.SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase))
                {
                    sb.AppendLine(string.Format("'{0}': connection string contains subscriptionId as '{1}'",
                                                    TestCSMOrgIdConnectionStringKey, this.SubscriptionId));
                    sb.AppendLine("Provide valid SubcriptionId info in connection string");
                    throw new Exception(sb.ToString());
                }
            }
#endregion
        }

        /// <summary>
        /// Retrieve list of subscription for current user
        /// </summary>
        /// <param name="baseuri"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        private List<SubscriptionInfo> ListSubscriptions(string baseuri, TokenCredentials credentials)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(string.Format("{0}/subscriptions?api-version=2014-04-01-preview", baseuri))
            };

            HttpClient client = new HttpClient();

            credentials.ProcessHttpRequestAsync(request, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

            HttpResponseMessage response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();

            string jsonString = response.Content.ReadAsStringAsync().Result;

            var jsonResult = JObject.Parse(jsonString);
            var results = ((JArray)jsonResult["value"]).Select(item => new SubscriptionInfo((JObject)item)).ToList();
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testEnv"></param>
        /// <param name="connectionString"></param>
        private void SetEnvironmentSubscriptionId()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    this.SubscriptionId = HttpMockServer.Variables.GetValueUsingCaseInsensitiveKey(ConnectionStringKeys.SubscriptionIdKey);
                }
                else if (string.IsNullOrEmpty(this.SubscriptionId))
                {
                    throw new Exception(string.Format("Subscription Id is not present in the recorded mock or in connection string (e.g. {0}=<subscriptionId>)", ConnectionStringKeys.SubscriptionIdKey));
                }
            }
            else // HttpRecorder Mode == Record/None
            {
                // Preserve/restore subscription ID
                HttpMockServer.Variables.UpdateDictionary(ConnectionStringKeys.SubscriptionIdKey, this.SubscriptionId);
            }
        }

        /// <summary>
        /// TODO: not sure if we need this for the ease to get the value of various connection string keys
        /// Currently you need to use the below syntax to get to the value of each connectionstring keys
        /// this.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey]
        /// with this funciton it will be as below
        /// this.GetKeyValue(ConnectionStringKeys.SubscriptionIdKey)
        /// </summary>
        /// <param name="connectionStringKeyName"></param>
        /// <returns></returns>
        private string GetKeyValue(string connectionStringKeyName)
        {
            string keyValue = string.Empty;
            if (this.ConnectionString.KeyValuePairs.ContainsKey(connectionStringKeyName))
            {
                this.ConnectionString.KeyValuePairs.TryGetValue(connectionStringKeyName, out keyValue);
            }

            return keyValue;
        }
#endregion
    }
}