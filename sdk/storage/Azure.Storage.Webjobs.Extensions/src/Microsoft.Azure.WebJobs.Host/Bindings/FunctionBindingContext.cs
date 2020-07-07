// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Provides binding context for all bind operations scoped to a particular
    /// function invocation.
    /// </summary>
    public class FunctionBindingContext
    {
        private readonly Guid _functionInstanceId;
        private readonly CancellationToken _functionCancellationToken;
        private readonly IServiceProvider _functionInvocationServices;
        private static Lazy<IServiceProvider> _emptyServiceProvider = new Lazy<IServiceProvider>(CreateEmptyServiceProvider);

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="functionInstanceId">The instance ID of the function being bound to.</param>
        /// <param name="functionCancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <param name="functionDescriptor">Current function being executed. </param>
        public FunctionBindingContext(
            Guid functionInstanceId,
            CancellationToken functionCancellationToken,
            FunctionDescriptor functionDescriptor = null)
            : this(functionInstanceId, functionCancellationToken, null, functionDescriptor)
        {
        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="functionInstanceId">The instance ID of the function being bound to.</param>
        /// <param name="functionCancellationToken">The <see cref="CancellationToken"/> to use.</param>
        /// <param name="functionInvocationServices">The user logger.</param>
        /// <param name="functionDescriptor">Current function being executed. </param>
        public FunctionBindingContext(
            Guid functionInstanceId,
            CancellationToken functionCancellationToken,
            IServiceProvider functionInvocationServices,
            FunctionDescriptor functionDescriptor)
        {
            _functionInstanceId = functionInstanceId;
            _functionCancellationToken = functionCancellationToken;
            _functionInvocationServices = functionInvocationServices ?? _emptyServiceProvider.Value;
            MethodName = functionDescriptor?.LogName;
        }

        /// <summary>
        /// Gets the instance ID of the function being bound to.
        /// </summary>
        public Guid FunctionInstanceId => _functionInstanceId;

        /// <summary>
        /// Gets the <see cref="CancellationToken"/> to use.
        /// </summary>
        public CancellationToken FunctionCancellationToken => _functionCancellationToken;

        /// <summary>
        /// The short name of the current function. 
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// The service provider for the current function invocation scope.
        /// </summary>
        public IServiceProvider InstanceServices { get; set; }

        /// <summary>
        /// Creates an object instance with constructor arguments provided in the
        /// method call and from the current function context scoped services.
        /// </summary>
        /// <param name="type">The type to instantiate.</param>
        /// <param name="parameters">Parameters not provided by the function service provider.</param>
        /// <returns>An instance of the type specified.</returns>
        public object CreateObjectInstance(Type type, params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance(_functionInvocationServices, type, parameters);
        }

        /// <summary>
        /// Creates an object instance with constructor arguments provided in the
        /// method call and from the current function context scoped services.
        /// </summary>
        /// <typeparam name="T">The type to instantiate.</typeparam>
        /// <param name="parameters">Parameters not provided by the function service provider.</param>
        /// <returns>An instance of type T.</returns>
        public T CreateObjectInstance<T>(params object[] parameters)
        {
            return ActivatorUtilities.CreateInstance<T>(_functionInvocationServices, parameters);
        }

        private static IServiceProvider CreateEmptyServiceProvider()
        {
            return new ServiceCollection().BuildServiceProvider();
        }
    }
}
