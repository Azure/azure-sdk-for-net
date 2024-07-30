// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Confirms that a field is set to one of the valid event identifiers.</summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    internal class AuthEventIdentifierAttribute : ValidationAttribute
    {
        private static string[] _eventIds;
        /// <summary>Gets the current registered event ids.
        /// (Lazy load).</summary>
        /// <value>The event ids.</value>
        internal static string[] EventIds
        {
            get
            {
                if (_eventIds == null)
                {
                    _eventIds = Enum.GetValues(typeof(WebJobsAuthenticationEventDefinition))
                        .Cast<WebJobsAuthenticationEventDefinition>()
                        .Select(x => x.GetAttribute<WebJobsAuthenticationEventMetadataAttribute>().EventIdentifier.ToLower(CultureInfo.CurrentCulture))
                        .ToArray();
                }

                return _eventIds;
            }
        }
        /// <summary>Applies formatting to an error message, based on the data field where the error occurred.</summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Val_One_Of, name) + string.Join(", ", EventIds);
        }

        /// <summary>Returns true if the value is a valid event identifier.</summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value is string val)
            {
                return EventIds.Contains(val.ToLower(CultureInfo.CurrentCulture));
            }

            return false;
        }
    }
}
