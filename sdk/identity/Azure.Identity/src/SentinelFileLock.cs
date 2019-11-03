// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class SentinelFileLock : IDisposable
    {
        private FileStream _lockFileStream;
        private const int DefaultFileBufferSize = 4096;

        private SentinelFileLock(FileStream lockFileStream)
        {
            _lockFileStream = lockFileStream;
        }

        public static async Task<SentinelFileLock> AcquireAsync(string lockfilePath, int lockFileRetryCount, TimeSpan lockFileRetryDelay)
        {
            Exception exception = null;
            FileStream fileStream = null;

            // Create lock file dir if it doesn't already exist
            Directory.CreateDirectory(Path.GetDirectoryName(lockfilePath));

            for (int tryCount = 0; tryCount < lockFileRetryCount; tryCount++)
            {
                try
                {
                    // We are using the file locking to synchronize the store, do not allow multiple writers for the file.
                    // Note: this only works on windows if we extend to work on unix systems we need to set FileShare.None
                    fileStream = new FileStream(lockfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read, DefaultFileBufferSize, FileOptions.DeleteOnClose);

                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8, DefaultFileBufferSize, leaveOpen: true))
                    {
                        await writer.WriteLineAsync($"{Process.GetCurrentProcess().Id} {Process.GetCurrentProcess().ProcessName}").ConfigureAwait(false);
                    }
                    break;
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                {
                    exception = ex;
                    await Task.Delay(lockFileRetryDelay).ConfigureAwait(false);
                }
            }

            return (fileStream != null) ? new SentinelFileLock(fileStream) : throw new InvalidOperationException("Could not get access to the shared lock file.", exception);
        }

        public void Dispose()
        {
            _lockFileStream?.Dispose();
            _lockFileStream = null;
        }
    }
}
