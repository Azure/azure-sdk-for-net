// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Azure.Storage;

namespace FakeStorage
{
    internal static class StorageExceptionFactory
    {
        public static StorageException Create(int httpStatusCode)
        {
            return Create(httpStatusCode, new XElement("Error", String.Empty));
        }

        public static StorageException Create(int httpStatusCode, string errorCode)
        {
            return Create(httpStatusCode, new XElement("Error", new XElement("Code", errorCode)));
        }

        public static Microsoft.Azure.Cosmos.Table.StorageException CreateTableStorageException(int httpStatusCode, string errorCode)
        {
            var result = new Microsoft.Azure.Cosmos.Table.RequestResult();
            result.HttpStatusCode = httpStatusCode;

            var extendedInfo = Activator.CreateInstance<Microsoft.Azure.Cosmos.Table.StorageExtendedErrorInformation>();
            extendedInfo.SetInternalProperty("ErrorCode", errorCode);
            result.SetInternalProperty("ExtendedErrorInformation", extendedInfo);

            return new Microsoft.Azure.Cosmos.Table.StorageException(result, null, null);
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
            using (var reader = XmlReader.Create(stringReader, new XmlReaderSettings { Async = true }))            
            {
                result.ReadXmlAsync(reader).Wait();
            }

            return new StorageException(result, null, null);
        }
    }
}
