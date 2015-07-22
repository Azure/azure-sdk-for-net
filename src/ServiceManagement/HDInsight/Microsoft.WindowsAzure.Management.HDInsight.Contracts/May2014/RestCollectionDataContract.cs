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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    [CollectionDataContract(Namespace = Constants.HdInsightManagementNamespace)]
    internal abstract class RestCollectionDataContract<TU> : List<TU>, IExtensibleDataObject
        where TU : RestDataContract
    {
        protected RestCollectionDataContract(IEnumerable<TU> listOfElements)
            : base(listOfElements)
        {
        }

        /// <summary>
        /// Default Serialization length is 1024, which is small for windows azure REST calls.
        /// </summary>
        private const int MaxDeserializationStringLength = 1024 * 1024;

        /// <summary>
        /// Deserializes and creates a new instance of <typeparamref name="T" /> from the specified stream.
        /// </summary>
        /// <typeparam name="T">Type of the object to create. This must inherit from <see cref="RestDataContract" />.</typeparam>
        /// <typeparam name="U">Type of the object to create.</typeparam>
        /// <param name="stream">The stream.</param>
        /// <returns>
        /// An instance of.<typeparamref name="T" />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">The stream.</exception>
        public static T Deserialize<T, U>(Stream stream)
            where T : RestCollectionDataContract<U>
            where U : RestDataContract
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            XmlDictionaryReaderQuotas xmlDictionaryQuotas = new XmlDictionaryReaderQuotas();
            xmlDictionaryQuotas.MaxStringContentLength = MaxDeserializationStringLength;
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(stream, xmlDictionaryQuotas))
            {
                return (T)serializer.ReadObject(reader);
            }
        }

        /// <summary>
        /// Deserializes and creates a new instance of <typeparamref name="T" /> from the specified UTF8 XML string.
        /// </summary>
        /// <typeparam name="T">Type of the object to create. This must inherit from RestDataContract.</typeparam>
        /// <typeparam name="U">Type of the object to create.</typeparam>
        /// <param name="utf8XmlString">The UTF8 XML string.</param>
        /// <returns>
        /// An instance of.<typeparamref name="T" />
        /// </returns>
        /// <exception cref="System.ArgumentException">Cannot be null or empty;utf8XmlString.</exception>
        public static T Deserialize<T, U>(string utf8XmlString)
            where T : RestCollectionDataContract<U>
            where U : RestDataContract
        {
            if (string.IsNullOrEmpty(utf8XmlString))
            {
                throw new ArgumentException("Cannot be null or empty", "utf8XmlString");
            }

            using (Stream memStr = new MemoryStream(Encoding.UTF8.GetBytes(utf8XmlString)))
            {
                return Deserialize<T, U>(memStr);
            }
        }

        protected RestCollectionDataContract()
        {
        }

        /// <summary>
        /// Serializes the and writes this object to the stream <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>Return serialized string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2202:Do not dispose objects multiple times", Justification = "Internal + done in base class.")]
        public string SerializeAndOptionallyWriteToStream(Stream stream)
        {
            using (stream = stream ?? new MemoryStream())
            {
                DataContractSerializer ser = new DataContractSerializer(GetType());
                XmlWriter streamWriter = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true });
                ser.WriteObject(streamWriter, this);

                using (MemoryStream memstr = new MemoryStream())
                {
                    using (XmlWriter writer = XmlWriter.Create(memstr, new XmlWriterSettings { Indent = true }))
                    {
                        ser.WriteObject(writer, this);
                        memstr.Position = 0;
                        using (StreamReader reader = new StreamReader(memstr))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the structure that contains extra data. Required for versioning.
        /// </summary>
        /// <returns>An <see cref="T:System.Runtime.Serialization.ExtensionDataObject"/> that contains data that is not recognized as belonging to the data contract.</returns>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}