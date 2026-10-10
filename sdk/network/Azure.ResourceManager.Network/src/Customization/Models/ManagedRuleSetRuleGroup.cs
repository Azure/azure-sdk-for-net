// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ManagedRuleSetRuleGroup
    {
        // The service changed rules from strings to integers in API version 2026-01-01.
        // The TypeSpec client name RuleIds gives the numeric collection its own API without
        // changing the signature of the released Rules getter.
        //
        // Keep the legacy collection independent rather than parsing its strings: existing
        // model-factory callers can supply arbitrary strings, null entries, and values outside
        // Int32's range. This compatibility storage is not bound to a TypeSpec member and must
        // not be serialized. Only the generated RuleIds property represents the rules wire field.
        private readonly IReadOnlyList<string> _rules = new ChangeTrackingList<string>();

        internal ManagedRuleSetRuleGroup(string ruleGroupName, IReadOnlyList<string> rules)
            : this(ruleGroupName)
        {
            _rules = rules;
        }

        /// <summary> Gets the legacy string rule collection supplied to the model factory. </summary>
        /// <remarks>
        /// This collection is independent of <see cref="RuleIds"/> and is not serialized.
        /// Deserialized responses populate <see cref="RuleIds"/> instead.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use RuleIds instead.")]
        public IReadOnlyList<string> Rules => _rules;
    }
}
