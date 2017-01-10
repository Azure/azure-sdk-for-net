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
        Current
    }

    public class TestEndpoints
    {
        /// <summary>
        /// 
        /// </summary>
        internal TestEndpoints() { }
        internal TestEndpoints(EnvironmentNames testEnvName)
        {
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
                        AADTokenAudienceUri = new Uri("https://management.core.windows.net");
                        GraphTokenAudienceUri = new Uri("https://graph.windows.net/");
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
                        AADTokenAudienceUri = new Uri("https://management.core.windows.net");
                        GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/");
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
                        AADTokenAudienceUri = new Uri("https://management.core.windows.net");
                        GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/");
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
                        AADTokenAudienceUri = new Uri("https://management.core.windows.net");
                        GraphTokenAudienceUri = new Uri("https://graph.ppe.windows.net/");
                        DataLakeStoreServiceUri = new Uri("https://caboaccountdogfood.net"); // TODO: change once a "Current" environment is published
                        DataLakeAnalyticsJobAndCatalogServiceUri = new Uri("https://konaaccountdogfood.net"); // TODO: change once a "Current" environment is published
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
        }

        /// <summary>
        /// Constructor updates endpoint URI that matches provided connection string
        /// </summary>
        /// <param name="testEndpoint">endPoint that needs to be updated according to connection string</param>
        /// <param name="connString">User provided connection string</param>
        internal TestEndpoints(TestEndpoints testEndpoint, ConnectionString connString): this(testEndpoint)
        {
            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.BaseUriKey)))
            {
                ResourceManagementUri = new Uri(connString.GetValue(ConnectionStringKeys.BaseUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.GraphUriKey)))
            {
                GraphUri = new Uri(connString.GetValue(ConnectionStringKeys.GraphUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.GalleryUriKey)))
            {
                GalleryUri = new Uri(connString.GetValue(ConnectionStringKeys.GalleryUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.AADAuthenticationEndpointKey)))
            {
                AADAuthUri = new Uri(connString.GetValue(ConnectionStringKeys.AADAuthenticationEndpointKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.IbizaPortalUriKey)))
            {
                IbizaPortalUri = new Uri(connString.GetValue(ConnectionStringKeys.IbizaPortalUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.DataLakeStoreServiceUriKey)))
            {
                DataLakeStoreServiceUri = new Uri(connString.GetValue(ConnectionStringKeys.DataLakeStoreServiceUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey)))
            {
                DataLakeAnalyticsJobAndCatalogServiceUri = new Uri(connString.GetValue(ConnectionStringKeys.DataLakeAnalyticsJobAndCatalogServiceUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.AADTokenAudienceUriKey)))
            {
                AADTokenAudienceUri = new Uri(connString.GetValue(ConnectionStringKeys.AADTokenAudienceUriKey));
            }

            if (!string.IsNullOrEmpty(connString.GetValue(ConnectionStringKeys.GraphTokenAudienceUriKey)))
            {
                GraphTokenAudienceUri = new Uri(connString.GetValue(ConnectionStringKeys.GraphTokenAudienceUriKey));
            }

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

    }
}
