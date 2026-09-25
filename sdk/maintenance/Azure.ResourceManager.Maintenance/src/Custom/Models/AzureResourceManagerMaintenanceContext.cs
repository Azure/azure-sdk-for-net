// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Maintenance
{
    [ModelReaderWriterBuildable(typeof(Models.ScheduledEventsListAcknowledgeError))]
    [ModelReaderWriterBuildable(typeof(Models.ScheduledEventsListAcknowledgeErrorDetails))]
    [ModelReaderWriterBuildable(typeof(Models.ScheduledEventsAcknowledgeErrorDetails))]
    public partial class AzureResourceManagerMaintenanceContext
    {
    }
}
