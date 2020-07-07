// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Loggers;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class NullFunctionInstanceLoggerProvider : IFunctionInstanceLoggerProvider
    {
        private readonly IFunctionInstanceLogger _logger;
        public NullFunctionInstanceLoggerProvider()
            : this(new NullFunctionInstanceLogger())
        {
        }

        public NullFunctionInstanceLoggerProvider(object instance)
        {
            _logger = (IFunctionInstanceLogger) instance;
        }

        Task<IFunctionInstanceLogger> IFunctionInstanceLoggerProvider.GetAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_logger);
        }
    }
}
