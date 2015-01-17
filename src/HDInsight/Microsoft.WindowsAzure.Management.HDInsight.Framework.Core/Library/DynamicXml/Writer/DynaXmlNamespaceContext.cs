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
    using System.Collections.Generic;

    internal class DynaXmlNamespaceContext
    {
        /// <summary>
        /// Initializes a new instance of the DynaXmlNamespaceContext class.
        /// </summary>
        /// <param name="orignal">
        /// An existing namespace context that should be cloned.
        /// </param>
        internal DynaXmlNamespaceContext(DynaXmlNamespaceContext orignal)
        {
            this.CurrentAlias = orignal.CurrentAlias;
            this.DefaultNamespace = orignal.DefaultNamespace;
            this.AliasTable = new Dictionary<string, string>(orignal.AliasTable);
        }

        /// <summary>
        /// Initializes a new instance of the DynaXmlNamespaceContext class.
        /// </summary>
        internal DynaXmlNamespaceContext()
        {
            this.CurrentAlias = string.Empty;
            this.DefaultNamespace = string.Empty;
            this.AliasTable = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the default namespace.
        /// </summary>
        public string DefaultNamespace { get; set; }

        /// <summary>
        /// Gets or sets the current alias.
        /// </summary>
        public string CurrentAlias { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current alias should be applied to attributes.
        /// </summary>
        public bool ApplyCurrentToAttributes { get; set; }

        /// <summary>
        /// Gets the current namespace table (organized by alias).
        /// </summary>
        public IDictionary<string, string> AliasTable { get; private set; }
    }
}
