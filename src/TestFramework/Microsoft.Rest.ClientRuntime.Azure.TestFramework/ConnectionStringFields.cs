// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    /// <summary>
    /// Contains constant definitions for the fields that
    /// are allowed in the test connection strings.
    /// </summary>
    public static class ConnectionStringFields
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificate = "ManagementCertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionId = "SubscriptionId";

        /// <summary>
        /// AAD token Audience Uri 
        /// </summary>
        public const string AADTokenAudienceUri = "AADTokenAudienceUri";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUri = "BaseUri";

        /// <summary>
        /// The key inside the connection string for AD Graph URI
        /// </summary>
        public const string GraphUri = "GraphUri";

        /// <summary>
        /// The key inside the connection string for AD Gallery URI
        /// </summary>
        public const string GalleryUri = "GalleryUri";

        /// <summary>
        /// The key inside the connection string for the Ibiza Portal URI
        /// </summary>
        public const string IbizaPortalUri = "IbizaPortalUri";

        /// <summary>
        /// The key inside the connection string for the RDFE Portal URI
        /// </summary>
        public const string RdfePortalUri = "RdfePortalUri";

        /// <summary>
        /// The key inside the connection string for the DataLake FileSystem URI suffix
        /// </summary>
        public const string DataLakeStoreServiceUri = "DataLakeStoreServiceUri";

        /// <summary>
        /// The key inside the connection string for the Kona Catalog URI
        /// </summary>
        public const string DataLakeAnalyticsJobAndCatalogServiceUri = "DataLakeAnalyticsJobAndCatalogServiceUri";

        /// <summary>
        /// The key inside the connection string for a Microsoft ID (OrgId or LiveId)
        /// </summary>
        public const string UserId = "UserId";

        /// <summary>
        /// Service principal key
        /// </summary>
        public const string ServicePrincipal = "ServicePrincipal";

        /// <summary>
        /// The key inside the connection string for a user password matching the Microsoft ID
        /// </summary>
        public const string Password = "Password";

        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        public const string RawToken = "RawToken";
        
        /// <summary>
        /// A raw JWT token for Graph authentication
        /// </summary>
        public const string RawGraphToken = "RawGraphToken";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        public const string AADClientId = "AADClientId";

        /// <summary>
        /// Endpoint to use for AAD authentication
        /// </summary>
        public const string AADAuthenticationEndpoint = "AADAuthEndpoint";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        public const string AADTenant = "AADTenant";

        /// <summary>
        /// Environment name
        /// </summary>
        public const string Environment = "Environment"; 
    }
}
