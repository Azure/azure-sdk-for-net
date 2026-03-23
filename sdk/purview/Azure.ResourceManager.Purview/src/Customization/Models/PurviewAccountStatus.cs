// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Purview.Models
{
    // Backward compatibility: the new TypeSpec generator doesn't emit a parameterless
    // internal constructor for PurviewAccountStatus. The old SDK (1.1.0) ModelFactory
    // and deserialization paths depend on it. Re-adding to preserve compat.
    public partial class PurviewAccountStatus
    {
        /// <summary> Initializes a new instance of <see cref="PurviewAccountStatus"/>. </summary>
        internal PurviewAccountStatus()
        {
        }
    }
}
