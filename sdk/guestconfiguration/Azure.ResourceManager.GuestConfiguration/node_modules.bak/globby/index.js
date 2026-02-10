import process from 'node:process';
import fs from 'node:fs';
import nodePath from 'node:path';
import {Readable} from 'node:stream';
import mergeStreams from '@sindresorhus/merge-streams';
import fastGlob from 'fast-glob';
import {toPath} from 'unicorn-magic/node';
import {
	GITIGNORE_FILES_PATTERN,
	getIgnorePatternsAndPredicate,
	getIgnorePatternsAndPredicateSync,
} from './ignore.js';
import {
	bindFsMethod,
	promisifyFsMethod,
	isNegativePattern,
	normalizeDirectoryPatternForFastGlob,
	adjustIgnorePatternsForParentDirectories,
	convertPatternsForFastGlob,
} from './utilities.js';

const assertPatternsInput = patterns => {
	if (patterns.some(pattern => typeof pattern !== 'string')) {
		throw new TypeError('Patterns must be a string or an array of strings');
	}
};

const getStatMethod = fsImplementation =>
	bindFsMethod(fsImplementation?.promises, 'stat')
	?? bindFsMethod(fs.promises, 'stat')
	?? promisifyFsMethod(fsImplementation, 'stat');

const getStatSyncMethod = fsImplementation =>
	bindFsMethod(fsImplementation, 'statSync')
	?? bindFsMethod(fs, 'statSync');

const isDirectory = async (path, fsImplementation) => {
	try {
		const stats = await getStatMethod(fsImplementation)(path);
		return stats.isDirectory();
	} catch {
		return false;
	}
};

const isDirectorySync = (path, fsImplementation) => {
	try {
		const stats = getStatSyncMethod(fsImplementation)(path);
		return stats.isDirectory();
	} catch {
		return false;
	}
};

const normalizePathForDirectoryGlob = (filePath, cwd) => {
	const path = isNegativePattern(filePath) ? filePath.slice(1) : filePath;
	return nodePath.isAbsolute(path) ? path : nodePath.join(cwd, path);
};

const shouldExpandGlobstarDirectory = pattern => {
	const match = pattern?.match(/\*\*\/([^/]+)$/);
	if (!match) {
		return false;
	}

	const dirname = match[1];
	const hasWildcards = /[*?[\]{}]/.test(dirname);
	const hasExtension = nodePath.extname(dirname) && !dirname.startsWith('.');

	return !hasWildcards && !hasExtension;
};

const getDirectoryGlob = ({directoryPath, files, extensions}) => {
	const extensionGlob = extensions?.length > 0 ? `.${extensions.length > 1 ? `{${extensions.join(',')}}` : extensions[0]}` : '';
	return files
		? files.map(file => nodePath.posix.join(directoryPath, `**/${nodePath.extname(file) ? file : `${file}${extensionGlob}`}`))
		: [nodePath.posix.join(directoryPath, `**${extensionGlob ? `/*${extensionGlob}` : ''}`)];
};

const directoryToGlob = async (directoryPaths, {
	cwd = process.cwd(),
	files,
	extensions,
	fs: fsImplementation,
} = {}) => {
	const globs = await Promise.all(directoryPaths.map(async directoryPath => {
		// Check pattern without negative prefix
		const checkPattern = isNegativePattern(directoryPath) ? directoryPath.slice(1) : directoryPath;

		// Expand globstar directory patterns like **/dirname to **/dirname/**
		if (shouldExpandGlobstarDirectory(checkPattern)) {
			return getDirectoryGlob({directoryPath, files, extensions});
		}

		// Original logic for checking actual directories
		const pathToCheck = normalizePathForDirectoryGlob(directoryPath, cwd);
		return (await isDirectory(pathToCheck, fsImplementation)) ? getDirectoryGlob({directoryPath, files, extensions}) : directoryPath;
	}));

	return globs.flat();
};

const directoryToGlobSync = (directoryPaths, {
	cwd = process.cwd(),
	files,
	extensions,
	fs: fsImplementation,
} = {}) => directoryPaths.flatMap(directoryPath => {
	// Check pattern without negative prefix
	const checkPattern = isNegativePattern(directoryPath) ? directoryPath.slice(1) : directoryPath;

	// Expand globstar directory patterns like **/dirname to **/dirname/**
	if (shouldExpandGlobstarDirectory(checkPattern)) {
		return getDirectoryGlob({directoryPath, files, extensions});
	}

	// Original logic for checking actual directories
	const pathToCheck = normalizePathForDirectoryGlob(directoryPath, cwd);
	return isDirectorySync(pathToCheck, fsImplementation) ? getDirectoryGlob({directoryPath, files, extensions}) : directoryPath;
});

const toPatternsArray = patterns => {
	patterns = [...new Set([patterns].flat())];
	assertPatternsInput(patterns);
	return patterns;
};

const checkCwdOption = (cwd, fsImplementation = fs) => {
	if (!cwd || !fsImplementation.statSync) {
		return;
	}

	let stats;
	try {
		stats = fsImplementation.statSync(cwd);
	} catch {
		// If stat fails (e.g., path doesn't exist), let fast-glob handle it
		return;
	}

	if (!stats.isDirectory()) {
		throw new Error(`The \`cwd\` option must be a path to a directory, got: ${cwd}`);
	}
};

const normalizeOptions = (options = {}) => {
	// Normalize ignore to an array (fast-glob accepts string but we need array internally)
	const ignore = options.ignore
		? (Array.isArray(options.ignore) ? options.ignore : [options.ignore])
		: [];

	options = {
		...options,
		ignore,
		expandDirectories: options.expandDirectories ?? true,
		cwd: toPath(options.cwd),
	};

	checkCwdOption(options.cwd, options.fs);

	return options;
};

const normalizeArguments = function_ => async (patterns, options) => function_(toPatternsArray(patterns), normalizeOptions(options));
const normalizeArgumentsSync = function_ => (patterns, options) => function_(toPatternsArray(patterns), normalizeOptions(options));

const getIgnoreFilesPatterns = options => {
	const {ignoreFiles, gitignore} = options;

	const patterns = ignoreFiles ? toPatternsArray(ignoreFiles) : [];
	if (gitignore) {
		patterns.push(GITIGNORE_FILES_PATTERN);
	}

	return patterns;
};

/**
Apply gitignore patterns to options and return filter predicate.

When negation patterns are present (e.g., '!important.log'), we cannot pass positive patterns to fast-glob because it would filter out files before our predicate can re-include them. In this case, we rely entirely on the predicate for filtering, which handles negations correctly.

When there are no negations, we optimize by passing patterns to fast-glob's ignore option to skip directories during traversal (performance optimization).

All patterns (including negated) are always used in the filter predicate to ensure correct Git-compatible behavior.

@returns {Promise<{options: Object, filter: Function}>}
*/
const applyIgnoreFilesAndGetFilter = async options => {
	const ignoreFilesPatterns = getIgnoreFilesPatterns(options);

	if (ignoreFilesPatterns.length === 0) {
		return {
			options,
			filter: createFilterFunction(false, options.cwd),
		};
	}

	// Read ignore files once and get both patterns and predicate
	// Enable parent .gitignore search when using gitignore option
	const includeParentIgnoreFiles = options.gitignore === true;
	const {patterns, predicate, usingGitRoot} = await getIgnorePatternsAndPredicate(ignoreFilesPatterns, options, includeParentIgnoreFiles);

	// Convert patterns to fast-glob format (may return empty array if predicate should handle everything)
	const patternsForFastGlob = convertPatternsForFastGlob(patterns, usingGitRoot, normalizeDirectoryPatternForFastGlob);

	const modifiedOptions = {
		...options,
		ignore: [...options.ignore, ...patternsForFastGlob],
	};

	return {
		options: modifiedOptions,
		filter: createFilterFunction(predicate, options.cwd),
	};
};

/**
Apply gitignore patterns to options and return filter predicate (sync version).

@returns {{options: Object, filter: Function}}
*/
const applyIgnoreFilesAndGetFilterSync = options => {
	const ignoreFilesPatterns = getIgnoreFilesPatterns(options);

	if (ignoreFilesPatterns.length === 0) {
		return {
			options,
			filter: createFilterFunction(false, options.cwd),
		};
	}

	// Read ignore files once and get both patterns and predicate
	// Enable parent .gitignore search when using gitignore option
	const includeParentIgnoreFiles = options.gitignore === true;
	const {patterns, predicate, usingGitRoot} = getIgnorePatternsAndPredicateSync(ignoreFilesPatterns, options, includeParentIgnoreFiles);

	// Convert patterns to fast-glob format (may return empty array if predicate should handle everything)
	const patternsForFastGlob = convertPatternsForFastGlob(patterns, usingGitRoot, normalizeDirectoryPatternForFastGlob);

	const modifiedOptions = {
		...options,
		ignore: [...options.ignore, ...patternsForFastGlob],
	};

	return {
		options: modifiedOptions,
		filter: createFilterFunction(predicate, options.cwd),
	};
};

const createFilterFunction = (isIgnored, cwd) => {
	const seen = new Set();
	const basePath = cwd || process.cwd();
	const pathCache = new Map(); // Cache for resolved paths

	return fastGlobResult => {
		const pathKey = nodePath.normalize(fastGlobResult.path ?? fastGlobResult);

		// Check seen set first (fast path)
		if (seen.has(pathKey)) {
			return false;
		}

		// Only compute absolute path and check predicate if needed
		if (isIgnored) {
			let absolutePath = pathCache.get(pathKey);
			if (absolutePath === undefined) {
				absolutePath = nodePath.isAbsolute(pathKey) ? pathKey : nodePath.resolve(basePath, pathKey);
				pathCache.set(pathKey, absolutePath);

				// Only clear path cache if it gets too large
				// Never clear 'seen' as it's needed for deduplication
				if (pathCache.size > 10_000) {
					pathCache.clear();
				}
			}

			if (isIgnored(absolutePath)) {
				return false;
			}
		}

		seen.add(pathKey);
		return true;
	};
};

const unionFastGlobResults = (results, filter) => results.flat().filter(fastGlobResult => filter(fastGlobResult));

const convertNegativePatterns = (patterns, options) => {
	// If all patterns are negative, prepend a positive catch-all pattern
	// This makes negation-only patterns work intuitively (e.g., '!*.json' matches all files except JSON)
	if (patterns.length > 0 && patterns.every(pattern => isNegativePattern(pattern))) {
		patterns = ['**/*', ...patterns];
	}

	const tasks = [];

	while (patterns.length > 0) {
		const index = patterns.findIndex(pattern => isNegativePattern(pattern));

		if (index === -1) {
			tasks.push({patterns, options});
			break;
		}

		const ignorePattern = patterns[index].slice(1);

		for (const task of tasks) {
			task.options.ignore.push(ignorePattern);
		}

		if (index !== 0) {
			tasks.push({
				patterns: patterns.slice(0, index),
				options: {
					...options,
					ignore: [
						...options.ignore,
						ignorePattern,
					],
				},
			});
		}

		patterns = patterns.slice(index + 1);
	}

	return tasks;
};

const applyParentDirectoryIgnoreAdjustments = tasks => tasks.map(task => ({
	patterns: task.patterns,
	options: {
		...task.options,
		ignore: adjustIgnorePatternsForParentDirectories(task.patterns, task.options.ignore),
	},
}));

const normalizeExpandDirectoriesOption = (options, cwd) => ({
	...(cwd ? {cwd} : {}),
	...(Array.isArray(options) ? {files: options} : options),
});

const generateTasks = async (patterns, options) => {
	const globTasks = convertNegativePatterns(patterns, options);

	const {cwd, expandDirectories, fs: fsImplementation} = options;

	if (!expandDirectories) {
		return applyParentDirectoryIgnoreAdjustments(globTasks);
	}

	const directoryToGlobOptions = {
		...normalizeExpandDirectoriesOption(expandDirectories, cwd),
		fs: fsImplementation,
	};

	return Promise.all(globTasks.map(async task => {
		let {patterns, options} = task;

		[
			patterns,
			options.ignore,
		] = await Promise.all([
			directoryToGlob(patterns, directoryToGlobOptions),
			directoryToGlob(options.ignore, {cwd, fs: fsImplementation}),
		]);

		// Adjust ignore patterns for parent directory references
		options.ignore = adjustIgnorePatternsForParentDirectories(patterns, options.ignore);

		return {patterns, options};
	}));
};

const generateTasksSync = (patterns, options) => {
	const globTasks = convertNegativePatterns(patterns, options);
	const {cwd, expandDirectories, fs: fsImplementation} = options;

	if (!expandDirectories) {
		return applyParentDirectoryIgnoreAdjustments(globTasks);
	}

	const directoryToGlobSyncOptions = {
		...normalizeExpandDirectoriesOption(expandDirectories, cwd),
		fs: fsImplementation,
	};

	return globTasks.map(task => {
		let {patterns, options} = task;
		patterns = directoryToGlobSync(patterns, directoryToGlobSyncOptions);
		options.ignore = directoryToGlobSync(options.ignore, {cwd, fs: fsImplementation});

		// Adjust ignore patterns for parent directory references
		options.ignore = adjustIgnorePatternsForParentDirectories(patterns, options.ignore);

		return {patterns, options};
	});
};

export const globby = normalizeArguments(async (patterns, options) => {
	// Apply ignore files and get filter (reads .gitignore files once)
	const {options: modifiedOptions, filter} = await applyIgnoreFilesAndGetFilter(options);

	// Generate tasks with modified options (includes gitignore patterns in ignore option)
	const tasks = await generateTasks(patterns, modifiedOptions);

	const results = await Promise.all(tasks.map(task => fastGlob(task.patterns, task.options)));
	return unionFastGlobResults(results, filter);
});

export const globbySync = normalizeArgumentsSync((patterns, options) => {
	// Apply ignore files and get filter (reads .gitignore files once)
	const {options: modifiedOptions, filter} = applyIgnoreFilesAndGetFilterSync(options);

	// Generate tasks with modified options (includes gitignore patterns in ignore option)
	const tasks = generateTasksSync(patterns, modifiedOptions);

	const results = tasks.map(task => fastGlob.sync(task.patterns, task.options));
	return unionFastGlobResults(results, filter);
});

export const globbyStream = normalizeArgumentsSync((patterns, options) => {
	// Apply ignore files and get filter (reads .gitignore files once)
	const {options: modifiedOptions, filter} = applyIgnoreFilesAndGetFilterSync(options);

	// Generate tasks with modified options (includes gitignore patterns in ignore option)
	const tasks = generateTasksSync(patterns, modifiedOptions);

	const streams = tasks.map(task => fastGlob.stream(task.patterns, task.options));

	if (streams.length === 0) {
		return Readable.from([]);
	}

	const stream = mergeStreams(streams).filter(fastGlobResult => filter(fastGlobResult));

	// Returning a web stream will require revisiting once Readable.toWeb integration is viable.
	// return Readable.toWeb(stream);

	return stream;
});

export const isDynamicPattern = normalizeArgumentsSync((patterns, options) => patterns.some(pattern => fastGlob.isDynamicPattern(pattern, options)));

export const generateGlobTasks = normalizeArguments(generateTasks);
export const generateGlobTasksSync = normalizeArgumentsSync(generateTasksSync);

export {
	isGitIgnored,
	isGitIgnoredSync,
	isIgnoredByIgnoreFiles,
	isIgnoredByIgnoreFilesSync,
} from './ignore.js';

export const {convertPathToPattern} = fastGlob;
