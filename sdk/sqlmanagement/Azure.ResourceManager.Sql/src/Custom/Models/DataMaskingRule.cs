// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    // Keep the fixed enum properties for binary back-compat.
    public partial class DataMaskingRule
    {
        /// <summary>
        /// The masking function that is used for the data masking rule.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.maskingFunction")]
        public DataMaskingFunction? MaskingFunction
        {
            get
            {
                SqlDataMaskingFunction? value = Properties?.DataMaskingFunction;
                return value.HasValue ? FromSqlDataMaskingFunction(value.Value) : (DataMaskingFunction?)null;
            }
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new DataMaskingRuleProperties();
                    Properties.DataMaskingFunction = ToSqlDataMaskingFunction(value.Value);
                }
            }
        }

        /// <summary>
        /// The rule state. Used to delete a rule. To delete an existing rule, specify the schemaName,
        /// tableName, columnName, maskingFunction, and specify ruleState as disabled. However, if the
        /// rule doesn't already exist, the rule will be created with ruleState set to enabled,
        /// regardless of the provided value of ruleState.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.ruleState")]
        public DataMaskingRuleState? RuleState
        {
            get
            {
                SqlDataMaskingRuleState? value = Properties?.DataMaskingRuleState;
                if (!value.HasValue)
                {
                    return null;
                }
                if (value.Value == SqlDataMaskingRuleState.Disabled)
                {
                    return Models.DataMaskingRuleState.Disabled;
                }
                if (value.Value == SqlDataMaskingRuleState.Enabled)
                {
                    return Models.DataMaskingRuleState.Enabled;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new DataMaskingRuleProperties();
                    Properties.DataMaskingRuleState = value.Value == Models.DataMaskingRuleState.Disabled
                        ? SqlDataMaskingRuleState.Disabled
                        : SqlDataMaskingRuleState.Enabled;
                }
            }
        }

        private static SqlDataMaskingFunction ToSqlDataMaskingFunction(DataMaskingFunction value)
        {
            return value switch
            {
                Models.DataMaskingFunction.Default => SqlDataMaskingFunction.Default,
                Models.DataMaskingFunction.Ccn => SqlDataMaskingFunction.Ccn,
                Models.DataMaskingFunction.Email => SqlDataMaskingFunction.Email,
                Models.DataMaskingFunction.Number => SqlDataMaskingFunction.Number,
                Models.DataMaskingFunction.Ssn => SqlDataMaskingFunction.Ssn,
                Models.DataMaskingFunction.Text => SqlDataMaskingFunction.Text,
                _ => new SqlDataMaskingFunction(value.ToString()),
            };
        }

        private static DataMaskingFunction? FromSqlDataMaskingFunction(SqlDataMaskingFunction value)
        {
            if (value == SqlDataMaskingFunction.Default) return Models.DataMaskingFunction.Default;
            if (value == SqlDataMaskingFunction.Ccn) return Models.DataMaskingFunction.Ccn;
            if (value == SqlDataMaskingFunction.Email) return Models.DataMaskingFunction.Email;
            if (value == SqlDataMaskingFunction.Number) return Models.DataMaskingFunction.Number;
            if (value == SqlDataMaskingFunction.Ssn) return Models.DataMaskingFunction.Ssn;
            if (value == SqlDataMaskingFunction.Text) return Models.DataMaskingFunction.Text;
            return null;
        }
    }
}
