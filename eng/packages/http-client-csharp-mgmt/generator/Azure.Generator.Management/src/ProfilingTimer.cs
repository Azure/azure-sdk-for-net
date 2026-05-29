// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

namespace Azure.Generator.Management
{
    internal static class ProfilingTimer
    {
        private const string EnvironmentVariableName = "AZSDK_MGMT_GENERATOR_PROFILE";
        internal static bool IsEnabled { get; } = string.Equals(Environment.GetEnvironmentVariable(EnvironmentVariableName), "1", StringComparison.Ordinal);

        internal static IDisposable Measure(string name, string? detail = null)
        {
            return IsEnabled ? new Scope(name, detail) : NoopScope.Instance;
        }

        internal static void Log(string message)
        {
            if (IsEnabled)
            {
                Console.Error.WriteLine($"[mgmt-generator-profile] {message}");
            }
        }

        private sealed class Scope : IDisposable
        {
            private readonly string _name;
            private readonly string? _detail;
            private readonly Stopwatch _stopwatch;

            public Scope(string name, string? detail)
            {
                _name = name;
                _detail = detail;
                _stopwatch = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                _stopwatch.Stop();
                Console.Error.WriteLine($"[mgmt-generator-profile] {_name}{(_detail is null ? string.Empty : $" ({_detail})")}: {_stopwatch.Elapsed}");
            }
        }

        private sealed class NoopScope : IDisposable
        {
            internal static readonly NoopScope Instance = new();

            public void Dispose()
            {
            }
        }
    }
}
