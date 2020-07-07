// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    internal sealed class NullFunctionOutputDefinition : IFunctionOutputDefinition
    {
        private NullFunctionOutputDefinition() {}

        public static IFunctionOutputDefinition Instance { get; } = new NullFunctionOutputDefinition();

        public LocalBlobDescriptor OutputBlob => null;

        public LocalBlobDescriptor ParameterLogBlob => null;

        public IFunctionOutput CreateOutput() => NullFunctionOutput.Instance;

        public IRecurrentCommand CreateParameterLogUpdateCommand(IReadOnlyDictionary<string, IWatcher> watches, ILogger logger) => null;

        private class NullFunctionOutput : IFunctionOutput
        {
            private NullFunctionOutput() { }

            public static IFunctionOutput Instance { get; } = new NullFunctionOutput();

            public IRecurrentCommand UpdateCommand => null;

            public TextWriter Output => TextWriter.Null;

            public Task SaveAndCloseAsync(FunctionInstanceLogEntry item, CancellationToken cancellationToken) => Task.CompletedTask;

            public void Dispose()
            {
            }
        }
    }
}
