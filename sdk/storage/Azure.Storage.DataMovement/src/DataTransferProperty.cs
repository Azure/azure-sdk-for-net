// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

#nullable enable

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Represents a property on the storage resource.
    /// </summary>
    public abstract class DataTransferProperty
    {
        internal bool _preserve;

        /// <summary>
        /// Defines whether the preserve the property on the storage resource. True to preserve, false to not.
        /// </summary>
        public virtual bool Preserve {
            get => _preserve;
            internal set => _preserve = value; }

        /// <summary>
        /// Default constructor for <see cref="DataTransferProperty"/>. Defaults to preserve the respective property the destination.
        /// </summary>
        public DataTransferProperty()
        {
            Preserve = true;
        }

        /// <summary>
        /// Constructs <see cref="DataTransferProperty"/> to preserves the respective property.
        /// </summary>
        /// <param name="preserve"></param>
        public DataTransferProperty(bool preserve)
        {
            Preserve = preserve;
        }

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
