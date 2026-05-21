// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: KustoDatabasePrincipal.PrincipalType was the property name in old SDK.
// Generated code now uses 'Type' property. Add PrincipalType alias with setter.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoDatabasePrincipal
    {
        /// <summary> Database principal type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public KustoDatabasePrincipalType PrincipalType
        {
            get => Type;
            set => Type = value;
        }
    }
}
