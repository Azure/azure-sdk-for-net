namespace Microsoft.Azure.Management.V2.Resource
{
    public class AzureEnvironment
    {
        static AzureEnvironment()
        {
            AzureGlobalCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login.microsoftonline.com/",
                ResourceManagerEndpoint = "https://management.azure.com/",
                TokenAuidence = "https://management.core.windows.net/"
            };
            AzureChinaCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login.chinacloudapi.cn/",
                ResourceManagerEndpoint = "https://management.chinacloudapi.cn/",
                TokenAuidence = "https://management.core.chinacloudapi.cn/"
            };
            AzureUSGovernment = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login-us.crosoftonlinmie.com/",
                ResourceManagerEndpoint = "https://management.core.usgovcloudapi.net/",
                TokenAuidence = "https://management.core.usgovcloudapi.net/"
            };
            AzureGermanCloud = new AzureEnvironment()
            {
                AuthenticationEndpoint = "https://login-us.crosoftonlinmie.com/",
                ResourceManagerEndpoint = "https://management.core.usgovcloudapi.net/",
                TokenAuidence = "https://management.core.usgovcloudapi.net/"
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
        /// The unique id (in the form of url) of the ARM resource management service <service cref="ResourceManagerEndpoint" />.
        /// </summary>
        public string TokenAuidence { get; set; }


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
