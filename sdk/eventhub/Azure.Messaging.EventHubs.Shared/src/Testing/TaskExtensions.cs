// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The set of extensions for the <see cref="Task" />
    ///   class.
    /// </summary>
    ///
    internal static class TaskExtensions
    {
        /// <summary>
        ///   Completes the <paramref name="instance" /> by awaiting, ignoring any exceptions
        ///   that may occur.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        public static async Task IgnoreExceptions(this Task instance)
        {
            try
            {
                await instance.ConfigureAwait(false);
            }
            catch
            {
                // Intentionally ignoring exceptions.
            }
        }
    }
}
