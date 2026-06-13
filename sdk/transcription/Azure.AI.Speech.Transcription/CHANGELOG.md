# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

- Documented that `Locales` is now honored in Enhanced Mode. The service operates in multi-lingual mode by default; if specified, the first locale is used as a hint to guide recognition.

## 1.0.0 (2026-05-14)

First stable release of the Azure.AI.Speech.Transcription client library.

### Breaking Changes

- Removed `TranscriptionResult.PhrasesByChannel` and the associated `TranscribedPhrases` type. Use `TranscriptionResult.Phrases` for the flat phrase list and `TranscriptionResult.CombinedPhrases` for the per-channel combined transcript.

## 1.0.0-beta.2 (2026-04-20)

### Other Changes

- Fixed broken links and corrected sample code in the README.

## 1.0.0-beta.1 (2026-02-10)

### Features Added

- Initial release of the Azure.AI.Speech.Transcription client library.
