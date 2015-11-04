namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    public static class IntuneClientHelper
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A resource management client, created from the current context (environment variables)</returns>
        public static IntuneResourceManagementClient GetIntuneResourceManagementClient(MockContext context)
        {
            if (intuneClient == null)
            {
                intuneClient = context.GetServiceClient<IntuneResourceManagementClient>();
                var location = intuneClient.GetLocationByHostName();
                asuHostName = location.HostName;
            }
            return intuneClient;
        }
        private static IntuneResourceManagementClient intuneClient;
        /// <summary>
        /// ASU host name for the tenant
        /// </summary>
        private static string asuHostName;
        internal static string AsuHostName
        {
            get
            {
                if (asuHostName == null)
                {
                    var location = intuneClient.GetLocationByHostName();
                    asuHostName = location.HostName;                    
                }

                return asuHostName;
            }
        }
    }
}
