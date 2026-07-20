// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Consumption.Mocking
{
    /// <summary>
    /// Obsolete back-compat stub for the v1.1.0 mockable tenant-scoped consumption surface. The
    /// TypeSpec migration no longer exposes tenant-scoped consumption operations, so this class is
    /// effectively a no-op placeholder. Hidden from IntelliSense and retained only so ApiCompat
    /// against the shipped contract succeeds.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MockableConsumptionTenantResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableConsumptionTenantResource"/> class for mocking. </summary>
        protected MockableConsumptionTenantResource()
        {
        }

        internal MockableConsumptionTenantResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
