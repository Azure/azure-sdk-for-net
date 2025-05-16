// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class QueryStringMatchCondition
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public QueryStringMatchCondition(QueryStringMatchConditionType conditionType, QueryStringOperator queryStringOperator) : this(queryStringOperator)
        {
            ConditionType = conditionType;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public QueryStringMatchConditionType ConditionType
        {
            get => new(TypeName.ToString());
            set
            {
                TypeName = value.ToString();
            }
        }
    }
}