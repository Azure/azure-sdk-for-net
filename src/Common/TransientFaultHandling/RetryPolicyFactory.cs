// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.WindowsAzure.Common.TransientFaultHandling
{
    /// <summary>
    /// Provides a factory class for instantiating application-specific retry policies described in the application configuration.
    /// </summary>
    public static class RetryPolicyFactory
    {
        /// <summary>
        /// Sets the retry manager.
        /// </summary>
        /// <param name="retryManager">The retry manager.</param>
        /// <param name="throwIfSet">true to throw an exception if the writer is already set; otherwise, false. Defaults to <see langword="true"/>.</param>
        /// <exception cref="InvalidOperationException">The factory is already set and <paramref name="throwIfSet"/> is true.</exception>
        public static void SetRetryManager(RetryManager retryManager, bool throwIfSet = true)
        {
            RetryManager.SetDefault(retryManager, throwIfSet);
        }

        /// <summary>
        /// Creates a retry manager from the system configuration.
        /// </summary>
        /// <returns></returns>
        public static RetryManager CreateDefault()
        {
            var manager = new RetryManager(new[] { RetryStrategy.DefaultExponential });
            RetryManager.SetDefault(manager);
            return manager;
        }

        /// <summary>
        /// Returns a retry policy with the specified error detection strategy and the default retry strategy defined in the configuration. 
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> interface that is responsible for detecting transient conditions.</typeparam>
        /// <returns>The retry policy that is initialized with the default retry strategy.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "As designed")]
        public static RetryPolicy GetRetryPolicy<T>() where T : ITransientErrorDetectionStrategy, new()
        {
            return GetOrCreateRetryManager().GetRetryPolicy<T>();
        }

        /// <summary>
        /// Returns an instance of the <see cref="RetryPolicy"/> object for a given error detection strategy and retry strategy.
        /// </summary>
        /// <typeparam name="T">The type that implements the <see cref="ITransientErrorDetectionStrategy"/> interface that is responsible for detecting transient conditions.</typeparam>
        /// <param name="retryStrategyName">The name under which a retry strategy definition is registered in the application configuration.</param>
        /// <returns>The retry policy that is initialized with the retry strategy matching the provided name.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "As designed")]
        public static RetryPolicy GetRetryPolicy<T>(string retryStrategyName) where T : ITransientErrorDetectionStrategy, new()
        {
            return GetOrCreateRetryManager().GetRetryPolicy<T>(retryStrategyName);
        }

        private static RetryManager GetOrCreateRetryManager()
        {
            try
            {
                return RetryManager.Instance;
            }
            catch (InvalidOperationException)
            {
                CreateDefault();
            }

            return RetryManager.Instance;
        }
    }
}
