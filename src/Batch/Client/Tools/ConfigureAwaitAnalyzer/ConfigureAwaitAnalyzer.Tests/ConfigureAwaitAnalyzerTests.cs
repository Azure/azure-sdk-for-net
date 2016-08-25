// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace ConfigureAwaitAnalyzerTests
{
    using System;
    using ConfigureAwaitAnalyzer;
    using Helpers;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Xunit;

    public class ConfigureAwaitAnalyzerTests : DiagnosticVerifier
    {
        private static readonly string ExpectedFileName = $"{DefaultFilePathPrefix}0.{CSharpDefaultFileExt}";

        [Fact]
        public void TestEmptyCodeBlock_ShouldBeNoError()
        {
            var test = @"";

            this.VerifyCSharpDiagnostic(test);
        }

        [Fact]
        public void TestAwaitWithNoConfigureAwait_ShouldBeError()
        {
            var test = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        public class TypeName
        {
            public static async Task Test()
            {
                await Task.Delay(0);
            }
        }
    }";
            this.VerifyCSharpDiagnostic(test, BuildExpectedResult(15, 17));
        }

        [Fact]
        public void TestAwaitWithConfigureAwaitTrue_ShouldBeError()
        {
            var test = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        public class TypeName
        {
            public static async Task Test()
            {
                await Task.Delay(0).ConfigureAwait(true);
            }
        }
    }";
            this.VerifyCSharpDiagnostic(test, BuildExpectedResult(15, 17));
        }

        [Fact]
        public void TestAwaitWithConfigureAwaitFalse_ShouldBeNoError()
        {
            var test = @"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    namespace ConsoleApplication1
    {
        public class TypeName
        {
            public static async Task Test()
            {
                await Task.Delay(0).ConfigureAwait(false);
                await Task.Delay(0).ConfigureAwait(continueOnCapturedContext: false);
            }
        }
    }";
            this.VerifyCSharpDiagnostic(test);
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new ConfigureAwaitAnalyzer();
        }

        protected override DiagnosticAnalyzer GetBasicDiagnosticAnalyzer()
        {
            throw new NotSupportedException("VB is not supported");
        }

        private static DiagnosticResult BuildExpectedResult(int line, int column)
        {
            return new DiagnosticResult
                {
                    Id = ConfigureAwaitAnalyzer.DiagnosticId,
                    Message = ConfigureAwaitAnalyzer.MessageFormat,
                    Severity = DiagnosticSeverity.Warning,
                    Locations =
                        new[] {
                                new DiagnosticResultLocation(ExpectedFileName, line, column)
                            }
                };
        }
    }
}