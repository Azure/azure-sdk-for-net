// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    /// <summary>
    /// A context that can be used to simulate the webjobs shutdown mechanism
    /// </summary>
    public class WebJobsShutdownContext : IDisposable
    {
        private const string ShutdownEnvironmentVariableName = "WEBJOBS_SHUTDOWN_FILE";

        private readonly string _oldVariableValue;

        private readonly string _shutdownFile;

        private readonly bool _cleanupOnDispose;

        private bool _disposed = false;


        public WebJobsShutdownContext()
            : this(Path.GetTempFileName())
        {
        }

        public WebJobsShutdownContext(string shutdownFile)
        {
            _oldVariableValue = Environment.GetEnvironmentVariable(ShutdownEnvironmentVariableName);

            _shutdownFile = shutdownFile;
            _cleanupOnDispose = shutdownFile != null;

            Environment.SetEnvironmentVariable(ShutdownEnvironmentVariableName, shutdownFile);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                if (_cleanupOnDispose && File.Exists(_shutdownFile))
                {
                    File.Delete(_shutdownFile);
                }

                Environment.SetEnvironmentVariable(ShutdownEnvironmentVariableName, _oldVariableValue);
            }
        }

        public void NotifyShutdown()
        {
            if (_shutdownFile == null)
            {
                throw new InvalidOperationException("No shutdown file set");
            }

            File.WriteAllText(_shutdownFile, "x");
        }
    }
}
