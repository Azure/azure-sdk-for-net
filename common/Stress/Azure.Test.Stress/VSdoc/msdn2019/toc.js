

// #region Main TOC

var c = [];

/**
 * Appends a TOC item under an existing XML element.
 * @param {HTMLElement} parentElm The parent element for the TOC item to be appended.
 * @param {Array} tocNode The TOC item to be appended. Format: ['Id','Text','Url',hasChildrenStr=0/1]
 */
function appendTocNode(parentElm, tocNode) {
    var id = tocNode[0];
    var text = tocNode[1];
    var url = tocNode[2];
    var hasChildren = tocNode[3];

    if (hasChildren === 1) {
        //<div id="id" class="header closed" onclick="toggle('cID',this)">
        //    <a href="url">text</a>
        //</div>
        //<div id="cID" class="item collapsed">
        //  <div id="ciID" class="inner-for-height">
        //  </div>
        //</div>
        var div1 = document.createElement('div');
        div1.id = id;
        div1.className = "header closed";
        div1.onclick = function () { toggle("c" + id, div1); };

        if (url !== "") {
            var a1 = document.createElement('a');
            a1.href = url;
            a1.setAttribute('title', text);
            //a1.innerHTML = text;
            a1.appendChild(document.createTextNode(text));   // safe way of setting un-escaped text

            div1.appendChild(a1);
        } else {
            //div1.innerHTML = text;
            div1.appendChild(document.createTextNode(text));   // safe way of setting un-escaped text
        }

        var div2 = document.createElement('div');
        div2.id = "c" + id;
        div2.className = "item collapsed";

        var div3 = document.createElement('div');
        div3.id = "ci" + id;
        div3.className = "inner-for-height";

        div2.appendChild(div3);

        parentElm.appendChild(div1);
        parentElm.appendChild(div2);
    } else {
        //<div id="id" class="leaf"><a href="url">text</a></div>
        var div = document.createElement('div');
        div.id = id;
        div.className = "leaf";

        var a = document.createElement('a');
        a.href = url;
        a.setAttribute('title', text);
        a.appendChild(document.createTextNode(text));   // safe way of setting un-escaped text
        //a.innerHTML = text;

        div.appendChild(a);
        parentElm.appendChild(div);
    }
}


/**
 * Toggles expansion of a TOC chapter.
 * @param {string} idSub Id of the DIV container with subtopics.
 * @param {HTMLElement} elHead The chapter DIV element.
 */
function toggle(idSub, elHead) {
    elHead.classList.add("animatable"); // make header DIV animatable
    var elSub = document.getElementById(idSub);
    if (hasElementClass(elSub, "expanded")) {
        // collapse
        expandCollapseElement(elSub, false, true);

        if (hasElementClasses(elHead, ["header", "open"])) {
            removeClassFromElement(elHead, "open");
            addClassToElement(elHead, "closed");
        }
        fitTocHeightToViewport();
    }
    else {
        // expand
        expandTocItem(elHead.id, true);
    }
}


/**
 * 
 * @param {HTMLElement} element The chapter container outer DIV.
 * @param {boolean} expand Indicates whether to expand or collapse.
 * @param {boolean} animationEffects Indicates whether to show animation.
 */
function expandCollapseElement(element, expand, animationEffects) {
    if (expand) {
        if (animationEffects) {
            element.classList.add("animatable"); // make container DIV animatable
        }
        element.classList.replace('collapsed', 'expanded');
    } else {
        if (animationEffects) {
            element.classList.add("animatable"); // make container DIV animatable
        }
        element.classList.replace('expanded', 'collapsed');
    }
    return;
}


/**
 * Returns the element height including margins.
 * @param {HTMLElement} element The element to test.
 * @returns {number} The height.
 */
function outerHeight(element) {
    const height = element.offsetHeight;
    const style = window.getComputedStyle(element);

    return ['top', 'bottom']
        .map(function (side) { return parseInt(style["margin-" + side]); })
        .reduce(function (total, side) { return total + side, height; });
}


/**
 * Expands specified topic chain in the TOC and selects the terminal topic. 
 * Function works asynchronously (the nodes are dynamically loaded if needed).
 * @param {Array<Array<string>>} breadcrumbs An array of topic definitions. A single TOC item
 * has format: ['Id','Text','Url'].
 * @returns {Promise<string>} A promise that is resolved after all specified nodes are expanded. The value is Id
 * of the last node.
 */
function expandBreadcrumbsInToc(breadcrumbs) {
    var oldScrollX = window.pageXOffset;
    var oldScrollY = window.pageYOffset;

    var lastId;
    var expandPromise = Promise.resolve();  //immediately resolving promise
    for (i = 0; i < breadcrumbs.length; i++) {
        var tocNode = breadcrumbs[i];
        let id = tocNode[0];
        lastId = id;
        expandPromise = expandPromise.then(function () { return expandTocItem(id, false) });
    }

    return expandPromise.then(
        function () {
            selectTocItem(lastId);    //last topic in breadcrumbs

            // The TOC expansion could scroll the page a bit. Scroll back to the original position.
            // On the next frame (as soon as the previous style change has taken effect),
            // restore the scroll position if it has changed.
            requestAnimationFrame(function () {
                window.scrollTo(oldScrollX, oldScrollY);
            });

            return lastId;
        }
    );
}


/**
 * Expands specified TOC item asynchronously (the child nodes are dynamically loaded if needed).
 * @param {string} tocItemId The ID of TOC item to expand.
 * @returns {Promise<string>} A promise that is resolved when the node is expanded. The value is tocItemId.
 * @param {boolean} animationEffects Indicates whether to show animation.
 */
function expandTocItem(tocItemId, animationEffects) {
    // get the chapter header
    var elmHead = document.getElementById(tocItemId);
    if (!elmHead) {
        return;
    }
    if (elmHead.className === "leaf") {
        return;
    }

    // get the container with subtopics
    var elmCont = document.getElementById("c" + tocItemId);
    if (hasElementClass(elmCont, "collapsed")) {
        // expand
        expandCollapseElement(elmCont, true, animationEffects);

        // process also chapter header
        if (hasElementClasses(elmHead, ["header", "closed"])) {
            removeClassFromElement(elmHead, "closed");
            addClassToElement(elmHead, "open");
        }

    }

    // ensure the child nodes are loaded
    return loadScriptOnce("toc--/t_" + tocItemId + ".js")
        .then(
            function (scriptWasLoadedNow) {
                if (scriptWasLoadedNow) {
                    appendChildTocItems(tocItemId);
                    fitTocHeightToViewport();
                    return tocItemId;
                }
            });

}


function appendChildTocItems(parentTocItemId) {
    // get inner DIV of the container with subtopics
    var elmCont = document.getElementById("ci" + parentTocItemId);
    var childrenDefinitions = c[parentTocItemId];    //dynamically loaded from t_ID.js
    if (elmCont && childrenDefinitions && elmCont.children.length === 0) {
        for (i = 0; i < childrenDefinitions.length; i++) {
            appendTocNode(elmCont, childrenDefinitions[i]);
        }
    }
}


/**
 * Selects (focus + highlight) specified TOC item
 * @param {string} tocItemId The ID of TOC item to select.
 */
function selectTocItem(tocItemId) {
    var linkContainer = document.getElementById(tocItemId);

    var oldSelected = getDivWithClass(document.body, "toc-highlighted");
    if (oldSelected) {
        removeClassFromElement(oldSelected, "toc-highlighted");
    }
    addClassToElement(linkContainer, "toc-highlighted");

    var links = linkContainer.getElementsByTagName("a");
    if (links.length > 0) {
        var link = links[0];
        //alert(link);
        //alert(link.innerHTML);
        if (!isElementVisibleY(link)) {
            link.scrollIntoView(true);
        }
        link.focus();
    }
}



function isElementVisibleY(el) {
    var rect = el.getBoundingClientRect(), top = rect.top, height = rect.height;
    el = el.parentNode;
    // Check if bottom of the element is off the page
    if (rect.bottom < 0) return false;
    // Check its within the document viewport
    if (top > document.documentElement.clientHeight) return false;
    do {
        rect = el.getBoundingClientRect();
        if (top <= rect.bottom === false) return false;
        // Check if the element is out of view due to a container scrolling
        if ((top + height) <= rect.top) return false;
        el = el.parentNode;
    } while (el !== document.body);
    return true;
}

// #endregion Main TOC


// #region Internal (in-page) TOC

/**
 * The InternalTOC class representing a dynamic internal (in-page) TOC for the page sections.
 * */
function InternalToc() {

    /**
    * A single generated TOC item.
    * @typedef {Object} TocItem
    * @property {HTMLElement} listItem - The LI element of the TOC item.
    * @property {HTMLElement} anchor - The link element inside the LI.
    * @property {HTMLElement} target - The target element on the page.
    */

    /**
     * The generated TOC items.
     * @type Array<TocItem>
     * */
    var tocItems;

    // Factor of screen size that the element must cross
    // before it's considered visible
    var TOP_MARGIN = 0.0;
    var BOTTOM_MARGIN = 0.0;

    // IE11 (used in CHM) doesn't have forEach, includes functions used in this class.
    // Add them.
    // NodeList.forEach
    if (window.NodeList && !NodeList.prototype.forEach) {
        NodeList.prototype.forEach = Array.prototype.forEach;
    }
    // Array.includes
    if (!Array.prototype.includes) {
        Object.defineProperty(Array.prototype, 'includes', {
            value: function (searchElement, fromIndex) {

                if (this == null) {
                    throw new TypeError('"this" is null or not defined');
                }

                const o = Object(this);
                // tslint:disable-next-line:no-bitwise
                const len = o.length >>> 0;

                if (len === 0) {
                    return false;
                }
                // tslint:disable-next-line:no-bitwise
                const n = fromIndex | 0;
                let k = Math.max(n >= 0 ? n : len - Math.abs(n), 0);

                while (k < len) {
                    if (o[k] === searchElement) {
                        return true;
                    }
                    k++;
                }
                return false;
            }
        });
    }
    generateTOC(document.getElementById("internal-toc-container"));
    registerEventHandler(window, 'scroll', syncSelectedTocItems);


    /**
     * Generates the TOC from the section headings on the page.
     * @param {any} tocParent The parent element where the TOC will be added.
     */
    function generateTOC(tocParent) {
        if (!tocParent) {
            return;
        }

        let pageContent = document.getElementById("mainBody");
        let headingsAll = pageContent.querySelectorAll('h2, h3, .section_heading, summary-info');
        let headings = [];
        let existingIDs = [];

        // Preprocess the headings.
        headingsAll.forEach(function (heading) {
            if (heading.id) {
                existingIDs.push(heading.id);
            }
            
            // Don't show 'Definition' for custom topics.
            let ignoreHeading = false;
            if (heading.tagName === "SUMMARY-INFO") {
                let codeMemberMetadata = pageContent.querySelector('div.metadata');
                if (codeMemberMetadata === null || codeMemberMetadata.textContent.trim().length=== 0) {
                    ignoreHeading = true;
                }
            }
            if (!ignoreHeading) {
                headings.push(heading);
            }
        });

        // Ensure each heading has an ID.
        headings.forEach(function (heading) {
            if (!heading.id) {
                let id = heading.textContent.trim().toLowerCase().split(' ').join('-').replace(/[\!\@\#\$\%\^\&\*\(\)\:]/ig, '');
                if (id.length === 0) {
                    id = "tocid";
                }
                id = generateUniqueID(id, existingIDs);
                heading.id = id;
                existingIDs.push(id);
            }
        });

        // Create the TOC
        tocItems = [];
        if (headings.length > 0) {
            let tocHeading = document.getElementById("internal-toc-heading");
            if (tocHeading) {
                addClassToElement(tocHeading, "visible");
            }

            let localizedDefinitionText = "Definition";
            let localizedHiddenElm = document.getElementById("internal-toc-definition-localized-text");
            if (localizedHiddenElm) {
                localizedDefinitionText = localizedHiddenElm.textContent;
            }
            
            let olElm = document.createElement("ul");
            tocParent.appendChild(olElm);

            headings.forEach(function (heading) {
                let text = heading.tagName === "SUMMARY-INFO" ? localizedDefinitionText : heading.textContent;
                let aElm = document.createElement("a");
                aElm.href = "#" + heading.id;
                aElm.innerHTML = text;

                let liElm = document.createElement("li");
                liElm.appendChild(aElm);
                olElm.appendChild(liElm);

                tocItems.push({
                    listItem: liElm,
                    anchor: aElm,
                    target: heading
                });

            });

        }

        syncSelectedTocItems();
    }


    function generateUniqueID(id, existingIDs) {
        let newId = id;
        let i = 1;
        while (existingIDs.includes(newId)) {
            i++;
            newId = id + "_" + i;
        }
        return newId;
    }


    function syncSelectedTocItems() {
        var windowHeight = window.innerHeight;
        var MINIMUM_VISIBLE_PART = 5; // the minimum required visible part of a section to be considered as visible, in pixels

        var previousItem = null;
        tocItems.forEach(function (item) {
            var targetBounds = item.target.getBoundingClientRect();

            if (targetBounds.top < windowHeight - MINIMUM_VISIBLE_PART) {
                // The heading top is in the viewport or above it.
                item.listItem.classList.add('visible');
            }
            else {
                item.listItem.classList.remove('visible');
            }

            // Correct the previous item, that could be marked as visible, but it isn't.
            if (previousItem && targetBounds.top < MINIMUM_VISIBLE_PART) {
                // prevous is not visible
                previousItem.listItem.classList.remove('visible');
            }
            previousItem = item;

        });

    }

}

// #endregion Internal (in-page) TOC