# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-05-21)

### Features Added

- Introduced model factory `Azure.AI.Translation.Text.TextTranslationModelFactory` for mocking.
- Added options overloads to Translate and Transliterate. TextTranslationTranslateOptions and TextTranslationTransliterateOptions roll up method parameters into a single object.
- Add support for using AAD authentication.

### Breaking Changes

- Changed the method `GetLanguages` to `GetSupportedLanguages`.
- Changed the name of `Score` property to `Confidence` in `DetectedLanguage`.
- Changed the name of `Dir` property to `Directionality` in `Languages` models. Changed the type from `string` to `Azure.AI.Translation.Text.LanguageDirectionality`.
- Changed the name of `Azure.AI.Translation.Text.Translation` to `Azure.AI.Translation.Text.TranslationText`.
- Changed the name of `SentLen` property to `SentencesLengths` in `BreakSentenceItem`.
- Changed type name from `SentenceLength` to `SentenceBoundaries`.
- Changed the name of `Proj` property to `Projections` in `TranslatedTextAlignment` type.

## 1.0.0-beta.1 (2023-04-17)
Initial version of Text Translation client library for .NET

### Features Added
- Added support for Text Translation - [Translate API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate)
- Added support for Text Transliteration - [Transliterate API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-transliterate)
- Added support for Finding Sentence Boundaries - [FindSentenceBoundaries API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-break-sentence)
- Added support for Getting the Supported Languages - [GetLanguages API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-languages)
- Added support for Looking up the Dictionary Entries - [LookupDictionaryEntries API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-dictionary-lookup)
- Added support for Looking up the Dictionary Examples - [LookupDictionaryExamples API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-dictionary-examples)

