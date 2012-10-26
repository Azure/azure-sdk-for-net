// -----------------------------------------------------------------------------------------
// <copyright file="Actions.cs" company="Microsoft">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;

namespace Microsoft.WindowsAzure.Test.Network
{
    /// <summary>
    /// Class to provide Actions for Storage Traffic
    /// </summary>
    public class Actions
    {
        /// <summary>
        /// Action to throttle a table request
        /// </summary>
        /// <returns>a Action to throttle the given request</returns>
        public static Action<Session> BreakSession = relevantSession =>
            {
                relevantSession["x-breakrequest"] = "breaking for abort";                
            };

        /// <summary>
        /// Action to throttle a table request
        /// </summary>
        public static Action<Session> ThrottleTableRequest = session =>
        {
            string payload = String.Format(TableErrorPayload, "ServerBusy", "The server is busy..", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("o"));
            session.oRequest.FailSession(503, "ServerBusy", payload);
        };

        /// <summary>
        /// Action to throttle a blob or queue request
        /// </summary>
        public static Action<Session> ThrottleBlobQueueRequest = session =>
        {
            string payload = String.Format(StorageErrorPayload, "ServerBusy", "The server is busy..", Guid.NewGuid().ToString(), DateTime.UtcNow.ToString("o"));
            session.oRequest.FailSession(503, "ServerBusy", payload);
        };

        /// <summary>
        /// String representing the Error Payload
        /// </summary>
        public static string TableErrorPayload = @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>" +
            @"<error xmlns=""http://schemas.microsoft.com/ado/2007/08/dataservices/metadata\"">" +
            "<code>{0}</code>\r\n" +
            @"<message xml:lang=""en-US"">" +
            "{1}\r\nRequestId:{2}\r\nTime:{3}</message>" +
            "\r\n</error>";

        /// <summary>
        /// String representing the Blob and QUEUE Error Payload
        /// </summary>
        public static string StorageErrorPayload = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
            "<Error>\r\n" +
            "<Code>{0}</Code>\r\n" +
            "<Message>{1}\r\nRequestId:{2}\r\nTime:{3}</Message>\r\n" +
            "</Error>";
    }
}
