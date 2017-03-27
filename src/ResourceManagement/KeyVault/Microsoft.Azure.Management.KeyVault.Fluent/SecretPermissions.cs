// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for SecretPermissions.
    /// </summary>
    public class SecretPermissions : ExpandableStringEnum<SecretPermissions>
    {
        public static readonly SecretPermissions All = Parse("all");
        public static readonly SecretPermissions Get = Parse("get");
        public static readonly SecretPermissions List = Parse("list");
        public static readonly SecretPermissions Set = Parse("set");
        public static readonly SecretPermissions Delete = Parse("delete");
    }
}
