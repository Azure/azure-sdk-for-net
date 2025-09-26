# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes
### Breaking Changes

### Type Changes from Enums to Extensible Enums

Several enum types have been converted to extensible enums (struct-based) for better extensibility:

### AnimationOutputType
- **Before**: `enum AnimationOutputType`
- **After**: `readonly partial struct AnimationOutputType`
- **Impact**: The type is now an extensible enum. Existing code using the enum values will continue to work due to implicit conversions.

### AudioNoiseReductionType
- **Before**: `enum AudioNoiseReductionType`
- **After**: `readonly partial struct AudioNoiseReductionType`
- **Impact**: The type is now an extensible enum. Existing code using the enum values will continue to work due to implicit conversions.

### ItemParamStatus
- **Before**: `enum ItemParamStatus`
- **After**: `readonly partial struct ItemParamStatus`
- **Impact**: The type is now an extensible enum. Existing code using the enum values will continue to work due to implicit conversions.

### ResponseCancelledDetailsReason
- **Before**: `enum ResponseCancelledDetailsReason`
- **After**: `readonly partial struct ResponseCancelledDetailsReason`
- **Impact**: The type is now an extensible enum. Existing code using the enum values will continue to work due to implicit conversions.

### ResponseIncompleteDetailsReason
- **Before**: `enum ResponseIncompleteDetailsReason`
- **After**: `readonly partial struct ResponseIncompleteDetailsReason`
- **Impact**: The type is now an extensible enum. Existing code using the enum values will continue to work due to implicit conversions.

## Class and Property Renames

### AudioInputTranscriptionSettings → AudioInputTranscriptionOptions
- **Type renamed**: `AudioInputTranscriptionSettings` is now `AudioInputTranscriptionOptions`
- **Model property renamed**: `AudioInputTranscriptionSettingsModel` is now `AudioInputTranscriptionOptionsModel`
- **Impact**: Update all references to use the new type name.

### InputModality → InteractionModality
- **Type renamed**: `InputModality` is now `InteractionModality`
- **Impact**: Update all references from `InputModality` to `InteractionModality` throughout your code.

### ResponseMaxOutputTokensOption → MaxResponseOutputTokensOption
- **Type renamed**: `ResponseMaxOutputTokensOption` is now `MaxResponseOutputTokensOption`
- **Impact**: Update all type references to use the new name.

### Removed Types

### UserContentPart (abstract base class)
- **Removed**: The abstract `UserContentPart` class has been removed.
- **Replacement**: Use the new `MessageContentPart` abstract base class instead.
- **Impact**: Update inheritance hierarchies to use `MessageContentPart`.

### AzureSemanticEnEouDetection
- **Removed**: This class has been removed.
- **Replacement**: Use `AzureSemanticEouDetectionEn` instead.

### AzureSemanticMultilingualEouDetection
- **Removed**: This class has been removed.
- **Replacement**: Use `AzureSemanticEouDetectionMultilingual` instead.

### AzureSemanticVadEnTurnDetection
- **Removed**: This class has been removed.
- **Replacement**: Use `AzureSemanticVadTurnDetectionEn` instead.

### AzureSemanticVadMultilingualTurnDetection
- **Removed**: This class has been removed.
- **Replacement**: Use `AzureSemanticVadTurnDetectionMultilingual` instead.

### Property Removals

### AnimationOptions
- **Removed properties**:
  - `EmotionDetectionInterval`
  - `EmotionDetectionIntervalMs`
- **Impact**: Remove any code that sets or reads these properties.

### AzureSemanticEouDetection family
- **Changed property**: `Threshold` (float) has been replaced with `ThresholdLevel` using new threshold level types:
  - `AzureSemanticDetectionThresholdLevel` for `AzureSemanticEouDetection`
  - `AzureSemanticDetectionEnThresholdLevel` for `AzureSemanticEouDetectionEn`
  - `AzureSemanticDetectionMultilingualThresholdLevel` for `AzureSemanticEouDetectionMultilingual`
- **Impact**: Update code to use the new `ThresholdLevel` property with appropriate enum values (Default, Low, Medium, High).

### Constructor and Method Signature Changes

### MessageItem
- **Constructor changed**:
  - **Before**: `MessageItem(string role)`
  - **After**: `MessageItem(ResponseMessageRole role, IEnumerable<MessageContentPart> content)`
- **Impact**: Update all MessageItem instantiations to provide both role and content parameters.

### AssistantMessageItem
- **Constructor changed**:
  - **Before**: Accepted `OutputTextContentPart` or `IEnumerable<OutputTextContentPart>`
  - **After**: Accepts `MessageContentPart`, `IEnumerable<MessageContentPart>`, or a string
- **Property changed**: `Content` is now `IList<MessageContentPart>` instead of `IList<OutputTextContentPart>`

### SystemMessageItem
- **Constructor changed**:
  - **Before**: Accepted `InputTextContentPart` or `IEnumerable<InputTextContentPart>`
  - **After**: Accepts `InputTextContentPart`, `IEnumerable<MessageContentPart>`, or a string
- **Property changed**: `Content` is now part of base `MessageItem` as `IList<MessageContentPart>`

### UserMessageItem
- **Constructor changed**:
  - **Before**: Accepted `UserContentPart` or `IEnumerable<UserContentPart>`
  - **After**: Accepts `InputTextContentPart`, `IEnumerable<MessageContentPart>`, or a string
- **Property changed**: `Content` is now part of base `MessageItem` as `IList<MessageContentPart>`

### ToolChoiceOption
- **Constructor parameter renamed**:
  - **Before**: `ToolChoiceOption(string stringValue)`
  - **After**: `ToolChoiceOption(string functionName)`
- **Impact**: The parameter name has changed, but functionality remains the same.

### Service Version Changes

### VoiceLiveClientOptions
- **Default service version changed**:
  - **Before**: `ServiceVersion.V2025_05_01_Preview`
  - **After**: `ServiceVersion.V2025_10_01`
- **Impact**: The client now defaults to a newer, non-preview API version.

### Class Inheritance Changes

### VoiceLiveClientOptions
- **Before**: Inherited from `Azure.Core.ClientOptions`
- **After**: No longer inherits from `ClientOptions`, but provides a `DiagnosticsOptions` property
- **Impact**: Some properties previously available through inheritance may need to be accessed differently.

### Content Part Classes
- `InputAudioContentPart`: Now inherits from `MessageContentPart` instead of `UserContentPart`
- `InputTextContentPart`: Now inherits from `MessageContentPart` instead of `UserContentPart`
- `OutputTextContentPart`: Now inherits from `MessageContentPart` instead of being standalone

### New Required Properties

### Turn Detection Classes
Several turn detection classes have new properties that should be considered:
- `CreateResponse` (bool?): Added to `ServerVadTurnDetection`, `AzureSemanticVadTurnDetection`, and related classes
- `InterruptResponse` (bool?): Added to the same turn detection classes

### VideoParams
- New optional properties:
  - `Background` (VideoBackground): Configure video background settings
  - `GopSize` (int?): Configure Group of Pictures size

### Property Access Changes

### VoiceLiveClient
- **Removed**: `Pipeline` property is no longer publicly accessible
- **Impact**: If you were accessing the HTTP pipeline directly, you'll need to find alternative approaches.

### VoiceLiveResponse
- **Property changed**: `Modalities` is now `ModalitiesInternal` and returns `IList<InteractionModality>` instead of `SessionUpdateModality`

### Migration Guide

1. **Update enum usage**: While the conversion to extensible enums maintains backward compatibility through implicit conversions, consider updating to use the new struct-based pattern for future-proofing.

2. **Rename types**: Find and replace all occurrences of renamed types:
   - `AudioInputTranscriptionSettings` → `AudioInputTranscriptionOptions`
   - `InputModality` → `InteractionModality`
   - `ResponseMaxOutputTokensOption` → `MaxResponseOutputTokensOption`

3. **Update inheritance**: Replace `UserContentPart` with `MessageContentPart` in any custom implementations.

4. **Update constructors**: Review and update all MessageItem-derived class instantiations to use the new constructor signatures.

5. **Update threshold properties**: Replace float `Threshold` properties with appropriate `ThresholdLevel` properties using the new enum values.

6. **Consider new properties**: Review the new `CreateResponse` and `InterruptResponse` properties in turn detection configurations to see if they benefit your use case.

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2025-09-22)

### Features Added
Added overloads for MessageItem creation to accept a single content part.

### Breaking Changes
AudioFormat was split into InputAudioFormat and OutputAudioFormat.
Emotion classes / options dropped.
Eou and TurnDetection classes renamed.
API properties that were duration based are now TimeSpans
Methods to configure session collapsed to ConfigureSession
Renamed ToolChoiceFunctionObjectFunction to ToolChoiceFunctionObject

## 1.0.0-beta.1 (2025-09-16)

### Features Added
Initial Addition of VoiceLiveClient and associated classes.
