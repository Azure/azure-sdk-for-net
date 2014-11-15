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
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    /// <summary>
    /// This is an attribute when applied to <see cref="ClusterRole"/> properties that would validate whether.
    /// </summary>
    internal sealed class ValidateRoleExistsInClusterAttribute : ValidationAttribute
    {
       private const string ClusterObjectKey = "ClusterObject";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext != null && validationContext.Items.ContainsKey(ClusterObjectKey))
            {
                var cluster = validationContext.Items[ClusterObjectKey] as ClusterBase;

                if (cluster != null)
                {
                    var valueAsRole = value as ClusterRole;
                    if (valueAsRole != null)
                    {
                        if (cluster.ClusterRoleCollection.Contains(valueAsRole))
                        {
                            return ValidationResult.Success;
                        }
                        return
                            new ValidationResult(
                                string.Format(
                                    CultureInfo.InvariantCulture,
                                    "{0} is used without defining in Cluster.Roles",
                                    valueAsRole.FriendlyName ?? "(Unnamed Role)"));
                    }
                }
            }
            // if neither of the above conditions hold, the attribute may have been placed in error, 
            // let us not fail the validation.
            return ValidationResult.Success;
        }
    }
}
