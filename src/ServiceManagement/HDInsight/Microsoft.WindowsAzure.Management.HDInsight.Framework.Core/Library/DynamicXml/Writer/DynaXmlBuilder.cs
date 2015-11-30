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
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer.Model;

    /// <summary>
    /// Used to build an Xml Document dynamically.
    /// </summary>
#if Non_Public_SDK
    public class DynaXmlBuilder : DynamicObject
#else
    internal class DynaXmlBuilder : DynamicObject
#endif
    {
        private const string Xmlns = "http://www.w3.org/2000/xmlns/";
        private bool includeHeader;
        private DynaXmlDocument document;
        private DynaXmlBuilderContext context;
        private Formatting xmlFormatting;
        private List<DynaXmlAttribute> rootNodeNamespaceDefinitions = new List<DynaXmlAttribute>();
        private readonly Dictionary<string, DynaXmlBuilderContext> setPoints = new Dictionary<string, DynaXmlBuilderContext>();

        /// <summary>
        /// Gets the current State of the building context.
        /// </summary>
        private DynaXmlBuilderState State
        {
            get { return this.context.State; }
        }

        /// <summary>
        /// Gets the current ancestor XmlNode for the builder.
        /// </summary>
        private DynaXmlElement CurrentAncestorElement
        {
            get { return this.context.CurrentAncestorElement; }
        }

        /// <summary>
        /// Gets the current ancestor as an XmlNode.
        /// </summary>
        private DynaXmlNode CurrentAncestorNode
        {
            get { return this.context.CurrentAncestorNode; }
        }

        /// <summary>
        /// Sets the last element that was created.
        /// </summary>
        private DynaXmlElement LastCreated
        {
            // get { return this.context.LastCreated; }
            set { this.context.LastCreated = value; }
        }

        /// <summary>
        /// Gets the current DynaXmlNamespaceContext.
        /// </summary>
        private DynaXmlNamespaceContext CurrentNamespaceContext
        {
            get { return this.context.CurrentNamespaceContext; }
        }

        /// <summary>
        /// Initializes a new instance of the DynaXmlBuilder class.
        /// </summary>
        /// <param name="document">
        /// The XmlDocument to use for building.
        /// </param>
        /// <param name="includeHeader">
        /// A flag indicating that a header should be included.
        /// </param>
        /// <param name="xmlFormatting">
        /// The XmlFormatting style to use when writing the document.
        /// </param>
        internal DynaXmlBuilder(DynaXmlDocument document, bool includeHeader, Formatting xmlFormatting)
        {
            this.xmlFormatting = xmlFormatting;
            this.includeHeader = includeHeader;
            this.context = new DynaXmlBuilderContext();
            this.document = document;
            // this.context.Push(this.document, DynaXmlBuilderState.ElementBuilder);
            this.context.Push(this.document, DynaXmlBuilderState.ElementListBuilder);
        }

        /// <summary>
        /// Creates a new instance of the DynaXmlBuilder class.
        /// This override allows the user to specify if a header should or should not be added.
        /// </summary>
        /// <param name="includeHeader">
        /// Specifies if a header (&lt;?xml ... &gt;) should be included.
        /// </param>
        /// <param name="xmlFormatting">
        /// The XmlFormatting style to use when writing the document.
        /// </param>
        /// <returns>
        /// A new DynaXmlBuilder object that can be used to build Xml.
        /// </returns>
        public static dynamic Create(bool includeHeader, Formatting xmlFormatting)
        {
            var document = new DynaXmlDocument();
            return new DynaXmlBuilder(document, includeHeader, xmlFormatting);
        }

        /// <summary>
        /// Creates a new instance of the DynaXmlBuilder class.
        /// This override will force the creation of an xml header.
        /// </summary>
        /// <returns>
        /// A new DynaXmlBuilder object that can be used to build Xml.
        /// </returns>
        public static dynamic Create()
        {
            return DynaXmlBuilder.Create(true, Formatting.Indented);
        }

        /// <summary>
        /// Creates a new element in the XmlDocument.
        /// </summary>
        /// <param name="name">
        /// The name of the element.
        /// </param>
        /// <returns>
        /// The XmlElement that was created.
        /// </returns>
        private DynaXmlElement CreateElement(string name)
        {
            DynaXmlElement element = null;
            var currentAlias = this.CurrentNamespaceContext.CurrentAlias;
            if (currentAlias.IsNotNullOrEmpty())
            {
                element = new DynaXmlElement()
                {
                    Prefix = currentAlias,
                    LocalName = name,
                    XmlNamespace = this.CurrentNamespaceContext.AliasTable[currentAlias]
                };
                // We've used the "CurrentAlias" so remove it as it's a (use once state);
                this.CurrentNamespaceContext.CurrentAlias = string.Empty;
                this.CurrentNamespaceContext.ApplyCurrentToAttributes = false;
            }
            else if (this.CurrentNamespaceContext.DefaultNamespace.IsNullOrEmpty())
            {
                element = new DynaXmlElement() { LocalName = name };
            }
            else
            {
                element = new DynaXmlElement() { LocalName = name, XmlNamespace = this.CurrentNamespaceContext.DefaultNamespace };
            }
            if (this.CurrentAncestorElement.IsNull())
            {
                element.Items.AddRange(this.rootNodeNamespaceDefinitions);
            }
            return element;
        }

        /// <summary>
        /// Used to manage members applied when in the Attribute state.
        /// </summary>
        /// <param name="name">
        /// The binder for the dynamic method get.
        /// </param>
        /// <returns>
        /// True if the operation is successful; otherwise, false. 
        /// If this method returns false, the run-time binder of the language determines the behavior
        /// (In most cases, a run-time exception is thrown).
        /// </returns>
        private bool AttributeBuilderGetMember(string name)
        {
            return this.AttributeBuilderInvokeMember(name, string.Empty);
        }

        /// <summary>
        /// Changes the current namespace alias for the current context.
        /// </summary>
        /// <param name="name">
        /// The alias for the new namespace.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool NamespaceBuilderGetMember(string name)
        {
            string xmlNamespace = null;
            if (!this.CurrentNamespaceContext.AliasTable.TryGetValue(name, out xmlNamespace))
            {
                throw new InvalidOperationException("An attempt was made to set the current XML namespace uri to a namespace that has not been defined.");
            }

            // NOTE: We pop the context first.  This is because we don't want to change the namespace
            // on the "NamespaceState" entry, but rather on the entry above it.
            this.context.Pop();
            // Change the current Alias.
            this.CurrentNamespaceContext.CurrentAlias = name;
            // If we are in an Attribute creation context, then we apply the namespace to the attribute.
            if (this.State == DynaXmlBuilderState.AttributeBuilder ||
                this.State == DynaXmlBuilderState.AttributeListBuilder)
            {
                this.CurrentNamespaceContext.ApplyCurrentToAttributes = true;
            }
            return true;
        }

        /// <summary>
        /// Changes the current namespace alias for the current context.
        /// </summary>
        /// <param name="name">
        /// The alias for the new namespace.
        /// </param>
        /// <param name="xmlNamespace">
        /// The namespace Url to apply.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool NamespaceBuilderInvokeMember(string name, string xmlNamespace)
        {
            // First check to make sure the namespace has not already been defined
            // on this element.  It's okay if it's in the current context, but it 
            // cant be on the AncestorElement.
            ICollection<DynaXmlAttribute> currentAttributes;
            if (this.CurrentAncestorElement.IsNotNull())
            {
                currentAttributes = new List<DynaXmlAttribute>();
                foreach (DynaXmlAttribute attrib in this.CurrentAncestorElement.Attributes)
                {
                    currentAttributes.Add(attrib);
                }
            }
            else
            {
                currentAttributes = this.rootNodeNamespaceDefinitions;
            }

            DynaXmlAttribute attribute = (from a in currentAttributes
                                          where a.LocalName == name &&
                                                a.XmlNamespace == Xmlns
                                          select a).FirstOrDefault();
            if (attribute.IsNotNull())
            {
                attribute.Value = xmlNamespace;
            }
            else
            {
                attribute = this.CreateNamespace(name, xmlNamespace);
                if (this.CurrentAncestorElement.IsNotNull())
                {
                    this.CurrentAncestorElement.Items.Add(attribute);
                }
                else
                {
                    this.rootNodeNamespaceDefinitions.Add(attribute);
                }
            }

            // Again we pop the context first.
            this.context.Pop();
            // Then we make the changes in the Namespace area of the context.
            this.CurrentNamespaceContext.AliasTable[name] = xmlNamespace;
            return true;
        }

        /// <summary>
        /// Used to manage the creation of Elements against the a child element within the Xml document.
        /// </summary>
        /// <param name="name">
        /// The name of the member.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool ElementBuilderGetMember(string name)
        {
            // Determine if we are at the root level and if we are trying to 
            // create more than one node.
            if (this.CurrentAncestorNode == this.document && this.document.Items.Count != 0)
            {
                throw new InvalidOperationException("An Xml Document may not have more than one root element.");
            }

            // If we are in a list builder, append the current element.
            if (this.State == DynaXmlBuilderState.ElementListBuilder ||
                this.State == DynaXmlBuilderState.LiteralElementBuilder)
            {
                var element = this.CreateElement(name);
                this.CurrentAncestorNode.Items.Add(element);
                // update the last created in case a new list is needed under this element.
                this.LastCreated = element;
            }
            else
            {
                // Push element updates both the last created element and the ancestor.
                // This is because a new ancestor is by definition the last created.
                this.context.PushElement(this.CreateElement(name));
            }

            if (this.State == DynaXmlBuilderState.LiteralElementBuilder)
            {
                this.context.Pop();
            }
            return true;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            using (var memStream = new MemoryStream())
            using (var reader = new StreamReader(memStream))
            {
                this.Save(memStream);
                memStream.Flush();
                memStream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Saves the Xml to a given file.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file to save to.
        /// </param>
        private void Save(string fileName)
        {
            using (var stream = new FileStream(fileName,
                                               FileMode.Create,
                                               FileAccess.Write,
                                               FileShare.Read))
            {
                this.Save(stream);
            }
        }

        /// <summary>
        /// Saves the Xml to a given stream.
        /// </summary>
        /// <param name="stream">
        /// The stream to save to.
        /// </param>
        private void Save(Stream stream)
        {
            // Use XmlWriterSettings to control the Xml construction.
            XmlWriterSettings settings = new XmlWriterSettings();
            // If indentation was request, then specify indentation.
            settings.Indent = this.xmlFormatting == Formatting.Indented;
            // Omit the header if include header is false.
            settings.OmitXmlDeclaration = !this.includeHeader;

            // Use a temporary memory stream as the writer will always dispose the stream.
            using (MemoryStream temp = new MemoryStream())
            using (var streamWriter = new StreamWriter(temp))
            using (var xmlWriter = XmlTextWriter.Create(streamWriter, settings))
            {
                var stack = new Stack<KeyValuePair<int, DynaXmlNode>>();
                stack.Push(new KeyValuePair<int, DynaXmlNode>(0, this.document.Items.ElementAt(0)));
                int lastDepth = 0;
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    var depth = node.Key;
                    while (depth < lastDepth && depth != 0)
                    {
                        xmlWriter.WriteEndElement();
                        lastDepth--;
                    }
                    lastDepth = depth;
                    switch (node.Value.NodeType)
                    {
                        case DynaXmlNodeType.Text:
                            xmlWriter.WriteString(node.Value.Value);
                            break;
                        case DynaXmlNodeType.CData:
                            xmlWriter.WriteCData(node.Value.Value);
                            break;
                        case DynaXmlNodeType.Element:
                            var attributes = (from n in node.Value.Items
                                              where n.NodeType == DynaXmlNodeType.Attribute
                                              select n).ToList();
                            var others = (from n in node.Value.Items
                                          where n.NodeType != DynaXmlNodeType.Attribute
                                          select n).Reverse().ToList();
                            xmlWriter.WriteStartElement(node.Value.Prefix, node.Value.LocalName, node.Value.XmlNamespace);
                            foreach (var attribute in attributes)
                            {
                                xmlWriter.WriteAttributeString(attribute.Prefix,
                                                               attribute.LocalName,
                                                               attribute.XmlNamespace,
                                                               attribute.Value);
                            }
                            bool hasOthers = false;
                            foreach (var other in others)
                            {
                                hasOthers = true;
                                stack.Push(new KeyValuePair<int, DynaXmlNode>(depth + 1, other));
                            }
                            if (!hasOthers)
                            {
                                xmlWriter.WriteEndElement();
                            }
                            break;
                    }
                }
                while (lastDepth > 0)
                {
                    lastDepth--;
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.Flush();
                streamWriter.Flush();
                stream.Flush();
                //this.document.Save(xmlWriter);
                // Copy the content into the actual stream supplied.
                temp.Position = 0;
                temp.CopyTo(stream);
            }
        }

        /// <summary>
        /// Creates an Xml Attribute.
        /// </summary>
        /// <param name="name">
        /// The name of the attribute.
        /// </param>
        /// <param name="value">
        /// The value of the attribute.
        /// </param>
        /// <returns>
        /// The new attribute.
        /// </returns>
        private DynaXmlAttribute CreateAttribute(string name, string value)
        {
            DynaXmlAttribute retval;
            var currentAlias = this.CurrentNamespaceContext.CurrentAlias;
            if (!this.CurrentNamespaceContext.ApplyCurrentToAttributes)
            {
                retval = new DynaXmlAttribute() { LocalName = name };
            }
            else
            {
                retval = new DynaXmlAttribute()
                {
                    Prefix = currentAlias,
                    LocalName = name,
                    XmlNamespace = this.CurrentNamespaceContext.AliasTable[currentAlias]
                };
                // We've used the current alias so remove it as it is a (use once state)
                this.CurrentNamespaceContext.CurrentAlias = string.Empty;
                this.CurrentNamespaceContext.ApplyCurrentToAttributes = false;
            }
            retval.Value = value;
            return retval;
        }

        /// <summary>
        /// Creates a new XmlNamespace element.
        /// </summary>
        /// <param name="prefix">The prefix for the namespace.</param>
        /// <param name="xmlNamespace">The namespace.</param>
        /// <returns>A new XmlAttribute representing the namespace.</returns>
        private DynaXmlAttribute CreateNamespace(string prefix, string xmlNamespace)
        {
            DynaXmlAttribute namespaceDefinition = new DynaXmlAttribute()
            {
                Prefix = "xmlns",
                LocalName = prefix,
                XmlNamespace = Xmlns
            };
            this.CurrentNamespaceContext.AliasTable.Add(prefix, xmlNamespace);
            namespaceDefinition.Value = xmlNamespace;
            return namespaceDefinition;
        }

        /// <summary>
        /// Gets a value indicating whether we are in a sate of processing an element.
        /// </summary>
        private bool IsElementState
        {
            get
            {
                return // this.State == DynaXmlBuilderState.ElementBuilder ||
                       this.State == DynaXmlBuilderState.ElementListBuilder ||
                       this.State == DynaXmlBuilderState.LiteralElementBuilder;
            }
        }

        /// <summary>
        /// Gets a value indicating whether we are in a state of processing a literal.
        /// </summary>
        private bool IsLiteratState
        {
            get
            {
                return this.State == DynaXmlBuilderState.LiteralElementBuilder ||
                       this.State == DynaXmlBuilderState.LiteralAttributeBuilder;
            }
        }

        /// <summary>
        /// Changes the default namespace to apply to all newly created elements.
        /// </summary>
        /// <param name="xmlNamespace">
        /// The new xml namespace.
        /// </param>
        private void SetDefaultNamespace(string xmlNamespace)
        {
            this.CurrentNamespaceContext.DefaultNamespace = xmlNamespace;
        }

        /// <inheritdoc />
        /// This method handles property gets.
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // A binder must have been supplied, the runtime will always do this.
            if (binder.IsNull())
            {
                throw new ArgumentNullException("binder");
            }

            // This is an "interface flowing" construct, so the result is always this.
            result = this;

            // Starts a Literal block
            if (binder.Name == "l" && !this.IsLiteratState)
            {
                switch (this.State)
                {
                    // If we are in an Attribute List builder, we push state.
                    case DynaXmlBuilderState.AttributeListBuilder:
                        this.context.PushState(DynaXmlBuilderState.LiteralAttributeBuilder);
                        break;
                    // If we are in a single attribute builder we change state (so the pop takes 
                    // us out of the attribute building)
                    case DynaXmlBuilderState.AttributeBuilder:
                        this.context.ChangeState(DynaXmlBuilderState.LiteralAttributeBuilder);
                        break;
                    // If we are in an Element or an Element List builder we push state.
                    case DynaXmlBuilderState.ElementListBuilder:
                        this.context.PushState(DynaXmlBuilderState.LiteralElementBuilder);
                        break;
                }
                return true;
            }

            // Starts an Attribute block which allows for an attribute to be added.
            if (binder.Name == "at" && !this.IsLiteratState)
            {
                this.context.PushState(DynaXmlBuilderState.AttributeBuilder);
                return true;
            }

            if (binder.Name == "xmlns" && !this.IsLiteratState)
            {
                this.context.PushState(DynaXmlBuilderState.NamespaceBuilder);
                return true;
            }

            // Starts a list (which is multiple elements or attributes in a row)
            if (binder.Name == "b")
            {
                if (this.State == DynaXmlBuilderState.ElementListBuilder)
                {
                    // Enter a child list of the parent.
                    this.context.PushState(DynaXmlBuilderState.ElementListBuilder);
                    return true;
                }
                if (this.State == DynaXmlBuilderState.AttributeBuilder)
                {
                    // Change state to attribute list builder.
                    this.context.ChangeState(DynaXmlBuilderState.AttributeListBuilder);
                    return true;
                }
            }

            // Ends a list (multiple elements or attributes in a row).
            if (binder.Name == "d" &&
                (this.State == DynaXmlBuilderState.ElementListBuilder ||
                 this.State == DynaXmlBuilderState.AttributeListBuilder))
            {
                this.context.Pop();
                return true;
            }

            switch (this.State)
            {
                case DynaXmlBuilderState.NamespaceBuilder:
                    return this.NamespaceBuilderGetMember(binder.Name);
                case DynaXmlBuilderState.ElementListBuilder:
                case DynaXmlBuilderState.LiteralElementBuilder:
                    return this.ElementBuilderGetMember(binder.Name);
                case DynaXmlBuilderState.AttributeBuilder:
                case DynaXmlBuilderState.LiteralAttributeBuilder:
                case DynaXmlBuilderState.AttributeListBuilder:
                    return this.AttributeBuilderGetMember(binder.Name);
            }
            // Otherwise call into base.
            // Base currently does nothing (but returns false and fails), but a new class could be interposed.
            return base.TryGetMember(binder, out result);
        }

        /// <inheritdoc />
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            // For interface flowing, the resulting object is always this object.
            result = this;
            if (binder == null)
            {
                throw new ArgumentNullException("binder");
            }

            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            // Ends the line of chaining.
            if (binder.Name == "End" && !this.IsLiteratState)
            {
                return true;
            }

            if (args.Length == 0 || args[0].IsNull())
            {
                if (this.IsElementState)
                {
                    this.ElementBuilderInvokeMember(binder.Name, string.Empty);
                }
                throw new ArgumentOutOfRangeException("args");
            }

            // Get the value of the first argument as a string.
            var arg0 = args[0].ToString();

            // Special method that saves the content of the XML.
            if (binder.Name == "Save" && !this.IsLiteratState)
            {
                var asStream = args[0] as Stream;
                if (asStream.IsNotNull())
                {
                    this.Save(asStream);
                    return true;
                }
                this.Save(arg0);
                return true;
            }

            // start a "save point" this can be used to go back to the midle of the document later.
            if (binder.Name == "sp" && !this.IsLiteratState)
            {
                this.setPoints[arg0] = new DynaXmlBuilderContext(this.context);
                return true;
            }

            // reload previously created save point.
            if (binder.Name == "rp" && !this.IsLiteratState)
            {
                this.context = this.setPoints[arg0];
                return true;
            }

            // Creates a Text block with the content supplied.
            if (binder.Name == "text" && !this.IsLiteratState)
            {
                return this.TextInvokeMember(arg0);
            }

            // Creates a CDATA block with the content supplied.
            if (binder.Name == "cdata" && !this.IsLiteratState)
            {
                return this.CDataInvokeMember(arg0);
            }

            // Sets the default namespace for the current element.
            if (binder.Name == "xmlns" &&
                !this.IsLiteratState)
            {
                this.SetDefaultNamespace(arg0);
                return true;
            }

            switch (this.State)
            {
                case DynaXmlBuilderState.NamespaceBuilder:
                    return this.NamespaceBuilderInvokeMember(binder.Name, arg0);
                case DynaXmlBuilderState.AttributeBuilder:
                case DynaXmlBuilderState.AttributeListBuilder:
                case DynaXmlBuilderState.LiteralAttributeBuilder:
                    return this.AttributeBuilderInvokeMember(binder.Name, arg0);
                case DynaXmlBuilderState.ElementListBuilder:
                case DynaXmlBuilderState.LiteralElementBuilder:
                    return this.ElementBuilderInvokeMember(binder.Name, arg0);
                //case DynaXmlBuilderState.NamespaceBuilder:
                //    return this.NamespaceBuilderInvokeMember(binder, args);
            }
            return base.TryInvokeMember(binder, args, out result);
        }

        /// <summary>
        /// Adds an element with content to the tree.
        /// </summary>
        /// <param name="name">
        /// The name of the element to add.
        /// </param>
        /// <param name="value">
        /// The value to place as the text of the element.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool ElementBuilderInvokeMember(string name, string value)
        {
            // Determine if we are at the root level and if we are trying to 
            // create more than one node.
            if (this.CurrentAncestorNode == this.document && this.document.Items.Count != 0)
            {
                throw new InvalidOperationException("An Xml Document may not have more than one root element.");
            }

            DynaXmlElement element = this.CreateElement(name);
            DynaXmlText text = new DynaXmlText() { Value = value };
            element.Items.Add(text);
            this.CurrentAncestorNode.Items.Add(element);
            if (this.State == DynaXmlBuilderState.LiteralElementBuilder)
            {
                this.context.Pop();
            }
            return true;
        }

        /// <summary>
        /// Creates an Attribute as a component of the current element.
        /// </summary>
        /// <param name="name">
        /// The name of the attribute.
        /// </param>
        /// <param name="value">
        /// The value for the attribute.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool AttributeBuilderInvokeMember(string name, string value)
        {
            // Determine if we are at the root level and if we are trying to 
            // create more than one node.
            if (this.CurrentAncestorNode == this.document && this.document.Items.Count != 0)
            {
                throw new InvalidOperationException("Attributes can not be added before a root element is defined.");
            }

            DynaXmlElement element = this.CurrentAncestorElement;
            element.Items.Add(this.CreateAttribute(name, value));
            // If we are NOT in a AttributeListBuild, we pop the state
            // if we are in a list attribute build, we do not.
            if (this.State != DynaXmlBuilderState.AttributeListBuilder)
            {
                this.context.Pop();
            }
            return true;
        }

        /// <summary>
        /// Creates a CDATA block with the text supplied.
        /// </summary>
        /// <param name="content">
        /// The content to place in the CDATA block.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool CDataInvokeMember(string content)
        {
            // Determine if we are at the root level and if we are trying to 
            // create more than one node.
            if (this.CurrentAncestorNode == this.document && this.document.Items.Count != 0)
            {
                throw new InvalidOperationException("CDATA nodes can not be part of the root xml structure.");
            }

            DynaXmlCData cdata = new DynaXmlCData() { Value = content };
            this.CurrentAncestorNode.Items.Add(cdata);
            return true;
        }

        /// <summary>
        /// Creates a Text block with the text supplied.
        /// </summary>
        /// <param name="content">
        /// The content to place in the CDATA block.
        /// </param>
        /// <returns>
        /// Always true.
        /// </returns>
        private bool TextInvokeMember(string content)
        {
            // Determine if we are at the root level and if we are trying to 
            // create more than one node.
            if (this.CurrentAncestorNode == this.document && this.document.Items.Count != 0)
            {
                throw new InvalidOperationException("Text nodes can not be part of the root xml structure.");
            }

            DynaXmlText text = new DynaXmlText() { Value = content };
            this.CurrentAncestorNode.Items.Add(text);
            return true;
        }
    }
}
