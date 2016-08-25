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
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class GroupTests : GraphTestBase
    {
        [Fact]
        public void CreateDeleteGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                //Test
                ADGroup group = CreateGroup(context);
                DeleteGroup(context, group.ObjectId);
                //verify the group has been deleted.
                Assert.Throws(typeof(GraphErrorException), () => { SearchGroup(context, group.ObjectId); });
            }
        }

        [Fact]
        public void AddRemoveMemberTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                //Arrange
                ADGroup group = CreateGroup(context);
                User user = CreateUser(context);

                //test
                AddMember(context, group, user);

                //Verify
                IEnumerable<string> groupIds = GetMemberGroups(context, user);
                string matched = groupIds.FirstOrDefault(p => p == group.ObjectId);
                Assert.Equal(matched, group.ObjectId);

                //Test
                RemoveMember(context, group, user);

                //Verify
                groupIds = GetMemberGroups(context, user);
                matched = groupIds.FirstOrDefault(p => p == group.ObjectId);
                Assert.True(string.IsNullOrEmpty(matched));

                //Cleanup
                DeleteGroup(context, group.ObjectId);
                DeleteUser(context, user.ObjectId);
            }
        }
    }
}
