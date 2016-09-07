// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Azure.Test.HttpRecorder;
    using Newtonsoft.Json.Linq;
    using Rest.Azure.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    /// <summary>
    /// Contains constant definitions for the fields that
    /// are allowed in the test connection strings.
    /// </summary>
    [Obsolete("This class will be deprecated after October 2016 PowerShell release. Use ConnectionStringKeys")]
    internal static class ConnectionStringFields
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        internal const string ManagementCertificate = "ManagementCertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        internal const string SubscriptionId = "SubscriptionId";

        /// <summary>
        /// AAD token Audience Uri 
        /// </summary>
        internal const string AADTokenAudienceUri = "AADTokenAudienceUri";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        internal const string BaseUri = "BaseUri";

        /// <summary>
        /// The key inside the connection string for AD Graph URI
        /// </summary>
        internal const string GraphUri = "GraphUri";

        /// <summary>
        /// The key inside the connection string for AD Gallery URI
        /// </summary>
        internal const string GalleryUri = "GalleryUri";

        /// <summary>
        /// The key inside the connection string for the Ibiza Portal URI
        /// </summary>
        internal const string IbizaPortalUri = "IbizaPortalUri";

        /// <summary>
        /// The key inside the connection string for the RDFE Portal URI
        /// </summary>
        internal const string RdfePortalUri = "RdfePortalUri";

        /// <summary>
        /// The key inside the connection string for the DataLake FileSystem URI suffix
        /// </summary>
        internal const string DataLakeStoreServiceUri = "DataLakeStoreServiceUri";

        /// <summary>
        /// The key inside the connection string for the Kona Catalog URI
        /// </summary>
        internal const string DataLakeAnalyticsJobAndCatalogServiceUri = "DataLakeAnalyticsJobAndCatalogServiceUri";

        /// <summary>
        /// The key inside the connection string for a Microsoft ID (OrgId or LiveId)
        /// </summary>
        internal const string UserId = "UserId";

        /// <summary>
        /// Service principal key
        /// </summary>
        internal const string ServicePrincipal = "ServicePrincipal";

        /// <summary>
        /// The key inside the connection string for a user password matching the Microsoft ID
        /// </summary>
        internal const string Password = "Password";

        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        internal const string RawToken = "RawToken";
        
        /// <summary>
        /// A raw JWT token for Graph authentication
        /// </summary>
        internal const string RawGraphToken = "RawGraphToken";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        internal const string AADClientId = "AADClientId";

        /// <summary>
        /// Endpoint to use for AAD authentication
        /// </summary>
        internal const string AADAuthenticationEndpoint = "AADAuthEndpoint";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        internal const string AADTenant = "AADTenant";

        /// <summary>
        /// Environment name
        /// </summary>
        internal const string Environment = "Environment"; 
    }
    
    public partial class TestEnvironment
    {
        const string TestCSMOrgIdConnectionStringKey = "TEST_CSM_ORGID_AUTHENTICATION";

        public ConnectionString ConnectionString { get; private set; }

        public TestEnvironment() : this(Environment.GetEnvironmentVariable(TestCSMOrgIdConnectionStringKey))
        { }

        public TestEnvironment(string connectionString)
        {
            //Initialize the connection string and set internal variables
            //string envVariableConnStr = Environment.GetEnvironmentVariable(TestCSMOrgIdConnectionStringKey);
            ConnectionString = new ConnectionString(connectionString);
            EnvEndpoints = new Dictionary<EnvironmentNames, TestEndpoints>();
            
            this.SubscriptionId = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.SubscriptionIdKey];
            this.UserName = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.UserIdKey];
            this.BaseUri = new Uri(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.BaseUriKey]);
            this.Tenant = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey];



            InitTokenDictionary();
            InitTestEndPoints();
            InitHttpRecorderMode();


            if(!(string.IsNullOrEmpty(this.SubscriptionId)) || (this.SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase)))
            {
                List<SubscriptionInfo> subscriptionList = ListSubscriptions(this.BaseUri.AbsoluteUri, this.TokenInfo[TokenAudience.Management]);
                string subscriptionId = subscriptionList.Where((sub) => sub.SubscriptionId.Equals(this.SubscriptionId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().SubscriptionId;

                if(string.IsNullOrEmpty(subscriptionId))
                {
                    StringBuilder sb = new StringBuilder("List of subscriptions retrieved:\r\n");
                    foreach(SubscriptionInfo subInfo in subscriptionList)
                    {
                        sb.AppendLine(subInfo.SubscriptionId);
                    }

                    string exceptionString = string.Format("Either no subscription was provided in connection string (e.g. TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=<subscritionId> or " +
                        "The provided SubscriptionId in connections string - '{0}' does not match the list of subscriptions associated with the account \r\n {1}", this.SubscriptionId, sb.ToString());

                    throw new Exception(exceptionString);
                }
            }
        }

        #region Helper Functions

        private void InitTokenDictionary()
        {
            this.TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();
            if(!string.IsNullOrEmpty(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.RawTokenKey]))
            {
                this.TokenInfo[TokenAudience.Management] = new TokenCredentials(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.RawTokenKey]);
            }

            if (!string.IsNullOrEmpty(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.RawGraphTokenKey]))
            {
                this.TokenInfo[TokenAudience.Graph] = new TokenCredentials(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.RawGraphTokenKey]);
            }
                
        }

        private void InitTestEndPoints()
        {
            EnvEndpoints.Add(EnvironmentNames.Prod, new TestEndpoints(EnvironmentNames.Prod));
            EnvEndpoints.Add(EnvironmentNames.Dogfood, new TestEndpoints(EnvironmentNames.Dogfood));
            EnvEndpoints.Add(EnvironmentNames.Next, new TestEndpoints(EnvironmentNames.Next));
            EnvEndpoints.Add(EnvironmentNames.Current, new TestEndpoints(EnvironmentNames.Current));

            string envNameString = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.EnvironmentKey];
            if (!string.IsNullOrEmpty(envNameString))
            {
                EnvironmentNames envName;
                if (!Enum.TryParse<EnvironmentNames>(envNameString, out envName))
                {
                    throw new Exception(
                        string.Format("Environment \"{0}\" is not valid", envNameString));
                }

                this.Endpoints = EnvEndpoints[envName];
            }
            else
            {
                this.Endpoints = EnvEndpoints[EnvironmentNames.Prod];
            }
        }

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

        private void InitHttpRecorderMode()
        {
            string testMode = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.HttpRecorderModeKey];
#if NET45
            TextInfo ti = new CultureInfo("en-us").TextInfo;
            testMode = ti.ToTitleCase(testMode);
#endif

            HttpRecorderMode recorderMode;
            if (Enum.TryParse<HttpRecorderMode>(testMode, out recorderMode))
            {
                HttpMockServer.Mode = recorderMode;
            }
            else
            {
                //log incompatible recorder mode
            }

            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                SetEnvironmentSubscriptionId();
            }
            else if((HttpMockServer.Mode == HttpRecorderMode.Record) || (HttpMockServer.Mode == HttpRecorderMode.None))
            {
                //We are not going to support custom key-value pairs in CustomeEnvValues
                //If users wants to add new keyValue pairs, they can do it by using this.ConnectionString.KeyValuePairs.Add("foo", "bar");


                //if (string.IsNullOrEmpty(this.ConnectionString.KeyValuePairs[ConnectionStringKeys.RawTokenKey]))
                if (!(this.TokenInfo.ContainsKey(TokenAudience.Management)) || !(this.TokenInfo.ContainsKey(TokenAudience.Graph)))
                {
                    string password = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.PasswordKey];
                    string spnClientId = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey];
                    string spnSecret = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey];

                    ActiveDirectoryServiceSettings aadServiceSettings = new ActiveDirectoryServiceSettings()
                    {
                        AuthenticationEndpoint = new Uri(this.Endpoints.AADAuthUri.ToString() + this.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey]),
                        TokenAudience = this.Endpoints.AADTokenAudienceUri
                    };
                    ActiveDirectoryServiceSettings graphAADServiceSettings = new ActiveDirectoryServiceSettings()
                    {
                        AuthenticationEndpoint = new Uri(this.Endpoints.AADAuthUri.ToString() + this.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey]),
                        TokenAudience = this.Endpoints.GraphTokenAudienceUri
                    };

                    /*
                    Currently we prioritize login as below:
                    1) UserName / Password combination
                    2) ServicePrincipal/ServicePrincipal Secret Key
                    3) Interactive Login (where user will be presented with prompt to login)
                   */
                    if ((!string.IsNullOrEmpty(this.UserName)) && (!string.IsNullOrEmpty(password)))
                    {
                        Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                                                                   .LoginSilentAsync(spnClientId, this.Tenant, this.UserName, password, aadServiceSettings).ConfigureAwait(continueOnCapturedContext: false));

                        this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
                    }
                    else if ((!string.IsNullOrEmpty(spnClientId)) && (!string.IsNullOrEmpty(spnSecret)))
                    {
                        Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await ApplicationTokenProvider
                                                                                   .LoginSilentAsync(this.Tenant, spnClientId, spnSecret, aadServiceSettings).ConfigureAwait(continueOnCapturedContext: false));

                        this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;
                    }
                    else
                    {
#if NET45
                        InteractiveLogin(this.Tenant, aadServiceSettings, graphAADServiceSettings);
#endif
                    }
                }
            }
        }
        
        private void InteractiveLogin(string tenant, ActiveDirectoryServiceSettings aadServiceSettings, ActiveDirectoryServiceSettings graphAADServiceSettings)
        {
#if NET45
            ActiveDirectoryClientSettings clientSettings = new ActiveDirectoryClientSettings()
            {
                ClientId = this.ConnectionString.KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey],
                ClientRedirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob"),
                PromptBehavior = PromptBehavior.Auto
            };
            Task<TokenCredentials> mgmAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                                                       .LoginWithPromptAsync(this.Tenant, clientSettings, aadServiceSettings).ConfigureAwait(continueOnCapturedContext: false));

            this.TokenInfo[TokenAudience.Management] = mgmAuthResult.Result;

            try
            {
                Task<TokenCredentials> graphAuthResult = Task.Run(async () => (TokenCredentials)await UserTokenProvider
                                .LoginWithPromptAsync(this.Tenant, clientSettings, graphAADServiceSettings).ConfigureAwait(continueOnCapturedContext: true));
                this.TokenInfo[TokenAudience.Graph] = graphAuthResult.Result;
            }
            catch
            {
                // Not all accounts are registered to have access to Graph endpoints. 
            }
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="testEnv"></param>
        /// <param name="connectionString"></param>
        private void SetEnvironmentSubscriptionId(/*TestEnvironment testEnv, string connectionString*/)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(ConnectionStringKeys.SubscriptionIdKey))
                {
                    this.SubscriptionId = HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey];
                }
                else if (string.IsNullOrEmpty(this.SubscriptionId))
                {
                    throw new Exception(string.Format("Subscription Id is not present in the recorded mock or in connection string (e.g. {0}=<subscriptionId>)", ConnectionStringKeys.SubscriptionIdKey));
                }
            }
            else //Record or None
            {
                // Preserve/restore subscription ID
                HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = this.SubscriptionId;
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
