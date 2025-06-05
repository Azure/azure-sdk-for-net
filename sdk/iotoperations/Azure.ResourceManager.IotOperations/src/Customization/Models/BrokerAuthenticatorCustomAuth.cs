// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> Custom Authentication properties. </summary>
    internal partial class BrokerAuthenticatorCustomAuth
    {
        /// <summary> Initializes a new instance of <see cref="BrokerAuthenticatorCustomAuth"/>. </summary>
        /// <param name="secretRef"> Kubernetes secret containing an X.509 client certificate. This is a reference to the secret through an identifying name, not the secret itself. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="secretRef"/> is null. </exception>
        public BrokerAuthenticatorCustomAuth(string secretRef)
        {
            Argument.AssertNotNull(secretRef, nameof(secretRef));

            X509 = new X509ManualCertificate(secretRef);
        }
    }
}
