using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class RemoteAppTestBase
    {
        protected RemoteAppManagementClient GetClient()
        {
            //RemoteAppManagementClient client = TestBase.GetServiceClient<RemoteAppManagementClient>(new CSMTestEnvironmentFactory());

            //return client;
            return null;
        }
    }
}
