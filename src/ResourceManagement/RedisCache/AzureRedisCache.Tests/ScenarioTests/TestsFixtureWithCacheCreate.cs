using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisCache.Tests
{
    public class TestsFixtureWithCacheCreate : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string RedisCacheName = "hydracache-1";
        public string Location = "North Central US";
        
        public TestsFixtureWithCacheCreate()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();

                RedisCacheManagementHelper redisCacheManagementHelper = new RedisCacheManagementHelper(this);
                redisCacheManagementHelper.TryRegisterSubscriptionForResource();
                
                ResourceGroupName = TestUtilities.GenerateName("hydra1");
                redisCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
                redisCacheManagementHelper.TryCreatingCache(ResourceGroupName, RedisCacheName, Location);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }

        public void Dispose()
        {
            Cleanup();    
        }
        private void Cleanup()
        {
            UndoContext.Current.UndoAll();
        }
    }
}
