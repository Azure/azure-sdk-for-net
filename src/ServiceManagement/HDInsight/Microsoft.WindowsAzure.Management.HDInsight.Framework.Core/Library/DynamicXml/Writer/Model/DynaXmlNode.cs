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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer.Model
{
    using System.Collections.Generic;

    internal enum DynaXmlNodeType
    {
        Attribute,
        CData,
        Text,
        Element,
        Document
    }

    internal abstract class DynaXmlNode
    {
        public string XmlNamespace { get; set; }

        public string Prefix { get; set; }

        public string LocalName { get; set; }

        public string Value;

        public DynaXmlNode()
        {
            this.Items = new List<DynaXmlNode>();
        }

        public ICollection<DynaXmlNode> Items { get; private set; }

        public abstract DynaXmlNodeType NodeType { get; }
    }
}
