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
    public partial class Field
    {
        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="dataType">The data type of the field.</param>
        public Field(string name, DataType dataType) : this(name, dataType != null ? dataType.ToString() : null)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <remarks>The new field will automatically be searchable and of type Edm.String.</remarks>
        public Field(string name, AnalyzerName analyzerName)
            : this(name, DataType.String, analyzerName)
        {
            // Do nothing.
        }

        /// <summary>
        /// Initializes a new instance of the Field class with required arguments.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="dataType">The data type of the field.</param>
        /// <param name="analyzerName">The name of the analyzer to use for the field.</param>
        /// <remarks>The new field will automatically be searchable.</remarks>
        public Field(string name, DataType dataType, AnalyzerName analyzerName)
            : this(name, dataType != null ? dataType.ToString() : null)
        {
            if (analyzerName == null)
            {
                throw new ArgumentNullException("analyzerName");
            }

            Analyzer = analyzerName.ToString();
            IsSearchable = true;
        }
    }
}
