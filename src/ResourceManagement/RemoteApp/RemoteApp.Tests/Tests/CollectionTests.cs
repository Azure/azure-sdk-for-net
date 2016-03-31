using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using RemoteApp.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Management.RemoteApp.Tests
{
    public class CollectionTests : RemoteAppTestBase
    {
        string groupName = "Default-RemoteApp-WestUS";

        [Fact(Skip = "TODO, 6983662: Bring tests up to date with sdk")]
        public void GetCollectionListTest()
        {
            RemoteAppManagementClient raClient = null;
            CollectionListResult collections = null;
            RemoteAppDelegatingHandler handler = new RemoteAppDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                raClient = GetClient(context, handler);

                collections = raClient.Collection.ListInResourceGroup(groupName);

                Assert.NotNull(collections);
                Assert.NotEmpty(collections.Value);

                foreach (Collection col in collections.Value)
                {
                    Assert.Equal("microsoft.remoteapp/collections", col.Type);
                }
            }
        }
    }
}
