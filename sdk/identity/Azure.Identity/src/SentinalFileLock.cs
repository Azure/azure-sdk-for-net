using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class SentinalFileLock : IDisposable
    {
        private FileStream _lockFileStream;

        private SentinalFileLock(FileStream lockFileStream)
        {
            _lockFileStream = lockFileStream;
        }
        public static async Task<SentinalFileLock> AquireAsync(string lockfilePath, int lockFileRetryDelay, int lockFileRetryCount)
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
                    fileStream = new FileStream(lockfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read, 4096, FileOptions.DeleteOnClose);

                    using (var writer = new StreamWriter(fileStream, Encoding.UTF8, 4096, leaveOpen: true))
                    {
                        await writer.WriteLineAsync($"{Process.GetCurrentProcess().Id} {Process.GetCurrentProcess().ProcessName}").ConfigureAwait(false);
                    }
                    break;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    await Task.Delay(lockFileRetryDelay).ConfigureAwait(false);
                }
                catch (UnauthorizedAccessException ex)
                {
                    exception = ex;
                    await Task.Delay(lockFileRetryCount).ConfigureAwait(false);
                }
            }

            return (fileStream != null) ? new SentinalFileLock(fileStream) : throw new InvalidOperationException("Could not get access to the shared lock file.", exception);
        }

        public void Dispose()
        {
            _lockFileStream?.Dispose();
            _lockFileStream = null;
        }
    }
}
