// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for WebContainer.
    /// </summary>
    public partial class WebContainer
    {
        public static readonly WebContainer Tomcat_7_0_Newest = new WebContainer("Tomcat 7.0");
        public static readonly WebContainer Tomcat_7_0_50 = new WebContainer("Tomcat 7.0.50");
        public static readonly WebContainer Tomcat_7_0_62 = new WebContainer("Tomcat 7.0.62");
        public static readonly WebContainer Tomcat_8_0_Newest = new WebContainer("Tomcat 8.0");
        public static readonly WebContainer Tomcat_8_0_23 = new WebContainer("Tomcat 8.0.23");
        public static readonly WebContainer Jetty_9_1_Newest = new WebContainer("Jetty 9.1");
        public static readonly WebContainer Jetty_9_1_V20131115 = new WebContainer("Jetty 9.1.0.20131115");

        private string value;

        /// <summary>
        /// Creates a custom value for WebContainer.
        /// </summary>
        /// <param name="container">the container value</param>
        public WebContainer(string container)
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
            if (!(obj is WebContainer))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            WebContainer rhs = (WebContainer) obj;
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
