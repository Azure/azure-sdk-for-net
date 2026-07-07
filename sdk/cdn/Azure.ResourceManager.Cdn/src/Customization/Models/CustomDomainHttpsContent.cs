// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds a constructor accepting only protocolType to the CustomDomainHttpsContent abstract base class
    // for backward API compatibility with the previous SDK.
    // Reason: The TypeSpec generator produces a constructor with the signature (minimumTlsVersion, protocolType), which includes the new minimumTlsVersion parameter.
    // The old SDK constructor accepted only protocolType. The old signature is preserved here (internally calling this(default, protocolType)),
    // and marked as EditorBrowsable.Never.
    public abstract partial class CustomDomainHttpsContent
    {
        /// <summary> Initializes a new instance of <see cref="CustomDomainHttpsContent"/>. </summary>
        /// <param name="protocolType"> Defines the TLS extension protocol that is used for secure delivery. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected CustomDomainHttpsContent(SecureDeliveryProtocolType protocolType) : this(default, protocolType)
        { }
    }
}
