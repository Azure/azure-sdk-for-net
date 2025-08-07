// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> A value indicating whether the field should be used as a permission filter. </summary>
    [CodeGenModel("PermissionFilter")]
    public readonly partial struct PermissionFilter
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary>
        /// The values of all declared <see cref="PermissionFilter"/> properties as string constants.
        /// These can be used in <see cref="SimpleFieldAttribute"/>, <see cref="SearchableFieldAttribute"/> and anywhere else constants are required.
        /// </summary>
        public static class Values
        {
            /// <summary> Field represents user IDs that should be used to filter document access on queries. </summary>
            public const string UserIds = PermissionFilter.UserIdsValue;
            /// <summary> Field represents group IDs that should be used to filter document access on queries. </summary>
            public const string GroupIds = PermissionFilter.GroupIdsValue;
            /// <summary> Field represents an RBAC scope that should be used to filter document access on queries. </summary>
            public const string RbacScope = PermissionFilter.RbacScopeValue;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
