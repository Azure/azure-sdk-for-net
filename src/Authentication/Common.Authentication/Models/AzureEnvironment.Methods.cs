// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Properties;
using Microsoft.Azure.Common.Authentication.Utilities;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public partial class AzureEnvironment
    {
        /// <summary>
        /// Predefined Microsoft Azure environments
        /// </summary>
        public static Dictionary<string, AzureEnvironment> PublicEnvironments
        {
            get { return environments; }
        }

        private const string storageFormatTemplate = "{{0}}://{{1}}.{0}.{1}/";

        private string EndpointFormatFor(string service)
        {
            string suffix = GetEndpointSuffix(AzureEnvironment.Endpoint.StorageEndpointSuffix);

            if (!string.IsNullOrEmpty(suffix))
            {
                suffix = string.Format(storageFormatTemplate, service, suffix);
            }

            return suffix;
        }

        /// <summary>
        /// The storage service blob endpoint format.
        /// </summary>
        private string StorageBlobEndpointFormat()
        {
            return EndpointFormatFor("blob");
        }

        /// <summary>
        /// The storage service queue endpoint format.
        /// </summary>
        private string StorageQueueEndpointFormat()
        {
            return EndpointFormatFor("queue");
        }

        /// <summary>
        /// The storage service table endpoint format.
        /// </summary>
        private string StorageTableEndpointFormat()
        {
            return EndpointFormatFor("table");
        }

        /// <summary>
        /// The storage service file endpoint format.
        /// </summary>
        private string StorageFileEndpointFormat()
        {
            return EndpointFormatFor("file");
        }

        private static readonly Dictionary<string, AzureEnvironment> environments =
            new Dictionary<string, AzureEnvironment>(StringComparer.InvariantCultureIgnoreCase)
        {
            {
                EnvironmentName.AzureCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureCloud,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.AzurePublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.AzureServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.AzureResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.AzureManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.AzureActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.AzureServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.AzureStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.GalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.AzureSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.AzureGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.AzureTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.AzureKeyVaultDnsSuffix},
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.AzureKeyVaultServiceEndpointResourceId},
                        { AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, AzureEnvironmentConstants.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix},
                        { AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, AzureEnvironmentConstants.AzureDataLakeStoreFileSystemEndpointSuffix},
                        { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.AzureGraphEndpoint}
                    }
                }
            },
            {
                EnvironmentName.AzureChinaCloud,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureChinaCloud,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.ChinaPublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.ChinaServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.ChinaResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.ChinaManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.ChinaActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.ChinaServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.ChinaStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.ChinaGalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.ChinaSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.ChinaGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, AzureEnvironmentConstants.ChinaTrafficManagerDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.ChinaKeyVaultDnsSuffix },
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.ChinaKeyVaultServiceEndpointResourceId },
                         { AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.ChinaGraphEndpoint}
                       // TODO: DataLakeAnalytics and ADL do not have a China endpoint yet. Once they do, add them here.
                    }
                }
            },
            {
                EnvironmentName.AzureUSGovernment,
                new AzureEnvironment
                {
                    Name = EnvironmentName.AzureUSGovernment,
                    Endpoints = new Dictionary<AzureEnvironment.Endpoint, string>
                    {
                        { AzureEnvironment.Endpoint.PublishSettingsFileUrl, AzureEnvironmentConstants.USGovernmentPublishSettingsFileUrl },
                        { AzureEnvironment.Endpoint.ServiceManagement, AzureEnvironmentConstants.USGovernmentServiceEndpoint },
                        { AzureEnvironment.Endpoint.ResourceManager, AzureEnvironmentConstants.USGovernmentResourceManagerEndpoint },
                        { AzureEnvironment.Endpoint.ManagementPortalUrl, AzureEnvironmentConstants.USGovernmentManagementPortalUrl },
                        { AzureEnvironment.Endpoint.ActiveDirectory, AzureEnvironmentConstants.USGovernmentActiveDirectoryEndpoint },
                        { AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId, AzureEnvironmentConstants.USGovernmentServiceEndpoint },
                        { AzureEnvironment.Endpoint.StorageEndpointSuffix, AzureEnvironmentConstants.USGovernmentStorageEndpointSuffix },
                        { AzureEnvironment.Endpoint.Gallery, AzureEnvironmentConstants.USGovernmentGalleryEndpoint },
                        { AzureEnvironment.Endpoint.SqlDatabaseDnsSuffix, AzureEnvironmentConstants.USGovernmentSqlDatabaseDnsSuffix },
                        { AzureEnvironment.Endpoint.Graph, AzureEnvironmentConstants.USGovernmentGraphEndpoint },
                        { AzureEnvironment.Endpoint.TrafficManagerDnsSuffix, null },
                        { AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix, AzureEnvironmentConstants.USGovernmentKeyVaultDnsSuffix},
                        { AzureEnvironment.Endpoint.AzureKeyVaultServiceEndpointResourceId, AzureEnvironmentConstants.USGovernmentKeyVaultServiceEndpointResourceId},
                        { AzureEnvironment.Endpoint.AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix, null},
                        { AzureEnvironment.Endpoint.AzureDataLakeStoreFileSystemEndpointSuffix, null},
                        {AzureEnvironment.Endpoint.GraphEndpointResourceId, AzureEnvironmentConstants.USGovernmentGraphEndpoint}
                    }
                }
            }
        };

        public Uri GetEndpointAsUri(AzureEnvironment.Endpoint endpoint)
        {
            if (Endpoints.ContainsKey(endpoint))
            {
                return new Uri(Endpoints[endpoint]);
            }

            return null;
        }

        public string GetEndpoint(AzureEnvironment.Endpoint endpoint)
        {
            if (Endpoints.ContainsKey(endpoint))
            {
                return Endpoints[endpoint];
            }

            return null;
        }

        public AzureEnvironment.Endpoint GetTokenAudience(AzureEnvironment.Endpoint targetEndpoint)
        {
            return targetEndpoint == AzureEnvironment.Endpoint.Graph
                ? AzureEnvironment.Endpoint.GraphEndpointResourceId
                : AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId;
        }

    

        public bool IsEndpointSet(AzureEnvironment.Endpoint endpoint)
        {
            return Endpoints.IsPropertySet(endpoint);
        }

        public bool IsEndpointSetToValue(AzureEnvironment.Endpoint endpoint, string url)
        {
            if (url == null && !Endpoints.IsPropertySet(endpoint))
            {
                return true;
            }
            if (url != null && Endpoints.IsPropertySet(endpoint))
            {
                return GetEndpoint(endpoint)
                    .Trim(new[] { '/' })
                    .Equals(url.Trim(new[] { '/' }), StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public string GetEndpointSuffix(AzureEnvironment.Endpoint endpointSuffix)
        {
            if (Endpoints.ContainsKey(endpointSuffix))
            {
                return Endpoints[endpointSuffix];
            }

            return null;
        }

        /// <summary>
        /// Gets the endpoint for storage blob.
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="useHttps">Use Https when creating the URI. Defaults to true.</param>
        /// <returns>The fully qualified uri to the blob service</returns>
        public Uri GetStorageBlobEndpoint(string accountName, bool useHttps = true)
        {
            return new Uri(string.Format(StorageBlobEndpointFormat(), useHttps ? "https" : "http", accountName));
        }

        /// <summary>
        /// Gets the endpoint for storage queue.
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="useHttps">Use Https when creating the URI. Defaults to true.</param>
        /// <returns>The fully qualified uri to the queue service</returns>
        public Uri GetStorageQueueEndpoint(string accountName, bool useHttps = true)
        {
            return new Uri(string.Format(StorageQueueEndpointFormat(), useHttps ? "https" : "http", accountName));
        }

        /// <summary>
        /// Gets the endpoint for storage table.
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="useHttps">Use Https when creating the URI. Defaults to true.</param>
        /// <returns>The fully qualified uri to the table service</returns>
        public Uri GetStorageTableEndpoint(string accountName, bool useHttps = true)
        {
            return new Uri(string.Format(StorageTableEndpointFormat(), useHttps ? "https" : "http", accountName));
        }

        /// <summary>
        /// Gets the endpoint for storage file.
        /// </summary>
        /// <param name="accountName">The account name</param>
        /// <param name="useHttps">Use Https when creating the URI. Defaults to true.</param>
        /// <returns>The fully qualified uri to the file service</returns>
        public Uri GetStorageFileEndpoint(string accountName, bool useHttps = true)
        {
            return new Uri(string.Format(StorageFileEndpointFormat(), useHttps ? "https" : "http", accountName));
        }

        /// <summary>
        /// Gets the management portal URI with a particular realm suffix if supplied
        /// </summary>
        /// <param name="realm">Realm for user's account</param>
        /// <returns>Url to management portal.</returns>
        public string GetManagementPortalUrlWithRealm(string realm = null)
        {
            if (realm != null)
            {
                realm = string.Format(Resources.PublishSettingsFileRealmFormat, realm);
            }
            else
            {
                realm = string.Empty;
            }
            return GetEndpointAsUri(Endpoint.ManagementPortalUrl) + realm;
        }

        /// <summary>
        /// Get the publish settings file download url with a realm suffix if needed.
        /// </summary>
        /// <param name="realm">Realm for user's account</param>
        /// <returns>Url to publish settings file</returns>
        public string GetPublishSettingsFileUrlWithRealm(string realm = null)
        {
            if (realm != null)
            {
                realm = string.Format(Resources.PublishSettingsFileRealmFormat, realm);
            }
            else
            {
                realm = string.Empty;
            }
            return GetEndpointAsUri(Endpoint.PublishSettingsFileUrl) + realm;
        }

        public enum Endpoint
        {
            ActiveDirectoryServiceEndpointResourceId,

            AdTenant,

            Gallery,

            ManagementPortalUrl,

            ServiceManagement,

            PublishSettingsFileUrl,

            ResourceManager,

            SqlDatabaseDnsSuffix,

            StorageEndpointSuffix,

            ActiveDirectory,

            Graph,

            TrafficManagerDnsSuffix,

            AzureKeyVaultDnsSuffix,

            AzureKeyVaultServiceEndpointResourceId,
            
            AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix,

            AzureDataLakeStoreFileSystemEndpointSuffix,

            GraphEndpointResourceId
        }
    }

    public static class EnvironmentName
    {
        public const string AzureCloud = "AzureCloud";

        public const string AzureChinaCloud = "AzureChinaCloud";

        public const string AzureUSGovernment = "AzureUSGovernment";
    }

    public static class AzureEnvironmentConstants
    {
        public const string AzureServiceEndpoint = "https://management.core.windows.net/";

        public const string ChinaServiceEndpoint = "https://management.core.chinacloudapi.cn/";

        public const string USGovernmentServiceEndpoint = "https://management.core.usgovcloudapi.net/";

        public const string AzureResourceManagerEndpoint = "https://management.azure.com/";

        public const string ChinaResourceManagerEndpoint = "https://management.chinacloudapi.cn/";

        public const string USGovernmentResourceManagerEndpoint = "https://management.usgovcloudapi.net/";

        public const string GalleryEndpoint = "https://gallery.azure.com/";

        public const string ChinaGalleryEndpoint = "https://gallery.chinacloudapi.cn/";

        public const string USGovernmentGalleryEndpoint = "https://gallery.usgovcloudapi.net/";

        public const string AzurePublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301775";

        public const string ChinaPublishSettingsFileUrl = "http://go.microsoft.com/fwlink/?LinkID=301776";

        public const string USGovernmentPublishSettingsFileUrl = "https://manage.windowsazure.us/publishsettings/index";

        public const string AzureManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=254433";

        public const string ChinaManagementPortalUrl = "http://go.microsoft.com/fwlink/?LinkId=301902";

        public const string USGovernmentManagementPortalUrl = "https://manage.windowsazure.us";

        public const string AzureStorageEndpointSuffix = "core.windows.net";

        public const string ChinaStorageEndpointSuffix = "core.chinacloudapi.cn";

        public const string USGovernmentStorageEndpointSuffix = "core.usgovcloudapi.net";

        public const string AzureSqlDatabaseDnsSuffix = ".database.windows.net";

        public const string ChinaSqlDatabaseDnsSuffix = ".database.chinacloudapi.cn";

        public const string USGovernmentSqlDatabaseDnsSuffix = ".database.usgovcloudapi.net";

        public const string AzureActiveDirectoryEndpoint = "https://login.microsoftonline.com/";

        public const string ChinaActiveDirectoryEndpoint = "https://login.chinacloudapi.cn/";

        public const string USGovernmentActiveDirectoryEndpoint = "https://login.microsoftonline.com/";

        public const string AzureGraphEndpoint = "https://graph.windows.net/";

        public const string ChinaGraphEndpoint = "https://graph.chinacloudapi.cn/";

        public const string USGovernmentGraphEndpoint = "https://graph.windows.net/";

        public const string AzureTrafficManagerDnsSuffix = "trafficmanager.net";

        public const string ChinaTrafficManagerDnsSuffix = "trafficmanager.cn";

        public const string AzureKeyVaultDnsSuffix = "vault.azure.net";

        public const string ChinaKeyVaultDnsSuffix = "vault.azure.cn";

        public const string USGovernmentKeyVaultDnsSuffix = "vault.usgovcloudapi.net";

        public const string AzureKeyVaultServiceEndpointResourceId = "https://vault.azure.net";

        public const string ChinaKeyVaultServiceEndpointResourceId = "https://vault.azure.cn";

        public const string USGovernmentKeyVaultServiceEndpointResourceId = "https://vault.usgovcloudapi.net";

        public const string AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix = "azuredatalakeanalytics.net";

        public const string AzureDataLakeStoreFileSystemEndpointSuffix = "azuredatalakestore.net";
    }
}
