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
    using Xunit;

    public class GetConfigurationTests
    {
        [Fact]
        [Trait("Feature", "Networks")]
        [Trait("Operation", "GetConfiguration")]
        public void GetConfigurationThrowsResourceNotFoundWhenNoConfigurationExists()
        {
            using (NetworkTestClient testClient = new NetworkTestClient())
            {
                testClient.EnsureNoNetworkConfigurationExists();

                try
                {
                    testClient.GetNetworkConfiguration();
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                }
            }
        }
    }
}
