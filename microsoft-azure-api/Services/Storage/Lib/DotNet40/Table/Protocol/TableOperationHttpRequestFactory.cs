namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Microsoft.Data.OData;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal class TableOperationHttpWebRequestFactory
    {
        internal static HttpWebRequest BuildRequestCore(Uri uri, UriQueryBuilder builder, string method, int? timeout, OperationContext ctx)
        {
            HttpWebRequest msg = HttpWebRequestFactory.CreateWebRequest(method, uri, timeout, builder, ctx);
            msg.Accept = "application/atom+xml,application/xml";
            msg.Headers.Add("Accept-Charset", "UTF-8");
            msg.Headers.Add("MaxDataServiceVersion", "2.0;NetFx");

            return msg;
        }

        internal static HttpWebRequest BuildRequestForTableQuery(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext ctx)
        {
            HttpWebRequest msg = BuildRequestCore(uri, builder, "GET", timeout, ctx);

            return msg;
        }

        internal static Tuple<HttpWebRequest, Stream> BuildRequestForTableOperation(Uri uri, UriQueryBuilder builder, int? timeout, TableOperation operation, OperationContext ctx)
        {
            HttpWebRequest msg = BuildRequestCore(uri, builder, operation.HttpMethod, timeout, ctx);

            if (operation.OperationType == TableOperationType.InsertOrMerge || operation.OperationType == TableOperationType.Merge)
            {
                // post tunnelling
                msg.Headers.Add("X-HTTP-Method", "MERGE");
            }

            // etag
            if (operation.OperationType == TableOperationType.Delete ||
                operation.OperationType == TableOperationType.Replace ||
                operation.OperationType == TableOperationType.Merge)
            {
                msg.Headers.Add("If-Match", operation.Entity.ETag);
            }

            if (operation.OperationType == TableOperationType.Insert ||
                operation.OperationType == TableOperationType.Merge ||
                operation.OperationType == TableOperationType.InsertOrMerge ||
                operation.OperationType == TableOperationType.InsertOrReplace ||
                operation.OperationType == TableOperationType.Replace)
            {
                // create the writer, indent for readability of the examples.  
                ODataMessageWriterSettings writerSettings = new ODataMessageWriterSettings()
                {
                    CheckCharacters = false,   // sets this flag on the XmlWriter for ATOM  
                    Version = ODataVersion.V2 // set the Odata version to use when writing the entry 
                };

                HttpWebRequestAdapterMessage adapterMsg = new HttpWebRequestAdapterMessage(msg);
                ODataMessageWriter odataWriter = new ODataMessageWriter(adapterMsg, writerSettings);
                ODataWriter writer = odataWriter.CreateODataEntryWriter();
                WriteOdataEntity(operation.Entity, operation.OperationType, ctx, writer);

                return new Tuple<HttpWebRequest, Stream>(adapterMsg.GetPopulatedMessage(), adapterMsg.GetStream());
            }

            return new Tuple<HttpWebRequest, Stream>(msg, null);
        }

        internal static Tuple<HttpWebRequest, Stream> BuildRequestForTableBatchOperation(Uri uri, UriQueryBuilder builder, int? timeout, Uri baseUri, string tableName, TableBatchOperation batch, OperationContext ctx)
        {
            HttpWebRequest msg = BuildRequestCore(NavigationHelper.AppendPathToUri(uri, "$batch"), builder, "POST", timeout, ctx);

            // create the writer, indent for readability of the examples.  
            ODataMessageWriterSettings writerSettings = new ODataMessageWriterSettings()
            {
                CheckCharacters = false,   // sets this flag on the XmlWriter for ATOM  
                Version = ODataVersion.V2 // set the Odata version to use when writing the entry 
            };

            HttpWebRequestAdapterMessage adapterMsg = new HttpWebRequestAdapterMessage(msg);

            // Start Batch
            ODataMessageWriter odataWriter = new ODataMessageWriter(adapterMsg, writerSettings);
            ODataBatchWriter batchWriter = odataWriter.CreateODataBatchWriter();
            batchWriter.WriteStartBatch();

            bool isQuery = batch.Count == 1 && batch[0].OperationType == TableOperationType.Retrieve;

            // Query operations should not be inside changeset in payload
            if (!isQuery)
            {
                // Start Operation
                batchWriter.WriteStartChangeset();
                batchWriter.Flush();
            }

            foreach (TableOperation operation in batch)
            {
                string httpMethod = operation.OperationType == TableOperationType.Merge || operation.OperationType == TableOperationType.InsertOrMerge ? "MERGE" : operation.HttpMethod;

                ODataBatchOperationRequestMessage mimePartMsg = batchWriter.CreateOperationRequestMessage(httpMethod, operation.GenerateRequestURI(baseUri, tableName));

                // etag
                if (operation.OperationType == TableOperationType.Delete ||
                    operation.OperationType == TableOperationType.Replace ||
                    operation.OperationType == TableOperationType.Merge)
                {
                    mimePartMsg.SetHeader("If-Match", operation.Entity.ETag);
                }

                if (operation.OperationType != TableOperationType.Delete && operation.OperationType != TableOperationType.Retrieve)
                {
                    using (ODataMessageWriter batchEntryWriter = new ODataMessageWriter(mimePartMsg, writerSettings))
                    {
                        // Write entity
                        ODataWriter entryWriter = batchEntryWriter.CreateODataEntryWriter();
                        WriteOdataEntity(operation.Entity, operation.OperationType, ctx, entryWriter);
                    }
                }
            }

            if (!isQuery)
            {
                // End Operation
                batchWriter.WriteEndChangeset();
            }

            // End Batch
            batchWriter.WriteEndBatch();
            batchWriter.Flush();

            return new Tuple<HttpWebRequest, Stream>(adapterMsg.GetPopulatedMessage(), adapterMsg.GetStream());
        }

        private static void WriteOdataEntity(ITableEntity entity, TableOperationType operationType, OperationContext ctx, ODataWriter writer)
        {
            ODataEntry entry = new ODataEntry()
            {
                Properties = GetPropertiesWithKeys(entity, ctx)
            };

            if (operationType != TableOperationType.Insert && operationType != TableOperationType.Retrieve)
            {
                entry.ETag = entity.ETag;
            }

            writer.WriteStart(entry);
            writer.WriteEnd();
            writer.Flush();
        }

        #region TableEntity Serialization Helpers

        internal static List<ODataProperty> GetPropertiesFromDictionary(IDictionary<string, EntityProperty> properties)
        {
            return properties.Select(kvp => new ODataProperty() { Name = kvp.Key, Value = kvp.Value.PropertyAsObject }).ToList();
        }

        internal static List<ODataProperty> GetPropertiesWithKeys(ITableEntity entity, OperationContext operationContext)
        {
            List<ODataProperty> retProps = GetPropertiesFromDictionary(entity.WriteEntity(operationContext));

            if (entity.PartitionKey != null)
            {
                retProps.Add(new ODataProperty() { Name = TableConstants.PartitionKey, Value = entity.PartitionKey });
            }

            if (entity.RowKey != null)
            {
                retProps.Add(new ODataProperty() { Name = TableConstants.RowKey, Value = entity.RowKey });
            }

            return retProps;
        }
        #endregion
    }
}
