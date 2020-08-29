// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    internal static class TestExtensions
    {
        public static async Task<T> CatchAsync<T>(this ClientTestBase source, Func<Task> action) where T : Exception
        {
            Assert.IsNotNull(source);
            Assert.IsNotNull(action);

            try
            {
                await action().ConfigureAwait(false);
                throw new AssertionException($@"Expected exception {typeof(T)} was not thrown");
            }
            catch (T ex)
            {
                return ex;
            }
        }
    }
}
