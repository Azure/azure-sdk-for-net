// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// Contains setup and tear down methods that run only once for the entire
    /// Azure.AI.FormRecognizer.DocumentAnalysis.Tests namespace.
    /// </summary>
    [SetUpFixture]
    public class DocumentAnalysisSetUpFixture
    {
        /// <summary>
        /// Deletes all models that have been cached in <see cref="DocumentModelCache"/>. This method
        /// runs only once after all tests in the Azure.AI.FormRecognizer.DocumentAnalysis.Tests
        /// namespace have finished running.
        /// </summary>
        [OneTimeTearDown]
        public async Task DeleteCachedModelsAsync()
        {
            await DocumentModelCache.DeleteModelsAsync();
        }
    }
}
