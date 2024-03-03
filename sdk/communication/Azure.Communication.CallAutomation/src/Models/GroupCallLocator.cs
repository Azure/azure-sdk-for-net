// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The group call locator. </summary>
    public class GroupCallLocator : CallLocator
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GroupCallLocator"/>.
        /// </summary>
        /// <param name="id">The group call id.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public GroupCallLocator(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (id.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", nameof(id));
            }
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CallLocator other)
            => other is GroupCallLocator otherId && otherId.Id == Id;
    }
}
