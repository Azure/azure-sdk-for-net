// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.EventHubs.Models
{
    public abstract partial class EventHubsApplicationGroupPolicy
    {
        /// <summary> Initializes a new instance of <see cref="EventHubsApplicationGroupPolicy"/>. </summary>
        /// <param name="name"> The Name of this policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected EventHubsApplicationGroupPolicy(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
