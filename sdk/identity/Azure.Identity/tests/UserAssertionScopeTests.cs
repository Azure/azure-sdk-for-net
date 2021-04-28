// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class UserAssertionScopeTests
    {
        [Test]
        public async Task UserAssertionValueIsConsistentAcrossThreads()
        {
            var rnd = new Random();
            var evt = new ManualResetEventSlim(false);
            List<Task> tasks = new();

            for (int i = 0; i < 1000; i++)
            {
                var runner = new AsyncMethodRunner(evt, rnd);
                tasks.Add(runner.Do());
            }
            evt.Set();
            await Task.WhenAll(tasks);
        }

        public class AsyncMethodRunner
        {
            private readonly string _value;
            private readonly Random _rnd;
            private readonly ManualResetEventSlim _evt;

            public AsyncMethodRunner(ManualResetEventSlim evt, Random rnd)
            {
                _value = Guid.NewGuid().ToString();
                _rnd = rnd;
                _evt = evt;
            }

            public Task Do()
            {
                return Task.Run(
                    async () =>
                    {
                        _evt.Wait();
                        using (_ = new UserAssertionScope(_value))
                        {
                            await Task.Delay(_rnd.Next(10, 100));
                            Assert.AreEqual(_value, UserAssertionScope.Current.UserAssertion.Assertion);
                            await DoInternal();
                        }
                    });
            }

            private async Task DoInternal()
            {
                await Task.Delay(_rnd.Next(10, 20));
                Assert.AreEqual(_value, UserAssertionScope.Current.UserAssertion.Assertion);
            }
        }
    }
}
