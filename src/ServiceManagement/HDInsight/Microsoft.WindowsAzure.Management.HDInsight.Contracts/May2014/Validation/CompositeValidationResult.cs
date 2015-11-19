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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This is an abstraction that can hold multiple validation results.
    /// </summary>
    internal class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> validationResults = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return this.validationResults;
            }
        }

        public CompositeValidationResult(string errorMessage) : base(errorMessage)
        {
        }
 
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames)
        {
        }
        
        protected CompositeValidationResult(ValidationResult validationResult) : base(validationResult)
        {
        }

        public void AddResult(ValidationResult validationResult)
        {
            this.validationResults.Add(validationResult);
        }
    }
}