// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.Samples
{
    public static class SamplesConstants
    {
        /// <summary>
        /// Room model Id
        /// </summary>
        public const string RoomModelId = "dtmi:samples:Room;1";

        /// <summary>
        /// WiFi model Id
        /// </summary>
        public const string WifiModelId = "dtmi:samples:Wifi;1";

        /// <summary>
        /// Building model Id
        /// </summary>
        public const string BuildingModelId = "dtmi:samples:Building;1";

        /// <summary>
        /// Floor model Id
        /// </summary>
        public const string FloorModelId = "dtmi:samples:Floor;1";

        /// <summary>
        /// HVAC model Id
        /// </summary>
        public const string HvacModelId = "dtmi:samples:HVAC;1";

        /// <summary>
        /// Placeholder for model Id in the temporary payload.
        /// </summary>
        public const string ModelId = "MODEL_ID";

        /// <summary>
        /// Placeholder for component Id in the temporary payload.
        /// </summary>
        public const string ComponentId = "COMPONENT_ID";

        /// <summary>
        /// Temporary model Id prefix
        /// </summary>
        public const string TemporaryModelPrefix = "dtmi:samples:TempModel;";

        /// <summary>
        /// Temporary component model Id prefix
        /// </summary>
        public const string TemporaryComponentModelPrefix = "dtmi:samples:ComponentModel;";

        /// <summary>
        /// Placeholder for model display name in the temporary payload.
        /// </summary>
        public const string ModelDisplayName = "MODEL_DISPLAY_NAME";

        /// <summary>
        /// Placeholder for model relationship name in the temporary payload.
        /// </summary>
        public const string RelationshipName = "RELATIONSHIP_NAME";

        /// <summary>
        /// The application/json description of a temporary model with a component.
        /// </summary>
        public const string TemporaryModelWithComponentPayload = @"
            {
                ""@id"": ""MODEL_ID"",
                ""@type"": ""Interface"",
                ""@context"": ""dtmi:dtdl:context;2"",
                ""displayName"": ""TempModel"",
                ""contents"": [
                    {
                        ""@type"": ""Property"",
                        ""name"": ""Prop1"",
                        ""schema"": ""string""
                    },
                    {
                        ""@type"": ""Property"",
                        ""name"": ""Prop2"",
                        ""schema"": ""integer""
                    },
                    {
                        ""@type"": ""Component"",
                        ""name"": ""Component1"",
                        ""schema"": ""COMPONENT_ID""
                    },
                    {
                        ""@type"": ""Telemetry"",
                        ""name"": ""Telemetry1"",
                        ""schema"": ""integer""
                    }
                ]
            }";

        /// <summary>
        /// Path for component.
        /// </summary>
        public const string ComponentPath = "Component1";

        /// <summary>
        /// The application/json description of a temporary component model
        /// </summary>
        public const string TemporaryComponentModelPayload = @"
            {
                ""@id"": ""COMPONENT_ID"",
                ""@type"": ""Interface"",
                ""@context"": ""dtmi:dtdl:context;2"",
                ""displayName"": ""Component1"",
                ""contents"": [
                    {
                        ""@type"": ""Property"",
                        ""name"": ""ComponentProp1"",
                        ""schema"": ""string""
                    },
                    {
                        ""@type"": ""Property"",
                        ""name"": ""ComponentProp2"",
                        ""schema"": ""integer""
                    },
                    {
                        ""@type"": ""Telemetry"",
                        ""name"": ""ComponentTelemetry1"",
                        ""schema"": ""integer""
                    }
                ]
            }";

        /// <summary>
        /// Temporary twin Id prefix
        /// </summary>
        public const string TemporaryTwinPrefix = "sampleTwin";

        /// <summary>
        /// The application/json description of a temporary twin
        /// </summary>
        public const string TemporaryTwinPayload = @"
            {
              ""$metadata"": {
                ""$model"": ""MODEL_ID""
              },
              ""Prop1"": ""Value"",
              ""Prop2"": 987,
              ""Component1"":{
                ""$metadata"":{
                },
                ""ComponentProp1"": ""Value"",
                ""ComponentProp2"": 123
              }
            }";

        /// <summary>
        /// Placeholder for a relationship target model Id in the temporary model with relationship payload.
        /// </summary>
        public const string RelationshipTargetModelId = "RELATIONSHIP_TARGET_MODEL_ID";

        /// <summary>
        /// The application/json description of a temporary model with a relationship
        /// </summary>
        public const string TemporaryModelWithRelationshipPayload = @"
            {
                ""@id"": ""MODEL_ID"",
                ""@type"": ""Interface"",
                ""@context"": ""dtmi:dtdl:context;2"",
                ""displayName"": ""MODEL_DISPLAY_NAME"",
                ""contents"": [
                    {
                        ""@type"": ""Relationship"",
                        ""name"": ""RELATIONSHIP_NAME"",
                        ""target"": ""RELATIONSHIP_TARGET_MODEL_ID"",
                        ""properties"": [
                            {
                                ""@type"": ""Property"",
                                ""name"": ""Prop1"",
                                ""schema"": ""string""
                            },
                            {
                                ""@type"": ""Property"",
                                ""name"": ""Prop2"",
                                ""schema"": ""integer""
                            }
                        ]
                    }
                ]
            }";
    }
}
