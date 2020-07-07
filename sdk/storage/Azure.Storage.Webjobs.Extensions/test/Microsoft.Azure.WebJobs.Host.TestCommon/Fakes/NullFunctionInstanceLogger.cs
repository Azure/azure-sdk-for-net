// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class NullFunctionInstanceLogger : IFunctionInstanceLogger
    {
        Task<string> IFunctionInstanceLogger.LogFunctionStartedAsync(FunctionStartedMessage message,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(string.Empty);
        }

        Task IFunctionInstanceLogger.LogFunctionCompletedAsync(FunctionCompletedMessage message,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        Task IFunctionInstanceLogger.DeleteLogFunctionStartedAsync(string startedMessageId,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
