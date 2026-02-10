import fs from 'node:fs';
import path from 'node:path';
import {promisify} from 'node:util';
import isPathInside from 'is-path-inside';

export const isNegativePattern = pattern => pattern[0] === '!';

export const bindFsMethod = (object, methodName) => {
	const method = object?.[methodName];
	return typeof method === 'function' ? method.bind(object) : undefined;
};

// Only used as a fallback for legacy fs implementations
export const promisifyFsMethod = (object, methodName) => {
	const method = object?.[methodName];
	if (typeof method !== 'function') {
		return undefined;
	}

	return promisify(method.bind(object));
};

export const normalizeDirectoryPatternForFastGlob = pattern => {
	if (!pattern.endsWith('/')) {
		return pattern;
	}

	const trimmedPattern = pattern.replace(/\/+$/u, '');
	if (!trimmedPattern) {
		return '/**';
	}

	// Special case for '**/' to avoid producing '**/**/**'
	if (trimmedPattern === '**') {
		return '**/**';
	}

	const hasLeadingSlash = trimmedPattern.startsWith('/');
	const patternBody = hasLeadingSlash ? trimmedPattern.slice(1) : trimmedPattern;
	const hasInnerSlash = patternBody.includes('/');
	const needsRecursivePrefix = !hasLeadingSlash && !hasInnerSlash && !trimmedPattern.startsWith('**/');
	const recursivePrefix = needsRecursivePrefix ? '**/' : '';

	return `${recursivePrefix}${trimmedPattern}/**`;
};

/**
Extract the parent directory prefix from a pattern (e.g., '../' or '../../').

Note: Patterns should have trailing slash after '..' (e.g., '../foo' not '..foo'). The directoryToGlob function ensures this in the normal pipeline.

@param {string} pattern - The pattern to analyze.
@returns {string} The parent directory prefix, or empty string if none.
*/
export const getParentDirectoryPrefix = pattern => {
	const normalizedPattern = isNegativePattern(pattern) ? pattern.slice(1) : pattern;
	const match = normalizedPattern.match(/^(\.\.\/)+/);
	return match ? match[0] : '';
};

/**
Adjust ignore patterns to match the relative base of the main patterns.

When patterns reference parent directories, ignore patterns starting with globstars need to be adjusted to match from the same base directory. This ensures intuitive behavior where ignore patterns work correctly with parent directory patterns.

This is analogous to how node-glob normalizes path prefixes (see node-glob issue #309) and how Rust ignore crate strips path prefixes before matching.

@param {string[]} patterns - The main glob patterns.
@param {string[]} ignorePatterns - The ignore patterns to adjust.
@returns {string[]} Adjusted ignore patterns.
*/
export const adjustIgnorePatternsForParentDirectories = (patterns, ignorePatterns) => {
	// Early exit for empty arrays
	if (patterns.length === 0 || ignorePatterns.length === 0) {
		return ignorePatterns;
	}

	// Get parent directory prefixes for all patterns (empty string if no prefix)
	const parentPrefixes = patterns.map(pattern => getParentDirectoryPrefix(pattern));

	// Check if all patterns have the same parent prefix
	const firstPrefix = parentPrefixes[0];
	if (!firstPrefix) {
		return ignorePatterns; // No parent directories in any pattern
	}

	const allSamePrefix = parentPrefixes.every(prefix => prefix === firstPrefix);
	if (!allSamePrefix) {
		return ignorePatterns; // Mixed bases - don't adjust
	}

	// Adjust ignore patterns that start with **/
	return ignorePatterns.map(pattern => {
		// Only adjust patterns starting with **/ that don't already have a parent reference
		if (pattern.startsWith('**/') && !pattern.startsWith('../')) {
			return firstPrefix + pattern;
		}

		return pattern;
	});
};

/**
Find the git root directory by searching upward for a .git directory.

@param {string} cwd - The directory to start searching from.
@param {Object} [fsImplementation] - Optional fs implementation.
@returns {string|undefined} The git root directory path, or undefined if not found.
*/
const getAsyncStatMethod = fsImplementation =>
	bindFsMethod(fsImplementation?.promises, 'stat')
	?? bindFsMethod(fs.promises, 'stat');

const getStatSyncMethod = fsImplementation => {
	if (fsImplementation) {
		return bindFsMethod(fsImplementation, 'statSync');
	}

	return bindFsMethod(fs, 'statSync');
};

const pathHasGitDirectory = stats => Boolean(stats?.isDirectory?.() || stats?.isFile?.());

const buildPathChain = (startPath, rootPath) => {
	const chain = [];
	let currentPath = startPath;

	chain.push(currentPath);

	while (currentPath !== rootPath) {
		const parentPath = path.dirname(currentPath);
		if (parentPath === currentPath) {
			break;
		}

		currentPath = parentPath;
		chain.push(currentPath);
	}

	return chain;
};

const findGitRootInChain = async (paths, statMethod) => {
	for (const directory of paths) {
		const gitPath = path.join(directory, '.git');

		try {
			const stats = await statMethod(gitPath); // eslint-disable-line no-await-in-loop
			if (pathHasGitDirectory(stats)) {
				return directory;
			}
		} catch {
			// Ignore errors and continue searching
		}
	}

	return undefined;
};

const findGitRootSyncUncached = (cwd, fsImplementation) => {
	const statSyncMethod = getStatSyncMethod(fsImplementation);
	if (!statSyncMethod) {
		return undefined;
	}

	const currentPath = path.resolve(cwd);
	const {root} = path.parse(currentPath);
	const chain = buildPathChain(currentPath, root);

	for (const directory of chain) {
		const gitPath = path.join(directory, '.git');
		try {
			const stats = statSyncMethod(gitPath);
			if (pathHasGitDirectory(stats)) {
				return directory;
			}
		} catch {
			// Ignore errors and continue searching
		}
	}

	return undefined;
};

export const findGitRootSync = (cwd, fsImplementation) => {
	if (typeof cwd !== 'string') {
		throw new TypeError('cwd must be a string');
	}

	return findGitRootSyncUncached(cwd, fsImplementation);
};

const findGitRootAsyncUncached = async (cwd, fsImplementation) => {
	const statMethod = getAsyncStatMethod(fsImplementation);
	if (!statMethod) {
		return findGitRootSync(cwd, fsImplementation);
	}

	const currentPath = path.resolve(cwd);
	const {root} = path.parse(currentPath);
	const chain = buildPathChain(currentPath, root);

	return findGitRootInChain(chain, statMethod);
};

export const findGitRoot = async (cwd, fsImplementation) => {
	if (typeof cwd !== 'string') {
		throw new TypeError('cwd must be a string');
	}

	return findGitRootAsyncUncached(cwd, fsImplementation);
};

/**
Get paths to all .gitignore files from git root to cwd (inclusive).

@param {string} gitRoot - The git root directory.
@param {string} cwd - The current working directory.
@returns {string[]} Array of .gitignore file paths to search for.
*/
const isWithinGitRoot = (gitRoot, cwd) => {
	const resolvedGitRoot = path.resolve(gitRoot);
	const resolvedCwd = path.resolve(cwd);
	return resolvedCwd === resolvedGitRoot || isPathInside(resolvedCwd, resolvedGitRoot);
};

export const getParentGitignorePaths = (gitRoot, cwd) => {
	if (gitRoot && typeof gitRoot !== 'string') {
		throw new TypeError('gitRoot must be a string or undefined');
	}

	if (typeof cwd !== 'string') {
		throw new TypeError('cwd must be a string');
	}

	// If no gitRoot provided, return empty array
	if (!gitRoot) {
		return [];
	}

	if (!isWithinGitRoot(gitRoot, cwd)) {
		return [];
	}

	const chain = buildPathChain(path.resolve(cwd), path.resolve(gitRoot));

	return [...chain]
		.reverse()
		.map(directory => path.join(directory, '.gitignore'));
};

/**
Convert ignore patterns to fast-glob compatible format.
Returns empty array if patterns should be handled by predicate only.

@param {string[]} patterns - Ignore patterns from .gitignore files
@param {boolean} usingGitRoot - Whether patterns are relative to git root
@param {Function} normalizeDirectoryPatternForFastGlob - Function to normalize directory patterns
@returns {string[]} Patterns safe to pass to fast-glob, or empty array
*/
export const convertPatternsForFastGlob = (patterns, usingGitRoot, normalizeDirectoryPatternForFastGlob) => {
	// Determine which patterns are safe to pass to fast-glob
	// If there are negation patterns, we can't pass file patterns to fast-glob
	// because fast-glob doesn't understand negations and would filter out files
	// that should be re-included by negation patterns.
	// If we're using git root, patterns are relative to git root not cwd,
	// so we can't pass them to fast-glob which expects cwd-relative patterns.
	// We only pass patterns to fast-glob if there are NO negations AND we're not using git root.

	if (usingGitRoot) {
		return []; // Patterns are relative to git root, not cwd
	}

	const result = [];
	let hasNegations = false;

	// Single pass to check for negations and collect positive patterns
	for (const pattern of patterns) {
		if (isNegativePattern(pattern)) {
			hasNegations = true;
			break; // Early exit on first negation
		}

		result.push(normalizeDirectoryPatternForFastGlob(pattern));
	}

	return hasNegations ? [] : result;
};
