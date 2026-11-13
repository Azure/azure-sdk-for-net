// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DataProtectionBackup.Models
{
    public abstract partial class DataProtectionBasePolicyRule
    {
        /// <summary> Initializes a new instance of <see cref="DataProtectionBasePolicyRule"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected DataProtectionBasePolicyRule(string name)     // This constructor is intentionally retained for backward compatibility.
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
