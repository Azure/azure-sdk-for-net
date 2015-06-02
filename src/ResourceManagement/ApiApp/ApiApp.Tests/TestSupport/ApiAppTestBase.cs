using System;
using System.Net.Sockets;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;

namespace Microsoft.Azure.Management.ApiApps.Tests.TestSupport
{
    public abstract class ApiAppTestBase : TestBase, IDisposable
    {
        private const string DefaultTestLocation = "South Central US";
        protected UndoContext UndoCtx;
        private bool disposed;

        protected string TestLocation { get; set; }

        protected ApiAppTestBase()
        {
            TestLocation = DefaultTestLocation;
            UndoCtx = UndoContext.Current;
            disposed = false;
        }


        public virtual void Dispose()
        {
            if (!disposed)
            {
                UndoCtx.Dispose();
            }
            disposed = true;
        }

        protected void WithNewGroup(Action<string> test)
        {
            string groupName;
            using (var armMgmt = GetArmClient<ResourceManagementClient>())
            {
                groupName = TestUtilities.GenerateName("apiapptest");
                armMgmt.ResourceGroups.CreateOrUpdateAsync(groupName, new ResourceGroup {Location = TestLocation});
            }
            test(groupName);
        }

        protected void WithNewGroup<TClient>(Action<string, TClient> test) where TClient : class, IDisposable
        {
            WithNewGroup(groupName =>
            {
                using (var client = GetArmClient<TClient>())
                {
                    test(groupName, client);
                }
            });
        }

        protected T GetArmClient<T>() where T : class
        {
            return GetServiceClient<T>(new CSMTestEnvironmentFactory());
        }
    }
}
