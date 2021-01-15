// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Tests
{
    /// <summary>
    /// Extension methods to make tests easier to author.
    /// </summary>
    public static partial class TestExtensions
    {
        /// <summary>
        /// Convert an IAsyncEnumerable into a List to make test verification
        /// easier.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="items">The sequence of items.</param>
        /// <returns>A list of all the items in the sequence.</returns>
        public static async Task<IList<T>> ToListAsync<T>(this IAsyncEnumerable<T> items)
        {
            var all = new List<T>();
            await foreach (T item in items)
            {
                all.Add(item);
            }
            return all;
        }

        public static string GenerateName(this TestRecording recording, string prefix)
        {
            return prefix + recording.GenerateId();
        }
    }
}