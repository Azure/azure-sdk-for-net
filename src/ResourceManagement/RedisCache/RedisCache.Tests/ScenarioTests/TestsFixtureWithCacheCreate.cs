// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Management.Redis;
using Microsoft.Azure.Management.Redis.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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
        public string RedisCacheName = "hydracache1";
        public string Location = "North Central US";
        private RedisCacheManagementHelper _redisCacheManagementHelper;
        private MockContext _context;
        
        public TestsFixtureWithCacheCreate()
        {
            _context = new MockContext();
            MockContext.Start(this.GetType().FullName, ".ctor");
            try
            {
                _redisCacheManagementHelper = new RedisCacheManagementHelper(this, _context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                ResourceGroupName = TestUtilities.GenerateName("hydra1");
                _redisCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, Location);
                _redisCacheManagementHelper.TryCreatingCache(ResourceGroupName, RedisCacheName, Location);
            }
            catch (Exception)
            {
                Cleanup();
                throw;
            }
            finally
            {
                HttpMockServer.Flush();
            }
        }

        public void Dispose()
        {
            Cleanup();    
        }

        private void Cleanup()
        {
            HttpMockServer.Initialize(this.GetType().FullName, ".cleanup");
            _context.Dispose();
        }
    }
}
