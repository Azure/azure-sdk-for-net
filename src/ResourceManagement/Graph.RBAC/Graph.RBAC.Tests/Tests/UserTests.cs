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

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class UserTests : GraphTestBase
    {
        [Fact]
        public void CreateDeleteUserTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
               //Test
                User user = CreateUser(context);
                DeleteUser(context, user.UserPrincipalName);
                //verify the user has been deleted.
                Assert.Throws(typeof(GraphErrorException), () => { SearchUser(context, user.UserPrincipalName); });
            }
        }
    }
}
