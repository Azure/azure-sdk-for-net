// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;

    public enum EnvironmentNames
    {
        Prod,
        Dogfood,
        Next,
        Current,
        Custom
    }

    public class TestEndpoints
    {
        /// <summary>
        /// 
        /// </summary>
        private TestEndpoints() { }
        internal TestEndpoints(EnvironmentNames testEnvName)
        {
            string _defaultAADTokenAudienceUri = @"https://management.core.windows.net/";
            string _defaultGraphTokenAudienceUri = @"https://graph.windows.net/";
            string _defaultPPEGraphTokenAudienceUri = @"https://graph.ppe.windows.net/";
            #region environment switch
            switch (testEnvName)
            {
                case EnvironmentNames.Prod:
                    {
                        #region
                        Name = EnvironmentNames.Prod;
                        AADAuthUri = new Uri("https://login.microsoftonline.com");
                        GalleryUri = new Uri("https://gallery.azure.com/");
                        GraphUri = new Uri("https://graph.windows.net/");
                        IbizaPortalUri = new Uri("https://portal.azure.com/");
                        RdfePortalUri = new Uri("http://go.microsoft.com/fwlink/?LinkId=254433");
                        ResourceManagementUri = new Uri("https://management.azure.com/");
                        ServiceManagementUri = new Uri("https://management.core.windows.net");
                        AADTokenAudienceUri = new Uri(_defaultAADTokenAudienceUri);
                        GraphTokenAudienceUri = new Uri(_defaultGraphTokenAudienceUri);
                        DataLakeStoreServiceUri = new Uri("https://azuredatalakestore.net");
                        DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://azuredatalakeanalytics.net");
                        break;
                        #endregion
                    }

                case EnvironmentNames.Dogfood:
                    {
                        #region
                        Name = EnvironmentNames.Dogfood;
                        AADAuthUri = new Uri("https://login.windows-ppe.net");
                        GalleryUri = new Uri("https://df.gallery.azure-test.net/");
                        GraphUri = new Uri("https://graph.ppe.windows.net/");
                        IbizaPortalUri = new Uri("http://df.onecloud.azure-test.net");
                        RdfePortalUri = new Uri("https://windows.azure-test.net");
                        ResourceManagementUri = new Uri("https://api-dogfood.resources.windows-int.net/");
                        ServiceManagementUri = new Uri("https://management-preview.core.windows-int.net");
                        AADTokenAudienceUri = new Uri(_defaultAADTokenAudienceUri);
                        GraphTokenAudienceUri = new Uri(_defaultPPEGraphTokenAudienceUri);
                        DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net");
                        DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net");
                        break;
                        #endregion
                    }

                case EnvironmentNames.Next:
                    {
                        #region
                        Name = EnvironmentNames.Next;
                        AADAuthUri = new Uri("https://login.windows-ppe.net");
                        GalleryUri = new Uri("https://next.gallery.azure-test.net/");
                        GraphUri = new Uri("https://graph.ppe.windows.net/");
                        IbizaPortalUri = new Uri("http://next.onecloud.azure-test.net");
                        RdfePortalUri = new Uri("https://auxnext.windows.azure-test.net");
                        ResourceManagementUri = new Uri("https://api-next.resources.windows-int.net/");
                        ServiceManagementUri = new Uri("https://managementnext.rdfetest.dnsdemo4.com");
                        AADTokenAudienceUri = new Uri(_defaultAADTokenAudienceUri);
                        GraphTokenAudienceUri = new Uri(_defaultPPEGraphTokenAudienceUri);
                        DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"); // TODO: change once a "next" environment is published
                        DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net"); // TODO: change once a "next" environment is published
                        break;
                        #endregion
                    }

                case EnvironmentNames.Current:
                    {
                        #region
                        Name = EnvironmentNames.Current;
                        AADAuthUri = new Uri("https://login.windows-ppe.net");
                        GalleryUri = new Uri("https://current.gallery.azure-test.net/");
                        GraphUri = new Uri("https://graph.ppe.windows.net/");
                        IbizaPortalUri = new Uri("http://current.onecloud.azure-test.net");
                        RdfePortalUri = new Uri("https://auxcurrent.windows.azure-test.net");
                        ResourceManagementUri = new Uri("https://api-current.resources.windows-int.net/");
                        ServiceManagementUri = new Uri("https://management.rdfetest.dnsdemo4.com");
                        AADTokenAudienceUri = new Uri(_defaultAADTokenAudienceUri);
                        GraphTokenAudienceUri = new Uri(_defaultPPEGraphTokenAudienceUri);
                        DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"); // TODO: change once a "Current" environment is published
                        DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net"); // TODO: change once a "Current" environment is published
                        break;
                        #endregion
                    }

                case EnvironmentNames.Custom:
                    {
                        #region
                        Name = EnvironmentNames.Custom;                        
                        break;
                        #endregion
                    }
            }
            #endregion
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="testEndpoint">endPoint instance</param>
        private TestEndpoints(TestEndpoints testEndpoint)
        {
            Name = testEndpoint.Name;
            ServiceManagementUri = testEndpoint.ServiceManagementUri;
            ResourceManagementUri = testEndpoint.ResourceManagementUri;
            GraphUri = testEndpoint.GraphUri;
            GalleryUri = testEndpoint.GalleryUri;
            AADAuthUri = testEndpoint.AADAuthUri;
            RdfePortalUri = testEndpoint.RdfePortalUri;
            IbizaPortalUri = testEndpoint.IbizaPortalUri;
            DataLakeStoreServiceUri = testEndpoint.DataLakeStoreServiceUri;
            DataLakeAnalyticsJobAndCatalogServiceUri = testEndpoint.DataLakeAnalyticsJobAndCatalogServiceUri;
            AADTokenAudienceUri = testEndpoint.AADTokenAudienceUri;
            GraphTokenAudienceUri = testEndpoint.GraphTokenAudienceUri;
            PublishingSettingsFileUri = testEndpoint.PublishingSettingsFileUri;
        }

        /// <summary>
        /// Constructor updates endpoint URI that matches provided connection string
        /// </summary>
        /// <param name="testEndpoint">endPoint that needs to be updated according to connection string</param>
        /// <param name="connString">User provided connection string</param>
        internal TestEndpoints(TestEndpoints testEndpoint, ConnectionString connStr) : this(testEndpoint)
        {
            UpdateEnvironmentEndpoint(connStr);
        }

        /// <summary>
        /// Constructor updates endpoint URI that matches Environment names with supplied URI's in connection string
        /// </summary>
        /// <param name="envName">EnvironmentName</param>
        /// <param name="connStr">ConnectionString object</param>
        internal TestEndpoints(EnvironmentNames envName, ConnectionString connStr) : this(envName)
        {
            UpdateEnvironmentEndpoint(connStr);
        }

        /// <summary>
        /// This function will update the URI keyvalue pairs passed into connection string and update accordingly
        /// E.g. You want to use Prod environment, but would like to use a custom ResourceManagementUri URI in prod env.
        /// So instead of the hard coded prod ResourceManagementUri https://management.core.windows.net, you would like to use
        /// https://brazilus.management.azure.com
        /// </summary>
        /// <param name="connStr">ConnectionString object</param>
        private void UpdateEnvironmentEndpoint(ConnectionString connStr)
        {
            #region
            if (connStr.HasNonEmptyValue(ConnectionStringKeys.AADTokenAudienceUriKey))
            {
                AADTokenAudienceUri = new Uri(connStr.GetValue(ConnectionStringKeys.AADTokenAudienceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GraphTokenAudienceUriKey))
            {
                GraphTokenAudienceUri = new Uri(connStr.GetValue(ConnectionStringKeys.GraphTokenAudienceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GraphUriKey))
            {
                GraphUri = new Uri(connStr.GetValue(ConnectionStringKeys.GraphUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.GalleryUriKey))
            {
                GalleryUri = new Uri(connStr.GetValue(ConnectionStringKeys.GalleryUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.IbizaPortalUriKey))
            {
                IbizaPortalUri = new Uri(connStr.GetValue(ConnectionStringKeys.IbizaPortalUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.RdfePortalUriKey))
            {
                RdfePortalUri = new Uri(connStr.GetValue(ConnectionStringKeys.RdfePortalUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.DataLakeStoreServiceUriKey))
            {
                DataLakeStoreServiceUri = new Uri(connStr.GetValue(ConnectionStringKeys.DataLakeStoreServiceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey))
            {
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri(connStr.GetValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.AADAuthUriKey))
            {
                AADAuthUri = new Uri(connStr.GetValue(ConnectionStringKeys.AADAuthUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.PublishSettingsFileUriKey))
            {
                PublishingSettingsFileUri = new Uri(connStr.GetValue(ConnectionStringKeys.PublishSettingsFileUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.ServiceManagementUriKey))
            {
                ServiceManagementUri = new Uri(connStr.GetValue(ConnectionStringKeys.ServiceManagementUriKey));
            }

            if (connStr.HasNonEmptyValue(ConnectionStringKeys.ResourceManagementUriKey))
            {
                ResourceManagementUri = new Uri(connStr.GetValue(ConnectionStringKeys.ResourceManagementUriKey));
            }
            #endregion
        }

        //TestEnvironment Name
        public EnvironmentNames Name { get; set; }

        //managementEndpointUrl - rdfe
        public Uri ServiceManagementUri { get; set; }

        //resourceManagerEndpointUrl - csm
        public Uri ResourceManagementUri { get; set; }
        
        //activeDirectoryGraphResourceId
        public Uri GraphUri { get; set; }
        
        //galleryEndpointUrl
        public Uri GalleryUri { get; set; }
        
        //activeDirectoryEndpointUrl
        public Uri AADAuthUri { get; set; }

        //portalUrl - rdfe
        public Uri RdfePortalUri { get; set; }

        // portal url - csm
        public Uri IbizaPortalUri { get; set; }

        // the DNS suffix for the DataLake Filesystem service
        public Uri DataLakeStoreServiceUri { get; set; }

        // the Kona catalog front end url
        public Uri DataLakeAnalyticsJobAndCatalogServiceUri { get; set; }

        // AAD Token Audience 
        public Uri AADTokenAudienceUri { get; set; }

        // Graph Token Audience 
        public Uri GraphTokenAudienceUri { get; set; }

        public Uri PublishingSettingsFileUri { get; set; }
    }
}
