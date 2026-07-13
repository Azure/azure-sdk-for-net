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
        public void BuiltInUserPermissionValues()
        {
            Assert.That(UserPermissions.CreateRoom, Is.EqualTo("user.create_room"));
            Assert.That(UserPermissions.FetchAllRooms, Is.EqualTo("user.fetch_all_rooms"));
        }

        [Test]
        public void BuiltInRoomPermissionValues()
        {
            Assert.That(RoomPermissions.InviteUser, Is.EqualTo("room.invite"));
            Assert.That(RoomPermissions.RemoveUser, Is.EqualTo("room.remove_user"));
            Assert.That(RoomPermissions.History, Is.EqualTo("room.history"));
            Assert.That(RoomPermissions.PublishMessage, Is.EqualTo("room.publish_message"));
        }

        [Test]
        public void BuiltInRoleValues()
        {
            Assert.That(ChatRoles.UserNormal, Is.EqualTo("user.normal"));
            Assert.That(ChatRoles.RoomMember, Is.EqualTo("room.member"));
            Assert.That(ChatRoles.RoomOperator, Is.EqualTo("room.operator"));
        }

        [Test]
        public void CanBuildCustomRoleFromBuiltInPermissions()
        {
            var role = new WebPubSubChatRole(new[]
            {
                RoomPermissions.PublishMessage,
                RoomPermissions.History,
                RoomPermissions.InviteUser,
            });

            Assert.That(
                role.Permissions,
                Is.EquivalentTo(new[] { "room.publish_message", "room.history", "room.invite" }));
        }

        [Test]
        public void ChatRoleConstructor_NullPermissions_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new WebPubSubChatRole((IEnumerable<string>)null));
        }

        [Test]
        public void BuiltInRoleCanBeAssignedToRoomMember()
        {
            var member = new WebPubSubChatRoomMember(ChatRoles.RoomOperator);

            Assert.That(member.RoleName, Is.EqualTo("room.operator"));
        }
    }
}
