// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Validator to ensure that a type value is not set to it's default value.</summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    internal class RequireNonDefaultAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="RequireNonDefaultAttribute" /> class.</summary>
        public RequireNonDefaultAttribute()
            : base(AuthenticationEventResource.Val_Non_Default)
        {
        }

        /// <summary>Returns true if the value is not set to it's default value.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }

            if (value is IEnumerable)//We don't look for defaults values in enumerables.
            {
                return true;
            }
            else
            {
                var type = value.GetType();
                return !Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type));
            }
        }
    }
}
