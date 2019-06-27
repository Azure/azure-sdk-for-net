// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    static partial class TestHelper
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
            Assert.IsTrue(actual.SequenceEqual(expected), "Actual sequence does not match expected sequence");
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

        public static void AssertExpectedException<T>(Action action, Func<T, bool> predicate = null)
            where T : Exception
            => AssertExpectedException(action, default, GetDefaultExceptionAssertion<T>((_, a) => predicate(a)));

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
    }
}
