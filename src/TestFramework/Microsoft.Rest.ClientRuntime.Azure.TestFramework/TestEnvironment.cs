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
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

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
            //Not sure why we do it, but it seems we do it with some random string value
            this.TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();
            if (!string.IsNullOrEmpty(this.ConnectionString.GetValue(ConnectionStringKeys.RawTokenKey)))
            {
                this.TokenInfo[TokenAudience.Management] = new TokenCredentials(this.ConnectionString.GetValue(ConnectionStringKeys.RawTokenKey));
            }

            if (!string.IsNullOrEmpty(this.ConnectionString.GetValue(ConnectionStringKeys.RawGraphTokenKey)))
            {
                this.TokenInfo[TokenAudience.Graph] = new TokenCredentials(this.ConnectionString.GetValue(ConnectionStringKeys.RawGraphTokenKey));
            }
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
            }
        }

        /// <summary>
        /// Set HttpRecorderMode from connection string
        /// </summary>
        private void SetupHttpRecorderMode()
        {
            string testMode = this.ConnectionString.GetValue(ConnectionStringKeys.HttpRecorderModeKey);
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
                //Restore Subscription Id in MockServer from supplied connection string
                HttpMockServer.Variables.UpdateDictionary(ConnectionStringKeys.SubscriptionIdKey, this.SubscriptionId);

                //We are not going to support custom key-value pairs in CustomeEnvValues
                //If users wants to add new keyValue pairs, they can do it by using this.ConnectionString.KeyValuePairs.Add("foo", "bar");

                //If User has provided Access Token in RawToken/GraphToken Key-Value, we don't need to authenticate
                //So we check if tokenInfo has default values (which was initialized to default value when connection string was processed)
                //then we need to authenticate and hence need to login
                if ((!this.TokenInfo[TokenAudience.Graph].Equals(ConnectionStringKeys.RawTokenKey)) || (!this.TokenInfo[TokenAudience.Graph].Equals(ConnectionStringKeys.RawGraphTokenKey)))
                {
                    Login();
                    VerifySubscription();
                }
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

            /*
            Currently we prioritize login as below:
            1) UserName / Password combination
            2) ServicePrincipal/ServicePrincipal Secret Key
            3) Interactive Login (where user will be presented with prompt to login)
           */
            #region Login
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
            #endregion
        }

        /// <summary>
        /// Run interactive login
        /// </summary>
        /// <param name="tenant"></param>
        /// <param name="aadServiceSettings"></param>
        /// <param name="graphAADServiceSettings"></param>
        private void InteractiveLogin(string tenant, ActiveDirectoryServiceSettings aadServiceSettings, ActiveDirectoryServiceSettings graphAADServiceSettings)
        {
#if NET45
            ActiveDirectoryClientSettings clientSettings = new ActiveDirectoryClientSettings()
            {
                ClientId = this.ConnectionString.GetValue(ConnectionStringKeys.ServicePrincipalKey),
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
        /// Retrieve subscriptions for current user and verify if the provided subscription Id matches from the retrieved subscription list
        /// </summary>
        private void VerifySubscription()
        {
            #region
            if (!(string.IsNullOrEmpty(this.SubscriptionId)) || (this.SubscriptionId.Equals("None", StringComparison.OrdinalIgnoreCase)))
            {
                //TokenCredentials cred = this.TokenInfo[TokenAudience.Management];

                List<SubscriptionInfo> subscriptionList = ListSubscriptions(this.BaseUri.ToString(), this.TokenInfo[TokenAudience.Management]);
                string subscriptionId = subscriptionList.Where((sub) => sub.SubscriptionId.Equals(this.SubscriptionId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault().SubscriptionId;

                if (string.IsNullOrEmpty(subscriptionId))
                {
                    StringBuilder sb = new StringBuilder("List of subscriptions retrieved:\r\n");
                    foreach (SubscriptionInfo subInfo in subscriptionList)
                    {
                        sb.AppendLine(subInfo.SubscriptionId);
                    }

                    //TODO: Find a way to get userId that is being used to retrive subscriptions
                    //Currently if there occurs a situation, the subscription list retrieved does not match the supplied subscriptionIds
                    //There is not way to let the user know as to for what user the subscription list was retrieved.
                    string exceptionString = string.Format("Either no subscription was provided in connection string (e.g. TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=<subscritionId> or " +
                        "The provided SubscriptionId in connections string - '{0}' does not match the list of subscriptions associated with the account \r\n {1}", this.SubscriptionId, sb.ToString());

                    throw new Exception(exceptionString);
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

/*

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    public partial class TestEnvironment
    {
        #region internal
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        internal const string ManagementCertificateKey = ConnectionStringFields.ManagementCertificate;

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        internal const string SubscriptionIdKey = ConnectionStringFields.SubscriptionId;

        /// <summary>
        /// The key inside the connection string for the base uri
        /// </summary>
        internal const string BaseUriKey = ConnectionStringFields.BaseUri;

        /// <summary>
        /// The service management endpoint name
        /// </summary>
        internal const string ServiceManagementUri = "ServiceManagementUri";

        /// <summary>
        /// The resource management endpoint name
        /// </summary>
        internal const string ResourceManagementUri = "ResourceManagementUri";

        /// <summary>
        /// Service principal key
        /// </summary>
        internal const string ServicePrincipalKey = ConnectionStringFields.ServicePrincipal;

        /// <summary>
        /// The key inside the connection string for the userId identifier
        /// </summary>
        internal const string UserIdKey = ConnectionStringFields.UserId;
        internal const string UserIdDefault = "user@example.com";

        /// <summary>
        /// The key inside the connection string for the AADPassword identifier
        /// </summary>
        internal const string AADPasswordKey = ConnectionStringFields.Password;

        internal const string EnvironmentKey = ConnectionStringFields.Environment;
        internal const EnvironmentNames EnvironmentDefault = EnvironmentNames.Prod;

        /// <summary>
        /// The key inside the connection string for the AAD client ID"
        /// </summary>
        internal const string ClientIdKey = ConnectionStringFields.AADClientId;
        internal const string ClientIdDefault = "1950a258-227b-4e31-a9cf-717495945fc2";

        /// <summary>
        /// The key inside the connection string for the AAD Tenant
        /// </summary>
        internal const string AADTenantKey = ConnectionStringFields.AADTenant;
        internal const string AADTenantDefault = "common";

        /// <summary>
        /// A raw token to be used for authentication with the give subscription ID
        /// </summary>
        internal const string RawToken = ConnectionStringFields.RawToken;
        internal const string RawGraphToken = ConnectionStringFields.RawGraphToken;
        internal static string RawTokenDefault = Guid.NewGuid().ToString();

        internal string ServicePrincipal { get; set; }

        private string ClientId { get; set; }

        private IDictionary<string, string> RawParameters { get; set; }

        //private bool UsesCustomUri()
        //{
        //    return this.CustomUri;
        //}        

        private static bool MatchEnvironmentBaseUri(TestEndpoints testEndpoint, string endpointValue)
        {
            endpointValue = EnsureTrailingSlash(endpointValue);
            return string.Equals(testEndpoint.ResourceManagementUri.ToString(), endpointValue, StringComparison.OrdinalIgnoreCase);
        }

        private static string EnsureTrailingSlash(string uri)
        {
            if (uri.EndsWith("/"))
            {
                return uri;
            }

            return string.Format("{0}/", uri);
        }

        #endregion

        public TestEndpoints Endpoints { get; set; }

        public static IDictionary<EnvironmentNames, TestEndpoints> EnvEndpoints;
        
        static TestEnvironment()
        {
            EnvEndpoints = new Dictionary<EnvironmentNames, TestEndpoints>();
            EnvEndpoints.Add(EnvironmentNames.Prod, new TestEndpoints
            {
                Name = EnvironmentNames.Prod,
                AADAuthUri = new Uri("https://login.microsoftonline.com"),
                GalleryUri = new Uri("https://gallery.azure.com/"),
                GraphUri = new Uri("https://graph.windows.net/"),
                IbizaPortalUri = new Uri("https://portal.azure.com/"),
                RdfePortalUri = new Uri("http://go.microsoft.com/fwlink/?LinkId=254433"),
                ResourceManagementUri = new Uri("https://management.azure.com/"),
                ServiceManagementUri = new Uri("https://management.core.windows.net"),
                AADTokenAudienceUri = new Uri("https://management.core.windows.net"),
                GraphTokenAudienceUri = new Uri("https://graph.windows.net/"),
                DataLakeStoreServiceUri = new Uri("https://azuredatalakestore.net"),
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://azuredatalakeanalytics.net")
            });
            EnvEndpoints.Add(EnvironmentNames.Dogfood, new TestEndpoints
            {
                Name = EnvironmentNames.Dogfood,
                AADAuthUri = new Uri("https://login.windows-ppe.net"),
                GalleryUri = new Uri("https://df.gallery.azure-test.net/"),
                GraphUri = new Uri("https://graph.ppe.windows.net/"),
                IbizaPortalUri = new Uri("http://df.onecloud.azure-test.net"),
                RdfePortalUri = new Uri("https://windows.azure-test.net"),
                ResourceManagementUri = new Uri("https://api-dogfood.resources.windows-int.net/"),
                ServiceManagementUri = new Uri("https://management-preview.core.windows-int.net"),
                AADTokenAudienceUri = new Uri("https://management.core.windows.net"),
                GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/"),
                DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"),
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net")
            });
            EnvEndpoints.Add(EnvironmentNames.Next, new TestEndpoints
            {
                Name = EnvironmentNames.Next,
                AADAuthUri = new Uri("https://login.windows-ppe.net"),
                GalleryUri = new Uri("https://next.gallery.azure-test.net/"),
                GraphUri = new Uri("https://graph.ppe.windows.net/"),
                IbizaPortalUri = new Uri("http://next.onecloud.azure-test.net"),
                RdfePortalUri = new Uri("https://auxnext.windows.azure-test.net"),
                ResourceManagementUri = new Uri("https://api-next.resources.windows-int.net/"),
                ServiceManagementUri = new Uri("https://managementnext.rdfetest.dnsdemo4.com"),
                AADTokenAudienceUri = new Uri("https://management.core.windows.net"),
                GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/"),
                DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"), // TODO: change once a "next" environment is published
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net") // TODO: change once a "next" environment is published
            });
            EnvEndpoints.Add(EnvironmentNames.Current, new TestEndpoints
            {
                Name = EnvironmentNames.Current,
                AADAuthUri = new Uri("https://login.windows-ppe.net"),
                GalleryUri = new Uri("https://current.gallery.azure-test.net/"),
                GraphUri = new Uri("https://graph.ppe.windows.net/"),
                IbizaPortalUri = new Uri("http://current.onecloud.azure-test.net"),
                RdfePortalUri = new Uri("https://auxcurrent.windows.azure-test.net"),
                ResourceManagementUri = new Uri("https://api-current.resources.windows-int.net/"),
                ServiceManagementUri = new Uri("https://management.rdfetest.dnsdemo4.com"),
                AADTokenAudienceUri = new Uri("https://management.core.windows.net"),
                GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/"),
                DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"), // TODO: change once a "Current" environment is published
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net") // TODO: change once a "Current" environment is published
            });
        }
        

        //public TestEnvironment()
        //    : this(null)
        //{
        //}

            
        

        internal TestEnvironment(IDictionary<string, string> connection)
        {
            this.TokenInfo = new Dictionary<TokenAudience, TokenCredentials>();
            // Instantiate dictionary of parameters
            RawParameters = new Dictionary<string, string>();
            // By default set env to Prod
            this.Endpoints = TestEnvironment.EnvEndpoints[EnvironmentDefault];

            this.BaseUri = this.Endpoints.ResourceManagementUri;
            this.ClientId = TestEnvironment.ClientIdDefault;
            this.Tenant = TestEnvironment.AADTenantDefault;

            if (connection != null)
            {
                if (connection.ContainsKey(TestEnvironment.UserIdKey))
                {
                    this.UserName = connection[TestEnvironment.UserIdKey];
                    var splitUser = this.UserName.Split( new []{'@'}, StringSplitOptions.RemoveEmptyEntries);
                    if (splitUser.Length == 2)
                    {
                        this.Tenant = splitUser[1];
                    }
                }
                if (connection.ContainsKey(TestEnvironment.ServicePrincipalKey))
                {
                    this.ServicePrincipal = connection[TestEnvironment.ServicePrincipalKey];
                }
                if (connection.ContainsKey(TestEnvironment.AADTenantKey))
                {
                    this.Tenant = connection[TestEnvironment.AADTenantKey];
                }
                if (connection.ContainsKey(TestEnvironment.SubscriptionIdKey))
                {
                    this.SubscriptionId = connection[TestEnvironment.SubscriptionIdKey];
                }
                if (connection.ContainsKey(TestEnvironment.ClientIdKey))
                {
                    this.ClientId = connection[TestEnvironment.ClientIdKey];
                }
                if (connection.ContainsKey(TestEnvironment.EnvironmentKey))
                {
                    if (ConnectionStringContainsEndpoint(connection))
                    {
                        throw new ArgumentException("Invalid connection string, can contain endpoints or environment but not both",
                            "connection");
                    }

                    var envNameString = connection[TestEnvironment.EnvironmentKey];

                    EnvironmentNames envName;
                    if(!Enum.TryParse<EnvironmentNames>(envNameString, out envName))
                    {
                        throw new Exception(
                            string.Format("Environment \"{0}\" is not valid", envNameString));
                    }

                    this.Endpoints = TestEnvironment.EnvEndpoints[envName];
                    //need to set the right baseUri
                    this.BaseUri = this.Endpoints.ResourceManagementUri;
                }
                if (connection.ContainsKey(TestEnvironment.BaseUriKey))
                {
                    var baseUriString = connection[TestEnvironment.BaseUriKey];
                    this.BaseUri = new Uri(baseUriString);
                    if (!connection.ContainsKey(TestEnvironment.EnvironmentKey))
                    {
                        EnvironmentNames envName = LookupEnvironmentFromBaseUri(baseUriString);
                        this.Endpoints = TestEnvironment.EnvEndpoints[envName];
                    }
                }
                if (connection.ContainsKey(ConnectionStringFields.AADAuthenticationEndpoint))
                {
                    this.Endpoints.AADAuthUri = new Uri(connection[ConnectionStringFields.AADAuthenticationEndpoint]);
                }
                if (connection.ContainsKey(ConnectionStringFields.GraphUri))
                {
                    this.Endpoints.GraphUri = new Uri(connection[ConnectionStringFields.GraphUri]);
                }
                if (connection.ContainsKey(ConnectionStringFields.GalleryUri))
                {
                    this.Endpoints.GalleryUri = new Uri(connection[ConnectionStringFields.GalleryUri]);
                }
                if (connection.ContainsKey(ConnectionStringFields.IbizaPortalUri))
                {
                    this.Endpoints.IbizaPortalUri = new Uri(connection[ConnectionStringFields.IbizaPortalUri]);
                }
                if (connection.ContainsKey(ConnectionStringFields.RdfePortalUri))
                {
                    this.Endpoints.RdfePortalUri = new Uri(connection[ConnectionStringFields.RdfePortalUri]);
                }
                if (connection.ContainsKey(ConnectionStringFields.DataLakeStoreServiceUri))
                {
                    this.Endpoints.DataLakeStoreServiceUri = new Uri(connection[ConnectionStringFields.DataLakeStoreServiceUri]);
                }
                if (connection.ContainsKey(ConnectionStringFields.DataLakeAnalyticsJobAndCatalogServiceUri))
                {
                    this.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri = new Uri(connection[ConnectionStringFields.DataLakeAnalyticsJobAndCatalogServiceUri]);
                }
                RawParameters = connection;
            }
        }

        private bool ConnectionStringContainsEndpoint(IDictionary<string, string> connection)
        {
            return new[]
            {
                ConnectionStringFields.BaseUri,
                ConnectionStringFields.GraphUri,
                ConnectionStringFields.GalleryUri,
                ConnectionStringFields.AADAuthenticationEndpoint,
                ConnectionStringFields.IbizaPortalUri,
                ConnectionStringFields.RdfePortalUri,
                ConnectionStringFields.DataLakeStoreServiceUri,
                ConnectionStringFields.DataLakeAnalyticsJobAndCatalogServiceUri,
                ConnectionStringFields.AADTokenAudienceUri
            }.Any(connection.ContainsKey);
        }

        //private bool CustomUri = false;
        private Uri _BaseUri;
        
        public Uri BaseUri
        {
            get
            {
                return this._BaseUri;
            }

            set
            {
                //this.CustomUri = true;
                this._BaseUri = value;
            }
        }

        public Dictionary<TokenAudience, TokenCredentials> TokenInfo { get; private set; }
        
        public string UserName { get; set; }

        public string Tenant { get; set; }        

        public string SubscriptionId { get; set; }

        public EnvironmentNames LookupEnvironmentFromBaseUri(string resourceManagementUri)
        {
            foreach (TestEndpoints testEndpoint in EnvEndpoints.Values)
            {
                if (MatchEnvironmentBaseUri(testEndpoint, resourceManagementUri))
                {
                    return testEndpoint.Name;
                }
            }
            return EnvironmentNames.Prod;
        }

    }
    */

}