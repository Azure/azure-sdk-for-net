// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> &lt;code&gt;Invalid&lt;/code&gt; indicates the name provided does not match Azure App Service naming requirements. &lt;code&gt;AlreadyExists&lt;/code&gt; indicates that the name is already in use and is therefore unavailable. </summary>
    public readonly partial struct AppServiceNameUnavailableReason : IEquatable<AppServiceNameUnavailableReason>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="AppServiceNameUnavailableReason"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AppServiceNameUnavailableReason(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InvalidValue = "Invalid";
        private const string AlreadyExistsValue = "AlreadyExists";

        /// <summary> Invalid. </summary>
        public static AppServiceNameUnavailableReason Invalid { get; } = new AppServiceNameUnavailableReason(InvalidValue);
        /// <summary> AlreadyExists. </summary>
        public static AppServiceNameUnavailableReason AlreadyExists { get; } = new AppServiceNameUnavailableReason(AlreadyExistsValue);
        /// <summary> Determines if two <see cref="AppServiceNameUnavailableReason"/> values are the same. </summary>
        public static bool operator ==(AppServiceNameUnavailableReason left, AppServiceNameUnavailableReason right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AppServiceNameUnavailableReason"/> values are not the same. </summary>
        public static bool operator !=(AppServiceNameUnavailableReason left, AppServiceNameUnavailableReason right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="AppServiceNameUnavailableReason"/>. </summary>
        public static implicit operator AppServiceNameUnavailableReason(string value) => new AppServiceNameUnavailableReason(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AppServiceNameUnavailableReason other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AppServiceNameUnavailableReason other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
