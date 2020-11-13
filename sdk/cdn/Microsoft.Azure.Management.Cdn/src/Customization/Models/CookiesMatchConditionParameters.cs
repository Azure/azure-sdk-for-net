// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;

namespace Microsoft.Azure.Management.Cdn.Models
{

    public partial class CookiesMatchConditionParameters
    {
        /// <summary>
        /// Initializes a new instance of the CookiesMatchConditionParameters
        /// class.
        /// </summary>
        /// <param name="selector">Name of Cookies to be matched</param>
        /// <param name="operatorProperty">Describes operator to be matched.
        /// Possible values include: 'Any', 'Equal', 'Contains', 'BeginsWith',
        /// 'EndsWith', 'LessThan', 'LessThanOrEqual', 'GreaterThan',
        /// 'GreaterThanOrEqual'</param>
        /// <param name="matchValues">The match value for the condition of the
        /// delivery rule</param>
        /// <param name="negateCondition">Describes if this is negate condition
        /// or not</param>
        /// <param name="transforms">List of transforms</param>
        public CookiesMatchConditionParameters(string selector = null, string operatorProperty = null, IList<string> matchValues = null, bool? negateCondition = null, IList<string> transforms = null)
        {
            Selector = selector;
            OperatorProperty = operatorProperty;
            NegateCondition = negateCondition;
            MatchValues = matchValues;
            Transforms = transforms;
            CustomInit();
        }
    }
}
