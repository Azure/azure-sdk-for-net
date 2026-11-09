// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve None = 4 from 1.1.0; the new VirtualApplianceEcmp takes the next free ordinal.
[assembly: CodeGenEnumValue("RouteNextHopType", "None", 4)]

// Preserve the released TLS 1.3 spelling at the same ordinal as its canonical name.
// Pin both names because reserving the alias alone would shift Tls1_3 to 4.
[assembly: CodeGenEnumValue("ApplicationGatewaySslProtocol", "Tls1_3", 3)]
[assembly: CodeGenEnumValue("ApplicationGatewaySslProtocol", "TLSv13", 3, WireName = "TLSv1_3", EditorBrowsableNever = true)]

// Reserve the missing leading values from 1.1.0; the remaining generated members
// then receive their original ordinals without individual overrides.
[assembly: CodeGenEnumValue("ApplicationGatewayCustomErrorStatusCode", "HttpStatus499", 0, WireName = "HttpStatus499", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("FirewallPolicyIntrusionDetectionProfileType", "Basic", 0, WireName = "Basic", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("FirewallPolicyIntrusionDetectionProfileType", "Standard", 1, WireName = "Standard", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("FirewallPolicyIntrusionDetectionProfileType", "Advanced", 2, WireName = "Advanced", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("LoadBalancerBackendAddressAdminState", "Drain", 0, WireName = "Drain", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("ManagedRuleSensitivityType", "None", 0, WireName = "None", EditorBrowsableNever = true)]

// Both released spellings represent AAD, but have distinct numeric values.
// Reserving them also restores Certificate = 1 and Radius = 2.
[assembly: CodeGenEnumValue("VpnAuthenticationType", "AAD", 0)]
[assembly: CodeGenEnumValue("VpnAuthenticationType", "Aad", 3, WireName = "AAD", EditorBrowsableNever = true)]

// Preserve the removed SHA384 value and the reordered GCM values. Uncustomized
// MD5/SHA1/SHA256 stay at 0/1/2, and the new GCMAES192 takes the next free value, 6.
[assembly: CodeGenEnumValue("IPsecIntegrity", "Sha384", 3, WireName = "SHA384", EditorBrowsableNever = true)]
[assembly: CodeGenEnumValue("IPsecIntegrity", "GcmAes256", 4)]
[assembly: CodeGenEnumValue("IPsecIntegrity", "GcmAes128", 5)]
