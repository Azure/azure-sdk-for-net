// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// IX509Certificate2Provider provides a way to control how the X509Certificate2 object is fetched.
    /// </summary>
    internal interface IX509Certificate2Provider
    {
        ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken);
    }
}
