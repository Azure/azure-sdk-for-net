// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    internal class RecurrentTaskSeriesCommand : ITaskSeriesCommand
    {
        private readonly IRecurrentCommand _innerCommand;
        private readonly IDelayStrategy _delayStrategy;

        public RecurrentTaskSeriesCommand(IRecurrentCommand innerCommand, IDelayStrategy delayStrategy)
        {
            _innerCommand = innerCommand;
            _delayStrategy = delayStrategy;
        }

        public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            bool succeeded = await _innerCommand.TryExecuteAsync(cancellationToken);
            Task wait = Task.Delay(_delayStrategy.GetNextDelay(succeeded));
            return new TaskSeriesCommandResult(wait);
        }
    }
}
