// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Logging
{
    internal class FunctionResultAggregatorProvider : IEventCollectorProvider
    {
        protected readonly FunctionResultAggregatorOptions _options;
        private readonly ILoggerFactory _loggerFactory;

        public FunctionResultAggregatorProvider(IOptions<FunctionResultAggregatorOptions> options, ILoggerFactory loggerFactory)
        {
            _options = options.Value;
            _loggerFactory = loggerFactory;
        }

        public virtual IAsyncCollector<FunctionInstanceLogEntry> Create()
        {
            // If the pieces aren't configured, don't create an aggregator.
            if (!_options.IsEnabled)
            {
                return null;
            }

            return new FunctionResultAggregator(_options.BatchSize, _options.FlushTimeout, _loggerFactory);
        }
    }
}
