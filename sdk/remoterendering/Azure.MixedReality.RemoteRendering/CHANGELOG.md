# Release History

## 1.2.1-beta.1 (Unreleased)

### Other Changes
- Renamed `conversionId` and `sessionId` tags reported on `RemoteRenderingClient` activities to `az.remoterendering.conversion.id` and `az.remoterendering.session.id` following OpenTelemetry attribute naming conventions.

## 1.2.1 (2022-08-09)
- Minor documentation fixes.

## 1.2.0-beta.1 (2021-11-16)
- The SDK now defaults to a 2s polling interval when waiting for a Standard sized rendering VM. For Premium, 10s is still used.

## 1.1.0 (2021-09-17)
- Ensure the MS-CV header is not redacted in logs. If you are logging an issue, it can be useful to quote this value.

## 1.0.1 (2021-05-25)
- Update dependency versions

## 1.0.0 (2021-03-02)
- Release client.

## 1.0.0-beta.3 (2021-02-24)
- Allow the STS endpoint to be customized.
- Changed constructors to align with guidance.

## 1.0.0-beta.2 (2021-02-16)
- Reflect minor REST API improvements.
- Make more classes mockable.

## 1.0.0-beta.1 (2021-02-10)
- Initial version of client.
