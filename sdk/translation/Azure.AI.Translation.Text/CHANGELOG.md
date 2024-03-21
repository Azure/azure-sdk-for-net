# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Introduced model factory `Azure.AI.Translation.Text.TextTranslationModelFactory` for mocking.
- Added options overloads to Translate and Transliterate. TextTranslationTranslateOptions and TextTranslationTransliterateOptions roll up method parameters into a single object.
- Add support for using AAD authentication.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2023-04-17)
Initial version of Text Translation client library for .NET

### Features Added
- Added support for Text Translation - [Translate API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-translate)
- Added support for Text Transliteration - [Transliterate API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-transliterate)
- Added support for Finding Sentence Boundaries - [FindSentenceBoundaries API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-break-sentence)
- Added support for Getting the Supported Languages - [GetLanguages API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-languages)
- Added support for Looking up the Dictionary Entries - [LookupDictionaryEntries API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-dictionary-lookup)
- Added support for Looking up the Dictionary Examples - [LookupDictionaryExamples API](https://learn.microsoft.com/azure/cognitive-services/translator/reference/v3-0-dictionary-examples)

