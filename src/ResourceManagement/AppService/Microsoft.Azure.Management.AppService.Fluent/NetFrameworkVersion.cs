// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for NetFrameworkVersion.
    /// </summary>
    public partial class NetFrameworkVersion
    {
        public static readonly NetFrameworkVersion V3_0 = new NetFrameworkVersion("v3.0");
        public static readonly NetFrameworkVersion V4_6 = new NetFrameworkVersion("v4.6");

        private string value;

        /// <summary>
        /// Creates a custom value for NetFrameworkVersion.
        /// </summary>
        /// <param name="version">the version value</param>
        public NetFrameworkVersion(string version)
        {
            this.value = version;
        }
        
        public override string ToString()
        {
            return this.value;
        }

        public override bool Equals(object obj)
        {

            string value = this.ToString();
            if (!(obj is NetFrameworkVersion))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            NetFrameworkVersion rhs = (NetFrameworkVersion) obj;
            if (value == null)
            {
                return rhs.value == null;
            }
            return value.Equals(rhs.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
