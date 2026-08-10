// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.CodeTransparency
{
    public static partial class CodeTransparencyModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Azure.Security.CodeTransparency.ServiceIdentityResult"/> for mocking. </summary>
        /// <param name="ledgerTlsCertificate"> String representing the service certificate. </param>
        /// <returns> A new <see cref="Azure.Security.CodeTransparency.ServiceIdentityResult"/> instance for mocking. </returns>
        public static ServiceIdentityResult ServiceIdentityResult(string ledgerTlsCertificate)
            => new ServiceIdentityResult(ledgerTlsCertificate);
    }
}
