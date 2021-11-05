// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal class ContextAccessor<TValue> : IContextGetter<TValue>, IContextSetter<TValue>
    {
        private TValue _value;

        public TValue Value
        {
            get { return _value; }
        }

        public void SetValue(TValue value)
        {
            _value = value;
        }
    }
}
