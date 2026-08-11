// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Built-in roles supported by Web PubSub Chat. </summary>
    public static class ChatRoles
    {
        /// <summary> The default user role with room creation and room listing permissions. </summary>
        public const string UserNormal = "user.normal";

        /// <summary> The room member role with publish, history, and invite permissions. </summary>
        public const string RoomMember = "room.member";

        /// <summary> The room operator role with all room permissions, including removing users. </summary>
        public const string RoomOperator = "room.operator";
    }
}
