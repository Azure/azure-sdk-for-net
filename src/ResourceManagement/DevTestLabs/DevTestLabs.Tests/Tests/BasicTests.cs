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

using Microsoft.Azure.Management.DevTestLabs;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace DevTestLabs.Tests
{
    public class LabTests : DevTestLabsTestBase
    {
        // Indicates items number to create for paginated test cases
        private const int PaginatedItemsCount = 110;

        [Fact]
        public void ListLabsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetDevTestLabsClient(context);

                var labs = client.Lab.ListBySubscription().ToList();
                Assert.NotEmpty(labs);
            }
        }
    }
}
