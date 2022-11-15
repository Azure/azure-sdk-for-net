// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.CallAutomation
{
    /// <summary>Represents a locator for a call in Azure Communication Services, that can be handled by the Call Automation APIs</summary>
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public abstract class CallLocator : IEquatable<CallLocator>
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        /// <summary> The call id. </summary>
        public string Id { get; internal set; }

        /// <inheritdoc />
        public abstract bool Equals(CallLocator other);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is CallLocator other && Equals(other);
    }
}
