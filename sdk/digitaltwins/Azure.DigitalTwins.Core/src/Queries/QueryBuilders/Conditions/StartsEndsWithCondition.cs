// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    ///// <summary>
    ///// Custom child class of Condition for STARTSWITH or ENDSWITH. Meant to be used if not implementing seperate
    ///// WHERE methods for these functions.
    ///// </summary>
    ///// NOTE -- Planning on using more explicit Where methods, this class likely not used.
    /////
    //internal class StartsEndsWithCondition : BaseCondition
    //{
    //    /// <summary>
    //    /// Enum representing if this is STARTSWITH or ENDSWITH.
    //    /// </summary>
    //    public WithType StartOrEnd;

    //    /// <summary>
    //    /// The string being checked for a substring on either the front or end.
    //    /// </summary>
    //    public string StringToCheck;

    //    /// <summary>
    //    /// The substring being searched for at either the beginning or ending of an expression.
    //    /// </summary>
    //    public string BeginningOrEndingString;

    //    /// <summary>
    //    /// Constructor for StartsWithEndsWithCondition.
    //    /// </summary>
    //    /// <param name="startOrEnd"> Enum representing if this is STARTSWITH or ENDSWITH. </param>
    //    /// <param name="stringToCheck"> The string being checked for a substring on either the front or end. </param>
    //    /// <param name="beginningOrEndingString"> The substring being searched for at either the beginning or ending of an expression. </param>
    //    public StartsEndsWithCondition(WithType startOrEnd, string stringToCheck, string beginningOrEndingString)
    //    {
    //        StartOrEnd = startOrEnd;
    //        StringToCheck = stringToCheck;
    //        BeginningOrEndingString = beginningOrEndingString;
    //    }
    //}
}
