// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Logging
{
    internal class FunctionResultAggregator : IAsyncCollector<FunctionInstanceLogEntry>, IDisposable
    {
        private readonly ILogger _logger;
        private readonly int _batchSize;
        private readonly TimeSpan _batchTimeout;

        private const string FunctionNamePrefix = "Functions.";

        private BufferBlock<FunctionInstanceLogEntry> _buffer;
        private BatchBlock<FunctionInstanceLogEntry> _batcher;

        private Timer _windowTimer;
        private IDisposable[] _disposables;

        public FunctionResultAggregator(int batchSize, TimeSpan batchTimeout, ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _logger = loggerFactory.CreateLogger(LogCategories.Aggregator);
            _batchSize = batchSize;
            _batchTimeout = batchTimeout;
            InitializeFlow(_batchSize, _batchTimeout);
        }

        private void InitializeFlow(int maxBacklog, TimeSpan maxFlushInterval)
        {
            _buffer = new BufferBlock<FunctionInstanceLogEntry>(
                new ExecutionDataflowBlockOptions()
                {
                    BoundedCapacity = maxBacklog
                });

            _batcher = new BatchBlock<FunctionInstanceLogEntry>(maxBacklog,
                new GroupingDataflowBlockOptions()
                {
                    BoundedCapacity = maxBacklog,
                    Greedy = true
                });

            TransformBlock<IEnumerable<FunctionInstanceLogEntry>, IEnumerable<FunctionResultAggregate>> aggregator =
                new TransformBlock<IEnumerable<FunctionInstanceLogEntry>, IEnumerable<FunctionResultAggregate>>(transform: (e) => Aggregate(e));

            ActionBlock<IEnumerable<FunctionResultAggregate>> publisher = new ActionBlock<IEnumerable<FunctionResultAggregate>>(
                (e) => Publish(e),
                new ExecutionDataflowBlockOptions()
                {
                    MaxDegreeOfParallelism = 1,
                    BoundedCapacity = 32
                });

            _disposables = new IDisposable[]
            {
                _buffer.LinkTo(_batcher),
                _batcher.LinkTo(aggregator),
                aggregator.LinkTo(publisher)
            };

            _windowTimer = new Timer(async (o) => await FlushAsync(), null, maxFlushInterval, maxFlushInterval);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            _batcher?.TriggerBatch();
            return Task.CompletedTask;
        }

        internal void Publish(IEnumerable<FunctionResultAggregate> results)
        {
            foreach (var result in results)
            {
                _logger.LogFunctionResultAggregate(result);
            }
        }

        public Task AddAsync(FunctionInstanceLogEntry result, CancellationToken cancellationToken = default(CancellationToken))
        {
            // We only care about completed events.
            if (result.IsCompleted)
            {
                return _buffer.SendAsync(result, cancellationToken);
            }

            return Task.CompletedTask;
        }

        internal static IEnumerable<FunctionResultAggregate> Aggregate(IEnumerable<FunctionInstanceLogEntry> evts)
        {
            var metrics = evts
                .GroupBy(e => new { e.FunctionName })
                .Select(e => new FunctionResultAggregate
                {
                    Name = TrimDefaultClassName(e.Key.FunctionName),
                    Timestamp = e.Min(t => t.StartTime),
                    Successes = e.Count(f => f.ErrorDetails == null),
                    Failures = e.Count(f => f.ErrorDetails != null),
                    MinDuration = e.Min(f => f.Duration),
                    MaxDuration = e.Max(f => f.Duration),
                    AverageDuration = new TimeSpan((long)e.Average(f => f.Duration.Ticks))
                });

            return metrics;
        }

        private static string TrimDefaultClassName(string functionName)
        {
            // We'll strip off the default namespace for nicer logs. Non-default namespaces will remain.
            if (functionName != null && functionName.StartsWith(FunctionNamePrefix, StringComparison.Ordinal))
            {
                functionName = functionName.Substring(FunctionNamePrefix.Length);
            }

            return functionName;
        }

        public void Dispose()
        {
            if (_disposables != null)
            {
                foreach (var d in _disposables)
                {
                    d.Dispose();
                }
                _disposables = null;
            }

            if (_windowTimer != null)
            {
                _windowTimer.Dispose();
                _windowTimer = null;
            }
        }
    }
}
