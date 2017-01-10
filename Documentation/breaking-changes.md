# Breaking Change Definition

Breaking changes in Azure SDK for .NET are defined as follows:

## Generated classes

- The class is removed
- The class is renamed
- The class no longer extends another class

## Properties of a generated class

- A property is removed
- A property is renamed
- A property has its type changed

## Methods of a generated class
- Methods should not be removed
- Methods should not be renamed
- Methods should not have their return type changed

## Parameters of methods in a generated class
- Parameters should not be removed
- Parameters should not have their type changed
- Parameters should preserve their ordering, including when a parameter is added
- Parameters should keep their default value, if they are assigned one