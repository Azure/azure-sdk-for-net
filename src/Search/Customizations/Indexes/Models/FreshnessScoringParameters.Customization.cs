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
using System.Xml;

namespace Microsoft.Azure.Search.Models
{
    public partial class FreshnessScoringParameters
    {
        /// <summary>
        /// Initializes a new instance of the FreshnessScoringParameters class with the given boosting duration value.
        /// </summary>
        /// <param name="boostingDuration">
        /// The expiration period after which boosting will stop for a particular document.
        /// </param>
        public FreshnessScoringParameters(TimeSpan boostingDuration) : this(XmlConvert.ToString(boostingDuration))
        {
        }
    }
}
