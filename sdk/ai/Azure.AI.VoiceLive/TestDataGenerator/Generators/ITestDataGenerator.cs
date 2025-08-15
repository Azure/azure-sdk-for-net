// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.TestDataGenerator.Models;

namespace Azure.AI.VoiceLive.TestDataGenerator.Generators
{
    /// <summary>
    /// Base interface for test data generators.
    /// </summary>
    public interface ITestDataGenerator
    {
        TestDataCategory Category { get; }
        Task GenerateAsync(string outputPath, TestPhrases phrases);
        void PreviewGeneration(string outputPath, TestPhrases phrases);
    }
}