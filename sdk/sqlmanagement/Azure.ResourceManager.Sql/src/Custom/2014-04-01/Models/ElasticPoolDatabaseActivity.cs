// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> Represents the activity on an elastic pool. </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ElasticPoolDatabaseActivity : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ElasticPoolDatabaseActivity"/>. </summary>
        public ElasticPoolDatabaseActivity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ElasticPoolDatabaseActivity"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="databaseName"> The database name. </param>
        /// <param name="endOn"> The time the operation finished (ISO8601 format). </param>
        /// <param name="errorCode"> The error code if available. </param>
        /// <param name="errorMessage"> The error message if available. </param>
        /// <param name="errorSeverity"> The error severity if available. </param>
        /// <param name="operation"> The operation name. </param>
        /// <param name="operationId"> The unique operation ID. </param>
        /// <param name="percentComplete"> The percentage complete if available. </param>
        /// <param name="requestedElasticPoolName"> The name for the elastic pool the database is moving into if available. </param>
        /// <param name="currentElasticPoolName"> The name of the current elastic pool the database is in if available. </param>
        /// <param name="currentServiceObjective"> The name of the current service objective if available. </param>
        /// <param name="requestedServiceObjective"> The name of the requested service objective if available. </param>
        /// <param name="serverName"> The name of the server the elastic pool is in. </param>
        /// <param name="startOn"> The time the operation started (ISO8601 format). </param>
        /// <param name="state"> The current state of the operation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ElasticPoolDatabaseActivity(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, AzureLocation? location, string databaseName, DateTimeOffset? endOn, int? errorCode, string errorMessage, int? errorSeverity, string operation, Guid? operationId, int? percentComplete, string requestedElasticPoolName, string currentElasticPoolName, string currentServiceObjective, string requestedServiceObjective, string serverName, DateTimeOffset? startOn, string state, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            DatabaseName = databaseName;
            EndOn = endOn;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorSeverity = errorSeverity;
            Operation = operation;
            OperationId = operationId;
            PercentComplete = percentComplete;
            RequestedElasticPoolName = requestedElasticPoolName;
            CurrentElasticPoolName = currentElasticPoolName;
            CurrentServiceObjective = currentServiceObjective;
            RequestedServiceObjective = requestedServiceObjective;
            ServerName = serverName;
            StartOn = startOn;
            State = state;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The geo-location where the resource lives. </summary>
        [WirePath("location")]
        public AzureLocation? Location { get; set; }
        /// <summary> The database name. </summary>
        [WirePath("properties.databaseName")]
        public string DatabaseName { get; }
        /// <summary> The time the operation finished (ISO8601 format). </summary>
        [WirePath("properties.endTime")]
        public DateTimeOffset? EndOn { get; }
        /// <summary> The error code if available. </summary>
        [WirePath("properties.errorCode")]
        public int? ErrorCode { get; }
        /// <summary> The error message if available. </summary>
        [WirePath("properties.errorMessage")]
        public string ErrorMessage { get; }
        /// <summary> The error severity if available. </summary>
        [WirePath("properties.errorSeverity")]
        public int? ErrorSeverity { get; }
        /// <summary> The operation name. </summary>
        [WirePath("properties.operation")]
        public string Operation { get; }
        /// <summary> The unique operation ID. </summary>
        [WirePath("properties.operationId")]
        public Guid? OperationId { get; }
        /// <summary> The percentage complete if available. </summary>
        [WirePath("properties.percentComplete")]
        public int? PercentComplete { get; }
        /// <summary> The name for the elastic pool the database is moving into if available. </summary>
        [WirePath("properties.requestedElasticPoolName")]
        public string RequestedElasticPoolName { get; }
        /// <summary> The name of the current elastic pool the database is in if available. </summary>
        [WirePath("properties.currentElasticPoolName")]
        public string CurrentElasticPoolName { get; }
        /// <summary> The name of the current service objective if available. </summary>
        [WirePath("properties.currentServiceObjective")]
        public string CurrentServiceObjective { get; }
        /// <summary> The name of the requested service objective if available. </summary>
        [WirePath("properties.requestedServiceObjective")]
        public string RequestedServiceObjective { get; }
        /// <summary> The name of the server the elastic pool is in. </summary>
        [WirePath("properties.serverName")]
        public string ServerName { get; }
        /// <summary> The time the operation started (ISO8601 format). </summary>
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn { get; }
        /// <summary> The current state of the operation. </summary>
        [WirePath("properties.state")]
        public string State { get; }
    }
}
