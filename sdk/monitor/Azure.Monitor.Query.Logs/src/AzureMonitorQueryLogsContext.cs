// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Monitor.Query.Logs
{
    /// <summary>
    /// Context class which will be filled in by the System.ClientModel.SourceGeneration.
    /// For more information <see href='https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/docs/ModelReaderWriterContext.md' />
    /// </summary>
    [ModelReaderWriterBuildable(typeof(ResponseError))]
    public partial class AzureMonitorQueryLogsContext
    {
    }
}
