// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public partial class TagScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the TagScoringFunction class.
        /// </summary>
        public TagScoringFunction(
            string fieldName, 
            double boost, 
            string tagsParameter, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(fieldName, boost, new TagScoringParameters(tagsParameter), interpolation)
        {
            // Initialization done by other constructor.
        }
    }
}
