// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Traffic manager profile statuses.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlByb2ZpbGVNb25pdG9yU3RhdHVz
    public partial class ProfileMonitorStatus 
    {
        public static readonly ProfileMonitorStatus INACTIVE = new ProfileMonitorStatus("Inactive");
        public static readonly ProfileMonitorStatus DISABLED = new ProfileMonitorStatus("Disabled");
        public static readonly ProfileMonitorStatus ONLINE = new ProfileMonitorStatus("Online");
        public static readonly ProfileMonitorStatus DEGRADED = new ProfileMonitorStatus("Degraded");
        public static readonly ProfileMonitorStatus CHECKING_ENDPOINT = new ProfileMonitorStatus("CheckingEndpoint");

        private string value;
        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(ProfileMonitorStatus lhs, ProfileMonitorStatus rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ProfileMonitorStatus lhs, ProfileMonitorStatus rhs)
        {
            return !(lhs == rhs);
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:319A6E227FE22BF7E76C696222460DDE
        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is ProfileMonitorStatus))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            ProfileMonitorStatus rhs = (ProfileMonitorStatus)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        /// <summary>
        /// Creates ProfileMonitorStatus.
        /// </summary>
        /// <param name="value">The status.</param>
        ///GENMHASH:ECD4398EA2EC7FEB4CC1A0B1DD1DE3CF:030291F3BFD74EABE095743C12CD3AEA
        public  ProfileMonitorStatus(string value)
        {
            this.value = value;
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:2C26F6EDF15B8D7739B8CA1E43BCDCEA
        public override string ToString()
        {
            return this.value;
        }
    }
}