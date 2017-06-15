// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent.Models
{
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for KeyPermissions.
    /// </summary>
    public class KeyPermissions : ExpandableStringEnum<KeyPermissions>
    {
        public static readonly KeyPermissions All = Parse("all");
        public static readonly KeyPermissions Encrypt = Parse("encrypt");
        public static readonly KeyPermissions Decrypt = Parse("decrypt");
        public static readonly KeyPermissions WrapKey = Parse("wrapKey");
        public static readonly KeyPermissions UnwrapKey = Parse("unwrapKey");
        public static readonly KeyPermissions Sign = Parse("sign");
        public static readonly KeyPermissions Verify = Parse("verify");
        public static readonly KeyPermissions Get = Parse("get");
        public static readonly KeyPermissions List = Parse("list");
        public static readonly KeyPermissions Create = Parse("create");
        public static readonly KeyPermissions Update = Parse("update");
        public static readonly KeyPermissions Import = Parse("import");
        public static readonly KeyPermissions Delete = Parse("delete");
        public static readonly KeyPermissions Backup = Parse("backup");
        public static readonly KeyPermissions Restore = Parse("restore");
    }
}
