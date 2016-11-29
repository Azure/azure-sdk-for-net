// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// The reason for unavailability of traffic manager profile DNS name.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlByb2ZpbGVEbnNOYW1lVW5hdmFpbGFibGVSZWFzb24=
    public partial class ProfileDnsNameUnavailableReason 
    {
        public static readonly ProfileDnsNameUnavailableReason INVALID = new ProfileDnsNameUnavailableReason("Invalid");
        public static readonly ProfileDnsNameUnavailableReason ALREADYEXISTS = new ProfileDnsNameUnavailableReason("AlreadyExists");

        private string value;

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:FEFD3C99C3C033AAC13E84482C543367
        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is ProfileDnsNameUnavailableReason))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            ProfileDnsNameUnavailableReason rhs = (ProfileDnsNameUnavailableReason)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:2C26F6EDF15B8D7739B8CA1E43BCDCEA
        public override string ToString()
        {
            return this.value;
        }

        /// <summary>
        /// Creates ProfileDnsNameUnavailableReason.
        /// </summary>
        /// <param name="value">The reason.</param>
        ///GENMHASH:B4E5B9E5C1234A0BC22C0581DC36CF3E:030291F3BFD74EABE095743C12CD3AEA
        public  ProfileDnsNameUnavailableReason(string value)
        {
            this.value = value;
        }
    }
}