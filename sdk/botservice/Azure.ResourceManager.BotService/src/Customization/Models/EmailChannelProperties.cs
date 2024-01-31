// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.BotService.Models
{
    /// <summary> The parameters to provide for the Email channel. </summary>
    public partial class EmailChannelProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EmailChannelProperties"/>. </summary>
        /// <param name="emailAddress"> The email address. </param>
        /// <param name="isEnabled"> Whether this channel is enabled for the bot. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="emailAddress"/> is null. </exception>
        public EmailChannelProperties(string emailAddress, bool isEnabled)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }

            EmailAddress = emailAddress;
            IsEnabled = isEnabled;
        }

        /// <summary> Initializes a new instance of <see cref="EmailChannelProperties"/>. </summary>
        /// <param name="emailAddress"> The email address. </param>
        /// <param name="authMethod"> Email channel auth method. 0 Password (Default); 1 Graph. </param>
        /// <param name="password"> The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty. </param>
        /// <param name="magicCode"> The magic code for setting up the modern authentication. </param>
        /// <param name="isEnabled"> Whether this channel is enabled for the bot. </param>
        /// /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EmailChannelProperties(string emailAddress, EmailChannelAuthMethod? authMethod, string password, string magicCode, bool isEnabled, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            EmailAddress = emailAddress;
            AuthMethod = authMethod;
            Password = password;
            MagicCode = magicCode;
            IsEnabled = isEnabled;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The email address. </summary>
        public string EmailAddress { get; set; }
        /// <summary> Email channel auth method. 0 Password (Default); 1 Graph. </summary>
        public EmailChannelAuthMethod? AuthMethod { get; set; }
        /// <summary> The password for the email address. Value only returned through POST to the action Channel List API, otherwise empty. </summary>
        public string Password { get; set; }
        /// <summary> The magic code for setting up the modern authentication. </summary>
        public string MagicCode { get; set; }
        /// <summary> Whether this channel is enabled for the bot. </summary>
        public bool IsEnabled { get; set; }
    }
}
