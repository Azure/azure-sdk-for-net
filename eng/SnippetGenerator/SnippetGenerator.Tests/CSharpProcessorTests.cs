using System;
using System.Collections.Generic;
using NUnit.Framework;
using SnippetGenerator;

namespace SnippetGenerator.Tests
{
    public class Tests
    {
        private const string Processed = "processed";

        [Test]
        [TestCaseSource(nameof(CodeInputs))]
        public void CSharpProcsesorFindsCodeXMLDocs(string code, string expected)
        {
            var actual = CSharpProcessor.Process(code, SnippetProvider);
            Assert.AreEqual(expected, actual);
        }

        private string SnippetProvider(string s) => Processed;

        public static IEnumerable<object[]> CodeInputs()
        {
            yield return new[]
            {
                @"   /// </remarks>
    /// <code snippet=""Snippet:A""></code>
    foo
        {",
                $@"   /// </remarks>
    /// <code snippet=""Snippet:A"">
    /// {Processed} </code>
    foo
        {{",
            };

            yield return new[]
            {
                @"/// <code snippet=""Snippet:B""></code>",
                $@"/// <code snippet=""Snippet:B"">
/// {Processed} </code>"
            };

            yield return new[]
            {
                @"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:
    /// <code snippet=""Snippet:C""></code>
    foo",
                $@"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:
    /// <code snippet=""Snippet:C"">
    /// {Processed} </code>
    foo"
            };
        }
    }
}