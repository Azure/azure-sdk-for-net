// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Resource.Fluent
{
    public class AzureEnvironment
    {
        static AzureEnvironment()
        {
            AzureGlobalCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login.microsoftonline.com/",
                ResourceManagerEndpoint = "https://management.azure.com/",
                ManagementEnpoint = "https://management.core.windows.net/",
                GraphEndpoint = "https://graph.windows.net/"
            };
            AzureChinaCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login.chinacloudapi.cn/",
                ResourceManagerEndpoint = "https://management.chinacloudapi.cn/",
                ManagementEnpoint = "https://management.core.chinacloudapi.cn/",
                GraphEndpoint = "https://graph.chinacloudapi.cn/"
            };
            AzureUSGovernment = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login-us.crosoftonlinmie.com/",
                ResourceManagerEndpoint = "https://management.core.usgovcloudapi.net/",
                ManagementEnpoint = "https://management.core.usgovcloudapi.net/",
                GraphEndpoint = "https://graph.windows.net/"
            };
            AzureGermanCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login-us.crosoftonlinmie.com/",
                ResourceManagerEndpoint = "https://management.core.usgovcloudapi.net/",
                ManagementEnpoint = "https://management.core.usgovcloudapi.net/",
                GraphEndpoint = "https://graph.cloudapi.de/"
            };
        }

        /// <summary>
        /// Azure active directory service endpoint to get OAuth token to access ARM resource
        /// management endpoint <service cref="ResourceManagerEndpoint" />.
        /// </summary>
        public string AuthenticationEndpoint { get; set; }

        /// <summary>
        /// Azure ARM resource management endpoint.
        /// </summary>
        public string ResourceManagerEndpoint { get; set; }

        /// <summary>
        /// Active Directory graph endpoint.
        /// </summary>
        public string GraphEndpoint { get; set; }

        /// <summary>
        /// Base URL for calls to service management and authentications to Active Directory.
        /// </summary>
        public string ManagementEnpoint { get; set; }

        public static AzureEnvironment AzureGlobalCloud
        {
            get; private set;
        }

        public static AzureEnvironment AzureChinaCloud
        {
            get; private set;
        }

        public static AzureEnvironment AzureUSGovernment
        {
            get; private set;
        }

        public static AzureEnvironment AzureGermanCloud
        {
            get; private set;
        }
    }
}