//-----------------------------------------------------------------------
// <copyright file="BlobRequest.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Provides a set of helper methods for constructing a request against the Blob service.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
        static class BlobRequest
    {
        /// <summary>
        /// Converts the date time to snapshot string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The converted string.</returns>
        internal static string ConvertDateTimeToSnapshotString(DateTimeOffset dateTime)
        {
            return dateTime.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff'Z'", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        public static void WriteSharedAccessIdentifiers(SharedAccessBlobPolicies sharedAccessPolicies, Stream outputStream)
        {
            Request.WriteSharedAccessIdentifiers(
                sharedAccessPolicies,
                outputStream,
                (policy, writer) =>
                {
                    writer.WriteElementString(
                        Constants.Start,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessStartTime));
                    writer.WriteElementString(
                        Constants.Expiry,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessExpiryTime));
                    writer.WriteElementString(
                        Constants.Permission,
                        SharedAccessBlobPolicy.PermissionsToString(policy.Permissions));
                });
        }

        /// <summary>
        /// Writes the body of the block list to the specified stream in XML format.
        /// </summary>
        /// <param name="blocks">An enumerable collection of <see cref="PutBlockListItem"/> objects.</param>
        /// <param name="outputStream">The stream to which the block list is written.</param>
        public static void WriteBlockListBody(IEnumerable<PutBlockListItem> blocks, Stream outputStream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                writer.WriteStartElement(Constants.BlockListElement);

                foreach (var block in blocks)
                {
                    if (block.SearchMode == BlockSearchMode.Committed)
                    {
                        writer.WriteElementString(Constants.CommittedElement, block.Id);
                    }
                    else if (block.SearchMode == BlockSearchMode.Uncommitted)
                    {
                        writer.WriteElementString(Constants.UncommittedElement, block.Id);
                    }
                    else if (block.SearchMode == BlockSearchMode.Latest)
                    {
                        writer.WriteElementString(Constants.LatestElement, block.Id);
                    }
                }

                writer.WriteEndDocument();
            }
        }
    }
}
