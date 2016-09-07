// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;

    /// <summary>
    /// This class represents KeyNames for all the keys currently supported in Connection string
    /// </summary>
    public class ConnectionStringKeys
    {
        // <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificateKey = "managementcertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionIdKey = "subscriptionid";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        public const string AADTenantKey = "aadtenant";

        /// <summary>
        /// The key inside the connection string for a Microsoft ID (OrgId or LiveId)
        /// </summary>
        public const string UserIdKey = "userid";

        /// <summary>
        /// The key inside the connection string for a user password matching the Microsoft ID
        /// </summary>
        public const string PasswordKey = "password";

        /// <summary>
        /// Service principal key
        /// </summary>
        public const string ServicePrincipalKey = "serviceprincipal";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        public const string AADClientIdKey = "aadclientid";

        /// <summary>
        /// ServicePrincipal Secret Key
        /// </summary>
        public const string ServicePrincipalSecretKey = "serviceprincipalsecret";

        /// <summary>
        /// Environment name
        /// </summary>
        public const string EnvironmentKey = "environment";

        #region Tokens
        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        public const string RawTokenKey = "rawtoken";

        /// <summary>
        /// A raw JWT token for Graph authentication
        /// </summary>
        public const string RawGraphTokenKey = "rawgraphtoken";

        /// <summary>
        /// 
        /// </summary>
        public const string HttpRecorderModeKey = "httprecordermode";
        #endregion
        
        #region URI's

        /// <summary>
        /// AAD token Audience Uri 
        /// </summary>
        public const string AADTokenAudienceUriKey = "aadtokenaudienceuri";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUriKey = "baseuri";

        /// <summary>
        /// The key inside the connection string for AD Graph URI
        /// </summary>
        public const string GraphUriKey = "graphuri";

        /// <summary>
        /// The key inside the connection string for AD Gallery URI
        /// </summary>
        public const string GalleryUriKey = "galleryuri";

        /// <summary>
        /// The key inside the connection string for the Ibiza Portal URI
        /// </summary>
        public const string IbizaPortalUriKey = "ibizaportaluri";

        /// <summary>
        /// The key inside the connection string for the RDFE Portal URI
        /// </summary>
        public const string RdfePortalUriKey = "rdfeportaluri";

        /// <summary>
        /// The key inside the connection string for the DataLake FileSystem URI suffix
        /// </summary>
        public const string DataLakeStoreServiceUriKey = "datalakestoreserviceuri";

        /// <summary>
        /// The key inside the connection string for the Kona Catalog URI
        /// </summary>
        public const string DataLakeAnalyticsJobAndCatalogServiceUriKey = "datalakeanalyticsjobandcatalogserviceuri";

        /// <summary>
        /// Endpoint to use for AAD authentication
        /// </summary>
        public const string AADAuthenticationEndpointKey = "aadauthendpoint";

        #endregion
    }
}
