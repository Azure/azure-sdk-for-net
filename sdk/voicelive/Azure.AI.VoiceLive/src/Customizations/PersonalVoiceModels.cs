// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Compatibility type for PersonalVoiceModels parameter.
    /// The TypeSpec was renamed to PersonalVoiceModel (singular),
    /// but some generated signatures still reference the plural form.
    /// This shim provides conversion operators for interop.
    /// </summary>
    public readonly partial struct PersonalVoiceModels : System.IEquatable<PersonalVoiceModels>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="PersonalVoiceModels"/>.
        /// </summary>
        /// <param name="value"></param>
        public PersonalVoiceModels(string value)
        {
            _value = value;
        }

        public static PersonalVoiceModels DragonHDOmniLatestNeural { get; } = new PersonalVoiceModels("dragon-hdomni-latest-neural");
        public static PersonalVoiceModels DragonLatestNeural { get; } = new PersonalVoiceModels("dragon-latest-neural");
        public static PersonalVoiceModels MaiVoice1 { get; } = new PersonalVoiceModels("mai-voice-1");
        public static PersonalVoiceModels PhoenixLatestNeural { get; } = new PersonalVoiceModels("phoenix-latest-neural");
        public static PersonalVoiceModels PhoenixV2Neural { get; } = new PersonalVoiceModels("phoenix-v2-neural");

        public bool Equals(PersonalVoiceModels other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is PersonalVoiceModels other && Equals(other);
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        public static bool operator ==(PersonalVoiceModels left, PersonalVoiceModels right) => left.Equals(right);
        public static implicit operator PersonalVoiceModels(PersonalVoiceModel value) => new PersonalVoiceModels(value.ToString());
        public static implicit operator PersonalVoiceModel(PersonalVoiceModels value) => new PersonalVoiceModel(value._value);
        public static implicit operator PersonalVoiceModels(string value) => new PersonalVoiceModels(value);
        public static bool operator !=(PersonalVoiceModels left, PersonalVoiceModels right) => !left.Equals(right);

        public override string ToString() => _value;
    }
}

#pragma warning restore CS1591
