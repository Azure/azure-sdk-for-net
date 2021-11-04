// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Core.Amqp
{
    #nullable enable
    internal class AnnotatedMessageMetadataDictionary : IDictionary<string, object?>
    {
        private readonly AmqpAnnotatedMessage _message;
        internal const string ContentType = "ContentType";

        public AnnotatedMessageMetadataDictionary(AmqpAnnotatedMessage message)
        {
            _message = message;
        }

        public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, object?> item) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();

        public bool Contains(KeyValuePair<string, object?> item)
        {
            if (item.Key == ContentType)
            {
                switch (item.Value)
                {
                    case null:
                        return _message.Properties.ContentType == null;
                    case string stringVal:
                        return stringVal == _message.Properties.ContentType;
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex) => throw new NotSupportedException();

        public bool Remove(KeyValuePair<string, object?> item) => throw new NotSupportedException();

        public int Count => 1;
        public bool IsReadOnly => false;

        public void Add(string key, object? value) => throw new NotSupportedException();

        public bool ContainsKey(string key) => key == ContentType;

        public bool Remove(string key) => throw new NotSupportedException();

        public bool TryGetValue(string key, out object? value)
        {
            if (key == ContentType)
            {
                value = _message.Properties.ContentType;
                return true;
            }

            value = null;
            return false;
        }

        public object? this[string key]
        {
            get
            {
                if (key == ContentType)
                {
                    return _message.Properties.ContentType;
                }

                throw new NotSupportedException("The key being looked up is not supported");
            }
            set
            {
                if (key == ContentType)
                {
                    AddContentType(value);
                    return;
                }

                throw new NotSupportedException("The key being added is not supported");
            }
        }

        public ICollection<string> Keys => new List<string> { ContentType };
        public ICollection<object?> Values => new List<object?> { _message.Properties.ContentType };

        private void AddContentType(object? value)
        {
            _message.Properties.ContentType = value switch
            {
                null => null,
                string stringVal => stringVal,
                _ => throw new InvalidOperationException($"The value for key '{ContentType}' must be a string.")
            };
        }
    }
}