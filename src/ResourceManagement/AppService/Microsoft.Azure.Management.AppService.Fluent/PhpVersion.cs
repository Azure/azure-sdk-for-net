// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for PhpVersion.
    /// </summary>
    public partial class PhpVersion
    {
        public static readonly PhpVersion Off = new PhpVersion("null");
        public static readonly PhpVersion Php5_5 = new PhpVersion("5.5");
        public static readonly PhpVersion Php5_6 = new PhpVersion("5.6");
        public static readonly PhpVersion Php7 = new PhpVersion("7.0");

        private string value;

        /// <summary>
        /// Creates a custom value for PhpVersion.
        /// </summary>
        /// <param name="version">the version value</param>
        public PhpVersion(string version)
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
            if (!(obj is PhpVersion))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            PhpVersion rhs = (PhpVersion) obj;
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
