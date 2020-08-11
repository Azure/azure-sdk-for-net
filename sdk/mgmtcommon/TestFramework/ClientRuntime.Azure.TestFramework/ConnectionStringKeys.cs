// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// This class represents KeyNames for all the keys currently supported in Connection string    
    /// Note:
    /// If you add a public const field, it will be used/assumed as key as part of the connection string
    /// This class is being used to reflect on all the key names supported in connection string.
    /// </summary>
    public class ConnectionStringKeys
    {
        /// <summary>
        /// The key inside the connection string for the management certificate
        /// </summary>
        public const string ManagementCertificateKey = "ManagementCertificate";

        /// <summary>
        /// The key inside the connection string for the subscription identifier
        /// </summary>
        public const string SubscriptionIdKey = "SubscriptionId";

        /// <summary>
        /// If a tenant other than common is to be used with the subscription, specifies the tenant
        /// </summary>
        public const string AADTenantKey = "AADTenant";

        /// <summary>
        /// The key inside the connection string for a Microsoft ID (OrgId or LiveId)
        /// </summary>
        public const string UserIdKey = "UserId";

        /// <summary>
        /// The key inside the connection string for a user password matching the Microsoft ID
        /// </summary>
        public const string PasswordKey = "Password";

        /// <summary>
        /// Service principal key
        /// </summary>
        public const string ServicePrincipalKey = "ServicePrincipal";

        /// <summary>
        /// The client ID to use when authenticating with AAD
        /// </summary>
        public const string AADClientIdKey = "AADClientId";

        /// <summary>
        /// ServicePrincipal Secret Key
        /// </summary>
        public const string ServicePrincipalSecretKey = "ServicePrincipalSecret";

        /// <summary>
        /// Environment name
        /// </summary>
        public const string EnvironmentKey = "Environment";

        public const string OptimizeRecordedFileKey = "OptimizeRecordedFile";

        #region Tokens
        /// <summary>
        /// A raw JWT token for AAD authentication
        /// </summary>
        public const string RawTokenKey = "RawToken";

        /// <summary>
        /// A raw JWT token for Graph authentication
        /// </summary>
        public const string RawGraphTokenKey = "RawGraphToken";

        /// <summary>
        /// HttpRecorderMode
        /// </summary>
        public const string HttpRecorderModeKey = "HttpRecorderMode";
        #endregion
        
        #region URI's

        /// <summary>
        /// AAD token Audience Uri 
        /// </summary>
        public const string AADTokenAudienceUriKey = "AADTokenAudienceUri";

        /// <summary>
        /// 
        /// </summary>
        public const string GraphTokenAudienceUriKey = "GraphTokenAudienceUri";

        /// <summary>
        /// The key inside the connection string for the base management URI
        /// </summary>
        public const string BaseUriKey = "BaseUri";

        /// <summary>
        /// The key inside the connection string for AD Graph URI
        /// </summary>
        public const string GraphUriKey = "GraphUri";

        /// <summary>
        /// The key inside the connection string for AD Gallery URI
        /// </summary>
        public const string GalleryUriKey = "GalleryUri";

        /// <summary>
        /// The key inside the connection string for the Ibiza Portal URI
        /// </summary>
        public const string IbizaPortalUriKey = "IbizaPortalUri";

        /// <summary>
        /// The key inside the connection string for the RDFE Portal URI
        /// </summary>
        public const string RdfePortalUriKey = "RdfePortalUri";

        /// <summary>
        /// The key inside the connection string for the DataLake FileSystem URI suffix
        /// </summary>
        public const string DataLakeStoreServiceUriKey = "DataLakeStoreServiceUri";

        /// <summary>
        /// The key inside the connection string for the Kona Catalog URI
        /// </summary>
        public const string DataLakeAnalyticsJobAndCatalogServiceUriKey = "DataLakeAnalyticsJobAndCatalogServiceUri";

        /// <summary>
        /// Endpoint to use for AAD authentication
        /// </summary>
        public const string AADAuthUriKey = "AADAuthUri";   //Most probably ActiveDirectoryAuthority

        /// <summary>
        /// Publishsettings endpoint
        /// </summary>
        public const string PublishSettingsFileUriKey = "PublishSettingsFileUri";

        /// <summary>
        /// Service Management endpoint
        /// </summary>
        public const string ServiceManagementUriKey = "ServiceManagementUri";

        /// <summary>
        /// Resource Management endpoint
        /// </summary>
        public const string ResourceManagementUriKey = "ResourceManagementUri";

        #endregion
    }
}
