// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    ///// <summary>
    ///// Custom child class of Condition for conditions that use IS-based functions (like IS_NUMBER, IS_STRING, etc.).
    ///// Only meant to be used if not implementing seperate WHERE methods for these functions.
    ///// </summary>
    //// NOTE -- These are planned to be defined more explicitly as where methods, this class likely not used.

    //internal class IsCondition : BaseCondition
    //{
    //    /// <summary>
    //    /// Enum for the 5 types that can be checked for existance.
    //    /// </summary>
    //    public IsType Type;

    //    /// <summary>
    //    /// The expression being searched for a specific type.
    //    /// </summary>
    //    public string Expression;

    //    /// <summary>
    //    /// Constructor for IsCondition.
    //    /// </summary>
    //    /// <param name="type"> Enum for the 5 types that can be checked for existance. </param>
    //    /// <param name="expression"> The expression being searched for a specific type. </param>
    //    public IsCondition(IsType type, string expression)
    //    {
    //        Type = type;
    //        Expression = expression;
    //    }
    //}
}
