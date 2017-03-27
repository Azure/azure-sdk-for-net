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

using Hyak.Common;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class UserTests
    {
        [Fact]
        public void CreateDeleteUserTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                //Arrange
                var client = new GraphTestBase();
                
                //Test
                User user = client.CreateUser();
                client.DeleteUser(user.UserPrincipalName);
                //verify the user has been deleted.
                Assert.Throws(typeof(CloudException), () => { client.SearchUser(user.UserPrincipalName); });
            }
        }
    }
}
