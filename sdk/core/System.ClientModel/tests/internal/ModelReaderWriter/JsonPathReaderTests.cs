// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathReaderTests
    {
        [Test]
        public void Read_RootToken_ReturnsCorrectly()
        {
            var reader = new JsonPathReader("$"u8);

            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);
            Assert.AreEqual(0, reader.Current.TokenStartIndex);
            Assert.AreEqual("$", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Read_SimpleProperty_AllTokensCorrect()
        {
            var reader = new JsonPathReader("$.property"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // Property separator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property
            Assert.IsTrue(reader.Read(), "Expected to read Property token");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("property", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // End
            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Read_QuotedString_ReturnsCorrectly()
        {
            var reader = new JsonPathReader("$['quoted-property']"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // Property separator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property
            Assert.IsTrue(reader.Read(), "Expected to read Property token");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("quoted-property", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Read_UnterminatedQuote_ThrowsException()
        {
            var reader = new JsonPathReader("$['unterminated"u8);

            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // Property separator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Unterminated quoted string in JsonPath", ex.Message);
            }

            Assert.IsTrue(exceptionThrown, "Expected ArgumentException for unterminated quote");
        }

        [Test]
        public void Read_ComplexPath_AllTokensCorrect()
        {
            var reader = new JsonPathReader("$.items[0].name"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property items
            Assert.IsTrue(reader.Read(), "Expected to read Property token (items)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("items", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // ArrayIndex 0
            Assert.IsTrue(reader.Read(), "Expected to read Number token (0)");
            Assert.AreEqual(JsonPathTokenType.ArrayIndex, reader.Current.TokenType);
            Assert.AreEqual("0", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property name
            Assert.IsTrue(reader.Read(), "Expected to read Property token (name)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("name", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // End
            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Read_UnsupportedFilterExpression_ParsedAsProperty()
        {
            var reader = new JsonPathReader("$[?(test"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Invalid JsonPath syntax at position 2: expected a property or array index after '['", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Expected FormatException for unsupported filter expression");
        }

        [Test]
        public void Read_WildcardOperator_ParsedAsProperty()
        {
            var reader = new JsonPathReader("$.*"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property *
            Assert.IsTrue(reader.Read(), "Expected to read Property token (*)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("*", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Current_InitialState_IsDefault()
        {
            var reader = new JsonPathReader("$.test"u8);

            // Compare properties individually since JsonPathToken doesn't have custom equality
            var defaultToken = default(JsonPathToken);
            Assert.AreEqual(defaultToken.TokenType, reader.Current.TokenType);
            Assert.AreEqual(defaultToken.TokenStartIndex, reader.Current.TokenStartIndex);
            Assert.IsTrue(reader.Current.ValueSpan.SequenceEqual(defaultToken.ValueSpan),
                $"Expected empty span but got '{Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray())}'");
        }

        [Test]
        public void Read_PropertyWithNumbers_ParsedCorrectly()
        {
            var reader = new JsonPathReader("$.x.2.y"u8);

            // Root $
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);
            Assert.AreEqual(0, reader.Current.TokenStartIndex);
            Assert.AreEqual("$", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator .
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property x
            Assert.IsTrue(reader.Read(), "Expected to read Property token (x)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("x", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator .
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property 2
            Assert.IsTrue(reader.Read(), "Expected to read Property token (2)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("2", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator .
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property y
            Assert.IsTrue(reader.Read(), "Expected to read Property token (y)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("y", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // End
            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [TestCase("$[0]", "")]
        [TestCase("$['complex path']", "$['complex path']")]
        [TestCase("$.x['complex path']", "$.x")]
        [TestCase("$.complex.path.here", "$.complex")]
        [TestCase("$", "")]
        [TestCase("$.property", "$.property")]
        public void GetFirstProperty(string jsonPath, string expected)
        {
            var reader = new JsonPathReader(jsonPath);

            var result = reader.GetFirstProperty();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result.ToArray()));
        }
    }
}
