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
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property
            Assert.That(reader.Read(), Is.True, "Expected to read Property token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo(propertyName));
        }

        [Test]
        public void Read_RootToken_ReturnsCorrectly()
        {
            var reader = new JsonPathReader("$"u8);

            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));
            Assert.That(reader.Current.TokenStartIndex, Is.EqualTo(0));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("$"));

            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Read_SimpleProperty_AllTokensCorrect()
        {
            var reader = new JsonPathReader("$.property"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // Property separator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property
            Assert.That(reader.Read(), Is.True, "Expected to read Property token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("property"));

            // End
            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Read_QuotedString_ReturnsCorrectly()
        {
            var reader = new JsonPathReader("$['quoted-property']"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // Property separator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property
            Assert.That(reader.Read(), Is.True, "Expected to read Property token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("quoted-property"));

            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Read_IntegerPropertyName()
        {
            var reader = new JsonPathReader("$['123']"u8);

            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            Assert.That(reader.Read(), Is.True, "Expected to read Property token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("123"));

            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));
        }

        [Test]
        public void Read_UnterminatedQuote_ThrowsException()
        {
            var reader = new JsonPathReader("$['unterminated"u8);

            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // Property separator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Unterminated quoted string in JsonPath"));
            }

            Assert.That(exceptionThrown, Is.True, "Expected ArgumentException for unterminated quote");
        }

        [Test]
        public void Read_ComplexPath_AllTokensCorrect()
        {
            var reader = new JsonPathReader("$.items[0].name"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property items
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (items)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("items" ));

            // ArrayIndex 0
            Assert.That(reader.Read(), Is.True, "Expected to read Number token (0)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.ArrayIndex));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("0"));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property name
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (name)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("name"));

            // End
            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Read_UnsupportedFilterExpression_ParsedAsProperty()
        {
            var reader = new JsonPathReader("$[?(test"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Invalid JsonPath syntax at position 2: expected a property or positive array index after '['"));
            }
            Assert.That(exceptionThrown, Is.True, "Expected FormatException for unsupported filter expression");
        }

        [Test]
        public void Read_WildcardOperator_ParsedAsProperty()
        {
            var reader = new JsonPathReader("$.*"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property *
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (*)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("*"));

            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Current_InitialState_IsDefault()
        {
            var reader = new JsonPathReader("$.test"u8);

            // Compare properties individually since JsonPathToken doesn't have custom equality
            var defaultToken = default(JsonPathToken);
            Assert.That(defaultToken.TokenType, Is.EqualTo(reader.Current.TokenType));
            Assert.That(defaultToken.TokenStartIndex, Is.EqualTo(reader.Current.TokenStartIndex));
            Assert.That(reader.Current.ValueSpan.SequenceEqual(defaultToken.ValueSpan),
                $"Expected empty span but got '{Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray())}'");
        }

        [Test]
        public void Read_PropertyWithNumbers_ParsedCorrectly()
        {
            var reader = new JsonPathReader("$.x.2.y"u8);

            // Root $
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));
            Assert.That(reader.Current.TokenStartIndex, Is.EqualTo(0));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("$"));

            // PropertySeparator .
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property x
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (x)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("x"));

            // PropertySeparator .
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property 2
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (2)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("2"));

            // PropertySeparator .
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property y
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (y)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("y"));

            // End
            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
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
            Assert.That(Encoding.UTF8.GetString(result.ToArray()), Is.EqualTo(expected));
        }

        [Test]
        public void PropertyNameWithDot()
        {
            var reader = new JsonPathReader("$.foo['property.with.dot'].x"u8);

            // Root
            Assert.That(reader.Read(), Is.True, "Expected to read Root token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property foo
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (foo)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("foo"));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property property.with.dot
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (property.with.dot)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("property.with.dot"));

            // PropertySeparator
            Assert.That(reader.Read(), Is.True, "Expected to read PropertySeparator token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Property x
            Assert.That(reader.Read(), Is.True, "Expected to read Property token (x)");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("x"));

            // End
            Assert.That(reader.Read(), Is.True, "Expected to read End token");
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));

            Assert.That(reader.Read(), Is.False, "Should not be able to read past End token");
        }

        [Test]
        public void Peek_DoesNotAdvance()
        {
            var reader = new JsonPathReader("$.x.y"u8);

            // First token
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // Peek property separator
            var peek1 = reader.Peek();
            Assert.That(peek1.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));
            // After peek, current still root
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Root));

            // Read now moves to separator
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));

            // Peek property 'x'
            var peek2 = reader.Peek();
            Assert.That(peek2.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(peek2.ValueSpan.ToArray()), Is.EqualTo("x"));

            // Read property 'x'
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(reader.Current.ValueSpan.ToArray()), Is.EqualTo("x"));
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
            Assert.That(full.Advance(slice), Is.True);

            // After advance, next token should continue at '.c'
            Assert.That(full.Read(), Is.True); // Expect PropertySeparator
            Assert.That(full.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));
            Assert.That(full.Read(), Is.True); // Property c
            Assert.That(full.Current.TokenType, Is.EqualTo(JsonPathTokenType.Property));
            Assert.That(Encoding.UTF8.GetString(full.Current.ValueSpan.ToArray()), Is.EqualTo("c"));
        }

        [Test]
        public void Advance_PrefixMismatch_ReturnsFalse()
        {
            var full = new JsonPathReader("$.a.b.c"u8);
            Assert.That(full.Advance("$.x"u8), Is.False);
        }

        [Test]
        public void Read_Invalid_UnclosedBracket_Throws()
        {
            var reader = new JsonPathReader("$['foo'"u8);
            Assert.That(reader.Read(), Is.True); // $
            Assert.That(reader.Read(), Is.True); // separator
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Unterminated quoted string in JsonPath"));
            }
            Assert.That(exceptionThrown, Is.True, "Expected FormatException for unterminated quoted string");
        }

        [Test]
        public void Read_Invalid_OpenBracket_NoFollowup_Throws()
        {
            var reader = new JsonPathReader("$["u8);
            Assert.That(reader.Read(), Is.True); // root
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Invalid JsonPath syntax at position 2: expected a property or positive array index after '['"));
            }
            Assert.That(exceptionThrown, Is.True, "Expected FormatException for open bracket with no follow-up");
        }

        [Test]
        public void Read_Invalid_UnclosedArrayIndex_Throws()
        {
            var reader = new JsonPathReader("$[123"u8);
            Assert.That(reader.Read(), Is.True); // root
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Invalid JsonPath syntax at position 5: expected ']' after number"));
            }
            Assert.That(exceptionThrown, Is.True, "Expected FormatException for unclosed array index");
        }

        [Test]
        public void Read_Invalid_NegativeIndex_Throws()
        {
            var reader = new JsonPathReader("$.arr[-1]"u8);
            Assert.That(reader.Read(), Is.True); // root
            Assert.That(reader.Read(), Is.True); // separator
            Assert.That(reader.Read(), Is.True); // property arr
            bool exceptionThrown = false;
            try
            {
                reader.Read();
            }
            catch (FormatException ex)
            {
                exceptionThrown = true;
                Assert.That(ex.Message, Is.EqualTo("Invalid JsonPath syntax at position 6: expected a property or positive array index after '['"));
            }
            Assert.That(exceptionThrown, Is.True, "Expected FormatException for negative array index");
        }

        [Test]
        public void Read_TrailingDot_ParsesSeparatorThenEnd()
        {
            var reader = new JsonPathReader("$.foo."u8);
            Assert.That(reader.Read(), Is.True); // $
            Assert.That(reader.Read(), Is.True); // .
            Assert.That(reader.Read(), Is.True); // foo
            Assert.That(reader.Read(), Is.True); // trailing .
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.PropertySeparator));
            Assert.That(reader.Read(), Is.True);
            Assert.That(reader.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));
        }

        [Test]
        public void Peek_AfterEnd_ReturnsEnd()
        {
            var r = new JsonPathReader("$"u8);
            Assert.That(r.Read(), Is.True);
            Assert.That(r.Read(), Is.True); // End
            Assert.That(r.Current.TokenType, Is.EqualTo(JsonPathTokenType.End));
            var pk = r.Peek();
            Assert.That(pk.TokenType, Is.EqualTo(JsonPathTokenType.End));
            var pk2 = r.Peek();
            Assert.That(pk2.TokenType, Is.EqualTo(JsonPathTokenType.End));
        }
    }
}
