// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Certificates
{
    public class Issuer : IssuerBase
    {
        public static string Self => "self";
        public static string Unknown => "unknown";

        public string AccountId { get; set; }
        public string Password { get; set; }
        public string OrganizationId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
