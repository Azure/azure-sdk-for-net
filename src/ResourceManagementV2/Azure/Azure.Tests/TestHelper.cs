using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Tests
{
    public class TestHelper
    {
        public static INetworkManager CreateNetworkManager()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");
            return NetworkManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }
    }
}
