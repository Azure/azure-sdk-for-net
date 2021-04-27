// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    /// Initializes a new instance of the MediaGraphPemCertificateList class.
    /// </summary>
    public partial class MediaGraphPemCertificateList
    {
        /// <summary>
        /// How long the base 64 lines should be.
        /// </summary>
        private const int Base64LineLength = 76;

        /// <summary>
        /// Header for a PEM formatted certificate.
        /// </summary>
        /// <remarks>
        /// See https://tools.ietf.org/html/rfc7468 Section 5.1.
        /// </remarks>
        private const string PemCertificateHeader = "-----BEGIN CERTIFICATE-----";

        /// <summary>
        /// Footer for a PEM formatted certificate.
        /// </summary>
        /// <remarks>
        /// See https://tools.ietf.org/html/rfc7468 Section 5.1.
        /// </remarks>
        private const string PemCertificateFooter = "-----END CERTIFICATE-----";

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaGraphPemCertificateList"/> class.
        /// </summary>
        /// <param name="certificates"> The list of certificates.</param>
        public MediaGraphPemCertificateList(IList<X509Certificate2> certificates)
        {
            if (certificates == null)
            {
                throw new ArgumentNullException(nameof(certificates));
            }

            Certificates = certificates.Select(ConvertToPemString).ToList();
            Type = "#Microsoft.Media.MediaGraphPemCertificateList";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaGraphPemCertificateList"/> class.
        /// </summary>
        /// <param name="certificates"> The certificates params.</param>
        public MediaGraphPemCertificateList(params X509Certificate2[] certificates)
        {
            if (certificates == null)
            {
                throw new ArgumentNullException(nameof(certificates));
            }

            Certificates = certificates.Select(ConvertToPemString).ToList();
            Type = "#Microsoft.Media.MediaGraphPemCertificateList";
        }

        private static string ConvertToPemString(X509Certificate2 certificate)
        {
            return new StringBuilder()
                .AppendLine(PemCertificateHeader)

                // Ideally this would be the following, but it is not supported in earlier versions of .NET
                // .AppendLine(Convert.ToBase64String(certificate.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks))
                .AppendLine(ToFormattedBase64String(certificate.Export(X509ContentType.Cert)))
                .AppendLine(PemCertificateFooter)
                .ToString();
        }

        private static string ToFormattedBase64String(byte[] data)
        {
            // Insert line breaks every 76 characters to match the implementation in netstandard2.0
            // https://docs.microsoft.com/en-us/dotnet/api/system.convert.tobase64string?view=netcore-3.1#System_Convert_ToBase64String_System_Byte___System_Base64FormattingOptions_
            var encoded = Convert.ToBase64String(data);
            var result = new StringBuilder();

            for (var position = 0; position < encoded.Length; position += Base64LineLength)
            {
                if (position + Base64LineLength < encoded.Length)
                {
                    var line = encoded.Substring(position, Base64LineLength);
                    result.AppendLine(line);
                }
                else
                {
                    var line = encoded.Substring(position, encoded.Length - position);
                    result.Append(line);
                }
            }

            return result.ToString();
        }
    }
}
