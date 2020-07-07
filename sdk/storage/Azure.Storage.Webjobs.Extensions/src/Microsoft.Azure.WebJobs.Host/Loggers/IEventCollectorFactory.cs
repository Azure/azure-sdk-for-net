// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    // $$$ Also Need to register FastTableLoggerProvider so that the log messages get properly created. 
    public interface IEventCollectorFactory
    {
        IAsyncCollector<FunctionInstanceLogEntry> Create();
    }
}
