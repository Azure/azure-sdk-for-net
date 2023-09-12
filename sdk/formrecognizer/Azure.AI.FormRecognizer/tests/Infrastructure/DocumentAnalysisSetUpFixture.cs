// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    [SetUpFixture]
    public class DocumentAnalysisSetUpFixture
    {
        [OneTimeTearDown]
        public async Task DeleteCachedModelsAsync()
        {
            await DocumentModelCache.DeleteModelsAsync();
        }
    }
}
