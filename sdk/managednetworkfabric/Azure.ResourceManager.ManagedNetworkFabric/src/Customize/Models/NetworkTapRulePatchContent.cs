// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkTapRulePatchContent
    {
        /// <summary> List of match configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is obsolete and will be removed in a future version. Use MatchConfigurationSettings instead.")]
        public IList<NetworkTapRuleMatchConfiguration> MatchConfigurations
        {
            get
            {
                Properties ??= new NetworkTapRulePatchProperties();
                return ToMatchConfigurations(Properties.MatchConfigurationSettings);
            }
        }

        /// <summary> List of dynamic match configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is obsolete and will be removed in a future version. Use DynamicMatchConfigurationSettings instead.")]
        public IList<CommonDynamicMatchConfiguration> DynamicMatchConfigurations
        {
            get
            {
                Properties ??= new NetworkTapRulePatchProperties();
                return ToDynamicMatchConfigurations(Properties.DynamicMatchConfigurationSettings);
            }
        }

        internal static IList<NetworkTapRuleMatchConfiguration> ToMatchConfigurations(IList<NetworkTapRuleMatchConfigurationPatch> inner)
            => new ConvertingList<NetworkTapRuleMatchConfiguration, NetworkTapRuleMatchConfigurationPatch>(inner, ToMatchConfiguration, ToMatchConfigurationPatch);

        internal static IList<CommonDynamicMatchConfiguration> ToDynamicMatchConfigurations(IList<CommonDynamicMatchConfigurationPatch> inner)
            => new ConvertingList<CommonDynamicMatchConfiguration, CommonDynamicMatchConfigurationPatch>(inner, ToDynamicMatchConfiguration, ToDynamicMatchConfigurationPatch);

        private static NetworkTapRuleMatchConfigurationPatch ToMatchConfigurationPatch(NetworkTapRuleMatchConfiguration value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new NetworkTapRuleMatchConfigurationPatch
            {
                MatchConfigurationName = value.MatchConfigurationName,
                SequenceNumber = value.SequenceNumber,
                IPAddressType = value.IPAddressType
            };
            foreach (NetworkTapRuleMatchCondition item in value.MatchConditions)
            {
                result.MatchConditions.Add(ToMatchConditionPatch(item));
            }
            foreach (NetworkTapRuleAction item in value.Actions)
            {
                result.Actions.Add(ToActionPatch(item));
            }
            return result;
        }

        private static NetworkTapRuleMatchConfiguration ToMatchConfiguration(NetworkTapRuleMatchConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new NetworkTapRuleMatchConfiguration
            {
                MatchConfigurationName = value.MatchConfigurationName,
                SequenceNumber = value.SequenceNumber,
                IPAddressType = value.IPAddressType
            };
            foreach (NetworkTapRuleMatchConditionPatch item in value.MatchConditions)
            {
                result.MatchConditions.Add(ToMatchCondition(item));
            }
            foreach (NetworkTapRuleActionPatch item in value.Actions)
            {
                result.Actions.Add(ToAction(item));
            }
            return result;
        }

        private static NetworkTapRuleMatchConditionPatch ToMatchConditionPatch(NetworkTapRuleMatchCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new NetworkTapRuleMatchConditionPatch
            {
                VlanMatchCondition = ToVlanMatchConditionPatch(value.VlanMatchCondition),
                IPCondition = ToIPMatchConditionPatch(value.IPCondition),
                EncapsulationType = value.EncapsulationType,
                PortCondition = ToPortConditionPatch(value.PortCondition)
            };
            Copy(value.ProtocolTypes, result.ProtocolTypes);
            return result;
        }

        private static NetworkTapRuleMatchCondition ToMatchCondition(NetworkTapRuleMatchConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new NetworkTapRuleMatchCondition
            {
                VlanMatchCondition = ToVlanMatchCondition(value.VlanMatchCondition),
                IPCondition = ToIPMatchCondition(value.IPCondition),
                EncapsulationType = value.EncapsulationType,
                PortCondition = ToPortCondition(value.PortCondition)
            };
            Copy(value.ProtocolTypes, result.ProtocolTypes);
            return result;
        }

        private static NetworkTapRuleActionPatch ToActionPatch(NetworkTapRuleAction value)
            => value is null ? null : new NetworkTapRuleActionPatch
            {
                TapRuleActionType = value.TapRuleActionType,
                Truncate = value.Truncate,
                IsTimestampEnabled = value.IsTimestampEnabled,
                DestinationId = value.DestinationId,
                MatchConfigurationName = value.MatchConfigurationName
            };

        private static NetworkTapRuleAction ToAction(NetworkTapRuleActionPatch value)
            => value is null ? null : new NetworkTapRuleAction
            {
                TapRuleActionType = value.TapRuleActionType,
                Truncate = value.Truncate,
                IsTimestampEnabled = value.IsTimestampEnabled,
                DestinationId = value.DestinationId,
                MatchConfigurationName = value.MatchConfigurationName
            };

        private static VlanMatchConditionPatch ToVlanMatchConditionPatch(VlanMatchCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new VlanMatchConditionPatch();
            Copy(value.Vlans, result.Vlans);
            Copy(value.InnerVlans, result.InnerVlans);
            Copy(value.VlanGroupNames, result.VlanGroupNames);
            return result;
        }

        private static VlanMatchCondition ToVlanMatchCondition(VlanMatchConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new VlanMatchCondition();
            Copy(value.Vlans, result.Vlans);
            Copy(value.InnerVlans, result.InnerVlans);
            Copy(value.VlanGroupNames, result.VlanGroupNames);
            return result;
        }

        private static IPMatchConditionPatch ToIPMatchConditionPatch(IPMatchCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new IPMatchConditionPatch
            {
                Type = value.SourceDestinationType,
                PrefixType = value.PrefixType
            };
            Copy(value.IPPrefixValues, result.IPPrefixValues);
            Copy(value.IPGroupNames, result.IPGroupNames);
            return result;
        }

        private static IPMatchCondition ToIPMatchCondition(IPMatchConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new IPMatchCondition
            {
                SourceDestinationType = value.Type,
                PrefixType = value.PrefixType
            };
            Copy(value.IPPrefixValues, result.IPPrefixValues);
            Copy(value.IPGroupNames, result.IPGroupNames);
            return result;
        }

        private static PortConditionPatch ToPortConditionPatch(NetworkFabricPortCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new PortConditionPatch
            {
                PortType = value.PortType,
                Layer4Protocol = value.Layer4Protocol
            };
            Copy(value.Ports, result.Ports);
            Copy(value.PortGroupNames, result.PortGroupNames);
            return result;
        }

        private static NetworkFabricPortCondition ToPortCondition(PortConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new NetworkFabricPortCondition(value.Layer4Protocol.GetValueOrDefault())
            {
                PortType = value.PortType
            };
            Copy(value.Ports, result.Ports);
            Copy(value.PortGroupNames, result.PortGroupNames);
            return result;
        }

        private static CommonDynamicMatchConfigurationPatch ToDynamicMatchConfigurationPatch(CommonDynamicMatchConfiguration value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new CommonDynamicMatchConfigurationPatch();
            foreach (MatchConfigurationIPGroupProperties item in value.IPGroups)
            {
                result.IPGroups.Add(ToIPGroupPatch(item));
            }
            foreach (VlanGroupProperties item in value.VlanGroups)
            {
                result.VlanGroups.Add(ToVlanGroupPatch(item));
            }
            foreach (PortGroupProperties item in value.PortGroups)
            {
                result.PortGroups.Add(ToPortGroupPatch(item));
            }
            return result;
        }

        private static CommonDynamicMatchConfiguration ToDynamicMatchConfiguration(CommonDynamicMatchConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new CommonDynamicMatchConfiguration();
            foreach (IPGroupPatchProperties item in value.IPGroups)
            {
                result.IPGroups.Add(ToIPGroup(item));
            }
            foreach (VlanGroupPatchProperties item in value.VlanGroups)
            {
                result.VlanGroups.Add(ToVlanGroup(item));
            }
            foreach (PortGroupPatchProperties item in value.PortGroups)
            {
                result.PortGroups.Add(ToPortGroup(item));
            }
            return result;
        }

        private static IPGroupPatchProperties ToIPGroupPatch(MatchConfigurationIPGroupProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new IPGroupPatchProperties
            {
                Name = value.Name,
                IPAddressType = value.IPAddressType
            };
            Copy(value.IPPrefixes, result.IPPrefixes);
            return result;
        }

        private static MatchConfigurationIPGroupProperties ToIPGroup(IPGroupPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new MatchConfigurationIPGroupProperties
            {
                Name = value.Name,
                IPAddressType = value.IPAddressType
            };
            Copy(value.IPPrefixes, result.IPPrefixes);
            return result;
        }

        private static VlanGroupPatchProperties ToVlanGroupPatch(VlanGroupProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new VlanGroupPatchProperties { Name = value.Name };
            Copy(value.Vlans, result.Vlans);
            return result;
        }

        private static VlanGroupProperties ToVlanGroup(VlanGroupPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new VlanGroupProperties { Name = value.Name };
            Copy(value.Vlans, result.Vlans);
            return result;
        }

        private static PortGroupPatchProperties ToPortGroupPatch(PortGroupProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new PortGroupPatchProperties { Name = value.Name };
            Copy(value.Ports, result.Ports);
            return result;
        }

        private static PortGroupProperties ToPortGroup(PortGroupPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new PortGroupProperties { Name = value.Name };
            Copy(value.Ports, result.Ports);
            return result;
        }

        private static void Copy<T>(IEnumerable<T> source, IList<T> target)
        {
            foreach (T item in source)
            {
                target.Add(item);
            }
        }
    }
}
