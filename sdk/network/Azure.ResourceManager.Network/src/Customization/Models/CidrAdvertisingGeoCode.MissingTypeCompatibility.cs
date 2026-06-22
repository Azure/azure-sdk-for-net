// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Geo code for CIDR advertising. </summary>
    /// The TypeSpec rename restores the generated CidrAdvertisingGeoCode type, but the generator
    /// still emits only the all-caps wire-name fields. Keep the shipped C#-cased members and the
    /// non-null string conversion/equality implementation for API compatibility.
    /// <summary> Compatibility declaration for the CidrAdvertisingGeoCode type. </summary>
    public readonly partial struct CidrAdvertisingGeoCode : IEquatable<CidrAdvertisingGeoCode>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CidrAdvertisingGeoCode"/>. </summary>
        /// <param name="value"> The value. </param>
        public CidrAdvertisingGeoCode(string value)
        {
            _value = value;
        }
        /// <summary> AFRI. </summary>
        public static CidrAdvertisingGeoCode Afri { get; } = new CidrAdvertisingGeoCode("AFRI");
        /// <summary> APAC. </summary>
        public static CidrAdvertisingGeoCode Apac { get; } = new CidrAdvertisingGeoCode("APAC");
        /// <summary> AQ. </summary>
        public static CidrAdvertisingGeoCode AQ { get; } = new CidrAdvertisingGeoCode("AQ");
        /// <summary> EURO. </summary>
        public static CidrAdvertisingGeoCode Euro { get; } = new CidrAdvertisingGeoCode("EURO");
        /// <summary> GLOBAL. </summary>
        public static CidrAdvertisingGeoCode Global { get; } = new CidrAdvertisingGeoCode("GLOBAL");
        /// <summary> LATAM. </summary>
        public static CidrAdvertisingGeoCode Latam { get; } = new CidrAdvertisingGeoCode("LATAM");
        /// <summary> ME. </summary>
        public static CidrAdvertisingGeoCode ME { get; } = new CidrAdvertisingGeoCode("ME");
        /// <summary> NAM. </summary>
        public static CidrAdvertisingGeoCode Nam { get; } = new CidrAdvertisingGeoCode("NAM");
        /// <summary> OCEANIA. </summary>
        public static CidrAdvertisingGeoCode Oceania { get; } = new CidrAdvertisingGeoCode("OCEANIA");

        /// <inheritdoc/>
        public bool Equals(CidrAdvertisingGeoCode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is CidrAdvertisingGeoCode other && Equals(other);
        /// <inheritdoc/>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary> Compares two <see cref="CidrAdvertisingGeoCode"/> values for equality. </summary>
        public static bool operator ==(CidrAdvertisingGeoCode left, CidrAdvertisingGeoCode right) => left.Equals(right);
        /// <summary> Converts a string to a <see cref="CidrAdvertisingGeoCode"/>. </summary>
        public static implicit operator CidrAdvertisingGeoCode(string value) => new CidrAdvertisingGeoCode(value);
        /// <summary> Compares two <see cref="CidrAdvertisingGeoCode"/> values for inequality. </summary>
        public static bool operator !=(CidrAdvertisingGeoCode left, CidrAdvertisingGeoCode right) => !left.Equals(right);
        /// <inheritdoc/>
        public override string ToString() => _value ?? string.Empty;
    }
}
