// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Possible endpoint types supported in a Traffic manager profile.
    /// </summary>
    public partial class EndpointType
    {
        public static readonly EndpointType AZURE = new EndpointType("Microsoft.Network/trafficManagerProfiles/azureEndpoints");
        public static readonly EndpointType EXTERNAL = new EndpointType("Microsoft.Network/trafficManagerProfiles/externalEndpoints");
        public static readonly EndpointType NESTED_PROFILE = new EndpointType("Microsoft.Network/trafficManagerProfiles/nestedEndpoints");

        private string value;

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public static bool operator ==(EndpointType lhs, EndpointType rhs)
        {
            if (object.ReferenceEquals(lhs, null))
            {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(EndpointType lhs, EndpointType rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is EndpointType))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            EndpointType rhs = (EndpointType)obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value, System.StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return this.value;
        }

        /// <summary>
        /// Creates EndpointType.
        /// </summary>
        /// <param name="value">The value.</param>
        public EndpointType(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the local name of the endpoint type.
        /// </summary>
        public string LocalName
        {
            get
            {
                if (this.value != null)
                {
                    return this.value.Substring(this.value.LastIndexOf('/') + 1);
                }
                return null;
            }
        }
    }
}