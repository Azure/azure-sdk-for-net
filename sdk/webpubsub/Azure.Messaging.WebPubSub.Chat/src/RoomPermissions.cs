// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Built-in room permissions supported by Web PubSub Chat. </summary>
    public static class RoomPermissions
    {
        /// <summary> Allows a room member to invite users to a room. </summary>
        public const string InviteUser = "room.invite";

        /// <summary> Allows a room operator to remove users from a room. </summary>
        public const string RemoveUser = "room.remove_user";

        /// <summary> Allows a room member to read message history. </summary>
        public const string History = "room.history";

        /// <summary> Allows a room member to publish messages. </summary>
        public const string PublishMessage = "room.publish_message";

        // The following permissions are not currently supported by the service.
        // Uncomment them once they become available.
        // See https://learn.microsoft.com/en-us/azure/azure-web-pubsub/chat-howto-roles-permissions

        //// <summary> Allows a room member to leave a room. </summary>
        //public const string LeaveRoom = "room.leave";

        //// <summary> Allows a room operator to delete a room. </summary>
        //public const string DeleteRoom = "room.delete_room";

        //// <summary> Allows a room operator to mute or unmute a room. </summary>
        //public const string MuteUnmute = "room.mute";

        //// <summary> Allows a room operator to freeze or unfreeze a room. </summary>
        //public const string FreezeUnfreeze = "room.freeze";

        //// <summary> Allows a room member to publish images. </summary>
        //public const string PublishImage = "room.publish_image";

        //// <summary> Allows a room member to publish attachments. </summary>
        //public const string PublishAttachment = "room.publish_attachment";

        //// <summary> Allows a room member to publish reactions. </summary>
        //public const string PublishReactions = "room.publish_reactions";
    }
}
