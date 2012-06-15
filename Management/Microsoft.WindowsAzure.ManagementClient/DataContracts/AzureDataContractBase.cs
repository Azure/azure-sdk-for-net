//-----------------------------------------------------------------------
// <copyright file="AzureDataContractBase.cs" company="Microsoft">
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
// <summary>
//    Contains code for the AzureDataContractBase class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Linq;
#if DEBUG
using System.Collections;
using System.Diagnostics;
using System.Reflection;
#endif

namespace Microsoft.WindowsAzure.ManagementClient
{
    /// <summary>
    /// Abstract base class for all data contracts in this assembly.
    /// It provides a standard implementation of 
    /// <see cref="IExtensibleDataObject" />,
    /// a standard override of <see cref="ToString()"/> and
    /// a Debug-only OnDeserialized method to catch members that are not being
    /// properly serialized.
    /// </summary>
    [DataContract]
    public abstract class AzureDataContractBase : IExtensibleDataObject
    {
        /// <summary>
        /// Implements <see cref="IExtensibleDataObject.ExtensionData"/>
        /// </summary>
        public ExtensionDataObject ExtensionData
        {
            get;
            set;
        }

        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return ToStringWorker(this);
        }

        //made this internal static so it can be called from
        //the CollectionDataContracts too.
        internal static string ToStringWorker(object thisObj)
        {
            DataContractSerializer serializer = new DataContractSerializer(thisObj.GetType());

            using(MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, thisObj);

                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                StreamReader reader = new StreamReader(stream);
                return XDocument.Parse(reader.ReadToEnd()).ToString();
            }
        }

#if DEBUG
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            ExtensionDataObject ext = ExtensionData;

            try{
                if (ext != null)
                {
                    FieldInfo info = ext.GetType().GetField("members", BindingFlags.Instance | BindingFlags.NonPublic);
                    IList value = (IList)info.GetValue(ext);

                    if (value != null)
                    {
                        Debug.WriteLine(string.Format("Object of type {0} has Extension Data.", this.GetType().ToString()));

                        foreach (object o in value)
                        {
                            FieldInfo nameInfo = o.GetType().GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
                            string name = (string)nameInfo.GetValue(o);
                            Debug.WriteLine(string.Format("\tProperty Found of Name: {0}", name));
                        }
                    }
                }
            }
            catch(Exception)
            {
                //just swallow everything, this is just for debugging
            }
        }
#endif
    }
}
