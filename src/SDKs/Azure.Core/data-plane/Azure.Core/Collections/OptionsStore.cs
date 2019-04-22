// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Collections
{
    struct OptionsStore
    {
        // TODO (pri 3): optimize the dictionaries
        // TODO (pri 2): test that these don't get created when options are read/get, but not set.
        Dictionary<object, object> _referenceTypeOptions;
        Dictionary<object, long> _ulongOptions;

        public void SetOption(object key, long value)
        {
            if (_ulongOptions == null) _ulongOptions = new Dictionary<object, long>();
            _ulongOptions[key] = value;
        }

        public void SetOption(object key, object value)
        {
            if (_referenceTypeOptions == null) _referenceTypeOptions = new Dictionary<object, object>();
            _referenceTypeOptions[key] = value;
        }

        public bool TryGetOption(object key, out object value)
        {
            if (_referenceTypeOptions == null)
            {
                value = default;
                return false;
            }
            return _referenceTypeOptions.TryGetValue(key, out value);
        }

        public bool TryGetOption(object key, out long value)
        {
            if (_ulongOptions == null)
            {
                value = default;
                return false;
            }
            return _ulongOptions.TryGetValue(key, out value);
        }

        public long GetInt64(object key)
        {
            if (!TryGetOption(key, out long value)) throw new KeyNotFoundException();
            return value;
        }

        public object GetObject(object key)
        {
            if (!TryGetOption(key, out object value)) throw new KeyNotFoundException();
            return value;
        }

        public void Clear()
        {
            _referenceTypeOptions?.Clear();
            _ulongOptions?.Clear();
        }
    }
}
