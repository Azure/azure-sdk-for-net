// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators
{
    /// <summary>Validator to ensure that a type value is not null.</summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class NotNullAttribute : ValidationAttribute
    {
        /// <summary>Initializes a new instance of the <see cref="NotNullAttribute" /> class.</summary>
        public NotNullAttribute()
            : base(AuthenticationEventResource.Val_Non_Default)
        {
        }

        /// <summary>Returns true if the value is not null</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            return value is not null;
        }
    }
}
