// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class ProcessManagerTests
    {
        [Fact]
        public async Task RequestCancellationTest()
        {
#if FullNetFx
            var filename = "cmd.exe";
#else
            var filename = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd.exe" : "/bin/bash";
#endif
            var processManager = new ProcessManager();
            var startInfo = new ProcessStartInfo { FileName = filename };

            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            await Assert.ThrowsAnyAsync<OperationCanceledException>(() => Task.Run(() => processManager.ExecuteAsync(new Process { StartInfo = startInfo }, cancellationTokenSource.Token)));
        }
    }
}
