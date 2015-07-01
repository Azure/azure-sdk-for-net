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
    public sealed class QueryKeyTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CanListQueryKeys()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                ListQueryKeysResponse queryKeyResponse =
                    searchMgmt.QueryKeys.List(Data.ResourceGroupName, Data.SearchServiceName);

                Assert.Equal(HttpStatusCode.OK, queryKeyResponse.StatusCode);
                Assert.Equal(1, queryKeyResponse.QueryKeys.Count);
                Assert.Null(queryKeyResponse.QueryKeys[0].Name);   // Default key has no name.
                Assert.NotNull(queryKeyResponse.QueryKeys[0].Key);
                Assert.NotEmpty(queryKeyResponse.QueryKeys[0].Key);
            });
        }
    }
}
