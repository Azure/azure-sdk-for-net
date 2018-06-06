using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Services.AppAuthentication
{
    internal class ValidationHelper
    {
        /// <summary>
        /// Validates a resource identifier. 
        /// </summary>
        /// <param name="resource">The resource to validate.</param>
        public static void ValidateResource(string resource)
        {
            if (!Regex.IsMatch(resource, @"^[0-9a-zA-Z-.:/]+$"))
            {
                throw new ArgumentException($"Resource {resource} is not in expected format. Only alphanumeric characters, [dot], [colon], [hyphen], and [forward slash] are allowed.");
            }
        }
    }
}
