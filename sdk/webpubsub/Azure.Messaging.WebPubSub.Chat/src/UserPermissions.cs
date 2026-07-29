// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Built-in user permissions supported by Web PubSub Chat. </summary>
    public static class UserPermissions
    {
        /// <summary> Allows a user to create chat rooms. </summary>
        public const string CreateRoom = "user.create_room";

        /// <summary> Allows a user to list the rooms they belong to. </summary>
        public const string FetchAllRooms = "user.fetch_all_rooms";

        // The following permissions are not currently supported by the service.
        // Uncomment them once they become available.
        // See https://learn.microsoft.com/en-us/azure/azure-web-pubsub/chat-howto-roles-permissions

        //// <summary> Allows a user to update their own information. </summary>
        //public const string UpdateOwnInfo = "user.update_own_info";

        //// <summary> Allows a user to search for other users. </summary>
        //public const string SearchUser = "user.search";

        //// <summary> Allows a user to manage their blacklist. </summary>
        //public const string Blacklist = "user.blacklist";
    }
}
