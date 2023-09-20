// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class MemoryRequest : Request
    {
        /// <summary>
        /// TBD.
        /// </summary>
        public MemoryRequest()
        {
            ClientRequestId = Guid.NewGuid().ToString();
        }

        private readonly DictionaryHeaders _headers = new();

        /// <summary>
        /// TBD.
        /// </summary>
        public override RequestContent? Content
        {
            get { return base.Content; }
            set
            {
                base.Content = value;
            }
        }

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

       /// <summary>
       /// TBD.
       /// </summary>
       protected override void SetHeader(string name, string value) => _headers.SetHeader(name, value);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override void AddHeader(string name, string value) => _headers.AddHeader(name, value);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override bool TryGetHeader(string name, out string value) => _headers.TryGetHeader(name, out value);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _headers.TryGetHeaderValues(name, out values);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override bool ContainsHeader(string name) => _headers.TryGetHeaderValues(name, out _);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override bool RemoveHeader(string name) => _headers.RemoveHeader(name);

#if HAS_INTERNALS_VISIBLE_CORE
        internal
#endif

        /// <summary>
        /// TBD.
        /// </summary>
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.EnumerateHeaders();

        /// <summary>
        /// TBD.
        /// </summary>
        public override string ClientRequestId { get; set; }

        /// <summary>
        /// TBD.
        /// </summary>
        public override string ToString() => $"{Method} {Uri}";

        /// <summary>
        /// TBD.
        /// </summary>
        public override void Dispose()
        { }
    }
}
