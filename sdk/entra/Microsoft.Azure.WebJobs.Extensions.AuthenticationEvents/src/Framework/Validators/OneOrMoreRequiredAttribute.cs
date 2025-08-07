// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Validator to ensure that a type value is enumerable and contains at least one item.</summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class OneOrMoreRequiredAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="OneOrMoreRequiredAttribute" /> class.</summary>
        public OneOrMoreRequiredAttribute()
            : base(AuthenticationEventResource.Ex_No_Action)
        {
        }

        /// <summary>Returns true if the value is not null, is IEnumerable and contains at lease one item.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            return value is not null
                && value is IEnumerable<object> obj
                && obj.Any();
        }
    }
}
