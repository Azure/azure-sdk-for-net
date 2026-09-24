// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    [TestFixture]
    public class ChatRolesAndPermissionsTests
    {
        [Test]
        public void CanBuildCustomRoleFromBuiltInPermissions()
        {
            var role = new WebPubSubChatRole(new[]
            {
                ChatPermission.RoomPublishMessage,
                ChatPermission.RoomHistory,
                ChatPermission.RoomInvite,
            });

            Assert.That(
                role.Permissions,
                Is.EquivalentTo(new[]
                {
                    ChatPermission.RoomPublishMessage,
                    ChatPermission.RoomHistory,
                    ChatPermission.RoomInvite,
                }));
        }

        [Test]
        public void ChatRoleConstructor_NullPermissions_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubChatRole((IEnumerable<ChatPermission>)null));
        }
    }
}
