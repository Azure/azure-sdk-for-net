# unicorn-magic

> Some useful utilities I often need

*I'm not accepting requests.*

## Install

```sh
npm install unicorn-magic
```

## Usage

```js
import {delay} from 'unicorn-magic';

await delay({seconds: 1});

console.log('1 second later');
```

You can also import from the `/node` sub-export to explicitly get the Node.js-specific utilities (useful for bundler compatibility):

```js
import {toPath} from 'unicorn-magic/node';
```

## API

See the [Node.js types](node.d.ts) and [default types](default.d.ts).
