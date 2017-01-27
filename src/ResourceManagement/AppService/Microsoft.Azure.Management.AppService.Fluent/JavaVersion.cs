// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for JavaVersion.
    /// </summary>
    public partial class JavaVersion
    {
        public static readonly JavaVersion Off = new JavaVersion("null");
        public static readonly JavaVersion V7Newest = new JavaVersion("1.7");
        public static readonly JavaVersion V7_51 = new JavaVersion("1.7.0_51");
        public static readonly JavaVersion V7_71 = new JavaVersion("1.7.0_71");
        public static readonly JavaVersion V8Newest = new JavaVersion("1.8");
        public static readonly JavaVersion V8_25 = new JavaVersion("1.8.0_25");
        public static readonly JavaVersion V8_60 = new JavaVersion("1.8.0_60");
        public static readonly JavaVersion V8_73 = new JavaVersion("1.8.0_73");
        public static readonly JavaVersion V8_92 = new JavaVersion("1.8.0_92");   

        private string value;

        /// <summary>
        /// Creates a custom value for JavaVersion.
        /// </summary>
        /// <param name="version">the version value</param>
        public JavaVersion(string version)
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
            if (!(obj is JavaVersion))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            JavaVersion rhs = (JavaVersion) obj;
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
