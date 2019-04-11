// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Base.Pipeline
{
    public partial class HttpPipelineMessage
    {
        public readonly struct HttpMessageOptions
        {
            readonly HttpPipelineMessage _message;

            internal HttpMessageOptions(HttpPipelineMessage message)
                => _message = message;

            public T Add<T>(T option) where T : class
            {
                _message._options.SetOption(typeof(T), option);
                return option;
            }

            public void Add(object option)
                => _message._options.SetOption(option.GetType(), option);

            public T GetOrDefault<T>() where T : class
            {
                if (_message._options.TryGetOption(typeof(T), out object value)) {
                    return (T)value;
                }
                return default;
            }

            public void SetOption(object key, long value)
                => _message._options.SetOption(key, value);

            void SetOption(object key, object value)
                => _message.Options.SetOption(key, value);

            public bool TryGetOption(object key, out object value)
                => _message._options.TryGetOption(key, out value);

            public bool TryGetOption(object key, out long value)
                => _message._options.TryGetOption(key, out value);

            public long GetInt64(object key)
                => _message._options.GetInt64(key);

            public object GetObject(object key)
                => _message._options.GetInt64(key);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool Equals(object obj) => base.Equals(obj);

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override int GetHashCode() => base.GetHashCode();

            [EditorBrowsable(EditorBrowsableState.Never)]
            public override string ToString() => base.ToString();
        }
    }
}
