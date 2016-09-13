// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public class TestEnvironment
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificateKey = ConnectionStringFields.ManagementCertificate;

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionIdKey = ConnectionStringFields.SubscriptionId;

        /// <summary>
        /// The key inside the connection string for the base uri
        /// </summary>
        public const string BaseUriKey = ConnectionStringFields.BaseUri;

        /// <summary>
        /// The service management endpoint name
        /// </summary>
        public const string ServiceManagementUri = "ServiceManagementUri";

        /// <summary>
        /// The resource management endpoint name
        /// </summary>
        public const string ResourceManagementUri = "ResourceManagementUri";

        /// <summary>
        /// Service principal key
        /// </summary>
        public const string ServicePrincipalKey = ConnectionStringFields.ServicePrincipal;

        /// <summary>
        /// The key inside the connection string for the userId identifier
        /// </summary>
        public const string UserIdKey = ConnectionStringFields.UserId;
        public const string UserIdDefault = "user@example.com";

        /// <summary>
        /// The key inside the connection string for the AADPassword identifier
        /// </summary>
        public const string AADPasswordKey = ConnectionStringFields.Password;

        public const string EnvironmentKey = ConnectionStringFields.Environment;
        public const EnvironmentNames EnvironmentDefault = EnvironmentNames.Prod;

        /// <summary>
        /// The key inside the connection string for the AAD client ID"
        /// </summary>
        public const string ClientIdKey = ConnectionStringFields.AADClientId;
        public const string ClientIdDefault = "1950a258-227b-4e31-a9cf-717495945fc2";

        /// <summary>
        /// The key inside the connection string for the AAD Tenant
        /// </summary>
        public const string AADTenantKey = ConnectionStringFields.AADTenant;
        public const string AADTenantDefault = "common";

        /// <summary>
        /// A raw token to be used for authentication with the give subscription ID
        /// </summary>
        public const string RawToken = ConnectionStringFields.RawToken;
        public const string RawGraphToken = ConnectionStringFields.RawGraphToken;
        public static string RawTokenDefault = Guid.NewGuid().ToString();

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

        public TestEnvironment()
            : this(null)
        {
        }

        public TestEnvironment(IDictionary<string, string> connection)
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

        private bool CustomUri = false;
        private Uri _BaseUri;

        public Uri BaseUri
        {
            get
            {
                return this._BaseUri;
            }

            set
            {
                this.CustomUri = true;
                this._BaseUri = value;
            }
        }

        public Dictionary<TokenAudience,TokenCredentials> TokenInfo { get; private set; }

        public string ServicePrincipal { get; set; }

        public string UserName { get; set; }

        public string Tenant { get; set; }

        public string ClientId { get; set; }

        public string SubscriptionId { get; set; }
        
        public IDictionary<string, string> RawParameters { get; set; }

        public bool UsesCustomUri()
        {
            return this.CustomUri;
        }

        public EnvironmentNames LookupEnvironmentFromBaseUri(string endpointValue)
        {
            foreach(TestEndpoints testEndpoint in EnvEndpoints.Values)
            {
                if (MatchEnvironmentBaseUri(testEndpoint, endpointValue))
                {
                    return testEndpoint.Name;
                }
            }
            return EnvironmentNames.Prod;
        }

        private static bool MatchEnvironmentBaseUri(TestEndpoints testEndpoint, string endpointValue)
        {
            endpointValue = EnsureTrailingSlash(endpointValue);
            return string.Equals(testEndpoint.ResourceManagementUri.ToString(), endpointValue, StringComparison.OrdinalIgnoreCase);
        }

        private static string EnsureTrailingSlash(string uri)
        {
            if(uri.EndsWith("/"))
            {
                return uri;
            }

            return string.Format("{0}/", uri);
        }
    }
}
