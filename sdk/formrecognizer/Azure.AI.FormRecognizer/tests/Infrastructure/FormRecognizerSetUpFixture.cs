// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    [SetUpFixture]
    public class FormRecognizerSetUpFixture
    {
        [OneTimeTearDown]
        public async Task DeleteCachedModelsAsync()
        {
            await TrainedModelCache.DeleteModelsAsync();
        }
    }
}
