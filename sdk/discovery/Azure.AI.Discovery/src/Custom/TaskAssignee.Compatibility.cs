// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Discovery
{
    public partial class TaskAssignee
    {
        /// <summary> Initializes a new instance of <see cref="TaskAssignee"/>. </summary>
        /// <param name="id"> The unique identifier of the assignee. </param>
        /// <param name="type"> The type of assignee. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public TaskAssignee(string id, DiscoveryActorType type) : this()
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            Type = type;
        }
    }
}
