// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal struct ActivityTagsProcessor
    {
        private readonly bool _includeUnmappedTags;

        public AzMonList MappedTags;
        public AzMonList UnMappedTags;

        public OperationType activityType { get; private set; }

        /// <summary>
        /// Whether the activity carried the newer semantic conventions.
        /// </summary>
        public readonly bool IsV2 => activityType.HasFlag(OperationType.V2);

        /// <summary>
        /// The operation type without the schema-version flag, for dispatching on the operation alone.
        /// </summary>
        public readonly OperationType BaseActivityType => activityType & ~OperationType.V2;

        public string? AzureNamespace { get; private set; } = null;

        public string? EndUserId { get; private set; } = null;

        public string? EndUserPseudoId { get; private set; } = null;

        public bool HasOverrideAttributes { get; private set; } = false;

        public ActivityTagsProcessor()
        {
            _includeUnmappedTags = true;
            MappedTags = AzMonList.InitializeForMappedTags();
            UnMappedTags = AzMonList.Initialize();
        }

        /// <summary>
        /// Callers that only read <see cref="MappedTags"/> can skip collecting the unmapped
        /// tags, which avoids a pooled buffer and the string conversion of array-valued tags.
        /// </summary>
        public ActivityTagsProcessor(bool includeUnmappedTags)
        {
            _includeUnmappedTags = includeUnmappedTags;
            MappedTags = AzMonList.InitializeForMappedTags();
            UnMappedTags = includeUnmappedTags ? AzMonList.Initialize() : default;
        }

        public void CategorizeTags(Activity activity)
        {
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                if (tag.Value == null)
                {
                    continue;
                }

                if (SemanticSlotMap.TryGetSlot(tag.Key, out var slot))
                {
                    switch (slot)
                    {
                        case SemanticSlot.HttpMethod:
                            activityType = OperationType.Http;
                            break;
                        case SemanticSlot.HttpRequestMethod:
                            activityType = OperationType.Http | OperationType.V2;
                            break;
                        case SemanticSlot.DbSystemName:
                            activityType = OperationType.Db | OperationType.V2;
                            break;
                        case SemanticSlot.DbSystem:
                            activityType = OperationType.Db;
                            break;
                        case SemanticSlot.MessagingSystem:
                            activityType = OperationType.Messaging;
                            break;
                        case SemanticSlot.AzureNameSpace:
                            AzureNamespace = tag.Value.ToString();
                            break;
                        case SemanticSlot.EnduserId:
                            EndUserId = tag.Value.ToString();
                            continue;
                        case SemanticSlot.EnduserPseudoId:
                            EndUserPseudoId = tag.Value.ToString();
                            continue;
                        case SemanticSlot.MicrosoftSessionId:
                        case SemanticSlot.AiDeviceId:
                        case SemanticSlot.AiDeviceModel:
                        case SemanticSlot.AiDeviceType:
                        case SemanticSlot.AiDeviceOsVersion:
                        case SemanticSlot.MicrosoftSyntheticSource:
                        case SemanticSlot.MicrosoftUserAccountId:
                        case SemanticSlot.MicrosoftDependencyData:
                        case SemanticSlot.MicrosoftDependencyName:
                        case SemanticSlot.MicrosoftDependencyTarget:
                        case SemanticSlot.MicrosoftDependencyType:
                        case SemanticSlot.MicrosoftDependencyResultCode:
                        case SemanticSlot.MicrosoftOperationName:
                        case SemanticSlot.MicrosoftRequestName:
                        case SemanticSlot.MicrosoftRequestUrl:
                        case SemanticSlot.MicrosoftRequestSource:
                        case SemanticSlot.MicrosoftRequestResultCode:
                            HasOverrideAttributes = true;
                            break;
                    }

                    AzMonList.AddMapped(ref MappedTags, slot, tag);
                }
                else
                {
                    if (!_includeUnmappedTags)
                    {
                        continue;
                    }

                    // If the tag value is an array, there is no need to check for semantics;
                    // directly add it to the Unmapped list.
                    if (tag.Value is Array array)
                    {
                        AzMonList.AddUnmapped(ref UnMappedTags, new KeyValuePair<string, object?>(tag.Key, array.ToCommaDelimitedString()));
                        continue;
                    }

                    AzMonList.AddUnmapped(ref UnMappedTags, tag);
                }
            }
        }

        public void Return()
        {
            MappedTags.Return();
            UnMappedTags.Return();
        }
    }
}
