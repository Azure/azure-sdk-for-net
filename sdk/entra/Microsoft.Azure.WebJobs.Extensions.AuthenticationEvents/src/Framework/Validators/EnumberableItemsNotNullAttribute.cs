// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators
{
    /// <summary>Validator to ensure that a type value is enumerable and contains no null items.</summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    internal class EnumberableItemsNotNullAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="EnumberableItemsNotNullAttribute" /> class.</summary>
        public EnumberableItemsNotNullAttribute()
            : base(AuthenticationEventResource.Ex_No_Action)
        {
        }

        /// <summary>Returns true if the value is not null, is IEnumerable and no items are null.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value is null
                || value is not IEnumerable
                || (value as IEnumerable<object>).Where(x => x == null).Any())
            {
                return false;
            }
            return true;
        }
    }
}
