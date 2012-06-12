using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Linq;
#if DEBUG
using System.Collections;
using System.Diagnostics;
using System.Reflection;
#endif
namespace Windows.Azure.Management
{
    [DataContract]
    public abstract class AzureDataContractBase : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData
        {
            get;
            set;
        }

        public override string ToString()
        {
            return ToStringWorker(this);
        }

        //made this internal static so it can be called from
        //the CollectionDataContracts too.
        internal static String ToStringWorker(object thisObj)
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
            ExtensionDataObject ext = this.ExtensionData;

            try{
                if (ext != null)
                {
                    FieldInfo info = ext.GetType().GetField("members", BindingFlags.Instance | BindingFlags.NonPublic);
                    IList value = (IList)info.GetValue(ext);

                    if (value != null)
                    {
                        Debug.WriteLine(String.Format("Object of type {0} has Extension Data.", this.GetType().ToString()));

                        foreach (object o in value)
                        {
                            FieldInfo nameInfo = o.GetType().GetField("name", BindingFlags.Instance | BindingFlags.NonPublic);
                            String name = (String)nameInfo.GetValue(o);
                            Debug.WriteLine(String.Format("\tProperty Found of Name: {0}", name));
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
