using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Services.AppAuthentication.Helpers
{
    internal class ValidationHelper
    {
        public static void ValidateResource(string resource)
        {
            if (!Regex.IsMatch(resource, @"^[0-9a-zA-Z-.:/]+$"))
            {
                throw new ArgumentException($"Resource {resource} is not in expected format. Only alphanumeric characters, [dot], [colon], [hyphen], and [forward slash] are allowed.");
            }
        }
    }
}
