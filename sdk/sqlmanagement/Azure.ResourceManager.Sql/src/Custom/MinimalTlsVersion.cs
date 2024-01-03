// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A struct representing a MinimalTlsVersion
    /// </summary>
	public partial struct MinimalTlsVersion
	{
		private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="MinimalTlsVersion"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MinimalTlsVersion(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string Tls_None = "None";
        private const string Tls1_0Value = "1.0";
        private const string Tls1_1Value = "1.1";
        private const string Tls1_2Value = "1.2";
        private const string Tls1_3Value = "1.3";

		/// <summary> None. </summary>
		[CodeGenMember("None")]
        public static MinimalTlsVersion TlsNone { get; } = new MinimalTlsVersion(Tls_None);
		/// <summary> 1.0. </summary>
		[CodeGenMember("One0")]
        public static MinimalTlsVersion Tls1_0 { get; } = new MinimalTlsVersion(Tls1_0Value);
		/// <summary> 1.1. </summary>
		[CodeGenMember("One1")]
        public static MinimalTlsVersion Tls1_1 { get; } = new MinimalTlsVersion(Tls1_1Value);
        /// <summary> 1.2. </summary>
		[CodeGenMember("One2")]
        public static MinimalTlsVersion Tls1_2 { get; } = new MinimalTlsVersion(Tls1_2Value);
        /// <summary> 1.3. </summary>
		[CodeGenMember("One3")]
        public static MinimalTlsVersion Tls1_3 { get; } = new MinimalTlsVersion(Tls1_3Value);
	}
}