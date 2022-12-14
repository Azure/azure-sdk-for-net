# Release History

## 2.8.0-preview.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.8.0-preview.3 (2022-11-25)

### Breaking Changes
- Id fields in responses for Person and Face objects from Person Directory are no longer nullable as they are guaranteed to be returned.
- The non-functional AddPersonFaceAsync method has been removed from Person Directory.

### Bugs Fixed
- Fix mismatching data types between request and response for personId and persistedFaceId in Person Directory. New extension methods expecting GUIDs have been added alongside the existing string ones
- Fix the missing parameter "url" in Person Directory AddPersonFaceAsync, which is now renamed to AddPersonFaceFromUrlAsync for clarity.

### Other Changes
- Change default value for returnFaceId parameter to false in detection operations. 

## 2.8.0-preview.2 (2021-11-15)

- Add support for new detection attribute `qualityForRecognition`
- Note that this version points to the face/v1.0-preview (public preview) endpoints.

## 2.7.0-preview.2 (2021-11-15)
- Add support for new detection attribute `qualityForRecognition`

## 2.8.0-preview.1 (2021-07-21)

- Add support for the Person Directory feature
- Note that this version points to the face/v1.0-preview (public preview) endpoints.

## 2.7.0-preview.1 (2021-03-25)

- Add support for new detection model `detection_03`, new recognition model `recognition_04`, and new mask attribute model

## 2.6.0-preview.1 (2020-08-11)

- Add support for new recognition model `recognition_03`
