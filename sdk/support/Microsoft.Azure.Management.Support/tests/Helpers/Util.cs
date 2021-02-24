// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.Support.Tests.Helpers
{
    public class Util
    {
        public static Models.SupportTicketDetails CreateSupportTicketParametersObject(
            string serviceId,
            string problemClassificationId,
            string severity = "minimal",
            string title = "test ticket from sdk test. please ignore and close",
            string description = "test ticket from sdk test. please ignore and close",
            string firstName = "first name",
            string lastName = "last name",
            string preferredContactMethod = "email",
            string country = "usa",
            string preferredSupportLanguage = "en-us",
            string preferredTimeZone = "pacific standard time",
            string primaryEmailAddress = "user@contoso.com",
            string phoneNumber = null,
            List<string> additionalEmailAddresses = null) => new Models.SupportTicketDetails
            {
                ServiceId = serviceId,
                ProblemClassificationId = problemClassificationId,
                Severity = severity,
                Title = title,
                Description = description,
                ContactDetails = new Models.ContactProfile
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PreferredContactMethod = "Email",
                    Country = country,
                    PreferredSupportLanguage = preferredSupportLanguage,
                    PreferredTimeZone = preferredTimeZone,
                    PrimaryEmailAddress = primaryEmailAddress,
                    PhoneNumber = phoneNumber,
                    AdditionalEmailAddresses = additionalEmailAddresses
                }
            };
    }
}
