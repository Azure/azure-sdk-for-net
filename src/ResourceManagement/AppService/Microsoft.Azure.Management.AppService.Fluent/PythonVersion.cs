// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for PythonVersion.
    /// </summary>
    public partial class PythonVersion
    {
        public static readonly PythonVersion Off = new PythonVersion("null");
        public static readonly PythonVersion Python_27 = new PythonVersion("2.7");
        public static readonly PythonVersion Python_34 = new PythonVersion("3.4");

        private string value;

        /// <summary>
        /// Creates a custom value for PythonVersion.
        /// </summary>
        /// <param name="version">the version value</param>
        public PythonVersion(string version)
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
            if (!(obj is PythonVersion))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            PythonVersion rhs = (PythonVersion) obj;
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
