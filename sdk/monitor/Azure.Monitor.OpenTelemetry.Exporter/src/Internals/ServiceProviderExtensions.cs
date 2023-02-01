// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1_OR_GREATER
using Microsoft.Extensions.Options;
#endif

namespace System
{
    /// <summary>
    /// Extension methods for OpenTelemetry dependency injection support.
    /// </summary>
    internal static class ServiceProviderExtensions
    {
        /// <summary>
        /// Get options from the supplied <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T">Options type.</typeparam>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        /// <returns>Options instance.</returns>
        public static T GetOptions<T>(this IServiceProvider serviceProvider)
            where T : class, new()
        {
#if NET461 || NETSTANDARD2_0 || NETSTANDARD2_1 || NETCOREAPP3_1_OR_GREATER
            IOptions<T> options = (IOptions<T>)serviceProvider.GetService(typeof(IOptions<T>));

            // Note: options could be null if user never invoked services.AddOptions().
            return options?.Value ?? new T();
#else
            return new T();
#endif
        }
    }
}
