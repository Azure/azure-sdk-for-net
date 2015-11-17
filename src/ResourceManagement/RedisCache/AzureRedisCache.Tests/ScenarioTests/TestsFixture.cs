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
    public class TestsFixture: TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string RedisClusterCacheName = "hydraclustercache-1";
        public string ClusterCacheLocation = "East US";
        public string RedisCacheName = "hydracache-1";
        public string Location = "North Central US";
        
        public TestsFixture()
        {
            TestUtilities.StartTest();
            try
            {
                UndoContext.Current.Start();

                RedisCacheManagementHelper redisCacheManagementHelper = new RedisCacheManagementHelper(this);
                redisCacheManagementHelper.TryRegisterSubscriptionForResource();
                
                ResourceGroupName = TestUtilities.GenerateName("hydra2");
                redisCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
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
