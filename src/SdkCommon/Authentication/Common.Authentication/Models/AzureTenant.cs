// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.Common.Authentication.Models
{
    /// <summary>
    /// Represents an AD tenant.
    /// </summary>
    [Serializable]
    public class AzureTenant
    {
        /// <summary>
        /// Gets or sets the tenant id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the tenant domain.
        /// </summary>
        public string Domain { get; set; }
    }
}
