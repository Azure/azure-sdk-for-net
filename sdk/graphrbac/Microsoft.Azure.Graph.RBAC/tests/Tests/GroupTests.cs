// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;
using Microsoft.Graph.RBAC.Tests.Infrastructure;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class GroupTests : GraphTestBase
    {
        [Fact]
        public void CreateDeleteGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                //Test
                ADGroup group = CreateGroup(context);
                DeleteGroup(context, group.ObjectId);
                //verify the group has been deleted.
                Assert.Throws<GraphErrorException>(() => { SearchGroup(context, group.ObjectId); });
            }
        }

        [Fact]
        public void AddRemoveMemberTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
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

