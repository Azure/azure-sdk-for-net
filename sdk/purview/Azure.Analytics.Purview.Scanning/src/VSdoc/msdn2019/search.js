/**
 * The array of document details for displayed search results. It is read from multiple small s_XY.js files.
 * Used when readCommonTitlesFile = false.
 * A single document info has format: search_result['DocumentId'] = ['Url','Title','Summary'].
 * 
 * @type {Array<Array<string>>}
 * */
var search_result = [];

/**
 * The array of document details for displayed search results. It is read from one large summaries s_all.sj file.
 * Used when readCommonTitlesFile = true.
 * A single document info has format: search_result['DocumentId'] = ['Url','Title','Summary'].
 *
 * @type {Array<Array<string>>}
 * */
var _s = [];

/** 
 * The count of results shown in one step. -1 means unlimited.
 * @type {number} 
 * */
var paginationSize = 25;

/** 
 * Indicates whether topic titles and summaries are read from one common large file 's_all.js'
 * or whether each title will be loaded from its own file named 's_TOPIC-ID.js'. 
 * 
 * With a huge index, e.g. 20000 topics, the single common file may be quite large. But still it is better
 * solution, because each loading of a small file with just sibgle topic takes about 100ms, which is 2.5 seconds for 25 results.
 *
 * @type {boolean} 
 * */
var readCommonTitlesFile = true;

/**
 * The search terms from the user.
 * @var {Array.<string>} qterms
 */


/**
 * Normalizes dots and spaces in a search query string.
 * @param {string} text The search query text.
 * @returns {string} Normalized search text.
 */
function stripSpaces(text) {
    //    return text.replace(/^\W+/,'').replace(/\W+$/,'');
    text = text.replace(/\./g, ' ');	// replace dots with spaces
    return text.split(" ").join(" ");  // remove multiple spaces
}

/**
 * Gets a search match bitmap where a bit at the specified position is set to 1.
 * A search match bitmap indicates, for which search term (qterm) a match was found
 * for a specific document.
 * 
 * @param {number} setbit A zero-based index of the bit to set to 1.
 * @param {number} size A size of bitmap, which is the count of the qterms.
 * @returns {Array.<number>} The bitmap with one bit set.
 */
function get_bitmap(setbit, size) {
    var map = {};
    for (let i = 0; i < size; ++i) {
        map[i] = 0;
    }
    map[setbit] = 1;
    return map;
}

/**
 * Fills the 'qterms' global variable with the terms from the 'search' query.
 * */
function getQtermsFromUrlQuery() {
    // extract all search terms
    var query = getQueryParameterByName("search");
    if (!query || query === "") {
        return;
    }
    var terms = stripSpaces(query.toLowerCase());

    qterms = [];
    var chunks = terms.split(" ");
    for (let i in chunks) {
        if (chunks[i]) {
            qterms[qterms.length] = chunks[i];
        }
    }
}

/**
 * Executes a search according to the 'search' query parameter.
 * 
 * */
function search() {
    // extract all search terms
    getQtermsFromUrlQuery();

    /** 
     *  For each document ID that has some match, contains a bitmap of matched terms and cumulative relevance.
     *  @type {Object.<number, {matchBitmap:Array.<number>, relevance:number} >} */
    var candidates = {};

    for (let qtermIndex in qterms) {
        /** @type {string} */
        let term = qterms[qtermIndex];
        let onlyWholeWord = false;
        // Read the user setting, whether he wants to always match whole words, even if no quotes around are used.
        // The user can define it in the CSS, e.g. in vsdocman_overrides.css:
        // :root {
        //        --searchAlwaysWholeWord: true;
        // }
        onlyWholeWord = getCssCustomProperty("--searchAlwaysWholeWord", "boolean");	
        if (term.length > 2 && term.startsWith("\"") && term.endsWith("\"")) {
            term = term.substr(1, term.length - 2);
            onlyWholeWord = true;
        }

        // index= "term1":"[[docId1, relevance1],.., [docIdN, relevanceN]]", ..., "term5":"[[docId1, relevance1],.., [docIdN, relevanceN]]""

        // whole words
        let termDocs=index[term];	// serialized string (instead of a direct array) for much faster parsing of search_index.js
        if (termDocs !== undefined) {
            termDocs = JSON.parse(termDocs); // deserialize
            for (let i in termDocs) {
                let docId = termDocs[i][0];
                let relevance = termDocs[i][1];
                if (candidates[docId] === undefined) {
                    candidates[docId] = {};
                    candidates[docId].matchBitmap = get_bitmap(qtermIndex, qterms.length);
                    candidates[docId].relevance = relevance;
                }
                else {
                    candidates[docId].matchBitmap[qtermIndex] = 1;
                    candidates[docId].relevance += relevance;
                }
            }
        }

        // parts of words
        if (!onlyWholeWord) {
            for (let indexedTerm in index) {
                if (indexedTerm.indexOf(term) >= 0) {
                    termDocs = index[indexedTerm];	// serialized string (instead of a direct array) for much faster parsing of search_index.js
                	termDocs = JSON.parse(termDocs); // deserialize
                    for (let i in termDocs) {
                        let docId = termDocs[i][0];
                        let relevance = termDocs[i][1];
                        if (candidates[docId] === undefined) {
                            candidates[docId] = {};
                            candidates[docId].matchBitmap = get_bitmap(qtermIndex, qterms.length);
                            candidates[docId].relevance = relevance;
                        }
                        else {
                            candidates[docId].matchBitmap[qtermIndex] = 1;
                            candidates[docId].relevance += relevance;
                        }
                    }
                }
            }
        }
    }

    let results = [];
    // sort by relevance in descending order
    let sortedDocIds = [];
    for (let key in candidates) sortedDocIds.push(key);
    sortedDocIds.sort(function (a, b) {
        return candidates[b].relevance - candidates[a].relevance;
    });
    for (let i = 0; i < sortedDocIds.length; i++) {
        let docIndex = sortedDocIds[i];
        let on = 1;
        for (let i in qterms) {
            on = on && candidates[docIndex].matchBitmap[i];
        }
        if (on) {
            results.push(docIndex);
        }
    }
    let resultsCount = results.length;

    document.getElementById("search-results-heading-count").appendChild(document.createTextNode(resultsCount));   // safe way of setting un-escaped text
    let sPhrase = getQueryParameterByName("search");
    sPhrase = "\"" + sPhrase + "\"";
    document.getElementById("search-results-heading-phrase").appendChild(document.createTextNode(sPhrase));   // safe way of setting un-escaped text

    var appendPromise = loadAndAppendSearchResultItems(results, 0, paginationSize);
}


/**
 * For specified file indexes range, loads and displays the search results.
 * @param {Array.<number>} docIds The doc IDs (assigned by the indexer) of all search results.
 * @param {number} from The index of the first item to append in the docIndexes.
 * @param {number} count The count of items to append from the docIndexes.
 * @returns {Promise<number>} A promise that is resolved when the result is displayed. The value is the last file index appended.
 */
function loadAndAppendSearchResultItems(docIds, from, count) {
    var appendPromise = Promise.resolve();  //immediately resolving promise
    for (let i = from; i < from + count && i < docIds.length; i++) {
        appendPromise = appendPromise.then(() => loadAndAppendSearchResultItem(docIds[i]));
    }

    appendPromise = appendPromise.then(() => {
        if (docIds.length > from + count) {
            showHidePaginationControls(true, docIds, from+count, count);
        } else {
            showHidePaginationControls(false, docIds, 0, 0);
        }
        return 0;   // return anything
    });

    return appendPromise;
}


/**
 * Shows or hide pagination links.
 * @param {boolean} show Show or hide.
 * @param {Array.<number>} docIds The doc IDs (assigned by the indexer) of all search results.
 * @param {number} nextFrom The index of the next item to append in the docIndexes when the NEXT link is pressed.
 * @param {number} count The count of items to append from the docIndexes when the NEXT link is pressed..
 */
function showHidePaginationControls(show, docIds, nextFrom, count) {
    let paginationDiv = document.getElementById("search-results-pagination");
    if (!paginationDiv) {
        if (show) {
            // create
            let parent = document.getElementById("search-results-section");
            paginationDiv = document.createElement('div');
            paginationDiv.id = "search-results-pagination";
            parent.appendChild(paginationDiv);

            let a = document.createElement('a');
            a.id = "search-pagination-next";
            a.href = "";
            a.appendChild(document.createTextNode("Next " + paginationSize + " >>"));   // safe way of setting un-escaped text
            paginationDiv.appendChild(a);

            a = document.createElement('a');
            a.id = "search-pagination-all";
            a.href = "";
            a.appendChild(document.createTextNode("All >>"));   // safe way of setting un-escaped text
            paginationDiv.appendChild(a);

        } else {
            return;
        }
    }

    if (show) {
        paginationDiv.classList.add("visible");
        // update click actions
        let a = document.getElementById("search-pagination-next");
        a.onclick = function () {
            loadAndAppendSearchResultItems(docIds, nextFrom, count);
            return false;
        };

        a = document.getElementById("search-pagination-all");
        a.onclick = function () {
            loadAndAppendSearchResultItems(docIds, nextFrom, docIds.length - nextFrom);
            return false;
        };
    } else {
        paginationDiv.classList.remove("visible");
    }
}


/**
 * For a specified file index, loads and displays the search result.
 * @param {number} fileIndex The search index (assigned by the indexer) of the result file.
 * @returns {Promise<number>} A promise that is resolved when the result is displayed. The value is fileIndex.
 */
function loadAndAppendSearchResultItem(fileIndex) {
    if (readCommonTitlesFile) {
        // Read the search result details from one common large file which contains all topics.
        // This method is much faster over network, but the 's_all.js' file may be quite large
        // for many, e.g. 20000, topics. So the first search will be slower, then the file will be cached.

        // ensure the file info is loaded
        return loadScriptOnce("search--/s_all.js")
            .then(
                function (scriptWasLoadedNow) {
                    // the loaded script defines all search results as _s[fileIndex]
                    let url = _s[fileIndex][0];
                    let title = _s[fileIndex][1];
                    let summary = _s[fileIndex][2];
                    appendSearchResultItem(url, title, summary);
                    return fileIndex;
                });

    } else {
        // Read the search result details from a separate small file, one for each topic.
        // This method is fast for local pages, but is slow on network, as each load of
        // a small file takes about 100ms.

        // ensure the file info is loaded
        return loadScriptOnce("search--/s_" + fileIndex + ".js")
            .then(
                function (scriptWasLoadedNow) {
                    // the loaded script defines search_result[fileIndex]
                    let url = search_result[fileIndex][0];
                    let title = search_result[fileIndex][1];
                    let summary = search_result[fileIndex][2];
                    appendSearchResultItem(url, title, summary);
                    return fileIndex;
                });

    }

}

/**
 * Appends specified search result to the list of results.
 * @param {string} url The URL of the search result.
 * @param {string} title The title of the search result.
 * @param {string} summary The summary of the search result, if any.
 */
function appendSearchResultItem(url, title, summary) {
    var containerElm = document.getElementById("search-results-container");
    if (!containerElm) {
        return;
    }

    var div = document.createElement('div');
    div.className = "search-result-item";

    var div2 = document.createElement('div');
    div2.className = "search-result-title";
    div.appendChild(div2);

    var a = document.createElement('a');
    a.href = url;
    //a.appendChild(document.createTextNode(title));   // safe way of setting un-escaped text
    a.innerHTML = title;  // 'title' is already HTML encoded
    div2.appendChild(a);

    div2 = document.createElement('div');
    div2.className = "search-result-summary";
    div2.appendChild(document.createTextNode(summary));   // safe way of setting un-escaped text
    div.appendChild(div2);

    containerElm.appendChild(div);
}


function highlightSearchTerms() {
    try {
        colors = ['yellow', 'lightgreen', 'gold', 'orange', 'magenta', 'lightblue'];
        getQtermsFromUrlQuery();
        if (qterms !== undefined) {
            for (let i in qterms) {
                document.body.innerHTML = doHighlight(document.body.innerHTML, qterms[i], colors[i % colors.length]);
            }
        }
    } catch (ex) { ; }
}

// from http://www.nsftools.com/misc/SearchAndHighlight.htm

/*
 * This is the function that actually highlights a text string by
 * adding HTML tags before and after all occurrences of the search
 * term. You can pass your own tags if you'd like, or if the
 * highlightStartTag or highlightEndTag parameters are omitted or
 * are empty strings then the default <font> tags will be used.
 */
function doHighlight(bodyText, searchTerm, color, highlightStartTag, highlightEndTag) {
    // the highlightStartTag and highlightEndTag parameters are optional
    if (!highlightStartTag || !highlightEndTag) {
        highlightStartTag = "<font style='background-color:" + color + ";'>";
        highlightEndTag = "</font>";
    }

    // find all occurrences of the search term in the given text,
    // and add some "highlight" tags to them (we're not using a
    // regular expression search, because we want to filter out
    // matches that occur within HTML tags and script blocks, so
    // we have to do a little extra validation)
    var newText = "";
    var i = -1;
    var lcSearchTerm = searchTerm.toLowerCase();
    var lcBodyText = bodyText.toLowerCase();

    while (bodyText.length > 0) {
        i = lcBodyText.indexOf(lcSearchTerm, i + 1);
        if (i < 0) {
            newText += bodyText;
            bodyText = "";
        } else {
            // skip anything inside an HTML tag
            if (bodyText.lastIndexOf(">", i) >= bodyText.lastIndexOf("<", i)) {
                // skip anything inside a <script> block
                if (lcBodyText.lastIndexOf("/script>", i) >= lcBodyText.lastIndexOf("<script", i)) {
                    newText += bodyText.substring(0, i) + highlightStartTag + bodyText.substr(i, searchTerm.length) + highlightEndTag;
                    bodyText = bodyText.substr(i + searchTerm.length);
                    lcBodyText = bodyText.toLowerCase();
                    i = -1;
                }
            }
        }
    }

    return newText;
}