// #region PAGE INIT ***********************


// Event handler attachment
function registerEventHandler(element, event, handler) {
    if (element.addEventListener) {
        element.addEventListener(event, handler, false);
    } else if (element.attachEvent) {
        element.attachEvent('on' + event, handler);
    } else {
        element[event] = handler;
    }
}


// Event handler detachment
function unregisterEventHandler(element, event, handler) {
    if (typeof element.removeEventListener === "function")
        element.removeEventListener(event, handler, false);
    else
        element.detachEvent("on" + event, handler);
}


/**
 * Scroll handler.
 * @type {function()}
 */
function scrollHandler() {
        fitTocHeightToViewport();
}


function resizeHandler() {
    fitTocHeightToViewport();
}

registerEventHandler(window, 'load', init);
registerEventHandler(window, 'scroll', scrollHandler);
registerEventHandler(window, 'resize', resizeHandler);


/**
 * Internal in-page sections TOC.
 * */
var inPageToc;


function init() {
    try {
        fixMoniker();
        mergeCodeSnippets();
        loadLangFilter();
        showSelectedLanguages();
        initSearchControls();
        inPageToc = new InternalToc();  // generate in-page TOC
        var breadcrumbsPromise = loadAndDisplayBreadcrumbs();
        breadcrumbsPromise.then(() => expandBreadcrumbsInToc(breadcrumbs));
    }
    catch (e) {
        var msg = e.message;
        if (e.stack) {
            msg = msg + "/n" + e.stack;
        }
        (console.error || console.log).call(console, msg);
    }
}


var scriptArray = []; //array of loaded url:script
/**
 * Loads a JS script if it is not loaded yet.
 * 
 * @param {string} url The URL of the JS script to be loaded.
 * @returns {Promise<boolean>} A promise that returns a value indicating whether this function
 * loaded the script. False if the script was already loaded before.
 */
function loadScriptOnce(url) {
    return new Promise(function (resolve, reject) {

        if (scriptArray[url] === undefined) {
            //the array doesn't have such url

            var script = document.createElement('script');
            script.src = url;
            var head = document.getElementsByTagName('head')[0];
            var done = false;

            script.onload = script.onreadystatechange = function () {
                if (!done && (!this.readyState || this.readyState === 'loaded' || this.readyState === 'complete')) {
                    done = true;
                    script.onload = script.onreadystatechange = null;
                    //head.removeChild(script);

                    scriptArray[url] = script;
                    resolve(true);
                }
            };
            script.onerror = () => reject(new Error("Script load error: " + url));

            head.appendChild(script);
        } else {
            // resolve immediately
            resolve(false);
        }

    });
}


/**
 * Ensures that the TOC is always fully visible, i.e. its height is adjusted.
 * */
function fitTocHeightToViewport() {
    var tocContainer = document.getElementById("toc-container");
    if (!tocContainer) {
        return;
    }

    var vpHeight = document.documentElement.clientHeight;
    var vpWidth = document.documentElement.clientWidth;
    var viewPortRect = {
        left: 0,
        top: 0,
        right: vpWidth-1,
        bottom: vpHeight-1,
        width: vpWidth,
        height: vpHeight,
        x: 0,
        y: 0
    };
    var headerVisibleHeight = 0;
    var footerVisibleHeight = 0;
    var elm;

    elm = document.getElementById("header");
    if (elm) {
        let interSect = getRectIntersection(viewPortRect, elm.getBoundingClientRect());
        if (interSect) {
            headerVisibleHeight = interSect.height;
        }
    }

    elm = document.getElementById("footer");
    if (elm) {
        let interSect = getRectIntersection(viewPortRect, elm.getBoundingClientRect());
        if (interSect) {
            footerVisibleHeight = interSect.height;
        }
    }

    // If header nor footer are visible, CSS works fine and the TOC height is OK.
    // remove any previously explicitly set max-height
    if (headerVisibleHeight === 0 && footerVisibleHeight === 0) {
        tocContainer.style.removeProperty("max-height");
        return;
    }

    var tocRect = tocContainer.getBoundingClientRect();
    // header or footer is visible
    // Check if top and bottom of the TOC are visible.
    if (tocRect.top < 0 || tocRect.bottom > viewPortRect.bottom) {
        //console.info("not visible");
        //console.info("header " + headerVisibleHeight);
        //console.info("footer " + footerVisibleHeight);
        tocContainer.style.maxHeight = (viewPortRect.height - headerVisibleHeight - footerVisibleHeight - 15) + "px";
    }

}


/**
 * Gets the intersection of two rectangles.
 * 
 * @param {ClientRect} rect1 Rectangle 1.
 * @param {ClientRect} rect2 Rectangle 2.
 * @returns {ClientRect} null if no intersection
 */
function getRectIntersection(rect1, rect2) {
    var isNoOverlapX = rect1.right < rect2.left || rect1.left > rect2.right;
    var isNoOverlapY = rect1.bottom < rect2.top || rect1.top > rect2.bottom;

    if (isNoOverlapX || isNoOverlapY) {
        return null;
    }

    var resLeft = Math.max(rect1.left, rect2.left);
    var resRight = Math.min(rect1.right, rect2.right);
    var resTop = Math.max(rect1.top, rect2.top);
    var resBottom = Math.min(rect1.bottom, rect2.bottom);

    return {
        left: resLeft,
        top: resTop,
        right: resRight,
        bottom: resBottom,
        width: resRight - resLeft + 1,
        height: resBottom - resTop + 1,
        x: resLeft,
        y: resTop
    };
}


function initSearchControls() {
    var searchContainer = document.getElementById("search-bar-container");
    if (!searchContainer) {
        return;
    }
    var searchForm = document.getElementById("search-bar");
    if (!searchForm) {
        return;
    }
    var searchBox = document.getElementById("HeaderSearchInput");
    if (!searchBox) {
        return;
    }
    var searchBtn = document.getElementById("btn-search");
    if (!searchBtn) {
        return;
    }
    var cancelSearchBtn = document.getElementById("cancel-search");    //
    if (!cancelSearchBtn) {
        return;
    }

    // 'executeSearch' function
    let executeSearch = function () {
        //alert("Searching");
        console.info("Searching");
        searchForm.submit();
    };

    // 'executeSearch' function
    let hideSearchBox = function () {
        removeClassFromElement(searchContainer, "search-focused");
    };

    // 'showAndFocusSearchBox' function
    let showAndFocusSearchBox = function () {
        addClassToElement(searchContainer, "search-focused");
        searchBox.focus();
    };

    // 'showAndFocusSearchBox' function
    let isSearchBoxHidden = function () {
        return !hasElementClass(searchContainer, "search-focused");
    };

    // "Search" button
    registerEventHandler(searchBtn, "click",
        function (e) {
            if (!isSearchBoxHidden()) {
                executeSearch();
                return;
            }
            e.preventDefault();
            e.stopPropagation();
            showAndFocusSearchBox();
        });


    // "Cancel" search button
    registerEventHandler(cancelSearchBtn, "click",
        function () {
            hideSearchBox();
        });

    registerEventHandler(cancelSearchBtn, "keydown",
        function (e) {
            e.preventDefault();
            // 27 ESC
            // 13 ENTER
            // 9 TAB
            e.keyCode === 27 || e.keyCode === 13 ? hideSearchBox() : e.keyCode === 9 && searchBox.focus();
        });

    // search box
    registerEventHandler(searchBox, "keydown",
        function (e) {
            switch (e.keyCode) {
                case 9:
                case 27:
                    hideSearchBox();
                    break;
                case 13:
                    executeSearch();
                    break;
            }
        });

    registerEventHandler(searchBox, "blur",
        function (e) {
            if (e.relatedTarget === searchBtn) {
                // search btn received the focus
                return;
            }
            hideSearchBox();
        });

}

// #endregion PAGE INIT ***********************


// #region BREADCRUMBS **********************

var breadcrumbs;

/**
 * @returns {Promise} A promise that is resolved after the 'breadcrumbs' variable is retrieved and displayed.
 */
function loadAndDisplayBreadcrumbs() {
    var filename = location.pathname.replace(/\\/g, "/");
    filename = filename.substring(filename.lastIndexOf('/') + 1);
    //var filenameWithoutExtension = filename;
    //var extension = "";
    //var i = filename.lastIndexOf('.');
    //if (i !== -1) {
    //    filenameWithoutExtension = filename.substring(0, i);
    //    extension = filename.substring(i);
    //}

    // get breadcrumbs js file
    var scriptFile = "toc--/" + filename + ".js";
    return loadScriptOnce(scriptFile)
        .then(script => DisplayBreadcrumbs());
}


function DisplayBreadcrumbs() {
    if (breadcrumbs) {
        let breadcrumbsDiv = document.getElementById("header-breadcrumbs");
        let ulElm = document.createElement("ul");
        breadcrumbsDiv.appendChild(ulElm);

        // breadcrumbs is an array of topic definitions. A single TOC item has format: ['Id', 'Text', 'Url']
        for (i = 0; i < breadcrumbs.length; i++) {
            let tocNode = breadcrumbs[i];
            let id = tocNode[0];
            let text = tocNode[1];
            let url = tocNode[2];

            if (!(i === 0 && url === "" && text === "")) {
                // not a virtual root
                let liElm = document.createElement("li");
                if (url !== "") {
                    let a1 = document.createElement('a');
                    a1.href = url;
                    //a1.innerHTML = text;
                    a1.appendChild(document.createTextNode(text));   // safe way of setting un-escaped text

                    liElm.appendChild(a1);
                } else {
                    //liElm.innerHTML = text;
                   liElm.appendChild(document.createTextNode(text));   // safe way of setting un-escaped text
                }

                ulElm.appendChild(liElm);
            }

        }
    }
}


// #endregion BREADCRUMBS **********************



// #region EXPAND / COLLAPSE SECTION *********************

function toggleSection(sectionLinkElm) {
    var sectionDiv = sectionLinkElm.parentNode.parentNode.parentNode;
    if (hasElementClass(sectionDiv, "collapsed")) {
        expandSection(sectionLinkElm);
    } else {
        collapseSection(sectionLinkElm);
    }
}

function expandSection(sectionLinkElm) {
    var sectionDiv = sectionLinkElm.parentNode.parentNode.parentNode;
    removeClassFromElement(sectionDiv, "collapsed");
    sectionLinkElm.setAttribute("title", "Collapse");
}

function collapseSection(sectionLinkElm) {
    var sectionDiv = sectionLinkElm.parentNode.parentNode.parentNode;
    addClassToElement(sectionDiv, "collapsed");
    sectionLinkElm.setAttribute("title", "Expand");
}

// #endregion EXPAND / COLLAPSE SECTION ***********************



// #region CODE SNIPPETS **********************

/**
 * Merges adjacent code snippets in different languages into
 * single code collection with tabs.  
 */
function mergeCodeSnippets() {
    var allNodes = getElementAndTextNodes(document.body);
    var parentCodeSnippet = null;
    var i;

    for (i = 0; i < allNodes.length; i++) {
        var currentNode = allNodes[i];

        var nextNode;
        if (!parentCodeSnippet) {
            // look for the first code snippet which will be a parent
            if (hasElementClass(currentNode, "codeSnippetContainer")) {
                parentCodeSnippet = currentNode;
                // snippet found, move after it
                nextNode = getNextNonChildElementOrTextNode(parentCodeSnippet);
                while (allNodes[++i] !== nextNode && i < allNodes.length) { /*empty*/ }
                i--;
            }

        } else {
            // look for the next ADJACENT code snippet
            if (hasElementClass(currentNode, "codeSnippetContainer")) {
                // merge it with the parent
                mergeTwoCodeSnippets(parentCodeSnippet, currentNode);
                // move after adjacent snippet
                nextNode = getNextNonChildElementOrTextNode(currentNode);
                while (allNodes[++i] !== nextNode && i < allNodes.length) { /*empty*/ }
                i--;
            } else {
                // or look for the non-whitespace text
                if (currentNode.nodeType === TEXT_NODE || currentNode.nodeType === CDATA_SECTION_NODE) {
                    if (currentNode.nodeValue.trim() !== "") {
                        // found non empty text after parent snippet, don't merge and find next parent
                        parentCodeSnippet = null;
                    }
                }
            }
        }

    }
}


var ELEMENT_NODE = 1;
var TEXT_NODE = 3;
var CDATA_SECTION_NODE = 4;

/**
 * Returns all elements and text nodes under the root.
 * Recursion is not used due to performance reasons. 
 * 
 * @param {HTMLElement} root - The root node.
 * @returns {Array<Node>} All elements and text nodes under the root.
 */
function getElementAndTextNodes(root) {
    var result = [];

    var node = root.childNodes[0];
    while (node !== null) {
        switch (node.nodeType) {
            case ELEMENT_NODE:
            case TEXT_NODE:
            case CDATA_SECTION_NODE:
                result.push(node);
                break;
        }

        if (node.hasChildNodes()) {
            node = node.firstChild;
        }
        else {
            while (node.nextSibling === null && node !== root) {
                node = node.parentNode;
            }
            if (node !== root) {
                node = node.nextSibling;
            } else {
                node = null;
            }
        }
    }

    return result;
}


/**
 * Merges two separate snippets together. The child snippet
 * becomes a part of the parent snippet. Tabs and visibility 
 * are adjusted accordingly.
 * @param {Node} parentSnippet The parent snippet to merge.
 * @param {Node} childSnippet The child snippet to merge.
 */
function mergeTwoCodeSnippets(parentSnippet, childSnippet) {
    var childCode = getDivWithClass(childSnippet, "codeSnippetCode");
    var parentCodeCollection = getDivWithClass(parentSnippet, "codeSnippetCodeCollection");
    if (childCode && parentCodeCollection) {
        // remove existing lang code in parent, if any
        var lang = getLangOfCodeSnippetCode(childCode);
        if (lang) {
            var existingCode = getCodeSnippetCodeByLang(parentSnippet, lang);
            if (existingCode) {
                existingCode.parentNode.removeChild(existingCode);
            }
        }
        // move child code to the parent
        childCode.parentNode.removeChild(childCode);
        parentCodeCollection.appendChild(childCode);
        showHideTag(childSnippet, false);

        // correct the tabs (bold or normal for N/A lang)
        var csCode, tab, i;
        var tabsDiv = getDivWithClass(parentSnippet, "codeSnippetTabs");
        var langs = ["codeVB", "codeCsharp", "codeCpp", "codeFsharp", "codeJScript"];

        for (i = 0; i < langs.length; i++) {
            lang = langs[i];
            csCode = getCodeSnippetCodeByLang(parentCodeCollection, lang);
            tab = getDivWithClass(tabsDiv, lang);
            if (csCode) {
                // lang exists
                removeClassFromElement(tab, "csNaTab");
            } else {
                // lang doesn't exist
                addClassToElement(tab, "csNaTab");
            }
        }
    }
}


/**
 * Gets a language of DIV with codeSnippetCode class.
 * @param {HTMLElement} elm The element with code to inspect.
 * @return {string}  The language code: "codeVB", "codeCsharp", "codeCpp", "codeFsharp", "codeJScript" or null.
 */
function getLangOfCodeSnippetCode(elm) {
    if (hasElementClass(elm, "codeVB")) {
        return "codeVB";
    } else if (hasElementClass(elm, "codeCsharp")) {
        return "codeCsharp";
    } else if (hasElementClass(elm, "codeCpp")) {
        return "codeCpp";
    } else if (hasElementClass(elm, "codeFsharp")) {
        return "codeFsharp";
    } else if (hasElementClass(elm, "codeJScript")) {
        return "codeJScript";
    } else {
        return null;
    }
}


/**
 * Gets a DIV with codeSnippetCode class with specified language class.
 * @param {HTMLElement} containerSnippet The code container element.
 * @param {string} lang The required language code.
 * @returns {HTMLElement} The found code element. Null if not found.
 */
function getCodeSnippetCodeByLang(containerSnippet, lang) {
    var divTags = containerSnippet.getElementsByTagName("div");
    var i;
    for (i = 0; i < divTags.length; i++) {
        if (hasElementClasses(divTags[i], new Array("codeSnippetCode", lang))) {
            return divTags[i];
        }
    }
    return null;
}


/**
 * Gets the next node which is not a child of specified element and
 * is whether an element or text node.
 * @param {Node} nod The base HTML node for which the search will be done.
 * @returns {Node} The node found or null.
 * @remark Unlike nextSibling property, this method returns also text nodes.
 * Moreover, if there is no next sibling, this method goes higher in the hierarchy
 * and finds the next node.
 */
function getNextNonChildElementOrTextNode(nod) {
    // try next sibling first
    var res = nod;
    while ((res = res.nextSibling) !== null) {
        switch (res.nodeType) {
            case ELEMENT_NODE:
            case TEXT_NODE:
            case CDATA_SECTION_NODE:
                return res;
        }
    }

    // no sibling element or text found, try higher
    if (nod.parentNode) {
        return getNextNonChildElementOrTextNode(nod.parentNode);
    } else {
        // no node found
        return null;
    }
}

// #endregion CODE SNIPPETS **********************


// #region COMMON UTILS **********************


/**
 * Gets the first DIV element which has the specified class.
 * @param {HTMLElement} parentElm The element where to start searching.
 * @param {string} className The class name to be found.
 * @returns {HTMLElement} The found DIV element or null if not found. 
 */
function getDivWithClass(parentElm, className) {
    var divTags = parentElm.getElementsByTagName("div");
    var i;
    for (i = 0; i < divTags.length; i++) {
        if (hasElementClass(divTags[i], className)) {
            return divTags[i];
        }
    }
    return null;
}


/**
 * Determines whether an element contains specified CSS class.
 * @param {HTMLElement} elm The element to test.
 * @param {string} className The class name to be tested.
 * @returns {boolean} A value indicating whether the element contains the class.
*/
function hasElementClass(elm, className) {
    if (elm.className) {
        var classes = elm.className.split(" ");
        className = className.toLowerCase();
        var i;
        for (i = 0; i < classes.length; i++) {
            if (classes[i].toLowerCase() === className) {
                return true;
            }
        }
    }

    return false;
}


/**
 * Determines whether an element contains all specified CSS classes.
 * @param {HTMLElement} elm The element to test.
 * @param {Array<string>} classNames An array of class names.
 * @returns {boolean} A value indicating whether the element contains the classes.
 */
function hasElementClasses(elm, classNames) {
    if (elm.className) {
        var classes = elm.className.split(" ");
        var i, j, found;
        found = 0;
        for (j = 0; j < classNames.length; j++) {
            var className = classNames[j].toLowerCase();
            for (i = 0; i < classes.length; i++) {
                var elmClass = classes[i].toLowerCase();
                if (elmClass === className) {
                    found++;
                    break;
                }
            }
        }
        if (found === classNames.length) {
            return true;
        }
    }

    return false;
}


/**
 * Removes specified CSS class from an element, if any.
 * @param {HTMLElement} elm The element to process.
 * @param {string} className The class name to be removed.
 */
function removeClassFromElement(elm, className) {
    if (elm === null) return;
    if (elm.className) {
        var classes = elm.className.split(" ");
        className = className.toLowerCase();
        var i;
        for (i = classes.length - 1; i >= 0; i--) {
            if (classes[i].toLowerCase() === className) {
                classes.splice(i, 1);
            }
        }
        elm.className = classes.join(" ");
    }
}


/**
 * Adds specified CSS class to an element.
 * @param {HTMLElement} elm The element to process.
 * @param {string} className The class name to be added.
 */
function addClassToElement(elm, className) {
    if (elm === null) return;
    if (elm.className) {
        var classes = elm.className.split(" ");
        var classNameLow = className.toLowerCase();
        var i;
        for (i = classes.length - 1; i >= 0; i--) {
            if (classes[i].toLowerCase() === classNameLow) {
                // class already exists
                return;
            }
        }
        classes[classes.length] = className;
        elm.className = classes.join(" ");
    } else {
        elm.className = className;
    }
}

/**
 * Super fast trim. Faster than pure regex solution.
 * @returns {string} The trimmed version of the original string.
 */
String.prototype.trim = function () {
    var str = this.replace(/^\s\s*/, ''),
        ws = /\s/,
        i = str.length;
    while (ws.test(str.charAt(--i)));
    return str.slice(0, i + 1);
};


/**
 * Gets the specified query parameter value.
 * @param {string} name Parameter name.
 * @param {string} url Optional.
 * @returns {string} The parameter value, an empty string if parameter is present without a value, null id parameter not present.
 */
function getQueryParameterByName(name, url) {
    //const urlParams = new URLSearchParams(window.location.search);    // not supported by IE, not a problem?
    //const myParam = urlParams.get('myParam');

    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}


/**
 * Gets the value of a CSS Custom Property (starting with --).
 * Pass in an element and its CSS Custom Property that you want the value of.
 * Optionally, you can determine what datatype you get back.
 *
 * @param {String} propertyName The name of the custom CSS property, including the leading --.
 * @param {String} [castAs='string'] The datatype name of the value to be retrieved. Available values are:
 * 'number', 'int', 'float', 'boolean', 'bool'. Any other or omitted value returns string.
 * @param {HTMLELement} [element=document.documentElement] The element with the CSS property.
 * Can be omitted if the property is global, defined inside the ':root { --MyProperty }' rule.
 * @returns {*} The value of the specified CSS Custom Property.
 */
const getCssCustomProperty = (propertyName, castAs = 'string', element = document.documentElement) => {
    let response = getComputedStyle(element).getPropertyValue(propertyName);

    // Tidy up the string if there's something to work with
    if (response.length) {
        response = response.replace(/\'|"/g, '').trim();
    }

    // Convert the response into a whatever type we wanted
    switch (castAs) {
        case 'number':
        case 'int':
            return parseInt(response, 10);
        case 'float':
            return parseFloat(response, 10);
        case 'boolean':
        case 'bool':
            return response === 'true' || response === '1';
    }

    // Return the string response by default
    return response;
};



// #endregion COMMON UTILS **********************



// #region LANGUAGE FILTER **********************

// Specifies which language tab is shown as default for the first time.
// Possible values: "codeVB", "codeCsharp", "codeCpp", "codeFsharp", "codeJScript"
var DEFAULT_LANGUAGE_TO_SHOW = "codeCsharp";
var languageToShow = DEFAULT_LANGUAGE_TO_SHOW;

function loadLangFilter() {
    languageToShow = loadSetting("languageToShow", DEFAULT_LANGUAGE_TO_SHOW);
}


function saveLangFilter() {
    saveSetting("languageToShow", languageToShow);
}


/**
 * Hides/shows the language sections according to language filter
 * @param {string} langCode  "VB", "Csharp", "Cpp", "Fsharp", "JScript"
 */
function CodeSnippet_SetLanguage(langCode) {
    languageToShow = "code" + langCode;
    showSelectedLanguages();
    saveLangFilter();
}


/**
 * Gets all code snippets. A snippet is a DIV with class="codeSnippetContainer".
 * @returns {Array<HTMLElement>} The found code snippets.
 */
function getAllCodeSnippets() {
    var divTags = document.getElementsByTagName("div");
    var snippets = new Array();
    var i, j;
    j = 0;
    for (i = 0; i < divTags.length; i++) {
        if (hasElementClass(divTags[i], "codeSnippetContainer")) {
            snippets[j++] = divTags[i];
        }
    }
    return snippets;
}


/**
 * Hides/shows the language sections according to the language filter.
 */
function showSelectedLanguages() {
    try {
        var snippets = getAllCodeSnippets();
        var i, j, divs, codeCollection, snippet;

        for (i = 0; i < snippets.length; i++) {
            snippet = snippets[i];
            if (snippet.style.display !== "none") {
                var langIsNA = false;

                // set the tabs (active/inactive)
                var tabsDiv = getDivWithClass(snippet, "codeSnippetTabs");
                // reset corners
                var leftCorner, rightCorner;
                leftCorner = getDivWithClass(tabsDiv, "codeSnippetTabLeftCorner");
                if (!leftCorner) {
                    leftCorner = getDivWithClass(tabsDiv, "codeSnippetTabLeftCornerActive");
                }
                rightCorner = getDivWithClass(tabsDiv, "codeSnippetTabRightCorner");
                if (!rightCorner) {
                    rightCorner = getDivWithClass(tabsDiv, "codeSnippetTabRightCornerActive");
                }
                removeClassFromElement(leftCorner, "codeSnippetTabLeftCornerActive");
                addClassToElement(leftCorner, "codeSnippetTabLeftCorner");
                removeClassFromElement(rightCorner, "codeSnippetTabRightCornerActive");
                addClassToElement(rightCorner, "codeSnippetTabRightCorner");

                //  get the tabs
                divs = tabsDiv.getElementsByTagName("div");
                var tab;
                var tabDivs = new Array();
                for (j = 0; j < divs.length; j++) {
                    if (hasElementClass(divs[j], "codeSnippetTab")) {
                        // it's a tab
                        tab = divs[j];
                        tabDivs[tabDivs.length] = tab;
                    }
                }

                //  activate/deactivate the tabs
                var tabLink;
                var visibleTabs = new Array();
                for (j = 0; j < tabDivs.length; j++) {
                    tab = tabDivs[j];

                    if (hasElementClass(tab, languageToShow)) {
                        addClassToElement(tab, "csActiveTab");
                        tabLink = tab.getElementsByTagName("a")[0];
                        tabLink.removeAttribute("href");
                        langIsNA = hasElementClass(tab, "csNaTab");
                    } else {
                        removeClassFromElement(tab, "csActiveTab");
                        var shortLang = getLangOfCodeSnippetCode(tab).substring(4);
                        tabLink = tab.getElementsByTagName("a")[0];
                        tabLink.setAttribute("href", "javascript: CodeSnippet_SetLanguage('" + shortLang + "');");
                    }

                    //  get visible tabs; invisible tabs are: with not supported lang AND not active
                    if (!(hasElementClass(tab, "csNaTab") && !hasElementClass(tab, "csActiveTab"))) {
                        // tab is visible
                        visibleTabs[visibleTabs.length] = tab;
                    }
                }

                // fix some styles (first, last) of visible tabs and corners
                for (j = 0; j < visibleTabs.length; j++) {
                    tab = visibleTabs[j];

                    removeClassFromElement(tab, "csFirstTab");
                    removeClassFromElement(tab, "csLastTab");
                    if (j === 0) {
                        addClassToElement(tab, "csFirstTab");
                        if (hasElementClass(tab, "csActiveTab")) {
                            removeClassFromElement(leftCorner, "codeSnippetTabLeftCorner");
                            addClassToElement(leftCorner, "codeSnippetTabLeftCornerActive");
                        }
                    }
                    if (j === visibleTabs.length - 1) {
                        addClassToElement(tab, "csLastTab");
                        if (hasElementClass(tab, "csActiveTab")) {
                            removeClassFromElement(rightCorner, "codeSnippetTabRightCorner");
                            addClassToElement(rightCorner, "codeSnippetTabRightCornerActive");
                        }
                    }
                }

                // show/hide code block
                codeCollection = getDivWithClass(snippet, "codeSnippetCodeCollection");
                divs = codeCollection.getElementsByTagName("div");
                for (j = 0; j < divs.length; j++) {
                    if (hasElementClass(divs[j], "codeSnippetCode")) {
                        // it's a code block
                        if (langIsNA) {
                            showHideTag(divs[j], hasElementClass(divs[j], "codeNA"));
                        } else {
                            showHideTag(divs[j], hasElementClass(divs[j], languageToShow));
                        }
                    }
                }

            }
        }

    } catch (ex) {
        // empty
    }
}


function showHideTag(tag, visible) {
    try {
        if (visible) {
            tag.style.display = "";
        } else {
            tag.style.display = "none";
        }
    } catch (e) {
        /*empty*/
    }
}

// #endregion LANGUAGE FILTER **********************



// #region COPY CODE ***************************

function CopyCode(item) {
    try {
        // get the visible code block div
        var codeCollection = item.parentNode.parentNode;
        var divs = codeCollection.getElementsByTagName("div");
        var i, shownCode;
        for (i = 0; i < divs.length; i++) {
            if (hasElementClass(divs[i], "codeSnippetCode")) {
                // it's a code block
                if (divs[i].style.display !== "none") {
                    shownCode = divs[i];
                    break;
                }
            }
        }

        if (shownCode) {
            // get code and remove <br>
            var code;
            code = shownCode.innerHTML;
            code = code.replace(/<br>/gi, "\n");
            code = code.replace(/<\/td>/gi, "</td>\n");	// syntax highlighter removes \n chars and puts each line in separate <td>
            code = code.trim();	// remove leading spaces which are unwanted in FF 
            // get plain text
            var tmpDiv = document.createElement('div');
            tmpDiv.innerHTML = code;

            if (typeof tmpDiv.textContent !== "undefined") {
                // standards compliant
                code = tmpDiv.textContent;
            }
            else if (typeof tmpDiv.innerText !== "undefined") {
                // IE only
                code = tmpDiv.innerText;
            }

            try {
                // works in IE only
                window.clipboardData.setData("Text", code);
            } catch (ex) {
                popCodeWindow(code);
            }
        }
    } catch (e) {
        /*empty*/
    }
}


function popCodeWindow(code) {
    try {
        var codeWindow = window.open("",
            "Copy the selected code",
            "location=0,status=0,toolbar=0,menubar =0,directories=0,resizable=1,scrollbars=1,height=400, width=400");
        codeWindow.document.writeln("<html>");
        codeWindow.document.writeln("<head>");
        codeWindow.document.writeln("<title>Copy the selected code</title>");
        codeWindow.document.writeln("</head>");
        codeWindow.document.writeln("<body bgcolor=\"#FFFFFF\">");
        codeWindow.document.writeln('<pre id="code_text">');
        codeWindow.document.writeln(escapeHTML(code));
        codeWindow.document.writeln("</pre>");
        codeWindow.document.writeln("<scr" + "ipt>");
        // the selectNode function below, converted by http://www.howtocreate.co.uk/tutorials/jsexamples/syntax/prepareInline.html 
        var ftn = "function selectNode (node) {\n\tvar selection, range, doc, win;\n\tif ((doc = node.ownerDocument) && \n\t\t(win = doc.defaultView) && \n\t\ttypeof win.getSelection != \'undefined\' && \n\t\ttypeof doc.createRange != \'undefined\' && \n\t\t(selection = window.getSelection()) && \n\t\ttypeof selection.removeAllRanges != \'undefined\') {\n\t\t\t\n\t\trange = doc.createRange();\n\t\trange.selectNode(node);\n    selection.removeAllRanges();\n    selection.addRange(range);\n\t} else if (document.body && \n\t\t\ttypeof document.body.createTextRange != \'undefined\' && \n\t\t\t(range = document.body.createTextRange())) {\n     \n\t\t \trange.moveToElementText(node);\n     \trange.select();\n  }\n} ";
        codeWindow.document.writeln(ftn);
        codeWindow.document.writeln("selectNode(document.getElementById('code_text'));</scr" + "ipt>");
        codeWindow.document.writeln("</body>");
        codeWindow.document.writeln("</html>");
        codeWindow.document.close();
    } catch (ex) { /*empty*/ }
}


function escapeHTML(str) {
    return str.replace(/&/g, "&amp;").
        replace(/>/g, "&gt;").
        replace(/</g, "&lt;").
        replace(/"/g, "&quot;");
}

function selectNode(node) {
    var selection, range, doc, win;
    if ((doc = node.ownerDocument) &&
        (win = doc.defaultView) &&
        typeof win.getSelection !== 'undefined' &&
        typeof doc.createRange !== 'undefined' &&
        (selection = window.getSelection()) &&
        typeof selection.removeAllRanges !== 'undefined') {

        range = doc.createRange();
        range.selectNode(node);
        selection.removeAllRanges();
        selection.addRange(range);
    } else if (document.body &&
        typeof document.body.createTextRange !== 'undefined' &&
        (range = document.body.createTextRange())) {

        range.moveToElementText(node);
        range.select();
    }
}

// #endregion COPY CODE ***************************



// #region PERSISTENCE *************************

/**
 * Sets the cookie value. When an optional argument is omitted, a null is used.
 * @param {string} name - The name of the cookie.
 * @param {*} value - The value of the cookie.
 * @param {Date} [expires] - The expiration date of the cookie (defaults to end of current session).
 * @param {string} [path] - The path for which the cookie is valid (defaults to path of calling document).
 * @param {string} [domain] - The domain for which the cookie is valid (defaults to domain of calling document)
 * @param {boolean} [secure] - Boolean value indicating if the cookie transmission requires a secure transmission
 */
function setCookie(name, value, expires, path, domain, secure) {
    var curCookie = name + "=" + escape(value) +
        (expires ? "; expires=" + expires.toGMTString() : "") +
        (path ? "; path=" + path : "") +
        (domain ? "; domain=" + domain : "") +
        (secure ? "; secure" : "");
    document.cookie = curCookie;
}

/**
 * Gets the cookie value.
 * @param {string} name The name of the desired cookie.
 * @returns {string} A string containing the value of specified cookie or null if cookie does not exist.
 */
function getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin === -1) {
        begin = dc.indexOf(prefix);
        if (begin !== 0) return null;
    } else
        begin += 2;
    var end = document.cookie.indexOf(";", begin);
    if (end === -1)
        end = dc.length;
    return unescape(dc.substring(begin + prefix.length, end));
}


/**
 * Deletes a cookie.
 * @param {string} name - The name of the cookie.
 * @param {string} [path] - path of the cookie (must be same as path used to create cookie)
 * @param {string} [domain] - domain of the cookie (must be same as domain used to create cookie)
 */
function deleteCookie(name, path, domain) {
    if (getCookie(name)) {
        document.cookie = name + "=" +
            (path ? "; path=" + path : "") +
            (domain ? "; domain=" + domain : "") +
            "; expires=Thu, 01-Jan-70 00:00:01 GMT";
    }
}


/**
 * Fixes the moniker of the current URL. It's needed for implementation of userData in a CHM.
 * @returns {boolean} True if the fix (URL replace) was done.
 */
function fixMoniker() {
    var curURL = document.location + ".";
    var pos = curURL.indexOf("mk:@MSITStore");
    if (pos === 0) {
        curURL = "ms-its:" + curURL.substring(14, curURL.length - 1);
        document.location.replace(curURL);
        return false;
    }
    else { return true; }
}


/**
 * Detects whether HTML5 localStotage functionality is supported.
 * @returns {boolean} A value indicating whether HTML5 localStotage functionality is supported.
 */
function isLocalStorageSupported() {
    var str = 'vsdocmanDetectStorage';
    try {
        localStorage.setItem(str, str);
        localStorage.removeItem(str);
        return true;
    } catch (e) {
        return false;
    }
}


function saveSetting(name, value) {
    // create an instance of the Date object
    var now = new Date();
    // cookie expires in one year (actually, 365 days)
    // 1000 milliseconds in a second
    now.setTime(now.getTime() + 365 * 24 * 60 * 60 * 1000);
    // convert the value to correct String
    if (value.constructor === Boolean) {
        if (!value) {
            value = "";
        }
    }
    // IE returns wrong document.cookie if the value is empty string
    if (value === "") {
        value = "string:empty";
    }

    // try to use localStorage (instead of old-fashioned cookies or userData)
    if (isLocalStorageSupported()) {
        localStorage.setItem(name, value);
        return;
    }

    // we cannot use cookies in CHM, so try to use behaviors if possible
    var headerDiv;	// we can use any particular DIV or other element
    headerDiv = document.getElementById("header");
    if (headerDiv.addBehavior) {
        headerDiv.style.behavior = "url('#default#userData')";
        headerDiv.expires = now.toUTCString();
        headerDiv.setAttribute(name, value);
        // Save the persistence data as "helpSettings".
        headerDiv.save("helpSettings");
    } else {
        // set the new cookie
        setCookie(name, value, now/*, "/"*/);
    }
}


function loadSetting(name, defaultValue) {
    var res;

    // try to use localStorage (instead of old-fashioned cookies or userData)
    if (isLocalStorageSupported()) {
        res = localStorage.getItem(name);
    } else {
        // we cannot use cookies in CHM, so try to use behaviors if possible
        var headerDiv;	// we can use any particular DIV or other element
        headerDiv = document.getElementById("header");
        if (headerDiv.addBehavior) {
            headerDiv.style.behavior = "url('#default#userData')";
            headerDiv.load("helpSettings");
            res = headerDiv.getAttribute(name);
        } else {
            // get the cookie
            res = getCookie(name);
        }
    }

    if (res === "string:empty") {
        res = "";
    }
    if (res === null) {
        res = defaultValue;
    }
    return res;
}


// #endregion PERSISTENCE *************************


