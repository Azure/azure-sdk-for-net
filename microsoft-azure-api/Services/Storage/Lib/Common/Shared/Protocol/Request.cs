// -----------------------------------------------------------------------------------------
// <copyright file="Request.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;

    internal static class Request
    {
        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        /// <param name="writePolicyXml">A delegate that writes a policy to an XML writer.</param>
        /// <typeparam name="T">The type of policy to write.</typeparam>
        internal static void WriteSharedAccessIdentifiers<T>(IDictionary<string, T> sharedAccessPolicies, Stream outputStream, Action<T, XmlWriter> writePolicyXml)
        {
            CommonUtility.AssertNotNull("sharedAccessPolicies", sharedAccessPolicies);
            CommonUtility.AssertNotNull("outputStream", outputStream);

            if (sharedAccessPolicies.Count > Constants.MaxSharedAccessPolicyIdentifiers)
            {
                string errorMessage = string.Format(
                    CultureInfo.CurrentCulture,
                    SR.TooManyPolicyIdentifiers,
                    sharedAccessPolicies.Count,
                    Constants.MaxSharedAccessPolicyIdentifiers);

                throw new ArgumentOutOfRangeException("sharedAccessPolicies", errorMessage);
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                writer.WriteStartElement(Constants.SignedIdentifiers);

                foreach (string key in sharedAccessPolicies.Keys)
                {
                    writer.WriteStartElement(Constants.SignedIdentifier);

                    // Set the identifier
                    writer.WriteElementString(Constants.Id, key);

                    // Set the permissions
                    writer.WriteStartElement(Constants.AccessPolicy);

                    T policy = sharedAccessPolicies[key];

                    writePolicyXml(policy, writer);

                    writer.WriteEndElement(); // AccessPolicy
                    writer.WriteEndElement(); // SignedIdentifier
                }

                writer.WriteEndDocument();
            }
        }
    }
}
