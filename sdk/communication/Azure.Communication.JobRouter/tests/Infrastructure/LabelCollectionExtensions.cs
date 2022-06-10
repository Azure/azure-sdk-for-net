// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;

namespace Azure.Communication.JobRouter.Tests.Infrastructure
{
    internal static class LabelCollectionExtensions
    {
        /// <summary>
        /// Checks for equality of LabelCollection
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="ignoreKeys">(Optional) Keys to ignore while comparing</param>
        /// <returns></returns>
        public static bool IsEqual(this LabelCollection actual, LabelCollection expected, params string[] ignoreKeys)
        {
            if (!ignoreKeys.Any())
            {
                return Enumerable.SequenceEqual(actual, expected);
            }

            var actualCopy = actual.ToDictionary(kv => kv.Key, kv => kv.Value);
            foreach (string key in ignoreKeys)
            {
                if (actualCopy.ContainsKey(key))
                {
                    actualCopy.Remove(key);
                }
            }
            return Enumerable.SequenceEqual(actualCopy, expected);
        }
    }
}
