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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json.Parser;
    using TechTalk.SpecFlow;

    [Binding]
    public class JsonParserSteps : DisposableObject
    {
        private string jsonContent;
        private ParseBuffer buffer;
        private JsonItem jsonItem;

        [Given(@"I have the following json content:")]
        public void GivenIHaveTheFollowingJsonContent(string content)
        {
            this.jsonContent = content;
        }

        [Given(@"I have the json content '(.*)'")]
        public void GivenIHaveTheJsonContent(string content)
        {
            this.jsonContent = content;
        }

        [When(@"I parse the content as a json (.*)")]
        public void WhenIParseTheContentAsAJsonString(string type)
        {
            this.buffer = new ParseBuffer(this.jsonContent);
            if (type == "string")
            {
                this.jsonItem = new JsonStringParser(buffer).ParseNext();
            }
            else if (type == "number")
            {
                this.jsonItem = new JsonNumberParser(buffer).ParseNext();
            }
            else if (type == "boolean")
            {
                this.jsonItem = new JsonBooleanParser(buffer).ParseNext();
            }
            else if (type == "null")
            {
                this.jsonItem = new JsonNullParser(buffer).ParseNext();
            }
            else
            {
                Assert.Fail("unknown parser type.");
            }
        }

        [Then(@"the next character on the parser buffer is a '(.)'")]
        public void ThenTheNextCharacterOnTheParseBufferIsA(char character)
        {
            char readChar;
            Assert.IsTrue(this.buffer.PeekNext(out readChar));
            Assert.AreEqual(character, readChar, "the character '{0}' was expected to be on the buffer but instead '{1}' was found", character, readChar);
        }

        [Then(@"the parsed json item should not be an error")]
        public void ThenTheParsedJsonItemShouldNotBeAnError()
        {
            if (this.jsonItem.IsError)
            {
                Assert.Fail("the following error occurred in parsing '{0}'", ((JsonParseError)this.jsonItem).Message);
            }
        }

        [Then(@"the parsed json item should be an? (.*)")]
        public void ThenTheParsedJsonItemShouldBeAnInteger(string type)
        {
            if (type == "integer")
            {
                Assert.IsTrue(this.jsonItem.IsInteger, "The value should be a JsonInteger but instead is a {0}", this.jsonItem.GetType().Name);
            }
            else if (type == "float")
            {
                Assert.IsTrue(this.jsonItem.IsFloat, "The value should be a JsonFloat but instead is a {0}", this.jsonItem.GetType().Name);
            }
            else if (type == "boolean")
            {
                Assert.IsTrue(this.jsonItem.IsBoolean, "The value should be a JsonBoolean but instead is a {0}", this.jsonItem.GetType().Name);
            }
            else if (type == "null")
            {
                Assert.IsTrue(this.jsonItem.IsNull, "The value should be a JsonNull but instead is a {0}", this.jsonItem.GetType().Name);
            }
            else if (type == "error")
            {
                Assert.IsTrue(this.jsonItem.IsError, "The value should be a JsonParseError but instead is a {0}", this.jsonItem.GetType().Name);
            }
            else
            {
                Assert.Fail("unknown json object type.");
            }
        }


        [Then(@"the parsed json integer should have a value of (-?\d+)")]
        public void ThenTheValueOfTheParsedJsonIntegerShouldBe(long value)
        {
            long asLong;
            this.jsonItem.TryGetValue(out asLong);
            Assert.AreEqual(value, asLong);
        }

        [Then(@"the parsed json float should have a value of (-?\d+(?:.\d+)?(?:[eE][+\-]?\d+)?)")]
        public void ThenTheValueOfTheParsedJsonFloatShouldBe(double value)
        {
            double asDouble;
            this.jsonItem.TryGetValue(out asDouble);
            Assert.AreEqual(value, asDouble);
        }

        [Then(@"the parsed json item should be a string")]
        public void ThenTheParsedItemShouldBeAString()
        {
            Assert.IsTrue(this.jsonItem.IsString);
        }

        [Then(@"the parsed json boolean should have a value of (true|false)")]
        public void TheParsedJsonBooleanShouldHaveAValueOf(bool value)
        {
            bool readBoolean;
            Assert.IsTrue(this.jsonItem.TryGetValue(out readBoolean));
            Assert.AreEqual(value, readBoolean);
        }

        [Then(@"the parsed json string should have a value of: (.*)")]
        public void AndTheValueOfTheparsedJsonStringShouldBe(string value)
        {
            string asString;
            this.jsonItem.TryGetValue(out asString);
            Assert.AreEqual(value, asString);
        }
    }
}
