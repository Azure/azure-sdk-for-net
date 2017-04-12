// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Defines values for WebContainer.
    /// </summary>
    public class WebContainer : ExpandableStringEnum<WebContainer>
    {
        public static readonly WebContainer Tomcat7_0Newest = Parse("Tomcat 7.0");
        public static readonly WebContainer Tomcat7_0_50 = Parse("Tomcat 7.0.50");
        public static readonly WebContainer Tomcat7_0_62 = Parse("Tomcat 7.0.62");
        public static readonly WebContainer Tomcat8_0Newest = Parse("Tomcat 8.0");
        public static readonly WebContainer Tomcat8_0_23 = Parse("Tomcat 8.0.23");
        public static readonly WebContainer Tomcat8_5Newest = Parse("Tomcat 8.5");
        public static readonly WebContainer Tomcat8_5_6 = Parse("Tomcat 8.5.6");
        public static readonly WebContainer Jetty9_1Newest = Parse("Jetty 9.1");
        public static readonly WebContainer Jetty9_1V20131115 = Parse("Jetty 9.1.0.20131115");
        public static readonly WebContainer Jetty9_3Newest = Parse("Jetty 9.3");
        public static readonly WebContainer Jetty9_3V20161014 = Parse("jetty 9.3.13.20161014");
    }
}
