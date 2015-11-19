// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

#if !NETFX_CORE
#endif

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension methods to allow strongly typed objects to be read from the query component of <see cref="Uri"/> instances.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class UriExtensions
    {
#if NETFX_CORE
        /// <summary>
        /// Parses the query portion of the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="address">The <see cref="Uri"/> instance from which to read.</param>
        /// <returns>A <see cref="HttpValueCollection"/> containing the parsed result.</returns>
        public static HttpValueCollection ParseQueryString(this Uri address)
#else
        /// <summary>
        /// Parses the query portion of the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="address">The <see cref="Uri"/> instance from which to read.</param>
        /// <returns>A <see cref="NameValueCollection"/> containing the parsed result.</returns>
        public static NameValueCollection ParseQueryString(this Uri address)
#endif
        {
            if (address == null)
            {
                throw Error.ArgumentNull("address");
            }

            return new FormDataCollection(address).ReadAsNameValueCollection();
        }

        /// <summary>
        /// Reads HTML form URL encoded data provided in the <see cref="Uri"/> query component as a <see cref="JObject"/> object.
        /// </summary>
        /// <param name="address">The <see cref="Uri"/> instance from which to read.</param>
        /// <param name="value">An object to be initialized with this instance or null if the conversion cannot be performed.</param>
        /// <returns><c>true</c> if the query component can be read as <see cref="JObject"/>; otherwise <c>false</c>.</returns>
        public static bool TryReadQueryAsJson(this Uri address, out JObject value)
        {
            if (address == null)
            {
                throw Error.ArgumentNull("address");
            }

            IEnumerable<KeyValuePair<string, string>> query = new FormDataCollection(address);
            return FormUrlEncodedJson.TryParse(query, out value);
        }

        /// <summary>
        /// Reads HTML form URL encoded data provided in the <see cref="Uri"/> query component as an <see cref="Object"/> of the given <paramref name="type"/>.
        /// </summary>
        /// <param name="address">The <see cref="Uri"/> instance from which to read.</param>
        /// <param name="type">The type of the object to read.</param>
        /// <param name="value">An object to be initialized with this instance or null if the conversion cannot be performed.</param>
        /// <returns><c>true</c> if the query component can be read as the specified type; otherwise <c>false</c>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1007:UseGenericsWhereAppropriate", Justification = "This is the non-generic version.")]
        public static bool TryReadQueryAs(this Uri address, Type type, out object value)
        {
            if (address == null)
            {
                throw Error.ArgumentNull("address");
            }

            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }

            IEnumerable<KeyValuePair<string, string>> query = new FormDataCollection(address);
            JObject jsonObject;
            if (FormUrlEncodedJson.TryParse(query, out jsonObject))
            {
                using (JTokenReader jsonReader = new JTokenReader(jsonObject))
                {
                    value = new JsonSerializer().Deserialize(jsonReader, type);
                }
                return true;
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Reads HTML form URL encoded data provided in the <see cref="Uri"/> query component as an <see cref="Object"/> of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to read.</typeparam>
        /// <param name="address">The <see cref="Uri"/> instance from which to read.</param>
        /// <param name="value">An object to be initialized with this instance or null if the conversion cannot be performed.</param>
        /// <returns><c>true</c> if the query component can be read as the specified type; otherwise <c>false</c>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The T represents the output parameter, not an input parameter.")]
        public static bool TryReadQueryAs<T>(this Uri address, out T value)
        {
            if (address == null)
            {
                throw Error.ArgumentNull("address");
            }

            IEnumerable<KeyValuePair<string, string>> query = new FormDataCollection(address);
            JObject jsonObject;
            if (FormUrlEncodedJson.TryParse(query, out jsonObject))
            {
                value = jsonObject.ToObject<T>();
                return true;
            }

            value = default(T);
            return false;
        }
    }
}
