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
                @"    /// </remarks>" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:A""></code>" + Environment.NewLine +
                "    foo" + Environment.NewLine +
                "        {",
                @"    /// </remarks>" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:A"">" + Environment.NewLine +
                $"    /// {Processed} </code>" + Environment.NewLine +
                "    foo" + Environment.NewLine +
                "        {"
            };

            yield return new[]
            {
                @"/// <code snippet=""Snippet:B""></code>",
                @"/// <code snippet=""Snippet:B"">" + Environment.NewLine +
                $"/// {Processed} </code>"
            };

            yield return new[]
            {
                @"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:C""></code>" + Environment.NewLine +
                "     foo",
                @"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:C"">" + Environment.NewLine +
                $"    /// {Processed} </code>" + Environment.NewLine +
                "     foo"
            };

            yield return new[]
            {
                @"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:Example"" example=""true""></code>" + Environment.NewLine +
                "     foo",
                @"    /// Example of enumerating an AsyncPageable using the <c> async foreach </c> loop:" + Environment.NewLine +
                @"    /// <example>" + Environment.NewLine +
                @"    /// <code snippet=""Snippet:Example"" example=""true"">" + Environment.NewLine +
                $"    /// {Processed} </code>" + Environment.NewLine +
                @"    /// </example>" + Environment.NewLine +
                "     foo"
            };
        }
    }
}