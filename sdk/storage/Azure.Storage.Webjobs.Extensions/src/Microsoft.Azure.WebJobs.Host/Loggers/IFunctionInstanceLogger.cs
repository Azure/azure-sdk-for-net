// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    // This is a DI interface.
    internal interface IFunctionInstanceLogger
    {
        Task<string> LogFunctionStartedAsync(FunctionStartedMessage message, CancellationToken cancellationToken);

        Task LogFunctionCompletedAsync(FunctionCompletedMessage message, CancellationToken cancellationToken);

        Task DeleteLogFunctionStartedAsync(string startedMessageId, CancellationToken cancellationToken);
    }
}
