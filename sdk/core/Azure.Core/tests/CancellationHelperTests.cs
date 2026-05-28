// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class CancellationHelperTests
    {
        [Test]
        public void CreateOperationCanceledExceptionPassesTokenOnSupportedVersions()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();
            var ex = (TaskCanceledException) CancellationHelper.CreateOperationCanceledException(new Exception("test"), cts.Token);

#if NETCOREAPP2_1_OR_GREATER
            Assert.IsTrue(ex.CancellationToken.IsCancellationRequested);
#else
            Assert.IsFalse(ex.CancellationToken.IsCancellationRequested);
#endif
        }
    }
}