// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Traffic manager profile statuses.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlByb2ZpbGVNb25pdG9yU3RhdHVz
    internal partial class ProfileMonitorStatus 
    {
        public ProfileMonitorStatus INACTIVE;
        public ProfileMonitorStatus DISABLED;
        public ProfileMonitorStatus ONLINE;
        public ProfileMonitorStatus DEGRADED;
        public ProfileMonitorStatus CHECKING_ENDPOINT;
        private string value;
        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public int HashCode()
        {
            //$ return this.value.HashCode();

            return 0;
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:319A6E227FE22BF7E76C696222460DDE
        public bool Equals(object obj)
        {
            //$ String value = this.ToString();
            //$ if (!(obj instanceof ProfileMonitorStatus)) {
            //$ return false;
            //$ }
            //$ if (obj == this) {
            //$ return true;
            //$ }
            //$ ProfileMonitorStatus rhs = (ProfileMonitorStatus) obj;
            //$ if (value == null) {
            //$ return rhs.Value == null;
            //$ } else {
            //$ return value.Equals(rhs.Value);
            //$ }

            return false;
        }

        /// <summary>
        /// Creates ProfileMonitorStatus.
        /// </summary>
        /// <param name="value">The status.</param>
        ///GENMHASH:ECD4398EA2EC7FEB4CC1A0B1DD1DE3CF:030291F3BFD74EABE095743C12CD3AEA
        public  ProfileMonitorStatus(string value)
        {
            //$ this.value = value;
            //$ }

        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:2C26F6EDF15B8D7739B8CA1E43BCDCEA
        public string ToString()
        {
            //$ return this.value;

            return null;
        }
    }
}