// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class MigrateResult
    {
        /// <summary>
        /// Initializes a Id
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id => ResourceId?.ToString();
    }
}
