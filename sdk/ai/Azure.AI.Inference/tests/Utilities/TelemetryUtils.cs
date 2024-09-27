// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.Inference.Telemetry;
using Azure.Core.TestFramework;
using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    internal class TelemetryUtils
    {
        public static IDisposable ConfigureInstrumentation(bool enableOTel, bool enableContent)
        {
            IDisposable disposable = new CompositeDisposable(
                new TestAppContextSwitch(new() {
                    { EnableOpenTelemetrySwitch, enableOTel.ToString() },
                    { TraceContentsSwitch, enableContent.ToString() }
                }));

            OpenTelemetryScope.ResetEnvironmentForTests();
            return disposable;
        }

        private class CompositeDisposable : IDisposable
        {
            private readonly List<IDisposable> _disposables = new List<IDisposable>();

            public CompositeDisposable(params IDisposable[] disposables)
            {
                for (int i = 0; i < disposables.Length; i++)
                {
                    _disposables.Add(disposables[i]);
                }
            }

            public void Dispose()
            {
                foreach (IDisposable d in _disposables)
                {
                    d?.Dispose();
                }
            }
        }
    }
}
