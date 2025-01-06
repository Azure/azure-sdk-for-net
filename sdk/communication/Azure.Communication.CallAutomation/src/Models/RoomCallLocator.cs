// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The room call locator. </summary>
    public class RoomCallLocator : CallLocator
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RoomCallLocator"/>.
        /// </summary>
        /// <param name="id">The room call id.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public RoomCallLocator(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CallLocator other)
            => other is RoomCallLocator otherId && otherId.Id == Id;
    }
}
