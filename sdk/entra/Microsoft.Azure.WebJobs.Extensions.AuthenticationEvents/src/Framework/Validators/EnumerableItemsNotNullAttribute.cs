// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Validator to ensure that a type value is enumerable and contains no null items.</summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class EnumerableItemsNotNullAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="EnumerableItemsNotNullAttribute" /> class.</summary>
        public EnumerableItemsNotNullAttribute()
            : base(AuthenticationEventResource.Ex_Null_Action_Items)
        {
        }

        /// <summary>Returns true if the value is not null, is IEnumerable and no items are null.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            return value is not null
                && value is IEnumerable<object> obj
                && !obj.Any(x => x == null);
        }
    }
}
