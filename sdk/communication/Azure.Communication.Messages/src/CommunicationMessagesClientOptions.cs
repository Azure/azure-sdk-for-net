// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The client options for <see cref="NotificationMessagesClient"/> and <see cref="MessageTemplateClient"/>.
    /// </summary>
    [CodeGenModel("AzureCommunicationMessagesClientOptions")]
#pragma warning disable AZC0009 // ClientOptions constructors should take a ServiceVersion as their first parameter
    public partial class CommunicationMessagesClientOptions { }
#pragma warning restore AZC0009 // ClientOptions constructors should take a ServiceVersion as their first parameter
}
