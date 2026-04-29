// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous public reason enum while the generated model stores the common internal enum.
    [CodeGenSuppress("Reason")]
    public partial class PostgreSqlFlexibleServerNameAvailabilityResponse
    {
        /// <summary> The reason for unavailability. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("reason")]
        public PostgreSqlFlexibleServerNameUnavailableReason? Reason
        {
            get
            {
                if (ReasonInternal is null)
                    return default;
                return new PostgreSqlFlexibleServerNameUnavailableReason(ReasonInternal.Value.ToString());
            }
        }

        [CodeGenMember("Reason")]
        internal CheckNameAvailabilityReason? ReasonInternal { get; }
    }
}
