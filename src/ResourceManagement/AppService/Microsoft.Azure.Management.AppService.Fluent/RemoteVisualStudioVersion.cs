// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for RemoteVisualStudioVersion.
    /// </summary>
    public partial class RemoteVisualStudioVersion
    {
        public static readonly RemoteVisualStudioVersion VS2012 = new RemoteVisualStudioVersion("VS2012");
        public static readonly RemoteVisualStudioVersion VS2013 = new RemoteVisualStudioVersion("VS2013");
        public static readonly RemoteVisualStudioVersion VS2015 = new RemoteVisualStudioVersion("VS2015");

        private string value;

        /// <summary>
        /// Creates a custom value for RemoteVisualStudioVersion.
        /// </summary>
        /// <param name="version">the version value</param>
        public RemoteVisualStudioVersion(string version)
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
            if (!(obj is RemoteVisualStudioVersion))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            RemoteVisualStudioVersion rhs = (RemoteVisualStudioVersion) obj;
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
