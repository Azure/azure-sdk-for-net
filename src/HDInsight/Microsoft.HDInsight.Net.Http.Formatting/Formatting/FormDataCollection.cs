// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if !NETFX_CORE
#endif

#if NETFX_CORE
using NameValueCollection = System.Net.Http.Formatting.HttpValueCollection;
#endif

namespace Microsoft.HDInsight.Net.Http.Formatting.Formatting
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    /// <summary>
    /// Represent the form data.
    /// - This has 100% fidelity (including ordering, which is important for deserializing ordered array). 
    /// - using interfaces allows us to optimize the implementation. E.g., we can avoid eagerly string-splitting a 10gb file. 
    /// - This also provides a convenient place to put extension methods. 
    /// </summary>
#if NETFX_CORE
    internal
#else
    public
#endif
    class FormDataCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly IEnumerable<KeyValuePair<string, string>> _pairs;

        private NameValueCollection _nameValueCollection;

        /// <summary>
        /// Initialize a form collection around incoming data. 
        /// The key value enumeration should be immutable. 
        /// </summary>
        /// <param name="pairs">incoming set of key value pairs. Ordering is preserved.</param>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is the convention for representing FormData")]
        public FormDataCollection(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            if (pairs == null)
            {
                throw Error.ArgumentNull("pairs");
            }
            this._pairs = pairs;
        }

        /// <summary>
        /// Initialize a form collection from a query string. 
        /// Uri and FormURl body have the same schema. 
        /// </summary>
        public FormDataCollection(Uri uri)
        {
            if (uri == null)
            {
                throw Error.ArgumentNull("uri");
            }

            string query = uri.Query;
            if (query != null && query.Length > 0 && query[0] == '?')
            {
                query = query.Substring(1);
            }

            this._pairs = ParseQueryString(query);
        }

        /// <summary>
        /// Initialize a form collection from a URL encoded query string. Any leading question
        /// mark (?) will be considered part of the query string and treated as any other value.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1057:StringUriOverloadsCallSystemUriOverloads", Justification = "string is a query string, not a URI")]
        public FormDataCollection(string query)
        {
            this._pairs = ParseQueryString(query);
        }

        /// <summary>
        /// Gets values associated with a given key. If there are multiple values, they're concatenated.
        /// </summary>
        /// <param name="name">The name of the entry that contains the values to get. The name can be null.</param>
        /// <returns>Values associated with a given key. If there are multiple values, they're concatenated.</returns>
        public string this[string name]
        {
            get
            {
                return this.Get(name);
            }
        }

        // Helper to invoke parser around a query string
        private static IEnumerable<KeyValuePair<string, string>> ParseQueryString(string query)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            if (String.IsNullOrWhiteSpace(query))
            {
                return result;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(query);

            FormUrlEncodedParser parser = new FormUrlEncodedParser(result, Int64.MaxValue);

            int bytesConsumed = 0;
            ParserState state = parser.ParseBuffer(bytes, bytes.Length, ref bytesConsumed, isFinal: true);

            if (state != ParserState.Done)
            {
                throw Error.InvalidOperation(Resources.FormUrlEncodedParseError, bytesConsumed);
            }

            return result;
        }

        /// <summary>
        /// Get the collection as a NameValueCollection.
        /// Beware this loses some ordering. Values are ordered within a key,
        /// but keys are no longer ordered against each other.
        /// </summary>
        public NameValueCollection ReadAsNameValueCollection()
        {
            if (this._nameValueCollection == null)
            {
                // Initialize in a private collection to be thread-safe, and swap the finished object.
                // Ok to double initialize this.
                HttpValueCollection newCollection = HttpValueCollection.Create(this);
                Interlocked.Exchange(ref this._nameValueCollection, newCollection);
            }
            return this._nameValueCollection;
        }

        /// <summary>
        /// Get values associated with a given key. If there are multiple values, they're concatenated. 
        /// </summary>
        public string Get(string key)
        {
            return this.ReadAsNameValueCollection().Get(key);
        }

        /// <summary>
        /// Get a value associated with a given key. 
        /// </summary>
        public string[] GetValues(string key)
        {
            return this.ReadAsNameValueCollection().GetValues(key);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return this._pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable ie = this._pairs;
            return ie.GetEnumerator();
        }
    }
}
