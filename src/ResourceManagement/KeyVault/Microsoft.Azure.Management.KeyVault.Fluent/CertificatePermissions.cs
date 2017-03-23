// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for CertificatePermissions.
    /// </summary>
    public class CertificatePermissions : ExpandableStringEnum<CertificatePermissions>
    {
        public static readonly CertificatePermissions All = Parse("all");
        public static readonly CertificatePermissions Get = Parse("get");
        public static readonly CertificatePermissions List = Parse("list");
        public static readonly CertificatePermissions Delete = Parse("delete");
        public static readonly CertificatePermissions Create = Parse("create");
        public static readonly CertificatePermissions Import = Parse("import");
        public static readonly CertificatePermissions Update = Parse("update");
        public static readonly CertificatePermissions Managecontacts = Parse("managecontacts");
        public static readonly CertificatePermissions Getissuers = Parse("getissuers");
        public static readonly CertificatePermissions Listissuers = Parse("listissuers");
        public static readonly CertificatePermissions Setissuers = Parse("setissuers");
        public static readonly CertificatePermissions Deleteissuers = Parse("deleteissuers");
        public static readonly CertificatePermissions Manageissuers = Parse("manageissuers");
    }
}
