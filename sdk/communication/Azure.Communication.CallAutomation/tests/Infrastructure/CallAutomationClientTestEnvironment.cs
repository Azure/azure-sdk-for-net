// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
{
    internal class CallAutomationClientTestEnvironment : CommunicationTestEnvironment
    {
        public const string ResourceId = "COMMUNICATION_LIVETEST_STATIC_RESOURCE_IDENTIFIER";

        public const string TargetUser = "TARGET_USER_ID";

        public const string AnotherTargetUser = "ANOTHER_TARGET_USER_ID";

        public const string TargetNumber = "TARGET_PHONE_NUMBER";

        public const string Endpoint = "PMA_Endpoint";

        private const string randomResourceIdentifier = "82e890fc-188a-4b67-bb7d-deff073d7d1e";

        private string randomAcsUser = $"8:acs:{randomResourceIdentifier}_0000000e-abbe-44ad-9f37-b0a72a616d0b";

        private string randomAcsUser2 = $"8:acs:{randomResourceIdentifier}_0000000e-9f82-b5db-eef0-8b3a0d000839";

        private string dispatcherEndpoint = "DISPATCHER_ENDPOINT";

        private string servicebusString = "SERVICEBUS_STRING";

        private string botAppId = "BOT_APP_ID";

        private string transportUrl = "TRANSPORT_URL";

        private string fileSourceUrl = "FILE_SOURCE_URL";

        private string cognitiveServiceEndpoint = "COGNITIVE_SERVICE_ENDPOINT";

        /// <summary>
        /// The resource identifier associated with the Azure Communication Service.
        /// </summary>
        public string ResourceIdentifier => GetRecordedVariable(ResourceId, options => options.IsSecret(randomResourceIdentifier));

        /// <summary>
        /// The phone number associated with the ACS resource. Required to make a PSTN call.
        /// </summary>
        public string SourcePhoneNumber => GetRecordedVariable(AzurePhoneNumber, options => options.IsSecret("+18771234567"));

        /// <summary>
        /// The target ACS user id represented in string formatted as "8:acs:ResourceId_UUID".
        /// </summary>
        public string TargetUserId => GetRecordedVariable(TargetUser, options => options.IsSecret(randomAcsUser));

        /// <summary>
        /// The target ACS user id represented in string formatted as "8:acs:ResourceId_UUID".
        /// </summary>
        public string TargetUserId2 => GetRecordedVariable(AnotherTargetUser, options => options.IsSecret(randomAcsUser2));
        /// <summary>
        /// The target phone number to call in string formated as "+1<PhoneNumber>".
        /// </summary>
        public string TargetPhoneNumber => GetRecordedVariable(TargetNumber, options => options.IsSecret("+16041234567"));

        /// <summary>
        /// Endpoint for the targetted PMA in string. If not set, default endpoint is used.
        /// </summary>
        public string PMAEndpoint => GetRecordedOptionalVariable(Endpoint, options => options.IsSecret("https://sanitized.com"));

        /// <summary>
        /// Dispatcher endpoint for automated testing
        /// </summary>
        public string DispatcherEndpoint => GetRecordedOptionalVariable(dispatcherEndpoint, options => options.IsSecret("https://sanitized.skype.com"));

        /// <summary>
        /// Bot App Id for Dialog tests.
        /// </summary>
        public string BotAppId => GetRecordedOptionalVariable(botAppId, options => options.IsSecret("Sanitized"));

        /// <summary>
        /// ServiceBus string
        /// </summary>
        public string ServiceBusNamespace => GetRecordedOptionalVariable(servicebusString, options => options.IsSecret("Sanitized"));

        /// <summary>
        /// websocket url for automated testing
        /// </summary>
        public string TransportUrl => GetRecordedOptionalVariable(transportUrl, options => options.IsSecret("https://sanitized.skype.com"));

        /// <summary>
        /// file source for automated testing
        /// </summary>
        public string FileSourceUrl => GetRecordedOptionalVariable(fileSourceUrl, options => options.IsSecret("https://sanitized.skype.com/prompt.wav"));

        /// <summary>
        /// Cognitive service endpoint for automated testing
        /// </summary>
        public string CognitiveServiceEndpoint => GetRecordedOptionalVariable(cognitiveServiceEndpoint, options => options.IsSecret("https://sanitized.skype.com"));

        /// <summary>
        /// The callback url of the application where notification would be received.
        /// </summary>
        public string DispatcherCallback => $"{DispatcherEndpoint}/api/servicebuscallback/events";

        /// <summary>
        /// The secret for validating incoming request.
        /// </summary>
        public string IncomingRequestSecret => "helloworld";

        /// <summary>
        /// The base url of the applicaiton.
        /// </summary>
        public string AppBaseUrl => "https://dummy.ngrok.io";

        /// <summary>
        /// The callback url of the application where notification would be received.
        /// </summary>
        public string AppCallbackUrl => $"{AppBaseUrl}/api/incident/callback?SecretKey={WebUtility.UrlEncode(IncomingRequestSecret)}";

        public string WebsocketUrl => $"wss://testwebsocket.webpubsub.azure.com/client/hubs/media?access_token=helloworld";
    }
}
