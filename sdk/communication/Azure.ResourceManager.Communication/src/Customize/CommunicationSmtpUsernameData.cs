// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Communication.Models;

namespace Azure.ResourceManager.Communication
{
    // Backward compat: baseline API had Guid? TenantId (nullable) because autorest format-by-name-rules
    // always generated nullable for uuid-typed properties. The TypeSpec property is required string
    // with @@alternateType(uuid), generating non-nullable Guid. This shim restores nullable to match
    // the published API surface (ApiCompatVersion 1.3.1).
    public partial class CommunicationSmtpUsernameData
    {
        /// <summary> The tenant of the linked Entra Application. </summary>
        [WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => Properties is null ? default(Guid?) : Properties.TenantId;
            set
            {
                if (Properties is null)
                {
                    Properties = new SmtpUsernameProperties();
                }
                Properties.TenantId = value ?? default;
            }
        }
    }
}
