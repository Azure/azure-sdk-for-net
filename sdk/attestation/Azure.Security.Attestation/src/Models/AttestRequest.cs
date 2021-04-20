// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// Represents the data sent to the Attestation Service for a call to the <see cref="AttestationClient.AttestOpenEnclave(AttestRequest, System.Threading.CancellationToken)"/> or <see cref="AttestationClient.AttestSgxEnclave(AttestRequest, System.Threading.CancellationToken)"/> APIs.
    ///
    /// An Attestation Request has three pieces:
    /// <list type="bullet">
    /// <item>
    ///     <term>Evidence</term>
    ///     <description>The attestation evidence generated from inside the target environment (often an Intel SGX or OpenEnclave enclave).
    ///     The 'Evidence' is normally an SGX Quote, an OpenEnclave Report, or OpenEnclave Evidence.</description>
    /// </item>
    /// <item>
    ///     <term>InitTime Data</term>
    ///     <description>Data presented at the time that the target environment was initialized.</description>
    /// </item>
    /// <item>
    ///     <term>Runtime Data</term>
    ///     <description>Data presented at the time that the Evidence was created.</description>
    /// </item>
    /// </list>
    /// </summary>
    public class AttestRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestRequest"/> class.
        /// </summary>
        /// <param name="evidence">Evidence generated from the target environment.</param>
        /// <param name="initTimeData">Data provided when the environment was created.</param>
        /// <param name="runTimeData">Data created when the evidence was created.</param>
        /// <param name="draftPolicyForAttestation">Optional 'draft' policy to be used in this attestation request. This can be used to test policy documents without affecting the service instance.</param>
        public AttestRequest(BinaryData evidence = null, AttestationData initTimeData = null, AttestationData runTimeData = null, string draftPolicyForAttestation = null)
        {
            Evidence = evidence;
            InittimeData = initTimeData;
            RuntimeData = runTimeData;
            DraftPolicyForAttestation = draftPolicyForAttestation;
        }

        /// <summary>
        /// The attestation evidence generated from inside the target environment (often an Intel SGX or OpenEnclave enclave).
        /// The 'Evidence' is normally an SGX Quote, an OpenEnclave Report, or OpenEnclave Evidence.
        /// </summary>
        public BinaryData Evidence { get; set; }

        /// <summary>
        /// Initialization Data provided when the target environment was created.
        ///
        /// <remark>Note that InitTime data is not supported on Azure DCsv2-Series virtual machines.</remark>
        /// </summary>
        public AttestationData InittimeData { get; set; }

        /// <summary>
        /// Runtime Data provided when the Evidence was created.
        /// </summary>
        public AttestationData RuntimeData { get; set; }

        /// <summary>
        /// Optional 'draft' policy for attestation. If this field is provided, then this policy document will be used for the attestation request.
        /// This allows a caller to test various policy documents against actual data before applying the policy document via the <see cref="AttestationAdministrationClient.SetPolicy(AttestationType, string, AttestationTokenSigningKey, System.Threading.CancellationToken)"/> API.
        /// </summary>
        public string DraftPolicyForAttestation { get; set; }
    }
}
