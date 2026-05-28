// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    [CodeGenSuppress("DevBox", typeof(string))]
    public partial class DevBox
    {
        /// <summary> Initializes a new instance of <see cref="DevBox"/>. </summary>
        /// <param name="name"> Display name for the Dev Box. </param>
        /// <param name="poolName"> The name of the Dev Box pool this machine belongs to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="poolName"/> is null. </exception>
        public DevBox(string name, string poolName)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(poolName, nameof(poolName));

            Name = name;
            PoolName = poolName;
        }

        /// <summary> Indicates whether the owner of the Dev Box is a local administrator. </summary>
        public LocalAdministratorStatus? LocalAdministratorStatus { get; set; }
    }
}
