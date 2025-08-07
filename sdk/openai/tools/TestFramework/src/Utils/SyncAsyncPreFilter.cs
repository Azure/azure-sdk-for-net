// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework.Interfaces;

namespace OpenAI.TestFramework.Utils
{
    /// <summary>
    /// Filter to exclude sync only or async only tests in the appropriate test run.
    /// </summary>
    public class SyncAsyncPreFilter : IPreFilter
    {
        private bool _isAsync;

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="isAsync">True to filter for an async test run, false to filter for sync test run.</param>
        public SyncAsyncPreFilter(bool isAsync)
        {
            _isAsync = isAsync;
        }

        /// <inheritdoc />
        public bool IsMatch(Type type)
            => type.GetCustomAttribute<AutoSyncAsyncTestFixtureAttribute>() != null;

        /// <inheritdoc />
        public bool IsMatch(Type type, MethodInfo method)
        {
            if (!IsMatch(type))
            {
                return false;
            }

            return _isAsync && method.GetCustomAttribute<SyncOnlyAttribute>() == null
                || !_isAsync && method.GetCustomAttribute<AsyncOnlyAttribute>() == null;
        }
    }
}
