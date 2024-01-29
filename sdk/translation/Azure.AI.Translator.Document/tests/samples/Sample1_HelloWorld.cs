// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translator.Document.Tests.Samples
{
    public partial class DocumentSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorld.cs to write samples. */
        [Test]
        [SyncOnly]
        public void Scenario()
        {
            #region Snippet:Azure_AI_Translator_Document_Scenario
            Console.WriteLine("Hello, world!");
            #endregion
        }
    }
}
