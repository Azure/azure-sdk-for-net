// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    internal static partial class TestHelper
    {
        public static byte[] GetRandomBuffer(long size, Random random = null)
        {
            random ??= new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        public static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.AreEqual(expected.Count(), actual.Count(), "Actual sequence length does not match expected sequence length");
            (int Index, T Expected, T Actual)[] firstErrors = expected.Zip(actual, (e, a) => (Expected: e, Actual: a)).Select((x, i) => (Index: i, x.Expected, x.Actual)).Where(x => !x.Expected.Equals(x.Actual)).Take(5).ToArray();
            Assert.IsFalse(firstErrors.Any(), $"Actual sequence does not match expected sequence at locations\n{string.Join("\n", firstErrors.Select(e => $"{e.Index} => expected = {e.Expected}, actual = {e.Actual}"))}");
        }

        public static IEnumerable<byte> AsBytes(this Stream s)
        {
            while (s.ReadByte() is var b && b != -1)
            {
                yield return (byte)b;
            }
        }

        internal static Action<T, T> GetDefaultExceptionAssertion<T>(Func<T, T, bool> predicate)
            where T : Exception
        {
            predicate = predicate ?? new Func<T, T, bool>((e, a) => true);

            return
                (e, a) =>
                {
                    if (predicate(e, a))
                    {
                        Assert.AreEqual(e.Message, a.Message);
                    }
                    else
                    {
                        Assert.Fail($"Unexpected exception: {a.Message}");
                    }
                }
                ;
        }

        public static void AssertExpectedException<T>(Action action, T expectedException, Func<T, T, bool> predicate = null)
            where T : Exception
            => AssertExpectedException(action, expectedException, GetDefaultExceptionAssertion(predicate));

        public static void AssertExpectedException<T>(Action action, Func<T, bool> predicate)
            where T : Exception
        {
            Assert.IsNotNull(action);
            Assert.IsNotNull(predicate);

            try
            {
                action();

                Assert.Fail("Expected exception not found");
            }
            catch (T actualException)
            {
                if (!predicate(actualException))
                {
                    Assert.Fail($"Unexpected exception: {actualException.Message}");
                }
            }
        }

        public static void AssertExpectedException<T>(Action action, T expectedException, Action<T, T> assertion)
            where T : Exception
        {
            Assert.IsNotNull(expectedException);
            Assert.IsNotNull(assertion);

            try
            {
                action();

                Assert.Fail("Expected exception not found");
            }
            catch (T actualException)
            {
                assertion(expectedException, actualException);
            }
        }

        public static Task AssertExpectedExceptionAsync<T>(Task task, T expectedException, Func<T, T, bool> predicate = null)
            where T : Exception
            => AssertExpectedExceptionAsync(task, expectedException, GetDefaultExceptionAssertion(predicate));

        public static Task AssertExpectedExceptionAsync<T>(Task task, Action<T> assertion)
            where T : Exception
            => AssertExpectedExceptionAsync<T>(task, default, (_, a) => assertion(a));

        public static async Task AssertExpectedExceptionAsync<T>(Task task, T expectedException, Action<T, T> assertion)
            where T : Exception
        {
            Assert.IsNotNull(assertion);

            try
            {
                await task.ConfigureAwait(false);

                Assert.Fail("Expected exception not found");
            }
            catch (T actualException)
            {
                assertion(expectedException, actualException);
            }
        }

        public static async Task<T> CatchAsync<T>(Func<Task> action)
            where T : Exception
        {
            try
            {
                await action().ConfigureAwait(false);
                Assert.Fail("Expected exception not found");
            }
            catch (T ex)
            {
                return ex;
            }
            catch (Exception other)
            {
                Assert.Fail($"Expected exception of type {typeof(T).Name}, not {other.ToString()}");
            }

            throw new InvalidOperationException("Won't ever get here!");
        }

        public static void AssertCacheableProperty<T>(T expected, Func<T> property)
        {
            T actual = property();
            Assert.AreEqual(expected, actual); // first call calculates and caches value
            Assert.AreSame(actual, property()); // subsequent calls use cached value
        }

        public static void AssertInconclusiveRecordingFriendly(RecordedTestMode mode, string message = default)
        {
            if (mode == RecordedTestMode.Record)
            {
                Assert.Pass(string.Join("\n", "Results inconclusive. Passing for ease of recording management.", message));
            }
            else
            {
                Assert.Inconclusive(message);
            }
        }

        public static CancellationTokenSource GetTimeoutTokenSource(int seconds)
        {
            CancellationTokenSource cts = new();
            cts.CancelAfter(TimeSpan.FromSeconds(seconds));
            return cts;
        }
    }
}
