// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the key vault resource settings. </summary>
    public partial class KeyVaultResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of KeyVaultResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultResourceSettings(string targetResourceName) : this()
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            TargetResourceName = targetResourceName;
        }
    }
}
