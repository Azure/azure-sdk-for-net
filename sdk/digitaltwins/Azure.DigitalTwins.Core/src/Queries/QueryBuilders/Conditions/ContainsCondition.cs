// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom child class for conditiosn that use the contains operators, IN and NIN.
    /// </summary>
    internal class ContainsCondition : BaseCondition
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
            Value = value;
            Searched = searched;
        }
    }
}
