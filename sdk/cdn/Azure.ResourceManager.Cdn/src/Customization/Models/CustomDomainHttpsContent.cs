// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public abstract partial class CustomDomainHttpsContent
    {
        /// <summary> Initializes a new instance of <see cref="CustomDomainHttpsContent"/>. </summary>
        /// <param name="protocolType"> Defines the TLS extension protocol that is used for secure delivery. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CustomDomainHttpsContent(SecureDeliveryProtocolType protocolType) : this(default, protocolType)
        { }
    }
}
