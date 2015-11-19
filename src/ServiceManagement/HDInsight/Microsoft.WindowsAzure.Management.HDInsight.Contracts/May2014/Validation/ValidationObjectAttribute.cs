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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Globalization;

    /// <summary>
    /// This is a custom validator for complex types that in turn have validatation attributes attached to it.
    /// </summary>
    internal sealed class ValidateObjectAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }
            var results = new List<ValidationResult>();
            
            var valuesToValidate = new List<object>();

            if (value is IEnumerable)
            {
                valuesToValidate.AddRange((value as IEnumerable<object>));
            }

            foreach (var valueToValidate in valuesToValidate)
            {
                if (valueToValidate != null)
                {
                    var context = new ValidationContext(valueToValidate, validationContext.ServiceContainer, validationContext.Items);
                    Validator.TryValidateObject(valueToValidate, context, results, true);
                }
            }

            if (results.Count != 0)
            {
                var compositeResults =
                    new CompositeValidationResult(
                        string.Format(CultureInfo.InvariantCulture, "Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);

                return compositeResults;
            }

            return ValidationResult.Success;
        }
    }
}
