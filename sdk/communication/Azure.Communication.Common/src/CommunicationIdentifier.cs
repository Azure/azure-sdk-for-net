// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication
{
    /// <summary>Represents an identifier in Azure Communication Services.</summary>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public abstract class CommunicationIdentifier : IEquatable<CommunicationIdentifier>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        /// <inheritdoc />
        public abstract bool Equals(CommunicationIdentifier other);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is CommunicationIdentifier other && Equals(other);
    }
}
