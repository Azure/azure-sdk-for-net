// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines whether or not the stream is consumable and readable
    /// </summary>
    [Flags]
    public enum StreamConsumableType
    {
        /// <summary>
        /// Defines that the readable stream is consumable.
        /// </summary>
        Consumable = 1,

        /// <summary>
        /// Defines that the readable stream is not consumable.
        /// </summary>
        NotConsumable = 0
    }
}
