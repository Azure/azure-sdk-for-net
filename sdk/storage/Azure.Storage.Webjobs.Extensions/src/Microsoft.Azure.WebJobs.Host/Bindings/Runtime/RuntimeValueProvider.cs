// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Runtime
{
    internal sealed class RuntimeValueProvider : IValueBinder, IDisposable
    {
        private readonly Binder _binder;
        private readonly Type _parameterType;
        private bool _disposed;

        public RuntimeValueProvider(IAttributeBindingSource bindingSource, Type parameterType)
        {
            _binder = new Binder(bindingSource);
            _parameterType = parameterType;
        }

        public Type Type
        {
            get { return _parameterType; }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_binder);
        }

        public async Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            await _binder.Complete(cancellationToken);
        }

        public string ToInvokeString()
        {
            return null;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (_binder != null)
                {
                    _binder.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
