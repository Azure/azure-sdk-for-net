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
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer
{
    /// <summary>
    ///     Provides an enumeration that describes what state the builder is in.
    /// </summary>
    internal enum DynaXmlBuilderState
    {
        /// <summary>
        ///     The builder is working on building a list of child elements.
        /// </summary>
        ElementListBuilder,

        /// <summary>
        /// The next input should be interpreted as a literal element.
        /// </summary>
        LiteralElementBuilder,

        /// <summary>
        ///     The builder is working on building a namespace node.
        /// </summary>
        NamespaceBuilder,

        /// <summary>
        ///     The builder is working on building an attribute node.
        /// </summary>
        AttributeBuilder,

        /// <summary>
        /// The builder is working on a list of attributes.
        /// </summary>
        AttributeListBuilder,

        /// <summary>
        /// The next input should be interpreted as a literal attribute.
        /// </summary>
        LiteralAttributeBuilder
    }
}