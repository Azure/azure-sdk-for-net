// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Provides hard coded values to ensure type safety when interacting with key static values.
    /// </summary>
    internal static class HDInsightRestConstants
    {
        /// <summary>
        /// The X-ms-version Http Header.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "XMs", Justification = "Used to denote x-ms correct in this instance. [tgs]")]
        public static readonly KeyValuePair<string, string> XMsVersion = new KeyValuePair<string, string>("x-ms-version", "2012-08-01");

        /// <summary>
        /// The X-ms-version Http Header.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "XMs", Justification = "Used to denote x-ms correct in this instance. [tgs]")]
        public static readonly KeyValuePair<string, string> AsvXMsVersion = new KeyValuePair<string, string>("x-ms-version", "2011-08-18");

        /// <summary>
        /// An Http header denoting to use a different Schema version when communicating with the RDFE server.
        /// </summary>
        public static readonly KeyValuePair<string, string> SchemaVersion2 = new KeyValuePair<string, string>("schemaversion", "2.0");

        /// <summary>
        /// An Http header denoting to use a different Schema version when communicating with the RDFE server.
        /// </summary>
        public static readonly KeyValuePair<string, string> SchemaVersion3 = new KeyValuePair<string, string>("schemaversion", "3.0");
            
        /// <summary>
        /// The X-ms-version Http Header.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "XMs", Justification = "Used to denote x-ms correct in this instance. [tgs]")]
        public static readonly string XMsDate = "x-ms-date";

        /// <summary>
        /// The Accept Http Header.
        /// </summary>
        public static readonly KeyValuePair<string, string> Accept = new KeyValuePair<string, string>("accept", HttpConstants.ApplicationXml);

        /// <summary>
        /// The UserAgent Http Header.
        /// </summary>
        public static readonly KeyValuePair<string, string> UserAgent = new KeyValuePair<string, string>("useragent", "HDInsight .NET SDK");
    }
}
