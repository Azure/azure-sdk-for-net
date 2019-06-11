// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Common;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Test
{
    partial class TestHelper
    {
        public static void AssertSequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual) 
            => Assert.IsTrue(actual.SequenceEqual(expected), "Actual sequence does not match expected sequence");

        public static void AssertMetadataEquality(Metadata expected, Metadata actual)
        {
            Assert.IsNotNull(expected, "Expected metadata is null");
            Assert.IsNotNull(actual, "Actual metadata is null");

            Assert.AreEqual(expected.Count, actual.Count, "Metadata counts are not equal");

            foreach (var kvp in expected)
            {
                if (!actual.TryGetValue(kvp.Key, out var value) ||
                    String.Compare(kvp.Value, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    Assert.Fail($"Expected key <{kvp.Key}> with value <{kvp.Value}> not found");
                }
            }
        }

        static Action<T, T> GetDefaultExceptionAssertion<T>(Func<T, T, bool> predicate)
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

        public static Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, T expectedException, Func<T, T, bool> predicate = null)
            where T : Exception
            => AssertExpectedExceptionAsync(task, expectedException, GetDefaultExceptionAssertion(predicate));

        public static Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, Action<T> assertion)
            where T : Exception
            => AssertExpectedExceptionAsync<T, U>(task, default, (_, a) => assertion(a));

        public static async Task AssertExpectedExceptionAsync<T, U>(StorageTask<U> task, T expectedException, Action<T, T> assertion)
            where T : Exception
        {
            Assert.IsNotNull(assertion);

            try
            {
                await task;

                Assert.Fail("Expected exception not found");
            }
            catch (T actualException)
            {
                assertion(expectedException, actualException);
            }
        }
    }
}
