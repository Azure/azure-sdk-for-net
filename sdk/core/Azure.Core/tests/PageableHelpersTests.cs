// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class PageableHelpersTests
    {
        [Test]
        public void PageableHelpers_CreateAsyncPageableFromDelegates()
        {
            var cts = new CancellationTokenSource();
            var enumerable = CreateAsyncPageableFromDelegates(cts).WithCancellation(cts.Token);

            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                await foreach (var i in enumerable) { }
            });
        }

        [Test]
        public void PageableHelpers_CreateAsyncPageableFromEnumerable()
        {
            var cts = new CancellationTokenSource();
            var enumerable = PageableHelpers.CreateAsyncEnumerable(CreateAsyncEnumerable(cts)).WithCancellation(cts.Token);

            Assert.CatchAsync<OperationCanceledException>(async () =>
            {
                await foreach (var i in enumerable) { }
            });
        }

        private AsyncPageable<int> CreateAsyncPageableFromDelegates(CancellationTokenSource cts, CancellationToken cancellationToken = default)
        {
            async Task<Page<int>> FirstPageFunc(int? arg)
            {
                await Task.Yield();
                cts.Cancel();
                return Page<int>.FromValues(new[] {0, 1}, "abc", new MockResponse(200));
            }

            async Task<Page<int>> NextPageFunc(string arg1, int? arg2)
            {
                await Task.Yield();
                cancellationToken.ThrowIfCancellationRequested();
                throw new Exception();
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        private async IAsyncEnumerable<Page<int>> CreateAsyncEnumerable(CancellationTokenSource cts, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            await Task.Yield();
            cts.Cancel();
            yield return Page<int>.FromValues(new[] {0, 1}, "abc", new MockResponse(200));

            await Task.Yield();
            cancellationToken.ThrowIfCancellationRequested();
            throw new Exception();
        }
    }
}
