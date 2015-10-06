// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if NETFX_CORE
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Web.Http;
#else

#endif

#if NETFX_CORE
namespace System.Net.Http.Formatting
#else
namespace Microsoft.HDInsight.Net.Http.Formatting.Internal
#endif
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;
    using System.Runtime.Serialization;
    using System.Text;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;

    /// <summary>
    ///  NameValueCollection to represent form data and to generate form data output.
    /// </summary>
#if NETFX_CORE
    internal class HttpValueCollection : IEnumerable<KeyValuePair<string, string>>
#else
    [Serializable]
    internal class HttpValueCollection : NameValueCollection
#endif
    {
#if NETFX_CORE
        internal readonly HashSet<string> Names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        internal readonly List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Creates a new <see cref="System.Net.Http.Formatting.HttpValueCollection"/> instance 
        /// </summary>
        public HttpValueCollection()
        {
        }
#else
        protected HttpValueCollection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private HttpValueCollection()
            : base(StringComparer.OrdinalIgnoreCase) // case-insensitive keys
        {
        }
#endif
        // Use a builder function instead of a ctor to avoid virtual calls from the ctor.
        // The above condition is only important in the Full .NET fx implementation.
        internal static HttpValueCollection Create()
        {
            return new HttpValueCollection();
        }

        internal static HttpValueCollection Create(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            Contract.Assert(pairs != null);

            var hvc = new HttpValueCollection();

            // Ordering example:
            //   k=A&j=B&k=C --> k:[A,C];j=[B].
            foreach (KeyValuePair<string, string> kvp in pairs)
            {
                hvc.Add(kvp.Key, kvp.Value);
            }
#if !NETFX_CORE
            hvc.IsReadOnly = false;
#endif
            return hvc;
        }

        /// <summary>
        /// Adds a name-value pair to the collection.
        /// </summary>
        /// <param name="name">The name to be added as a case insensitive string.</param>
        /// <param name="value">The value to be added.</param>
        public
#if !NETFX_CORE
            override
#endif
 void Add(string name, string value)
        {
            ThrowIfMaxHttpCollectionKeysExceeded(this.Count);

            name = name ?? String.Empty;
            value = value ?? String.Empty;

#if NETFX_CORE
            Names.Add(name);
            List.Add(new KeyValuePair<string, string>(name, value));
#else
            base.Add(name, value);
#endif
        }

        /// <summary>
        /// Converts the content of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance, multiple values with a single key are comma separated.</returns>
        public override string ToString()
        {
            return this.ToString(true);
        }

        private static void ThrowIfMaxHttpCollectionKeysExceeded(int count)
        {
            if (count >= MediaTypeFormatter.MaxHttpCollectionKeys)
            {
                throw Error.InvalidOperation(Resources.MaxHttpCollectionKeyLimitReached, MediaTypeFormatter.MaxHttpCollectionKeys, typeof(MediaTypeFormatter));
            }
        }

        private string ToString(bool urlEncode)
        {
            if (this.Count == 0)
            {
                return String.Empty;
            }

            StringBuilder builder = new StringBuilder();
            bool first = true;
#if NETFX_CORE
            foreach (string name in Names)
#else
            foreach (string name in this)
#endif
            {
                string[] values = this.GetValues(name);
                if (values == null || values.Length == 0)
                {
                    first = AppendNameValuePair(builder, first, urlEncode, name, String.Empty);
                }
                else
                {
                    foreach (string value in values)
                    {
                        first = AppendNameValuePair(builder, first, urlEncode, name, value);
                    }
                }
            }

            return builder.ToString();
        }

        private static bool AppendNameValuePair(StringBuilder builder, bool first, bool urlEncode, string name, string value)
        {
            string effectiveName = name ?? String.Empty;
            string encodedName = urlEncode ? UriQueryUtility.UrlEncode(effectiveName) : effectiveName;

            string effectiveValue = value ?? String.Empty;
            string encodedValue = urlEncode ? UriQueryUtility.UrlEncode(effectiveValue) : effectiveValue;

            if (first)
            {
                first = false;
            }
            else
            {
                builder.Append("&");
            }

            builder.Append(encodedName);
            if (!String.IsNullOrEmpty(encodedValue))
            {
                builder.Append("=");
                builder.Append(encodedValue);
            }
            return first;
        }

#if NETFX_CORE
        /// <summary>
        /// Gets the values associated with the specified name
        /// combined into one comma-separated list.
        /// </summary>
        /// <param name="name">The name of the entry that contains the values to get. The name can be null.</param>
        /// <returns>A <see cref="System.String"/> that contains a comma-separated list of url encoded values associated
        /// with the specified name if found; otherwise, null. The values are Url encoded.</returns>
        public string this[string name]
        {
            get
            {
                return Get(name);
            }
        }

        /// <summary>
        /// Gets the number of names in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                return Names.Count;
            }
        }

        /// <summary>
        /// Gets the values associated with the specified name
        /// combined into one comma-separated list.
        /// </summary>
        /// <param name="name">The name of the entry that contains the values to get. The name can be null.</param>
        /// <returns>
        /// A <see cref="System.String"/> that contains a comma-separated list of url encoded values associated
        /// with the specified name if found; otherwise, null. The values are Url encoded.
        /// </returns>
        public string Get(string name)
        {
            name = name ?? String.Empty;

            if (!Names.Contains(name))
            {
                return null;
            }

            List<string> values = GetValuesInternal(name);
            Contract.Assert(values != null && values.Count > 0);

            return String.Join(",", values);
        }

        /// <summary>
        /// Gets the values associated with the specified name.
        /// </summary>
        /// <param name="name">The <see cref="System.String"/></param>
        /// <returns>A <see cref="System.String"/> that contains url encoded values associated with the name, or null if the name does not exist.</returns>
        public string[] GetValues(string name)
        {
            name = name ?? String.Empty;

            if (!Names.Contains(name))
            {
                return null;
            }

            return GetValuesInternal(name).ToArray();
        }

        // call this when only when there are values available.
        private List<string> GetValuesInternal(string name)
        {
            List<string> values = new List<string>();

            for (int i = 0; i < List.Count; i++)
            {
                KeyValuePair<string, string> kvp = List[i];

                if (String.Equals(kvp.Key, name, StringComparison.OrdinalIgnoreCase))
                {
                    values.Add(kvp.Value);
                }
            }

            return values;
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }
#endif
    }
}
