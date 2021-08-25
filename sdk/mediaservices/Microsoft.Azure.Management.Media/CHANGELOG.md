# Microsoft.Azure.Management.Media release notes

## Changes in 4.0.0

- Added KeyDelivery Access control property to Media Services that allows restricting KeyDelivery requests by IP address ranges

### Breaking changes

- Media serice constructor has new optional Key delivery parameter after encryption parameter.
- Media service update call is expecting an object of a new class MediaServiceUpdate. The MediaServiceUpdate class is similar to MediaService class, except it doesn't have location property.

## Changes in 3.0.4

This SDK is using 2020-05-01 version of the API.

New features added to encoder:

- Added new built-in encoder presets for H265
- Input track and stream selection
- Audio channel mapping
- Stitching of multiple clips

## Changes in 3.0.3

- Fixed a bug with AssemblyFile version.

## Changes in 3.0.2

This SDK is using 2020-05-01 version of the API

- The Media Services account now supports system managed identities.
- When a Media Services account has a managed identity, it can be used to enable encryption at REST with a customer managed key.
- When a Media Services account has a managed identity, it can be used to access the attached storage accounts using the managed identity.
- Live event added an Allocate action to put it into StandBy state.
- Updates to most live event properties are now allowed when the live event is in stopped and standby state.
- Users can specify a prefix for the static hostname for the live event's input and preview URLs.
- VanityUrl is now called useStaticHostName to better reflect the intent of the property.
- When an encoding live event receives input with aspect ratio different from the one specified in the preset, stretch mode allows customers to specify the stretching behavior for the output.
- Encoding live events can now be configured to output constant fragment size of between 0.5 to 20 seconds.
- Live transcription APIs allow customers to turn on live transcription for one of the many supported languages.
- Added property Video.SyncMode which controls the frame rate of the encoded output. Supported values are "Auto", "Passthrough", "Cfr", and "Vfr".
- Added Property JpgImage.SpriteColumn, which can be used to set the number of columns used in thumbnail sprite image
- Added CopyAllBitrateNonInterleaved Preset, which can be used to clip an existing asset or convert a group of key frame (GOP) aligned MP4 files as an asset that can be streamed.
- Added UtcClipTime class, which specifies the clip time as a Utc time position in the media file during a job creation.
- Added the “Mode” property to Audio/VideoAnalyzerPresets, exposing a new Basic Mode that only performs transcription and caption generation.

### Breaking changes:

- VanityUrl property on LiveEvent is now called UseStaticHostName to better reflect the intent of the property.
- SubscriptionMediaService class has been removed in favor of MediaService class. SubscriptionMediaService is a duplicate of MediaService class.
- Basic and Standard live encoding types referred to the same live event type. Basic LiveEventEncodingType has now been removed. Supported encoding types are Standard, Premium1080p or None.
