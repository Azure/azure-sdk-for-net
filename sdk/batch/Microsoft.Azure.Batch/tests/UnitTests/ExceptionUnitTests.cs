// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Common;
    using Xunit;
    using Xunit.Abstractions;
    using BatchError = Microsoft.Azure.Batch.BatchError;

    public class ExceptionUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public ExceptionUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CustomAggregateToStringIncludesCallstack()
        {
            Guid clientRequestId = Guid.NewGuid();
            
            BatchException e1 = ThrowWithStack<BatchException>(() => {
                throw new BatchException(new RequestInformation()
                    {
                        BatchError = new BatchError(new Microsoft.Azure.Batch.Protocol.Models.BatchError(code: "Foo")),
                        ClientRequestId = clientRequestId,
                    },
                    "Test",
                    null); } );
            ArgumentNullException e2 = ThrowWithStack<ArgumentNullException>(() =>
                {
                    throw new ArgumentNullException();
                });
            
            ParallelOperationsException parallelOperationsException = new ParallelOperationsException(new Exception[] {e1, e2});
            string exceptionText = parallelOperationsException.ToString();

            Assert.Contains(typeof(ParallelOperationsException).Name, exceptionText);
            Assert.Contains("Exception #0", exceptionText);
            Assert.Contains("Exception #1", exceptionText);
            Assert.Contains("One or more errors occurred", exceptionText);

            //Ensure each exception logs a stacktrace from the ToString(). The stacktrace should include this test method's name.

            IEnumerable<string> innerExceptionDumps = GetInnerExceptionText(exceptionText);
            foreach (string innerExceptionText in innerExceptionDumps)
            {
                Assert.Contains("CustomAggregateToStringIncludesCallstack", innerExceptionText);
            }

            //Ensure that our BatchException was ToString()'ed correctly
            Assert.Contains(clientRequestId.ToString(), exceptionText);
        }

        private static IEnumerable<string> GetInnerExceptionText(string exceptionString)
        {
            IEnumerable<string> splitResults = exceptionString.Split(new[] { "Exception #" }, StringSplitOptions.RemoveEmptyEntries);
            splitResults = splitResults.Skip(1);

            return splitResults;
        }

        private static T ThrowWithStack<T>(Action action) where T: Exception
        {
            T exception = null;
            try
            {
                action();
            }
            catch (T e)
            {
                exception = e;
            }

            return exception;
        }
    }
}
