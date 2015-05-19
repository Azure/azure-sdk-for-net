// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System.Net;
using Microsoft.Azure.Management.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Xunit;

namespace Microsoft.Azure.Management.Search.Tests
{
    public sealed class AdminKeyTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CanListAdminKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                // List admin keys
                AdminKeyResponse adminKeyResponse = 
                    searchMgmt.AdminKeys.List(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.Equal(HttpStatusCode.OK, adminKeyResponse.StatusCode);
                Assert.NotNull(adminKeyResponse.PrimaryKey);
                Assert.NotNull(adminKeyResponse.SecondaryKey);
                Assert.NotEmpty(adminKeyResponse.PrimaryKey);
                Assert.NotEmpty(adminKeyResponse.SecondaryKey);
            });
        }
    }
}
