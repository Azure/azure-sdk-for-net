// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using Microsoft.Azure.Search.Models;

    /// <summary>
    /// Indicates whether the field can be returned in a search result. This
    /// defaults to true, so this attribute only has any effect if you use it
    /// as [IsRetrievable(false)].
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsRetrievableAttribute : Attribute
    {
        public IsRetrievableAttribute(bool isRetrievable)
        {
            IsRetrievable = isRetrievable;
        }

        public bool IsRetrievable { get; }
    }
}
