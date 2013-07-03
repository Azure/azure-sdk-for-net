// -----------------------------------------------------------------------------------------
// <copyright file="TableBehaviors.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Test.Network
{
    using Fiddler;
    using Microsoft.WindowsAzure.Test.Network.Behaviors;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    /// <summary>
    /// TableBehaviors contains behaviors for Azure Storage tables
    /// </summary>
    public static class TableBehaviors
    {
        private static readonly Regex tableNameRegex = new Regex(@"/Tables\('([^']+)'\)", RegexOptions.Compiled);

        /// <summary>
        /// CreateTableOk returns a behavior which causes all create requests for table traffic to return successfully.
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior CreateTableOk()
        {
            return TamperBehaviors.TamperAllRequestsIf(session => GetTableWithCode(session, 201), Selectors.IfPost().ForTableTraffic());
        }

        /// <summary>
        /// CreateTableOk returns a behavior which causes all GET requests for table creation traffic to return successfully.
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior GetTableOk()
        {
            return TamperBehaviors.TamperAllRequestsIf(session => GetTableWithCode(session, 200), Selectors.IfGet().ForTableTraffic());
        }

        /// <summary>
        /// CreateTableErrorTableAlreadyExists returns a behavior saying the request failed with 409 (conflict) and substatus of "already exists"
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior CreateTableErrorTableAlreadyExists()
        {
            return TamperBehaviors.TamperAllRequestsIf(
                session => CreateTableError(session, 409, "TableAlreadyExists", "The table specified already exists."),
                Selectors.IfPost().ForTableTraffic());
        }

        /// <summary>
        /// CreateTableErrorTableBeingDeleted returns a behavior saying the request failed with 409 (conflict) and substatus of "being deleted"
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior CreateTableErrorTableBeingDeleted()
        {
            return TamperBehaviors.TamperAllRequestsIf(
                session => CreateTableError(session, 409, "TableBeingDeleted", "The table specified is in the process of being deleted."),
                Selectors.IfPost().ForTableTraffic());
        }

        /// <summary>
        /// GetTableNotFound returns a behavior saying the request failed with 404 (not found)
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior GetTableNotFound()
        {
            return TamperBehaviors.TamperAllRequestsIf(
                session => CreateTableError(session, 404, "ResourceNotFound", "The specified resource does not exist."),
                Selectors.IfGet().ForTableTraffic());
        }

        /// <summary>
        /// EchoTableEntry echos back the contents that were sent to the server.
        /// </summary>
        /// <returns>A new behavior.</returns>
        public static ProxyBehavior EchoTableEntry()
        {
            return TamperBehaviors.TamperAllRequestsIf(EchoEntry, Selectors.IfPost().ForTableTraffic());
        }

        private static void EchoEntry(Session session)
        {
            Uri hostName = new Uri(string.Format("http://{0}/", session.oRequest["Host"]));
            Uri tableUrl = new Uri(session.fullUrl);
            string requestString = session.GetRequestBodyAsString();

            string timestamp = DateTime.UtcNow.ToString("o");
            string etag = string.Format("W/\"datetime'{0}'\"", Uri.EscapeDataString(timestamp));

            XElement request = XElement.Parse(requestString);

            request.SetAttributeValue(XNamespace.Xml + "base", hostName.AbsoluteUri);
            request.SetAttributeValue(TableConstants.Metadata + "etag", Uri.EscapeDataString(etag));

            string partitionKey = request.Descendants(TableConstants.OData + "PartitionKey").Single().Value;
            string rowKey = request.Descendants(TableConstants.OData + "RowKey").Single().Value;

            Uri entryUri = new Uri(string.Format(
                "{0}(PartitionKey='{1}',RowKey='{2}')",
                tableUrl.AbsoluteUri,
                Uri.EscapeUriString(partitionKey),
                Uri.EscapeUriString(rowKey)));

            XElement timestampElement = request.Descendants(TableConstants.OData + "Timestamp").Single();
            timestampElement.Value = timestamp;

            XElement updatedElement = request.Descendants(TableConstants.Atom + "updated").Single();
            updatedElement.Value = timestamp;

            XElement idElement = request.Descendants(TableConstants.Atom + "id").Single();
            idElement.Value = entryUri.AbsoluteUri;

            // Add link
            XElement linkElement = new XElement(
                TableConstants.Atom + "link",
                new XAttribute("rel", "edit"),
                new XAttribute("href", entryUri.PathAndQuery.Substring(1)));
            idElement.AddAfterSelf(linkElement);

            // Add category
            string accountName = hostName.Host.Substring(0, hostName.Host.IndexOf('.'));
            string categoryName = accountName + "." + tableUrl.PathAndQuery.Substring(1);
            idElement.AddAfterSelf(TableConstants.GetCategory(categoryName));

            // mark that we're going to tamper with it
            session.utilCreateResponseAndBypassServer();

            session.oResponse.headers = CreateResponseHeaders(entryUri.AbsoluteUri);
            session.oResponse.headers["ETag"] = etag;

            session.responseCode = 201;

            string responseString = request.ToString();
            session.utilSetResponseBody(responseString);
        }

        /// <summary>
        /// GetTableWithCode tampers with with the request to return the specific table and a success code.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="statusCode"></param>
        private static void GetTableWithCode(Session session, int statusCode)
        {
            // Find relevant facts about this table creation.
            Uri hostName = new Uri(string.Format("http://{0}/", session.oRequest["Host"]));
            string requestString = session.GetRequestBodyAsString();

            string tableName = null;
            string tableUri = null;
            if (string.IsNullOrEmpty(requestString))
            {
                tableName = tableNameRegex.Match(session.url).Groups[1].Value;
            }
            else
            {
                XElement request = XElement.Parse(requestString);
                tableName = request.Descendants(TableConstants.OData + "TableName").Single().Value;
                tableUri = new Uri(hostName, string.Format("/Tables('{0}')", tableName)).AbsoluteUri;
            }

            // mark that we're going to tamper with it
            session.utilCreateResponseAndBypassServer();

            session.oResponse.headers = CreateResponseHeaders(tableUri);
            session.responseCode = statusCode;

            // Create the response XML
            XElement response = TableConstants.GetEntry(hostName.AbsoluteUri);

            response.Add(new XElement(TableConstants.Atom + "id", session.fullUrl));
            response.Add(new XElement(TableConstants.Title));
            response.Add(new XElement(TableConstants.Atom + "updated", DateTime.UtcNow.ToString("o")));
            response.Add(TableConstants.Author);

            response.Add(TableConstants.GetLink(tableName));

            string accountName = hostName.Host.Substring(0, hostName.Host.IndexOf('.'));
            response.Add(TableConstants.GetCategory(accountName + ".Tables"));

            // Add in the most important part -- the table name.
            response.Add(new XElement(
                TableConstants.Atom + "content",
                new XAttribute("type", "application/xml"),
                new XElement(
                    TableConstants.Metadata + "properties",
                    new XElement(
                        TableConstants.OData + "TableName",
                        tableName))));

            string responseString = response.ToString();
            session.utilSetResponseBody(responseString);
        }

        /// <summary>
        /// CreateTableError creates an error response from a table API.
        /// </summary>
        /// <param name="session">The session with which to tamper.</param>
        /// <param name="statusCode">The error code to return</param>
        /// <param name="messageCode">The string name for the error</param>
        /// <param name="message">The long error message to be returned.</param>
        private static void CreateTableError(Session session, int statusCode, string messageCode, string message)
        {
            session.utilCreateResponseAndBypassServer();
            session.oResponse.headers = CreateResponseHeaders(null);
            session.responseCode = statusCode;

            session.utilSetResponseBody(
                TableConstants.GetError(
                    messageCode,
                    string.Format(
                        "{0}\r\nRequestId:{1}\r\nTime:{2}",
                        message,
                        Guid.Empty.ToString(),
                        DateTime.UtcNow.ToString("o"))).ToString());
        }

        /// <summary>
        /// CreateResponseHeaders returns a set of common response headers.
        /// </summary>
        /// <param name="tableUri">The table URI to include in the Location header. Null of empty if no location.</param>
        /// <returns></returns>
        private static HTTPResponseHeaders CreateResponseHeaders(string tableUri)
        {
            HTTPResponseHeaders headers = new HTTPResponseHeaders();
            headers["Transfer-Encoding"] = "chunked";
            headers["Date"] = DateTime.UtcNow.ToString("R");
            headers["Cache-Control"] = "no-cache";

            if (!string.IsNullOrEmpty(tableUri))
            {
                headers["Location"] = tableUri;
            }

            headers["Content-Type"] = "application/atom+xml;charset=utf-8";
            headers["x-ms-version"] = TableConstants.XMsVersion;
            headers["x-ms-request-id"] = Guid.Empty.ToString();

            return headers;
        }
    }
}
