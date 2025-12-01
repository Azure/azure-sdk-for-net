# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

- `DnsAaaRecordInfo`: `Ipv6Addresses` renamed to `Ipv6Address`
- `DnsARecordInfo `: `ipv4Addresses` renamed to `Ipv4Address`

### Bugs Fixed

- `DnsCnameRecord.Cname`: property is now backed by the correct Bicep field ( `.properties.CNAMERecord.cname` )

### Other Changes

## 1.0.0-beta.1 (2025-11-07)

### Features Added

- Initial beta release of new Azure.Provisioning.Dns.
