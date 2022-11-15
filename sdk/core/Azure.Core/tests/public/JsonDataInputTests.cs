// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    internal class JsonDataInputTests
    {
        [Test]
        public void CanSetEachProperty()
        {
            // Idea 1
            dynamic input = RequestContent.CreateDynamic(/*optional serializer options*/);
            input.analysisInput.conversationItem.text = "Send an email to Carol about tomorrow's demo";
            input.analysisInput.conversationItem.id = "1";
            input.analysisInput.conversationItem.participantId = "1";
            input.parameters.projectName = "MyProject";
            input.parameters.deploymentName = "MyDeployment";
            input.parameters.stringIndexType = "Utf16CodeUnit";
            input.kind = "Conversation";

            Assert.AreEqual("Send an email to Carol about tomorrow's demo", (string)input.analysisInput.conversationItem.text);
            Assert.AreEqual("Utf16CodeUnit", (string)input.parameters.stringIndexType);
            Assert.AreEqual("Conversation", (string)input.kind);
        }

        [Test]
        public void CanSetWithAnonymousTypes()
        {
            // Idea 2
            dynamic input = RequestContent.CreateDynamic(/*optional serializer options*/);
            input.kind = "Conversation";
            input.analysisInput.conversationItem = new
            {
                text = "Send an email to Carol about tomorrow's demo",
                id = "1",
                participantId = "1",
            };
            input.parameters = new
            {
                projectName = "MyProject",
                deploymentName = "MyDeployment",

                // Use Utf16CodeUnit for strings in .NET.
                stringIndexType = "Utf16CodeUnit",
            };

            Assert.AreEqual("Send an email to Carol about tomorrow's demo", (string)input.analysisInput.conversationItem.text);
            Assert.AreEqual("Utf16CodeUnit", (string)input.parameters.stringIndexType);
            Assert.AreEqual("Conversation", (string)input.kind);
        }

        [Test]
        public void CanSetToTopLevelArray()
        {
            dynamic input = RequestContent.CreateDynamic(new int[] { 1, 2, 3 } /*, optional serializer options*/);

            Assert.AreEqual(3, input.Length);
            Assert.AreEqual(1, (int)input[0]);
            Assert.AreEqual(2, (int)input[1]);
            Assert.AreEqual(3, (int)input[2]);
        }

        [Test]
        public void CanAddArrayValues()
        {
            // Idea: mimic Collection interface.
            dynamic input = RequestContent.CreateDynamic(new int[] { 1, 2, 3 } /*, optional serializer options*/);
            input.Add(4);

            // [ 1, 2, 3, 4 ]
            Assert.AreEqual(4, input.Length);

            //// Needs implementation of equality.
            //input.Remove(2);

            //// [ 1, 3, 4 ]
            //Assert.AreEqual(3, input.Length);
            //Assert.AreEqual(1, (int)input[0]);
            //Assert.AreEqual(3, (int)input[1]);
            //Assert.AreEqual(4, (int)input[2]);

            input.RemoveAt(0);

            // [ 2, 3, 4 ]
            Assert.AreEqual(3, input.Length);
            Assert.AreEqual(2, (int)input[0]);
            Assert.AreEqual(3, (int)input[1]);
            Assert.AreEqual(4, (int)input[2]);

            input[0] = 5;

            // [ 5, 3, 4 ]
            Assert.AreEqual(3, input.Length);
            Assert.AreEqual(5, (int)input[0]);
            Assert.AreEqual(3, (int)input[1]);
            Assert.AreEqual(4, (int)input[2]);
        }

        [Test]
        public void CanAddArrayValuesToProperties()
        {
            // Idea: mimic Collection interface.
            dynamic input = RequestContent.CreateDynamic(/*optional serializer options*/);
            input.ArrayProperty = new int[] { 1, 2, 3 };

            input.ArrayProperty.Add(4);

            // [ 1, 2, 3, 4 ]
            Assert.AreEqual(4, input.ArrayProperty.Length);

            //input.ArrayProperty.Remove(2);

            //// [ 1, 3, 4 ]
            //Assert.AreEqual(3, input.ArrayProperty.Length);
            //Assert.AreEqual(1, (int)input.ArrayProperty[0]);
            //Assert.AreEqual(3, (int)input.ArrayProperty[1]);
            //Assert.AreEqual(4, (int)input.ArrayProperty[2]);

            input.ArrayProperty.RemoveAt(0);

            // [ 2, 3, 4 ]
            Assert.AreEqual(3, input.ArrayProperty.Length);
            Assert.AreEqual(2, (int)input.ArrayProperty[0]);
            Assert.AreEqual(3, (int)input.ArrayProperty[1]);
            Assert.AreEqual(4, (int)input.ArrayProperty[2]);

            input.ArrayProperty[0] = 5;

            // [ 5, 3, 4 ]
            Assert.AreEqual(3, input.ArrayProperty.Length);
            Assert.AreEqual(5, (int)input.ArrayProperty[0]);
            Assert.AreEqual(3, (int)input.ArrayProperty[1]);
            Assert.AreEqual(4, (int)input.ArrayProperty[2]);
        }

        // TODO: Add negative tests, e.g. showing you can't call Add an array value to an Object.
    }
}
