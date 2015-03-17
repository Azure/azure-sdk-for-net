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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.DynamicXml
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Xml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class DynaXmlBuilderTest : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root />
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root />",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanSetTheDefaultNamespaceOnTheRootNode_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //   And I set the default namespace
                builder.xmlns("http://default.com")
                //  When I add a member "Root" to the builder
                       .Root
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root xmlns=\"http://default.com\" />
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root xmlns=\"http://default.com\" />",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void WhenMultipleDefaultNamespacesAreSuppliedForTheRootObjectTheLastOneWins_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //   And I set the default namespace
                builder.xmlns("http://first.com")
                //   And I set the default namespace to something else
                       .xmlns("http://default.com")
                //  When I add a member "Root" to the builder
                       .Root
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root xmlns=\"http://default.com\" />
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root xmlns=\"http://default.com\" />",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanSetTheDefaultNamespaceOnAChildNodeMultipleTimesTheLastOneWins_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I set the default namespace
                         .xmlns("http://first.com")
                //   And I set the default namespace to something else
                // #NOTE: The second request to change the default namespace wins.
                         .xmlns("http://default.com")
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child xmlns=\"http://default.com\" /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child xmlns=\"http://default.com\" /></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanSetTheDefaultNamespaceOnAChildNode_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I set the default namespace 
                // # NOTE: xmlns applies to the next command not the last.
                         .xmlns("http://default.com")
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child xmlns=\"http://default.com\" /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child xmlns=\"http://default.com\" /></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanAddAChildElementAsTheRootNode_WithBuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" with content to the builder
                builder.Root("inner text")
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root>inner text</Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root>inner text</Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanAddAChildElementWithContentUnderTheRootNode_WithBuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list
                       .b
                //   And I add an element with content
                         .Child("inner text")
                //   And I end the list
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child>inner text</Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child>inner text</Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithAnAttribute_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I specify an attribute attrib="value"
                         .at.attrib("value")
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root attrib=\"value\" />
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root attrib=\"value\" />",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithACDATASectionThatAddsCharactersNotValidInXml_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I specify an attribute attrib="value"
                         .cdata("<someXmlContent>")
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><![CDATA[<someXmlContent>]]></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><![CDATA[<someXmlContent>]]></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithAChildElementWithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child /></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithTwoLyersOfChildElementWithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child member "SubChild" to the builder
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild /></Child></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateASubChildElementWithContent_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child member "SubChild" to the builder
                           .SubChild("inner text")
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild>inner text</SubChild></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild>inner text</SubChild></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateASubChildElementWithinAListWithContent_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list
                         .b
                //   And I add a child member "SubChild" to the builder
                           .SubChild("inner text")
                //   And I end the list
                         .d
                //   And I end the list
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild>inner text</SubChild></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild>inner text</SubChild></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateASubChildElementWithinAListAndSetTheDefaultNamespace_TheNamespaceIsApplied_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list
                         .b
                //   And I set the default namespace to something else
                           .xmlns("http://default.com")
                //   And I add a child member "SubChild" to the builder
                           .SubChild
                //   And I end the list
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild xmlns=\"http://default.com\" /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild xmlns=\"http://default.com\" /></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void WhenIApplyTheDefaultNamespaceBeforeAListItIsAppliedToAllChildren_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I set the default namespace to something else
                // #NOTE: This default namespace will apply to all elements in the block 
                // # not just the next one.
                         .xmlns("http://default.com")
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I start a list of children
                           .b
                //   And I add a child called "SubSubChild"
                // #NOTE: The Inner elements will not receive an explicit default namespace declaration
                // because they are inheriting it from the parent.
                             .SubSubChild
                //   And I end the list of children
                           .d
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild xmlns=\"http://default.com\"><SubSubChild /></SubChild><SubChild xmlns=\"http://default.com\" /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild xmlns=\"http://default.com\"><SubSubChild /></SubChild><SubChild xmlns=\"http://default.com\" /></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateMultipleLayersOfChildren_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I start a list of children
                           .b
                //   And I add a child called "SubSubChild"
                             .SubSubChild
                //   And I end the list of children
                           .d
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild><SubSubChild /></SubChild><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild><SubSubChild /></SubChild><SubChild /></Child></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateAnAttributeList_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I create an attribute list
                //# REMEMBER: this attribute will apply to Root because child has not started a block.
                         .at
                         .b
                //   And I supply an attribute
                           .attrib1("value")
                //   And I supply a second attrib value
                           .attrib2("value")
                //   And I end the attribute list
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root attrib1=\"value\" attrib2=\"value\"><Child /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root attrib1=\"value\" attrib2=\"value\"><Child /></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void WithMultipleLayersOfSubChildrenAttributesGoToTheLastAncestor_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I start a list of children
                           .b
                //   And I add a child called "SubSubChild"
                             .SubSubChild
                //   And I add an attribute attrib="value"
                             .at.attrib("value")
                //   And I end the list of children
                           .d
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild attrib=\"value\"><SubSubChild /></SubChild><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual(
                        "<Root><Child><SubChild attrib=\"value\"><SubSubChild /></SubChild><SubChild /></Child></Root>",
                        content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanStartAListAfterTheRootElement_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynaXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);

                //  When I add a member "Root" to the builder.
                builder.Root
                //   And I start a list
                       .b
                //   And I create an element
                         .Child
                //   And I create another element
                         .Child
                //   And I end the list
                       .d
                //   And I save the results
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child /><Child /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child /><Child /></Root>", content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanUseNamespaceAliases_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynaXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);

                //  When I add a member "Root" to the builder.
                builder.Root
                    //   And I start a list
                       .b
                         .xmlns.test("http://test.com")
                    //   And I create an element
                         .xmlns.test.Child
                    //   And I create another element
                         .Child
                    //   And I end the list
                       .d
                    //   And I save the results
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root xmlns:test=\"http://test.com\"><test:Child /><Child /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root xmlns:test=\"http://test.com\"><test:Child /><Child /></Root>", content);
                }
            }            
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanUseMultipleNamespaceAliases_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynaXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);

                //  When I add a member "Root" to the builder.
                builder.Root
                    //   And I start a list
                       .b
                         .xmlns.test1("http://test1.com")
                         .xmlns.test2("http://test2.com")
                    //   And I create an element
                         .xmlns.test1.Child
                    //   And I create another element
                         .xmlns.test2.Child
                    //   And I end the list
                       .d
                    //   And I save the results
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root xmlns:test1=\"http://test1.com\" xmlns:test2=\"http://test2.com\"><test1:Child /><test2:Child /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root xmlns:test1=\"http://test1.com\" xmlns:test2=\"http://test2.com\"><test1:Child /><test2:Child /></Root>", content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateAliasOnTheRootNodeAndUseIt_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynaXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);

                //  When I create an alias
                builder.xmlns.test1("http://test1.com")
                    //   And I create another alias         
                       .xmlns.test2("http://test2.com")
                    //   And I use the first alias
                       .xmlns.test1
                    //   And I create the root node.
                       .Root
                    //   And I start a list
                       .b
                    //   And I create a child element
                         .Child
                    //   And I use the second alias
                         .xmlns.test2
                    //   And I use the child element
                         .Child
                    //   And I end the list
                       .d
                    //   And I save the results
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <test1:Root xmlns:test1=\"http://test1.com\"><Child /><test2:Child xmlns:test2=\"http://test2.com\" /></test1:Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<test1:Root xmlns:test1=\"http://test1.com\" xmlns:test2=\"http://test2.com\"><Child /><test2:Child /></test1:Root>", content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateAliasOnTheRootNode_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynaXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);

                //  When I create an alias
                builder.xmlns.test1("http://test1.com")
                //   And I create another alias         
                       .xmlns.test2("http://test2.com")
                //   And I create the root node.
                       .Root
                //   And I start a list
                       .b
                //   And I use the first alias
                         .xmlns.test1
                //   And I create a child element
                         .Child
                //   And I use the second alias
                         .xmlns.test2
                //   And I use the child element
                         .Child
                //   And I end the list
                       .d
                //   And I save the results
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><test1:Child xmlns:test1=\"http://test1.com\" /><test2:Child xmlns:test2=\"http://test2.com\" /></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root xmlns:test1=\"http://test1.com\" xmlns:test2=\"http://test2.com\"><test1:Child /><test2:Child /></Root>", content);
                }
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "Cyclomatic complexity inflated due to interface flowing, this is exaggerated and not real. [tgs]")]
        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanUseLiteralToEscapeOutDynaXmlKeywords_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list
                         .b
                //   And I escape out a .b as an attribute
                           .at.l.b("root b value")
                //   And I escape out a .d as an attribute
                           .at.l.d("root d value")
                //   And I escape out a .b
                           .l.b
                //   And I escape out a .at
                           .l.at
                //   And I escape out a .l
                           .l.l
                //   And I escape out a .xmlns (default xmlns)
                           .l.xmlns("inner text")
                //   And I escape out a .xmlns (Namespace Definition Entry)
                           .l.xmlns
                //   And I escape out a .cdata block
                           .l.cdata("inner text")
                //   And I escape out a .d
                           .l.d
                //   And I escape out a .End
                           .l.End("inner text")
                //   And I escape out a .Save
                           .l.Save("inner text")
                //   And I add a child member "Child" to the builder
                           .Child
                //   And I start a list
                           .b
                //   And I escape out a .b as an attribute
                             .at.l.b("child 1 b value")
                //   And I escape out a .d as an attribute
                             .at.l.d("child 1 d value")
                //   And I escape out a .b
                             .l.b
                //   And I escape out a .at
                             .l.at
                //   And I escape out a .l
                             .l.l
                //   And I escape out a .xmlns (default xmlns)
                             .l.xmlns("inner text")
                //   And I escape out a .xmlns (Namespace Definition Entry)
                             .l.xmlns
                //   And I escape out a .cdata block
                             .l.cdata("inner text")
                //   And I escape out a .d
                             .l.d
                //   And I escape out a .End
                             .l.End("inner text")
                //   And I escape out a .Save
                             .l.Save("inner text")
                //   And I end the list
                           .d
                //   And I add an element
                           .Child
                //   And I start a list
                           .b
                //   And I escape out a .b as an attribute
                             .at.l.b("child 2 b value")
                //   And I escape out a .d as an attribute
                             .at.l.d("child 2 d value")
                //   And I escape out a .b
                             .l.b
                //   And I escape out a .at
                             .l.at
                //   And I escape out a .l
                             .l.l
                //   And I escape out a .xmlns (default xmlns)
                             .l.xmlns("inner text")
                //   And I escape out a .xmlns (Namespace Definition Entry)
                             .l.xmlns
                //   And I escape out a .cdata block
                             .l.cdata("inner text")
                //   And I escape out a .d
                             .l.d
                //   And I escape out a .End
                             .l.End("inner text")
                //   And I escape out a .Save
                             .l.Save("inner text")
                //   And I end the list
                           .d
                //   And I end the list
                         .d
                //   And I save the content
                         .Save(stream);
                //  Then the content of the saved file should be as _
                /*  <Root b="rood b value" d="root d value">
                 *    <b />
                 *    <at />
                 *    <l />
                 *    <xmlns>inner text</xmlns>
                 *    <xmlns />
                 *    <cdata>inner text</cdata>
                 *    <d />
                 *    <End>inner text</End>
                 *    <Save>inner text</Save>
                 *    <Child b="child 1 b value" d="child 1 d value">
                 *      <b />
                 *      <at />
                 *      <l />
                 *      <xmlns>inner text</xmlns>
                 *      <xmlns />
                 *      <cdata>inner text</cdata>
                 *      <d />
                 *      <End>inner text</End>
                 *      <Save>inner text</Save>
                 *    </Child>
                 *    <Child b="child 2 b value" d="child 2 d value">
                 *      <b />
                 *      <at />
                 *      <l />
                 *      <xmlns>inner text</xmlns>
                 *      <xmlns />
                 *      <cdata>inner text</cdata>
                 *      <d />
                 *      <End>inner text</End>
                 *      <Save>inner text</Save>
                 *    </Child>
                 *  </Root>
                 */
                // <Root b=\"root b value\" d=\"root d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save><Child b=\"child 1 b value\" d=\"child 1 d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save></Child><Child b=\"child 2 b value\" d=\"child 2 d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root b=\"root b value\" d=\"root d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save><Child b=\"child 1 b value\" d=\"child 1 d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save></Child><Child b=\"child 2 b value\" d=\"child 2 d value\"><b /><at /><l /><xmlns>inner text</xmlns><xmlns /><cdata>inner text</cdata><d /><End>inner text</End><Save>inner text</Save></Child></Root>",
                                    content);
                }
            }
        }


        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanEndProcessingWithoutHavingToHoldTheVariable_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false, Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I start a list of children
                           .b
                //   And I add a child called "SubSubChild"
                             .SubSubChild
                //   And I add an attribute attrib="value"
                //# NOTE: Attributes are applied to the last ancestor (started block)
                //# therefore this attribute applies to SubChild and not SubSubChild
                             .at.attrib("value")
                //   And I end the list of children
                           .d
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I end the line
                       .End();
                //   And I save the content
                builder.Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild attrib=\"value\"><SubSubChild /></SubChild><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild attrib=\"value\"><SubSubChild /></SubChild><SubChild /></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanSetpointALocationAndComeBackForLaterProcessing_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I start a list of children
                           .b
                //   And I add a child called "SubSubChild"
                             .SubSubChild
                //   And I add an attribute attrib="value"
                             .at.attrib("value")
                //   And I set a setpoint
                             .sp("setpoint1")
                //   And I end the list of children
                           .d
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I end the line of chaining
                       .End();
                //   And I go back to the setpoint and add another element.
                builder.rp("setpoint1")
                       .SubSubChild
                    //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild attrib=\"value\"><SubSubChild /><SubSubChild /></SubChild><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild attrib=\"value\"><SubSubChild /><SubSubChild /></SubChild><SubChild /></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void IfIApplyAnElementAfterStartingAListTheElementGoesWithTheNodeOfTheList_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                    //   And I start a list of children
                       .b
                    //   And I add a child member "Child" to the builder
                         .Child
                    //   And I start a list of children
                         .b
                    //   And I add an element attrib="value"
                           .at.attrib("value")
                    //   And I add a child called "SubChild"
                           .SubChild
                    //   And I add another child called "SubChild"
                           .SubChild
                    //   And I end the list of children
                         .d
                    //   And I end the list of children
                       .d
                    //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child attrib=\"value\"><SubChild /><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child attrib=\"value\"><SubChild /><SubChild /></Child></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void IfIApplyAnElementAfterStartingAListAndAddingAnElementTheElementGoesWithTheNodeOfTheList_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                    //   And I start a list of children
                       .b
                    //   And I add a child member "Child" to the builder
                         .Child
                    //   And I start a list of children
                         .b
                    //   And I add a child called "SubChild"
                           .SubChild
                    //   And I add an element attrib="value"
                    // #NOTE: attributes apply to the current ancestor not the last element created.
                           .at.attrib("value")
                    //   And I add another child called "SubChild"
                           .SubChild
                    //   And I end the list of children
                         .d
                    //   And I end the list of children
                       .d
                    //   And I save the builder
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child attrib=\"value\"><SubChild /><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child attrib=\"value\"><SubChild /><SubChild /></Child></Root>",
                                    content);
                }
            }
        }

        [TestMethod]
        [TestCategory("DynaXmlBuilder")]
        [TestCategory("CheckIn")]
        public void ICanCreateDynamicXmlWithAListOfSubChildElement_WithABuilder()
        {
            using (var stream = new MemoryStream())
            {
                // Given I have a DynamicXmlBuilder
                dynamic builder = DynaXmlBuilder.Create(false,
                                                        Formatting.None);
                //  When I add a member "Root" to the builder
                builder.Root
                //   And I start a list of children
                       .b
                //   And I add a child member "Child" to the builder
                         .Child
                //   And I start a list of children
                         .b
                //   And I add a child called "SubChild"
                           .SubChild
                //   And I add another child called "SubChild"
                           .SubChild
                //   And I end the list of children
                         .d
                //   And I end the list of children
                       .d
                //   And I end the list of children
                       .Save(stream);
                //  Then the content of the saved file should be as _
                //  <Root><Child><SubChild /><SubChild /></Child></Root>
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.AreEqual("<Root><Child><SubChild /><SubChild /></Child></Root>",
                                    content.Replace("\r\n",
                                                    string.Empty));
                }
            }
        }
    }
}