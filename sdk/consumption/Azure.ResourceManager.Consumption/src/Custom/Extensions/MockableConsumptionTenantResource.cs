// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Consumption.Mocking
{
    // Stub retained so ApiCompat against the v1.1.0 contract succeeds; the TypeSpec migration no longer
    // exposes tenant-scoped consumption operations, so this class is effectively a no-op placeholder.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MockableConsumptionTenantResource : ArmResource
    {
        protected MockableConsumptionTenantResource()
        {
        }

        internal MockableConsumptionTenantResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
