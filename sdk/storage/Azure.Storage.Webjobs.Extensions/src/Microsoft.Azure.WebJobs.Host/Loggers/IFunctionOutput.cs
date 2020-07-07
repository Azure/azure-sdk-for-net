// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Loggers
{
    internal interface IFunctionOutput : IDisposable
    {
        IRecurrentCommand UpdateCommand { get; }

        // Get a text writer for logging. A user function can get this via model binding to a 'TextWriter'.
        // The logging provider determines the backing storage for this. 
        TextWriter Output { get; }

        // Copy the output contents the logEntry. 
        Task SaveAndCloseAsync(FunctionInstanceLogEntry logEntry, CancellationToken cancellationToken);
    }
}
