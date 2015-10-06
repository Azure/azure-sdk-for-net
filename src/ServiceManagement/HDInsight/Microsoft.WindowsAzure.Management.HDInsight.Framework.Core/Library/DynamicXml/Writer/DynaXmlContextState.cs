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
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer.Model;

    /// <summary>
    ///     Used to track a current context state within the builder system.
    /// </summary>
    internal class DynaXmlContextState
    {
        /// <summary>
        ///     Initializes a new instance of the DynaXmlContextState class.
        /// </summary>
        /// <param name="document">The xml document.</param>
        /// <param name="currentAncestor">The current ancestor of all new nodes.</param>
        /// <param name="lastCreated">The last node that was created.</param>
        /// <param name="namespaceContext">The current namespace context.</param>
        /// <param name="state">The current state of the state machine.</param>
        public DynaXmlContextState(DynaXmlDocument document,
                                   DynaXmlElement currentAncestor,
                                   DynaXmlElement lastCreated,
                                   DynaXmlNamespaceContext namespaceContext,
                                   DynaXmlBuilderState state)
        {
            this.Document = document;
            this.State = state;
            this.CurentAncestorElement = currentAncestor;
            this.CurrentNamespaceContext = namespaceContext;
            this.LastCreated = lastCreated;
        }

        /// <summary>
        /// Gets the XmlDocument current being worked on.
        /// </summary>
        public DynaXmlDocument Document { get; private set; }

        /// <summary>
        /// Gets the last XmlElement (ancestor of self) created.
        /// </summary>
        public DynaXmlElement CurentAncestorElement { get; private set; }

        /// <summary>
        /// Gets or sets the current namespace context.
        /// </summary>
        public DynaXmlNamespaceContext CurrentNamespaceContext { get; set; }

        /// <summary>
        /// Gets or sets the last element created (even if it isn't currently the ancestor).
        /// </summary>
        public DynaXmlElement LastCreated { get; set; }

        /// <summary>
        /// Gets or sets the dynamic xml builder state (the type of things being built) represented by this state.
        /// </summary>
        public DynaXmlBuilderState State { get; internal set; }
    }
}