// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Xml;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    internal abstract class XmlTypeWriterBase<T>
    {
        private readonly string _elementName;

        protected XmlTypeWriterBase(string elementName)
        {
            _elementName = elementName;
        }

        public void Write(T entity, XmlWriter writer)
        {
            writer.WriteStartElement(_elementName);
            WriteAttributes(entity, writer);
            WriteContents(entity, writer);
            writer.WriteEndElement();
        }

        public void Write(IEnumerable<T> entities, XmlWriter writer)
        {
            foreach (var entity in entities)
            {
                Write(entity, writer);
            }
        }

        protected abstract void WriteAttributes(T entity, XmlWriter writer);
        protected virtual void WriteContents(T entity, XmlWriter writer) { }
    }
}
