// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoDatabasePrincipalAssignmentNameAvailabilityContent
    {
        /// <summary> The type of resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public KustoDatabasePrincipalAssignmentType ResourceType => new KustoDatabasePrincipalAssignmentType(Type);
    }
}
