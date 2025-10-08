// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    internal static partial class FeatureFlagFieldsExtensions
    {
        /// <summary>
        /// Maps a FeatureFlagFields member to its corresponding service name in accordance with the REST API specification.
        /// </summary>
        private static readonly IReadOnlyDictionary<FeatureFlagFields, string> s_serviceNameMap = new Dictionary<FeatureFlagFields, string>()
        {
            { FeatureFlagFields.Name        , "name"          },
            { FeatureFlagFields.Label       , "label"         },
            { FeatureFlagFields.Alias       , "alias"         },
            { FeatureFlagFields.Allocation  , "allocation"    },
            { FeatureFlagFields.ETag        , "etag"          },
            { FeatureFlagFields.LastModified, "last_modified" },
            { FeatureFlagFields.IsReadOnly  , "locked"        },
            { FeatureFlagFields.Tags        , "tags"          },
            { FeatureFlagFields.Variants    , "variants"      },
            { FeatureFlagFields.Enabled     , "enabled"       },
            { FeatureFlagFields.Description , "description"   },
            { FeatureFlagFields.Conditions  , "conditions"    },
            { FeatureFlagFields.Telemetry   , "telemetry"     }
        };

        /// <summary>
        /// Splits <see cref="FeatureFlagFields"/> flags into their corresponding service names.
        /// </summary>
        /// <param name="fields">The flags to split.</param>
        /// <returns>An enumerable containing the names of the flags. The method returns <c>null</c> for <see cref="FeatureFlagFields.All"/>.</returns>
        public static IEnumerable<string> Split(this FeatureFlagFields fields)
        {
            if (fields == FeatureFlagFields.All)
            {
                return null;
            }

            var splitFields = new List<string>();

            foreach (FeatureFlagFields currentField in s_serviceNameMap.Keys)
            {
                if ((fields & currentField) == currentField)
                {
                    splitFields.Add(s_serviceNameMap[currentField]);
                }
            }

            return splitFields;
        }
    }
}
