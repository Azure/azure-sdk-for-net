// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Builds a list of <see cref="SearchField"/> given a model type for use in a <see cref="SearchIndex"/>.
    /// <seealso cref="SimpleFieldAttribute"/>
    /// <seealso cref="SearchableFieldAttribute"/>
    /// </summary>
    public static class FieldBuilder
    {
        private static readonly DefaultNamingPolicy s_defaultNamingPolicy = new DefaultNamingPolicy();

        /// <summary>
        /// Builds a list of <see cref="SearchField"/> given a model type <typeparamref name="T"/> for use in a <see cref="SearchIndex"/>.
        /// By default, all public properties and fields of that model type will generate a <see cref="SearchField"/>;
        /// however, you can ignore them using <see cref="JsonIgnoreAttribute"/> or <see cref="NonSerializedAttribute"/>.
        /// You can further customize the generated <see cref="SearchField"/> using the
        /// <see cref="SimpleFieldAttribute"/> and <see cref="SearchableFieldAttribute"/> attributes.
        /// </summary>
        /// <typeparam name="T">The type of model from which to build fields.</typeparam>
        /// <returns>A list of <see cref="SearchField"/> from model type <typeparamref name="T"/>.</returns>
        public static IList<SearchField> Build<T>() => Build(typeof(T), s_defaultNamingPolicy);

        /// <summary>
        /// Builds a list of <see cref="SearchField"/> given a model type <typeparamref name="T"/> for use in a <see cref="SearchIndex"/>.
        /// By default, all public properties and fields of that model type will generate a <see cref="SearchField"/>;
        /// however, you can ignore them using <see cref="JsonIgnoreAttribute"/> or <see cref="NonSerializedAttribute"/>.
        /// You can further customize the generated <see cref="SearchField"/> using the
        /// <see cref="SimpleFieldAttribute"/> and <see cref="SearchableFieldAttribute"/> attributes.
        /// </summary>
        /// <typeparam name="T">The type of model from which to build fields.</typeparam>
        /// <param name="namingPolicy">
        /// The <see cref="JsonNamingPolicy"/> to use for converting property names if not already attributed with <see cref="JsonPropertyNameAttribute"/>.
        /// </param>
        /// <returns>A list of <see cref="SearchField"/> from model type <typeparamref name="T"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="namingPolicy"/> is null.</exception>
        public static IList<SearchField> Build<T>(JsonNamingPolicy namingPolicy) => Build(typeof(T), namingPolicy);

        /// <summary>
        /// Builds a list of <see cref="SearchField"/> given a model <paramref name="type"/> for use in a <see cref="SearchIndex"/>.
        /// By default, all public properties and fields of that model type will generate a <see cref="SearchField"/>;
        /// however, you can ignore them using <see cref="JsonIgnoreAttribute"/> or <see cref="NonSerializedAttribute"/>.
        /// You can further customize the generated <see cref="SearchField"/> using the
        /// <see cref="SimpleFieldAttribute"/> and <see cref="SearchableFieldAttribute"/> attributes.
        /// </summary>
        /// <param name="type">The type of model from which to build fields.</param>
        /// <returns>A list of <see cref="SearchField"/> from model <paramref name="type"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        public static IList<SearchField> Build(Type type) => Build(type, s_defaultNamingPolicy);

        /// <summary>
        /// Builds a list of <see cref="SearchField"/> given a model <paramref name="type"/> for use in a <see cref="SearchIndex"/>.
        /// By default, all public properties and fields of that model type will generate a <see cref="SearchField"/>;
        /// however, you can ignore them using <see cref="JsonIgnoreAttribute"/> or <see cref="NonSerializedAttribute"/>.
        /// You can further customize the generated <see cref="SearchField"/> using the
        /// <see cref="SimpleFieldAttribute"/> and <see cref="SearchableFieldAttribute"/> attributes.
        /// </summary>
        /// <param name="type">The type of model from which to build fields.</param>
        /// <param name="namingPolicy">
        /// The <see cref="JsonNamingPolicy"/> to use for converting property names if not already attributed with <see cref="JsonPropertyNameAttribute"/>.
        /// </param>
        /// <returns>A list of <see cref="SearchField"/> from model <paramref name="type"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> or <paramref name="namingPolicy"/> is null.</exception>
        public static IList<SearchField> Build(Type type, JsonNamingPolicy namingPolicy)
        {
            Argument.AssertNotNull(type, nameof(type));
            Argument.AssertNotNull(namingPolicy, nameof(namingPolicy));

            throw new NotImplementedException();
        }

        private class DefaultNamingPolicy : JsonNamingPolicy
        {
            /// <summary>
            /// Returns the <paramref name="name"/> as is.
            /// </summary>
            /// <param name="name">The property name to convert.</param>
            /// <returns>The <paramref name="name"/> as is.</returns>
            public override string ConvertName(string name) => name;
        }
    }
}
