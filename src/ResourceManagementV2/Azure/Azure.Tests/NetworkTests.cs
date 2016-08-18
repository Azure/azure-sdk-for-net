using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class NetworkTests
    {
        [Fact]
        public void TestPublicIpAddresses()
        {
            INetworkManager manager = this.CreateNetworkManager();
            var list = manager.PublicIpAddresses.List();
            foreach(var item in list)
            {
                
            }

        }

        [Fact]
        public void TestNetworks()
        {
            INetworkManager manager = this.CreateNetworkManager();
            var list = manager.Networks.List();
            foreach (var item in list)
            {
                var name = item.Name;
            }
        }

        [Fact]
        public void TestNetworkSecurityGroups()
        {
            INetworkManager manager = this.CreateNetworkManager();
            var list = manager.NetworkSecurityGroups.List();
            foreach (var item in list)
            {
                var name = item.Name;
            }
        }

        [Fact]
        public void TestNetworkInterfaces()
        {
            INetworkManager manager = this.CreateNetworkManager();
            var list = manager.NetworkInterfaces.List();
            foreach (var item in list)
            {
                var name = item.Name;
            }
        }

        public INetworkManager CreateNetworkManager()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");
            return NetworkManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }
    }

}
