// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host
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
