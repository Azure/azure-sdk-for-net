// -----------------------------------------------------------------------------------------
// <copyright file="QueueRequest.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.IO;
    using System.Text;
    using System.Xml;

#if RTMD
    internal
#else
    public
#endif
        static class QueueRequest
    {
        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        public static void WriteSharedAccessIdentifiers(SharedAccessQueuePolicies sharedAccessPolicies, Stream outputStream)
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
                        SharedAccessQueuePolicy.PermissionsToString(policy.Permissions));
                });
        }

        /// <summary>
        /// Writes a message to the specified stream in XML format.
        /// </summary>
        /// <param name="messageContent">The message body.</param>
        /// <param name="outputStream">An output stream.</param>
        internal static void WriteMessageContent(string messageContent, Stream outputStream)
        {
            CommonUtils.AssertNotNull("outputStream", outputStream);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.NewLineHandling = NewLineHandling.Entitize;

            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                writer.WriteStartElement(Constants.MessageElement);
                writer.WriteElementString(Constants.MessageTextElement, messageContent);
                writer.WriteEndDocument();
            }
        }
    }
}
