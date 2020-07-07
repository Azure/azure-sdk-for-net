// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class HeartbeatFunctionExecutor : IFunctionExecutor
    {
        private readonly IRecurrentCommand _heartbeatCommand;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IFunctionExecutor _innerExecutor;

        public HeartbeatFunctionExecutor(IRecurrentCommand heartbeatCommand,
            IWebJobsExceptionHandler exceptionHandler, IFunctionExecutor innerExecutor)
        {
            _heartbeatCommand = heartbeatCommand;
            _exceptionHandler = exceptionHandler;
            _innerExecutor = innerExecutor;
        }

        public async Task<IDelayedException> TryExecuteAsync(IFunctionInstance instance, CancellationToken cancellationToken)
        {
            IDelayedException result;

            using (ITaskSeriesTimer timer = CreateHeartbeatTimer(_exceptionHandler))
            {
                await _heartbeatCommand.TryExecuteAsync(cancellationToken);
                timer.Start();

                result = await _innerExecutor.TryExecuteAsync(instance, cancellationToken);

                await timer.StopAsync(cancellationToken);
            }

            return result;
        }

        private ITaskSeriesTimer CreateHeartbeatTimer(IWebJobsExceptionHandler exceptionHandler)
        {
            return LinearSpeedupStrategy.CreateTimer(_heartbeatCommand, HeartbeatIntervals.NormalSignalInterval,
                HeartbeatIntervals.MinimumSignalInterval, exceptionHandler);
        }
    }
}
