// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Internal
{
    /// <summary>
    /// Test Mocking Levels, which control how the service locator should work in 
    /// a test environment.
    /// </summary>
    public enum ServiceLocationMockingLevel
    {
        /// <summary>
        /// Apply Full Mocking, All mocking levels should be respected.
        /// </summary>
        ApplyFullMocking,

        /// <summary>
        /// Apply Individual Test Mocking only.  Only individual test overrides
        /// should be respected.
        /// </summary>
        ApplyIndividualTestMockingOnly,

        /// <summary>
        /// Apply Test Run Mocking Only.  Only full test run overrides should 
        /// be respected.
        /// </summary>
        ApplyTestRunMockingOnly,

        /// <summary>
        /// Apply No Mocking.  No mocking should be respected and only runtime
        /// objects should be utilized.
        /// </summary>
        ApplyNoMocking
    }
}