// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class JsonPathReaderTests
    {
        [TestCase("$[\"\"foo\"]", "\"foo")]
        [TestCase("$[\"f\"oo\"]", "f\"oo")]
        [TestCase("$[\"foo\"\"]", "foo\"")]
        [TestCase("$['\'foo']", "'foo")]
        [TestCase("$['f\'oo']", "f'oo")]
        [TestCase("$['foo\'']", "foo'")]
        [TestCase("$.\"foo", "\"foo")]
        [TestCase("$.f\"oo", "f\"oo")]
        [TestCase("$.foo\"", "foo\"")]
        [TestCase("$.\'foo", "'foo")]
        [TestCase("$.f\'oo", "f'oo")]
        [TestCase("$.foo\'", "foo'")]
        [TestCase("$['foo bar']", "foo bar")]
        [TestCase("$['foo-bar']", "foo-bar")]
        [TestCase("$['foo_bar']", "foo_bar")]
        [TestCase("$['foo.bar']", "foo.bar")]
        [TestCase("$['foo,bar']", "foo,bar")]
        [TestCase("$['foo:bar']", "foo:bar")]
        [TestCase("$['foo;bar']", "foo;bar")]
        [TestCase("$['foo/bar']", "foo/bar")]
        [TestCase("$['foo\\\\bar']", "foo\\\\bar")]
        [TestCase("$['foo/bar\\\\baz']", "foo/bar\\\\baz")]
        [TestCase("$['foo[bar]']", "foo[bar]")]
        [TestCase("$['foo{bar}']", "foo{bar}")]
        [TestCase("$['foo(bar)']", "foo(bar)")]
        [TestCase("$['foo@bar']", "foo@bar")]
        [TestCase("$['foo#bar']", "foo#bar")]
        [TestCase("$['foo$bar']", "foo$bar")]
        [TestCase("$['foo%bar']", "foo%bar")]
        [TestCase("$['foo^bar']", "foo^bar")]
        [TestCase("$['foo&bar']", "foo&bar")]
        [TestCase("$['foo*bar']", "foo*bar")]
        [TestCase("$['foo!bar']", "foo!bar")]
        [TestCase("$['foo?bar']", "foo?bar")]
        [TestCase("$['foo=bar']", "foo=bar")]
        [TestCase("$['foo<bar>']", "foo<bar>")]
        [TestCase("$['foo|bar']", "foo|bar")]
        [TestCase("$['foo~bar']", "foo~bar")]
        [TestCase("$['foo`bar']", "foo`bar")]
        [TestCase("$['foo\u263Abar']", "foo\u263Abar")]
        [TestCase("$['']", "")]
        [TestCase("$.''", "''")]
        [TestCase("$['foo''bar']", "foo''bar")]
        [TestCase("$['foo\"bar']", "foo\"bar")]
        [TestCase("$['foo\nbar']", "foo\nbar")]
        [TestCase("$['foo\tbar']", "foo\tbar")]
        [TestCase("$['foo\rbar']", "foo\rbar")]
        public void Read_SpecialCharacter(string jsonPath, string propertyName)
        {
            JsonPathReader reader = new(jsonPath);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property
            Assert.IsTrue(reader.Read(), "Expected to read Property token");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual(propertyName, Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));
        }

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
        public void Read_IntegerPropertyName()
        {
            var reader = new JsonPathReader("$['123']"u8);

            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            Assert.IsTrue(reader.Read(), "Expected to read Property token");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("123", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);
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
                Assert.AreEqual("Invalid JsonPath syntax at position 2: expected a property or positive array index after '['", ex.Message);
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

        [TestCase("$.x", "$.x")]
        [TestCase("$[0]", "$[0]")]
        [TestCase("$.x[0]", "$.x")]
        [TestCase("$[0].x", "$[0]")]
        [TestCase("$['complex path']", "$['complex path']")]
        [TestCase("$.x['complex path']", "$.x")]
        [TestCase("$.complex.path.here", "$.complex")]
        [TestCase("$", "$")]
        [TestCase("$.property", "$.property")]
        [TestCase("$['property.with.dot'].x", "$['property.with.dot']")]
        public void GetFirstProperty(string jsonPath, string expected)
        {
            var reader = new JsonPathReader(jsonPath);

            var result = reader.GetFirstProperty();
            Assert.AreEqual(expected, Encoding.UTF8.GetString(result.ToArray()));
        }

        [Test]
        public void PropertyNameWithDot()
        {
            var reader = new JsonPathReader("$.foo['property.with.dot'].x"u8);

            // Root
            Assert.IsTrue(reader.Read(), "Expected to read Root token");
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property foo
            Assert.IsTrue(reader.Read(), "Expected to read Property token (foo)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("foo", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property property.with.dot
            Assert.IsTrue(reader.Read(), "Expected to read Property token (property.with.dot)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("property.with.dot", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // PropertySeparator
            Assert.IsTrue(reader.Read(), "Expected to read PropertySeparator token");
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Property x
            Assert.IsTrue(reader.Read(), "Expected to read Property token (x)");
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("x", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));

            // End
            Assert.IsTrue(reader.Read(), "Expected to read End token");
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);

            Assert.IsFalse(reader.Read(), "Should not be able to read past End token");
        }

        [Test]
        public void Peek_DoesNotAdvance()
        {
            var reader = new JsonPathReader("$.x.y"u8);

            // First token
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // Peek property separator
            var peek1 = reader.Peek();
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, peek1.TokenType);
            // After peek, current still root
            Assert.AreEqual(JsonPathTokenType.Root, reader.Current.TokenType);

            // Read now moves to separator
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);

            // Peek property 'x'
            var peek2 = reader.Peek();
            Assert.AreEqual(JsonPathTokenType.Property, peek2.TokenType);
            Assert.AreEqual("x", Encoding.UTF8.GetString(peek2.ValueSpan.ToArray()));

            // Read property 'x'
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(JsonPathTokenType.Property, reader.Current.TokenType);
            Assert.AreEqual("x", Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()));
        }

        [Test]
        public void Advance_ByPrefix()
        {
            var full = new JsonPathReader("$.a.b.c"u8);
            var prefixReader = new JsonPathReader("$.a.b"u8);

            // Consume prefix in prefixReader fully (simulate external usage)
            while (prefixReader.Read() && prefixReader.Current.TokenType != JsonPathTokenType.End)
            { }

            // Now advance 'full' reader using parsed prefix slice
            var slice = Encoding.UTF8.GetBytes("$.a.b");
            Assert.IsTrue(full.Advance(slice));

            // After advance, next token should continue at '.c'
            Assert.IsTrue(full.Read()); // Expect PropertySeparator
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, full.Current.TokenType);
            Assert.IsTrue(full.Read()); // Property c
            Assert.AreEqual(JsonPathTokenType.Property, full.Current.TokenType);
            Assert.AreEqual("c", Encoding.UTF8.GetString(full.Current.ValueSpan.ToArray()));
        }

        [Test]
        public void Advance_PrefixMismatch_ReturnsFalse()
        {
            var full = new JsonPathReader("$.a.b.c"u8);
            Assert.IsFalse(full.Advance("$.x"u8));
        }

        [Test]
        public void Read_Invalid_UnclosedBracket_Throws()
        {
            var reader = new JsonPathReader("$['foo'"u8);
            Assert.IsTrue(reader.Read()); // $
            Assert.IsTrue(reader.Read()); // separator
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
            Assert.IsTrue(exceptionThrown, "Expected FormatException for unterminated quoted string");
        }

        [Test]
        public void Read_Invalid_OpenBracket_NoFollowup_Throws()
        {
            var reader = new JsonPathReader("$["u8);
            Assert.IsTrue(reader.Read()); // root
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Invalid JsonPath syntax at position 2: expected a property or positive array index after '['", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Expected FormatException for open bracket with no follow-up");
        }

        [Test]
        public void Read_Invalid_UnclosedArrayIndex_Throws()
        {
            var reader = new JsonPathReader("$[123"u8);
            Assert.IsTrue(reader.Read()); // root
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Invalid JsonPath syntax at position 5: expected ']' after number", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Expected FormatException for unclosed array index");
        }

        [Test]
        public void Read_Invalid_NegativeIndex_Throws()
        {
            var reader = new JsonPathReader("$.arr[-1]"u8);
            Assert.IsTrue(reader.Read()); // root
            Assert.IsTrue(reader.Read()); // separator
            Assert.IsTrue(reader.Read()); // property arr
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("Invalid JsonPath syntax at position 6: expected a property or positive array index after '['", ex.Message);
            }
            Assert.IsTrue(exceptionThrown, "Expected FormatException for negative array index");
        }

        [Test]
        public void Read_TrailingDot_ParsesSeparatorThenEnd()
        {
            var reader = new JsonPathReader("$.foo."u8);
            Assert.IsTrue(reader.Read()); // $
            Assert.IsTrue(reader.Read()); // .
            Assert.IsTrue(reader.Read()); // foo
            Assert.IsTrue(reader.Read()); // trailing .
            Assert.AreEqual(JsonPathTokenType.PropertySeparator, reader.Current.TokenType);
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(JsonPathTokenType.End, reader.Current.TokenType);
        }

        [Test]
        public void Peek_AfterEnd_ReturnsEnd()
        {
            var r = new JsonPathReader("$"u8);
            Assert.IsTrue(r.Read());
            Assert.IsTrue(r.Read()); // End
            Assert.AreEqual(JsonPathTokenType.End, r.Current.TokenType);
            var pk = r.Peek();
            Assert.AreEqual(JsonPathTokenType.End, pk.TokenType);
            var pk2 = r.Peek();
            Assert.AreEqual(JsonPathTokenType.End, pk2.TokenType);
        }
    }
}
