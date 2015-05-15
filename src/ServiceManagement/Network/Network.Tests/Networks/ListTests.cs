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

namespace Network.Tests.Networks
{
    using System.Linq;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class ListTests
    {
        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "ListConfigurations")]
        public void ListWhenNoConfigurationExists()
        {
            using (NetworkTestClient testClient = new NetworkTestClient())
            {
                testClient.EnsureNoNetworkConfigurationExists();

                NetworkListResponse listResponse = testClient.ListNetworkConfigurations();
                Assert.NotNull(listResponse);
                Assert.False(listResponse.Any(), "List() should have returned an empty list if no configurations exist.");
            }
        }
    }
}
