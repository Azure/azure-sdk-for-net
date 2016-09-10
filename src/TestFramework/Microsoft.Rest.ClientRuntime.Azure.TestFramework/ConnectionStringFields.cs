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
    
    /*
    /// <summary>
    /// Collapse
    /// </summary>
    public static partial class ExtMethods
    {
        /// <summary>
        /// Allow to get value for key (either title case or lowercase)
        /// This allows users to set the connection string without worrying about case sensitivity of the keys in the key-value pairs within
        /// connection string
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueUsingCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {   
            string valueForKey;
            if(dictionary.TryGetValue(keyName, out valueForKey))
            {
                return valueForKey;
            }
            else if(dictionary.TryGetValue(keyName.ToLower(), out valueForKey))
            {
                return valueForKey;
            }

            return valueForKey;
        }

        /// <summary>
        /// Searches dictionary with key as provided as well as key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static bool ContainsCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {            
            if (dictionary.ContainsKey(keyName))
            {
                return true;
            }
            if (dictionary.ContainsKey(keyName.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the dictionary first by searching for key as provided then does a second pass for key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static void UpdateDictionary(this Dictionary<string, string> dictionary, string keyName, string value)
        {
            if(dictionary.ContainsKey(keyName))
            {
                dictionary[keyName] = value;
            }
            else if(dictionary.ContainsKey(keyName.ToLower()))
            {
                dictionary[keyName.ToLower()] = value;
            }
        }
    }
    */
}
