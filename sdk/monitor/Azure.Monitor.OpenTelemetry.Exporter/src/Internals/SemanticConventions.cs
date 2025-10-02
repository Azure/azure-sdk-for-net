// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Constants for semantic attribute names outlined by the OpenTelemetry specifications.
    /// <see href="https://github.com/open-telemetry/opentelemetry-specification/blob/master/specification/trace/semantic_conventions/README.md"/>.
    /// </summary>
    internal static class SemanticConventions
    {
        // The set of constants matches the specification as of this commit.
        // https://github.com/open-telemetry/opentelemetry-specification/tree/709293fe132709705f0e0dd4252992e87a6ec899/specification/trace/semantic_conventions
        public const string AttributeServiceName = "service.name";
        public const string AttributeServiceNamespace = "service.namespace";
        public const string AttributeServiceInstance = "service.instance.id";
        public const string AttributeServiceVersion = "service.version";

        public const string AttributeTelemetrySdkName = "telemetry.sdk.name";
        public const string AttributeTelemetrySdkLanguage = "telemetry.sdk.language";
        public const string AttributeTelemetrySdkVersion = "telemetry.sdk.version";

        public const string AttributeContainerName = "container.name";
        public const string AttributeContainerImage = "container.image.name";
        public const string AttributeContainerTag = "container.image.tag";

        public const string AttributeFaasName = "faas.name";
        public const string AttributeFaasId = "faas.id";
        public const string AttributeFaasVersion = "faas.version";
        public const string AttributeFaasInstance = "faas.instance";

        public const string AttributeK8sCluster = "k8s.cluster.name";
        public const string AttributeK8sCronJob = "k8s.cronjob.name";
        public const string AttributeK8sDaemonSet = "k8s.daemonset.name";
        public const string AttributeK8sDeployment = "k8s.deployment.name";
        public const string AttributeK8sJob = "k8s.job.name";
        public const string AttributeK8sNamespace = "k8s.namespace.name";
        public const string AttributeK8sPod = "k8s.pod.name";
        public const string AttributeK8sReplicaSet = "k8s.replicaset.name";
        public const string AttributeK8sStatefulSet = "k8s.statefulset.name";

        public const string AttributeHostHostname = "host.hostname";
        public const string AttributeHostId = "host.id";
        public const string AttributeHostName = "host.name";
        public const string AttributeHostType = "host.type";
        public const string AttributeHostImageName = "host.image.name";
        public const string AttributeHostImageId = "host.image.id";
        public const string AttributeHostImageVersion = "host.image.version";

        public const string AttributeProcessId = "process.id";
        public const string AttributeProcessExecutableName = "process.executable.name";
        public const string AttributeProcessExecutablePath = "process.executable.path";
        public const string AttributeProcessCommand = "process.command";
        public const string AttributeProcessCommandLine = "process.command_line";
        public const string AttributeProcessUsername = "process.username";

        public const string AttributeCloudProvider = "cloud.provider";
        public const string AttributeCloudAccount = "cloud.account.id";
        public const string AttributeCloudRegion = "cloud.region";
        public const string AttributeCloudZone = "cloud.zone";
        public const string AttributeComponent = "component";

        public const string AttributeNetTransport = "net.transport";
        public const string AttributeNetPeerIp = "net.peer.ip";
        public const string AttributeNetPeerPort = "net.peer.port";
        public const string AttributeNetPeerName = "net.peer.name";
        public const string AttributeNetHostIp = "net.host.ip";
        public const string AttributeNetHostPort = "net.host.port";
        public const string AttributeNetHostName = "net.host.name";

        public const string AttributeEnduserId = "enduser.id";
        public const string AttributeEnduserPseudoId = "enduser.pseudo.id";
        public const string AttributeEnduserRole = "enduser.role";
        public const string AttributeEnduserScope = "enduser.scope";

        public const string AttributePeerService = "peer.service";

        public const string AttributeHttpMethod = "http.method";
        public const string AttributeHttpUrl = "http.url";
        public const string AttributeHttpTarget = "http.target";
        public const string AttributeHttpHost = "http.host";
        public const string AttributeHttpScheme = "http.scheme";
        public const string AttributeHttpStatusCode = "http.status_code";
        public const string AttributeHttpStatusText = "http.status_text";
        public const string AttributeHttpFlavor = "http.flavor";
        public const string AttributeHttpServerName = "http.server_name";
        public const string AttributeHttpHostName = "host.name";
        public const string AttributeHttpHostPort = "host.port";
        public const string AttributeHttpRoute = "http.route";
        public const string AttributeHttpUserAgent = "http.user_agent";
        public const string AttributeHttpRequestContentLength = "http.request_content_length";
        public const string AttributeHttpRequestContentLengthUncompressed = "http.request_content_length_uncompressed";
        public const string AttributeHttpResponseContentLength = "http.response_content_length";
        public const string AttributeHttpResponseContentLengthUncompressed = "http.response_content_length_uncompressed";

        public const string AttributeDbSystem = "db.system";
        public const string AttributeDbConnectionString = "db.connection_string";
        public const string AttributeDbUser = "db.user";
        public const string AttributeDbMsSqlInstanceName = "db.mssql.instance_name";
        public const string AttributeDbJdbcDriverClassName = "db.jdbc.driver_classname";
        public const string AttributeDbName = "db.name";
        public const string AttributeDbStatement = "db.statement";
        public const string AttributeDbOperation = "db.operation";
        public const string AttributeDbInstance = "db.instance";
        public const string AttributeDbUrl = "db.url";
        public const string AttributeDbCassandraKeyspace = "db.cassandra.keyspace";
        public const string AttributeDbHBaseNamespace = "db.hbase.namespace";
        public const string AttributeDbRedisDatabaseIndex = "db.redis.database_index";
        public const string AttributeDbMongoDbCollection = "db.mongodb.collection";

        public const string AttributeMessageType = "message.type";
        public const string AttributeMessageId = "message.id";
        public const string AttributeMessageCompressedSize = "message.compressed_size";
        public const string AttributeMessageUncompressedSize = "message.uncompressed_size";

        public const string AttributeFaasTrigger = "faas.trigger";
        public const string AttributeFaasExecution = "faas.execution";
        public const string AttributeFaasColdStart = "faas.coldstart";
        public const string AttributeFaasDocumentCollection = "faas.document.collection";
        public const string AttributeFaasDocumentOperation = "faas.document.operation";
        public const string AttributeFaasDocumentTime = "faas.document.time";
        public const string AttributeFaasDocumentName = "faas.document.name";
        public const string AttributeFaasTime = "faas.time";
        public const string AttributeFaasCron = "faas.cron";

        public const string AttributeMessagingSystem = "messaging.system";
        public const string AttributeMessagingDestination = "messaging.destination";
        public const string AttributeMessagingDestinationKind = "messaging.destination_kind";
        public const string AttributeMessagingTempDestination = "messaging.temp_destination";
        public const string AttributeMessagingProtocol = "messaging.protocol";
        public const string AttributeMessagingProtocolVersion = "messaging.protocol_version";
        public const string AttributeMessagingUrl = "messaging.url";
        public const string AttributeMessagingMessageId = "messaging.message_id";
        public const string AttributeMessagingConversationId = "messaging.conversation_id";
        public const string AttributeMessagingPayloadSize = "messaging.message_payload_size_bytes";
        public const string AttributeMessagingPayloadCompressedSize = "messaging.message_payload_compressed_size_bytes";
        public const string AttributeMessagingOperation = "messaging.operation";

        public const string AttributeEndpointAddress = "peer.address";
        public const string AttributeMessageBusDestination = "message_bus.destination";

        public const string AttributeAzureNameSpace = "az.namespace";

        // Exceptions v1.24.0 https://github.com/open-telemetry/semantic-conventions/blob/v1.24.0/docs/exceptions/exceptions-spans.md
        public const string AttributeExceptionEventName = "exception";
        public const string AttributeExceptionType = "exception.type";
        public const string AttributeExceptionMessage = "exception.message";
        public const string AttributeExceptionStacktrace = "exception.stacktrace";

        // Http v1.21.0 https://github.com/open-telemetry/opentelemetry-specification/blob/v1.21.0/specification/trace/semantic_conventions/http.md
        public const string AttributeClientAddress = "client.address"; // replaces: "http.client_ip" (AttributeHttpClientIp)
        public const string AttributeHttpRequestMethod = "http.request.method"; // replaces: "http.method" (AttributeHttpMethod)
        public const string AttributeHttpResponseStatusCode = "http.response.status_code"; // replaces: "http.status_code" (AttributeHttpStatusCode)
        public const string AttributeNetworkProtocolVersion = "network.protocol.version"; // replaces: "http.flavor" (AttributeHttpFlavor)
        public const string AttributeServerAddress = "server.address"; // replaces: "net.host.name" (AttributeNetHostName)
        public const string AttributeServerPort = "server.port"; // replaces: "net.host.port" (AttributeNetHostPort) and "net.peer.port" (AttributeNetPeerPort)
        public const string AttributeUrlFull = "url.full"; // replaces: "http.url" (AttributeHttpUrl)
        public const string AttributeUrlPath = "url.path"; // replaces: "http.target" (AttributeHttpTarget)
        public const string AttributeUrlScheme = "url.scheme"; // replaces: "http.scheme" (AttributeHttpScheme)
        public const string AttributeUrlQuery = "url.query";
        public const string AttributeUserAgentOriginal = "user_agent.original"; // replaces: "http.user_agent" (AttributeHttpUserAgent)
        public const string AttributeServerSocketAddress = "server.socket.address"; // replaces: "net.peer.ip" (AttributeNetPeerIp)

        // Messaging v1.21.0 https://github.com/open-telemetry/opentelemetry-specification/blob/v1.21.0/specification/trace/semantic_conventions/messaging.md
        public const string AttributeMessagingDestinationName = "messaging.destination.name";
        public const string AttributeNetworkProtocolName = "network.protocol.name";
    }
}
