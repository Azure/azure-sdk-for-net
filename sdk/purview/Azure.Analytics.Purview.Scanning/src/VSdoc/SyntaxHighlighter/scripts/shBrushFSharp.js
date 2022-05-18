/**
 * SyntaxHighlighter
 * http://alexgorbatchev.com/
 *
 * SyntaxHighlighter is donationware. If you are using it, please donate.
 * http://alexgorbatchev.com/wiki/SyntaxHighlighter:Donate
 *
 * @version
 * 2.0.320 (May 03 2009)
 *
 * @copyright
 * Copyright (C) 2004-2009 Alex Gorbatchev.
 *
 * @license
 * This file is part of SyntaxHighlighter.
 *
 * SyntaxHighlighter is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SyntaxHighlighter is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SyntaxHighlighter.  If not, see <http://www.gnu.org/copyleft/lesser.html>.
 */

/* modified by Helixoft */

SyntaxHighlighter.brushes.FSharp = function () {
    /* main F# keywords */
    var keywords1 =
        /* section 3.4 */
        'abstract and as assert base begin class default delegate do done ' +
        'downcast downto elif else end exception extern false finally for ' +
        'fun function if in inherit inline interface internal lazy let ' +
        'match member module mutable namespace new null of open or ' +
        'override private public rec return sig static struct then to ' +
        'true try type upcast use val void when while with yield ' +
        'asr land lor lsl lsr lxor mod ' +
        /* identifiers are reserved for future use by F# */
        'atomic break checked component const constraint constructor ' +
        'continue eager fixed fori functor global include method mixin ' +
        'object parallel params process protected pure sealed tailcall ' +
        'trait virtual volatile ';
    /* do, return, let, yield keywords with ! at the end are added later */

    /* define names of main libraries in F# Core so we can link to it
          http://research.microsoft.com/en-us/um/cambridge/projects/fsharp/manual/namespaces.html
      */
    var modules =
        'Array Array2D Array3D Array4D ComparisonIdentity HashIdentity List ' +
        'Map Seq SequenceExpressionHelpers Set CommonExtensions Event ' +
        'ExtraTopLevelOperators LanguagePrimitives NumericLiterals Operators ' +
        'OptimizedClosures Option String NativePtr Printf';

    /* 17.2 & 17.3 */
    var functions =
        'abs acos asin atan atan2 ceil cos cosh exp ' +
        'floor log log10 pown round sign sin sinh sqrt tan tanh ' +
        'fst snd KeyValue not min max ' +
        'ignore stdin stdout stderr ';

    /* 17.2 Object Transformation Operators */
    var objectTransformations =
        'box hash sizeof typeof typedefof unbox'

    /* 17.2 Exceptions */
    var exceptions =
        'failwith invalidArg raise rethrow';

    /* 3.11 Pre-processor Declarations / Identifier Replacements*/
    var constants =
        '__SOURCE_DIRECTORY__ __SOURCE_FILE__ __LINE__';

    /* Pervasives Types & Overloaded Conversion Functions */
    var datatypes =
        'bool byref byte char decimal double exn float float32 ' +
        'FuncConvert ilsigptr int int16 int32 int64 int8 ' +
        'nativeint nativeptr obj option ref sbyte single string uint16 ' +
        'uint32 uint64 uint8 unativeint unit enum async seq dict ';

    function fixComments(match, regexInfo) {
        var css = (match[0].indexOf("///") === 0) ? 'color1' : 'comments';
        return [new SyntaxHighlighter.Match(match[0], match.index, css)];
    }

    this.regexList = [
        { regex: /\<.*?\>/gm, css: 'skipTag' },			// HTML tag, don't decorate, Helixoft
        /* 3.3 Conditional compilation & 13.3 Compiler Directives + light /light off*/
        { regex: /\s*#\b(light|if|else|endif|indent|nowarn|r(eference)?|I|include|load|time|help|q(uit)?)/gm, css: 'preprocessor' },
        { regex: SyntaxHighlighter.regexLib.singleLineCComments, css: 'comments' },
        { regex: SyntaxHighlighter.regexLib.multiLineCComments, css: 'comments' },
        { regex: /\s*\(\*[\s\S]*?\*\)/gm, css: 'comments' },
        { regex: SyntaxHighlighter.regexLib.doubleQuotedString, css: 'string' },
        { regex: /'[^']?'/gm, css: 'string' },
        { regex: new RegExp(this.getKeywords(keywords1), 'gm'), css: 'keyword' },
        { regex: /\s*(do|let|yield|return)*\!/gm, css: 'keyword' },
        { regex: new RegExp(this.getKeywords(modules), 'gm'), css: 'keyword' },
        { regex: new RegExp(this.getKeywords(functions), 'gm'), css: 'functions' },
        { regex: new RegExp(this.getKeywords(objectTransformations), 'gm'), css: 'keyword' },
        { regex: new RegExp(this.getKeywords(exceptions), 'gm'), css: 'keyword' },
        { regex: new RegExp(this.getKeywords(constants), 'gm'), css: 'constants' },
        { regex: new RegExp(this.getKeywords(datatypes), 'gm'), css: 'keyword' }
    ];

    this.forHtmlScript(SyntaxHighlighter.regexLib.aspScriptTags);
};

SyntaxHighlighter.brushes.FSharp.prototype = new SyntaxHighlighter.Highlighter();
SyntaxHighlighter.brushes.FSharp.aliases = ['f#', 'f-sharp', 'fsharp'];