import type FastGlob from 'fast-glob';

export type GlobEntry = FastGlob.Entry;

export type GlobTask = {
	readonly patterns: string[];
	readonly options: Options;
};

export type ExpandDirectoriesOption =
	| boolean
	| readonly string[]
	| {files?: readonly string[]; extensions?: readonly string[]};

type FastGlobOptionsWithoutCwd = Omit<FastGlob.Options, 'cwd'>;

export type Options = {
	/**
	If set to `true`, `globby` will automatically glob directories for you. If you define an `Array` it will only glob files that matches the patterns inside the `Array`. You can also define an `Object` with `files` and `extensions` like in the example below.

	Note that if you set this option to `false`, you won't get back matched directories unless you set `onlyFiles: false`.

	@default true

	@example
	```
	import {globby} from 'globby';

	const paths = await globby('images', {
		expandDirectories: {
			files: ['cat', 'unicorn', '*.jpg'],
			extensions: ['png']
		}
	});

	console.log(paths);
	//=> ['cat.png', 'unicorn.png', 'cow.jpg', 'rainbow.jpg']
	```
	*/
	readonly expandDirectories?: ExpandDirectoriesOption;

	/**
	Respect ignore patterns in `.gitignore` files that apply to the globbed files.

	When enabled, globby searches for `.gitignore` files from the current working directory downward, and if a Git repository is detected (by finding a `.git` directory), it also respects `.gitignore` files in parent directories up to the repository root. This matches Git's actual behavior where patterns from parent `.gitignore` files apply to subdirectories.

	Gitignore patterns take priority over user patterns, matching Git's behavior. To include gitignored files, set this to `false`.

	Performance: Globby reads `.gitignore` files before globbing. When there are no negation patterns (like `!important.log`) and no parent `.gitignore` files are found, it passes ignore patterns to fast-glob to skip traversing ignored directories entirely, which significantly improves performance for large `node_modules` or build directories. When negation patterns or parent `.gitignore` files are present, all filtering is done after traversal to ensure correct Git-compatible behavior. For optimal performance, prefer specific `.gitignore` patterns without negations, or use `ignoreFiles: '.gitignore'` to target only the root ignore file.

	@default false
	*/
	readonly gitignore?: boolean;

	/**
	Glob patterns to look for ignore files, which are then used to ignore globbed files.

	This is a more generic form of the `gitignore` option, allowing you to find ignore files with a [compatible syntax](http://git-scm.com/docs/gitignore). For instance, this works with Babel's `.babelignore`, Prettier's `.prettierignore`, or ESLint's `.eslintignore` files.

	Performance tip: Using a specific path like `'.gitignore'` is much faster than recursive patterns.

	@default undefined
	*/
	readonly ignoreFiles?: string | readonly string[];

	/**
	The current working directory in which to search.

	@default process.cwd()
	*/
	readonly cwd?: URL | string;
} & FastGlobOptionsWithoutCwd;

export type GitignoreOptions = {
	/**
	The current working directory in which to search.

	@default process.cwd()
	*/
	readonly cwd?: URL | string;

	/**
	Suppress errors when encountering directories or files without read permissions.

	By default, fast-glob only suppresses `ENOENT` errors. Set to `true` to suppress any error.

	@default false
	*/
	readonly suppressErrors?: boolean;

	/**
	Specifies the maximum depth of ignore file search relative to the start directory.

	@default Infinity
	*/
	readonly deep?: number;

	/**
	Glob patterns to exclude from ignore file search.

	@default []
	*/
	readonly ignore?: string | readonly string[];

	/**
	Indicates whether to traverse descendants of symbolic link directories.

	@default true
	*/
	readonly followSymbolicLinks?: boolean;

	/**
	Specifies the maximum number of concurrent requests from a reader to read directories.

	@default os.cpus().length
	*/
	readonly concurrency?: number;

	/**
	Throw an error when symbolic link is broken if `true` or safely return `lstat` call if `false`.

	@default false
	*/
	readonly throwErrorOnBrokenSymbolicLink?: boolean;

	/**
	Custom file system implementation (useful for testing or virtual file systems).

	@default undefined
	*/
	readonly fs?: FastGlob.Options['fs'];
};

export type GlobbyFilterFunction = (path: URL | string) => boolean;

type AsyncIterableReadable<Value> = Omit<NodeJS.ReadableStream, typeof Symbol.asyncIterator> & {
	[Symbol.asyncIterator](): NodeJS.AsyncIterator<Value>;
};

/**
A readable stream that yields string paths from glob patterns.
*/
export type GlobbyStream = AsyncIterableReadable<string>;

/**
A readable stream that yields `GlobEntry` objects from glob patterns when `objectMode` is enabled.
*/
export type GlobbyEntryStream = AsyncIterableReadable<GlobEntry>;

/**
Find files and directories using glob patterns.

Note that glob patterns can only contain forward-slashes, not backward-slashes, so if you want to construct a glob pattern from path components, you need to use `path.posix.join()` instead of `path.join()`.

Windows: Patterns with backslashes will silently fail. Use `path.posix.join()` or `convertPathToPattern()`.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns). Supports negation patterns to exclude files. When using only negation patterns (like `['!*.json']`), globby implicitly prepends a catch-all pattern to match all files before applying negations.
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns The matching paths.

@example
```
import {globby} from 'globby';

const paths = await globby(['*', '!cake']);

console.log(paths);
//=> ['unicorn', 'rainbow']
```

@example
```
import {globby} from 'globby';

// Negation-only patterns match all files except the negated ones
const paths = await globby(['!*.json', '!*.xml'], {cwd: 'config'});

console.log(paths);
//=> ['config.js', 'settings.yaml']
```
*/
export function globby(
	patterns: string | readonly string[],
	options: Options & ({objectMode: true} | {stats: true})
): Promise<GlobEntry[]>;
export function globby(
	patterns: string | readonly string[],
	options?: Options
): Promise<string[]>;

/**
Find files and directories using glob patterns.

Note that glob patterns can only contain forward-slashes, not backward-slashes, so if you want to construct a glob pattern from path components, you need to use `path.posix.join()` instead of `path.join()`.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns The matching paths.
*/
export function globbySync(
	patterns: string | readonly string[],
	options: Options & ({objectMode: true} | {stats: true})
): GlobEntry[];
export function globbySync(
	patterns: string | readonly string[],
	options?: Options
): string[];

/**
Find files and directories using glob patterns.

Note that glob patterns can only contain forward-slashes, not backward-slashes, so if you want to construct a glob pattern from path components, you need to use `path.posix.join()` instead of `path.join()`.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns The stream of matching paths.

@example
```
import {globbyStream} from 'globby';

for await (const path of globbyStream('*.tmp')) {
	console.log(path);
}
```
*/
export function globbyStream(
	patterns: string | readonly string[],
	options: Options & ({objectMode: true} | {stats: true})
): GlobbyEntryStream;
export function globbyStream(
	patterns: string | readonly string[],
	options?: Options
): GlobbyStream;

/**
Note that you should avoid running the same tasks multiple times as they contain a file system cache. Instead, run this method each time to ensure file system changes are taken into consideration.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns An object in the format `{pattern: string, options: object}`, which can be passed as arguments to [`fast-glob`](https://github.com/mrmlnc/fast-glob). This is useful for other globbing-related packages.
*/
export function generateGlobTasks(
	patterns: string | readonly string[],
	options?: Options
): Promise<GlobTask[]>;

/**
@see generateGlobTasks

@returns An object in the format `{pattern: string, options: object}`, which can be passed as arguments to [`fast-glob`](https://github.com/mrmlnc/fast-glob). This is useful for other globbing-related packages.
*/
export function generateGlobTasksSync(
	patterns: string | readonly string[],
	options?: Options
): GlobTask[];

/**
Note that the options affect the results.

This function is backed by [`fast-glob`](https://github.com/mrmlnc/fast-glob#isdynamicpatternpattern-options).

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3).
@returns Whether there are any special glob characters in the `patterns`.
*/
export function isDynamicPattern(
	patterns: string | readonly string[],
	options?: FastGlobOptionsWithoutCwd & {
		/**
		The current working directory in which to search.

		@default process.cwd()
		*/
		readonly cwd?: URL | string;
	}
): boolean;

/**
`.gitignore` files matched by the ignore config are not used for the resulting filter function.

@returns A filter function indicating whether a given path is ignored via a `.gitignore` file.

@example
```
import {isGitIgnored} from 'globby';

const isIgnored = await isGitIgnored();

console.log(isIgnored('some/file'));
```
*/
export function isGitIgnored(options?: GitignoreOptions): Promise<GlobbyFilterFunction>;

/**
@see isGitIgnored

@returns A filter function indicating whether a given path is ignored via a `.gitignore` file.
*/
export function isGitIgnoredSync(options?: GitignoreOptions): GlobbyFilterFunction;

/**
Converts a path to a pattern by escaping special glob characters like `()`, `[]`, `{}`. On Windows, also converts backslashes to forward slashes.

Use this when your literal paths contain characters with special meaning in globs.

@param source - A file system path to convert to a safe glob pattern.
@returns The path with special glob characters escaped.

@example
```
import {globby, convertPathToPattern} from 'globby';

// ❌ Fails - parentheses are glob syntax
await globby('C:/Program Files (x86)/*.txt');
//=> []

// ✅ Works
const base = convertPathToPattern('C:/Program Files (x86)');
await globby(`${base}/*.txt`);
//=> ['C:/Program Files (x86)/file.txt']
```
*/
export function convertPathToPattern(source: string): FastGlob.Pattern;

/**
Check if a path is ignored by the ignore files.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns A filter function indicating whether a given path is ignored via the ignore files.

This is a more generic form of the `isGitIgnored` function, allowing you to find ignore files with a [compatible syntax](http://git-scm.com/docs/gitignore). For instance, this works with Babel's `.babelignore`, Prettier's `.prettierignore`, or ESLint's `.eslintignore` files.

@example
```
import {isIgnoredByIgnoreFiles} from 'globby';

const isIgnored = await isIgnoredByIgnoreFiles('**\/.gitignore');

console.log(isIgnored('some/file'));
```
*/
export function isIgnoredByIgnoreFiles(
	patterns: string | readonly string[],
	options?: Options
): Promise<GlobbyFilterFunction>;

/**
Check if a path is ignored by the ignore files.

@param patterns - See the supported [glob patterns](https://github.com/sindresorhus/globby#globbing-patterns).
@param options - See the [`fast-glob` options](https://github.com/mrmlnc/fast-glob#options-3) in addition to the ones in this package.
@returns A filter function indicating whether a given path is ignored via the ignore files.

This is a more generic form of the `isGitIgnored` function, allowing you to find ignore files with a [compatible syntax](http://git-scm.com/docs/gitignore). For instance, this works with Babel's `.babelignore`, Prettier's `.prettierignore`, or ESLint's `.eslintignore` files.

@see {@link isIgnoredByIgnoreFiles}

@example
```
import {isIgnoredByIgnoreFilesSync} from 'globby';

const isIgnored = isIgnoredByIgnoreFilesSync('**\/.gitignore');

console.log(isIgnored('some/file'));
```
*/
export function isIgnoredByIgnoreFilesSync(
	patterns: string | readonly string[],
	options?: Options
): GlobbyFilterFunction;
