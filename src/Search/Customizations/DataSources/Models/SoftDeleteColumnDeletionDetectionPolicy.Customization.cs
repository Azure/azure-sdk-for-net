// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;

namespace Microsoft.Azure.Search.Models
{
    public partial class SoftDeleteColumnDeletionDetectionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the SoftDeleteColumnDeletionDetectionPolicy class with required arguments. 
        /// </summary>
        /// <param name="softDeleteColumnName">Specifies the name of the column to use for soft-deletion detection.</param>
        /// <param name="softDeleteMarkerValue">Specifies the marker value that indentifies an item as deleted.</param>
        public SoftDeleteColumnDeletionDetectionPolicy(string softDeleteColumnName, object softDeleteMarkerValue)
        {
            if (softDeleteColumnName == null)
            {
                throw new ArgumentNullException("softDeleteColumnName");
            }
            if (softDeleteMarkerValue == null)
            {
                throw new ArgumentNullException("softDeleteMarkerValue");
            } 

            if (!(softDeleteMarkerValue is int || softDeleteMarkerValue is long || softDeleteMarkerValue is byte || 
                  softDeleteMarkerValue is short || softDeleteMarkerValue is string || softDeleteMarkerValue is bool))
            {
                throw new ArgumentException("Soft-delete marker value must be an integer, string, or bool value.", "softDeleteMarkerValue");
            }

            SoftDeleteColumnName = softDeleteColumnName;
            SoftDeleteMarkerValue = softDeleteMarkerValue.ToString();
        }
    }
}
