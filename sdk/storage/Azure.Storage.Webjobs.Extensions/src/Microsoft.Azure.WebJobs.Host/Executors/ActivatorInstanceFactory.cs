// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class ActivatorInstanceFactory<T> : IJobInstanceFactory<T> 
    {
        private readonly Func<IFunctionInstanceEx, T> _createInstance;

        public ActivatorInstanceFactory(IJobActivator activator)
        {
            if (activator == null)
            {
                throw new ArgumentNullException(nameof(activator));
            }

            _createInstance = activator is IJobActivatorEx activatorEx
                ? new Func<IFunctionInstanceEx, T>(i => activatorEx.CreateInstance<T>(i))
                : new Func<IFunctionInstanceEx, T>(i => activator.CreateInstance<T>());
        }

        public T Create(IFunctionInstanceEx functionInstance)
        {
            return _createInstance(functionInstance);
        }
    }
}
