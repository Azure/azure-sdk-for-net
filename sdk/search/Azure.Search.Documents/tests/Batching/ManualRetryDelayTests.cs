// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Search.Documents.Batching;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class ManualRetryDelayTests
    {
        [Test]
        public async Task AddsDelay()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            delay.Update(throttled: true);
            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                70 <= watch.ElapsedMilliseconds && watch.ElapsedMilliseconds <= 500,
                $"Expected a delay between 70ms and 500ms, not {watch.ElapsedMilliseconds}");
        }

        [Test]
        public async Task AddsMoreDelay()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();
            delay.Update(throttled: true);

            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                148 <= watch.ElapsedMilliseconds && watch.ElapsedMilliseconds <= 500,
                $"Expected a delay between 148ms and 500ms, not {watch.ElapsedMilliseconds}");
        }

        [Test]
        public async Task ClampDelay()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();
            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();
            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();
            delay.Update(throttled: true);

            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                248 <= watch.ElapsedMilliseconds && watch.ElapsedMilliseconds <= 500,
                $"Expected a delay between 248ms and 500ms, not {watch.ElapsedMilliseconds}");
        }

        [Test]
        public async Task NoDelay()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                watch.ElapsedMilliseconds < 100,
                $"Expected a delay less than 100ms, not {watch.ElapsedMilliseconds}");
        }

        [Test]
        public async Task ClearDelay()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();
            delay.Update(throttled: true);
            await delay.WaitIfNeededAsync();

            delay.Update(throttled: false);
            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                watch.ElapsedMilliseconds < 100,
                $"Expected a delay less than 100ms, not {watch.ElapsedMilliseconds}");
        }

        [Test]
        public async Task NoDelayIfCalledAfterWait()
        {
            Stopwatch watch = new Stopwatch();
            var delay = new ManualRetryDelay
            {
                Delay = TimeSpan.FromMilliseconds(100),
                MaxDelay = TimeSpan.FromMilliseconds(250)
            };

            delay.Update(throttled: true);
            await Task.Delay(TimeSpan.FromMilliseconds(120));

            watch.Start();
            await delay.WaitIfNeededAsync();
            watch.Stop();

            Assert.IsTrue(
                watch.ElapsedMilliseconds < 100,
                $"Expected a delay less than 100ms, not {watch.ElapsedMilliseconds}");
        }
    }
}
