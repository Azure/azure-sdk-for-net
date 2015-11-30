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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer.Model;

    /// <summary>
    ///     Provides the current context tracking for Dynamic Xml building.
    /// </summary>
    internal class DynaXmlBuilderContext
    {
        private readonly Stack<DynaXmlContextState> stack;

        /// <summary>
        ///     Initializes a new instance of the DynaXmlBuilderContext class.
        /// </summary>
        public DynaXmlBuilderContext()
        {
            this.stack = new Stack<DynaXmlContextState>();
        }

        /// <summary>
        ///     Initializes a new instance of the DynaXmlBuilderContext class.
        /// </summary>
        /// <param name="original">Original context.</param>
        public DynaXmlBuilderContext(DynaXmlBuilderContext original)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }

            IEnumerable<DynaXmlContextState> list = new List<DynaXmlContextState>(original.stack);
            IEnumerable<DynaXmlContextState> reversed = list.Reverse();
            this.stack = new Stack<DynaXmlContextState>(reversed);
        }

        /// <summary>
        ///     Gets the builder state represented by this object.
        /// </summary>
        public DynaXmlBuilderState State
        {
            get { return this.stack.Peek().State; }
            private set { this.stack.Peek().State = value; }
        }

        /// <summary>
        /// Gets the last Element Node created (ancestor of self).
        /// </summary>
        public DynaXmlElement CurrentAncestorElement
        {
            get { return this.stack.Peek().CurentAncestorElement; }
        }

        /// <summary>
        /// Gets the current ancestor node.
        /// </summary>
        public DynaXmlNode CurrentAncestorNode
        {
            get { return (DynaXmlNode)this.CurrentAncestorElement ?? this.Document; }
        }

        /// <summary>
        /// Gets or sets the last element created.
        /// </summary>
        public DynaXmlElement LastCreated
        {
            get { return this.stack.Peek().LastCreated; }
            set { this.stack.Peek().LastCreated = value; }
        }

        /// <summary>
        /// Gets or sets the current namespace context.
        /// </summary>
        public DynaXmlNamespaceContext CurrentNamespaceContext
        {
            get { return this.stack.Peek().CurrentNamespaceContext; }
            set { this.stack.Peek().CurrentNamespaceContext = value; }
        }

        public DynaXmlContextState Current
        {
            get { return this.stack.Peek(); }
        }

        /// <summary>
        /// Gets the XmlDocument.
        /// </summary>
        public DynaXmlDocument Document
        {
            get { return this.stack.Peek().Document; }
        }

        /// <summary>
        ///     Pops to the previous state in the stack.
        /// </summary>
        /// <returns>The Content state for the previous state in the stack.</returns>
        public DynaXmlContextState Pop()
        {
            return this.stack.Pop();
        }

        /// <summary>
        ///     Pushes a new state into the stack (thus changing the current state to the new state).
        /// </summary>
        /// <param name="element">
        ///     The XmlELement representing the current state.
        /// </param>
        public void PushElement(DynaXmlElement element)
        {
            this.CurrentAncestorNode.Items.Add(element);
            this.Push(element, DynaXmlBuilderState.ElementListBuilder);
        }

        /// <summary>
        ///     Pushes a new state into the stack.  This allows a change of building type without altering the current node being built.
        /// </summary>
        /// <param name="state">
        ///     The new state of the builder.
        /// </param>
        public void PushState(DynaXmlBuilderState state)
        {
            if (state == DynaXmlBuilderState.ElementListBuilder)
            {
                this.Push(this.LastCreated, state);
            }
            else
            {
                this.Push(this.CurrentAncestorElement,
                          state);
            }
        }

        /// <summary>
        ///     Pushes a new state into the stack (thus changing the current state to the new state).
        ///     This method allows for both a new node and a new state to be supplied.
        /// </summary>
        /// <param name="newAncestor">
        ///     The new XmlNode representing the ancestor for all new nodes.
        /// </param>
        /// <param name="state">
        ///     The new state.
        /// </param>
        internal void Push(DynaXmlElement newAncestor, DynaXmlBuilderState state)
        {
            this.stack.Push(new DynaXmlContextState(this.Document,
                                                    newAncestor,
                                                    newAncestor,
                                                    new DynaXmlNamespaceContext(this.CurrentNamespaceContext),
                                                    state));
        }

        /// <summary>
        /// Changes the BuilderState for the current context.
        /// </summary>
        /// <param name="state">
        /// The new state to enter.
        /// </param>
        internal void ChangeState(DynaXmlBuilderState state)
        {
            this.State = state;
        }

        /// <summary>
        ///     Pushes an initial document onto the stack.
        /// </summary>
        /// <param name="document">
        ///     The XmlDocument object representing the document for building.
        /// </param>
        /// <param name="state">
        ///     The new state.
        /// </param>
        internal void Push(DynaXmlDocument document, DynaXmlBuilderState state)
        {
            this.stack.Push(new DynaXmlContextState(document,
                                                    null,
                                                    null,
                                                    new DynaXmlNamespaceContext(),
                                                    state));
        }
    }
}