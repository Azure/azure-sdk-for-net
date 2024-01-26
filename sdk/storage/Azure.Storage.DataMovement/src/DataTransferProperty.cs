// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

#nullable enable

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Represents a property on the storage resource.
    /// </summary>
    public abstract class DataTransferProperty
    {
        /// <summary>
        /// Defines whether the preserve the property on the storage resource. True to preserve, false to not.
        /// </summary>
        public abstract bool Preserve { get; set; }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string? ToString() => base.ToString();
    }
}
