// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Microsoft bot.</summary>
    public class MicrosoftBotIdentifier : CommunicationIdentifier
    {
        private string _rawId;

        /// <summary>
        /// Returns the canonical string representation of the <see cref="MicrosoftBotIdentifier"/>.
        /// You can use the <see cref="RawId"/> for encoding the identifier and then use it as a key in a database.
        /// </summary>
        public override string RawId
        {
            get
            {
                if (_rawId != null)
                    return _rawId;

                if (IsGlobal)
                {
                    if (Cloud == CommunicationCloudEnvironment.Dod)
                    {
                        _rawId = $"28:dod-global:{BotId}";
                    }
                    else if (Cloud == CommunicationCloudEnvironment.Gcch)
                    {
                        _rawId = $"28:gcch-global:{BotId}";
                    }
                    else
                    {
                        _rawId = $"28:{BotId}";
                    }
                }
                else
                {
                    if (Cloud == CommunicationCloudEnvironment.Dod)
                    {
                        _rawId = $"28:dod:{BotId}";
                    }
                    else if (Cloud == CommunicationCloudEnvironment.Gcch)
                    {
                        _rawId = $"28:gcch:{BotId}";
                    }
                    else
                    {
                        _rawId = $"28:orgid:{BotId}";
                    }
                }

                return _rawId;
            }
        }

        /// <summary>The id of the Microsoft bot.</summary>
        public string BotId { get; }

        /// <summary>True if the bot is global and false (or missing) if the bot is tenantized.</summary>
        public bool IsGlobal { get; }

        /// <summary> The cloud that the bot belongs to. </summary>
        public CommunicationCloudEnvironment Cloud { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MicrosoftBotIdentifier"/>.
        /// </summary>
        /// <param name="botId">Id of the Microsoft bot. The unique Microsoft app ID for the bot as registered with the Bot Framework.</param>
        /// <param name="isGlobal">Set this to true if the bot is global.</param>
        /// <param name="cloud">The cloud that the Microsoft bot belongs to. A null value translates to the Public cloud.</param>
        /// <param name="rawId">Raw id of the Microsoft bot optional.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="botId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="botId"/> is empty.
        /// </exception>
        public MicrosoftBotIdentifier(string botId, bool isGlobal = false, CommunicationCloudEnvironment? cloud = null, string rawId = null)
        {
            Argument.AssertNotNullOrEmpty(botId, nameof(botId));
            BotId = botId;
            IsGlobal = isGlobal;
            Cloud = cloud ?? CommunicationCloudEnvironment.Public;
            _rawId = rawId;
        }

        /// <inheritdoc />
        public override string ToString() => BotId;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is MicrosoftBotIdentifier botIdentifier
            && botIdentifier.RawId == RawId;
    }
}
