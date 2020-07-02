// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Indicates whether the field can be returned in a search result. This
    /// defaults to true, so this attribute only has any effect if you use it
    /// as [IsRetrievable(false)].
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsRetrievableAttribute : Attribute
    {
        /// <summary>
        /// Indicates that the specified value should be used to negate the <see cref="SearchField.IsHidden"/>
        /// flag of the target field.
        /// </summary>
        /// <param name="isRetrievable"><c>true</c> if the target field should be included in
        /// search results, <c>false</c> otherwise.</param>
        public IsRetrievableAttribute(bool isRetrievable)
        {
            IsRetrievable = isRetrievable;
        }

        /// <summary>
        /// <c>true</c> if the target field should be included in search results, <c>false</c> otherwise.
        /// </summary>
        public bool IsRetrievable { get; }
    }
}
