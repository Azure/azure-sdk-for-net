// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Builds a list of <see cref="SearchField"/> given a model type <typeparamref name="T"/> for use in a <see cref="SearchIndex"/>.
        /// By default, all public properties and fields of that model type will generate a <see cref="SearchField"/>;
        /// however, you can ignore them using <see cref="JsonIgnoreAttribute"/> or <see cref="NonSerializedAttribute"/>.
        /// You can further customize the generated <see cref="SearchField"/> using the
        /// <see cref="SimpleFieldAttribute"/> and <see cref="SearchableFieldAttribute"/> attributes.
        /// </summary>
        /// <typeparam name="T">The type of model from which to build fields.</typeparam>
        /// <returns>A list of <see cref="SearchField"/> from model type <typeparamref name="T"/>.</returns>
        public static IList<SearchField> Build<T>() => Build(typeof(T));

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
        public static IList<SearchField> Build(Type type)
        {
            Argument.AssertNotNull(type, nameof(type));

            throw new NotImplementedException();
        }

        // TODO: Add overloads taking a JsonNamingPolicy or whatever on which we standardize later.
    }
}
