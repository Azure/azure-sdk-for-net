using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.RemoteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteApp.Tests
{
    public class RemoteAppTestBase : TestBase
    {
        protected RemoteAppManagementClient GetRemoteAppManagementClient()
        {
            RemoteAppManagementClient client =
                TestBase.GetServiceClient<RemoteAppManagementClient>(new RDFETestEnvironmentFactory());
            
            client.RdfeNamespace = "rdst15";

            return client;
        }

    }
}
