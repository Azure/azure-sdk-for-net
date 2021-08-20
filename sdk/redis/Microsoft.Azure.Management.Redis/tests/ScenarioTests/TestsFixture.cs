// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class TestsFixture : TestBase, IDisposable
    {
        public string ResourceGroupName { set; get; }
        public string RedisCacheName { set; get; }

        private RedisCacheManagementHelper _redisCacheManagementHelper;
        private MockContext _context = null;

        public TestsFixture()
        {
            _context = new MockContext();
            MockContext.Start(this.GetType(), ".ctor");
            try
            {
                _redisCacheManagementHelper = new RedisCacheManagementHelper(this, _context);
                _redisCacheManagementHelper.TryRegisterSubscriptionForResource();

                ResourceGroupName = TestUtilities.GenerateName("RedisCreateUpdate");
                RedisCacheName = TestUtilities.GenerateName("RedisCreateUpdate");
                _redisCacheManagementHelper.TryCreateResourceGroup(ResourceGroupName, RedisCacheManagementHelper.Location);
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

