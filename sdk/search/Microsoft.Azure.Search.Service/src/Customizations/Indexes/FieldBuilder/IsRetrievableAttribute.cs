// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.Search.Models;

namespace Microsoft.Azure.Search
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
        /// Indicates that the specified value should be used for the <see cref="Field.IsRetrievable" />
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
