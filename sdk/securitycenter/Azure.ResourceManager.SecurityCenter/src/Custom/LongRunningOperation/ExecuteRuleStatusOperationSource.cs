// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    internal class ExecuteRuleStatusOperationSource : IOperationSource<ExecuteRuleStatus>
    {
        ExecuteRuleStatus IOperationSource<ExecuteRuleStatus>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return ExecuteRuleStatus.DeserializeExecuteRuleStatus(document.RootElement);
        }

        async ValueTask<ExecuteRuleStatus> IOperationSource<ExecuteRuleStatus>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ExecuteRuleStatus.DeserializeExecuteRuleStatus(document.RootElement);
        }
    }
}
