// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    ///  The locator used for joining a group call.
    /// </summary>
    public class GroupCallLocator : CallLocator
    {
        /// <summary>The group id.</summary>
        public string GroupId { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="GroupCallLocator"/>.
        /// </summary>
        /// <param name="groupId">The group id of the call.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="groupId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="groupId"/> is empty.
        /// </exception>
        public GroupCallLocator(string groupId)
        {
            Argument.AssertNotNullOrEmpty(groupId, nameof(groupId));
            GroupId = groupId;
        }
    }
}
