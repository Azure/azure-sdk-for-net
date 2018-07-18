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
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class GroupTests
    {
        [Fact]
        public void CreateDeleteGroupTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = new GraphTestBase();

                //Test
                Group group = client.CreateGroup();
                client.DeleteGroup(group.ObjectId);
                //verify the group has been deleted.
                Assert.Throws(typeof(CloudException), () => { client.SearchGroup(group.ObjectId); });
            }
        }

        [Fact]
        public void AddRemoveMemberTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                //Arrange
                var client = new GraphTestBase();
                Group group = client.CreateGroup();
                User user = client.CreateUser();

                //test
                client.AddMember(group, user);

                //Verify
                IList<string> groupIds = client.GetMemberGroups(user);
                string matched = groupIds.FirstOrDefault(p => p == group.ObjectId);
                Assert.Equal(matched, group.ObjectId);

                //Test
                client.RemoveMember(group, user);

                //Verify
                groupIds = client.GetMemberGroups(user);
                matched = groupIds.FirstOrDefault(p => p == group.ObjectId);
                Assert.True(string.IsNullOrEmpty(matched));

                //Cleanup
                client.DeleteGroup(group.ObjectId);
                client.DeleteUser(user.ObjectId);
            }
        }
    }
}
