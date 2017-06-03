// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// Defines values for certificate types in Active Directory.
    /// </summary>
    public class CertificateType : ExpandableStringEnum<CertificateType>
    {
        public static readonly CertificateType AsymmetricX509Cert = Parse("AsymmetricX509Cert");
        public static readonly CertificateType Symmetric = Parse("Symmetric");
    }
}
