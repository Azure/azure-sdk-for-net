// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ServiceModel.Rest
{
    public abstract class RestRequest : IDisposable
    {
        /// <summary>
        /// Adds a header value to the header collection.
        /// </summary>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        protected internal abstract void SetHeader(string name, string value);

        /// <summary>
        /// Frees resources held by this <see cref="RestRequest"/> instance.
        /// </summary>
        public abstract void Dispose();
    }
}