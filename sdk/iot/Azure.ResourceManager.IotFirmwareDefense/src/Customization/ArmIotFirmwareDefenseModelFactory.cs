// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmIotFirmwareDefenseModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.BinaryHardeningResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="binaryHardeningId"> ID for the binary hardening result. </param>
        /// <param name="architecture"> The architecture of the uploaded firmware. </param>
        /// <param name="filePath"> The executable path. </param>
        /// <param name="class"> The executable class to indicate 32 or 64 bit. </param>
        /// <param name="runpath"> The runpath of the uploaded firmware. </param>
        /// <param name="rpath"> The rpath of the uploaded firmware. </param>
        /// <param name="nxFlag"> NX (no-execute) flag. </param>
        /// <param name="pieFlag"> PIE (position independent executable) flag. </param>
        /// <param name="relroFlag"> RELRO (relocation read-only) flag. </param>
        /// <param name="canaryFlag"> Canary (stack canaries) flag. </param>
        /// <param name="strippedFlag"> Stripped flag. </param>
        /// <returns> A new <see cref="Models.BinaryHardeningResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BinaryHardeningResult BinaryHardeningResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string binaryHardeningId, string architecture = null, string filePath = null, string @class = null, string runpath = null, string rpath = null, bool? nxFlag = null, bool? pieFlag = null, bool? relroFlag = null, bool? canaryFlag = null, bool? strippedFlag = null) =>
            BinaryHardeningResult(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                binaryHardeningId: binaryHardeningId,
                securityHardeningFeatures: new BinaryHardeningFeatures(nxFlag, pieFlag, relroFlag, canaryFlag, strippedFlag, serializedAdditionalRawData: null),
                executableArchitecture: architecture,
                filePath: filePath,
                executableClass: @class,
                runpath: runpath,
                rpath: rpath);

        /// <summary> Initializes a new instance of <see cref="Models.CryptoCertificateResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="cryptoCertId"> ID for the certificate result. </param>
        /// <param name="namePropertiesName"> Name of the certificate. </param>
        /// <param name="subject"> Subject information of the certificate. </param>
        /// <param name="issuer"> Issuer information of the certificate. </param>
        /// <param name="issuedOn"> Issue date for the certificate. </param>
        /// <param name="expireOn"> Expiration date for the certificate. </param>
        /// <param name="role"> Role of the certificate (Root CA, etc). </param>
        /// <param name="signatureAlgorithm"> The signature algorithm used in the certificate. </param>
        /// <param name="keySize"> Size of the certificate's key in bits. </param>
        /// <param name="keyAlgorithm"> Key algorithm used in the certificate. </param>
        /// <param name="encoding"> Encoding used for the certificate. </param>
        /// <param name="serialNumber"> Serial number of the certificate. </param>
        /// <param name="fingerprint"> Fingerprint of the certificate. </param>
        /// <param name="usage"> List of functions the certificate can fulfill. </param>
        /// <param name="filePaths"> List of files where this certificate was found. </param>
        /// <param name="pairedKey"> A matching paired private key. </param>
        /// <param name="isExpired"> Indicates if the certificate is expired. </param>
        /// <param name="isSelfSigned"> Indicates if the certificate is self-signed. </param>
        /// <param name="isWeakSignature"> Indicates the signature algorithm used is insecure. </param>
        /// <param name="isShortKeySize"> Indicates the certificate's key size is considered too small to be secure for the key algorithm. </param>
        /// <returns> A new <see cref="Models.CryptoCertificateResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CryptoCertificateResult CryptoCertificateResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string cryptoCertId, string namePropertiesName = null, CryptoCertificateEntity subject = null, CryptoCertificateEntity issuer = null, DateTimeOffset? issuedOn = null, DateTimeOffset? expireOn = null, string role = null, string signatureAlgorithm = null, long? keySize = null, string keyAlgorithm = null, string encoding = null, string serialNumber = null, string fingerprint = null, IEnumerable<string> usage = null, IEnumerable<string> filePaths = null, CryptoPairedKey pairedKey = null, bool? isExpired = null, bool? isSelfSigned = null, bool? isWeakSignature = null, bool? isShortKeySize = null)
        {
            usage ??= new List<string>();
            filePaths ??= new List<string>();

            var certificateUsage = new List<CertificateUsage>();
            foreach (string usageString in usage)
            {
                certificateUsage.Add(new CertificateUsage(usageString));
            }

            return CryptoCertificateResult(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                cryptoCertId: cryptoCertId,
                certificateName: namePropertiesName,
                subject: subject,
                issuer: issuer,
                issuedOn: issuedOn,
                expireOn: expireOn,
                certificateRole: role,
                signatureAlgorithm: signatureAlgorithm,
                certificateKeySize: keySize,
                certificateKeyAlgorithm: keyAlgorithm,
                encoding: encoding,
                serialNumber: serialNumber,
                fingerprint: fingerprint,
                certificateUsage: certificateUsage,
                filePaths: filePaths?.ToList(),
                pairedKey: pairedKey,
                isExpired: isExpired,
                isSelfSigned: isSelfSigned,
                isWeakSignature: isWeakSignature,
                isShortKeySize: isShortKeySize
            );
        }

        /// <summary> Initializes a new instance of <see cref="Models.CryptoKeyResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="cryptoKeyId"> ID for the key result. </param>
        /// <param name="keyType"> Type of the key (public or private). </param>
        /// <param name="keySize"> Size of the key in bits. </param>
        /// <param name="keyAlgorithm"> Key algorithm name. </param>
        /// <param name="usage"> Functions the key can fulfill. </param>
        /// <param name="filePaths"> List of files where this key was found. </param>
        /// <param name="pairedKey"> A matching paired key or certificate. </param>
        /// <param name="isShortKeySize"> Indicates the key size is considered too small to be secure for the algorithm. </param>
        /// <returns> A new <see cref="Models.CryptoKeyResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CryptoKeyResult CryptoKeyResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string cryptoKeyId, string keyType, long? keySize = null, string keyAlgorithm = null, IEnumerable<string> usage = null, IEnumerable<string> filePaths = null, CryptoPairedKey pairedKey = null, bool? isShortKeySize = null)
        {
            usage ??= new List<string>();
            filePaths ??= new List<string>();

            return CryptoKeyResult(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                cryptoKeyId: cryptoKeyId,
                cryptoKeyType: keyType,
                cryptoKeySize: keySize,
                keyAlgorithm: keyAlgorithm,
                cryptoKeyUsage: usage?.ToList(),
                filePaths: filePaths?.ToList(),
                pairedKey: pairedKey,
                isShortKeySize: isShortKeySize
            );
        }

        /// <summary> Initializes a new instance of <see cref="Models.CveResult"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="cveId"> ID of the CVE result. </param>
        /// <param name="component"> The SBOM component for the CVE. </param>
        /// <param name="severity"> Severity of the CVE. </param>
        /// <param name="namePropertiesName"> Name of the CVE. </param>
        /// <param name="cvssScore"> A single CVSS score to represent the CVE. If a V3 score is specified, then it will use the V3 score. Otherwise if the V2 score is specified it will be the V2 score. </param>
        /// <param name="cvssVersion"> CVSS version of the CVE. </param>
        /// <param name="cvssV2Score"> CVSS V2 score of the CVE. </param>
        /// <param name="cvssV3Score"> CVSS V3 score of the CVE. </param>
        /// <param name="links"> The list of reference links for the CVE. </param>
        /// <param name="description"> The CVE description. </param>
        /// <returns> A new <see cref="Models.CveResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CveResult CveResult(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string cveId, CveComponent component = null, string severity = null, string namePropertiesName = null, string cvssScore = null, string cvssVersion = null, string cvssV2Score = null, string cvssV3Score = null, IEnumerable<CveLink> links = null, string description = null)
        {
            links ??= new List<CveLink>();

            var cves = new List<CvssScore>();
            var cvss2score = new CvssScore(2);
            cvss2score.Score = float.Parse(cvssV2Score);
            cves.Add(cvss2score);

            var cvss3score = new CvssScore(3);
            cvss3score.Score = float.Parse(cvssV3Score);
            cves.Add(cvss3score);

            return CveResult(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                cveId: cveId,
                componentId: component.ComponentId,
                componentName: component.Name,
                componentVersion: component.Version,
                severity: severity,
                cveName: namePropertiesName,
                effectiveCvssScore: cvss3score.Score > 0 ? cvss3score.Score : cvss2score.Score,
                effectiveCvssVersion: cvss3score.Score > 0 ? 3: 2,
                cvssScores: cves,
                links: links?.ToList(),
                description: description
            );
        }

         /// <summary> Initializes a new instance of <see cref="Models.FirmwareAnalysisWorkspacePatch"/>. </summary>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <returns> A new <see cref="Models.FirmwareAnalysisWorkspacePatch"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FirmwareAnalysisWorkspacePatch FirmwareAnalysisWorkspacePatch(FirmwareProvisioningState? provisioningState = null)
        {
            return new FirmwareAnalysisWorkspacePatch();
        }

        /// <summary> Initializes a new instance of <see cref="Models.CveSummary"/>. </summary>
        /// <param name="critical"> The total number of critical severity CVEs detected. </param>
        /// <param name="high"> The total number of high severity CVEs detected. </param>
        /// <param name="medium"> The total number of medium severity CVEs detected. </param>
        /// <param name="low"> The total number of low severity CVEs detected. </param>
        /// <param name="unknown"> The total number of unknown severity CVEs detected. </param>
        /// <returns> A new <see cref="Models.CveSummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CveSummary CveSummary(long? critical = null, long? high = null, long? medium = null, long? low = null, long? unknown = null) =>
            CveSummary(
                critical: critical,
                high: high,
                medium: medium,
                low: low,
                unknown: unknown);

        /// <summary> Initializes a new instance of <see cref="Models.BinaryHardeningSummary"/>. </summary>
        /// <param name="totalFiles"> Total number of binaries that were analyzed. </param>
        /// <param name="nxPercentage"> NX summary percentage. </param>
        /// <param name="piePercentage"> PIE summary percentage. </param>
        /// <param name="relroPercentage"> RELRO summary percentage. </param>
        /// <param name="canaryPercentage"> Canary summary percentage. </param>
        /// <param name="strippedPercentage"> Stripped summary percentage. </param>
        /// <returns> A new <see cref="Models.BinaryHardeningSummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BinaryHardeningSummary BinaryHardeningSummary(long? totalFiles = null, int? nxPercentage = null, int? piePercentage = null, int? relroPercentage = null, int? canaryPercentage = null, int? strippedPercentage = null) =>
            BinaryHardeningSummary(
                totalFiles: totalFiles,
                notExecutableStackCount: nxPercentage,
                positionIndependentExecutableCount: piePercentage,
                relocationReadOnlyCount: relroPercentage,
                stackCanaryCount: canaryPercentage,
                strippedBinaryCount: strippedPercentage);

        /// <summary> Initializes a new instance of <see cref="Models.CryptoCertificateSummary"/>. </summary>
        /// <param name="totalCertificates"> Total number of certificates found. </param>
        /// <param name="pairedKeys"> Total number of paired private keys found for the certificates. </param>
        /// <param name="expired"> Total number of expired certificates found. </param>
        /// <param name="expiringSoon"> Total number of nearly expired certificates found. </param>
        /// <param name="weakSignature"> Total number of certificates found using a weak signature algorithm. </param>
        /// <param name="selfSigned"> Total number of certificates found that are self-signed. </param>
        /// <param name="shortKeySize"> Total number of certificates found that have an insecure key size for the key algorithm. </param>
        /// <returns> A new <see cref="Models.CryptoCertificateSummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CryptoCertificateSummary CryptoCertificateSummary(long? totalCertificates = null, long? pairedKeys = null, long? expired = null, long? expiringSoon = null, long? weakSignature = null, long? selfSigned = null, long? shortKeySize = null) =>
            CryptoCertificateSummary(
                totalCertificateCount: totalCertificates,
                pairedKeyCount: pairedKeys,
                expiredCertificateCount: expired,
                expiringSoonCertificateCount: expiringSoon,
                weakSignatureCount: weakSignature,
                selfSignedCertificateCount: selfSigned,
                shortKeySizeCount: shortKeySize);

        /// <summary> Initializes a new instance of <see cref="Models.CryptoKeySummary"/>. </summary>
        /// <param name="totalKeys"> Total number of cryptographic keys found. </param>
        /// <param name="publicKeys"> Total number of (non-certificate) public keys found. </param>
        /// <param name="privateKeys"> Total number of private keys found. </param>
        /// <param name="pairedKeys"> Total number of keys found that have a matching paired key or certificate. </param>
        /// <param name="shortKeySize"> Total number of keys found that have an insecure key size for the algorithm. </param>
        /// <returns> A new <see cref="Models.CryptoKeySummary"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CryptoKeySummary CryptoKeySummary(long? totalKeys = null, long? publicKeys = null, long? privateKeys = null, long? pairedKeys = null, long? shortKeySize = null) =>
            CryptoKeySummary(
                totalKeyCount: totalKeys,
                publicKeyCount: publicKeys,
                privateKeyCount: privateKeys,
                pairedKeyCount: pairedKeys,
                shortKeySizeCount: shortKeySize);
    }
}
