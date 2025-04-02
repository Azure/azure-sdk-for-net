// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class GeneralTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void ListOfListAndList(bool implicitContext)
            => InvocationTestBase.RunInvocationTest(
                InvocationTestBase.JsonModel,
                string.Empty,
                implicitContext,
                Caller,
                [ListOfListTests.AssertListOfList, ListTests.AssertList]);

        private string Caller(string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<List<{{type}}>>(BinaryData.Empty, ModelReaderWriterOptions.Json, TestAssemblyContext.Default);
            ModelReaderWriter.Read<List<List<{{type}}>>>(BinaryData.Empty, ModelReaderWriterOptions.Json, TestAssemblyContext.Default);
        }
    }
""";
        }
    }
}
