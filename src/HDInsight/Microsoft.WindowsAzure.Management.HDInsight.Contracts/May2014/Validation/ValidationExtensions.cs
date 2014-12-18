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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class ValidationExtensions
    {
        /// <summary>
        /// Tries to validate the cluster object.
        /// </summary>
        /// <param name="clusterBase">The cluster.</param>
        /// <param name="validationResults">The validation results.</param>
        /// <returns>Return validation result.</returns>
        public static bool TryValidate(this ClusterBase clusterBase, ref IList<ValidationResult> validationResults)
        {
            if (clusterBase == null)
            {
                throw new ArgumentNullException("clusterBase");
            }
            validationResults = validationResults ?? new List<ValidationResult>();
            return Validator.TryValidateObject(clusterBase, new ValidationContext(clusterBase, null, new Dictionary<object, object> { { "ClusterObject", clusterBase } }), validationResults, true);
        }
    }
}
