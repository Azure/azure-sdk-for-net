// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// A trusted computing base (TCB) baseline that an attestation policy can require for SGX attestation,
    /// by setting the <c>x-ms-sgx-tcbidentifier</c> claim to its <see cref="TcbIdentifier"/>.
    /// </summary>
    // Makes the generated model public, for GetTcbBaselines; the generator emits the accessibility declared here.
    [CodeGenType("TcbBaseline")]
    public partial class TcbBaseline
    {
    }
}
