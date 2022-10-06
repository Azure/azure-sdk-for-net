# devtestcenter

> see https://aka.ms/autorest

This is the AutoRest configuration file for Azure.Developer.DevCenter.

## Getting Started

To build the SDKs for My API, simply install AutoRest via `npm` (`npm install -g autorest`) and then run:

> `autorest readme.md`

To see additional help and options, run:

> `autorest --help`

For other options on installation see [Installing AutoRest](https://aka.ms/autorest/install) on the AutoRest github page.

---

## Configuration

### Basic Information

These are the global settings for Azure.Developer.DevCenter.

```yaml
openapi-type: data-plane
azure-arm: false
tag: v2022-03-01-preview
eol: crlf
license-header: MICROSOFT_MIT_NO_VERSION
public-clients: true

input-file:
  - C:\Users\chrismiller\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\devcenter.json
  - C:\Users\chrismiller\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\devbox.json
  - C:\Users\chrismiller\source\repos\azure-devtest-center\src\sdk\specification\devcenter\data-plane\Microsoft.DevCenter\preview\2022-03-01-preview\environments.json

csharp/simplifier:
  plugin: csharp-simplifier
  input: generate
  output-artifact: source-file-csharp
  suffixes:
    - ""
```


## CSharp

See configuration in [readme.csharp.md](./readme.csharp.md)

## TypeScript

See configuration in [readme.typescript.md](./readme.typescript.md)