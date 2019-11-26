// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Azure.Management.PowerBIDedicated
{
    /// <inheritdoc/>
    public partial class PowerBIDedicatedManagementClient
    {
        partial void CustomInitialize()
        {
            // Override the capacities operations which includes override of UpdateWithHttpMessagesAsync to support non long running operation in case of OK response
            this.Capacities = new CustomCapacitiesOperations(this.Capacities, this);
        }
    }
}
