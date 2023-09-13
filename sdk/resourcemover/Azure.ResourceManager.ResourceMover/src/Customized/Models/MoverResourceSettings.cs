// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    public abstract partial class MoverResourceSettings
    {
        /// <summary> Initializes a new instance of MoverResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        protected MoverResourceSettings(string targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            TargetResourceName = targetResourceName;
        }
    }
}
