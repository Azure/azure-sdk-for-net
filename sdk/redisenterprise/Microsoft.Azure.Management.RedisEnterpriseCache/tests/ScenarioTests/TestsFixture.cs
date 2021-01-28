// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.RedisEnterprise;
using Microsoft.Azure.Management.RedisEnterprise.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRedisEnterpriseCache.Tests
{
    public class TestsFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string RedisEnterpriseCacheName { set; get; }
        public string DatabaseName { set; get; }

        private RedisEnterpriseCacheManagementHelper _redisEnterpriseCacheManagementHelper;
        private MockContext _context = null;

        public TestsFixture()
        {
            _context = new MockContext();
            MockContext.Start(this.GetType(), ".ctor");
            try
            {
                _redisEnterpriseCacheManagementHelper = new RedisEnterpriseCacheManagementHelper(this, _context);
                _redisEnterpriseCacheManagementHelper.TryRegisterSubscriptionForResource();

                ResourceGroupName = TestUtilities.GenerateName("RedisEnterpriseCreateUpdate");
                RedisEnterpriseCacheName = TestUtilities.GenerateName("RedisEnterpriseCreateUpdate");
                DatabaseName = "default";
                _redisEnterpriseCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, RedisEnterpriseCacheManagementHelper.Location);
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
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Initialize(this.GetType(), ".cleanup");
            }
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}

