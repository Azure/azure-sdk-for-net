// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Helper class for providing a cancellation token for when this WebJob's shutdown is signaled.
    /// </summary>
    public sealed class WebJobsShutdownWatcher : IDisposable
    {
        private readonly string _shutdownFile;
        private readonly bool _ownsCancellationTokenSource;

        private CancellationTokenSource _cts;
        private FileSystemWatcher _watcher;

        /// <summary>
        /// Begin watching for a shutdown notification from Antares.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public WebJobsShutdownWatcher()
            : this(new CancellationTokenSource(), ownsCancellationTokenSource: true)
        {
        }

        private WebJobsShutdownWatcher(CancellationTokenSource cancellationTokenSource, bool ownsCancellationTokenSource)
        {
            // http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/#.U3aIXRFOVaQ
            // Antares will set this file to signify shutdown
            _shutdownFile = Environment.GetEnvironmentVariable("WEBJOBS_SHUTDOWN_FILE");
            if (_shutdownFile == null)
            {
                // If env var is not set, then no shutdown support
                return;
            }

            // Setup a file system watcher on that file's directory to know when the file is created
            string directoryName = Path.GetDirectoryName(_shutdownFile);
            try
            {
                // FileSystemWatcher throws an argument exception if the part of 
                // the directory name does not exist
                _watcher = new FileSystemWatcher(directoryName);
            }
            catch (ArgumentException)
            {
                // The path is invalid
                return;
            }

            _watcher.Created += OnChanged;
            _watcher.Changed += OnChanged;
            _watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;

            _cts = cancellationTokenSource;
            _ownsCancellationTokenSource = ownsCancellationTokenSource;
        }

        /// <summary>
        /// Get a CancellationToken that is signaled when the shutdown notification is detected.
        /// </summary>
        public CancellationToken Token
        {
            get
            {
                // CancellationToken.None means CanBeCanceled = false, which can facilitate optimizations with tokens.
                return (_cts != null) ? _cts.Token : CancellationToken.None;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.FullPath.IndexOf(Path.GetFileName(_shutdownFile), StringComparison.OrdinalIgnoreCase) >= 0)
            {
                // Found the file mark this WebJob as finished
                if (_cts != null)
                {
                    _cts.Cancel();
                }
            }
        }

        /// <summary>
        /// Stop watching for the shutdown notification
        /// </summary>
        public void Dispose()
        {
            if (_watcher != null)
            {
                CancellationTokenSource cts = _cts;

                if (cts != null && _ownsCancellationTokenSource)
                {
                    // Null out the field to prevent a race condition in OnChanged above.
                    _cts = null;
                    cts.Dispose();
                }

                _watcher.Dispose();
                _watcher = null;
            }
        }

        internal static WebJobsShutdownWatcher Create(CancellationTokenSource cancellationTokenSource)
        {
            WebJobsShutdownWatcher watcher = new WebJobsShutdownWatcher(cancellationTokenSource, ownsCancellationTokenSource: false);

            if (watcher._watcher == null)
            {
                watcher.Dispose();
                return null;
            }

            return watcher;
        }
    }
}
