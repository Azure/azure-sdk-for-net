// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> Custom Authentication properties. </summary>
    // TODO: Remove this customization once the fix for
    // https://github.com/microsoft/typespec/issues/7380 is merged and IotOperations is
    // regenerated. The chained safe-flatten setter for AuthX509SecretRef will then construct
    // BrokerAuthenticatorCustomAuth via its parameterless ctor + delegated assignment, and this
    // hand-added (string secretRef) constructor will no longer be required.
    public partial class BrokerAuthenticatorCustomAuth
    {
        /// <summary> Initializes a new instance of <see cref="BrokerAuthenticatorCustomAuth"/>. </summary>
        /// <param name="secretRef"> Kubernetes secret containing an X.509 client certificate. This is a reference to the secret through an identifying name, not the secret itself. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secretRef"/> is null. </exception>
        public BrokerAuthenticatorCustomAuth(string secretRef)
        {
            Argument.AssertNotNull(secretRef, nameof(secretRef));

            X509 = new BrokerX509ManualCertificate(secretRef);
        }
    }
}
