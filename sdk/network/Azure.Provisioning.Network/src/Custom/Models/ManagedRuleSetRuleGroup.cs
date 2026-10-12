// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Network;

public partial class ManagedRuleSetRuleGroup
{
    private BicepList<string> _legacyRules;

    // RuleIds represents the new integer array. Preserve the released string collection
    // independently so existing literals and Bicep expressions still emit without parsing.
    // Both collections use the original rules path, but configuring both is an error.
    /// <summary> Gets the legacy string rule collection. </summary>
    /// <remarks> This collection has independent storage from RuleIds. Populate only one of the two collections. </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use RuleIds instead.")]
    public BicepList<string> Rules
    {
        get
        {
            Initialize();
            return _legacyRules;
        }
    }

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // Register the retained legacy property under its released name.
        BicepList<string> value = DefineListProperty<string>(nameof(Rules), new string[] { "rules" });
        _legacyRules = new LegacyRulesList(value, _ruleIds);
        ProvisionableProperties[nameof(Rules)] = _legacyRules;
#pragma warning restore CS0618
    }

    // Nested constructs do not necessarily pass through their own Validate override.
    // The compiler always checks property emptiness before aggregating wire paths, so
    // this also detects conflicting mutations made through previously retrieved lists.
    private sealed class LegacyRulesList : BicepList<string>
    {
        private readonly BicepList<int> _numeric;

        public LegacyRulesList(BicepList<string> value, BicepList<int> numeric)
        {
            _numeric = numeric;
            // Keep an untouched legacy list unset, not an expression referencing itself.
            Assign((BicepList<string>)null);
            ((IBicepValue)this).Self = ((IBicepValue)value).Self;
        }

        public override bool IsEmpty
        {
            get
            {
                if (!base.IsEmpty && !_numeric.IsEmpty)
                {
                    throw new InvalidOperationException("Populate either Rules or RuleIds, not both.");
                }
                return base.IsEmpty;
            }
        }
    }
}
