// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Validator to validated that a value is one of the the values in a list.</summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    internal class OneOfAttribute : ValidationAttribute
    {
        private readonly string[] _allowed;
        /// <summary>Initializes a new instance of the <see cref="OneOfAttribute" /> class.</summary>
        /// <param name="allowed">The allowed values.</param>
        internal OneOfAttribute(params string[] allowed) : base($"{AuthenticationEventResource.Val_One_Of} '{string.Join("' ,'", allowed)}'")
        {
            _allowed = allowed;
        }

        /// <summary>Returns true if the value is in the list of allowed values.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return value is string val && _allowed.Contains(val);
        }
    }
}
