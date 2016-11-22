// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Target Azure resource types supported for an Azure endpoint in a traffic manager profile.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlRhcmdldEF6dXJlUmVzb3VyY2VUeXBl
    public partial class TargetAzureResourceType 
    {
        public static readonly TargetAzureResourceType PUBLICIP = new TargetAzureResourceType("Microsoft.Network", "publicIPAddresses");
        public static readonly TargetAzureResourceType WEBAPP = new TargetAzureResourceType("Microsoft.Web", "sites");
        public static readonly TargetAzureResourceType CLOUDSERVICE = new TargetAzureResourceType("Microsoft.ClassicCompute", "domainNames");

        private string value;
        /// <summary>
        /// Creates TargetAzureResourceType.
        /// </summary>
        /// <param name="resourceProviderName">The resource provider name.</param>
        /// <param name="resourceType">The resource type.</param>
        ///GENMHASH:3F9A7CADE1EFA3BBBF249B9C7356113B:F14AA826FEFD37AE04DE2B5628420CF8
        public  TargetAzureResourceType(string resourceProviderName, string resourceType)
        {
            this.value = resourceProviderName + "/" + resourceType;
        }

        ///GENMHASH:0A2A1204F2A167AF288B2FBF2A490437:7E40CAD8AD46FC64A58AAA73BDA0A301
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        ///GENMHASH:86E56D83C59D665A2120AFEA8D89804D:BAC300C10B6A36568C70A93CCBB9CC9A
        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is TargetAzureResourceType))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            TargetAzureResourceType rhs = (TargetAzureResourceType)obj;
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
    }
}