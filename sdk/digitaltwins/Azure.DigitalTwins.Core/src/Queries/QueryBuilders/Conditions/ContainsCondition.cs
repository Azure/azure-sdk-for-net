// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom child class for conditions that use the contains operators, IN and NIN.
    /// </summary>
    internal class ContainsCondition : ConditionBase
    {
        /// <summary>
        /// The value being searched for within some list of objects.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#contains-operators">contains operator</see> being invoked.
        /// </summary>
        public QueryContainOperator Operator { get; set; }

        /// <summary>
        /// The list of objects being searched for a value.
        /// </summary>
        public string[] Searched { get; set; }

        /// <summary>
        /// Constructor for ContainsCondition.
        /// </summary>
        /// <param name="value"> The value being searched for within some list of objects.  </param>
        /// <param name="containOperator"> The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#contains-operators">contains operator</see> being invoked. </param>
        /// <param name="searched"> The list of objects being searched for a value. </param>
        public ContainsCondition(string value, QueryContainOperator containOperator, string[] searched)
        {
            Value = value;
            Operator = containOperator;
            Searched = searched;
        }

        public override string Stringify()
        {
            // turn the string array into the correct format ['property1', 'property2', 'etc']
            string searchedFormatted = $"['{string.Join("', '", Searched)}']";

            // form entire conditional string
            return $"{Value} {Operator} {searchedFormatted}";
        }
    }
}
