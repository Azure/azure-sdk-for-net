import process from 'node:process';
import fs from 'node:fs';
import fsPromises from 'node:fs/promises';
import path from 'node:path';
import fastGlob from 'fast-glob';
import gitIgnore from 'ignore';
import isPathInside from 'is-path-inside';
import slash from 'slash';
import {toPath} from 'unicorn-magic/node';
import {
	isNegativePattern,
	bindFsMethod,
	promisifyFsMethod,
	findGitRoot,
	findGitRootSync,
	getParentGitignorePaths,
} from './utilities.js';

const defaultIgnoredDirectories = [
	'**/node_modules',
	'**/flow-typed',
	'**/coverage',
	'**/.git',
];
const ignoreFilesGlobOptions = {
	absolute: true,
	dot: true,
};

export const GITIGNORE_FILES_PATTERN = '**/.gitignore';

const getReadFileMethod = fsImplementation =>
	bindFsMethod(fsImplementation?.promises, 'readFile')
	?? bindFsMethod(fsPromises, 'readFile')
	?? promisifyFsMethod(fsImplementation, 'readFile');

const getReadFileSyncMethod = fsImplementation =>
	bindFsMethod(fsImplementation, 'readFileSync')
	?? bindFsMethod(fs, 'readFileSync');

const shouldSkipIgnoreFileError = (error, suppressErrors) => {
	if (!error) {
		return Boolean(suppressErrors);
	}

	if (error.code === 'ENOENT' || error.code === 'ENOTDIR') {
		return true;
	}

	return Boolean(suppressErrors);
};

const createIgnoreFileReadError = (filePath, error) => {
	if (error instanceof Error) {
		error.message = `Failed to read ignore file at ${filePath}: ${error.message}`;
		return error;
	}

	return new Error(`Failed to read ignore file at ${filePath}: ${String(error)}`);
};

const processIgnoreFileCore = (filePath, readMethod, suppressErrors) => {
	try {
		const content = readMethod(filePath, 'utf8');
		return {filePath, content};
	} catch (error) {
		if (shouldSkipIgnoreFileError(error, suppressErrors)) {
			return undefined;
		}

		throw createIgnoreFileReadError(filePath, error);
	}
};

const readIgnoreFilesSafely = async (paths, readFileMethod, suppressErrors) => {
	const fileResults = await Promise.all(paths.map(async filePath => {
		try {
			const content = await readFileMethod(filePath, 'utf8');
			return {filePath, content};
		} catch (error) {
			if (shouldSkipIgnoreFileError(error, suppressErrors)) {
				return undefined;
			}

			throw createIgnoreFileReadError(filePath, error);
		}
	}));

	return fileResults.filter(Boolean);
};

const readIgnoreFilesSafelySync = (paths, readFileSyncMethod, suppressErrors) => paths
	.map(filePath => processIgnoreFileCore(filePath, readFileSyncMethod, suppressErrors))
	.filter(Boolean);

const dedupePaths = paths => {
	const seen = new Set();
	return paths.filter(filePath => {
		if (seen.has(filePath)) {
			return false;
		}

		seen.add(filePath);
		return true;
	});
};

const globIgnoreFiles = (globFunction, patterns, normalizedOptions) => globFunction(patterns, {
	...normalizedOptions,
	...ignoreFilesGlobOptions, // Must be last to ensure absolute/dot flags stick
});

const getParentIgnorePaths = (gitRoot, normalizedOptions) => gitRoot
	? getParentGitignorePaths(gitRoot, normalizedOptions.cwd)
	: [];

const combineIgnoreFilePaths = (gitRoot, normalizedOptions, childPaths) => dedupePaths([
	...getParentIgnorePaths(gitRoot, normalizedOptions),
	...childPaths,
]);

const buildIgnoreResult = (files, normalizedOptions, gitRoot) => {
	const baseDir = gitRoot || normalizedOptions.cwd;
	const patterns = getPatternsFromIgnoreFiles(files, baseDir);

	return {
		patterns,
		predicate: createIgnorePredicate(patterns, normalizedOptions.cwd, baseDir),
		usingGitRoot: Boolean(gitRoot && gitRoot !== normalizedOptions.cwd),
	};
};

// Apply base path to gitignore patterns based on .gitignore spec 2.22.1
// https://git-scm.com/docs/gitignore#_pattern_format
// See also https://github.com/sindresorhus/globby/issues/146
const applyBaseToPattern = (pattern, base) => {
	if (!base) {
		return pattern;
	}

	const isNegative = isNegativePattern(pattern);
	const cleanPattern = isNegative ? pattern.slice(1) : pattern;

	// Check if pattern has non-trailing slashes
	const slashIndex = cleanPattern.indexOf('/');
	const hasNonTrailingSlash = slashIndex !== -1 && slashIndex !== cleanPattern.length - 1;

	let result;
	if (!hasNonTrailingSlash) {
		// "If there is no separator at the beginning or middle of the pattern,
		// then the pattern may also match at any level below the .gitignore level."
		// So patterns like '*.log' or 'temp' or 'build/' (trailing slash) match recursively.
		result = path.posix.join(base, '**', cleanPattern);
	} else if (cleanPattern.startsWith('/')) {
		// "If there is a separator at the beginning [...] of the pattern,
		// then the pattern is relative to the directory level of the particular .gitignore file itself."
		// Leading slash anchors the pattern to the .gitignore's directory.
		result = path.posix.join(base, cleanPattern.slice(1));
	} else {
		// "If there is a separator [...] middle [...] of the pattern,
		// then the pattern is relative to the directory level of the particular .gitignore file itself."
		// Patterns like 'src/foo' are relative to the .gitignore's directory.
		result = path.posix.join(base, cleanPattern);
	}

	return isNegative ? '!' + result : result;
};

const parseIgnoreFile = (file, cwd) => {
	const base = slash(path.relative(cwd, path.dirname(file.filePath)));

	return file.content
		.split(/\r?\n/)
		.filter(line => line && !line.startsWith('#'))
		.map(pattern => applyBaseToPattern(pattern, base));
};

const toRelativePath = (fileOrDirectory, cwd) => {
	if (path.isAbsolute(fileOrDirectory)) {
		// When paths are equal, path.relative returns empty string which is valid
		// isPathInside returns false for equal paths, so check this case first
		const relativePath = path.relative(cwd, fileOrDirectory);
		if (relativePath && !isPathInside(fileOrDirectory, cwd)) {
			// Path is outside cwd - it cannot be ignored by patterns in cwd
			// Return undefined to indicate this path is outside scope
			return undefined;
		}

		return relativePath;
	}

	// Normalize relative paths:
	// - Git treats './foo' as 'foo' when checking against patterns
	// - Patterns starting with './' in .gitignore are invalid and don't match anything
	// - The ignore library expects normalized paths without './' prefix
	if (fileOrDirectory.startsWith('./')) {
		return fileOrDirectory.slice(2);
	}

	// Paths with ../ point outside cwd and cannot match patterns from this directory
	// Return undefined to indicate this path is outside scope
	if (fileOrDirectory.startsWith('../')) {
		return undefined;
	}

	return fileOrDirectory;
};

const createIgnorePredicate = (patterns, cwd, baseDir) => {
	const ignores = gitIgnore().add(patterns);
	// Normalize to handle path separator and . / .. components consistently
	const resolvedCwd = path.normalize(path.resolve(cwd));
	const resolvedBaseDir = path.normalize(path.resolve(baseDir));

	return fileOrDirectory => {
		fileOrDirectory = toPath(fileOrDirectory);

		// Never ignore the cwd itself - use normalized comparison
		const normalizedPath = path.normalize(path.resolve(fileOrDirectory));
		if (normalizedPath === resolvedCwd) {
			return false;
		}

		// Convert to relative path from baseDir (use normalized baseDir)
		const relativePath = toRelativePath(fileOrDirectory, resolvedBaseDir);

		// If path is outside baseDir (undefined), it can't be ignored by patterns
		if (relativePath === undefined) {
			return false;
		}

		return relativePath ? ignores.ignores(slash(relativePath)) : false;
	};
};

const normalizeOptions = (options = {}) => {
	const ignoreOption = options.ignore
		? (Array.isArray(options.ignore) ? options.ignore : [options.ignore])
		: [];

	const cwd = toPath(options.cwd) ?? process.cwd();

	// Adjust deep option for fast-glob: fast-glob's deep counts differently than expected
	// User's deep: 0 = root only -> fast-glob needs: 1
	// User's deep: 1 = root + 1 level -> fast-glob needs: 2
	const deep = typeof options.deep === 'number' ? Math.max(0, options.deep) + 1 : Number.POSITIVE_INFINITY;

	// Only pass through specific fast-glob options that make sense for finding ignore files
	return {
		cwd,
		suppressErrors: options.suppressErrors ?? false,
		deep,
		ignore: [...ignoreOption, ...defaultIgnoredDirectories],
		followSymbolicLinks: options.followSymbolicLinks ?? true,
		concurrency: options.concurrency,
		throwErrorOnBrokenSymbolicLink: options.throwErrorOnBrokenSymbolicLink ?? false,
		fs: options.fs,
	};
};

const collectIgnoreFileArtifactsAsync = async (patterns, options, includeParentIgnoreFiles) => {
	const normalizedOptions = normalizeOptions(options);
	const childPaths = await globIgnoreFiles(fastGlob, patterns, normalizedOptions);
	const gitRoot = includeParentIgnoreFiles
		? await findGitRoot(normalizedOptions.cwd, normalizedOptions.fs)
		: undefined;
	const allPaths = combineIgnoreFilePaths(gitRoot, normalizedOptions, childPaths);
	const readFileMethod = getReadFileMethod(normalizedOptions.fs);
	const files = await readIgnoreFilesSafely(allPaths, readFileMethod, normalizedOptions.suppressErrors);

	return {files, normalizedOptions, gitRoot};
};

const collectIgnoreFileArtifactsSync = (patterns, options, includeParentIgnoreFiles) => {
	const normalizedOptions = normalizeOptions(options);
	const childPaths = globIgnoreFiles(fastGlob.sync, patterns, normalizedOptions);
	const gitRoot = includeParentIgnoreFiles
		? findGitRootSync(normalizedOptions.cwd, normalizedOptions.fs)
		: undefined;
	const allPaths = combineIgnoreFilePaths(gitRoot, normalizedOptions, childPaths);
	const readFileSyncMethod = getReadFileSyncMethod(normalizedOptions.fs);
	const files = readIgnoreFilesSafelySync(allPaths, readFileSyncMethod, normalizedOptions.suppressErrors);

	return {files, normalizedOptions, gitRoot};
};

export const isIgnoredByIgnoreFiles = async (patterns, options) => {
	const {files, normalizedOptions, gitRoot} = await collectIgnoreFileArtifactsAsync(patterns, options, false);
	return buildIgnoreResult(files, normalizedOptions, gitRoot).predicate;
};

export const isIgnoredByIgnoreFilesSync = (patterns, options) => {
	const {files, normalizedOptions, gitRoot} = collectIgnoreFileArtifactsSync(patterns, options, false);
	return buildIgnoreResult(files, normalizedOptions, gitRoot).predicate;
};

const getPatternsFromIgnoreFiles = (files, baseDir) => files.flatMap(file => parseIgnoreFile(file, baseDir));

/**
Read ignore files and return both patterns and predicate.
This avoids reading the same files twice (once for patterns, once for filtering).

@param {string[]} patterns - Patterns to find ignore files
@param {Object} options - Options object
@param {boolean} [includeParentIgnoreFiles=false] - Whether to search for parent .gitignore files
@returns {Promise<{patterns: string[], predicate: Function, usingGitRoot: boolean}>}
*/
export const getIgnorePatternsAndPredicate = async (patterns, options, includeParentIgnoreFiles = false) => {
	const {files, normalizedOptions, gitRoot} = await collectIgnoreFileArtifactsAsync(
		patterns,
		options,
		includeParentIgnoreFiles,
	);

	return buildIgnoreResult(files, normalizedOptions, gitRoot);
};

/**
Read ignore files and return both patterns and predicate (sync version).

@param {string[]} patterns - Patterns to find ignore files
@param {Object} options - Options object
@param {boolean} [includeParentIgnoreFiles=false] - Whether to search for parent .gitignore files
@returns {{patterns: string[], predicate: Function, usingGitRoot: boolean}}
*/
export const getIgnorePatternsAndPredicateSync = (patterns, options, includeParentIgnoreFiles = false) => {
	const {files, normalizedOptions, gitRoot} = collectIgnoreFileArtifactsSync(
		patterns,
		options,
		includeParentIgnoreFiles,
	);

	return buildIgnoreResult(files, normalizedOptions, gitRoot);
};

export const isGitIgnored = options => isIgnoredByIgnoreFiles(GITIGNORE_FILES_PATTERN, options);
export const isGitIgnoredSync = options => isIgnoredByIgnoreFilesSync(GITIGNORE_FILES_PATTERN, options);
