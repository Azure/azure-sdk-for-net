# Swap Case

> Transform a string by swapping every character from upper to lower case, or lower to upper case.

## Installation

```
npm install swap-case --save
```

## Usage

```js
import { swapCase } from "swap-case";

swapCase("string"); //=> "STRING"
swapCase("dot.case"); //=> "DOT.CASE"
swapCase("PascalCase"); //=> "pASCALcASE"
```

## TypeScript and ESM

This package is a [pure ESM package](https://gist.github.com/sindresorhus/a39789f98801d908bbc7ff3ecc99d99c) and ships with TypeScript definitions. It cannot be `require`'d or used with CommonJS module resolution in TypeScript.

## License

MIT
