// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// A custom class for Conditions, which define the logic contained in WHERE objects.
    /// </summary>
    internal abstract class QueryCondition
    {
    }

    /// <summary>
    /// A child of Condition specifically for comparisons using the SQL-like comparison operators "<," ">," "<=", "!=," etc.
    /// </summary>
    internal class ComparisonCondition : QueryCondition
    {
        /// <summary>
        /// The field that we're checking against a certain value. Eg "Temperature < 5" --- Temperature is the field
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The comparision operator being invoked, eg. <, >, !=, =, etc.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// The value we're checking against a Field. Eg, in the above example, 5 is the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor for a comparison condition.
        /// </summary>
        /// <param name="field"> The field that we're checking against a certain value. Eg "Temperature < 5" --- Temperature is the field </param>
        /// <param name="oper"> The comparision operator being invoked, eg. <, >, !=, =, etc. </param>
        /// <param name="value"> The value we're checking against a Field. Eg, in the above example, 5 is the value. </param>
        public ComparisonCondition(string field, string oper, string value)
        {
            this.Field = field;
            this.Operator = oper;
            this.Value = value;
        }
    }

    /// <summary>
    /// Custom child class for conditiosn that use the contains operators, IN and NIN.
    /// </summary>
    internal class ContainsCondition : QueryCondition
    {
        /// <summary>
        /// The value being searched for within some list of objects. 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The list of objects being searched for a value.
        /// </summary>
        public string[] Searched { get; set; }

        /// <summary>
        /// Constructor for ContainsCondition.
        /// </summary>
        /// <param name="value"> The value being searched for within some list of objects.  </param>
        /// <param name="searched"> The list of objects being searched for a value. </param>
        public ContainsCondition(string value, string[] searched)
        {
            this.Value = value;
            this.Searched = searched;
        }
    }

    /// <summary>
    /// Custom child class of Condition for conditions that use IS-based functions (like IS_NUMBER, IS_STRING, etc.).
    /// Only meant to be used if not implementing seperate WHERE methods for these functions. 
    /// </summary>
    internal class IsCondition : QueryCondition
    {
        /// <summary>
        /// Enum for the 5 types that can be checked for existance. 
        /// </summary>
        public IsType Type;

        /// <summary>
        /// The expression being searched for a specific type.
        /// </summary>
        public string Expression;

        /// <summary>
        /// Constructor for IsCondition. 
        /// </summary>
        /// <param name="type"> Enum for the 5 types that can be checked for existance. </param>
        /// <param name="expression"> The expression being searched for a specific type. </param>
        public IsCondition(IsType type, string expression)
        {
            this.Type = type;
            this.Expression = expression;
        }
    }

    /// <summary>
    /// Custom child class of Condition for STARTSWITH or ENDSWITH. Meant to be used if not implementing seperate
    /// WHERE methods for these functions.
    /// </summary>
    internal class StartsEndsWithCondition : QueryCondition
    {
        /// <summary>
        /// Enum representing if this is STARTSWITH or ENDSWITH.
        /// </summary>
        public WithType StartOrEnd;

        /// <summary>
        /// The string being checked for a substring on either the front or end.
        /// </summary>
        public string StringToCheck;

        /// <summary>
        /// The substring being searched for at either the beginning or ending of an expression.
        /// </summary>
        public string BeginningOrEndingString;

        /// <summary>
        /// Constructor for StartsWithEndsWithCondition.
        /// </summary>
        /// <param name="startOrEnd"> Enum representing if this is STARTSWITH or ENDSWITH. </param>
        /// <param name="stringToCheck"> The string being checked for a substring on either the front or end. </param>
        /// <param name="beginningOrEndingString"> The substring being searched for at either the beginning or ending of an expression. </param>
        public StartsEndsWithCondition(WithType startOrEnd, string stringToCheck, string beginningOrEndingString)
        {
            this.StartOrEnd = startOrEnd;
            this.StringToCheck = stringToCheck;
            this.BeginningOrEndingString = beginningOrEndingString;
        }
    }
}
