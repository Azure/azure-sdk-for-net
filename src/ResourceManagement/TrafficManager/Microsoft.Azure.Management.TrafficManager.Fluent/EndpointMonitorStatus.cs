// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Traffic manager profile endpoint monitor statuses.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLkVuZHBvaW50TW9uaXRvclN0YXR1cw==
    internal partial class EndpointMonitorStatus 
    {
        public EndpointMonitorStatus INACTIVE;
        public EndpointMonitorStatus DISABLED;
        public EndpointMonitorStatus ONLINE;
        public EndpointMonitorStatus DEGRADED;
        public EndpointMonitorStatus CHECKING_ENDPOINT;
        public EndpointMonitorStatus STOPPED;
        private string value;
        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public int HashCode()
        {
            //$ return this.value.HashCode();

            return 0;
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:DD06768FCF4C921AC5D5390E4B7F4A1A
        public bool Equals(object obj)
        {
            //$ String value = this.ToString();
            //$ if (!(obj instanceof EndpointMonitorStatus)) {
            //$ return false;
            //$ }
            //$ if (obj == this) {
            //$ return true;
            //$ }
            //$ EndpointMonitorStatus rhs = (EndpointMonitorStatus) obj;
            //$ if (value == null) {
            //$ return rhs.Value == null;
            //$ } else {
            //$ return value.Equals(rhs.Value);
            //$ }

            return false;
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:2C26F6EDF15B8D7739B8CA1E43BCDCEA
        public string ToString()
        {
            //$ return this.value;

            return null;
        }

        /// <summary>
        /// Creates EndpointMonitorStatus.
        /// </summary>
        /// <param name="value">The status.</param>
        ///GENMHASH:99F38614EB8A7F23E88656112ADD42E8:030291F3BFD74EABE095743C12CD3AEA
        public  EndpointMonitorStatus(string value)
        {
            //$ this.value = value;
            //$ }

        }
    }
}