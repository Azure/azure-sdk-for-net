# Sponge Case

> Transform into a string with random capitalization applied.

## Installation

```
npm install sponge-case --save
```

## Usage

```js
import { spongeCase } from "sponge-case";

spongeCase("string"); //=> "sTrinG"
spongeCase("dot.case"); //=> "dOt.caSE"
spongeCase("PascalCase"); //=> "pASCaLCasE"
spongeCase("version 1.2.10"); //=> "VErSIoN 1.2.10"
```

## TypeScript and ESM

This package is a [pure ESM package](https://gist.github.com/sindresorhus/a39789f98801d908bbc7ff3ecc99d99c) and ships with TypeScript definitions. It cannot be `require`'d or used with CommonJS module resolution in TypeScript.

## License

MIT
