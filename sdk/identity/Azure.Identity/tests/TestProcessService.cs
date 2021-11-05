// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal sealed class TestProcessService : IProcessService
    {
        public Func<ProcessStartInfo, IProcess> CreateHandler { get; set; }

        public TestProcessService(IProcess process, bool preservePassedStartInfo)
        {
            if (preservePassedStartInfo)
            {
                CreateHandler = psi =>
                {
                    process.StartInfo = psi;
                    return process;
                };
            }
            else
            {
                CreateHandler = _ => process;
            }
        }

        public TestProcessService(params IProcess[] processes)
        {
            var queue = new ConcurrentQueue<IProcess>(processes);
            CreateHandler = _ => queue.TryDequeue(out IProcess process) ? process : throw new AssertionException("Unexpected call of IProcessService.Create");
        }

        public IProcess Create(ProcessStartInfo startInfo) => CreateHandler(startInfo);
    }
}
