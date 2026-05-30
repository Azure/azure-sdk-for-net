// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricAccessControlListPatchContent
    {
        /// <summary> List of match configurations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is obsolete and will be removed in a future version. Use MatchConfigurationSettings instead.")]
        public IList<AccessControlListMatchConfiguration> MatchConfigurations
        {
            get
            {
                Properties ??= new AccessControlListPatchProperties();
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
                Properties ??= new AccessControlListPatchProperties();
                return ToDynamicMatchConfigurations(Properties.DynamicMatchConfigurationSettings);
            }
        }

        internal static IList<AccessControlListMatchConfiguration> ToMatchConfigurations(IList<AccessControlListMatchConfigurationPatch> inner)
            => new ConvertingList<AccessControlListMatchConfiguration, AccessControlListMatchConfigurationPatch>(inner, ToMatchConfiguration, ToMatchConfigurationPatch);

        internal static IList<CommonDynamicMatchConfiguration> ToDynamicMatchConfigurations(IList<CommonDynamicMatchConfigurationPatch> inner)
            => new ConvertingList<CommonDynamicMatchConfiguration, CommonDynamicMatchConfigurationPatch>(inner, ToDynamicMatchConfiguration, ToDynamicMatchConfigurationPatch);

        internal static AccessControlListMatchConfigurationPatch ToMatchConfigurationPatch(AccessControlListMatchConfiguration value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListMatchConfigurationPatch
            {
                MatchConfigurationName = value.MatchConfigurationName,
                SequenceNumber = value.SequenceNumber,
                IPAddressType = value.IPAddressType
            };
            foreach (AccessControlListMatchCondition item in value.MatchConditions)
            {
                result.MatchConditions.Add(ToMatchConditionPatch(item));
            }
            foreach (AccessControlListAction item in value.Actions)
            {
                result.Actions.Add(ToActionPatch(item));
            }
            return result;
        }

        internal static CommonDynamicMatchConfigurationPatch ToDynamicMatchConfigurationPatch(CommonDynamicMatchConfiguration value)
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

        private static AccessControlListMatchConfiguration ToMatchConfiguration(AccessControlListMatchConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListMatchConfiguration
            {
                MatchConfigurationName = value.MatchConfigurationName,
                SequenceNumber = value.SequenceNumber,
                IPAddressType = value.IPAddressType
            };
            foreach (AccessControlListMatchConditionPatch item in value.MatchConditions)
            {
                result.MatchConditions.Add(ToMatchCondition(item));
            }
            foreach (AccessControlListActionPatch item in value.Actions)
            {
                result.Actions.Add(ToAction(item));
            }
            return result;
        }

        private static AccessControlListMatchConditionPatch ToMatchConditionPatch(AccessControlListMatchCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListMatchConditionPatch
            {
                VlanMatchCondition = ToVlanMatchConditionPatch(value.VlanMatchCondition),
                IPCondition = ToIpMatchConditionPatch(value.IPCondition),
                PortCondition = ToPortConditionPatch(value.PortCondition)
            };
            Copy(value.ProtocolTypes, result.ProtocolTypes);
            Copy(value.EtherTypes, result.EtherTypes);
            Copy(value.Fragments, result.Fragments);
            Copy(value.IPLengths, result.IPLengths);
            Copy(value.TtlValues, result.TtlValues);
            Copy(value.DscpMarkings, result.DscpMarkings);
            Copy(value.ProtocolNeighbors, result.ProtocolNeighbors);
            Copy(value.IcmpTypes, result.IcmpTypes);
            return result;
        }

        private static AccessControlListMatchCondition ToMatchCondition(AccessControlListMatchConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListMatchCondition
            {
                VlanMatchCondition = ToVlanMatchCondition(value.VlanMatchCondition),
                IPCondition = ToIPMatchCondition(value.IPCondition),
                PortCondition = ToPortCondition(value.PortCondition)
            };
            Copy(value.ProtocolTypes, result.ProtocolTypes);
            Copy(value.EtherTypes, result.EtherTypes);
            Copy(value.Fragments, result.Fragments);
            Copy(value.IPLengths, result.IPLengths);
            Copy(value.TtlValues, result.TtlValues);
            Copy(value.DscpMarkings, result.DscpMarkings);
            Copy(value.ProtocolNeighbors, result.ProtocolNeighbors);
            Copy(value.IcmpTypes, result.IcmpTypes);
            return result;
        }

        private static AccessControlListActionPatch ToActionPatch(AccessControlListAction value)
            => value is null ? null : new AccessControlListActionPatch
            {
                AclActionType = value.AclActionType,
                CounterName = value.CounterName,
                RemarkComment = value.RemarkComment,
                PoliceRateConfiguration = value.PoliceRateConfiguration
            };

        private static AccessControlListAction ToAction(AccessControlListActionPatch value)
            => value is null ? null : new AccessControlListAction
            {
                AclActionType = value.AclActionType,
                CounterName = value.CounterName,
                RemarkComment = value.RemarkComment,
                PoliceRateConfiguration = value.PoliceRateConfiguration
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

        private static IpMatchConditionPatch ToIpMatchConditionPatch(IPMatchCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new IpMatchConditionPatch
            {
                Type = value.SourceDestinationType,
                PrefixType = value.PrefixType
            };
            Copy(value.IPPrefixValues, result.IPPrefixValues);
            Copy(value.IPGroupNames, result.IPGroupNames);
            return result;
        }

        private static IPMatchCondition ToIPMatchCondition(IpMatchConditionPatch value)
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

        private static AccessControlListPortConditionPatch ToPortConditionPatch(AccessControlListPortCondition value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListPortConditionPatch
            {
                PortType = value.PortType,
                Layer4Protocol = value.Layer4Protocol
            };
            Copy(value.Ports, result.Ports);
            Copy(value.PortGroupNames, result.PortGroupNames);
            Copy(value.Flags, result.Flags);
            return result;
        }

        private static AccessControlListPortCondition ToPortCondition(AccessControlListPortConditionPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new AccessControlListPortCondition(value.Layer4Protocol.GetValueOrDefault())
            {
                PortType = value.PortType
            };
            Copy(value.Ports, result.Ports);
            Copy(value.PortGroupNames, result.PortGroupNames);
            Copy(value.Flags, result.Flags);
            return result;
        }

        private static CommonDynamicMatchConfiguration ToDynamicMatchConfiguration(CommonDynamicMatchConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new CommonDynamicMatchConfiguration();
            foreach (IpGroupPatchProperties item in value.IPGroups)
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

        private static IpGroupPatchProperties ToIPGroupPatch(MatchConfigurationIPGroupProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new IpGroupPatchProperties
            {
                Name = value.Name,
                IPAddressType = value.IPAddressType
            };
            Copy(value.IPPrefixes, result.IPPrefixes);
            return result;
        }

        private static MatchConfigurationIPGroupProperties ToIPGroup(IpGroupPatchProperties value)
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
