// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class BindingExceptionValueProvider : IValueProvider
    {
        private readonly string _message;
        private readonly Exception _exception;

        public BindingExceptionValueProvider(string parameterName, Exception exception)
        {
            _message = exception.Message;
            _exception = new InvalidOperationException(String.Format(CultureInfo.InvariantCulture,
                "Exception binding parameter '{0}'", parameterName), exception);
        }

        public Exception Exception
        {
            get { return _exception; }
        }

        public Type Type
        {
            get { return typeof(object); }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(null);
        }

        public string ToInvokeString()
        {
            return _message;
        }
    }
}
