// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
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
            bool succeeded = await _innerCommand.TryExecuteAsync(cancellationToken).ConfigureAwait(false);
            Task wait = Task.Delay(_delayStrategy.GetNextDelay(succeeded), cancellationToken);
            return new TaskSeriesCommandResult(wait);
        }
    }
}
