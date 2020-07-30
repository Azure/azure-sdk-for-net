// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.Storage;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public static class StorageExceptionFactory
    {
        public static StorageException Create(int httpStatusCode)
        {
            return Create(httpStatusCode, new XElement("Error", String.Empty));
        }

        public static StorageException Create(int httpStatusCode, string errorCode)
        {
            return Create(httpStatusCode, new XElement("Error", new XElement("Code", errorCode)));
        }

        private static StorageException Create(int httpStatusCode, XElement extendedErrorElement)
        {
            // Unfortunately, the RequestResult properties are all internal-only settable. ReadXml is the only way to
            // create a populated RequestResult instance.

            XElement requestResultElement = new XElement("RequestResult",
                new XElement("HTTPStatusCode", httpStatusCode),
                new XElement("HttpStatusMessage"),
                new XElement("TargetLocation"),
                new XElement("ServiceRequestID"),
                new XElement("ContentMd5"),
                new XElement("ContentCrc64"),
                new XElement("Etag"),
                new XElement("RequestDate"),
                new XElement("ErrorCode"),
                new XElement("StartTime", DateTime.Now),
                new XElement("EndTime", DateTime.Now),
                extendedErrorElement);

            RequestResult result = new RequestResult();

            using (var stringReader = new StringReader(requestResultElement.ToString()))
#pragma warning disable CA3075 // Insecure DTD processing in XML
            using (var reader = XmlReader.Create(stringReader, new XmlReaderSettings { Async = true }))
#pragma warning restore CA3075 // Insecure DTD processing in XML
            {
                result.ReadXmlAsync(reader).Wait();
            }

            return new StorageException(result, null, null);
        }
    }
}
