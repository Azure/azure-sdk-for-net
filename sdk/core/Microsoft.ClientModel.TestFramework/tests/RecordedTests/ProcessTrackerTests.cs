// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class ProcessTrackerTests
{
    #region Process Management Tests

    [Test]
    public void AddWithRunningProcessTracksProcess()
    {
        if (!IsWindowsWithJobObjectSupport())
        {
            Assert.Ignore("Test requires Windows 8 or later");
            return;
        }

        using var process = CreateTestProcess();
        process.Start();
        Assert.DoesNotThrow(() => ProcessTracker.Add(process));
        Assert.That(process.HasExited, Is.False, "Process should still be running after being added to tracker");

        process.Kill();
        process.WaitForExit(5000);
    }

    [Test]
    public void AddWithExitedProcessDoesNotThrow()
    {
        if (!IsWindowsWithJobObjectSupport())
        {
            Assert.Ignore("Test requires Windows 8 or later");
            return;
        }

        using var process = CreateTestProcess();
        process.Start();
        process.Kill();
        process.WaitForExit(5000);

        // Should not throw even if process has already exited
        Assert.DoesNotThrow(() => ProcessTracker.Add(process));
        Assert.That(process.HasExited, Is.True);
    }

    [Test]
    public void AddMultipleProcessesTracksAllProcesses()
    {
        if (!IsWindowsWithJobObjectSupport())
        {
            Assert.Ignore("Test requires Windows 8 or later");
            return;
        }

        var processes = new Process[3];
        try
        {
            for (int i = 0; i < processes.Length; i++)
            {
                processes[i] = CreateTestProcess();
                processes[i].Start();

                Assert.DoesNotThrow(() => ProcessTracker.Add(processes[i]),
                    $"Should be able to add process {i} to tracker");
                Assert.That(processes[i].HasExited, Is.False,
                    $"Process {i} should still be running after being added to tracker");
            }
        }
        finally
        {
            foreach (var process in processes)
            {
                if (process != null && !process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit(5000);
                }
                process?.Dispose();
            }
        }
    }

    #endregion

    #region Error Handling Tests

    [Test]
    public void AddWithNullProcessThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => ProcessTracker.Add(null));
    }

    [Test]
    public void AddWithDisposedProcessThrowsException()
    {
        if (!IsWindowsWithJobObjectSupport())
        {
            Assert.Ignore("Test requires Windows 8 or later");
            return;
        }

        var process = CreateTestProcess();
        process.Dispose();

        // Should throw because we can't access the handle of a disposed process
        Assert.Throws<InvalidOperationException>(() => ProcessTracker.Add(process));
    }

    #endregion

    #region Static Initialization Tests

    [Test]
    public void StaticConstructorInitializesJobObject()
    {
        // The static constructor should have run by the time we call Add
        // We can't directly test the static constructor, but we can verify
        // that Add works, which implies the static constructor succeeded

        if (!IsWindowsWithJobObjectSupport())
        {
            Assert.Ignore("Test requires Windows 8 or later");
            return;
        }

        using var process = CreateTestProcess();
        process.Start();

        // If static constructor failed, this would throw
        Assert.DoesNotThrow(() => ProcessTracker.Add(process));

        process.Kill();
        process.WaitForExit(5000);
    }

    #endregion

    #region Helper Methods

    private static bool IsWindowsWithJobObjectSupport()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
               Environment.OSVersion.Version >= new Version(6, 2);
    }

    private static Process CreateTestProcess()
    {
        // Use a simple, harmless process that we can control
        return new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c timeout /t 30",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            }
        };
    }

    #endregion
}
