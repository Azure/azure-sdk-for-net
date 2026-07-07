// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    public class AllowListParserTests
    {
        [Test]
        public void Parse_EmptyText_ReturnsEmpty()
        {
            var result = AllowListParser.Parse(string.Empty);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_NullText_ReturnsEmpty()
        {
            var result = AllowListParser.Parse(null!);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_SkipsBlankLinesAndComments()
        {
            string text = @"
# This is a comment
   # Indented comment

nowarn:AZC0102
   # trailing blank line below

";
            var result = AllowListParser.Parse(text);
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0102"));
            Assert.That(result[0].IsScoped, Is.False);
        }

        [Test]
        public void Parse_NoWarn_WholeAssembly()
        {
            var result = AllowListParser.Parse("nowarn:AZC0034");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0034"));
            Assert.That(result[0].Target, Is.Null);
            Assert.That(result[0].IsScoped, Is.False);
        }

        [Test]
        public void Parse_NoWarn_IsCaseInsensitivePrefix()
        {
            var result = AllowListParser.Parse("NoWarn:AZC0034");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0034"));
        }

        [Test]
        public void Parse_NoWarn_ToleratesWhitespaceAfterColon()
        {
            var result = AllowListParser.Parse("nowarn:   AZC0034");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0034"));
        }

        [Test]
        public void Parse_Type_Target()
        {
            var result = AllowListParser.Parse("nowarn:AZC0034 T:Azure.Foo.Bar");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0034"));
            Assert.That(result[0].Target, Is.EqualTo("T:Azure.Foo.Bar"));
            Assert.That(result[0].IsScoped, Is.True);
        }

        [Test]
        public void Parse_Member_Target()
        {
            var result = AllowListParser.Parse("nowarn:AZC0007 M:Azure.Foo.Bar.#ctor(System.String)");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0007"));
            Assert.That(result[0].Target, Is.EqualTo("M:Azure.Foo.Bar.#ctor(System.String)"));
        }

        [Test]
        public void Parse_Namespace_Target()
        {
            var result = AllowListParser.Parse("nowarn:CS0618 N:Azure.Foo.Models");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("CS0618"));
            Assert.That(result[0].Target, Is.EqualTo("N:Azure.Foo.Models"));
        }

        [Test]
        public void Parse_TildePrefixIsStripped()
        {
            var result = AllowListParser.Parse("nowarn:AZC0034 ~T:Azure.Foo.Bar");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Target, Is.EqualTo("T:Azure.Foo.Bar"));
        }

        [Test]
        public void Parse_InvalidTargetPrefix_RejectsTheLine()
        {
            var result = AllowListParser.Parse("nowarn:AZC0034 X:Azure.Foo.Bar");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_MultipleEntries_Mixed()
        {
            string text = @"
nowarn:AZC0102
nowarn:AZC0034 T:Azure.Foo.Bar
# comment between entries
nowarn:CS0618 N:Azure.Foo.Models
";
            var result = AllowListParser.Parse(text);
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].Code, Is.EqualTo("AZC0102"));
            Assert.That(result[0].IsScoped, Is.False);
            Assert.That(result[1].Code, Is.EqualTo("AZC0034"));
            Assert.That(result[1].Target, Is.EqualTo("T:Azure.Foo.Bar"));
            Assert.That(result[2].Code, Is.EqualTo("CS0618"));
            Assert.That(result[2].Target, Is.EqualTo("N:Azure.Foo.Models"));
        }

        [Test]
        public void Parse_LineNumber_TracksOneBased()
        {
            string text = "# comment\n\nnowarn:AZC0102\nnowarn:AZC0034 T:Foo";
            var result = AllowListParser.Parse(text);
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0].LineNumber, Is.EqualTo(3));
            Assert.That(result[1].LineNumber, Is.EqualTo(4));
        }

        [Test]
        public void Parse_NoWarnWithoutCode_IsSkipped()
        {
            var result = AllowListParser.Parse("nowarn:");
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Parse_UnscopedEntry_StripsTrailingInlineComment()
        {
            var result = AllowListParser.Parse("nowarn:AZC0102 # explanatory comment");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0102"));
            Assert.That(result[0].Target, Is.Null);
            Assert.That(result[0].IsScoped, Is.False);
        }

        [Test]
        public void Parse_ScopedTypeEntry_StripsTrailingInlineComment()
        {
            var result = AllowListParser.Parse("nowarn:AZC0034 T:Azure.Foo.Bar # reason");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Code, Is.EqualTo("AZC0034"));
            Assert.That(result[0].Target, Is.EqualTo("T:Azure.Foo.Bar"));
        }

        [Test]
        public void Parse_ScopedNamespaceEntry_StripsTrailingInlineComment()
        {
            var result = AllowListParser.Parse("nowarn:CS0618 N:Azure.Foo.Models    # justification");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Target, Is.EqualTo("N:Azure.Foo.Models"));
        }

        [Test]
        public void Parse_ConstructorDocId_PreservesHashCtor()
        {
            var result = AllowListParser.Parse("nowarn:AZC0007 M:Azure.Foo.Bar.#ctor(System.String)");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Target, Is.EqualTo("M:Azure.Foo.Bar.#ctor(System.String)"));
        }

        [Test]
        public void Parse_ConstructorDocId_WithTrailingComment_PreservesHashCtorAndStripsComment()
        {
            var result = AllowListParser.Parse("nowarn:AZC0007 M:Azure.Foo.Bar.#ctor(System.String) # mocking exception");
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Target, Is.EqualTo("M:Azure.Foo.Bar.#ctor(System.String)"));
        }
    }
}
