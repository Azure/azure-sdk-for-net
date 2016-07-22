// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public enum EnvironmentNames
    {
        Prod,
        Dogfood,
        Next,
        Current
    }

    public class TestEndpoints
    {
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
