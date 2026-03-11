// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The client options for <see cref="NotificationMessagesClient"/> and <see cref="MessageTemplateClient"/>.
    /// </summary>
    public partial class CommunicationMessagesClientOptions : MessagesClientOptions
    {
        /// <summary>
        /// The service version to use.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new enum ServiceVersion
        {
            /// <summary> API version "2024-02-01". </summary>
            V2024_02_01 = 1,
            /// <summary> API version "2024-08-30". </summary>
            V2024_08_30 = 2,
            /// <summary> API version "2025-01-15-preview". </summary>
            V2025_01_15_Preview = 3,
            /// <summary> API version "2025-04-01-preview". </summary>
            V2025_04_01_Preview = 4,
            /// <summary> API version "2025-09-01-preview". </summary>
            V2025_09_01_Preview = 5,
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationMessagesClientOptions"/>.
        /// </summary>
        /// <param name="version">The service version to use.</param>
        public CommunicationMessagesClientOptions(ServiceVersion version = ServiceVersion.V2025_09_01_Preview) : base((MessagesClientOptions.ServiceVersion)version)
        {
        }
    }
}
