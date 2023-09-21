// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest.Shared.Core;

namespace Azure.Core
{
    /// <summary>
    /// Adapter class for RawRequestUriBuilder.
    /// </summary>
    public class RawRequestUri : RequestUriBuilder
    {
        private readonly RequestUri _uri;

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="uri"></param>
        public RawRequestUri(RequestUri uri)
        {
            _uri = uri;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="escape"></param>
        public override void AppendPath(ReadOnlySpan<char> value, bool escape)
            => _uri.AppendPath(value, escape);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        public override void AppendPath(string value)
            => _uri.AppendPath(value);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="escape"></param>
        public override void AppendPath(string value, bool escape)
            => _uri.AppendPath(value, escape);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="escapeValue"></param>
        public override void AppendQuery(ReadOnlySpan<char> name, ReadOnlySpan<char> value, bool escapeValue)
            => _uri.AppendQuery(name, value, escapeValue);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void AppendQuery(string name, string value)
            => _uri.AppendQuery(name, value);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="escapeValue"></param>
        public override void AppendQuery(string name, string value, bool escapeValue)
            => _uri.AppendQuery(name, value, escapeValue);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="value"></param>
        public override void Reset(Uri value)
            => _uri.Reset(value);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <returns></returns>
        public override Uri ToUri()
            => _uri.ToUri();
    }
}
