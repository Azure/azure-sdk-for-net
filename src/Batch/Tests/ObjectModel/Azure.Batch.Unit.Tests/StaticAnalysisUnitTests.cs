namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BatchTestCommon;
    using TestUtilities;
    using Xunit;
    using Xunit.Abstractions;

    public class StaticAnalysisUnitTests
    {
        private readonly string sourceLocation;
        private readonly string proxySourceLocation;

        private readonly IReadOnlyList<string> sourceLocationsToScan;

        private const string SourceFileType = @".*\.cs";
        private readonly ITestOutputHelper testOutputHelper;

        private const string GeneratedProtocolFolder = "GeneratedProtocol";

        public StaticAnalysisUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            this.sourceLocation = @"..\..\..\..\..\src";
            this.proxySourceLocation = @"..\..\..\..\..\src\" + GeneratedProtocolFolder;

            this.sourceLocationsToScan = new List<string>()
                                         {
                                             this.sourceLocation
                                         };
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void AwaitAlwaysFollowedByConfigureAwaitFalse()
        {
            //What this expression means:
            //(?<!//.*?) -- Make sure that any await we find is not preceeded on the same line by //
            //(?s: -- means . will match newlines in this sub-expression.
            //await\\s+ -- Find the word await followed by at least 1 whitespace character
            //.*?(;|$|ConfigureAwait\\(.*?false\\)) -- After the await stop matching if
            //we see a ;, the end of the file, or the string "ConfigureAwait(<text>false)" where
            //<text> can be any characters but not newline.
            const string pattern = "(?<!//.*?)(?s:await\\s+.*?(;|$|ConfigureAwait\\([\\w\\W]*?false\\)))";

            SourceParser sourceParser = new SourceParser(this.sourceLocationsToScan, SourceFileType, null, pattern);

            List<SourceParserResult> results = sourceParser.Parse().ToList();

            //Some sanity on the number of results we have
            const int expectedAtLeastThisManyAwaits = 350;
            this.testOutputHelper.WriteLine("Found {0} awaits", results.Count);
            Assert.True(results.Count > expectedAtLeastThisManyAwaits);

            foreach (SourceParserResult parserResult in results)
            {
                Match match = parserResult.Match;
                int configureAwaitCount = Regex.Matches(match.Value, "ConfigureAwait").Count;
                int awaitCount = Regex.Matches(match.Value, "await").Count;

                if (awaitCount == 1)
                {
                    if (configureAwaitCount == 0)
                    {
                        //Didn't find configureawait
                        string message = string.Format("No ConfigureAwait in {0} at {1} -- {2}", parserResult.File, parserResult.LineNumber, match.Value);
                        this.testOutputHelper.WriteLine(message);

                        Assert.True(false, message);
                    }
                    else if (configureAwaitCount == 1)
                    {
                        //Found configureawait
                        this.testOutputHelper.WriteLine("Found ConfigureAwait in {0} at {1} -- {2}", parserResult.File, parserResult.LineNumber, match.Value);
                    }
                    else
                    {
                        string message =
                            string.Format("Found more than 1 ConfigureAwait in substring, which is not expected.  File: {0}, Line: {1}, String: {2}",
                                parserResult.File,
                                parserResult.LineNumber,
                                parserResult.Match.Value);

                        Assert.True(false, message);
                    }
                }
                else
                {
                    string message =
                            string.Format("Found more than 1 Await in substring, which is not expected.  File: {0}, Line: {1}, String: {2}",
                                parserResult.File,
                                parserResult.LineNumber,
                                parserResult.Match.Value);

                    Assert.True(false, message);
                }
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ExceptionsThrownDirectlyByRestProxyDontChange()
        {
            const string exceptionNameCaptureGroup = "ExceptionName";
            string pattern = GetExceptionCaptureRegex(exceptionNameCaptureGroup);

            SourceParser sourceParser = new SourceParser(this.proxySourceLocation, SourceFileType, null, pattern);

            List<SourceParserResult> results = sourceParser.Parse().ToList();

            //Ensure we've scanned at least some files...
            const int expectedExceptionCount = 100;
            this.testOutputHelper.WriteLine("Found {0} \"throw new Exception\" strings", results.Count);
            Assert.True(results.Count > expectedExceptionCount);

            HashSet<string> exceptionSet = new HashSet<string>();

            foreach (SourceParserResult parserResult in results)
            {
                string exceptionName = parserResult.Match.Groups[exceptionNameCaptureGroup].Value;
                exceptionSet.Add(exceptionName);
            }

            this.testOutputHelper.WriteLine("Found {0} types of exception thrown by rest proxy", exceptionSet.Count);
            this.testOutputHelper.WriteLine("Exceptions:");
            this.testOutputHelper.WriteLine("------------------------");
            foreach (string exceptionType in exceptionSet)
            {
                this.testOutputHelper.WriteLine("{0}", exceptionType);
            }

            IReadOnlyCollection<string> expectedExceptions = new List<string>()
                                                             {
                                                                 "ArgumentNullException",
                                                                 "ValidationException",
                                                                 "SerializationException"
                                                             };
            Assert.Equal(expectedExceptions, exceptionSet);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ExceptionsThrownDirectlyByObjectModelDontChange()
        {
            const string exceptionNameCaptureGroup = "ExceptionName";
            string pattern = GetExceptionCaptureRegex(exceptionNameCaptureGroup);

            SourceParser sourceParser = new SourceParser(this.sourceLocation, SourceFileType, GeneratedProtocolFolder, pattern);

            List<SourceParserResult> results = sourceParser.Parse().ToList();

            //Ensure we've scanned at least some files...
            const int expectedExceptionCount = 50;
            this.testOutputHelper.WriteLine("Found {0} \"throw new Exception\" strings", results.Count);
            Assert.True(results.Count > expectedExceptionCount);

            HashSet<string> exceptionSet = new HashSet<string>();

            foreach (SourceParserResult parserResult in results)
            {
                string exceptionName = parserResult.Match.Groups[exceptionNameCaptureGroup].Value;
                exceptionSet.Add(exceptionName);
            }

            this.testOutputHelper.WriteLine("Found {0} types of exception thrown by object model", exceptionSet.Count);
            this.testOutputHelper.WriteLine("Exceptions:");
            this.testOutputHelper.WriteLine("------------------------");
            foreach (string exceptionType in exceptionSet)
            {
                this.testOutputHelper.WriteLine("{0}", exceptionType);
            }

            var expectedExceptions = new HashSet<string>
                 {
                     "ArgumentNullException",
                     "AddTaskCollectionTerminatedException",
                     "BatchClientException",
                     "RunOnceException",
                     "TimeoutException",
                     "ArgumentOutOfRangeException",
                     "InvalidOperationException",
                     "ArgumentException",
                     "FileNotFoundException",
                     "ParallelOperationsException",
                 };

            Assert.Equal(expectedExceptions.OrderBy(e => e), exceptionSet.OrderBy(e => e));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void DotWaitAndDotResultAreNeverUsed()
        {
            //TODO: We should use Roslyn to do this

            //What this expression means:
            //(?<!//.*?) -- Make sure that any await we find is not preceeded on the same line by //
            //(?s: -- means . will match newlines in this sub-expression.
            //\\.Wait\\(\\) -- matches .Wait()
            //\\.Result(\\.|;|\\s|,) -- matches .Result followed by a ., ;, whitespace, or ,
            const string pattern = "(?<!//.*?)(?s:(\\.Wait\\(\\)|\\.Result(\\.|;|\\s|,)))";

            SourceParser sourceParser = new SourceParser(this.sourceLocation, SourceFileType, null, pattern);

            List<SourceParserResult> results = sourceParser.Parse().ToList();

            //There should be no .Result or .Wait() calls outside of the two which are expected below
            //Remove the two we expect
            results.Remove(results.First(r => r.File.Contains("UtilitiesInternal.cs")));
            results.Remove(results.First(r => r.File.Contains("SynchronousMethodExceptionBehavior.cs")));
            
            foreach (SourceParserResult parserResult in results)
            {
                this.testOutputHelper.WriteLine("Found .Wait or .Result in {0} at {1} -- {2}", parserResult.File, parserResult.LineNumber, parserResult.Match);
            }

            Assert.Equal(0, results.Count);
        }

        #region Private helpers

        private static string GetExceptionCaptureRegex(string exceptionNameCaptureGroup)
        {
            //TODO: Note that this misses anything like "throw ex;" since it's missing the new -- we should try to  use
            //TODO: Roslyn or something else to do a better job of this.
            //What this expression means:
            //(?<!//.*?) - make sure any throw we find is not on a line which starts with //'s
            //(throw\\s+?new - find "throw new" with any number of whitespace characters seperating them (on the same line)
            //\\s+(?<{0}>\\w+?)\\( - find everything after the "new" in the previous part of the expression which is a
            //                       "word" character (alphanumeric), and comes before the next "(" character
            //                       and store it in the group named "ExceptionName"

            string pattern = string.Format("(?<!//.*?)(throw\\s+?new\\s+(?<{0}>\\w+?)\\()", exceptionNameCaptureGroup);

            return pattern;
        }

        #endregion
    }
}
