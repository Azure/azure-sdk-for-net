// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace System.ClientModel.SourceGeneration.Tests.Unit.InvocationTests
{
    internal class GeneralTests
    {
        public void ListOfListAndList()
            => new ListOfListTests().RunInvocationTest(
                InvocationTestBase.JsonModel,
                string.Empty,
                true,
                Caller,
                [ListOfListTests.AssertListOfList, ListTests.AssertList]);

        private string Caller(bool contextAdded, string type, string invocation)
        {
            return
$$"""

    public class Caller
    {
        public void Call()
        {
            ModelReaderWriter.Read<List<{{type}}>>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
            ModelReaderWriter.Read<List<List<{{type}}>>>(BinaryData.Empty, ModelReaderWriterOptions.Json, LocalContext.Default);
        }
    }
""";
        }
    }
}
