// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class NetworkFabricRoutePolicyPatchContent
    {
        /// <summary> Route Policy statements. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility property is obsolete and will be removed in a future version. Use StatementSettings instead.")]
        public IList<RoutePolicyStatementProperties> Statements
        {
            get
            {
                Properties ??= new RoutePolicyPatchableProperties();
                return ToStatements(Properties.StatementSettings);
            }
        }

        internal static IList<RoutePolicyStatementProperties> ToStatements(IList<RoutePolicyStatementPatchProperties> inner)
            => new ConvertingList<RoutePolicyStatementProperties, RoutePolicyStatementPatchProperties>(inner, ToStatementProperties, ToStatementPatchProperties);

        private static RoutePolicyStatementPatchProperties ToStatementPatchProperties(RoutePolicyStatementProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new RoutePolicyStatementPatchProperties(value.Annotation, additionalBinaryDataProperties: null, value.SequenceNumber, ToConditionPatchProperties(value.Condition), ToActionPatchProperties(value.Action));
        }

        private static RoutePolicyStatementProperties ToStatementProperties(RoutePolicyStatementPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new RoutePolicyStatementProperties(value.Annotation, additionalBinaryDataProperties: null, value.SequenceNumber, ToConditionProperties(value.Condition), ToActionProperties(value.Action));
        }

        private static StatementConditionPatchProperties ToConditionPatchProperties(StatementConditionProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new StatementConditionPatchProperties
            {
                Type = value.RoutePolicyConditionType,
                IPPrefixId = value.IPPrefixId?.ToString()
            };
            Copy(value.IPCommunityIds, result.IPCommunityIds, ToString);
            Copy(value.IPExtendedCommunityIds, result.IPExtendedCommunityIds, ToString);
            return result;
        }

        private static StatementConditionProperties ToConditionProperties(StatementConditionPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new StatementConditionProperties
            {
                RoutePolicyConditionType = value.Type,
                IPPrefixId = ToResourceIdentifier(value.IPPrefixId)
            };
            Copy(value.IPCommunityIds, result.IPCommunityIds, ToResourceIdentifier);
            Copy(value.IPExtendedCommunityIds, result.IPExtendedCommunityIds, ToResourceIdentifier);
            return result;
        }

        private static StatementActionPatchProperties ToActionPatchProperties(StatementActionProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new StatementActionPatchProperties(value.LocalPreference, value.ActionType, ToIPCommunityPatchProperties(value.IPCommunityProperties), ToIPExtendedCommunityPatchProperties(value.IPExtendedCommunityProperties), additionalBinaryDataProperties: null);
        }

        private static StatementActionProperties ToActionProperties(StatementActionPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            return new StatementActionProperties(value.LocalPreference, value.ActionType, ToIPCommunityProperties(value.IPCommunityProperties), ToIPExtendedCommunityProperties(value.IPExtendedCommunityProperties), additionalBinaryDataProperties: null);
        }

        private static ActionIPCommunityPatchProperties ToIPCommunityPatchProperties(ActionIPCommunityProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new ActionIPCommunityPatchProperties();
            Copy(value.AddIPCommunityIds, result.AddIPCommunityIds, Identity);
            Copy(value.DeleteIPCommunityIds, result.DeleteIPCommunityIds, Identity);
            Copy(value.SetIPCommunityIds, result.SetIPCommunityIds, Identity);
            return result;
        }

        private static ActionIPCommunityProperties ToIPCommunityProperties(ActionIPCommunityPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new ActionIPCommunityProperties();
            Copy(value.AddIPCommunityIds, result.AddIPCommunityIds, Identity);
            Copy(value.DeleteIPCommunityIds, result.DeleteIPCommunityIds, Identity);
            Copy(value.SetIPCommunityIds, result.SetIPCommunityIds, Identity);
            return result;
        }

        private static ActionIPExtendedCommunityPatchProperties ToIPExtendedCommunityPatchProperties(ActionIPExtendedCommunityProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new ActionIPExtendedCommunityPatchProperties();
            Copy(value.AddIPExtendedCommunityIds, result.AddIPExtendedCommunityIds, Identity);
            Copy(value.DeleteIPExtendedCommunityIds, result.DeleteIPExtendedCommunityIds, Identity);
            Copy(value.SetIPExtendedCommunityIds, result.SetIPExtendedCommunityIds, Identity);
            return result;
        }

        private static ActionIPExtendedCommunityProperties ToIPExtendedCommunityProperties(ActionIPExtendedCommunityPatchProperties value)
        {
            if (value is null)
            {
                return null;
            }

            var result = new ActionIPExtendedCommunityProperties();
            Copy(value.AddIPExtendedCommunityIds, result.AddIPExtendedCommunityIds, Identity);
            Copy(value.DeleteIPExtendedCommunityIds, result.DeleteIPExtendedCommunityIds, Identity);
            Copy(value.SetIPExtendedCommunityIds, result.SetIPExtendedCommunityIds, Identity);
            return result;
        }

        private static ResourceIdentifier ToResourceIdentifier(string value)
            => value is null ? null : new ResourceIdentifier(value);

        private static string ToString(ResourceIdentifier value)
            => value?.ToString();

        private static ResourceIdentifier Identity(ResourceIdentifier value)
            => value;

        private static void Copy<TSource, TTarget>(IEnumerable<TSource> source, IList<TTarget> target, Func<TSource, TTarget> convert)
        {
            foreach (TSource item in source)
            {
                target.Add(convert(item));
            }
        }
    }
}
