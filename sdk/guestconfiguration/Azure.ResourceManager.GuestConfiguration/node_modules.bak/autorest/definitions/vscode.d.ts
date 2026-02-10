/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

declare module 'vscode' {

	/**
	 * The version of the editor.
	 */
  export const version: string;

	/**
	 * Represents a reference to a command. Provides a title which
	 * will be used to represent a command in the UI and, optionally,
	 * an array of arguments which will be passed to the command handler
	 * function when invoked.
	 */
  export interface Command {
		/**
		 * Title of the command, like `save`.
		 */
    title: string;

		/**
		 * The identifier of the actual command handler.
		 * @see [commands.registerCommand](#commands.registerCommand).
		 */
    command: string;

		/**
		 * A tooltip for for command, when represented in the UI.
		 */
    tooltip?: string;

		/**
		 * Arguments that the command handler should be
		 * invoked with.
		 */
    arguments?: any[];
  }

	/**
	 * Represents a line of text, such as a line of source code.
	 *
	 * TextLine objects are __immutable__. When a [document](#TextDocument) changes,
	 * previously retrieved lines will not represent the latest state.
	 */
  export interface TextLine {

		/**
		 * The zero-based line number.
		 */
    readonly lineNumber: number;

		/**
		 * The text of this line without the line separator characters.
		 */
    readonly text: string;

		/**
		 * The range this line covers without the line separator characters.
		 */
    readonly range: Range;

		/**
		 * The range this line covers with the line separator characters.
		 */
    readonly rangeIncludingLineBreak: Range;

		/**
		 * The offset of the first character which is not a whitespace character as defined
		 * by `/\s/`. **Note** that if a line is all whitespaces the length of the line is returned.
		 */
    readonly firstNonWhitespaceCharacterIndex: number;

		/**
		 * Whether this line is whitespace only, shorthand
		 * for [TextLine.firstNonWhitespaceCharacterIndex](#TextLine.firstNonWhitespaceCharacterIndex) === [TextLine.text.length](#TextLine.text).
		 */
    readonly isEmptyOrWhitespace: boolean;
  }

	/**
	 * Represents a text document, such as a source file. Text documents have
	 * [lines](#TextLine) and knowledge about an underlying resource like a file.
	 */
  export interface TextDocument {

		/**
		 * The associated URI for this document. Most documents have the __file__-scheme, indicating that they
		 * represent files on disk. However, some documents may have other schemes indicating that they are not
		 * available on disk.
		 */
    readonly uri: Uri;

		/**
		 * The file system path of the associated resource. Shorthand
		 * notation for [TextDocument.uri.fsPath](#TextDocument.uri). Independent of the uri scheme.
		 */
    readonly fileName: string;

		/**
		 * Is this document representing an untitled file.
		 */
    readonly isUntitled: boolean;

		/**
		 * The identifier of the language associated with this document.
		 */
    readonly languageId: string;

		/**
		 * The version number of this document (it will strictly increase after each
		 * change, including undo/redo).
		 */
    readonly version: number;

		/**
		 * `true` if there are unpersisted changes.
		 */
    readonly isDirty: boolean;

		/**
		 * `true` if the document have been closed. A closed document isn't synchronized anymore
		 * and won't be re-used when the same resource is opened again.
		 */
    readonly isClosed: boolean;

		/**
		 * Save the underlying file.
		 *
		 * @return A promise that will resolve to true when the file
		 * has been saved. If the file was not dirty or the save failed,
		 * will return false.
		 */
    save(): Thenable<boolean>;

		/**
		 * The [end of line](#EndOfLine) sequence that is predominately
		 * used in this document.
		 */
    readonly eol: EndOfLine;

		/**
		 * The number of lines in this document.
		 */
    readonly lineCount: number;

		/**
		 * Returns a text line denoted by the line number. Note
		 * that the returned object is *not* live and changes to the
		 * document are not reflected.
		 *
		 * @param line A line number in [0, lineCount).
		 * @return A [line](#TextLine).
		 */
    lineAt(line: number): TextLine;

		/**
		 * Returns a text line denoted by the position. Note
		 * that the returned object is *not* live and changes to the
		 * document are not reflected.
		 *
		 * The position will be [adjusted](#TextDocument.validatePosition).
		 *
		 * @see [TextDocument.lineAt](#TextDocument.lineAt)
		 * @param position A position.
		 * @return A [line](#TextLine).
		 */
    lineAt(position: Position): TextLine;

		/**
		 * Converts the position to a zero-based offset.
		 *
		 * The position will be [adjusted](#TextDocument.validatePosition).
		 *
		 * @param position A position.
		 * @return A valid zero-based offset.
		 */
    offsetAt(position: Position): number;

		/**
		 * Converts a zero-based offset to a position.
		 *
		 * @param offset A zero-based offset.
		 * @return A valid [position](#Position).
		 */
    positionAt(offset: number): Position;

		/**
		 * Get the text of this document. A substring can be retrieved by providing
		 * a range. The range will be [adjusted](#TextDocument.validateRange).
		 *
		 * @param range Include only the text included by the range.
		 * @return The text inside the provided range or the entire text.
		 */
    getText(range?: Range): string;

		/**
		 * Get a word-range at the given position. By default words are defined by
		 * common separators, like space, -, _, etc. In addition, per languge custom
		 * [word definitions](#LanguageConfiguration.wordPattern) can be defined. It
		 * is also possible to provide a custom regular expression.
		 *
		 * * *Note 1:* A custom regular expression must not match the empty string and
		 * if it does, it will be ignored.
		 * * *Note 2:* A custom regular expression will fail to match multiline strings
		 * and in the name of speed regular expressions should not match words with
		 * spaces. Use [`TextLine.text`](#TextLine.text) for more complex, non-wordy, scenarios.
		 *
		 * The position will be [adjusted](#TextDocument.validatePosition).
		 *
		 * @param position A position.
		 * @param regex Optional regular expression that describes what a word is.
		 * @return A range spanning a word, or `undefined`.
		 */
    getWordRangeAtPosition(position: Position, regex?: RegExp): Range | undefined;

		/**
		 * Ensure a range is completely contained in this document.
		 *
		 * @param range A range.
		 * @return The given range or a new, adjusted range.
		 */
    validateRange(range: Range): Range;

		/**
		 * Ensure a position is contained in the range of this document.
		 *
		 * @param position A position.
		 * @return The given position or a new, adjusted position.
		 */
    validatePosition(position: Position): Position;
  }

	/**
	 * Represents a line and character position, such as
	 * the position of the cursor.
	 *
	 * Position objects are __immutable__. Use the [with](#Position.with) or
	 * [translate](#Position.translate) methods to derive new positions
	 * from an existing position.
	 */
  export class Position {

		/**
		 * The zero-based line value.
		 */
    readonly line: number;

		/**
		 * The zero-based character value.
		 */
    readonly character: number;

		/**
		 * @param line A zero-based line value.
		 * @param character A zero-based character value.
		 */
    constructor(line: number, character: number);

		/**
		 * Check if `other` is before this position.
		 *
		 * @param other A position.
		 * @return `true` if position is on a smaller line
		 * or on the same line on a smaller character.
		 */
    isBefore(other: Position): boolean;

		/**
		 * Check if `other` is before or equal to this position.
		 *
		 * @param other A position.
		 * @return `true` if position is on a smaller line
		 * or on the same line on a smaller or equal character.
		 */
    isBeforeOrEqual(other: Position): boolean;

		/**
		 * Check if `other` is after this position.
		 *
		 * @param other A position.
		 * @return `true` if position is on a greater line
		 * or on the same line on a greater character.
		 */
    isAfter(other: Position): boolean;

		/**
		 * Check if `other` is after or equal to this position.
		 *
		 * @param other A position.
		 * @return `true` if position is on a greater line
		 * or on the same line on a greater or equal character.
		 */
    isAfterOrEqual(other: Position): boolean;

		/**
		 * Check if `other` equals this position.
		 *
		 * @param other A position.
		 * @return `true` if the line and character of the given position are equal to
		 * the line and character of this position.
		 */
    isEqual(other: Position): boolean;

		/**
		 * Compare this to `other`.
		 *
		 * @param other A position.
		 * @return A number smaller than zero if this position is before the given position,
		 * a number greater than zero if this position is after the given position, or zero when
		 * this and the given position are equal.
		 */
    compareTo(other: Position): number;

		/**
		 * Create a new position relative to this position.
		 *
		 * @param lineDelta Delta value for the line value, default is `0`.
		 * @param characterDelta Delta value for the character value, default is `0`.
		 * @return A position which line and character is the sum of the current line and
		 * character and the corresponding deltas.
		 */
    translate(lineDelta?: number, characterDelta?: number): Position;

		/**
		 * Derived a new position relative to this position.
		 *
		 * @param change An object that describes a delta to this position.
		 * @return A position that reflects the given delta. Will return `this` position if the change
		 * is not changing anything.
		 */
    translate(change: { lineDelta?: number; characterDelta?: number; }): Position;

		/**
		 * Create a new position derived from this position.
		 *
		 * @param line Value that should be used as line value, default is the [existing value](#Position.line)
		 * @param character Value that should be used as character value, default is the [existing value](#Position.character)
		 * @return A position where line and character are replaced by the given values.
		 */
    with(line?: number, character?: number): Position;

		/**
		 * Derived a new position from this position.
		 *
		 * @param change An object that describes a change to this position.
		 * @return A position that reflects the given change. Will return `this` position if the change
		 * is not changing anything.
		 */
    with(change: { line?: number; character?: number; }): Position;
  }

	/**
	 * A range represents an ordered pair of two positions.
	 * It is guaranteed that [start](#Range.start).isBeforeOrEqual([end](#Range.end))
	 *
	 * Range objects are __immutable__. Use the [with](#Range.with),
	 * [intersection](#Range.intersection), or [union](#Range.union) methods
	 * to derive new ranges from an existing range.
	 */
  export class Range {

		/**
		 * The start position. It is before or equal to [end](#Range.end).
		 */
    readonly start: Position;

		/**
		 * The end position. It is after or equal to [start](#Range.start).
		 */
    readonly end: Position;

		/**
		 * Create a new range from two positions. If `start` is not
		 * before or equal to `end`, the values will be swapped.
		 *
		 * @param start A position.
		 * @param end A position.
		 */
    constructor(start: Position, end: Position);

		/**
		 * Create a new range from number coordinates. It is a shorter equivalent of
		 * using `new Range(new Position(startLine, startCharacter), new Position(endLine, endCharacter))`
		 *
		 * @param startLine A zero-based line value.
		 * @param startCharacter A zero-based character value.
		 * @param endLine A zero-based line value.
		 * @param endCharacter A zero-based character value.
		 */
    constructor(startLine: number, startCharacter: number, endLine: number, endCharacter: number);

		/**
		 * `true` if `start` and `end` are equal.
		 */
    isEmpty: boolean;

		/**
		 * `true` if `start.line` and `end.line` are equal.
		 */
    isSingleLine: boolean;

		/**
		 * Check if a position or a range is contained in this range.
		 *
		 * @param positionOrRange A position or a range.
		 * @return `true` if the position or range is inside or equal
		 * to this range.
		 */
    contains(positionOrRange: Position | Range): boolean;

		/**
		 * Check if `other` equals this range.
		 *
		 * @param other A range.
		 * @return `true` when start and end are [equal](#Position.isEqual) to
		 * start and end of this range.
		 */
    isEqual(other: Range): boolean;

		/**
		 * Intersect `range` with this range and returns a new range or `undefined`
		 * if the ranges have no overlap.
		 *
		 * @param range A range.
		 * @return A range of the greater start and smaller end positions. Will
		 * return undefined when there is no overlap.
		 */
    intersection(range: Range): Range | undefined;

		/**
		 * Compute the union of `other` with this range.
		 *
		 * @param other A range.
		 * @return A range of smaller start position and the greater end position.
		 */
    union(other: Range): Range;

		/**
		 * Derived a new range from this range.
		 *
		 * @param start A position that should be used as start. The default value is the [current start](#Range.start).
		 * @param end A position that should be used as end. The default value is the [current end](#Range.end).
		 * @return A range derived from this range with the given start and end position.
		 * If start and end are not different `this` range will be returned.
		 */
    with(start?: Position, end?: Position): Range;

		/**
		 * Derived a new range from this range.
		 *
		 * @param change An object that describes a change to this range.
		 * @return A range that reflects the given change. Will return `this` range if the change
		 * is not changing anything.
		 */
    with(change: { start?: Position, end?: Position }): Range;
  }

	/**
	 * Represents a text selection in an editor.
	 */
  export class Selection extends Range {

		/**
		 * The position at which the selection starts.
		 * This position might be before or after [active](#Selection.active).
		 */
    anchor: Position;

		/**
		 * The position of the cursor.
		 * This position might be before or after [anchor](#Selection.anchor).
		 */
    active: Position;

		/**
		 * Create a selection from two postions.
		 *
		 * @param anchor A position.
		 * @param active A position.
		 */
    constructor(anchor: Position, active: Position);

		/**
		 * Create a selection from four coordinates.
		 *
		 * @param anchorLine A zero-based line value.
		 * @param anchorCharacter A zero-based character value.
		 * @param activeLine A zero-based line value.
		 * @param activeCharacter A zero-based character value.
		 */
    constructor(anchorLine: number, anchorCharacter: number, activeLine: number, activeCharacter: number);

		/**
		 * A selection is reversed if [active](#Selection.active).isBefore([anchor](#Selection.anchor)).
		 */
    isReversed: boolean;
  }

	/**
	 * Represents sources that can cause [selection change events](#window.onDidChangeTextEditorSelection).
	*/
  export enum TextEditorSelectionChangeKind {
		/**
		 * Selection changed due to typing in the editor.
		 */
    Keyboard = 1,
		/**
		 * Selection change due to clicking in the editor.
		 */
    Mouse = 2,
		/**
		 * Selection changed because a command ran.
		 */
    Command = 3
  }

	/**
	 * Represents an event describing the change in a [text editor's selections](#TextEditor.selections).
	 */
  export interface TextEditorSelectionChangeEvent {
		/**
		 * The [text editor](#TextEditor) for which the selections have changed.
		 */
    textEditor: TextEditor;
		/**
		 * The new value for the [text editor's selections](#TextEditor.selections).
		 */
    selections: Selection[];
		/**
		 * The [change kind](#TextEditorSelectionChangeKind) which has triggered this
		 * event. Can be `undefined`.
		 */
    kind?: TextEditorSelectionChangeKind;
  }

	/**
	 * Represents an event describing the change in a [text editor's options](#TextEditor.options).
	 */
  export interface TextEditorOptionsChangeEvent {
		/**
		 * The [text editor](#TextEditor) for which the options have changed.
		 */
    textEditor: TextEditor;
		/**
		 * The new value for the [text editor's options](#TextEditor.options).
		 */
    options: TextEditorOptions;
  }

	/**
	 * Represents an event describing the change of a [text editor's view column](#TextEditor.viewColumn).
	 */
  export interface TextEditorViewColumnChangeEvent {
		/**
		 * The [text editor](#TextEditor) for which the options have changed.
		 */
    textEditor: TextEditor;
		/**
		 * The new value for the [text editor's view column](#TextEditor.viewColumn).
		 */
    viewColumn: ViewColumn;
  }

	/**
	 * Rendering style of the cursor.
	 */
  export enum TextEditorCursorStyle {
		/**
		 * Render the cursor as a vertical thick line.
		 */
    Line = 1,
		/**
		 * Render the cursor as a block filled.
		 */
    Block = 2,
		/**
		 * Render the cursor as a thick horizontal line.
		 */
    Underline = 3,
		/**
		 * Render the cursor as a vertical thin line.
		 */
    LineThin = 4,
		/**
		 * Render the cursor as a block outlined.
		 */
    BlockOutline = 5,
		/**
		 * Render the cursor as a thin horizontal line.
		 */
    UnderlineThin = 6
  }

	/**
	 * Rendering style of the line numbers.
	 */
  export enum TextEditorLineNumbersStyle {
		/**
		 * Do not render the line numbers.
		 */
    Off = 0,
		/**
		 * Render the line numbers.
		 */
    On = 1,
		/**
		 * Render the line numbers with values relative to the primary cursor location.
		 */
    Relative = 2
  }

	/**
	 * Represents a [text editor](#TextEditor)'s [options](#TextEditor.options).
	 */
  export interface TextEditorOptions {

		/**
		 * The size in spaces a tab takes. This is used for two purposes:
		 *  - the rendering width of a tab character;
		 *  - the number of spaces to insert when [insertSpaces](#TextEditorOptions.insertSpaces) is true.
		 *
		 * When getting a text editor's options, this property will always be a number (resolved).
		 * When setting a text editor's options, this property is optional and it can be a number or `"auto"`.
		 */
    tabSize?: number | string;

		/**
		 * When pressing Tab insert [n](#TextEditorOptions.tabSize) spaces.
		 * When getting a text editor's options, this property will always be a boolean (resolved).
		 * When setting a text editor's options, this property is optional and it can be a boolean or `"auto"`.
		 */
    insertSpaces?: boolean | string;

		/**
		 * The rendering style of the cursor in this editor.
		 * When getting a text editor's options, this property will always be present.
		 * When setting a text editor's options, this property is optional.
		 */
    cursorStyle?: TextEditorCursorStyle;

		/**
		 * Render relative line numbers w.r.t. the current line number.
		 * When getting a text editor's options, this property will always be present.
		 * When setting a text editor's options, this property is optional.
		 */
    lineNumbers?: TextEditorLineNumbersStyle;
  }

	/**
	 * Represents a handle to a set of decorations
	 * sharing the same [styling options](#DecorationRenderOptions) in a [text editor](#TextEditor).
	 *
	 * To get an instance of a `TextEditorDecorationType` use
	 * [createTextEditorDecorationType](#window.createTextEditorDecorationType).
	 */
  export interface TextEditorDecorationType {

		/**
		 * Internal representation of the handle.
		 */
    readonly key: string;

		/**
		 * Remove this decoration type and all decorations on all text editors using it.
		 */
    dispose(): void;
  }

	/**
	 * Represents different [reveal](#TextEditor.revealRange) strategies in a text editor.
	 */
  export enum TextEditorRevealType {
		/**
		 * The range will be revealed with as little scrolling as possible.
		 */
    Default = 0,
		/**
		 * The range will always be revealed in the center of the viewport.
		 */
    InCenter = 1,
		/**
		 * If the range is outside the viewport, it will be revealed in the center of the viewport.
		 * Otherwise, it will be revealed with as little scrolling as possible.
		 */
    InCenterIfOutsideViewport = 2,
		/**
		 * The range will always be revealed at the top of the viewport.
		 */
    AtTop = 3
  }

	/**
	 * Represents different positions for rendering a decoration in an [overview ruler](#DecorationRenderOptions.overviewRulerLane).
	 * The overview ruler supports three lanes.
	 */
  export enum OverviewRulerLane {
    Left = 1,
    Center = 2,
    Right = 4,
    Full = 7
  }

	/**
	 * Describes the behavior of decorations when typing/editing at their edges.
	 */
  export enum DecorationRangeBehavior {
		/**
		 * The decoration's range will widen when edits occur at the start or end.
		 */
    OpenOpen = 0,
		/**
		 * The decoration's range will not widen when edits occur at the start of end.
		 */
    ClosedClosed = 1,
		/**
		 * The decoration's range will widen when edits occur at the start, but not at the end.
		 */
    OpenClosed = 2,
		/**
		 * The decoration's range will widen when edits occur at the end, but not at the start.
		 */
    ClosedOpen = 3
  }

	/**
	 * Represents options to configure the behavior of showing a [document](#TextDocument) in an [editor](#TextEditor).
	 */
  export interface TextDocumentShowOptions {
		/**
		 * An optional view column in which the [editor](#TextEditor) should be shown.
		 * The default is the [one](#ViewColumn.One), other values are adjusted to
		 * be __Min(column, columnCount + 1)__.
		 */
    viewColumn?: ViewColumn;

		/**
		 * An optional flag that when `true` will stop the [editor](#TextEditor) from taking focus.
		 */
    preserveFocus?: boolean;

		/**
		 * An optional flag that controls if an [editor](#TextEditor)-tab will be replaced
		 * with the next editor or if it will be kept.
		 */
    preview?: boolean;

		/**
		 * An optional selection to apply for the document in the [editor](#TextEditor).
		 */
    selection?: Range;
  }

	/**
	 * A reference to one of the workbench colors as defined in https://code.visualstudio.com/docs/getstarted/theme-color-reference.
	 * Using a theme color is preferred over a custom color as it gives theme authors and users the possibility to change the color.
	 */
  export class ThemeColor {

		/**
		 * Creates a reference to a theme color.
		 * @param id of the color. The available colors are listed in https://code.visualstudio.com/docs/getstarted/theme-color-reference.
		 */
    constructor(id: string);
  }

	/**
	 * Represents theme specific rendering styles for a [text editor decoration](#TextEditorDecorationType).
	 */
  export interface ThemableDecorationRenderOptions {
		/**
		 * Background color of the decoration. Use rgba() and define transparent background colors to play well with other decorations.
		 * Alternativly a color from the color registry an be [referenced](#ColorIdentifier).
		 */
    backgroundColor?: string | ThemeColor;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    outline?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'outline' for setting one or more of the individual outline properties.
		 */
    outlineColor?: string | ThemeColor;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'outline' for setting one or more of the individual outline properties.
		 */
    outlineStyle?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'outline' for setting one or more of the individual outline properties.
		 */
    outlineWidth?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    border?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'border' for setting one or more of the individual border properties.
		 */
    borderColor?: string | ThemeColor;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'border' for setting one or more of the individual border properties.
		 */
    borderRadius?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'border' for setting one or more of the individual border properties.
		 */
    borderSpacing?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'border' for setting one or more of the individual border properties.
		 */
    borderStyle?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 * Better use 'border' for setting one or more of the individual border properties.
		 */
    borderWidth?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    textDecoration?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    cursor?: string;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    color?: string | ThemeColor;

		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    letterSpacing?: string;

		/**
		 * An **absolute path** or an URI to an image to be rendered in the gutter.
		 */
    gutterIconPath?: string | Uri;

		/**
		 * Specifies the size of the gutter icon.
		 * Available values are 'auto', 'contain', 'cover' and any percentage value.
		 * For further information: https://msdn.microsoft.com/en-us/library/jj127316(v=vs.85).aspx
		 */
    gutterIconSize?: string;

		/**
		 * The color of the decoration in the overview ruler. Use rgba() and define transparent colors to play well with other decorations.
		 */
    overviewRulerColor?: string | ThemeColor;

		/**
		 * Defines the rendering options of the attachment that is inserted before the decorated text
		 */
    before?: ThemableDecorationAttachmentRenderOptions;

		/**
		 * Defines the rendering options of the attachment that is inserted after the decorated text
		 */
    after?: ThemableDecorationAttachmentRenderOptions;
  }

  export interface ThemableDecorationAttachmentRenderOptions {
		/**
		 * Defines a text content that is shown in the attachment. Either an icon or a text can be shown, but not both.
		 */
    contentText?: string;
		/**
		 * An **absolute path** or an URI to an image to be rendered in the attachment. Either an icon
		 * or a text can be shown, but not both.
		 */
    contentIconPath?: string | Uri;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    border?: string;
		/**
		 * CSS styling property that will be applied to text enclosed by a decoration.
		 */
    borderColor?: string | ThemeColor;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    textDecoration?: string;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    color?: string | ThemeColor;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    backgroundColor?: string | ThemeColor;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    margin?: string;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    width?: string;
		/**
		 * CSS styling property that will be applied to the decoration attachment.
		 */
    height?: string;
  }

	/**
	 * Represents rendering styles for a [text editor decoration](#TextEditorDecorationType).
	 */
  export interface DecorationRenderOptions extends ThemableDecorationRenderOptions {
		/**
		 * Should the decoration be rendered also on the whitespace after the line text.
		 * Defaults to `false`.
		 */
    isWholeLine?: boolean;

		/**
		 * Customize the growing behavior of the decoration when edits occur at the edges of the decoration's range.
		 * Defaults to `DecorationRangeBehavior.OpenOpen`.
		 */
    rangeBehavior?: DecorationRangeBehavior;

		/**
		 * The position in the overview ruler where the decoration should be rendered.
		 */
    overviewRulerLane?: OverviewRulerLane;

		/**
		 * Overwrite options for light themes.
		 */
    light?: ThemableDecorationRenderOptions;

		/**
		 * Overwrite options for dark themes.
		 */
    dark?: ThemableDecorationRenderOptions;
  }

	/**
	 * Represents options for a specific decoration in a [decoration set](#TextEditorDecorationType).
	 */
  export interface DecorationOptions {

		/**
		 * Range to which this decoration is applied. The range must not be empty.
		 */
    range: Range;

		/**
		 * A message that should be rendered when hovering over the decoration.
		 */
    hoverMessage?: MarkedString | MarkedString[];

		/**
		 * Render options applied to the current decoration. For performance reasons, keep the
		 * number of decoration specific options small, and use decoration types whereever possible.
		 */
    renderOptions?: DecorationInstanceRenderOptions;
  }

  export interface ThemableDecorationInstanceRenderOptions {
		/**
		 * Defines the rendering options of the attachment that is inserted before the decorated text
		 */
    before?: ThemableDecorationAttachmentRenderOptions;

		/**
		 * Defines the rendering options of the attachment that is inserted after the decorated text
		 */
    after?: ThemableDecorationAttachmentRenderOptions;
  }

  export interface DecorationInstanceRenderOptions extends ThemableDecorationInstanceRenderOptions {
		/**
		 * Overwrite options for light themes.
		 */
    light?: ThemableDecorationInstanceRenderOptions;

		/**
		 * Overwrite options for dark themes.
		 */
    dark?: ThemableDecorationInstanceRenderOptions;
  }

	/**
	 * Represents an editor that is attached to a [document](#TextDocument).
	 */
  export interface TextEditor {

		/**
		 * The document associated with this text editor. The document will be the same for the entire lifetime of this text editor.
		 */
    document: TextDocument;

		/**
		 * The primary selection on this text editor. Shorthand for `TextEditor.selections[0]`.
		 */
    selection: Selection;

		/**
		 * The selections in this text editor. The primary selection is always at index 0.
		 */
    selections: Selection[];

		/**
		 * Text editor options.
		 */
    options: TextEditorOptions;

		/**
		 * The column in which this editor shows. Will be `undefined` in case this
		 * isn't one of the three main editors, e.g an embedded editor.
		 */
    viewColumn?: ViewColumn;

		/**
		 * Perform an edit on the document associated with this text editor.
		 *
		 * The given callback-function is invoked with an [edit-builder](#TextEditorEdit) which must
		 * be used to make edits. Note that the edit-builder is only valid while the
		 * callback executes.
		 *
		 * @param callback A function which can create edits using an [edit-builder](#TextEditorEdit).
		 * @param options The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.
		 * @return A promise that resolves with a value indicating if the edits could be applied.
		 */
    edit(callback: (editBuilder: TextEditorEdit) => void, options?: { undoStopBefore: boolean; undoStopAfter: boolean; }): Thenable<boolean>;

		/**
		 * Insert a [snippet](#SnippetString) and put the editor into snippet mode. "Snippet mode"
		 * means the editor adds placeholders and additionals cursors so that the user can complete
		 * or accept the snippet.
		 *
		 * @param snippet The snippet to insert in this edit.
		 * @param location Position or range at which to insert the snippet, defaults to the current editor selection or selections.
		 * @param options The undo/redo behavior around this edit. By default, undo stops will be created before and after this edit.
		 * @return A promise that resolves with a value indicating if the snippet could be inserted. Note that the promise does not signal
		 * that the snippet is completely filled-in or accepted.
		 */
    insertSnippet(snippet: SnippetString, location?: Position | Range | Position[] | Range[], options?: { undoStopBefore: boolean; undoStopAfter: boolean; }): Thenable<boolean>;

		/**
		 * Adds a set of decorations to the text editor. If a set of decorations already exists with
		 * the given [decoration type](#TextEditorDecorationType), they will be replaced.
		 *
		 * @see [createTextEditorDecorationType](#window.createTextEditorDecorationType).
		 *
		 * @param decorationType A decoration type.
		 * @param rangesOrOptions Either [ranges](#Range) or more detailed [options](#DecorationOptions).
		 */
    setDecorations(decorationType: TextEditorDecorationType, rangesOrOptions: Range[] | DecorationOptions[]): void;

		/**
		 * Scroll as indicated by `revealType` in order to reveal the given range.
		 *
		 * @param range A range.
		 * @param revealType The scrolling strategy for revealing `range`.
		 */
    revealRange(range: Range, revealType?: TextEditorRevealType): void;

		/**
		 * ~~Show the text editor.~~
		 *
		 * @deprecated Use [window.showTextDocument](#window.showTextDocument)
		 *
		 * @param column The [column](#ViewColumn) in which to show this editor.
		 * instead. This method shows unexpected behavior and will be removed in the next major update.
		 */
    show(column?: ViewColumn): void;

		/**
		 * ~~Hide the text editor.~~
		 *
		 * @deprecated Use the command `workbench.action.closeActiveEditor` instead.
		 * This method shows unexpected behavior and will be removed in the next major update.
		 */
    hide(): void;
  }

	/**
	 * Represents an end of line character sequence in a [document](#TextDocument).
	 */
  export enum EndOfLine {
		/**
		 * The line feed `\n` character.
		 */
    LF = 1,
		/**
		 * The carriage return line feed `\r\n` sequence.
		 */
    CRLF = 2
  }

	/**
	 * A complex edit that will be applied in one transaction on a TextEditor.
	 * This holds a description of the edits and if the edits are valid (i.e. no overlapping regions, document was not changed in the meantime, etc.)
	 * they can be applied on a [document](#TextDocument) associated with a [text editor](#TextEditor).
	 *
	 */
  export interface TextEditorEdit {
		/**
		 * Replace a certain text region with a new value.
		 * You can use \r\n or \n in `value` and they will be normalized to the current [document](#TextDocument).
		 *
		 * @param location The range this operation should remove.
		 * @param value The new text this operation should insert after removing `location`.
		 */
    replace(location: Position | Range | Selection, value: string): void;

		/**
		 * Insert text at a location.
		 * You can use \r\n or \n in `value` and they will be normalized to the current [document](#TextDocument).
		 * Although the equivalent text edit can be made with [replace](#TextEditorEdit.replace), `insert` will produce a different resulting selection (it will get moved).
		 *
		 * @param location The position where the new text should be inserted.
		 * @param value The new text this operation should insert.
		 */
    insert(location: Position, value: string): void;

		/**
		 * Delete a certain text region.
		 *
		 * @param location The range this operation should remove.
		 */
    delete(location: Range | Selection): void;

		/**
		 * Set the end of line sequence.
		 *
		 * @param endOfLine The new end of line for the [document](#TextDocument).
		 */
    setEndOfLine(endOfLine: EndOfLine): void;
  }

	/**
	 * A universal resource identifier representing either a file on disk
	 * or another resource, like untitled resources.
	 */
  export class Uri {

		/**
		 * Create an URI from a file system path. The [scheme](#Uri.scheme)
		 * will be `file`.
		 *
		 * @param path A file system or UNC path.
		 * @return A new Uri instance.
		 */
    static file(path: string): Uri;

		/**
		 * Create an URI from a string. Will throw if the given value is not
		 * valid.
		 *
		 * @param value The string value of an Uri.
		 * @return A new Uri instance.
		 */
    static parse(value: string): Uri;

		/**
		 * Scheme is the `http` part of `http://www.msft.com/some/path?query#fragment`.
		 * The part before the first colon.
		 */
    readonly scheme: string;

		/**
		 * Authority is the `www.msft.com` part of `http://www.msft.com/some/path?query#fragment`.
		 * The part between the first double slashes and the next slash.
		 */
    readonly authority: string;

		/**
		 * Path is the `/some/path` part of `http://www.msft.com/some/path?query#fragment`.
		 */
    readonly path: string;

		/**
		 * Query is the `query` part of `http://www.msft.com/some/path?query#fragment`.
		 */
    readonly query: string;

		/**
		 * Fragment is the `fragment` part of `http://www.msft.com/some/path?query#fragment`.
		 */
    readonly fragment: string;

		/**
		 * The string representing the corresponding file system path of this Uri.
		 *
		 * Will handle UNC paths and normalize windows drive letters to lower-case. Also
		 * uses the platform specific path separator. Will *not* validate the path for
		 * invalid characters and semantics. Will *not* look at the scheme of this Uri.
		 */
    readonly fsPath: string;

		/**
		 * Derive a new Uri from this Uri.
		 *
		 * ```ts
		 * let file = Uri.parse('before:some/file/path');
		 * let other = file.with({ scheme: 'after' });
		 * assert.ok(other.toString() === 'after:some/file/path');
		 * ```
		 *
		 * @param change An object that describes a change to this Uri. To unset components use `null` or
		 *  the empty string.
		 * @return A new Uri that reflects the given change. Will return `this` Uri if the change
		 *  is not changing anything.
		 */
    with(change: { scheme?: string; authority?: string; path?: string; query?: string; fragment?: string }): Uri;

		/**
		 * Returns a string representation of this Uri. The representation and normalization
		 * of a URI depends on the scheme. The resulting string can be safely used with
		 * [Uri.parse](#Uri.parse).
		 *
		 * @param skipEncoding Do not percentage-encode the result, defaults to `false`. Note that
		 *	the `#` and `?` characters occuring in the path will always be encoded.
		 * @returns A string representation of this Uri.
		 */
    toString(skipEncoding?: boolean): string;

		/**
		 * Returns a JSON representation of this Uri.
		 *
		 * @return An object.
		 */
    toJSON(): any;
  }

	/**
	 * A cancellation token is passed to an asynchronous or long running
	 * operation to request cancellation, like cancelling a request
	 * for completion items because the user continued to type.
	 *
	 * To get an instance of a `CancellationToken` use a
	 * [CancellationTokenSource](#CancellationTokenSource).
	 */
  export interface CancellationToken {

		/**
		 * Is `true` when the token has been cancelled, `false` otherwise.
		 */
    isCancellationRequested: boolean;

		/**
		 * An [event](#Event) which fires upon cancellation.
		 */
    onCancellationRequested: Event<any>;
  }

	/**
	 * A cancellation source creates and controls a [cancellation token](#CancellationToken).
	 */
  export class CancellationTokenSource {

		/**
		 * The cancellation token of this source.
		 */
    token: CancellationToken;

		/**
		 * Signal cancellation on the token.
		 */
    cancel(): void;

		/**
		 * Dispose object and free resources. Will call [cancel](#CancellationTokenSource.cancel).
		 */
    dispose(): void;
  }

	/**
	 * Represents a type which can release resources, such
	 * as event listening or a timer.
	 */
  export class Disposable {

		/**
		 * Combine many disposable-likes into one. Use this method
		 * when having objects with a dispose function which are not
		 * instances of Disposable.
		 *
		 * @param disposableLikes Objects that have at least a `dispose`-function member.
		 * @return Returns a new disposable which, upon dispose, will
		 * dispose all provided disposables.
		 */
    static from(...disposableLikes: { dispose: () => any }[]): Disposable;

		/**
		 * Creates a new Disposable calling the provided function
		 * on dispose.
		 * @param callOnDispose Function that disposes something.
		 */
    constructor(callOnDispose: Function);

		/**
		 * Dispose this object.
		 */
    dispose(): any;
  }

	/**
	 * Represents a typed event.
	 *
	 * A function that represents an event to which you subscribe by calling it with
	 * a listener function as argument.
	 *
	 * @sample `item.onDidChange(function(event) { console.log("Event happened: " + event); });`
	 */
  export interface Event<T> {

		/**
		 * A function that represents an event to which you subscribe by calling it with
		 * a listener function as argument.
		 *
		 * @param listener The listener function will be called when the event happens.
		 * @param thisArgs The `this`-argument which will be used when calling the event listener.
		 * @param disposables An array to which a [disposable](#Disposable) will be added.
		 * @return A disposable which unsubscribes the event listener.
		 */
    (listener: (e: T) => any, thisArgs?: any, disposables?: Disposable[]): Disposable;
  }

	/**
	 * An event emitter can be used to create and manage an [event](#Event) for others
	 * to subscribe to. One emitter always owns one event.
	 *
	 * Use this class if you want to provide event from within your extension, for instance
	 * inside a [TextDocumentContentProvider](#TextDocumentContentProvider) or when providing
	 * API to other extensions.
	 */
  export class EventEmitter<T> {

		/**
		 * The event listeners can subscribe to.
		 */
    event: Event<T>;

		/**
		 * Notify all subscribers of the [event](EventEmitter#event). Failure
		 * of one or more listener will not fail this function call.
		 *
		 * @param data The event object.
		 */
    fire(data?: T): void;

		/**
		 * Dispose this object and free resources.
		 */
    dispose(): void;
  }

	/**
	 * A file system watcher notifies about changes to files and folders
	 * on disk.
	 *
	 * To get an instance of a `FileSystemWatcher` use
	 * [createFileSystemWatcher](#workspace.createFileSystemWatcher).
	 */
  export interface FileSystemWatcher extends Disposable {

		/**
		 * true if this file system watcher has been created such that
		 * it ignores creation file system events.
		 */
    ignoreCreateEvents: boolean;

		/**
		 * true if this file system watcher has been created such that
		 * it ignores change file system events.
		 */
    ignoreChangeEvents: boolean;

		/**
		 * true if this file system watcher has been created such that
		 * it ignores delete file system events.
		 */
    ignoreDeleteEvents: boolean;

		/**
		 * An event which fires on file/folder creation.
		 */
    onDidCreate: Event<Uri>;

		/**
		 * An event which fires on file/folder change.
		 */
    onDidChange: Event<Uri>;

		/**
		 * An event which fires on file/folder deletion.
		 */
    onDidDelete: Event<Uri>;
  }

	/**
	 * A text document content provider allows to add readonly documents
	 * to the editor, such as source from a dll or generated html from md.
	 *
	 * Content providers are [registered](#workspace.registerTextDocumentContentProvider)
	 * for a [uri-scheme](#Uri.scheme). When a uri with that scheme is to
	 * be [loaded](#workspace.openTextDocument) the content provider is
	 * asked.
	 */
  export interface TextDocumentContentProvider {

		/**
		 * An event to signal a resource has changed.
		 */
    onDidChange?: Event<Uri>;

		/**
		 * Provide textual content for a given uri.
		 *
		 * The editor will use the returned string-content to create a readonly
		 * [document](#TextDocument). Resources allocated should be released when
		 * the corresponding document has been [closed](#workspace.onDidCloseTextDocument).
		 *
		 * @param uri An uri which scheme matches the scheme this provider was [registered](#workspace.registerTextDocumentContentProvider) for.
		 * @param token A cancellation token.
		 * @return A string or a thenable that resolves to such.
		 */
    provideTextDocumentContent(uri: Uri, token: CancellationToken): ProviderResult<string>;
  }

	/**
	 * Represents an item that can be selected from
	 * a list of items.
	 */
  export interface QuickPickItem {

		/**
		 * A human readable string which is rendered prominent.
		 */
    label: string;

		/**
		 * A human readable string which is rendered less prominent.
		 */
    description: string;

		/**
		 * A human readable string which is rendered less prominent.
		 */
    detail?: string;
  }

	/**
	 * Options to configure the behavior of the quick pick UI.
	 */
  export interface QuickPickOptions {
		/**
		 * An optional flag to include the description when filtering the picks.
		 */
    matchOnDescription?: boolean;

		/**
		 * An optional flag to include the detail when filtering the picks.
		 */
    matchOnDetail?: boolean;

		/**
		 * An optional string to show as place holder in the input box to guide the user what to pick on.
		 */
    placeHolder?: string;

		/**
		 * Set to `true` to keep the picker open when focus moves to another part of the editor or to another window.
		 */
    ignoreFocusOut?: boolean;

		/**
		 * An optional function that is invoked whenever an item is selected.
		 */
    onDidSelectItem?(item: QuickPickItem | string): any;
  }

	/**
	 * Represents an action that is shown with an information, warning, or
	 * error message.
	 *
	 * @see [showInformationMessage](#window.showInformationMessage)
	 * @see [showWarningMessage](#window.showWarningMessage)
	 * @see [showErrorMessage](#window.showErrorMessage)
	 */
  export interface MessageItem {

		/**
		 * A short title like 'Retry', 'Open Log' etc.
		 */
    title: string;

		/**
		 * Indicates that this item replaces the default
		 * 'Close' action.
		 */
    isCloseAffordance?: boolean;
  }

	/**
	 * Options to configure the behavior of the message.
	 *
	 * @see [showInformationMessage](#window.showInformationMessage)
	 * @see [showWarningMessage](#window.showWarningMessage)
	 * @see [showErrorMessage](#window.showErrorMessage)
	 */
  export interface MessageOptions {

		/**
		 * Indicates that this message should be modal.
		 */
    modal?: boolean;
  }

	/**
	 * Options to configure the behavior of the input box UI.
	 */
  export interface InputBoxOptions {

		/**
		 * The value to prefill in the input box.
		 */
    value?: string;

		/**
		 * Selection of the prefilled [`value`](#InputBoxOptions.value). Defined as tuple of two number where the
		 * first is the inclusive start index and the second the exclusive end index. When `undefined` the whole
		 * word will be selected, when empty (start equals end) only the cursor will be set,
		 * otherwise the defined range will be selected.
		 */
    valueSelection?: [number, number];

		/**
		 * The text to display underneath the input box.
		 */
    prompt?: string;

		/**
		 * An optional string to show as place holder in the input box to guide the user what to type.
		 */
    placeHolder?: string;

		/**
		 * Set to `true` to show a password prompt that will not show the typed value.
		 */
    password?: boolean;

		/**
		 * Set to `true` to keep the input box open when focus moves to another part of the editor or to another window.
		 */
    ignoreFocusOut?: boolean;

		/**
		 * An optional function that will be called to validate input and to give a hint
		 * to the user.
		 *
		 * @param value The current value of the input box.
		 * @return A human readable string which is presented as diagnostic message.
		 * Return `undefined`, `null`, or the empty string when 'value' is valid.
		 */
    validateInput?(value: string): string | undefined | null;
  }

	/**
	 * A document filter denotes a document by different properties like
	 * the [language](#TextDocument.languageId), the [scheme](#Uri.scheme) of
	 * its resource, or a glob-pattern that is applied to the [path](#TextDocument.fileName).
	 *
	 * @sample A language filter that applies to typescript files on disk: `{ language: 'typescript', scheme: 'file' }`
	 * @sample A language filter that applies to all package.json paths: `{ language: 'json', pattern: '**∕package.json' }`
	 */
  export interface DocumentFilter {

		/**
		 * A language id, like `typescript`.
		 */
    language?: string;

		/**
		 * A Uri [scheme](#Uri.scheme), like `file` or `untitled`.
		 */
    scheme?: string;

		/**
		 * A glob pattern, like `*.{ts,js}`.
		 */
    pattern?: string;
  }

	/**
	 * A language selector is the combination of one or many language identifiers
	 * and [language filters](#DocumentFilter).
	 *
	 * @sample `let sel:DocumentSelector = 'typescript'`;
	 * @sample `let sel:DocumentSelector = ['typescript', { language: 'json', pattern: '**∕tsconfig.json' }]`;
	 */
  export type DocumentSelector = string | DocumentFilter | (string | DocumentFilter)[];


	/**
	 * A provider result represents the values a provider, like the [`HoverProvider`](#HoverProvider),
	 * may return. For once this is the actual result type `T`, like `Hover`, or a thenable that resolves
	 * to that type `T`. In addition, `null` and `undefined` can be returned - either directly or from a
	 * thenable.
	 *
	 * The snippets below are all valid implementions of the [`HoverProvider`](#HoverProvider):
	 *
	 * ```ts
	 * let a: HoverProvider = {
	 * 	provideHover(doc, pos, token): ProviderResult<Hover> {
	 * 		return new Hover('Hello World');
	 * 	}
	 * }
	 *
	 * let b: HoverProvider = {
	 * 	provideHover(doc, pos, token): ProviderResult<Hover> {
	 * 		return new Promise(resolve => {
	 * 			resolve(new Hover('Hello World'));
	 * 	 	});
	 * 	}
	 * }
	 *
	 * let c: HoverProvider = {
	 * 	provideHover(doc, pos, token): ProviderResult<Hover> {
	 * 		return; // undefined
	 * 	}
	 * }
	 * ```
	 */
  export type ProviderResult<T> = T | undefined | null | Thenable<T | undefined | null>;

	/**
	 * Contains additional diagnostic information about the context in which
	 * a [code action](#CodeActionProvider.provideCodeActions) is run.
	 */
  export interface CodeActionContext {

		/**
		 * An array of diagnostics.
		 */
    readonly diagnostics: Diagnostic[];
  }

	/**
	 * The code action interface defines the contract between extensions and
	 * the [light bulb](https://code.visualstudio.com/docs/editor/editingevolved#_code-action) feature.
	 *
	 * A code action can be any command that is [known](#commands.getCommands) to the system.
	 */
  export interface CodeActionProvider {

		/**
		 * Provide commands for the given document and range.
		 *
		 * @param document The document in which the command was invoked.
		 * @param range The range for which the command was invoked.
		 * @param context Context carrying additional information.
		 * @param token A cancellation token.
		 * @return An array of commands or a thenable of such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideCodeActions(document: TextDocument, range: Range, context: CodeActionContext, token: CancellationToken): ProviderResult<Command[]>;
  }

	/**
	 * A code lens represents a [command](#Command) that should be shown along with
	 * source text, like the number of references, a way to run tests, etc.
	 *
	 * A code lens is _unresolved_ when no command is associated to it. For performance
	 * reasons the creation of a code lens and resolving should be done to two stages.
	 *
	 * @see [CodeLensProvider.provideCodeLenses](#CodeLensProvider.provideCodeLenses)
	 * @see [CodeLensProvider.resolveCodeLens](#CodeLensProvider.resolveCodeLens)
	 */
  export class CodeLens {

		/**
		 * The range in which this code lens is valid. Should only span a single line.
		 */
    range: Range;

		/**
		 * The command this code lens represents.
		 */
    command?: Command;

		/**
		 * `true` when there is a command associated.
		 */
    readonly isResolved: boolean;

		/**
		 * Creates a new code lens object.
		 *
		 * @param range The range to which this code lens applies.
		 * @param command The command associated to this code lens.
		 */
    constructor(range: Range, command?: Command);
  }

	/**
	 * A code lens provider adds [commands](#Command) to source text. The commands will be shown
	 * as dedicated horizontal lines in between the source text.
	 */
  export interface CodeLensProvider {

		/**
		 * An optional event to signal that the code lenses from this provider have changed.
		 */
    onDidChangeCodeLenses?: Event<void>;

		/**
		 * Compute a list of [lenses](#CodeLens). This call should return as fast as possible and if
		 * computing the commands is expensive implementors should only return code lens objects with the
		 * range set and implement [resolve](#CodeLensProvider.resolveCodeLens).
		 *
		 * @param document The document in which the command was invoked.
		 * @param token A cancellation token.
		 * @return An array of code lenses or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideCodeLenses(document: TextDocument, token: CancellationToken): ProviderResult<CodeLens[]>;

		/**
		 * This function will be called for each visible code lens, usually when scrolling and after
		 * calls to [compute](#CodeLensProvider.provideCodeLenses)-lenses.
		 *
		 * @param codeLens code lens that must be resolved.
		 * @param token A cancellation token.
		 * @return The given, resolved code lens or thenable that resolves to such.
		 */
    resolveCodeLens?(codeLens: CodeLens, token: CancellationToken): ProviderResult<CodeLens>;
  }

	/**
	 * The definition of a symbol represented as one or many [locations](#Location).
	 * For most programming languages there is only one location at which a symbol is
	 * defined.
	 */
  export type Definition = Location | Location[];

	/**
	 * The definition provider interface defines the contract between extensions and
	 * the [go to definition](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-definition)
	 * and peek definition features.
	 */
  export interface DefinitionProvider {

		/**
		 * Provide the definition of the symbol at the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return A definition or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideDefinition(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<Definition>;
  }

	/**
	 * The implemenetation provider interface defines the contract between extensions and
	 * the go to implementation feature.
	 */
  export interface ImplementationProvider {

		/**
		 * Provide the implementations of the symbol at the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return A definition or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideImplementation(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<Definition>;
  }

	/**
	 * The type definition provider defines the contract between extensions and
	 * the go to type definition feature.
	 */
  export interface TypeDefinitionProvider {

		/**
		 * Provide the type definition of the symbol at the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return A definition or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideTypeDefinition(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<Definition>;
  }

	/**
	 * The MarkdownString represents human readable text that supports formatting via the
	 * markdown syntax. Standard markdown is supported, also tables, but no embedded html.
	 */
  export class MarkdownString {

		/**
		 * The markdown string.
		 */
    value: string;

		/**
		 * Indicates that this markdown string is from a trusted source. Only *trusted*
		 * markdown supports links that execute commands, e.g. `[Run it](command:myCommandId)`.
		 */
    isTrusted?: boolean;

		/**
		 * Creates a new markdown string with the given value.
		 *
		 * @param value Optional, initial value.
		 */
    constructor(value?: string);

		/**
		 * Appends and escapes the given string to this markdown string.
		 * @param value Plain text.
		 */
    appendText(value: string): MarkdownString;

		/**
		 * Appends the given string 'as is' to this markdown string.
		 * @param value Markdown string.
		 */
    appendMarkdown(value: string): MarkdownString;
  }

	/**
	 * ~~MarkedString can be used to render human readable text. It is either a markdown string
	 * or a code-block that provides a language and a code snippet. Note that
	 * markdown strings will be sanitized - that means html will be escaped.~~
	 *
	 * @deprecated This type is deprecated, please use [`MarkdownString`](#MarkdownString) instead.
	 */
  export type MarkedString = MarkdownString | string | { language: string; value: string };

	/**
	 * A hover represents additional information for a symbol or word. Hovers are
	 * rendered in a tooltip-like widget.
	 */
  export class Hover {

		/**
		 * The contents of this hover.
		 */
    contents: MarkedString[];

		/**
		 * The range to which this hover applies. When missing, the
		 * editor will use the range at the current position or the
		 * current position itself.
		 */
    range?: Range;

		/**
		 * Creates a new hover object.
		 *
		 * @param contents The contents of the hover.
		 * @param range The range to which the hover applies.
		 */
    constructor(contents: MarkedString | MarkedString[], range?: Range);
  }

	/**
	 * The hover provider interface defines the contract between extensions and
	 * the [hover](https://code.visualstudio.com/docs/editor/intellisense)-feature.
	 */
  export interface HoverProvider {

		/**
		 * Provide a hover for the given position and document. Multiple hovers at the same
		 * position will be merged by the editor. A hover can have a range which defaults
		 * to the word range at the position when omitted.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return A hover or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideHover(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<Hover>;
  }

	/**
	 * A document highlight kind.
	 */
  export enum DocumentHighlightKind {

		/**
		 * A textual occurrence.
		 */
    Text = 0,

		/**
		 * Read-access of a symbol, like reading a variable.
		 */
    Read = 1,

		/**
		 * Write-access of a symbol, like writing to a variable.
		 */
    Write = 2
  }

	/**
	 * A document highlight is a range inside a text document which deserves
	 * special attention. Usually a document highlight is visualized by changing
	 * the background color of its range.
	 */
  export class DocumentHighlight {

		/**
		 * The range this highlight applies to.
		 */
    range: Range;

		/**
		 * The highlight kind, default is [text](#DocumentHighlightKind.Text).
		 */
    kind?: DocumentHighlightKind;

		/**
		 * Creates a new document highlight object.
		 *
		 * @param range The range the highlight applies to.
		 * @param kind The highlight kind, default is [text](#DocumentHighlightKind.Text).
		 */
    constructor(range: Range, kind?: DocumentHighlightKind);
  }

	/**
	 * The document highlight provider interface defines the contract between extensions and
	 * the word-highlight-feature.
	 */
  export interface DocumentHighlightProvider {

		/**
		 * Provide a set of document highlights, like all occurrences of a variable or
		 * all exit-points of a function.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return An array of document highlights or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideDocumentHighlights(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<DocumentHighlight[]>;
  }

	/**
	 * A symbol kind.
	 */
  export enum SymbolKind {
    File = 0,
    Module = 1,
    Namespace = 2,
    Package = 3,
    Class = 4,
    Method = 5,
    Property = 6,
    Field = 7,
    Constructor = 8,
    Enum = 9,
    Interface = 10,
    Function = 11,
    Variable = 12,
    Constant = 13,
    String = 14,
    Number = 15,
    Boolean = 16,
    Array = 17,
    Object = 18,
    Key = 19,
    Null = 20,
    EnumMember = 21,
    Struct = 22,
    Event = 23,
    Operator = 24,
    TypeParameter = 25
  }

	/**
	 * Represents information about programming constructs like variables, classes,
	 * interfaces etc.
	 */
  export class SymbolInformation {

		/**
		 * The name of this symbol.
		 */
    name: string;

		/**
		 * The name of the symbol containing this symbol.
		 */
    containerName: string;

		/**
		 * The kind of this symbol.
		 */
    kind: SymbolKind;

		/**
		 * The location of this symbol.
		 */
    location: Location;

		/**
		 * Creates a new symbol information object.
		 *
		 * @param name The name of the symbol.
		 * @param kind The kind of the symbol.
		 * @param containerName The name of the symbol containing the symbol.
		 * @param location The the location of the symbol.
		 */
    constructor(name: string, kind: SymbolKind, containerName: string, location: Location);

		/**
		 * ~~Creates a new symbol information object.~~
		 *
		 * @deprecated Please use the constructor taking a [location](#Location) object.
		 *
		 * @param name The name of the symbol.
		 * @param kind The kind of the symbol.
		 * @param range The range of the location of the symbol.
		 * @param uri The resource of the location of symbol, defaults to the current document.
		 * @param containerName The name of the symbol containing the symbol.
		 */
    constructor(name: string, kind: SymbolKind, range: Range, uri?: Uri, containerName?: string);
  }

	/**
	 * The document symbol provider interface defines the contract between extensions and
	 * the [go to symbol](https://code.visualstudio.com/docs/editor/editingevolved#_go-to-symbol)-feature.
	 */
  export interface DocumentSymbolProvider {

		/**
		 * Provide symbol information for the given document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param token A cancellation token.
		 * @return An array of document highlights or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideDocumentSymbols(document: TextDocument, token: CancellationToken): ProviderResult<SymbolInformation[]>;
  }

	/**
	 * The workspace symbol provider interface defines the contract between extensions and
	 * the [symbol search](https://code.visualstudio.com/docs/editor/editingevolved#_open-symbol-by-name)-feature.
	 */
  export interface WorkspaceSymbolProvider {

		/**
		 * Project-wide search for a symbol matching the given query string. It is up to the provider
		 * how to search given the query string, like substring, indexOf etc. To improve performance implementors can
		 * skip the [location](#SymbolInformation.location) of symbols and implement `resolveWorkspaceSymbol` to do that
		 * later.
		 *
		 * @param query A non-empty query string.
		 * @param token A cancellation token.
		 * @return An array of document highlights or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideWorkspaceSymbols(query: string, token: CancellationToken): ProviderResult<SymbolInformation[]>;

		/**
		 * Given a symbol fill in its [location](#SymbolInformation.location). This method is called whenever a symbol
		 * is selected in the UI. Providers can implement this method and return incomplete symbols from
		 * [`provideWorkspaceSymbols`](#WorkspaceSymbolProvider.provideWorkspaceSymbols) which often helps to improve
		 * performance.
		 *
		 * @param symbol The symbol that is to be resolved. Guaranteed to be an instance of an object returned from an
		 * earlier call to `provideWorkspaceSymbols`.
		 * @param token A cancellation token.
		 * @return The resolved symbol or a thenable that resolves to that. When no result is returned,
		 * the given `symbol` is used.
		 */
    resolveWorkspaceSymbol?(symbol: SymbolInformation, token: CancellationToken): ProviderResult<SymbolInformation>;
  }

	/**
	 * Value-object that contains additional information when
	 * requesting references.
	 */
  export interface ReferenceContext {

		/**
		 * Include the declaration of the current symbol.
		 */
    includeDeclaration: boolean;
  }

	/**
	 * The reference provider interface defines the contract between extensions and
	 * the [find references](https://code.visualstudio.com/docs/editor/editingevolved#_peek)-feature.
	 */
  export interface ReferenceProvider {

		/**
		 * Provide a set of project-wide references for the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param context
		 * @param token A cancellation token.
		 * @return An array of locations or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideReferences(document: TextDocument, position: Position, context: ReferenceContext, token: CancellationToken): ProviderResult<Location[]>;
  }

	/**
	 * A text edit represents edits that should be applied
	 * to a document.
	 */
  export class TextEdit {

		/**
		 * Utility to create a replace edit.
		 *
		 * @param range A range.
		 * @param newText A string.
		 * @return A new text edit object.
		 */
    static replace(range: Range, newText: string): TextEdit;

		/**
		 * Utility to create an insert edit.
		 *
		 * @param position A position, will become an empty range.
		 * @param newText A string.
		 * @return A new text edit object.
		 */
    static insert(position: Position, newText: string): TextEdit;

		/**
		 * Utility to create a delete edit.
		 *
		 * @param range A range.
		 * @return A new text edit object.
		 */
    static delete(range: Range): TextEdit;

		/**
		 * Utility to create an eol-edit.
		 *
		 * @param eol An eol-sequence
		 * @return A new text edit object.
		 */
    static setEndOfLine(eol: EndOfLine): TextEdit;

		/**
		 * The range this edit applies to.
		 */
    range: Range;

		/**
		 * The string this edit will insert.
		 */
    newText: string;

		/**
		 * The eol-sequence used in the document.
		 *
		 * *Note* that the eol-sequence will be applied to the
		 * whole document.
		 */
    newEol: EndOfLine;

		/**
		 * Create a new TextEdit.
		 *
		 * @param range A range.
		 * @param newText A string.
		 */
    constructor(range: Range, newText: string);
  }

	/**
	 * A workspace edit represents textual changes for many documents.
	 */
  export class WorkspaceEdit {

		/**
		 * The number of affected resources.
		 */
    readonly size: number;

		/**
		 * Replace the given range with given text for the given resource.
		 *
		 * @param uri A resource identifier.
		 * @param range A range.
		 * @param newText A string.
		 */
    replace(uri: Uri, range: Range, newText: string): void;

		/**
		 * Insert the given text at the given position.
		 *
		 * @param uri A resource identifier.
		 * @param position A position.
		 * @param newText A string.
		 */
    insert(uri: Uri, position: Position, newText: string): void;

		/**
		 * Delete the text at the given range.
		 *
		 * @param uri A resource identifier.
		 * @param range A range.
		 */
    delete(uri: Uri, range: Range): void;

		/**
		 * Check if this edit affects the given resource.
		 * @param uri A resource identifier.
		 * @return `true` if the given resource will be touched by this edit.
		 */
    has(uri: Uri): boolean;

		/**
		 * Set (and replace) text edits for a resource.
		 *
		 * @param uri A resource identifier.
		 * @param edits An array of text edits.
		 */
    set(uri: Uri, edits: TextEdit[]): void;

		/**
		 * Get the text edits for a resource.
		 *
		 * @param uri A resource identifier.
		 * @return An array of text edits.
		 */
    get(uri: Uri): TextEdit[];

		/**
		 * Get all text edits grouped by resource.
		 *
		 * @return An array of `[Uri, TextEdit[]]`-tuples.
		 */
    entries(): [Uri, TextEdit[]][];
  }

	/**
	 * A snippet string is a template which allows to insert text
	 * and to control the editor cursor when insertion happens.
	 *
	 * A snippet can define tab stops and placeholders with `$1`, `$2`
	 * and `${3:foo}`. `$0` defines the final tab stop, it defaults to
	 * the end of the snippet. Variables are defined with `$name` and
	 * `${name:default value}`. The full snippet syntax is documented
	 * [here](http://code.visualstudio.com/docs/editor/userdefinedsnippets#_creating-your-own-snippets).
	 */
  export class SnippetString {

		/**
		 * The snippet string.
		 */
    value: string;

    constructor(value?: string);

		/**
		 * Builder-function that appends the given string to
		 * the [`value`](#SnippetString.value) of this snippet string.
		 *
		 * @param string A value to append 'as given'. The string will be escaped.
		 * @return This snippet string.
		 */
    appendText(string: string): SnippetString;

		/**
		 * Builder-function that appends a tabstop (`$1`, `$2` etc) to
		 * the [`value`](#SnippetString.value) of this snippet string.
		 *
		 * @param number The number of this tabstop, defaults to an auto-incremet
		 * value starting at 1.
		 * @return This snippet string.
		 */
    appendTabstop(number?: number): SnippetString;

		/**
		 * Builder-function that appends a placeholder (`${1:value}`) to
		 * the [`value`](#SnippetString.value) of this snippet string.
		 *
		 * @param value The value of this placeholder - either a string or a function
		 * with which a nested snippet can be created.
		 * @param number The number of this tabstop, defaults to an auto-incremet
		 * value starting at 1.
		 * @return This snippet string.
		 */
    appendPlaceholder(value: string | ((snippet: SnippetString) => any), number?: number): SnippetString;

		/**
		 * Builder-function that appends a variable (`${VAR}`) to
		 * the [`value`](#SnippetString.value) of this snippet string.
		 *
		 * @param name The name of the variable - excluding the `$`.
		 * @param defaultValue The default value which is used when the variable name cannot
		 * be resolved - either a string or a function with which a nested snippet can be created.
		 * @return This snippet string.
		 */
    appendVariable(name: string, defaultValue: string | ((snippet: SnippetString) => any)): SnippetString;
  }

	/**
	 * The rename provider interface defines the contract between extensions and
	 * the [rename](https://code.visualstudio.com/docs/editor/editingevolved#_rename-symbol)-feature.
	 */
  export interface RenameProvider {

		/**
		 * Provide an edit that describes changes that have to be made to one
		 * or many resources to rename a symbol to a different name.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param newName The new name of the symbol. If the given name is not valid, the provider must return a rejected promise.
		 * @param token A cancellation token.
		 * @return A workspace edit or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideRenameEdits(document: TextDocument, position: Position, newName: string, token: CancellationToken): ProviderResult<WorkspaceEdit>;
  }

	/**
	 * Value-object describing what options formatting should use.
	 */
  export interface FormattingOptions {

		/**
		 * Size of a tab in spaces.
		 */
    tabSize: number;

		/**
		 * Prefer spaces over tabs.
		 */
    insertSpaces: boolean;

		/**
		 * Signature for further properties.
		 */
    [key: string]: boolean | number | string;
  }

	/**
	 * The document formatting provider interface defines the contract between extensions and
	 * the formatting-feature.
	 */
  export interface DocumentFormattingEditProvider {

		/**
		 * Provide formatting edits for a whole document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param options Options controlling formatting.
		 * @param token A cancellation token.
		 * @return A set of text edits or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideDocumentFormattingEdits(document: TextDocument, options: FormattingOptions, token: CancellationToken): ProviderResult<TextEdit[]>;
  }

	/**
	 * The document formatting provider interface defines the contract between extensions and
	 * the formatting-feature.
	 */
  export interface DocumentRangeFormattingEditProvider {

		/**
		 * Provide formatting edits for a range in a document.
		 *
		 * The given range is a hint and providers can decide to format a smaller
		 * or larger range. Often this is done by adjusting the start and end
		 * of the range to full syntax nodes.
		 *
		 * @param document The document in which the command was invoked.
		 * @param range The range which should be formatted.
		 * @param options Options controlling formatting.
		 * @param token A cancellation token.
		 * @return A set of text edits or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideDocumentRangeFormattingEdits(document: TextDocument, range: Range, options: FormattingOptions, token: CancellationToken): ProviderResult<TextEdit[]>;
  }

	/**
	 * The document formatting provider interface defines the contract between extensions and
	 * the formatting-feature.
	 */
  export interface OnTypeFormattingEditProvider {

		/**
		 * Provide formatting edits after a character has been typed.
		 *
		 * The given position and character should hint to the provider
		 * what range the position to expand to, like find the matching `{`
		 * when `}` has been entered.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param ch The character that has been typed.
		 * @param options Options controlling formatting.
		 * @param token A cancellation token.
		 * @return A set of text edits or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideOnTypeFormattingEdits(document: TextDocument, position: Position, ch: string, options: FormattingOptions, token: CancellationToken): ProviderResult<TextEdit[]>;
  }

	/**
	 * Represents a parameter of a callable-signature. A parameter can
	 * have a label and a doc-comment.
	 */
  export class ParameterInformation {

		/**
		 * The label of this signature. Will be shown in
		 * the UI.
		 */
    label: string;

		/**
		 * The human-readable doc-comment of this signature. Will be shown
		 * in the UI but can be omitted.
		 */
    documentation?: string;

		/**
		 * Creates a new parameter information object.
		 *
		 * @param label A label string.
		 * @param documentation A doc string.
		 */
    constructor(label: string, documentation?: string);
  }

	/**
	 * Represents the signature of something callable. A signature
	 * can have a label, like a function-name, a doc-comment, and
	 * a set of parameters.
	 */
  export class SignatureInformation {

		/**
		 * The label of this signature. Will be shown in
		 * the UI.
		 */
    label: string;

		/**
		 * The human-readable doc-comment of this signature. Will be shown
		 * in the UI but can be omitted.
		 */
    documentation?: string;

		/**
		 * The parameters of this signature.
		 */
    parameters: ParameterInformation[];

		/**
		 * Creates a new signature information object.
		 *
		 * @param label A label string.
		 * @param documentation A doc string.
		 */
    constructor(label: string, documentation?: string);
  }

	/**
	 * Signature help represents the signature of something
	 * callable. There can be multiple signatures but only one
	 * active and only one active parameter.
	 */
  export class SignatureHelp {

		/**
		 * One or more signatures.
		 */
    signatures: SignatureInformation[];

		/**
		 * The active signature.
		 */
    activeSignature: number;

		/**
		 * The active parameter of the active signature.
		 */
    activeParameter: number;
  }

	/**
	 * The signature help provider interface defines the contract between extensions and
	 * the [parameter hints](https://code.visualstudio.com/docs/editor/intellisense)-feature.
	 */
  export interface SignatureHelpProvider {

		/**
		 * Provide help for the signature at the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return Signature help or a thenable that resolves to such. The lack of a result can be
		 * signaled by returning `undefined` or `null`.
		 */
    provideSignatureHelp(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<SignatureHelp>;
  }

	/**
	 * Completion item kinds.
	 */
  export enum CompletionItemKind {
    Text = 0,
    Method = 1,
    Function = 2,
    Constructor = 3,
    Field = 4,
    Variable = 5,
    Class = 6,
    Interface = 7,
    Module = 8,
    Property = 9,
    Unit = 10,
    Value = 11,
    Enum = 12,
    Keyword = 13,
    Snippet = 14,
    Color = 15,
    Reference = 17,
    File = 16,
    Folder = 18,
    EnumMember = 19,
    Constant = 20,
    Struct = 21,
    Event = 22,
    Operator = 23,
    TypeParameter = 24
  }

	/**
	 * A completion item represents a text snippet that is proposed to complete text that is being typed.
	 *
	 * It is suffient to create a completion item from just a [label](#CompletionItem.label). In that
	 * case the completion item will replace the [word](#TextDocument.getWordRangeAtPosition)
	 * until the cursor with the given label or [insertText](#CompletionItem.insertText). Otherwise the
	 * the given [edit](#CompletionItem.textEdit) is used.
	 *
	 * When selecting a completion item in the editor its defined or synthesized text edit will be applied
	 * to *all* cursors/selections whereas [additionalTextEdits](CompletionItem.additionalTextEdits) will be
	 * applied as provided.
	 *
	 * @see [CompletionItemProvider.provideCompletionItems](#CompletionItemProvider.provideCompletionItems)
	 * @see [CompletionItemProvider.resolveCompletionItem](#CompletionItemProvider.resolveCompletionItem)
	 */
  export class CompletionItem {

		/**
		 * The label of this completion item. By default
		 * this is also the text that is inserted when selecting
		 * this completion.
		 */
    label: string;

		/**
		 * The kind of this completion item. Based on the kind
		 * an icon is chosen by the editor.
		 */
    kind?: CompletionItemKind;

		/**
		 * A human-readable string with additional information
		 * about this item, like type or symbol information.
		 */
    detail?: string;

		/**
		 * A human-readable string that represents a doc-comment.
		 */
    documentation?: string;

		/**
		 * A string that should be used when comparing this item
		 * with other items. When `falsy` the [label](#CompletionItem.label)
		 * is used.
		 */
    sortText?: string;

		/**
		 * A string that should be used when filtering a set of
		 * completion items. When `falsy` the [label](#CompletionItem.label)
		 * is used.
		 */
    filterText?: string;

		/**
		 * A string or snippet that should be inserted in a document when selecting
		 * this completion. When `falsy` the [label](#CompletionItem.label)
		 * is used.
		 */
    insertText?: string | SnippetString;

		/**
		 * A range of text that should be replaced by this completion item.
		 *
		 * Defaults to a range from the start of the [current word](#TextDocument.getWordRangeAtPosition) to the
		 * current position.
		 *
		 * *Note:* The range must be a [single line](#Range.isSingleLine) and it must
		 * [contain](#Range.contains) the position at which completion has been [requested](#CompletionItemProvider.provideCompletionItems).
		 */
    range?: Range;

		/**
		 * An optional set of characters that when pressed while this completion is active will accept it first and
		 * then type that character. *Note* that all commit characters should have `length=1` and that superfluous
		 * characters will be ignored.
		 */
    commitCharacters?: string[];

		/**
		 * @deprecated Use `CompletionItem.insertText` and `CompletionItem.range` instead.
		 *
		 * ~~An [edit](#TextEdit) which is applied to a document when selecting
		 * this completion. When an edit is provided the value of
		 * [insertText](#CompletionItem.insertText) is ignored.~~
		 *
		 * ~~The [range](#Range) of the edit must be single-line and on the same
		 * line completions were [requested](#CompletionItemProvider.provideCompletionItems) at.~~
		 */
    textEdit?: TextEdit;

		/**
		 * An optional array of additional [text edits](#TextEdit) that are applied when
		 * selecting this completion. Edits must not overlap with the main [edit](#CompletionItem.textEdit)
		 * nor with themselves.
		 */
    additionalTextEdits?: TextEdit[];

		/**
		 * An optional [command](#Command) that is executed *after* inserting this completion. *Note* that
		 * additional modifications to the current document should be described with the
		 * [additionalTextEdits](#CompletionItem.additionalTextEdits)-property.
		 */
    command?: Command;

		/**
		 * Creates a new completion item.
		 *
		 * Completion items must have at least a [label](#CompletionItem.label) which then
		 * will be used as insert text as well as for sorting and filtering.
		 *
		 * @param label The label of the completion.
		 * @param kind The [kind](#CompletionItemKind) of the completion.
		 */
    constructor(label: string, kind?: CompletionItemKind);
  }

	/**
	 * Represents a collection of [completion items](#CompletionItem) to be presented
	 * in the editor.
	 */
  export class CompletionList {

		/**
		 * This list it not complete. Further typing should result in recomputing
		 * this list.
		 */
    isIncomplete?: boolean;

		/**
		 * The completion items.
		 */
    items: CompletionItem[];

		/**
		 * Creates a new completion list.
		 *
		 * @param items The completion items.
		 * @param isIncomplete The list is not complete.
		 */
    constructor(items?: CompletionItem[], isIncomplete?: boolean);
  }

	/**
	 * The completion item provider interface defines the contract between extensions and
	 * [IntelliSense](https://code.visualstudio.com/docs/editor/intellisense).
	 *
	 * When computing *complete* completion items is expensive, providers can optionally implement
	 * the `resolveCompletionItem`-function. In that case it is enough to return completion
	 * items with a [label](#CompletionItem.label) from the
	 * [provideCompletionItems](#CompletionItemProvider.provideCompletionItems)-function. Subsequently,
	 * when a completion item is shown in the UI and gains focus this provider is asked to resolve
	 * the item, like adding [doc-comment](#CompletionItem.documentation) or [details](#CompletionItem.detail).
	 *
	 * Providers are asked for completions either explicitly by a user gesture or -depending on the configuration-
	 * implicitly when typing words or trigger characters.
	 */
  export interface CompletionItemProvider {

		/**
		 * Provide completion items for the given position and document.
		 *
		 * @param document The document in which the command was invoked.
		 * @param position The position at which the command was invoked.
		 * @param token A cancellation token.
		 * @return An array of completions, a [completion list](#CompletionList), or a thenable that resolves to either.
		 * The lack of a result can be signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideCompletionItems(document: TextDocument, position: Position, token: CancellationToken): ProviderResult<CompletionItem[] | CompletionList>;

		/**
		 * Given a completion item fill in more data, like [doc-comment](#CompletionItem.documentation)
		 * or [details](#CompletionItem.detail).
		 *
		 * The editor will only resolve a completion item once.
		 *
		 * @param item A completion item currently active in the UI.
		 * @param token A cancellation token.
		 * @return The resolved completion item or a thenable that resolves to of such. It is OK to return the given
		 * `item`. When no result is returned, the given `item` will be used.
		 */
    resolveCompletionItem?(item: CompletionItem, token: CancellationToken): ProviderResult<CompletionItem>;
  }


	/**
	 * A document link is a range in a text document that links to an internal or external resource, like another
	 * text document or a web site.
	 */
  export class DocumentLink {

		/**
		 * The range this link applies to.
		 */
    range: Range;

		/**
		 * The uri this link points to.
		 */
    target?: Uri;

		/**
		 * Creates a new document link.
		 *
		 * @param range The range the document link applies to. Must not be empty.
		 * @param target The uri the document link points to.
		 */
    constructor(range: Range, target?: Uri);
  }

	/**
	 * The document link provider defines the contract between extensions and feature of showing
	 * links in the editor.
	 */
  export interface DocumentLinkProvider {

		/**
		 * Provide links for the given document. Note that the editor ships with a default provider that detects
		 * `http(s)` and `file` links.
		 *
		 * @param document The document in which the command was invoked.
		 * @param token A cancellation token.
		 * @return An array of [document links](#DocumentLink) or a thenable that resolves to such. The lack of a result
		 * can be signaled by returning `undefined`, `null`, or an empty array.
		 */
    provideDocumentLinks(document: TextDocument, token: CancellationToken): ProviderResult<DocumentLink[]>;

		/**
		 * Given a link fill in its [target](#DocumentLink.target). This method is called when an incomplete
		 * link is selected in the UI. Providers can implement this method and return incomple links
		 * (without target) from the [`provideDocumentLinks`](#DocumentLinkProvider.provideDocumentLinks) method which
		 * often helps to improve performance.
		 *
		 * @param link The link that is to be resolved.
		 * @param token A cancellation token.
		 */
    resolveDocumentLink?(link: DocumentLink, token: CancellationToken): ProviderResult<DocumentLink>;
  }

	/**
	 * A tuple of two characters, like a pair of
	 * opening and closing brackets.
	 */
  export type CharacterPair = [string, string];

	/**
	 * Describes how comments for a language work.
	 */
  export interface CommentRule {

		/**
		 * The line comment token, like `// this is a comment`
		 */
    lineComment?: string;

		/**
		 * The block comment character pair, like `/* block comment *&#47;`
		 */
    blockComment?: CharacterPair;
  }

	/**
	 * Describes indentation rules for a language.
	 */
  export interface IndentationRule {
		/**
		 * If a line matches this pattern, then all the lines after it should be unindendented once (until another rule matches).
		 */
    decreaseIndentPattern: RegExp;
		/**
		 * If a line matches this pattern, then all the lines after it should be indented once (until another rule matches).
		 */
    increaseIndentPattern: RegExp;
		/**
		 * If a line matches this pattern, then **only the next line** after it should be indented once.
		 */
    indentNextLinePattern?: RegExp;
		/**
		 * If a line matches this pattern, then its indentation should not be changed and it should not be evaluated against the other rules.
		 */
    unIndentedLinePattern?: RegExp;
  }

	/**
	 * Describes what to do with the indentation when pressing Enter.
	 */
  export enum IndentAction {
		/**
		 * Insert new line and copy the previous line's indentation.
		 */
    None = 0,
		/**
		 * Insert new line and indent once (relative to the previous line's indentation).
		 */
    Indent = 1,
		/**
		 * Insert two new lines:
		 *  - the first one indented which will hold the cursor
		 *  - the second one at the same indentation level
		 */
    IndentOutdent = 2,
		/**
		 * Insert new line and outdent once (relative to the previous line's indentation).
		 */
    Outdent = 3
  }

	/**
	 * Describes what to do when pressing Enter.
	 */
  export interface EnterAction {
		/**
		 * Describe what to do with the indentation.
		 */
    indentAction: IndentAction;
		/**
		 * Describes text to be appended after the new line and after the indentation.
		 */
    appendText?: string;
		/**
		 * Describes the number of characters to remove from the new line's indentation.
		 */
    removeText?: number;
  }

	/**
	 * Describes a rule to be evaluated when pressing Enter.
	 */
  export interface OnEnterRule {
		/**
		 * This rule will only execute if the text before the cursor matches this regular expression.
		 */
    beforeText: RegExp;
		/**
		 * This rule will only execute if the text after the cursor matches this regular expression.
		 */
    afterText?: RegExp;
		/**
		 * The action to execute.
		 */
    action: EnterAction;
  }

	/**
	 * The language configuration interfaces defines the contract between extensions
	 * and various editor features, like automatic bracket insertion, automatic indentation etc.
	 */
  export interface LanguageConfiguration {
		/**
		 * The language's comment settings.
		 */
    comments?: CommentRule;
		/**
		 * The language's brackets.
		 * This configuration implicitly affects pressing Enter around these brackets.
		 */
    brackets?: CharacterPair[];
		/**
		 * The language's word definition.
		 * If the language supports Unicode identifiers (e.g. JavaScript), it is preferable
		 * to provide a word definition that uses exclusion of known separators.
		 * e.g.: A regex that matches anything except known separators (and dot is allowed to occur in a floating point number):
		 *   /(-?\d*\.\d\w*)|([^\`\~\!\@\#\%\^\&\*\(\)\-\=\+\[\{\]\}\\\|\;\:\'\"\,\.\<\>\/\?\s]+)/g
		 */
    wordPattern?: RegExp;
		/**
		 * The language's indentation settings.
		 */
    indentationRules?: IndentationRule;
		/**
		 * The language's rules to be evaluated when pressing Enter.
		 */
    onEnterRules?: OnEnterRule[];

		/**
		 * **Deprecated** Do not use.
		 *
		 * @deprecated Will be replaced by a better API soon.
		 */
    __electricCharacterSupport?: {
			/**
			 * This property is deprecated and will be **ignored** from
			 * the editor.
			 * @deprecated
			 */
      brackets?: any;
			/**
			 * This property is deprecated and not fully supported anymore by
			 * the editor (scope and lineStart are ignored).
			 * Use the the autoClosingPairs property in the language configuration file instead.
			 * @deprecated
			 */
      docComment?: {
        scope: string;
        open: string;
        lineStart: string;
        close?: string;
      };
    };

		/**
		 * **Deprecated** Do not use.
		 *
		 * @deprecated * Use the the autoClosingPairs property in the language configuration file instead.
		 */
    __characterPairSupport?: {
      autoClosingPairs: {
        open: string;
        close: string;
        notIn?: string[];
      }[];
    };
  }

	/**
	 * The configuration target
	 */
  export enum ConfigurationTarget {
		/**
		 * Global configuration
		*/
    Global = 1,

		/**
		 * Workspace configuration
		 */
    Workspace = 2,

		/**
		 * Workspace folder configuration
		 */
    WorkspaceFolder = 3
  }

	/**
	 * Represents the configuration. It is a merged view of
	 *
	 * - Default configuration
	 * - Global configuration
	 * - Workspace configuration (if available)
	 * - Workspace folder configuration of the requested resource (if available)
	 *
	 * *Global configuration* comes from User Settings and shadows Defaults.
	 *
	 * *Workspace configuration* comes from Workspace Settings and shadows Global configuration.
	 *
	 * *Workspace Folder configuration* comes from `.vscode` folder under one of the [workspace folders](#workspace.workspaceFolders).
	 *
	 * *Note:* Workspace and Workspace Folder configurations contains `launch` and `tasks` settings. Their basename will be
	 * part of the section identifier. The following snippets shows how to retrieve all configurations
	 * from `launch.json`:
	 *
	 * ```ts
	 * // launch.json configuration
	 * const config = workspace.getConfiguration('launch', vscode.window.activeTextEditor.document.uri);
	 *
	 * // retrieve values
	 * const values = config.get('configurations');
	 * ```
	 *
	 * Refer to [Settings](https://code.visualstudio.com/docs/getstarted/settings) for more information.
	 */
  export interface WorkspaceConfiguration {

		/**
		 * Return a value from this configuration.
		 *
		 * @param section Configuration name, supports _dotted_ names.
		 * @return The value `section` denotes or `undefined`.
		 */
    get<T>(section: string): T | undefined;

		/**
		 * Return a value from this configuration.
		 *
		 * @param section Configuration name, supports _dotted_ names.
		 * @param defaultValue A value should be returned when no value could be found, is `undefined`.
		 * @return The value `section` denotes or the default.
		 */
    get<T>(section: string, defaultValue: T): T;

		/**
		 * Check if this configuration has a certain value.
		 *
		 * @param section Configuration name, supports _dotted_ names.
		 * @return `true` if the section doesn't resolve to `undefined`.
		 */
    has(section: string): boolean;

		/**
		 * Retrieve all information about a configuration setting. A configuration value
		 * often consists of a *default* value, a global or installation-wide value,
		 * a workspace-specific value and a folder-specific value.
		 *
		 * The *effective* value (returned by [`get`](#WorkspaceConfiguration.get))
		 * is computed like this: `defaultValue` overwritten by `globalValue`,
		 * `globalValue` overwritten by `workspaceValue`. `workspaceValue` overwritten by `workspaceFolderValue`.
		 * Refer to [Settings Inheritence](https://code.visualstudio.com/docs/getstarted/settings)
		 * for more information.
		 *
		 * *Note:* The configuration name must denote a leaf in the configuration tree
		 * (`editor.fontSize` vs `editor`) otherwise no result is returned.
		 *
		 * @param section Configuration name, supports _dotted_ names.
		 * @return Information about a configuration setting or `undefined`.
		 */
    inspect<T>(section: string): { key: string; defaultValue?: T; globalValue?: T; workspaceValue?: T, workspaceFolderValue?: T } | undefined;

		/**
		 * Update a configuration value. The updated configuration values are persisted.
		 *
		 * A value can be changed in
		 *
		 * - [Global configuration](#ConfigurationTarget.Global): Changes the value for all instances of the editor.
		 * - [Workspace configuration](#ConfigurationTarget.Workspace): Changes the value for current workspace, if available.
		 * - [Workspace folder configuration](#ConfigurationTarget.WorkspaceFolder): Changes the value for the
		 * [Workspace folder](#workspace.workspaceFolders) to which the current [configuration](#WorkspaceConfiguration) is scoped to.
		 *
		 * *Note 1:* Setting a global value in the presence of a more specific workspace value
		 * has no observable effect in that workspace, but in others. Setting a workspace value
		 * in the presence of a more specific folder value has no observable effect for the resources
		 * under respective [folder](#workspace.workspaceFolders), but in others. Refer to
		 * [Settings Inheritence](https://code.visualstudio.com/docs/getstarted/settings) for more information.
		 *
		 * *Note 2:* To remove a configuration value use `undefined`, like so: `config.update('somekey', undefined)`
		 *
		 * Will throw error when
		 * - Writing a configuration which is not registered.
		 * - Writing a configuration to workspace or folder target when no workspace is opened
		 * - Writing a configuration to folder target when there is no folder settings
		 * - Writing to folder target without passing a resource when getting the configuration (`workspace.getConfiguration(section, resource)`)
		 * - Writing a window configuration to folder target
		 *
		 * @param section Configuration name, supports _dotted_ names.
		 * @param value The new value.
		 * @param configurationTarget The [configuration target](#ConfigurationTarget) or a boolean value.
		 *	- If `true` configuration target is `ConfigurationTarget.Global`.
		 *	- If `false` configuration target is `ConfigurationTarget.Workspace`.
		 *	- If `undefined` or `null` configuration target is
		 *	`ConfigurationTarget.WorkspaceFolder` when configuration is resource specific
		 *	`ConfigurationTarget.Workspace` otherwise.
		 */
    update(section: string, value: any, configurationTarget?: ConfigurationTarget | boolean): Thenable<void>;

		/**
		 * Readable dictionary that backs this configuration.
		 */
    readonly [key: string]: any;
  }

	/**
	 * Represents a location inside a resource, such as a line
	 * inside a text file.
	 */
  export class Location {

		/**
		 * The resource identifier of this location.
		 */
    uri: Uri;

		/**
		 * The document range of this locations.
		 */
    range: Range;

		/**
		 * Creates a new location object.
		 *
		 * @param uri The resource identifier.
		 * @param rangeOrPosition The range or position. Positions will be converted to an empty range.
		 */
    constructor(uri: Uri, rangeOrPosition: Range | Position);
  }

	/**
	 * Represents the severity of diagnostics.
	 */
  export enum DiagnosticSeverity {

		/**
		 * Something not allowed by the rules of a language or other means.
		 */
    Error = 0,

		/**
		 * Something suspicious but allowed.
		 */
    Warning = 1,

		/**
		 * Something to inform about but not a problem.
		 */
    Information = 2,

		/**
		 * Something to hint to a better way of doing it, like proposing
		 * a refactoring.
		 */
    Hint = 3
  }

	/**
	 * Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
	 * are only valid in the scope of a file.
	 */
  export class Diagnostic {

		/**
		 * The range to which this diagnostic applies.
		 */
    range: Range;

		/**
		 * The human-readable message.
		 */
    message: string;

		/**
		 * A human-readable string describing the source of this
		 * diagnostic, e.g. 'typescript' or 'super lint'.
		 */
    source: string;

		/**
		 * The severity, default is [error](#DiagnosticSeverity.Error).
		 */
    severity: DiagnosticSeverity;

		/**
		 * A code or identifier for this diagnostics. Will not be surfaced
		 * to the user, but should be used for later processing, e.g. when
		 * providing [code actions](#CodeActionContext).
		 */
    code: string | number;

		/**
		 * Creates a new diagnostic object.
		 *
		 * @param range The range to which this diagnostic applies.
		 * @param message The human-readable message.
		 * @param severity The severity, default is [error](#DiagnosticSeverity.Error).
		 */
    constructor(range: Range, message: string, severity?: DiagnosticSeverity);
  }

	/**
	 * A diagnostics collection is a container that manages a set of
	 * [diagnostics](#Diagnostic). Diagnostics are always scopes to a
	 * diagnostics collection and a resource.
	 *
	 * To get an instance of a `DiagnosticCollection` use
	 * [createDiagnosticCollection](#languages.createDiagnosticCollection).
	 */
  export interface DiagnosticCollection {

		/**
		 * The name of this diagnostic collection, for instance `typescript`. Every diagnostic
		 * from this collection will be associated with this name. Also, the task framework uses this
		 * name when defining [problem matchers](https://code.visualstudio.com/docs/editor/tasks#_defining-a-problem-matcher).
		 */
    readonly name: string;

		/**
		 * Assign diagnostics for given resource. Will replace
		 * existing diagnostics for that resource.
		 *
		 * @param uri A resource identifier.
		 * @param diagnostics Array of diagnostics or `undefined`
		 */
    set(uri: Uri, diagnostics: Diagnostic[] | undefined): void;

		/**
		 * Replace all entries in this collection.
		 *
		 * Diagnostics of multiple tuples of the same uri will be merged, e.g
		 * `[[file1, [d1]], [file1, [d2]]]` is equivalent to `[[file1, [d1, d2]]]`.
		 * If a diagnostics item is `undefined` as in `[file1, undefined]`
		 * all previous but not subsequent diagnostics are removed.
		 *
		 * @param entries An array of tuples, like `[[file1, [d1, d2]], [file2, [d3, d4, d5]]]`, or `undefined`.
		 */
    set(entries: [Uri, Diagnostic[] | undefined][]): void;

		/**
		 * Remove all diagnostics from this collection that belong
		 * to the provided `uri`. The same as `#set(uri, undefined)`.
		 *
		 * @param uri A resource identifier.
		 */
    delete(uri: Uri): void;

		/**
		 * Remove all diagnostics from this collection. The same
		 * as calling `#set(undefined)`;
		 */
    clear(): void;

		/**
		 * Iterate over each entry in this collection.
		 *
		 * @param callback Function to execute for each entry.
		 * @param thisArg The `this` context used when invoking the handler function.
		 */
    forEach(callback: (uri: Uri, diagnostics: Diagnostic[], collection: DiagnosticCollection) => any, thisArg?: any): void;

		/**
		 * Get the diagnostics for a given resource. *Note* that you cannot
		 * modify the diagnostics-array returned from this call.
		 *
		 * @param uri A resource identifier.
		 * @returns An immutable array of [diagnostics](#Diagnostic) or `undefined`.
		 */
    get(uri: Uri): Diagnostic[] | undefined;

		/**
		 * Check if this collection contains diagnostics for a
		 * given resource.
		 *
		 * @param uri A resource identifier.
		 * @returns `true` if this collection has diagnostic for the given resource.
		 */
    has(uri: Uri): boolean;

		/**
		 * Dispose and free associated resources. Calls
		 * [clear](#DiagnosticCollection.clear).
		 */
    dispose(): void;
  }

	/**
	 * Denotes a column in the editor window. Columns are
	 * used to show editors side by side.
	 */
  export enum ViewColumn {
    One = 1,
    Two = 2,
    Three = 3
  }

	/**
	 * An output channel is a container for readonly textual information.
	 *
	 * To get an instance of an `OutputChannel` use
	 * [createOutputChannel](#window.createOutputChannel).
	 */
  export interface OutputChannel {

		/**
		 * The human-readable name of this output channel.
		 */
    readonly name: string;

		/**
		 * Append the given value to the channel.
		 *
		 * @param value A string, falsy values will not be printed.
		 */
    append(value: string): void;

		/**
		 * Append the given value and a line feed character
		 * to the channel.
		 *
		 * @param value A string, falsy values will be printed.
		 */
    appendLine(value: string): void;

		/**
		 * Removes all output from the channel.
		 */
    clear(): void;

		/**
		 * Reveal this channel in the UI.
		 *
		 * @param preserveFocus When `true` the channel will not take focus.
		 */
    show(preserveFocus?: boolean): void;

		/**
		 * ~~Reveal this channel in the UI.~~
		 *
		 * @deprecated Use the overload with just one parameter (`show(preserveFocus?: boolean): void`).
		 *
		 * @param column This argument is **deprecated** and will be ignored.
		 * @param preserveFocus When `true` the channel will not take focus.
		 */
    show(column?: ViewColumn, preserveFocus?: boolean): void;

		/**
		 * Hide this channel from the UI.
		 */
    hide(): void;

		/**
		 * Dispose and free associated resources.
		 */
    dispose(): void;
  }

	/**
	 * Represents the alignment of status bar items.
	 */
  export enum StatusBarAlignment {

		/**
		 * Aligned to the left side.
		 */
    Left = 1,

		/**
		 * Aligned to the right side.
		 */
    Right = 2
  }

	/**
	 * A status bar item is a status bar contribution that can
	 * show text and icons and run a command on click.
	 */
  export interface StatusBarItem {

		/**
		 * The alignment of this item.
		 */
    readonly alignment: StatusBarAlignment;

		/**
		 * The priority of this item. Higher value means the item should
		 * be shown more to the left.
		 */
    readonly priority: number;

		/**
		 * The text to show for the entry. You can embed icons in the text by leveraging the syntax:
		 *
		 * `My text $(icon-name) contains icons like $(icon'name) this one.`
		 *
		 * Where the icon-name is taken from the [octicon](https://octicons.github.com) icon set, e.g.
		 * `light-bulb`, `thumbsup`, `zap` etc.
		 */
    text: string;

		/**
		 * The tooltip text when you hover over this entry.
		 */
    tooltip: string | undefined;

		/**
		 * The foreground color for this entry.
		 */
    color: string | ThemeColor | undefined;

		/**
		 * The identifier of a command to run on click. The command must be
		 * [known](#commands.getCommands).
		 */
    command: string | undefined;

		/**
		 * Shows the entry in the status bar.
		 */
    show(): void;

		/**
		 * Hide the entry in the status bar.
		 */
    hide(): void;

		/**
		 * Dispose and free associated resources. Call
		 * [hide](#StatusBarItem.hide).
		 */
    dispose(): void;
  }

	/**
	 * Defines a generalized way of reporting progress updates.
	 */
  export interface Progress<T> {

		/**
		 * Report a progress update.
		 * @param value A progress item, like a message or an updated percentage value
		 */
    report(value: T): void;
  }

	/**
	 * An individual terminal instance within the integrated terminal.
	 */
  export interface Terminal {

		/**
		 * The name of the terminal.
		 */
    readonly name: string;

		/**
		 * The process ID of the shell process.
		 */
    readonly processId: Thenable<number>;

		/**
		 * Send text to the terminal. The text is written to the stdin of the underlying pty process
		 * (shell) of the terminal.
		 *
		 * @param text The text to send.
		 * @param addNewLine Whether to add a new line to the text being sent, this is normally
		 * required to run a command in the terminal. The character(s) added are \n or \r\n
		 * depending on the platform. This defaults to `true`.
		 */
    sendText(text: string, addNewLine?: boolean): void;

		/**
		 * Show the terminal panel and reveal this terminal in the UI.
		 *
		 * @param preserveFocus When `true` the terminal will not take focus.
		 */
    show(preserveFocus?: boolean): void;

		/**
		 * Hide the terminal panel if this terminal is currently showing.
		 */
    hide(): void;

		/**
		 * Dispose and free associated resources.
		 */
    dispose(): void;
  }

	/**
	 * Represents an extension.
	 *
	 * To get an instance of an `Extension` use [getExtension](#extensions.getExtension).
	 */
  export interface Extension<T> {

		/**
		 * The canonical extension identifier in the form of: `publisher.name`.
		 */
    readonly id: string;

		/**
		 * The absolute file path of the directory containing this extension.
		 */
    readonly extensionPath: string;

		/**
		 * `true` if the extension has been activated.
		 */
    readonly isActive: boolean;

		/**
		 * The parsed contents of the extension's package.json.
		 */
    readonly packageJSON: any;

		/**
		 * The public API exported by this extension. It is an invalid action
		 * to access this field before this extension has been activated.
		 */
    readonly exports: T;

		/**
		 * Activates this extension and returns its public API.
		 *
		 * @return A promise that will resolve when this extension has been activated.
		 */
    activate(): Thenable<T>;
  }

	/**
	 * An extension context is a collection of utilities private to an
	 * extension.
	 *
	 * An instance of an `ExtensionContext` is provided as the first
	 * parameter to the `activate`-call of an extension.
	 */
  export interface ExtensionContext {

		/**
		 * An array to which disposables can be added. When this
		 * extension is deactivated the disposables will be disposed.
		 */
    subscriptions: { dispose(): any }[];

		/**
		 * A memento object that stores state in the context
		 * of the currently opened [workspace](#workspace.workspaceFolders).
		 */
    workspaceState: Memento;

		/**
		 * A memento object that stores state independent
		 * of the current opened [workspace](#workspace.workspaceFolders).
		 */
    globalState: Memento;

		/**
		 * The absolute file path of the directory containing the extension.
		 */
    extensionPath: string;

		/**
		 * Get the absolute path of a resource contained in the extension.
		 *
		 * @param relativePath A relative path to a resource contained in the extension.
		 * @return The absolute path of the resource.
		 */
    asAbsolutePath(relativePath: string): string;

		/**
		 * An absolute file path of a workspace specific directory in which the extension
		 * can store private state. The directory might not exist on disk and creation is
		 * up to the extension. However, the parent directory is guaranteed to be existent.
		 *
		 * Use [`workspaceState`](#ExtensionContext.workspaceState) or
		 * [`globalState`](#ExtensionContext.globalState) to store key value data.
		 */
    storagePath: string | undefined;
  }

	/**
	 * A memento represents a storage utility. It can store and retrieve
	 * values.
	 */
  export interface Memento {

		/**
		 * Return a value.
		 *
		 * @param key A string.
		 * @return The stored value or `undefined`.
		 */
    get<T>(key: string): T | undefined;

		/**
		 * Return a value.
		 *
		 * @param key A string.
		 * @param defaultValue A value that should be returned when there is no
		 * value (`undefined`) with the given key.
		 * @return The stored value or the defaultValue.
		 */
    get<T>(key: string, defaultValue: T): T;

		/**
		 * Store a value. The value must be JSON-stringifyable.
		 *
		 * @param key A string.
		 * @param value A value. MUST not contain cyclic references.
		 */
    update(key: string, value: any): Thenable<void>;
  }

	/**
	 * Controls the behaviour of the terminal's visibility.
	 */
  export enum TaskRevealKind {
		/**
		 * Always brings the terminal to front if the task is executed.
		 */
    Always = 1,

		/**
		 * Only brings the terminal to front if a problem is detected executing the task
		 * (e.g. the task couldn't be started because).
		 */
    Silent = 2,

		/**
		 * The terminal never comes to front when the task is executed.
		 */
    Never = 3
  }

	/**
	 * Controls how the task channel is used between tasks
	 */
  export enum TaskPanelKind {

		/**
		 * Shares a panel with other tasks. This is the default.
		 */
    Shared = 1,

		/**
		 * Uses a dedicated panel for this tasks. The panel is not
		 * shared with other tasks.
		 */
    Dedicated = 2,

		/**
		 * Creates a new panel whenever this task is executed.
		 */
    New = 3
  }

	/**
	 * Controls how the task is presented in the UI.
	 */
  export interface TaskPresentationOptions {
		/**
		 * Controls whether the task output is reveal in the user interface.
		 * Defaults to `RevealKind.Always`.
		 */
    reveal?: TaskRevealKind;

		/**
		 * Controls whether the command associated with the task is echoed
		 * in the user interface.
		 */
    echo?: boolean;

		/**
		 * Controls whether the panel showing the task output is taking focus.
		 */
    focus?: boolean;

		/**
		 * Controls if the task panel is used for this task only (dedicated),
		 * shared between tasks (shared) or if a new panel is created on
		 * every task execution (new). Defaults to `TaskInstanceKind.Shared`
		 */
    panel?: TaskPanelKind;
  }

	/**
	 * A grouping for tasks. The editor by default supports the
	 * 'Clean', 'Build', 'RebuildAll' and 'Test' group.
	 */
  export class TaskGroup {

		/**
		 * The clean task group;
		 */
    public static Clean: TaskGroup;

		/**
		 * The build task group;
		 */
    public static Build: TaskGroup;

		/**
		 * The rebuild all task group;
		 */
    public static Rebuild: TaskGroup;

		/**
		 * The test all task group;
		 */
    public static Test: TaskGroup;

    private constructor(id: string, label: string);
  }


	/**
	 * A structure that defines a task kind in the system.
	 * The value must be JSON-stringifyable.
	 */
  export interface TaskDefinition {
		/**
		 * The task definition describing the task provided by an extension.
		 * Usually a task provider defines more properties to identify
		 * a task. They need to be defined in the package.json of the
		 * extension under the 'taskDefinitions' extension point. The npm
		 * task definition for example looks like this
		 * ```typescript
		 * interface NpmTaskDefinition extends TaskDefinition {
		 *     script: string;
		 * }
		 * ```
		 */
    readonly type: string;

		/**
		 * Additional attributes of a concrete task definition.
		 */
    [name: string]: any;
  }

	/**
	 * Options for a process execution
	 */
  export interface ProcessExecutionOptions {
		/**
		 * The current working directory of the executed program or shell.
		 * If omitted the tools current workspace root is used.
		 */
    cwd?: string;

		/**
		 * The additional environment of the executed program or shell. If omitted
		 * the parent process' environment is used. If provided it is merged with
		 * the parent process' environment.
		 */
    env?: { [key: string]: string };
  }

	/**
	 * The execution of a task happens as an external process
	 * without shell interaction.
	 */
  export class ProcessExecution {

		/**
		 * Creates a process execution.
		 *
		 * @param process The process to start.
		 * @param options Optional options for the started process.
		 */
    constructor(process: string, options?: ProcessExecutionOptions);

		/**
		 * Creates a process execution.
		 *
		 * @param process The process to start.
		 * @param args Arguments to be passed to the process.
		 * @param options Optional options for the started process.
		 */
    constructor(process: string, args: string[], options?: ProcessExecutionOptions);

		/**
		 * The process to be executed.
		 */
    process: string;

		/**
		 * The arguments passed to the process. Defaults to an empty array.
		 */
    args: string[];

		/**
		 * The process options used when the process is executed.
		 * Defaults to undefined.
		 */
    options?: ProcessExecutionOptions;
  }

	/**
	 * Options for a shell execution
	 */
  export interface ShellExecutionOptions {
		/**
		 * The shell executable.
		 */
    executable?: string;

		/**
		 * The arguments to be passed to the shell executable used to run the task.
		 */
    shellArgs?: string[];

		/**
		 * The current working directory of the executed shell.
		 * If omitted the tools current workspace root is used.
		 */
    cwd?: string;

		/**
		 * The additional environment of the executed shell. If omitted
		 * the parent process' environment is used. If provided it is merged with
		 * the parent process' environment.
		 */
    env?: { [key: string]: string };
  }


  export class ShellExecution {
		/**
		 * Creates a process execution.
		 *
		 * @param commandLine The command line to execute.
		 * @param options Optional options for the started the shell.
		 */
    constructor(commandLine: string, options?: ShellExecutionOptions);

		/**
		 * The shell command line
		 */
    commandLine: string;

		/**
		 * The shell options used when the command line is executed in a shell.
		 * Defaults to undefined.
		 */
    options?: ShellExecutionOptions;
  }

	/**
	 * A task to execute
	 */
  export class Task {

		/**
		 * Creates a new task.
		 *
		 * @param definition The task definition as defined in the taskDefinitions extension point.
		 * @param name The task's name. Is presented in the user interface.
		 * @param source The task's source (e.g. 'gulp', 'npm', ...). Is presented in the user interface.
		 * @param execution The process or shell execution.
		 * @param problemMatchers the names of problem matchers to use, like '$tsc'
		 *  or '$eslint'. Problem matchers can be contributed by an extension using
		 *  the `problemMatchers` extension point.
		 */
    constructor(taskDefinition: TaskDefinition, name: string, source: string, execution?: ProcessExecution | ShellExecution, problemMatchers?: string | string[]);

		/**
		 * The task's definition.
		 */
    definition: TaskDefinition;

		/**
		 * The task's name
		 */
    name: string;

		/**
		 * The task's execution engine
		 */
    execution: ProcessExecution | ShellExecution;

		/**
		 * Whether the task is a background task or not.
		 */
    isBackground: boolean;

		/**
		 * A human-readable string describing the source of this
		 * shell task, e.g. 'gulp' or 'npm'.
		 */
    source: string;

		/**
		 * The task group this tasks belongs to. See TaskGroup
		 * for a predefined set of available groups.
		 * Defaults to undefined meaning that the task doesn't
		 * belong to any special group.
		 */
    group?: TaskGroup;

		/**
		 * The presentation options. Defaults to an empty literal.
		 */
    presentationOptions: TaskPresentationOptions;

		/**
		 * The problem matchers attached to the task. Defaults to an empty
		 * array.
		 */
    problemMatchers: string[];
  }

	/**
	 * A task provider allows to add tasks to the task service.
	 * A task provider is registered via #workspace.registerTaskProvider.
	 */
  export interface TaskProvider {
		/**
		 * Provides tasks.
		 * @param token A cancellation token.
		 * @return an array of tasks
		 */
    provideTasks(token?: CancellationToken): ProviderResult<Task[]>;

		/**
		 * Resolves a task that has no [`execution`](#Task.execution) set. Tasks are
		 * often created from information found in the `task.json`-file. Such tasks miss
		 * the information on how to execute them and a task provider must fill in
		 * the missing information in the `resolveTask`-method.
		 *
		 * @param task The task to resolve.
		 * @param token A cancellation token.
		 * @return The resolved task
		 */
    resolveTask(task: Task, token?: CancellationToken): ProviderResult<Task>;
  }

	/**
	 * Namespace describing the environment the editor runs in.
	 */
  export namespace env {

		/**
		 * The application name of the editor, like 'VS Code'.
		 *
		 * @readonly
		 */
    export let appName: string;

		/**
		 * The application root folder from which the editor is running.
		 *
		 * @readonly
		 */
    export let appRoot: string;

		/**
		 * Represents the preferred user-language, like `de-CH`, `fr`, or `en-US`.
		 *
		 * @readonly
		 */
    export let language: string;

		/**
		 * A unique identifier for the computer.
		 *
		 * @readonly
		 */
    export let machineId: string;

		/**
		 * A unique identifier for the current session.
		 * Changes each time the editor is started.
		 *
		 * @readonly
		 */
    export let sessionId: string;
  }

	/**
	 * Namespace for dealing with commands. In short, a command is a function with a
	 * unique identifier. The function is sometimes also called _command handler_.
	 *
	 * Commands can be added to the editor using the [registerCommand](#commands.registerCommand)
	 * and [registerTextEditorCommand](#commands.registerTextEditorCommand) functions. Commands
	 * can be executed [manually](#commands.executeCommand) or from a UI gesture. Those are:
	 *
	 * * palette - Use the `commands`-section in `package.json` to make a command show in
	 * the [command palette](https://code.visualstudio.com/docs/getstarted/userinterface#_command-palette).
	 * * keybinding - Use the `keybindings`-section in `package.json` to enable
	 * [keybindings](https://code.visualstudio.com/docs/getstarted/keybindings#_customizing-shortcuts)
	 * for your extension.
	 *
	 * Commands from other extensions and from the editor itself are accessible to an extension. However,
	 * when invoking an editor command not all argument types are supported.
	 *
	 * This is a sample that registers a command handler and adds an entry for that command to the palette. First
	 * register a command handler with the identifier `extension.sayHello`.
	 * ```javascript
	 * commands.registerCommand('extension.sayHello', () => {
	 * 	window.showInformationMessage('Hello World!');
	 * });
	 * ```
	 * Second, bind the command identifier to a title under which it will show in the palette (`package.json`).
	 * ```json
	 * {
	 * 	"contributes": {
	 * 		"commands": [{
	 * 			"command": "extension.sayHello",
	 * 			"title": "Hello World"
	 * 		}]
	 * 	}
	 * }
	 * ```
	 */
  export namespace commands {

		/**
		 * Registers a command that can be invoked via a keyboard shortcut,
		 * a menu item, an action, or directly.
		 *
		 * Registering a command with an existing command identifier twice
		 * will cause an error.
		 *
		 * @param command A unique identifier for the command.
		 * @param callback A command handler function.
		 * @param thisArg The `this` context used when invoking the handler function.
		 * @return Disposable which unregisters this command on disposal.
		 */
    export function registerCommand(command: string, callback: (...args: any[]) => any, thisArg?: any): Disposable;

		/**
		 * Registers a text editor command that can be invoked via a keyboard shortcut,
		 * a menu item, an action, or directly.
		 *
		 * Text editor commands are different from ordinary [commands](#commands.registerCommand) as
		 * they only execute when there is an active editor when the command is called. Also, the
		 * command handler of an editor command has access to the active editor and to an
		 * [edit](#TextEditorEdit)-builder.
		 *
		 * @param command A unique identifier for the command.
		 * @param callback A command handler function with access to an [editor](#TextEditor) and an [edit](#TextEditorEdit).
		 * @param thisArg The `this` context used when invoking the handler function.
		 * @return Disposable which unregisters this command on disposal.
		 */
    export function registerTextEditorCommand(command: string, callback: (textEditor: TextEditor, edit: TextEditorEdit, ...args: any[]) => void, thisArg?: any): Disposable;

		/**
		 * Executes the command denoted by the given command identifier.
		 *
		 * * *Note 1:* When executing an editor command not all types are allowed to
		 * be passed as arguments. Allowed are the primitive types `string`, `boolean`,
		 * `number`, `undefined`, and `null`, as well as [`Position`](#Position), [`Range`](#Range), [`Uri`](#Uri) and [`Location`](#Location).
		 * * *Note 2:* There are no restrictions when executing commands that have been contributed
		 * by extensions.
		 *
		 * @param command Identifier of the command to execute.
		 * @param rest Parameters passed to the command function.
		 * @return A thenable that resolves to the returned value of the given command. `undefined` when
		 * the command handler function doesn't return anything.
		 */
    export function executeCommand<T>(command: string, ...rest: any[]): Thenable<T | undefined>;

		/**
		 * Retrieve the list of all available commands. Commands starting an underscore are
		 * treated as internal commands.
		 *
		 * @param filterInternal Set `true` to not see internal commands (starting with an underscore)
		 * @return Thenable that resolves to a list of command ids.
		 */
    export function getCommands(filterInternal?: boolean): Thenable<string[]>;
  }

	/**
	 * Represents the state of a window.
	 */
  export interface WindowState {

		/**
		 * Whether the current window is focused.
		 */
    readonly focused: boolean;
  }

	/**
	 * Namespace for dealing with the current window of the editor. That is visible
	 * and active editors, as well as, UI elements to show messages, selections, and
	 * asking for user input.
	 */
  export namespace window {

		/**
		 * The currently active editor or `undefined`. The active editor is the one
		 * that currently has focus or, when none has focus, the one that has changed
		 * input most recently.
		 */
    export let activeTextEditor: TextEditor | undefined;

		/**
		 * The currently visible editors or an empty array.
		 */
    export let visibleTextEditors: TextEditor[];

		/**
		 * An [event](#Event) which fires when the [active editor](#window.activeTextEditor)
		 * has changed. *Note* that the event also fires when the active editor changes
		 * to `undefined`.
		 */
    export const onDidChangeActiveTextEditor: Event<TextEditor>;

		/**
		 * An [event](#Event) which fires when the array of [visible editors](#window.visibleTextEditors)
		 * has changed.
		 */
    export const onDidChangeVisibleTextEditors: Event<TextEditor[]>;

		/**
		 * An [event](#Event) which fires when the selection in an editor has changed.
		 */
    export const onDidChangeTextEditorSelection: Event<TextEditorSelectionChangeEvent>;

		/**
		 * An [event](#Event) which fires when the options of an editor have changed.
		 */
    export const onDidChangeTextEditorOptions: Event<TextEditorOptionsChangeEvent>;

		/**
		 * An [event](#Event) which fires when the view column of an editor has changed.
		 */
    export const onDidChangeTextEditorViewColumn: Event<TextEditorViewColumnChangeEvent>;

		/**
		 * An [event](#Event) which fires when a terminal is disposed.
		 */
    export const onDidCloseTerminal: Event<Terminal>;

		/**
		 * Represents the current window's state.
		 *
		 * @readonly
		 */
    export let state: WindowState;

		/**
		 * An [event](#Event) which fires when the focus state of the current window
		 * changes. The value of the event represents whether the window is focused.
		 */
    export const onDidChangeWindowState: Event<WindowState>;

		/**
		 * Show the given document in a text editor. A [column](#ViewColumn) can be provided
		 * to control where the editor is being shown. Might change the [active editor](#window.activeTextEditor).
		 *
		 * @param document A text document to be shown.
		 * @param column A view column in which the editor should be shown. The default is the [one](#ViewColumn.One), other values
		 * are adjusted to be __Min(column, columnCount + 1)__.
		 * @param preserveFocus When `true` the editor will not take focus.
		 * @return A promise that resolves to an [editor](#TextEditor).
		 */
    export function showTextDocument(document: TextDocument, column?: ViewColumn, preserveFocus?: boolean): Thenable<TextEditor>;

		/**
		 * Show the given document in a text editor. [Options](#TextDocumentShowOptions) can be provided
		 * to control options of the editor is being shown. Might change the [active editor](#window.activeTextEditor).
		 *
		 * @param document A text document to be shown.
		 * @param options [Editor options](#ShowTextDocumentOptions) to configure the behavior of showing the [editor](#TextEditor).
		 * @return A promise that resolves to an [editor](#TextEditor).
		 */
    export function showTextDocument(document: TextDocument, options?: TextDocumentShowOptions): Thenable<TextEditor>;

		/**
		 * A short-hand for `openTextDocument(uri).then(document => showTextDocument(document, options))`.
		 *
		 * @see [openTextDocument](#openTextDocument)
		 *
		 * @param uri A resource identifier.
		 * @param options [Editor options](#ShowTextDocumentOptions) to configure the behavior of showing the [editor](#TextEditor).
		 * @return A promise that resolves to an [editor](#TextEditor).
		 */
    export function showTextDocument(uri: Uri, options?: TextDocumentShowOptions): Thenable<TextEditor>;

		/**
		 * Create a TextEditorDecorationType that can be used to add decorations to text editors.
		 *
		 * @param options Rendering options for the decoration type.
		 * @return A new decoration type instance.
		 */
    export function createTextEditorDecorationType(options: DecorationRenderOptions): TextEditorDecorationType;

		/**
		 * Show an information message to users. Optionally provide an array of items which will be presented as
		 * clickable buttons.
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showInformationMessage(message: string, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show an information message to users. Optionally provide an array of items which will be presented as
		 * clickable buttons.
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showInformationMessage(message: string, options: MessageOptions, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show an information message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showInformationMessage<T extends MessageItem>(message: string, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Show an information message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showInformationMessage<T extends MessageItem>(message: string, options: MessageOptions, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Show a warning message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showWarningMessage(message: string, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show a warning message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showWarningMessage(message: string, options: MessageOptions, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show a warning message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showWarningMessage<T extends MessageItem>(message: string, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Show a warning message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showWarningMessage<T extends MessageItem>(message: string, options: MessageOptions, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Show an error message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showErrorMessage(message: string, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show an error message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showErrorMessage(message: string, options: MessageOptions, ...items: string[]): Thenable<string | undefined>;

		/**
		 * Show an error message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showErrorMessage<T extends MessageItem>(message: string, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Show an error message.
		 *
		 * @see [showInformationMessage](#window.showInformationMessage)
		 *
		 * @param message The message to show.
		 * @param options Configures the behaviour of the message.
		 * @param items A set of items that will be rendered as actions in the message.
		 * @return A thenable that resolves to the selected item or `undefined` when being dismissed.
		 */
    export function showErrorMessage<T extends MessageItem>(message: string, options: MessageOptions, ...items: T[]): Thenable<T | undefined>;

		/**
		 * Shows a selection list.
		 *
		 * @param items An array of strings, or a promise that resolves to an array of strings.
		 * @param options Configures the behavior of the selection list.
		 * @param token A token that can be used to signal cancellation.
		 * @return A promise that resolves to the selection or `undefined`.
		 */
    export function showQuickPick(items: string[] | Thenable<string[]>, options?: QuickPickOptions, token?: CancellationToken): Thenable<string | undefined>;

		/**
		 * Shows a selection list.
		 *
		 * @param items An array of items, or a promise that resolves to an array of items.
		 * @param options Configures the behavior of the selection list.
		 * @param token A token that can be used to signal cancellation.
		 * @return A promise that resolves to the selected item or `undefined`.
		 */
    export function showQuickPick<T extends QuickPickItem>(items: T[] | Thenable<T[]>, options?: QuickPickOptions, token?: CancellationToken): Thenable<T | undefined>;

		/**
		 * Opens an input box to ask the user for input.
		 *
		 * The returned value will be `undefined` if the input box was canceled (e.g. pressing ESC). Otherwise the
		 * returned value will be the string typed by the user or an empty string if the user did not type
		 * anything but dismissed the input box with OK.
		 *
		 * @param options Configures the behavior of the input box.
		 * @param token A token that can be used to signal cancellation.
		 * @return A promise that resolves to a string the user provided or to `undefined` in case of dismissal.
		 */
    export function showInputBox(options?: InputBoxOptions, token?: CancellationToken): Thenable<string | undefined>;

		/**
		 * Create a new [output channel](#OutputChannel) with the given name.
		 *
		 * @param name Human-readable string which will be used to represent the channel in the UI.
		 */
    export function createOutputChannel(name: string): OutputChannel;

		/**
		 * Set a message to the status bar. This is a short hand for the more powerful
		 * status bar [items](#window.createStatusBarItem).
		 *
		 * @param text The message to show, supports icon substitution as in status bar [items](#StatusBarItem.text).
		 * @param hideAfterTimeout Timeout in milliseconds after which the message will be disposed.
		 * @return A disposable which hides the status bar message.
		 */
    export function setStatusBarMessage(text: string, hideAfterTimeout: number): Disposable;

		/**
		 * Set a message to the status bar. This is a short hand for the more powerful
		 * status bar [items](#window.createStatusBarItem).
		 *
		 * @param text The message to show, supports icon substitution as in status bar [items](#StatusBarItem.text).
		 * @param hideWhenDone Thenable on which completion (resolve or reject) the message will be disposed.
		 * @return A disposable which hides the status bar message.
		 */
    export function setStatusBarMessage(text: string, hideWhenDone: Thenable<any>): Disposable;

		/**
		 * Set a message to the status bar. This is a short hand for the more powerful
		 * status bar [items](#window.createStatusBarItem).
		 *
		 * *Note* that status bar messages stack and that they must be disposed when no
		 * longer used.
		 *
		 * @param text The message to show, supports icon substitution as in status bar [items](#StatusBarItem.text).
		 * @return A disposable which hides the status bar message.
		 */
    export function setStatusBarMessage(text: string): Disposable;

		/**
		 * ~~Show progress in the Source Control viewlet while running the given callback and while
		 * its returned promise isn't resolve or rejected.~~
		 *
		 * @deprecated Use `withProgress` instead.
		 *
		 * @param task A callback returning a promise. Progress increments can be reported with
		 * the provided [progress](#Progress)-object.
		 * @return The thenable the task did rseturn.
		 */
    export function withScmProgress<R>(task: (progress: Progress<number>) => Thenable<R>): Thenable<R>;

		/**
		 * Show progress in the editor. Progress is shown while running the given callback
		 * and while the promise it returned isn't resolved nor rejected. The location at which
		 * progress should show (and other details) is defined via the passed [`ProgressOptions`](#ProgressOptions).
		 *
		 * @param task A callback returning a promise. Progress state can be reported with
		 * the provided [progress](#Progress)-object.
		 * @return The thenable the task-callback returned.
		 */
    export function withProgress<R>(options: ProgressOptions, task: (progress: Progress<{ message?: string; }>) => Thenable<R>): Thenable<R>;

		/**
		 * Creates a status bar [item](#StatusBarItem).
		 *
		 * @param alignment The alignment of the item.
		 * @param priority The priority of the item. Higher values mean the item should be shown more to the left.
		 * @return A new status bar item.
		 */
    export function createStatusBarItem(alignment?: StatusBarAlignment, priority?: number): StatusBarItem;

		/**
		 * Creates a [Terminal](#Terminal). The cwd of the terminal will be the workspace directory
		 * if it exists, regardless of whether an explicit customStartPath setting exists.
		 *
		 * @param name Optional human-readable string which will be used to represent the terminal in the UI.
		 * @param shellPath Optional path to a custom shell executable to be used in the terminal.
		 * @param shellArgs Optional args for the custom shell executable, this does not work on Windows (see #8429)
		 * @return A new Terminal.
		 */
    export function createTerminal(name?: string, shellPath?: string, shellArgs?: string[]): Terminal;

		/**
		 * Creates a [Terminal](#Terminal). The cwd of the terminal will be the workspace directory
		 * if it exists, regardless of whether an explicit customStartPath setting exists.
		 *
		 * @param options A TerminalOptions object describing the characteristics of the new terminal.
		 * @return A new Terminal.
		 */
    export function createTerminal(options: TerminalOptions): Terminal;

		/**
		 * Register a [TreeDataProvider](#TreeDataProvider) for the view contributed using the extension point `views`.
		 * @param viewId Id of the view contributed using the extension point `views`.
		 * @param treeDataProvider A [TreeDataProvider](#TreeDataProvider) that provides tree data for the view
		 */
    export function registerTreeDataProvider<T>(viewId: string, treeDataProvider: TreeDataProvider<T>): Disposable;
  }

	/**
	 * A data provider that provides tree data
	 */
  export interface TreeDataProvider<T> {
		/**
		 * An optional event to signal that an element or root has changed.
		 * To signal that root has changed, do not pass any argument or pass `undefined` or `null`.
		 */
    onDidChangeTreeData?: Event<T | undefined | null>;

		/**
		 * Get [TreeItem](#TreeItem) representation of the `element`
		 *
		 * @param element The element for which [TreeItem](#TreeItem) representation is asked for.
		 * @return [TreeItem](#TreeItem) representation of the element
		 */
    getTreeItem(element: T): TreeItem | Thenable<TreeItem>;

		/**
		 * Get the children of `element` or root if no element is passed.
		 *
		 * @param element The element from which the provider gets children. Can be `undefined`.
		 * @return Children of `element` or root if no element is passed.
		 */
    getChildren(element?: T): ProviderResult<T[]>;
  }

  export class TreeItem {
		/**
		 * A human-readable string describing this item
		 */
    label: string;

		/**
		 * The icon path for the tree item
		 */
    iconPath?: string | Uri | { light: string | Uri; dark: string | Uri };

		/**
		 * The [command](#Command) which should be run when the tree item is selected.
		 */
    command?: Command;

		/**
		 * [TreeItemCollapsibleState](#TreeItemCollapsibleState) of the tree item.
		 */
    collapsibleState?: TreeItemCollapsibleState;

		/**
		 * Context value of the tree item. This can be used to contribute item specific actions in the tree.
		 * For example, a tree item is given a context value as `folder`. When contributing actions to `view/item/context`
		 * using `menus` extension point, you can specify context value for key `viewItem` in `when` expression like `viewItem == folder`.
		 * ```
		 *	"contributes": {
		 *		"menus": {
		 *			"view/item/context": [
		 *				{
		 *					"command": "extension.deleteFolder",
		 *					"when": "viewItem == folder"
		 *				}
		 *			]
		 *		}
		 *	}
		 * ```
		 * This will show action `extension.deleteFolder` only for items with `contextValue` is `folder`.
		 */
    contextValue?: string;

		/**
		 * @param label A human-readable string describing this item
		 * @param collapsibleState [TreeItemCollapsibleState](#TreeItemCollapsibleState) of the tree item. Default is [TreeItemCollapsibleState.None](#TreeItemCollapsibleState.None)
		 */
    constructor(label: string, collapsibleState?: TreeItemCollapsibleState);
  }

	/**
	 * Collapsible state of the tree item
	 */
  export enum TreeItemCollapsibleState {
		/**
		 * Determines an item can be neither collapsed nor expanded. Implies it has no children.
		 */
    None = 0,
		/**
		 * Determines an item is collapsed
		 */
    Collapsed = 1,
		/**
		 * Determines an item is expanded
		 */
    Expanded = 2
  }

	/**
	 * Value-object describing what options a terminal should use.
	 */
  export interface TerminalOptions {
		/**
		 * A human-readable string which will be used to represent the terminal in the UI.
		 */
    name?: string;

		/**
		 * A path to a custom shell executable to be used in the terminal.
		 */
    shellPath?: string;

		/**
		 * Args for the custom shell executable, this does not work on Windows (see #8429)
		 */
    shellArgs?: string[];
  }

	/**
	 * A location in the editor at which progress information can be shown. It depends on the
	 * location how progress is visually represented.
	 */
  export enum ProgressLocation {

		/**
		 * Show progress for the source control viewlet, as overlay for the icon and as progress bar
		 * inside the viewlet (when visible).
		 */
    SourceControl = 1,

		/**
		 * Show progress in the status bar of the editor.
		 */
    Window = 10
  }

	/**
	 * Value-object describing where and how progress should show.
	 */
  export interface ProgressOptions {

		/**
		 * The location at which progress should show.
		 */
    location: ProgressLocation;

		/**
		 * A human-readable string which will be used to describe the
		 * operation.
		 */
    title?: string;
  }

	/**
	 * An event describing an individual change in the text of a [document](#TextDocument).
	 */
  export interface TextDocumentContentChangeEvent {
		/**
		 * The range that got replaced.
		 */
    range: Range;
		/**
		 * The length of the range that got replaced.
		 */
    rangeLength: number;
		/**
		 * The new text for the range.
		 */
    text: string;
  }

	/**
	 * An event describing a transactional [document](#TextDocument) change.
	 */
  export interface TextDocumentChangeEvent {

		/**
		 * The affected document.
		 */
    document: TextDocument;

		/**
		 * An array of content changes.
		 */
    contentChanges: TextDocumentContentChangeEvent[];
  }

	/**
	 * Represents reasons why a text document is saved.
	 */
  export enum TextDocumentSaveReason {

		/**
		 * Manually triggered, e.g. by the user pressing save, by starting debugging,
		 * or by an API call.
		 */
    Manual = 1,

		/**
		 * Automatic after a delay.
		 */
    AfterDelay = 2,

		/**
		 * When the editor lost focus.
		 */
    FocusOut = 3
  }

	/**
	 * An event that is fired when a [document](#TextDocument) will be saved.
	 *
	 * To make modifications to the document before it is being saved, call the
	 * [`waitUntil`](#TextDocumentWillSaveEvent.waitUntil)-function with a thenable
	 * that resolves to an array of [text edits](#TextEdit).
	 */
  export interface TextDocumentWillSaveEvent {

		/**
		 * The document that will be saved.
		 */
    document: TextDocument;

		/**
		 * The reason why save was triggered.
		 */
    reason: TextDocumentSaveReason;

		/**
		 * Allows to pause the event loop and to apply [pre-save-edits](#TextEdit).
		 * Edits of subsequent calls to this function will be applied in order. The
		 * edits will be *ignored* if concurrent modifications of the document happened.
		 *
		 * *Note:* This function can only be called during event dispatch and not
		 * in an asynchronous manner:
		 *
		 * ```ts
		 * workspace.onWillSaveTextDocument(event => {
		 * 	// async, will *throw* an error
		 * 	setTimeout(() => event.waitUntil(promise));
		 *
		 * 	// sync, OK
		 * 	event.waitUntil(promise);
		 * })
		 * ```
		 *
		 * @param thenable A thenable that resolves to [pre-save-edits](#TextEdit).
		 */
    waitUntil(thenable: Thenable<TextEdit[]>): void;

		/**
		 * Allows to pause the event loop until the provided thenable resolved.
		 *
		 * *Note:* This function can only be called during event dispatch.
		 *
		 * @param thenable A thenable that delays saving.
		 */
    waitUntil(thenable: Thenable<any>): void;
  }

	/**
	 * An event describing a change to the set of [workspace folders](#workspace.workspaceFolders).
	 */
  export interface WorkspaceFoldersChangeEvent {
		/**
		 * Added workspace folders.
		 */
    readonly added: WorkspaceFolder[];

		/**
		 * Removed workspace folders.
		 */
    readonly removed: WorkspaceFolder[];
  }

	/**
	 * A workspace folder is one of potentially many roots opened by the editor. All workspace folders
	 * are equal which means there is no notion of an active or master workspace folder.
	 */
  export interface WorkspaceFolder {

		/**
		 * The associated URI for this workspace folder.
		 */
    readonly uri: Uri;

		/**
		 * The name of this workspace folder. Defaults to
		 * the basename its [uri-path](#Uri.path)
		 */
    readonly name: string;

		/**
		 * The ordinal number of this workspace folder.
		 */
    readonly index: number;
  }

	/**
	 * Namespace for dealing with the current workspace. A workspace is the representation
	 * of the folder that has been opened. There is no workspace when just a file but not a
	 * folder has been opened.
	 *
	 * The workspace offers support for [listening](#workspace.createFileSystemWatcher) to fs
	 * events and for [finding](#workspace.findFiles) files. Both perform well and run _outside_
	 * the editor-process so that they should be always used instead of nodejs-equivalents.
	 */
  export namespace workspace {

		/**
		 * ~~The folder that is open in the editor. `undefined` when no folder
		 * has been opened.~~
		 *
		 * @deprecated Use [`workspaceFolders`](#workspace.workspaceFolders) instead.
		 *
		 * @readonly
		 */
    export let rootPath: string | undefined;

		/**
		 * List of workspace folders or `undefined` when no folder is open.
		 * *Note* that the first entry corresponds to the value of `rootPath`.
		 *
		 * @readonly
		 */
    export let workspaceFolders: WorkspaceFolder[] | undefined;

		/**
		 * An event that is emitted when a workspace folder is added or removed.
		 */
    export const onDidChangeWorkspaceFolders: Event<WorkspaceFoldersChangeEvent>;

		/**
		 * Returns a [workspace folder](#WorkspaceFolder) for the provided resource. When the resource
		 * is a workspace folder itself, its parent workspace folder or `undefined` is returned.
		 *
		 * @param uri An uri.
		 * @return A workspace folder or `undefined`
		 */
    export function getWorkspaceFolder(uri: Uri): WorkspaceFolder | undefined;

		/**
		 * Returns a path that is relative to the workspace folder or folders.
		 *
		 * When there are no [workspace folders](#workspace.workspaceFolders) or when the path
		 * is not contained in them, the input is returned.
		 *
		 * @param pathOrUri A path or uri. When a uri is given its [fsPath](#Uri.fsPath) is used.
		 * @param includeWorkspaceFolder When `true` and when the given path is contained inside a
		 * workspace folder the name of the workspace is prepended. Defaults to `true` when there are
		 * multiple workspace folders and `false` otherwise.
		 * @return A path relative to the root or the input.
		 */
    export function asRelativePath(pathOrUri: string | Uri, includeWorkspaceFolder?: boolean): string;

		/**
		 * Creates a file system watcher.
		 *
		 * A glob pattern that filters the file events must be provided. Optionally, flags to ignore certain
		 * kinds of events can be provided. To stop listening to events the watcher must be disposed.
		 *
		 * *Note* that only files within the current [workspace folders](#workspace.workspaceFolders) can be watched.
		 *
		 * @param globPattern A glob pattern that is applied to the names of created, changed, and deleted files.
		 * @param ignoreCreateEvents Ignore when files have been created.
		 * @param ignoreChangeEvents Ignore when files have been changed.
		 * @param ignoreDeleteEvents Ignore when files have been deleted.
		 * @return A new file system watcher instance.
		 */
    export function createFileSystemWatcher(globPattern: string, ignoreCreateEvents?: boolean, ignoreChangeEvents?: boolean, ignoreDeleteEvents?: boolean): FileSystemWatcher;

		/**
		 * Find files in the workspace.
		 *
		 * @sample `findFiles('**∕*.js', '**∕node_modules∕**', 10)`
		 * @param include A glob pattern that defines the files to search for.
		 * @param exclude A glob pattern that defines files and folders to exclude.
		 * @param maxResults An upper-bound for the result.
		 * @param token A token that can be used to signal cancellation to the underlying search engine.
		 * @return A thenable that resolves to an array of resource identifiers.
		 */
    export function findFiles(include: string, exclude?: string, maxResults?: number, token?: CancellationToken): Thenable<Uri[]>;

		/**
		 * Save all dirty files.
		 *
		 * @param includeUntitled Also save files that have been created during this session.
		 * @return A thenable that resolves when the files have been saved.
		 */
    export function saveAll(includeUntitled?: boolean): Thenable<boolean>;

		/**
		 * Make changes to one or many resources as defined by the given
		 * [workspace edit](#WorkspaceEdit).
		 *
		 * When applying a workspace edit, the editor implements an 'all-or-nothing'-strategy,
		 * that means failure to load one document or make changes to one document will cause
		 * the edit to be rejected.
		 *
		 * @param edit A workspace edit.
		 * @return A thenable that resolves when the edit could be applied.
		 */
    export function applyEdit(edit: WorkspaceEdit): Thenable<boolean>;

		/**
		 * All text documents currently known to the system.
		 *
		 * @readonly
		 */
    export let textDocuments: TextDocument[];

		/**
		 * Opens a document. Will return early if this document is already open. Otherwise
		 * the document is loaded and the [didOpen](#workspace.onDidOpenTextDocument)-event fires.
		 *
		 * The document is denoted by an [uri](#Uri). Depending on the [scheme](#Uri.scheme) the
		 * following rules apply:
		 * * `file`-scheme: Open a file on disk, will be rejected if the file does not exist or cannot be loaded.
		 * * `untitled`-scheme: A new file that should be saved on disk, e.g. `untitled:c:\frodo\new.js`. The language
		 * will be derived from the file name.
		 * * For all other schemes the registered text document content [providers](#TextDocumentContentProvider) are consulted.
		 *
		 * *Note* that the lifecycle of the returned document is owned by the editor and not by the extension. That means an
		 * [`onDidClose`](#workspace.onDidCloseTextDocument)-event can occur at any time after opening it.
		 *
		 * @param uri Identifies the resource to open.
		 * @return A promise that resolves to a [document](#TextDocument).
		 */
    export function openTextDocument(uri: Uri): Thenable<TextDocument>;

		/**
		 * A short-hand for `openTextDocument(Uri.file(fileName))`.
		 *
		 * @see [openTextDocument](#openTextDocument)
		 * @param fileName A name of a file on disk.
		 * @return A promise that resolves to a [document](#TextDocument).
		 */
    export function openTextDocument(fileName: string): Thenable<TextDocument>;

		/**
		 * Opens an untitled text document. The editor will prompt the user for a file
		 * path when the document is to be saved. The `options` parameter allows to
		 * specify the *language* and/or the *content* of the document.
		 *
		 * @param options Options to control how the document will be created.
		 * @return A promise that resolves to a [document](#TextDocument).
		 */
    export function openTextDocument(options?: { language?: string; content?: string; }): Thenable<TextDocument>;

		/**
		 * Register a text document content provider.
		 *
		 * Only one provider can be registered per scheme.
		 *
		 * @param scheme The uri-scheme to register for.
		 * @param provider A content provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerTextDocumentContentProvider(scheme: string, provider: TextDocumentContentProvider): Disposable;

		/**
		 * An event that is emitted when a [text document](#TextDocument) is opened.
		 */
    export const onDidOpenTextDocument: Event<TextDocument>;

		/**
		 * An event that is emitted when a [text document](#TextDocument) is disposed.
		 */
    export const onDidCloseTextDocument: Event<TextDocument>;

		/**
		 * An event that is emitted when a [text document](#TextDocument) is changed. This usually happens
		 * when the [contents](#TextDocument.getText) changes but also when other things like the
		 * [dirty](TextDocument#isDirty)-state changes.
		 */
    export const onDidChangeTextDocument: Event<TextDocumentChangeEvent>;

		/**
		 * An event that is emitted when a [text document](#TextDocument) will be saved to disk.
		 *
		 * *Note 1:* Subscribers can delay saving by registering asynchronous work. For the sake of data integrity the editor
		 * might save without firing this event. For instance when shutting down with dirty files.
		 *
		 * *Note 2:* Subscribers are called sequentially and they can [delay](#TextDocumentWillSaveEvent.waitUntil) saving
		 * by registering asynchronous work. Protection against misbehaving listeners is implemented as such:
		 *  * there is an overall time budget that all listeners share and if that is exhausted no further listener is called
		 *  * listeners that take a long time or produce errors frequently will not be called anymore
		 *
		 * The current thresholds are 1.5 seconds as overall time budget and a listener can misbehave 3 times before being ignored.
		 */
    export const onWillSaveTextDocument: Event<TextDocumentWillSaveEvent>;

		/**
		 * An event that is emitted when a [text document](#TextDocument) is saved to disk.
		 */
    export const onDidSaveTextDocument: Event<TextDocument>;

		/**
		 * Get a workspace configuration object.
		 *
		 * When a section-identifier is provided only that part of the configuration
		 * is returned. Dots in the section-identifier are interpreted as child-access,
		 * like `{ myExt: { setting: { doIt: true }}}` and `getConfiguration('myExt.setting').get('doIt') === true`.
		 *
		 * When a resource is provided, configuration scoped to that resource is returned.
		 *
		 * @param section A dot-separated identifier.
		 * @param resource A resource for which the configuration is asked for
		 * @return The full configuration or a subset.
		 */
    export function getConfiguration(section?: string, resource?: Uri): WorkspaceConfiguration;

		/**
		 * An event that is emitted when the [configuration](#WorkspaceConfiguration) changed.
		 */
    export const onDidChangeConfiguration: Event<void>;

		/**
		 * Register a task provider.
		 *
		 * @param type The task kind type this provider is registered for.
		 * @param provider A task provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerTaskProvider(type: string, provider: TaskProvider): Disposable;
  }

	/**
	 * Namespace for participating in language-specific editor [features](https://code.visualstudio.com/docs/editor/editingevolved),
	 * like IntelliSense, code actions, diagnostics etc.
	 *
	 * Many programming languages exist and there is huge variety in syntaxes, semantics, and paradigms. Despite that, features
	 * like automatic word-completion, code navigation, or code checking have become popular across different tools for different
	 * programming languages.
	 *
	 * The editor provides an API that makes it simple to provide such common features by having all UI and actions already in place and
	 * by allowing you to participate by providing data only. For instance, to contribute a hover all you have to do is provide a function
	 * that can be called with a [TextDocument](#TextDocument) and a [Position](#Position) returning hover info. The rest, like tracking the
	 * mouse, positioning the hover, keeping the hover stable etc. is taken care of by the editor.
	 *
	 * ```javascript
	 * languages.registerHoverProvider('javascript', {
	 * 	provideHover(document, position, token) {
	 * 		return new Hover('I am a hover!');
	 * 	}
	 * });
	 * ```
	 *
	 * Registration is done using a [document selector](#DocumentSelector) which is either a language id, like `javascript` or
	 * a more complex [filter](#DocumentFilter) like `{ language: 'typescript', scheme: 'file' }`. Matching a document against such
	 * a selector will result in a [score](#languages.match) that is used to determine if and how a provider shall be used. When
	 * scores are equal the provider that came last wins. For features that allow full arity, like [hover](#languages.registerHoverProvider),
	 * the score is only checked to be `>0`, for other features, like [IntelliSense](#languages.registerCompletionItemProvider) the
	 * score is used for determining the order in which providers are asked to participate.
	 */
  export namespace languages {

		/**
		 * Return the identifiers of all known languages.
		 * @return Promise resolving to an array of identifier strings.
		 */
    export function getLanguages(): Thenable<string[]>;

		/**
		 * Compute the match between a document [selector](#DocumentSelector) and a document. Values
		 * greater than zero mean the selector matches the document.
		 *
		 * A match is computed according to these rules:
		 * 1. When [`DocumentSelector`](#DocumentSelector) is an array, compute the match for each contained `DocumentFilter` or language identifier and take the maximum value.
		 * 2. A string will be desugared to become the `language`-part of a [`DocumentFilter`](#DocumentFilter), so `"fooLang"` is like `{ language: "fooLang" }`.
		 * 3. A [`DocumentFilter`](#DocumentFilter) will be matched against the document by comparing its parts with the document. The following rules apply:
		 *  1. When the `DocumentFilter` is empty (`{}`) the result is `0`
		 *  2. When `scheme`, `language`, or `pattern` are defined but one doesn’t match, the result is `0`
		 *  3. Matching against `*` gives a score of `5`, matching via equality or via a glob-pattern gives a score of `10`
		 *  4. The result is the maximun value of each match
		 *
		 * Samples:
		 * ```js
		 * // default document from disk (file-scheme)
		 * doc.uri; //'file:///my/file.js'
		 * doc.languageId; // 'javascript'
		 * match('javascript', doc); // 10;
		 * match({language: 'javascript'}, doc); // 10;
		 * match({language: 'javascript', scheme: 'file'}, doc); // 10;
		 * match('*', doc); // 5
		 * match('fooLang', doc); // 0
		 * match(['fooLang', '*'], doc); // 5
		 *
		 * // virtual document, e.g. from git-index
		 * doc.uri; // 'git:/my/file.js'
		 * doc.languageId; // 'javascript'
		 * match('javascript', doc); // 10;
		 * match({language: 'javascript', scheme: 'git'}, doc); // 10;
		 * match('*', doc); // 5
		 * ```
		 *
		 * @param selector A document selector.
		 * @param document A text document.
		 * @return A number `>0` when the selector matches and `0` when the selector does not match.
		 */
    export function match(selector: DocumentSelector, document: TextDocument): number;

		/**
		 * Create a diagnostics collection.
		 *
		 * @param name The [name](#DiagnosticCollection.name) of the collection.
		 * @return A new diagnostic collection.
		 */
    export function createDiagnosticCollection(name?: string): DiagnosticCollection;

		/**
		 * Register a completion provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and groups of equal score are sequentially asked for
		 * completion items. The process stops when one or many providers of a group return a
		 * result. A failing provider (rejected promise or exception) will not fail the whole
		 * operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A completion provider.
		 * @param triggerCharacters Trigger completion when the user types one of the characters, like `.` or `:`.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerCompletionItemProvider(selector: DocumentSelector, provider: CompletionItemProvider, ...triggerCharacters: string[]): Disposable;

		/**
		 * Register a code action provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A code action provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerCodeActionsProvider(selector: DocumentSelector, provider: CodeActionProvider): Disposable;

		/**
		 * Register a code lens provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A code lens provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerCodeLensProvider(selector: DocumentSelector, provider: CodeLensProvider): Disposable;

		/**
		 * Register a definition provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A definition provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDefinitionProvider(selector: DocumentSelector, provider: DefinitionProvider): Disposable;

		/**
		 * Register an implementation provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider An implementation provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerImplementationProvider(selector: DocumentSelector, provider: ImplementationProvider): Disposable;

		/**
		 * Register a type definition provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A type definition provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerTypeDefinitionProvider(selector: DocumentSelector, provider: TypeDefinitionProvider): Disposable;

		/**
		 * Register a hover provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A hover provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerHoverProvider(selector: DocumentSelector, provider: HoverProvider): Disposable;

		/**
		 * Register a document highlight provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and groups sequentially asked for document highlights.
		 * The process stops when a provider returns a `non-falsy` or `non-failure` result.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A document highlight provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDocumentHighlightProvider(selector: DocumentSelector, provider: DocumentHighlightProvider): Disposable;

		/**
		 * Register a document symbol provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A document symbol provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDocumentSymbolProvider(selector: DocumentSelector, provider: DocumentSymbolProvider): Disposable;

		/**
		 * Register a workspace symbol provider.
		 *
		 * Multiple providers can be registered. In that case providers are asked in parallel and
		 * the results are merged. A failing provider (rejected promise or exception) will not cause
		 * a failure of the whole operation.
		 *
		 * @param provider A workspace symbol provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerWorkspaceSymbolProvider(provider: WorkspaceSymbolProvider): Disposable;

		/**
		 * Register a reference provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A reference provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerReferenceProvider(selector: DocumentSelector, provider: ReferenceProvider): Disposable;

		/**
		 * Register a reference provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and the best-matching provider is used. Failure
		 * of the selected provider will cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A rename provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerRenameProvider(selector: DocumentSelector, provider: RenameProvider): Disposable;

		/**
		 * Register a formatting provider for a document.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and the best-matching provider is used. Failure
		 * of the selected provider will cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A document formatting edit provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDocumentFormattingEditProvider(selector: DocumentSelector, provider: DocumentFormattingEditProvider): Disposable;

		/**
		 * Register a formatting provider for a document range.
		 *
		 * *Note:* A document range provider is also a [document formatter](#DocumentFormattingEditProvider)
		 * which means there is no need to [register](registerDocumentFormattingEditProvider) a document
		 * formatter when also registering a range provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and the best-matching provider is used. Failure
		 * of the selected provider will cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A document range formatting edit provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDocumentRangeFormattingEditProvider(selector: DocumentSelector, provider: DocumentRangeFormattingEditProvider): Disposable;

		/**
		 * Register a formatting provider that works on type. The provider is active when the user enables the setting `editor.formatOnType`.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and the best-matching provider is used. Failure
		 * of the selected provider will cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider An on type formatting edit provider.
		 * @param firstTriggerCharacter A character on which formatting should be triggered, like `}`.
		 * @param moreTriggerCharacter More trigger characters.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerOnTypeFormattingEditProvider(selector: DocumentSelector, provider: OnTypeFormattingEditProvider, firstTriggerCharacter: string, ...moreTriggerCharacter: string[]): Disposable;

		/**
		 * Register a signature help provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are sorted
		 * by their [score](#languages.match) and called sequentially until a provider returns a
		 * valid result.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A signature help provider.
		 * @param triggerCharacters Trigger signature help when the user types one of the characters, like `,` or `(`.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerSignatureHelpProvider(selector: DocumentSelector, provider: SignatureHelpProvider, ...triggerCharacters: string[]): Disposable;

		/**
		 * Register a document link provider.
		 *
		 * Multiple providers can be registered for a language. In that case providers are asked in
		 * parallel and the results are merged. A failing provider (rejected promise or exception) will
		 * not cause a failure of the whole operation.
		 *
		 * @param selector A selector that defines the documents this provider is applicable to.
		 * @param provider A document link provider.
		 * @return A [disposable](#Disposable) that unregisters this provider when being disposed.
		 */
    export function registerDocumentLinkProvider(selector: DocumentSelector, provider: DocumentLinkProvider): Disposable;

		/**
		 * Set a [language configuration](#LanguageConfiguration) for a language.
		 *
		 * @param language A language identifier like `typescript`.
		 * @param configuration Language configuration.
		 * @return A [disposable](#Disposable) that unsets this configuration.
		 */
    export function setLanguageConfiguration(language: string, configuration: LanguageConfiguration): Disposable;
  }

	/**
	 * Represents the input box in the Source Control viewlet.
	 */
  export interface SourceControlInputBox {

		/**
		 * Setter and getter for the contents of the input box.
		 */
    value: string;
  }

  interface QuickDiffProvider {

		/**
		 * Provide a [uri](#Uri) to the original resource of any given resource uri.
		 *
		 * @param uri The uri of the resource open in a text editor.
		 * @param token A cancellation token.
		 * @return A thenable that resolves to uri of the matching original resource.
		 */
    provideOriginalResource?(uri: Uri, token: CancellationToken): ProviderResult<Uri>;
  }

	/**
	 * The theme-aware decorations for a
	 * [source control resource state](#SourceControlResourceState).
	 */
  export interface SourceControlResourceThemableDecorations {

		/**
		 * The icon path for a specific
		 * [source control resource state](#SourceControlResourceState).
		 */
    readonly iconPath?: string | Uri;
  }

	/**
	 * The decorations for a [source control resource state](#SourceControlResourceState).
	 * Can be independently specified for light and dark themes.
	 */
  export interface SourceControlResourceDecorations extends SourceControlResourceThemableDecorations {

		/**
		 * Whether the [source control resource state](#SourceControlResourceState) should
		 * be striked-through in the UI.
		 */
    readonly strikeThrough?: boolean;

		/**
		 * Whether the [source control resource state](#SourceControlResourceState) should
		 * be faded in the UI.
		 */
    readonly faded?: boolean;

		/**
		 * The title for a specific
		 * [source control resource state](#SourceControlResourceState).
		 */
    readonly tooltip?: string;

		/**
		 * The light theme decorations.
		 */
    readonly light?: SourceControlResourceThemableDecorations;

		/**
		 * The dark theme decorations.
		 */
    readonly dark?: SourceControlResourceThemableDecorations;
  }

	/**
	 * An source control resource state represents the state of an underlying workspace
	 * resource within a certain [source control group](#SourceControlResourceGroup).
	 */
  export interface SourceControlResourceState {

		/**
		 * The [uri](#Uri) of the underlying resource inside the workspace.
		 */
    readonly resourceUri: Uri;

		/**
		 * The [command](#Command) which should be run when the resource
		 * state is open in the Source Control viewlet.
		 */
    readonly command?: Command;

		/**
		 * The [decorations](#SourceControlResourceDecorations) for this source control
		 * resource state.
		 */
    readonly decorations?: SourceControlResourceDecorations;
  }

	/**
	 * A source control resource group is a collection of
	 * [source control resource states](#SourceControlResourceState).
	 */
  export interface SourceControlResourceGroup {

		/**
		 * The id of this source control resource group.
		 */
    readonly id: string;

		/**
		 * The label of this source control resource group.
		 */
    label: string;

		/**
		 * Whether this source control resource group is hidden when it contains
		 * no [source control resource states](#SourceControlResourceState).
		 */
    hideWhenEmpty?: boolean;

		/**
		 * This group's collection of
		 * [source control resource states](#SourceControlResourceState).
		 */
    resourceStates: SourceControlResourceState[];

		/**
		 * Dispose this source control resource group.
		 */
    dispose(): void;
  }

	/**
	 * An source control is able to provide [resource states](#SourceControlResourceState)
	 * to the editor and interact with the editor in several source control related ways.
	 */
  export interface SourceControl {

		/**
		 * The id of this source control.
		 */
    readonly id: string;

		/**
		 * The human-readable label of this source control.
		 */
    readonly label: string;

		/**
		 * The [input box](#SourceControlInputBox) for this source control.
		 */
    readonly inputBox: SourceControlInputBox;

		/**
		 * The UI-visible count of [resource states](#SourceControlResourceState) of
		 * this source control.
		 *
		 * Equals to the total number of [resource state](#SourceControlResourceState)
		 * of this source control, if undefined.
		 */
    count?: number;

		/**
		 * An optional [quick diff provider](#QuickDiffProvider).
		 */
    quickDiffProvider?: QuickDiffProvider;

		/**
		 * Optional commit template string.
		 *
		 * The Source Control viewlet will populate the Source Control
		 * input with this value when appropriate.
		 */
    commitTemplate?: string;

		/**
		 * Optional accept input command.
		 *
		 * This command will be invoked when the user accepts the value
		 * in the Source Control input.
		 */
    acceptInputCommand?: Command;

		/**
		 * Optional status bar commands.
		 *
		 * These commands will be displayed in the editor's status bar.
		 */
    statusBarCommands?: Command[];

		/**
		 * Create a new [resource group](#SourceControlResourceGroup).
		 */
    createResourceGroup(id: string, label: string): SourceControlResourceGroup;

		/**
		 * Dispose this source control.
		 */
    dispose(): void;
  }

  export namespace scm {

		/**
		 * ~~The [input box](#SourceControlInputBox) for the last source control
		 * created by the extension.~~
		 *
		 * @deprecated Use [SourceControl.inputBox](#SourceControl.inputBox) instead
		 */
    export const inputBox: SourceControlInputBox;

		/**
		 * Creates a new [source control](#SourceControl) instance.
		 *
		 * @param id An `id` for the source control. Something short, eg: `git`.
		 * @param label A human-readable string for the source control. Eg: `Git`.
		 * @return An instance of [source control](#SourceControl).
		 */
    export function createSourceControl(id: string, label: string): SourceControl;
  }

	/**
	 * Configuration for a debug session.
	 */
  export interface DebugConfiguration {
		/**
		 * The type of the debug session.
		 */
    type: string;

		/**
		 * The name of the debug session.
		 */
    name: string;

		/**
		 * The request type of the debug session.
		 */
    request: string;

		/**
		 * Additional debug type specific properties.
		 */
    [key: string]: any;
  }

	/**
	 * A debug session.
	 */
  export interface DebugSession {

		/**
		 * The unique ID of this debug session.
		 */
    readonly id: string;

		/**
		 * The debug session's type from the [debug configuration](#DebugConfiguration).
		 */
    readonly type: string;

		/**
		 * The debug session's name from the [debug configuration](#DebugConfiguration).
		 */
    readonly name: string;

		/**
		 * Send a custom request to the debug adapter.
		 */
    customRequest(command: string, args?: any): Thenable<any>;
  }

	/**
	 * A custom Debug Adapter Protocol event received from a [debug session](#DebugSession).
	 */
  export interface DebugSessionCustomEvent {
		/**
		 * The [debug session](#DebugSession) for which the custom event was received.
		 */
    session: DebugSession;

		/**
		 * Type of event.
		 */
    event: string;

		/**
		 * Event specific information.
		 */
    body?: any;
  }

	/**
	 * Namespace for dealing with debug sessions.
	 */
  export namespace debug {

		/**
		 * Start debugging by using either a named launch or named compound configuration,
		 * or by directly passing a [DebugConfiguration](#DebugConfiguration).
		 * The named configurations are looked up in '.vscode/launch.json' found in the given folder.
		 * Before debugging starts, all unsaved files are saved and the launch configurations are brought up-to-date.
		 * Folder specific variables used in the configuration (e.g. '${workspaceRoot}') are resolved against the given folder.
		 * @param folder The [workspace folder](#WorkspaceFolder) for looking up named configurations and resolving variables or `undefined` for a non-folder setup.
		 * @param nameOrConfiguration Either the name of a debug or compound configuration or a [DebugConfiguration](#DebugConfiguration) object.
		 * @return A thenable that resolves when debugging could be successfully started.
		 */
    export function startDebugging(folder: WorkspaceFolder | undefined, nameOrConfiguration: string | DebugConfiguration): Thenable<boolean>;

		/**
		 * The currently active [debug session](#DebugSession) or `undefined`. The active debug session is the one
		 * represented by the debug action floating window or the one currently shown in the drop down menu of the debug action floating window.
		 * If no debug session is active, the value is `undefined`.
		 */
    export let activeDebugSession: DebugSession | undefined;

		/**
		 * An [event](#Event) which fires when the [active debug session](#debug.activeDebugSession)
		 * has changed. *Note* that the event also fires when the active debug session changes
		 * to `undefined`.
		 */
    export const onDidChangeActiveDebugSession: Event<DebugSession | undefined>;

		/**
		 * An [event](#Event) which fires when a new [debug session](#DebugSession) has been started.
		 */
    export const onDidStartDebugSession: Event<DebugSession>;

		/**
		 * An [event](#Event) which fires when a custom DAP event is received from the [debug session](#DebugSession).
		 */
    export const onDidReceiveDebugSessionCustomEvent: Event<DebugSessionCustomEvent>;

		/**
		 * An [event](#Event) which fires when a [debug session](#DebugSession) has terminated.
		 */
    export const onDidTerminateDebugSession: Event<DebugSession>;
  }

	/**
	 * Namespace for dealing with installed extensions. Extensions are represented
	 * by an [extension](#Extension)-interface which allows to reflect on them.
	 *
	 * Extension writers can provide APIs to other extensions by returning their API public
	 * surface from the `activate`-call.
	 *
	 * ```javascript
	 * export function activate(context: vscode.ExtensionContext) {
	 * 	let api = {
	 * 		sum(a, b) {
	 * 			return a + b;
	 * 		},
	 * 		mul(a, b) {
	 * 			return a * b;
	 * 		}
	 * 	};
	 * 	// 'export' public api-surface
	 * 	return api;
	 * }
	 * ```
	 * When depending on the API of another extension add an `extensionDependency`-entry
	 * to `package.json`, and use the [getExtension](#extensions.getExtension)-function
	 * and the [exports](#Extension.exports)-property, like below:
	 *
	 * ```javascript
	 * let mathExt = extensions.getExtension('genius.math');
	 * let importedApi = mathExt.exports;
	 *
	 * console.log(importedApi.mul(42, 1));
	 * ```
	 */
  export namespace extensions {

		/**
		 * Get an extension by its full identifier in the form of: `publisher.name`.
		 *
		 * @param extensionId An extension identifier.
		 * @return An extension or `undefined`.
		 */
    export function getExtension(extensionId: string): Extension<any> | undefined;

		/**
		 * Get an extension its full identifier in the form of: `publisher.name`.
		 *
		 * @param extensionId An extension identifier.
		 * @return An extension or `undefined`.
		 */
    export function getExtension<T>(extensionId: string): Extension<T> | undefined;

		/**
		 * All extensions currently known to the system.
		 */
    export let all: Extension<any>[];
  }
}

/**
 * Thenable is a common denominator between ES6 promises, Q, jquery.Deferred, WinJS.Promise,
 * and others. This API makes no assumption about what promise libary is being used which
 * enables reusing existing code without migrating to a specific promise implementation. Still,
 * we recommend the use of native promises which are available in this editor.
 */
interface Thenable<T> {
	/**
	* Attaches callbacks for the resolution and/or rejection of the Promise.
	* @param onfulfilled The callback to execute when the Promise is resolved.
	* @param onrejected The callback to execute when the Promise is rejected.
	* @returns A Promise for the completion of which ever callback is executed.
	*/
  then<TResult>(onfulfilled?: (value: T) => TResult | Thenable<TResult>, onrejected?: (reason: any) => TResult | Thenable<TResult>): Thenable<TResult>;
  then<TResult>(onfulfilled?: (value: T) => TResult | Thenable<TResult>, onrejected?: (reason: any) => void): Thenable<TResult>;
}

interface Thenable<T> extends PromiseLike<T> {
}
declare module 'vscode-jsonrpc/messages' {
	/**
	 * A language server message
	 */
  export interface Message {
    jsonrpc: string;
  }
	/**
	 * Request message
	 */
  export interface RequestMessage extends Message {
    /**
     * The request id.
     */
    id: number | string;
    /**
     * The method to be invoked.
     */
    method: string;
    /**
     * The method's params.
     */
    params?: any;
  }
	/**
	 * Predefined error codes.
	 */
  export namespace ErrorCodes {
    const ParseError: number;
    const InvalidRequest: number;
    const MethodNotFound: number;
    const InvalidParams: number;
    const InternalError: number;
    const serverErrorStart: number;
    const serverErrorEnd: number;
    const ServerNotInitialized: number;
    const UnknownErrorCode: number;
    const RequestCancelled: number;
    const MessageWriteError: number;
    const MessageReadError: number;
  }
  export interface ResponseErrorLiteral<D> {
    /**
     * A number indicating the error type that occured.
     */
    code: number;
    /**
     * A string providing a short decription of the error.
     */
    message: string;
    /**
     * A Primitive or Structured value that contains additional
     * information about the error. Can be omitted.
     */
    data?: D;
  }
	/**
	 * A error object return in a response in case a request
	 * has failed.
	 */
  export class ResponseError<D> extends Error {
    readonly code: number;
    readonly data: D;
    constructor(code: number, message: string, data?: D);
    toJson(): ResponseErrorLiteral<D>;
  }
	/**
	 * A response message.
	 */
  export interface ResponseMessage extends Message {
    /**
     * The request id.
     */
    id: number | string | null;
    /**
     * The result of a request. This can be omitted in
     * the case of an error.
     */
    result?: any;
    /**
     * The error object in case a request fails.
     */
    error?: ResponseErrorLiteral<any>;
  }
	/**
	 * An interface to type messages.
	 */
  export interface MessageType {
    readonly method: string;
    readonly numberOfParams: number;
  }
	/**
	 * An abstract implementation of a MessageType.
	 */
  export abstract class AbstractMessageType implements MessageType {
    private _method;
    private _numberOfParams;
    constructor(_method: string, _numberOfParams: number);
    readonly method: string;
    readonly numberOfParams: number;
  }
	/**
	 * End marker interface for request and notification types.
	 */
  export interface _EM {
    _$endMarker$_: number;
  }
	/**
	 * Classes to type request response pairs
	 */
  export class RequestType0<R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType<P, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType1<P1, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType2<P1, P2, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType3<P1, P2, P3, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType4<P1, P2, P3, P4, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType5<P1, P2, P3, P4, P5, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType6<P1, P2, P3, P4, P5, P6, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType7<P1, P2, P3, P4, P5, P6, P7, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType8<P1, P2, P3, P4, P5, P6, P7, P8, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class RequestType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
	/**
	 * Notification Message
	 */
  export interface NotificationMessage extends Message {
    /**
     * The method to be invoked.
     */
    method: string;
    /**
     * The notification's params.
     */
    params?: any;
  }
  export class NotificationType<P, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType0<RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType1<P1, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType2<P1, P2, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType3<P1, P2, P3, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType4<P1, P2, P3, P4, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType5<P1, P2, P3, P4, P5, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType6<P1, P2, P3, P4, P5, P6, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType7<P1, P2, P3, P4, P5, P6, P7, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType8<P1, P2, P3, P4, P5, P6, P7, P8, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
  export class NotificationType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, RO> extends AbstractMessageType {
    private _?;
    constructor(method: string);
  }
	/**
	 * Tests if the given message is a request message
	 */
  export function isRequestMessage(message: Message | undefined): message is RequestMessage;
	/**
	 * Tests if the given message is a notification message
	 */
  export function isNotificationMessage(message: Message | undefined): message is NotificationMessage;
	/**
	 * Tests if the given message is a response message
	 */
  export function isResponseMessage(message: Message | undefined): message is ResponseMessage;

}
declare module 'vscode-jsonrpc/events' {
  export interface Disposable {
    /**
     * Dispose this object.
     */
    dispose(): void;
  }
  export namespace Disposable {
    function create(func: () => void): Disposable;
  }
	/**
	 * Represents a typed event.
	 */
  export interface Event<T> {
    /**
     *
     * @param listener The listener function will be call when the event happens.
     * @param thisArgs The 'this' which will be used when calling the event listener.
     * @param disposables An array to which a {{IDisposable}} will be added. The
     * @return
    */
    (listener: (e: T) => any, thisArgs?: any, disposables?: Disposable[]): Disposable;
  }
  export namespace Event {
    const None: Event<any>;
  }
  export interface EmitterOptions {
    onFirstListenerAdd?: Function;
    onLastListenerRemove?: Function;
  }
  export class Emitter<T> {
    private _options;
    private static _noop;
    private _event;
    private _callbacks;
    constructor(_options?: EmitterOptions | undefined);
    /**
     * For the public to allow to subscribe
     * to events from this Emitter
     */
    readonly event: Event<T>;
    /**
     * To be kept private to fire an event to
     * subscribers
     */
    fire(event: T): any;
    dispose(): void;
  }

}
declare module 'vscode-jsonrpc/messageReader' {
  /// <reference types="node" />
  import { Socket } from 'net';
  import { ChildProcess } from 'child_process';
  import { Message } from 'vscode-jsonrpc/messages';
  import { Event } from 'vscode-jsonrpc/events';
  export interface DataCallback {
    (data: Message): void;
  }
  export interface PartialMessageInfo {
    readonly messageToken: number;
    readonly waitingTime: number;
  }
  export interface MessageReader {
    readonly onError: Event<Error>;
    readonly onClose: Event<void>;
    readonly onPartialMessage: Event<PartialMessageInfo>;
    listen(callback: DataCallback): void;
    dispose(): void;
  }
  export namespace MessageReader {
    function is(value: any): value is MessageReader;
  }
  export abstract class AbstractMessageReader {
    private errorEmitter;
    private closeEmitter;
    private partialMessageEmitter;
    constructor();
    dispose(): void;
    readonly onError: Event<Error>;
    protected fireError(error: any): void;
    readonly onClose: Event<void>;
    protected fireClose(): void;
    readonly onPartialMessage: Event<PartialMessageInfo>;
    protected firePartialMessage(info: PartialMessageInfo): void;
    private asError(error);
  }
  export class StreamMessageReader extends AbstractMessageReader implements MessageReader {
    private readable;
    private callback;
    private buffer;
    private nextMessageLength;
    private messageToken;
    private partialMessageTimer;
    private _partialMessageTimeout;
    constructor(readable: NodeJS.ReadableStream, encoding?: string);
    partialMessageTimeout: number;
    listen(callback: DataCallback): void;
    private onData(data);
    private clearPartialMessageTimer();
    private setPartialMessageTimer();
  }
  export class IPCMessageReader extends AbstractMessageReader implements MessageReader {
    private process;
    constructor(process: NodeJS.Process | ChildProcess);
    listen(callback: DataCallback): void;
  }
  export class SocketMessageReader extends StreamMessageReader {
    constructor(socket: Socket, encoding?: string);
  }

}
declare module 'vscode-jsonrpc/messageWriter' {
  /// <reference types="node" />
  import { ChildProcess } from 'child_process';
  import { Socket } from 'net';
  import { Message } from 'vscode-jsonrpc/messages';
  import { Event } from 'vscode-jsonrpc/events';
  export interface MessageWriter {
    readonly onError: Event<[Error, Message | undefined, number | undefined]>;
    readonly onClose: Event<void>;
    write(msg: Message): void;
    dispose(): void;
  }
  export namespace MessageWriter {
    function is(value: any): value is MessageWriter;
  }
  export abstract class AbstractMessageWriter {
    private errorEmitter;
    private closeEmitter;
    constructor();
    dispose(): void;
    readonly onError: Event<[Error, Message | undefined, number | undefined]>;
    protected fireError(error: any, message?: Message, count?: number): void;
    readonly onClose: Event<void>;
    protected fireClose(): void;
    private asError(error);
  }
  export class StreamMessageWriter extends AbstractMessageWriter implements MessageWriter {
    private writable;
    private encoding;
    private errorCount;
    constructor(writable: NodeJS.WritableStream, encoding?: string);
    write(msg: Message): void;
  }
  export class IPCMessageWriter extends AbstractMessageWriter implements MessageWriter {
    private process;
    private queue;
    private sending;
    private errorCount;
    constructor(process: NodeJS.Process | ChildProcess);
    write(msg: Message): void;
    doWriteMessage(msg: Message): void;
  }
  export class SocketMessageWriter extends AbstractMessageWriter implements MessageWriter {
    private socket;
    private queue;
    private sending;
    private encoding;
    private errorCount;
    constructor(socket: Socket, encoding?: string);
    write(msg: Message): void;
    doWriteMessage(msg: Message): void;
    private handleError(error, msg);
  }

}
declare module 'vscode-jsonrpc/cancellation' {
  import { Event } from 'vscode-jsonrpc/events';
	/**
	 * Defines a CancellationToken. This interface is not
	 * intended to be implemented. A CancellationToken must
	 * be created via a CancellationTokenSource.
	 */
  export interface CancellationToken {
    /**
     * Is `true` when the token has been cancelled, `false` otherwise.
     */
    readonly isCancellationRequested: boolean;
    /**
     * An [event](#Event) which fires upon cancellation.
     */
    readonly onCancellationRequested: Event<any>;
  }
  export namespace CancellationToken {
    const None: CancellationToken;
    const Cancelled: CancellationToken;
    function is(value: any): value is CancellationToken;
  }
  export class CancellationTokenSource {
    private _token;
    readonly token: CancellationToken;
    cancel(): void;
    dispose(): void;
  }

}
declare module 'vscode-jsonrpc/linkedMap' {
  export namespace Touch {
    const None: 0;
    const First: 1;
    const Last: 2;
  }
  export type Touch = 0 | 1 | 2;
  export class LinkedMap<K, V> {
    private _map;
    private _head;
    private _tail;
    private _size;
    constructor();
    clear(): void;
    isEmpty(): boolean;
    readonly size: number;
    has(key: K): boolean;
    get(key: K): V | undefined;
    set(key: K, value: V, touch?: Touch): void;
    delete(key: K): boolean;
    shift(): V | undefined;
    forEach(callbackfn: (value: V, key: K, map: LinkedMap<K, V>) => void, thisArg?: any): void;
    forEachReverse(callbackfn: (value: V, key: K, map: LinkedMap<K, V>) => void, thisArg?: any): void;
    values(): V[];
    keys(): K[];
    private addItemFirst(item);
    private addItemLast(item);
    private removeItem(item);
    private touch(item, touch);
  }

}
declare module 'vscode-jsonrpc/pipeSupport' {
  import { MessageReader } from 'vscode-jsonrpc/messageReader';
  import { MessageWriter } from 'vscode-jsonrpc/messageWriter';
  export function generateRandomPipeName(): string;
  export interface PipeTransport {
    onConnected(): Thenable<[MessageReader, MessageWriter]>;
  }
  export function createClientPipeTransport(pipeName: string, encoding?: string): Thenable<PipeTransport>;
  export function createServerPipeTransport(pipeName: string, encoding?: string): [MessageReader, MessageWriter];

}
declare module 'vscode-jsonrpc' {
  /// <reference path="thenable.d.ts" />
  /// <reference types="node" />
  import { Message, MessageType, RequestMessage, RequestType, RequestType0, RequestType1, RequestType2, RequestType3, RequestType4, RequestType5, RequestType6, RequestType7, RequestType8, RequestType9, ResponseMessage, ResponseError, ErrorCodes, NotificationMessage, NotificationType, NotificationType0, NotificationType1, NotificationType2, NotificationType3, NotificationType4, NotificationType5, NotificationType6, NotificationType7, NotificationType8, NotificationType9 } from 'vscode-jsonrpc/messages';
  import { MessageReader, DataCallback, StreamMessageReader, IPCMessageReader, SocketMessageReader } from 'vscode-jsonrpc/messageReader';
  import { MessageWriter, StreamMessageWriter, IPCMessageWriter, SocketMessageWriter } from 'vscode-jsonrpc/messageWriter';
  import { Disposable, Event, Emitter } from 'vscode-jsonrpc/events';
  import { CancellationTokenSource, CancellationToken } from 'vscode-jsonrpc/cancellation';
  import { LinkedMap } from 'vscode-jsonrpc/linkedMap';
  export { Message, MessageType, ErrorCodes, ResponseError, RequestMessage, RequestType, RequestType0, RequestType1, RequestType2, RequestType3, RequestType4, RequestType5, RequestType6, RequestType7, RequestType8, RequestType9, NotificationMessage, NotificationType, NotificationType0, NotificationType1, NotificationType2, NotificationType3, NotificationType4, NotificationType5, NotificationType6, NotificationType7, NotificationType8, NotificationType9, MessageReader, DataCallback, StreamMessageReader, IPCMessageReader, SocketMessageReader, MessageWriter, StreamMessageWriter, IPCMessageWriter, SocketMessageWriter, CancellationTokenSource, CancellationToken, Disposable, Event, Emitter };
  export * from 'vscode-jsonrpc/pipeSupport';
  export type HandlerResult<R, E> = R | ResponseError<E> | Thenable<R> | Thenable<ResponseError<E>>;
  export interface StarRequestHandler {
    (method: string, ...params: any[]): HandlerResult<any, any>;
  }
  export interface GenericRequestHandler<R, E> {
    (...params: any[]): HandlerResult<R, E>;
  }
  export interface RequestHandler0<R, E> {
    (token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler<P, R, E> {
    (params: P, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler1<P1, R, E> {
    (p1: P1, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler2<P1, P2, R, E> {
    (p1: P1, p2: P2, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler3<P1, P2, P3, R, E> {
    (p1: P1, p2: P2, p3: P3, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler4<P1, P2, P3, P4, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler5<P1, P2, P3, P4, P5, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler6<P1, P2, P3, P4, P5, P6, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler7<P1, P2, P3, P4, P5, P6, P7, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler8<P1, P2, P3, P4, P5, P6, P7, P8, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface RequestHandler9<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, p9: P9, token: CancellationToken): HandlerResult<R, E>;
  }
  export interface StarNotificationHandler {
    (method: string, ...params: any[]): void;
  }
  export interface GenericNotificationHandler {
    (...params: any[]): void;
  }
  export interface NotificationHandler0 {
    (): void;
  }
  export interface NotificationHandler<P> {
    (params: P): void;
  }
  export interface NotificationHandler1<P1> {
    (p1: P1): void;
  }
  export interface NotificationHandler2<P1, P2> {
    (p1: P1, p2: P2): void;
  }
  export interface NotificationHandler3<P1, P2, P3> {
    (p1: P1, p2: P2, p3: P3): void;
  }
  export interface NotificationHandler4<P1, P2, P3, P4> {
    (p1: P1, p2: P2, p3: P3, p4: P4): void;
  }
  export interface NotificationHandler5<P1, P2, P3, P4, P5> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5): void;
  }
  export interface NotificationHandler6<P1, P2, P3, P4, P5, P6> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6): void;
  }
  export interface NotificationHandler7<P1, P2, P3, P4, P5, P6, P7> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7): void;
  }
  export interface NotificationHandler8<P1, P2, P3, P4, P5, P6, P7, P8> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8): void;
  }
  export interface NotificationHandler9<P1, P2, P3, P4, P5, P6, P7, P8, P9> {
    (p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, p9: P9): void;
  }
  export interface Logger {
    error(message: string): void;
    warn(message: string): void;
    info(message: string): void;
    log(message: string): void;
  }
  export enum Trace {
    Off = 0,
    Messages = 1,
    Verbose = 2,
  }
  export type TraceValues = 'off' | 'messages' | 'verbose';
  export namespace Trace {
    function fromString(value: string): Trace;
    function toString(value: Trace): TraceValues;
  }
  export interface SetTraceParams {
    value: TraceValues;
  }
  export namespace SetTraceNotification {
    const type: NotificationType<SetTraceParams, void>;
  }
  export interface LogTraceParams {
    message: string;
    verbose?: string;
  }
  export namespace LogTraceNotification {
    const type: NotificationType<LogTraceParams, void>;
  }
  export interface Tracer {
    log(message: string, data?: string): void;
  }
  export enum ConnectionErrors {
    /**
     * The connection is closed.
     */
    Closed = 1,
    /**
     * The connection got disposed.
     */
    Disposed = 2,
    /**
     * The connection is already in listening mode.
     */
    AlreadyListening = 3,
  }
  export class ConnectionError extends Error {
    readonly code: ConnectionErrors;
    constructor(code: ConnectionErrors, message: string);
  }
  export type MessageQueue = LinkedMap<string, Message>;
  export type ConnectionStrategy = {
    cancelUndispatched?: (message: Message, next: (message: Message) => ResponseMessage | undefined) => ResponseMessage | undefined;
  };
  export namespace ConnectionStrategy {
    function is(value: any): value is ConnectionStrategy;
  }
  export interface MessageConnection {
    sendRequest<R, E, RO>(type: RequestType0<R, E, RO>, token?: CancellationToken): Thenable<R>;
    sendRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, params: P, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, R, E, RO>(type: RequestType1<P1, R, E, RO>, p1: P1, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, R, E, RO>(type: RequestType2<P1, P2, R, E, RO>, p1: P1, p2: P2, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, R, E, RO>(type: RequestType3<P1, P2, P3, R, E, RO>, p1: P1, p2: P2, p3: P3, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, R, E, RO>(type: RequestType4<P1, P2, P3, P4, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, P5, R, E, RO>(type: RequestType5<P1, P2, P3, P4, P5, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, P5, P6, R, E, RO>(type: RequestType6<P1, P2, P3, P4, P5, P6, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, P5, P6, P7, R, E, RO>(type: RequestType7<P1, P2, P3, P4, P5, P6, P7, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, P5, P6, P7, P8, R, E, RO>(type: RequestType8<P1, P2, P3, P4, P5, P6, P7, P8, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, token?: CancellationToken): Thenable<R>;
    sendRequest<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E, RO>(type: RequestType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, p9: P9, token?: CancellationToken): Thenable<R>;
    sendRequest<R>(method: string, ...params: any[]): Thenable<R>;
    onRequest<R, E, RO>(type: RequestType0<R, E, RO>, handler: RequestHandler0<R, E>): void;
    onRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, handler: RequestHandler<P, R, E>): void;
    onRequest<P1, R, E, RO>(type: RequestType1<P1, R, E, RO>, handler: RequestHandler1<P1, R, E>): void;
    onRequest<P1, P2, R, E, RO>(type: RequestType2<P1, P2, R, E, RO>, handler: RequestHandler2<P1, P2, R, E>): void;
    onRequest<P1, P2, P3, R, E, RO>(type: RequestType3<P1, P2, P3, R, E, RO>, handler: RequestHandler3<P1, P2, P3, R, E>): void;
    onRequest<P1, P2, P3, P4, R, E, RO>(type: RequestType4<P1, P2, P3, P4, R, E, RO>, handler: RequestHandler4<P1, P2, P3, P4, R, E>): void;
    onRequest<P1, P2, P3, P4, P5, R, E, RO>(type: RequestType5<P1, P2, P3, P4, P5, R, E, RO>, handler: RequestHandler5<P1, P2, P3, P4, P5, R, E>): void;
    onRequest<P1, P2, P3, P4, P5, P6, R, E, RO>(type: RequestType6<P1, P2, P3, P4, P5, P6, R, E, RO>, handler: RequestHandler6<P1, P2, P3, P4, P5, P6, R, E>): void;
    onRequest<P1, P2, P3, P4, P5, P6, P7, R, E, RO>(type: RequestType7<P1, P2, P3, P4, P5, P6, P7, R, E, RO>, handler: RequestHandler7<P1, P2, P3, P4, P5, P6, P7, R, E>): void;
    onRequest<P1, P2, P3, P4, P5, P6, P7, P8, R, E, RO>(type: RequestType8<P1, P2, P3, P4, P5, P6, P7, P8, R, E, RO>, handler: RequestHandler8<P1, P2, P3, P4, P5, P6, P7, P8, R, E>): void;
    onRequest<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E, RO>(type: RequestType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E, RO>, handler: RequestHandler9<P1, P2, P3, P4, P5, P6, P7, P8, P9, R, E>): void;
    onRequest<R, E>(method: string, handler: GenericRequestHandler<R, E>): void;
    onRequest(handler: StarRequestHandler): void;
    sendNotification<RO>(type: NotificationType0<RO>): void;
    sendNotification<P, RO>(type: NotificationType<P, RO>, params?: P): void;
    sendNotification<P1, RO>(type: NotificationType1<P1, RO>, p1: P1): void;
    sendNotification<P1, P2, RO>(type: NotificationType2<P1, P2, RO>, p1: P1, p2: P2): void;
    sendNotification<P1, P2, P3, RO>(type: NotificationType3<P1, P2, P3, RO>, p1: P1, p2: P2, p3: P3): void;
    sendNotification<P1, P2, P3, P4, RO>(type: NotificationType4<P1, P2, P3, P4, RO>, p1: P1, p2: P2, p3: P3, p4: P4): void;
    sendNotification<P1, P2, P3, P4, P5, RO>(type: NotificationType5<P1, P2, P3, P4, P5, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5): void;
    sendNotification<P1, P2, P3, P4, P5, P6, RO>(type: NotificationType6<P1, P2, P3, P4, P5, P6, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6): void;
    sendNotification<P1, P2, P3, P4, P5, P6, P7, RO>(type: NotificationType7<P1, P2, P3, P4, P5, P6, P7, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7): void;
    sendNotification<P1, P2, P3, P4, P5, P6, P7, P8, RO>(type: NotificationType8<P1, P2, P3, P4, P5, P6, P7, P8, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8): void;
    sendNotification<P1, P2, P3, P4, P5, P6, P7, P8, P9, RO>(type: NotificationType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, RO>, p1: P1, p2: P2, p3: P3, p4: P4, p5: P5, p6: P6, p7: P7, p8: P8, p9: P9): void;
    sendNotification(method: string, ...params: any[]): void;
    onNotification<RO>(type: NotificationType0<RO>, handler: NotificationHandler0): void;
    onNotification<P, RO>(type: NotificationType<P, RO>, handler: NotificationHandler<P>): void;
    onNotification<P1, RO>(type: NotificationType1<P1, RO>, handler: NotificationHandler1<P1>): void;
    onNotification<P1, P2, RO>(type: NotificationType2<P1, P2, RO>, handler: NotificationHandler2<P1, P2>): void;
    onNotification<P1, P2, P3, RO>(type: NotificationType3<P1, P2, P3, RO>, handler: NotificationHandler3<P1, P2, P3>): void;
    onNotification<P1, P2, P3, P4, RO>(type: NotificationType4<P1, P2, P3, P4, RO>, handler: NotificationHandler4<P1, P2, P3, P4>): void;
    onNotification<P1, P2, P3, P4, P5, RO>(type: NotificationType5<P1, P2, P3, P4, P5, RO>, handler: NotificationHandler5<P1, P2, P3, P4, P5>): void;
    onNotification<P1, P2, P3, P4, P5, P6, RO>(type: NotificationType6<P1, P2, P3, P4, P5, P6, RO>, handler: NotificationHandler6<P1, P2, P3, P4, P5, P6>): void;
    onNotification<P1, P2, P3, P4, P5, P6, P7, RO>(type: NotificationType7<P1, P2, P3, P4, P5, P6, P7, RO>, handler: NotificationHandler7<P1, P2, P3, P4, P5, P6, P7>): void;
    onNotification<P1, P2, P3, P4, P5, P6, P7, P8, RO>(type: NotificationType8<P1, P2, P3, P4, P5, P6, P7, P8, RO>, handler: NotificationHandler8<P1, P2, P3, P4, P5, P6, P7, P8>): void;
    onNotification<P1, P2, P3, P4, P5, P6, P7, P8, P9, RO>(type: NotificationType9<P1, P2, P3, P4, P5, P6, P7, P8, P9, RO>, handler: NotificationHandler9<P1, P2, P3, P4, P5, P6, P7, P8, P9>): void;
    onNotification(method: string, handler: GenericNotificationHandler): void;
    onNotification(handler: StarNotificationHandler): void;
    trace(value: Trace, tracer: Tracer, sendNotification?: boolean): void;
    onError: Event<[Error, Message | undefined, number | undefined]>;
    onClose: Event<void>;
    onUnhandledNotification: Event<NotificationMessage>;
    listen(): void;
    onDispose: Event<void>;
    dispose(): void;
    inspect(): void;
  }
  export function createMessageConnection(reader: MessageReader, writer: MessageWriter, logger: Logger, strategy?: ConnectionStrategy): MessageConnection;
  export function createMessageConnection(inputStream: NodeJS.ReadableStream, outputStream: NodeJS.WritableStream, logger: Logger, strategy?: ConnectionStrategy): MessageConnection;

}

declare module 'vscode-languageclient/codeConverter' {
  import * as code from 'vscode';
  import * as proto from 'vscode-languageserver-protocol';
  export interface Converter {
    asUri(uri: code.Uri): string;
    asTextDocumentIdentifier(textDocument: code.TextDocument): proto.TextDocumentIdentifier;
    asOpenTextDocumentParams(textDocument: code.TextDocument): proto.DidOpenTextDocumentParams;
    asChangeTextDocumentParams(textDocument: code.TextDocument): proto.DidChangeTextDocumentParams;
    asChangeTextDocumentParams(event: code.TextDocumentChangeEvent): proto.DidChangeTextDocumentParams;
    asCloseTextDocumentParams(textDocument: code.TextDocument): proto.DidCloseTextDocumentParams;
    asSaveTextDocumentParams(textDocument: code.TextDocument, includeContent?: boolean): proto.DidSaveTextDocumentParams;
    asWillSaveTextDocumentParams(event: code.TextDocumentWillSaveEvent): proto.WillSaveTextDocumentParams;
    asTextDocumentPositionParams(textDocument: code.TextDocument, position: code.Position): proto.TextDocumentPositionParams;
    asWorkerPosition(position: code.Position): proto.Position;
    asPosition(value: code.Position): proto.Position;
    asPosition(value: undefined): undefined;
    asPosition(value: null): null;
    asPosition(value: code.Position | undefined | null): proto.Position | undefined | null;
    asRange(value: code.Range): proto.Range;
    asRange(value: undefined): undefined;
    asRange(value: null): null;
    asRange(value: code.Range | undefined | null): proto.Range | undefined | null;
    asDiagnosticSeverity(value: code.DiagnosticSeverity): number;
    asDiagnostic(item: code.Diagnostic): proto.Diagnostic;
    asDiagnostics(items: code.Diagnostic[]): proto.Diagnostic[];
    asCompletionItem(item: code.CompletionItem): proto.CompletionItem;
    asTextEdit(edit: code.TextEdit): proto.TextEdit;
    asReferenceParams(textDocument: code.TextDocument, position: code.Position, options: {
      includeDeclaration: boolean;
    }): proto.ReferenceParams;
    asCodeActionContext(context: code.CodeActionContext): proto.CodeActionContext;
    asCommand(item: code.Command): proto.Command;
    asCodeLens(item: code.CodeLens): proto.CodeLens;
    asFormattingOptions(item: code.FormattingOptions): proto.FormattingOptions;
    asDocumentSymbolParams(textDocument: code.TextDocument): proto.DocumentSymbolParams;
    asCodeLensParams(textDocument: code.TextDocument): proto.CodeLensParams;
    asDocumentLink(item: code.DocumentLink): proto.DocumentLink;
    asDocumentLinkParams(textDocument: code.TextDocument): proto.DocumentLinkParams;
  }
  export interface URIConverter {
    (value: code.Uri): string;
  }
  export function createConverter(uriConverter?: URIConverter): Converter;

}
declare module 'vscode-languageclient/protocolCompletionItem' {
  import * as code from 'vscode';
  export default class ProtocolCompletionItem extends code.CompletionItem {
    data: any;
    fromEdit: boolean;
    constructor(label: string);
  }

}
declare module 'vscode-languageclient/protocolConverter' {
  import * as code from 'vscode';
  import * as ls from 'vscode-languageserver-protocol';
  import ProtocolCompletionItem from 'vscode-languageclient/protocolCompletionItem';
  export interface Converter {
    asUri(value: string): code.Uri;
    asDiagnostic(diagnostic: ls.Diagnostic): code.Diagnostic;
    asDiagnostics(diagnostics: ls.Diagnostic[]): code.Diagnostic[];
    asPosition(value: undefined | null): undefined;
    asPosition(value: ls.Position): code.Position;
    asPosition(value: ls.Position | undefined | null): code.Position | undefined;
    asRange(value: undefined | null): undefined;
    asRange(value: ls.Range): code.Range;
    asRange(value: ls.Range | undefined | null): code.Range | undefined;
    asDiagnosticSeverity(value: number | undefined | null): code.DiagnosticSeverity;
    asHover(hover: ls.Hover): code.Hover;
    asHover(hover: undefined | null): undefined;
    asHover(hover: ls.Hover | undefined | null): code.Hover | undefined;
    asCompletionResult(result: ls.CompletionList): code.CompletionList;
    asCompletionResult(result: ls.CompletionItem[]): code.CompletionItem[];
    asCompletionResult(result: undefined | null): undefined;
    asCompletionResult(result: ls.CompletionItem[] | ls.CompletionList | undefined | null): code.CompletionItem[] | code.CompletionList | undefined;
    asCompletionItem(item: ls.CompletionItem): ProtocolCompletionItem;
    asTextEdit(edit: undefined | null): undefined;
    asTextEdit(edit: ls.TextEdit): code.TextEdit;
    asTextEdits(items: ls.TextEdit[]): code.TextEdit[];
    asTextEdits(items: undefined | null): undefined;
    asTextEdits(items: ls.TextEdit[] | undefined | null): code.TextEdit[] | undefined;
    asSignatureHelp(item: undefined | null): undefined;
    asSignatureHelp(item: ls.SignatureHelp): code.SignatureHelp;
    asSignatureHelp(item: ls.SignatureHelp | undefined | null): code.SignatureHelp | undefined;
    asSignatureInformation(item: ls.SignatureInformation): code.SignatureInformation;
    asSignatureInformations(items: ls.SignatureInformation[]): code.SignatureInformation[];
    asParameterInformation(item: ls.ParameterInformation): code.ParameterInformation;
    asParameterInformations(item: ls.ParameterInformation[]): code.ParameterInformation[];
    asDefinitionResult(item: ls.Definition): code.Definition;
    asDefinitionResult(item: undefined | null): undefined;
    asDefinitionResult(item: ls.Definition | undefined | null): code.Definition | undefined;
    asLocation(item: ls.Location): code.Location;
    asLocation(item: undefined | null): undefined;
    asLocation(item: ls.Location | undefined | null): code.Location | undefined;
    asReferences(values: ls.Location[]): code.Location[];
    asReferences(values: undefined | null): code.Location[] | undefined;
    asReferences(values: ls.Location[] | undefined | null): code.Location[] | undefined;
    asDocumentHighlightKind(item: number): code.DocumentHighlightKind;
    asDocumentHighlight(item: ls.DocumentHighlight): code.DocumentHighlight;
    asDocumentHighlights(values: ls.DocumentHighlight[]): code.DocumentHighlight[];
    asDocumentHighlights(values: undefined | null): undefined;
    asDocumentHighlights(values: ls.DocumentHighlight[] | undefined | null): code.DocumentHighlight[] | undefined;
    asSymbolInformation(item: ls.SymbolInformation, uri?: code.Uri): code.SymbolInformation;
    asSymbolInformations(values: ls.SymbolInformation[], uri?: code.Uri): code.SymbolInformation[];
    asSymbolInformations(values: undefined | null, uri?: code.Uri): undefined;
    asSymbolInformations(values: ls.SymbolInformation[] | undefined | null, uri?: code.Uri): code.SymbolInformation[] | undefined;
    asCommand(item: ls.Command): code.Command;
    asCommands(items: ls.Command[]): code.Command[];
    asCommands(items: undefined | null): undefined;
    asCommands(items: ls.Command[] | undefined | null): code.Command[] | undefined;
    asCodeLens(item: ls.CodeLens): code.CodeLens;
    asCodeLens(item: undefined | null): undefined;
    asCodeLens(item: ls.CodeLens | undefined | null): code.CodeLens | undefined;
    asCodeLenses(items: ls.CodeLens[]): code.CodeLens[];
    asCodeLenses(items: undefined | null): undefined;
    asCodeLenses(items: ls.CodeLens[] | undefined | null): code.CodeLens[] | undefined;
    asWorkspaceEdit(item: ls.WorkspaceEdit): code.WorkspaceEdit;
    asWorkspaceEdit(item: undefined | null): undefined;
    asWorkspaceEdit(item: ls.WorkspaceEdit | undefined | null): code.WorkspaceEdit | undefined;
    asDocumentLink(item: ls.DocumentLink): code.DocumentLink;
    asDocumentLinks(items: ls.DocumentLink[]): code.DocumentLink[];
    asDocumentLinks(items: undefined | null): undefined;
    asDocumentLinks(items: ls.DocumentLink[] | undefined | null): code.DocumentLink[] | undefined;
  }
  export interface URIConverter {
    (value: string): code.Uri;
  }
  export function createConverter(uriConverter?: URIConverter): Converter;

}
declare module 'vscode-languageclient/client' {
  import { TextDocumentChangeEvent, TextDocument, Disposable, OutputChannel, FileSystemWatcher as VFileSystemWatcher, DiagnosticCollection, ProviderResult, CancellationToken, Position as VPosition, Location as VLocation, Range as VRange, CompletionItem as VCompletionItem, CompletionList as VCompletionList, SignatureHelp as VSignatureHelp, Definition as VDefinition, DocumentHighlight as VDocumentHighlight, SymbolInformation as VSymbolInformation, CodeActionContext as VCodeActionContext, Command as VCommand, CodeLens as VCodeLens, FormattingOptions as VFormattingOptions, TextEdit as VTextEdit, WorkspaceEdit as VWorkspaceEdit, Hover as VHover, DocumentLink as VDocumentLink, TextDocumentWillSaveEvent, WorkspaceFolder as VWorkspaceFolder } from 'vscode';
  import { Message, RPCMessageType, ResponseError, RequestType, RequestType0, RequestHandler, RequestHandler0, GenericRequestHandler, NotificationType, NotificationType0, NotificationHandler, NotificationHandler0, GenericNotificationHandler, MessageReader, MessageWriter, Trace, Event, ClientCapabilities, InitializeParams, InitializeResult, InitializeError, ServerCapabilities, DocumentSelector } from 'vscode-languageserver-protocol';
  import * as c2p from 'vscode-languageclient/codeConverter';
  import * as p2c from 'vscode-languageclient/protocolConverter';
  export { Converter as Code2ProtocolConverter } from 'vscode-languageclient/codeConverter';
  export { Converter as Protocol2CodeConverter } from 'vscode-languageclient/protocolConverter';
  export * from 'vscode-languageserver-protocol';
  export interface ExecutableOptions {
    cwd?: string;
    stdio?: string | string[];
    env?: any;
    detached?: boolean;
  }
  export interface Executable {
    command: string;
    args?: string[];
    options?: ExecutableOptions;
  }
  export interface ForkOptions {
    cwd?: string;
    env?: any;
    encoding?: string;
    execArgv?: string[];
  }
  export enum TransportKind {
    stdio = 0,
    ipc = 1,
    pipe = 2,
  }
  export interface NodeModule {
    module: string;
    transport?: TransportKind;
    args?: string[];
    runtime?: string;
    options?: ForkOptions;
  }
	/**
	 * An action to be performed when the connection is producing errors.
	 */
  export enum ErrorAction {
    /**
     * Continue running the server.
     */
    Continue = 1,
    /**
     * Shutdown the server.
     */
    Shutdown = 2,
  }
	/**
	 * An action to be performed when the connection to a server got closed.
	 */
  export enum CloseAction {
    /**
     * Don't restart the server. The connection stays closed.
     */
    DoNotRestart = 1,
    /**
     * Restart the server.
     */
    Restart = 2,
  }
	/**
	 * A pluggable error handler that is invoked when the connection is either
	 * producing errors or got closed.
	 */
  export interface ErrorHandler {
    /**
     * An error has occurred while writing or reading from the connection.
     *
     * @param error - the error received
     * @param message - the message to be delivered to the server if know.
     * @param count - a count indicating how often an error is received. Will
     *  be reset if a message got successfully send or received.
     */
    error(error: Error, message: Message, count: number): ErrorAction;
    /**
     * The connection to the server got closed.
     */
    closed(): CloseAction;
  }
  export interface InitializationFailedHandler {
    (error: ResponseError<InitializeError> | Error | any): boolean;
  }
  export interface SynchronizeOptions {
    configurationSection?: string | string[];
    fileEvents?: VFileSystemWatcher | VFileSystemWatcher[];
  }
  export enum RevealOutputChannelOn {
    Info = 1,
    Warn = 2,
    Error = 3,
    Never = 4,
  }
  export interface ProvideCompletionItemsSignature {
    (document: TextDocument, position: VPosition, token: CancellationToken): ProviderResult<VCompletionItem[] | VCompletionList>;
  }
  export interface ResolveCompletionItemSignature {
    (item: VCompletionItem, token: CancellationToken): ProviderResult<VCompletionItem>;
  }
  export interface ProvideHoverSignature {
    (document: TextDocument, position: VPosition, token: CancellationToken): ProviderResult<VHover>;
  }
  export interface ProvideSignatureHelpSignature {
    (document: TextDocument, position: VPosition, token: CancellationToken): ProviderResult<VSignatureHelp>;
  }
  export interface ProvideDefinitionSignature {
    (document: TextDocument, position: VPosition, token: CancellationToken): ProviderResult<VDefinition>;
  }
  export interface ProvideReferencesSignature {
    (document: TextDocument, position: VPosition, options: {
      includeDeclaration: boolean;
    }, token: CancellationToken): ProviderResult<VLocation[]>;
  }
  export interface ProvideDocumentHighlightsSignature {
    (document: TextDocument, position: VPosition, token: CancellationToken): ProviderResult<VDocumentHighlight[]>;
  }
  export interface ProvideDocumentSymbolsSignature {
    (document: TextDocument, token: CancellationToken): ProviderResult<VSymbolInformation[]>;
  }
  export interface ProvideWorkspaceSymbolsSignature {
    (query: string, token: CancellationToken): ProviderResult<VSymbolInformation[]>;
  }
  export interface ProvideCodeActionsSignature {
    (document: TextDocument, range: VRange, context: VCodeActionContext, token: CancellationToken): ProviderResult<VCommand[]>;
  }
  export interface ProvideCodeLensesSignature {
    (document: TextDocument, token: CancellationToken): ProviderResult<VCodeLens[]>;
  }
  export interface ResolveCodeLensSignature {
    (codeLens: VCodeLens, token: CancellationToken): ProviderResult<VCodeLens>;
  }
  export interface ProvideDocumentFormattingEditsSignature {
    (document: TextDocument, options: VFormattingOptions, token: CancellationToken): ProviderResult<VTextEdit[]>;
  }
  export interface ProvideDocumentRangeFormattingEditsSignature {
    (document: TextDocument, range: VRange, options: VFormattingOptions, token: CancellationToken): ProviderResult<VTextEdit[]>;
  }
  export interface ProvideOnTypeFormattingEditsSignature {
    (document: TextDocument, position: VPosition, ch: string, options: VFormattingOptions, token: CancellationToken): ProviderResult<VTextEdit[]>;
  }
  export interface ProvideRenameEditsSignature {
    (document: TextDocument, position: VPosition, newName: string, token: CancellationToken): ProviderResult<VWorkspaceEdit>;
  }
  export interface ProvideDocumentLinksSignature {
    (document: TextDocument, token: CancellationToken): ProviderResult<VDocumentLink[]>;
  }
  export interface ResolveDocumentLinkSignature {
    (link: VDocumentLink, token: CancellationToken): ProviderResult<VDocumentLink>;
  }
  export interface NextSignature<P, R> {
    (data: P, next: (data: P) => R): R;
  }
  export interface DidChangeConfigurationSignature {
    (sections: string[] | undefined): void;
  }
  export interface WorkspaceMiddleware {
    didChangeConfiguration?: (sections: string[] | undefined, next: DidChangeConfigurationSignature) => void;
  }
  export interface Middleware {
    didOpen?: NextSignature<TextDocument, void>;
    didChange?: NextSignature<TextDocumentChangeEvent, void>;
    willSave?: NextSignature<TextDocumentWillSaveEvent, void>;
    willSaveWaitUntil?: NextSignature<TextDocumentWillSaveEvent, Thenable<VTextEdit[]>>;
    didSave?: NextSignature<TextDocument, void>;
    didClose?: NextSignature<TextDocument, void>;
    provideCompletionItem?: (document: TextDocument, position: VPosition, token: CancellationToken, next: ProvideCompletionItemsSignature) => ProviderResult<VCompletionItem[] | VCompletionList>;
    resolveCompletionItem?: (item: VCompletionItem, token: CancellationToken, next: ResolveCompletionItemSignature) => ProviderResult<VCompletionItem>;
    provideHover?: (document: TextDocument, position: VPosition, token: CancellationToken, next: ProvideHoverSignature) => ProviderResult<VHover>;
    provideSignatureHelp?: (document: TextDocument, position: VPosition, token: CancellationToken, next: ProvideSignatureHelpSignature) => ProviderResult<VSignatureHelp>;
    provideDefinition?: (document: TextDocument, position: VPosition, token: CancellationToken, next: ProvideDefinitionSignature) => ProviderResult<VDefinition>;
    provideReferences?: (document: TextDocument, position: VPosition, options: {
      includeDeclaration: boolean;
    }, token: CancellationToken, next: ProvideReferencesSignature) => ProviderResult<VLocation[]>;
    provideDocumentHighlights?: (document: TextDocument, position: VPosition, token: CancellationToken, next: ProvideDocumentHighlightsSignature) => ProviderResult<VDocumentHighlight[]>;
    provideDocumentSymbols?: (document: TextDocument, token: CancellationToken, next: ProvideDocumentSymbolsSignature) => ProviderResult<VSymbolInformation[]>;
    provideWorkspaceSymbols?: (query: string, token: CancellationToken, next: ProvideWorkspaceSymbolsSignature) => ProviderResult<VSymbolInformation[]>;
    provideCodeActions?: (document: TextDocument, range: VRange, context: VCodeActionContext, token: CancellationToken, next: ProvideCodeActionsSignature) => ProviderResult<VCommand[]>;
    provideCodeLenses?: (document: TextDocument, token: CancellationToken, next: ProvideCodeLensesSignature) => ProviderResult<VCodeLens[]>;
    resolveCodeLens?: (codeLens: VCodeLens, token: CancellationToken, next: ResolveCodeLensSignature) => ProviderResult<VCodeLens>;
    provideDocumentFormattingEdits?: (document: TextDocument, options: VFormattingOptions, token: CancellationToken, next: ProvideDocumentFormattingEditsSignature) => ProviderResult<VTextEdit[]>;
    provideDocumentRangeFormattingEdits?: (document: TextDocument, range: VRange, options: VFormattingOptions, token: CancellationToken, next: ProvideDocumentRangeFormattingEditsSignature) => ProviderResult<VTextEdit[]>;
    provideOnTypeFormattingEdits?: (document: TextDocument, position: VPosition, ch: string, options: VFormattingOptions, token: CancellationToken, next: ProvideOnTypeFormattingEditsSignature) => ProviderResult<VTextEdit[]>;
    provideRenameEdits?: (document: TextDocument, position: VPosition, newName: string, token: CancellationToken, next: ProvideRenameEditsSignature) => ProviderResult<VWorkspaceEdit>;
    provideDocumentLinks?: (document: TextDocument, token: CancellationToken, next: ProvideDocumentLinksSignature) => ProviderResult<VDocumentLink[]>;
    resolveDocumentLink?: (link: VDocumentLink, token: CancellationToken, next: ResolveDocumentLinkSignature) => ProviderResult<VDocumentLink>;
    workspace?: WorkspaceMiddleware;
  }
  export interface LanguageClientOptions {
    documentSelector?: DocumentSelector | string[];
    synchronize?: SynchronizeOptions;
    diagnosticCollectionName?: string;
    outputChannel?: OutputChannel;
    outputChannelName?: string;
    revealOutputChannelOn?: RevealOutputChannelOn;
    /**
     * The encoding use to read stdout and stderr. Defaults
     * to 'utf8' if ommitted.
     */
    stdioEncoding?: string;
    initializationOptions?: any | (() => any);
    initializationFailedHandler?: InitializationFailedHandler;
    errorHandler?: ErrorHandler;
    middleware?: Middleware;
    uriConverters?: {
      code2Protocol: c2p.URIConverter;
      protocol2Code: p2c.URIConverter;
    };
    workspaceFolder?: VWorkspaceFolder;
  }
  export enum State {
    Stopped = 1,
    Running = 2,
  }
  export interface StateChangeEvent {
    oldState: State;
    newState: State;
  }
	/**
	 * A static feature. A static feature can't be dynamically activate via the
	 * server. It is wired during the initialize sequence.
	 */
  export interface StaticFeature {
    /**
     * Called to fill the initialize params.
     *
     * @params the initialize params.
     */
    fillInitializeParams?: (params: InitializeParams) => void;
    /**
     * Called to fill in the client capabilities this feature implements.
     *
     * @param capabilities The client capabilities to fill.
     */
    fillClientCapabilities(capabilities: ClientCapabilities): void;
    /**
     * Initialize the feature. This method is called on a feature instance
     * when the client has successfully received the initalize request from
     * the server and before the client sends the initialized notification
     * to the server.
     *
     * @param capabilities the server capabilities
     * @param documentSelector the document selector pass to the client's constuctor.
     *  May be `undefined` if the client was created without a selector.
     */
    initialize(capabilities: ServerCapabilities, documentSelector: DocumentSelector | undefined): void;
  }
  export interface RegistrationData<T> {
    id: string;
    registerOptions: T;
  }
  export interface DynamicFeature<T> {
    /**
     * The message for which this features support dynamic activation / registration.
     */
    messages: RPCMessageType | RPCMessageType[];
    /**
     * Called to fill the initialize params.
     *
     * @params the initialize params.
     */
    fillInitializeParams?: (params: InitializeParams) => void;
    /**
     * Called to fill in the client capabilities this feature implements.
     *
     * @param capabilities The client capabilities to fill.
     */
    fillClientCapabilities(capabilities: ClientCapabilities): void;
    /**
     * Initialize the feature. This method is called on a feature instance
     * when the client has successfully received the initalize request from
     * the server and before the client sends the initialized notification
     * to the server.
     *
     * @param capabilities the server capabilities.
     * @param documentSelector the document selector pass to the client's constuctor.
     *  May be `undefined` if the client was created without a selector.
     */
    initialize(capabilities: ServerCapabilities, documentSelector: DocumentSelector | undefined): void;
    /**
     * Is called when the server send a register request for the given message.
     *
     * @param message the message to register for.
     * @param data additional registration data as defined in the protocol.
     */
    register(message: RPCMessageType, data: RegistrationData<T>): void;
    /**
     * Is called when the server wants to unregister a feature.
     *
     * @param id the id used when registering the feature.
     */
    unregister(id: string): void;
    /**
     * Called when the client is stopped to dispose this feature. Usually a feature
     * unregisters listeners registerd hooked up with the VS Code extension host.
     */
    dispose(): void;
  }
  export interface MessageTransports {
    reader: MessageReader;
    writer: MessageWriter;
  }
  export namespace MessageTransports {
    function is(value: any): value is MessageTransports;
  }
  export abstract class BaseLanguageClient {
    private _id;
    private _name;
    private _clientOptions;
    private _state;
    private _onReady;
    private _onReadyCallbacks;
    private _connectionPromise;
    private _resolvedConnection;
    private _initializeResult;
    private _outputChannel;
    private _disposeOutputChannel;
    private _capabilities;
    private _listeners;
    private _providers;
    private _diagnostics;
    private _fileEvents;
    private _fileEventDelayer;
    private _telemetryEmitter;
    private _stateChangeEmitter;
    private _trace;
    private _tracer;
    private _c2p;
    private _p2c;
    constructor(id: string, name: string, clientOptions: LanguageClientOptions);
    private state;
    private getPublicState();
    readonly initializeResult: InitializeResult | undefined;
    sendRequest<R, E, RO>(type: RequestType0<R, E, RO>, token?: CancellationToken): Thenable<R>;
    sendRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, params: P, token?: CancellationToken): Thenable<R>;
    sendRequest<R>(method: string, token?: CancellationToken): Thenable<R>;
    sendRequest<R>(method: string, param: any, token?: CancellationToken): Thenable<R>;
    onRequest<R, E, RO>(type: RequestType0<R, E, RO>, handler: RequestHandler0<R, E>): void;
    onRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, handler: RequestHandler<P, R, E>): void;
    onRequest<R, E>(method: string, handler: GenericRequestHandler<R, E>): void;
    sendNotification<RO>(type: NotificationType0<RO>): void;
    sendNotification<P, RO>(type: NotificationType<P, RO>, params?: P): void;
    sendNotification(method: string): void;
    sendNotification(method: string, params: any): void;
    onNotification<RO>(type: NotificationType0<RO>, handler: NotificationHandler0): void;
    onNotification<P, RO>(type: NotificationType<P, RO>, handler: NotificationHandler<P>): void;
    onNotification(method: string, handler: GenericNotificationHandler): void;
    readonly clientOptions: LanguageClientOptions;
    readonly protocol2CodeConverter: p2c.Converter;
    readonly code2ProtocolConverter: c2p.Converter;
    readonly onTelemetry: Event<any>;
    readonly onDidChangeState: Event<StateChangeEvent>;
    readonly outputChannel: OutputChannel;
    readonly diagnostics: DiagnosticCollection | undefined;
    createDefaultErrorHandler(): ErrorHandler;
    trace: Trace;
    private data2String(data);
    info(message: string, data?: any): void;
    warn(message: string, data?: any): void;
    error(message: string, data?: any): void;
    private logTrace(message, data?);
    needsStart(): boolean;
    needsStop(): boolean;
    onReady(): Promise<void>;
    private isConnectionActive();
    start(): Disposable;
    private resolveConnection();
    private initialize(connection);
    stop(): Thenable<void>;
    private cleanUp(restart?);
    private notifyFileEvent(event);
    private forceDocumentSync();
    private handleDiagnostics(params);
    protected abstract createMessageTransports(encoding: string): Thenable<MessageTransports>;
    private createConnection();
    protected handleConnectionClosed(): void;
    private handleConnectionError(error, message, count);
    private hookConfigurationChanged(connection);
    private refreshTrace(connection, sendNotification?);
    private hookFileEvents(_connection);
    private readonly _features;
    private readonly _method2Message;
    private readonly _dynamicFeatures;
    registerFeatures(features: (StaticFeature | DynamicFeature<any>)[]): void;
    registerFeature(feature: StaticFeature | DynamicFeature<any>): void;
    private registerBuiltinFeatures();
    private fillInitializeParams(params);
    private computeClientCapabilities();
    private initializeFeatures(_connection);
    private handleRegistrationRequest(params);
    private handleUnregistrationRequest(params);
    private handleApplyWorkspaceEdit(params);
    logFailedRequest(type: RPCMessageType, error: any): void;
  }

}
declare module 'vscode-languageclient/configuration.proposed' {
  import { StaticFeature, BaseLanguageClient } from 'vscode-languageclient/client';
  import { ClientCapabilities, Proposed } from 'vscode-languageserver-protocol';
  export interface ConfigurationMiddleware {
    workspace?: {
      configuration?: Proposed.ConfigurationRequest.MiddlewareSignature;
    };
  }
  export class ConfigurationFeature implements StaticFeature {
    private _client;
    constructor(_client: BaseLanguageClient);
    fillClientCapabilities(capabilities: ClientCapabilities): void;
    initialize(): void;
    private getConfiguration(resource, section);
    private getConfigurationMiddleware();
  }

}
declare module 'vscode-languageclient/workspaceFolders.proposed' {
  import { WorkspaceFoldersChangeEvent as VWorkspaceFoldersChangeEvent } from 'vscode';
  import { DynamicFeature, RegistrationData, BaseLanguageClient, NextSignature } from 'vscode-languageclient/client';
  import { ClientCapabilities, InitializedParams, Proposed, RPCMessageType } from 'vscode-languageserver-protocol';
  export interface WorkspaceFolderMiddleware {
    workspace?: {
      workspaceFolders?: Proposed.WorkspaceFoldersRequest.MiddlewareSignature;
      didChangeWorkspaceFolders?: NextSignature<VWorkspaceFoldersChangeEvent, void>;
    };
  }
  export class WorkspaceFoldersFeature implements DynamicFeature<undefined> {
    private _client;
    private _listeners;
    constructor(_client: BaseLanguageClient);
    readonly messages: RPCMessageType;
    fillInitializeParams(params: InitializedParams): void;
    fillClientCapabilities(capabilities: ClientCapabilities): void;
    initialize(): void;
    register(_message: RPCMessageType, data: RegistrationData<undefined>): void;
    unregister(id: string): void;
    dispose(): void;
    private asProtocol(workspaceFolder);
    private asProtocol(workspaceFolder);
    private getWorkspaceFolderMiddleware();
  }

}
declare module 'vscode-languageclient' {
  /// <reference types="node" />
  import * as cp from 'child_process';
  import ChildProcess = cp.ChildProcess;
  import { BaseLanguageClient, LanguageClientOptions, MessageTransports, StaticFeature, DynamicFeature } from 'vscode-languageclient/client';
  import { Disposable } from 'vscode';
  export * from 'vscode-languageclient/client';
  export interface ExecutableOptions {
    cwd?: string;
    stdio?: string | string[];
    env?: any;
    detached?: boolean;
  }
  export interface Executable {
    command: string;
    args?: string[];
    options?: ExecutableOptions;
  }
  export interface ForkOptions {
    cwd?: string;
    env?: any;
    encoding?: string;
    execArgv?: string[];
  }
  export enum TransportKind {
    stdio = 0,
    ipc = 1,
    pipe = 2,
  }
  export interface NodeModule {
    module: string;
    transport?: TransportKind;
    args?: string[];
    runtime?: string;
    options?: ForkOptions;
  }
  export interface StreamInfo {
    writer: NodeJS.WritableStream;
    reader: NodeJS.ReadableStream;
  }
  export type ServerOptions = Executable | {
    run: Executable;
    debug: Executable;
  } | {
    run: NodeModule;
    debug: NodeModule;
  } | NodeModule | (() => Thenable<ChildProcess | StreamInfo | MessageTransports>);
  export class LanguageClient extends BaseLanguageClient {
    private _serverOptions;
    private _forceDebug;
    private _serverProcess;
    constructor(name: string, serverOptions: ServerOptions, clientOptions: LanguageClientOptions, forceDebug?: boolean);
    constructor(id: string, name: string, serverOptions: ServerOptions, clientOptions: LanguageClientOptions, forceDebug?: boolean);
    stop(): Thenable<void>;
    private checkProcessDied(childProcess);
    protected handleConnectionClosed(): void;
    protected createMessageTransports(encoding: string): Thenable<MessageTransports>;
    registerProposedFeatures(): void;
  }
  export class SettingMonitor {
    private _client;
    private _setting;
    private _listeners;
    constructor(_client: LanguageClient, _setting: string);
    start(): Disposable;
    private onDidChangeConfiguration();
  }
  import * as config from 'vscode-languageclient/configuration.proposed';
  import * as folders from 'vscode-languageclient/workspaceFolders.proposed';
  export namespace ProposedFeatures {
    type ConfigurationFeature = config.ConfigurationFeature;
    const ConfigurationFeature: typeof config.ConfigurationFeature;
    type ConfigurationMiddleware = config.ConfigurationMiddleware;
    type WorkspaceFoldersFeature = folders.WorkspaceFoldersFeature;
    const WorkspaceFoldersFeature: typeof folders.WorkspaceFoldersFeature;
    type WorkspaceFolderMiddleware = folders.WorkspaceFolderMiddleware;
    function createAll(client: BaseLanguageClient): (StaticFeature | DynamicFeature<any>)[];
  }

}

declare module 'vscode-languageserver-protocol/protocol' {
  import { RequestType, RequestType0, NotificationType, NotificationType0 } from 'vscode-jsonrpc';
  import { TextDocumentContentChangeEvent, Position, Range, Location, Diagnostic, Command, TextEdit, WorkspaceEdit, WorkspaceSymbolParams, TextDocumentIdentifier, VersionedTextDocumentIdentifier, TextDocumentItem, TextDocumentSaveReason, CompletionItem, CompletionList, Hover, SignatureHelp, Definition, ReferenceContext, DocumentHighlight, DocumentSymbolParams, SymbolInformation, CodeLens, CodeActionContext, FormattingOptions, DocumentLink } from 'vscode-languageserver-types';
	/**
	 * A document filter denotes a document by different properties like
	 * the [language](#TextDocument.languageId), the [scheme](#Uri.scheme) of
	 * its resource, or a glob-pattern that is applied to the [path](#TextDocument.fileName).
	 *
	 * @sample A language filter that applies to typescript files on disk: `{ language: 'typescript', scheme: 'file' }`
	 * @sample A language filter that applies to all package.json paths: `{ language: 'json', pattern: '**package.json' }`
	 */
  export type DocumentFilter = {
    /** A language id, like `typescript`. */
    language: string;
    /** A Uri [scheme](#Uri.scheme), like `file` or `untitled`. */
    scheme?: string;
    /** A glob pattern, like `*.{ts,js}`. */
    pattern?: string;
  } | {
    /** A language id, like `typescript`. */
    language?: string;
    /** A Uri [scheme](#Uri.scheme), like `file` or `untitled`. */
    scheme: string;
    /** A glob pattern, like `*.{ts,js}`. */
    pattern?: string;
  } | {
    /** A language id, like `typescript`. */
    language?: string;
    /** A Uri [scheme](#Uri.scheme), like `file` or `untitled`. */
    scheme?: string;
    /** A glob pattern, like `*.{ts,js}`. */
    pattern: string;
  };
  export namespace DocumentFilter {
    function is(value: any): value is DocumentFilter;
  }
	/**
	 * A document selector is the combination of one or many document filters.
	 *
	 * @sample `let sel:DocumentSelector = [{ language: 'typescript' }, { language: 'json', pattern: '**∕tsconfig.json' }]`;
	 */
  export type DocumentSelector = (string | DocumentFilter)[];
	/**
	 * General paramters to to regsiter for an notification or to register a provider.
	 */
  export interface Registration {
    /**
     * The id used to register the request. The id can be used to deregister
     * the request again.
     */
    id: string;
    /**
     * The method to register for.
     */
    method: string;
    /**
     * Options necessary for the registration.
     */
    registerOptions?: any;
  }
  export interface RegistrationParams {
    registrations: Registration[];
  }
	/**
	 * The `client/registerCapability` request is sent from the server to the client to register a new capability
	 * handler on the client side.
	 */
  export namespace RegistrationRequest {
    const type: RequestType<RegistrationParams, void, void, void>;
  }
	/**
	 * General parameters to unregister a request or notification.
	 */
  export interface Unregistration {
    /**
     * The id used to unregister the request or notification. Usually an id
     * provided during the register request.
     */
    id: string;
    /**
     * The method to unregister for.
     */
    method: string;
  }
  export interface UnregistrationParams {
    unregisterations: Unregistration[];
  }
	/**
	 * The `client/unregisterCapability` request is sent from the server to the client to unregister a previously registered capability
	 * handler on the client side.
	 */
  export namespace UnregistrationRequest {
    const type: RequestType<UnregistrationParams, void, void, void>;
  }
	/**
	 * A parameter literal used in requests to pass a text document and a position inside that
	 * document.
	 */
  export interface TextDocumentPositionParams {
    /**
     * The text document.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The position inside the text document.
     */
    position: Position;
  }
	/**
	 * Workspace specific client capabilities.
	 */
  export interface WorkspaceClientCapabilities {
    /**
     * The client supports applying batch edits
     * to the workspace by supporting the request
     * 'workspace/applyEdit'
     */
    applyEdit?: boolean;
    /**
     * Capabilities specific to `WorkspaceEdit`s
     */
    workspaceEdit?: {
      /**
       * The client supports versioned document changes in `WorkspaceEdit`s
       */
      documentChanges?: boolean;
    };
    /**
     * Capabilities specific to the `workspace/didChangeConfiguration` notification.
     */
    didChangeConfiguration?: {
      /**
       * Did change configuration notification supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `workspace/didChangeWatchedFiles` notification.
     */
    didChangeWatchedFiles?: {
      /**
       * Did change watched files notification supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `workspace/symbol` request.
     */
    symbol?: {
      /**
       * Symbol request supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `workspace/executeCommand` request.
     */
    executeCommand?: {
      /**
       * Execute command supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
  }
	/**
	 * This is for backwards compatibility. Can be removed when we switch to 4.0.
	 */
  export type WorkspaceClientCapabilites = WorkspaceClientCapabilities;
	/**
	 * Text document specific client capabilities.
	 */
  export interface TextDocumentClientCapabilities {
    /**
     * Defines which synchronization capabilities the client supports.
     */
    synchronization?: {
      /**
       * Whether text document synchronization supports dynamic registration.
       */
      dynamicRegistration?: boolean;
      /**
       * The client supports sending will save notifications.
       */
      willSave?: boolean;
      /**
       * The client supports sending a will save request and
       * waits for a response providing text edits which will
       * be applied to the document before it is saved.
       */
      willSaveWaitUntil?: boolean;
      /**
       * The client supports did save notifications.
       */
      didSave?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/completion`
     */
    completion?: {
      /**
       * Whether completion supports dynamic registration.
       */
      dynamicRegistration?: boolean;
      /**
       * The client supports the following `CompletionItem` specific
       * capabilities.
       */
      completionItem?: {
        /**
         * Client supports snippets as insert text.
         *
         * A snippet can define tab stops and placeholders with `$1`, `$2`
         * and `${3:foo}`. `$0` defines the final tab stop, it defaults to
         * the end of the snippet. Placeholders with equal identifiers are linked,
         * that is typing in one will update others too.
         */
        snippetSupport?: boolean;
      };
    };
    /**
     * Capabilities specific to the `textDocument/hover`
     */
    hover?: {
      /**
       * Whether hover supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/signatureHelp`
     */
    signatureHelp?: {
      /**
       * Whether signature help supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/references`
     */
    references?: {
      /**
       * Whether references supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/documentHighlight`
     */
    documentHighlight?: {
      /**
       * Whether document highlight supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/documentSymbol`
     */
    documentSymbol?: {
      /**
       * Whether document symbol supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/formatting`
     */
    formatting?: {
      /**
       * Whether formatting supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/rangeFormatting`
     */
    rangeFormatting?: {
      /**
       * Whether range formatting supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/onTypeFormatting`
     */
    onTypeFormatting?: {
      /**
       * Whether on type formatting supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/definition`
     */
    definition?: {
      /**
       * Whether definition supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/codeAction`
     */
    codeAction?: {
      /**
       * Whether code action supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/codeLens`
     */
    codeLens?: {
      /**
       * Whether code lens supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/documentLink`
     */
    documentLink?: {
      /**
       * Whether document link supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
    /**
     * Capabilities specific to the `textDocument/rename`
     */
    rename?: {
      /**
       * Whether rename supports dynamic registration.
       */
      dynamicRegistration?: boolean;
    };
  }
	/**
	 * Defines the capabilities provided by the client.
	 */
  export interface ClientCapabilities {
    /**
     * Workspace specific client capabilities.
     */
    workspace?: WorkspaceClientCapabilities;
    /**
     * Text document specific client capabilities.
     */
    textDocument?: TextDocumentClientCapabilities;
    /**
     * Experimental client capabilities.
     */
    experimental?: any;
  }
	/**
	 * Defines how the host (editor) should sync
	 * document changes to the language server.
	 */
  export namespace TextDocumentSyncKind {
    /**
     * Documents should not be synced at all.
     */
    const None = 0;
    /**
     * Documents are synced by always sending the full content
     * of the document.
     */
    const Full = 1;
    /**
     * Documents are synced by sending the full content on open.
     * After that only incremental updates to the document are
     * send.
     */
    const Incremental = 2;
  }
  export type TextDocumentSyncKind = 0 | 1 | 2;
	/**
	 * General text document registration options.
	 */
  export interface TextDocumentRegistrationOptions {
    /**
     * A document selector to identify the scope of the registration. If set to null
     * the document selector provided on the client side will be used.
     */
    documentSelector: DocumentSelector | null;
  }
	/**
	 * Completion options.
	 */
  export interface CompletionOptions {
    /**
     * The server provides support to resolve additional
     * information for a completion item.
     */
    resolveProvider?: boolean;
    /**
     * The characters that trigger completion automatically.
     */
    triggerCharacters?: string[];
  }
	/**
	 * Signature help options.
	 */
  export interface SignatureHelpOptions {
    /**
     * The characters that trigger signature help
     * automatically.
     */
    triggerCharacters?: string[];
  }
	/**
	 * Code Lens options.
	 */
  export interface CodeLensOptions {
    /**
     * Code lens has a resolve provider as well.
     */
    resolveProvider?: boolean;
  }
	/**
	 * Format document on type options
	 */
  export interface DocumentOnTypeFormattingOptions {
    /**
     * A character on which formatting should be triggered, like `}`.
     */
    firstTriggerCharacter: string;
    /**
     * More trigger characters.
     */
    moreTriggerCharacter?: string[];
  }
	/**
	 * Document link options
	 */
  export interface DocumentLinkOptions {
    /**
     * Document links have a resolve provider as well.
     */
    resolveProvider?: boolean;
  }
	/**
	 * Execute command options.
	 */
  export interface ExecuteCommandOptions {
    /**
     * The commands to be executed on the server
     */
    commands: string[];
  }
	/**
	 * Save options.
	 */
  export interface SaveOptions {
    /**
     * The client is supposed to include the content on save.
     */
    includeText?: boolean;
  }
  export interface TextDocumentSyncOptions {
    /**
     * Open and close notifications are sent to the server.
     */
    openClose?: boolean;
    /**
     * Change notificatins are sent to the server. See TextDocumentSyncKind.None, TextDocumentSyncKind.Full
     * and TextDocumentSyncKindIncremental.
     */
    change?: TextDocumentSyncKind;
    /**
     * Will save notifications are sent to the server.
     */
    willSave?: boolean;
    /**
     * Will save wait until requests are sent to the server.
     */
    willSaveWaitUntil?: boolean;
    /**
     * Save notifications are sent to the server.
     */
    save?: SaveOptions;
  }
	/**
	 * Defines the capabilities provided by a language
	 * server.
	 */
  export interface ServerCapabilities {
    /**
     * Defines how text documents are synced. Is either a detailed structure defining each notification or
     * for backwards compatibility the TextDocumentSyncKind number.
     */
    textDocumentSync?: TextDocumentSyncOptions | TextDocumentSyncKind;
    /**
     * The server provides hover support.
     */
    hoverProvider?: boolean;
    /**
     * The server provides completion support.
     */
    completionProvider?: CompletionOptions;
    /**
     * The server provides signature help support.
     */
    signatureHelpProvider?: SignatureHelpOptions;
    /**
     * The server provides goto definition support.
     */
    definitionProvider?: boolean;
    /**
     * The server provides find references support.
     */
    referencesProvider?: boolean;
    /**
     * The server provides document highlight support.
     */
    documentHighlightProvider?: boolean;
    /**
     * The server provides document symbol support.
     */
    documentSymbolProvider?: boolean;
    /**
     * The server provides workspace symbol support.
     */
    workspaceSymbolProvider?: boolean;
    /**
     * The server provides code actions.
     */
    codeActionProvider?: boolean;
    /**
     * The server provides code lens.
     */
    codeLensProvider?: CodeLensOptions;
    /**
     * The server provides document formatting.
     */
    documentFormattingProvider?: boolean;
    /**
     * The server provides document range formatting.
     */
    documentRangeFormattingProvider?: boolean;
    /**
     * The server provides document formatting on typing.
     */
    documentOnTypeFormattingProvider?: {
      /**
       * A character on which formatting should be triggered, like `}`.
       */
      firstTriggerCharacter: string;
      /**
       * More trigger characters.
       */
      moreTriggerCharacter?: string[];
    };
    /**
     * The server provides rename support.
     */
    renameProvider?: boolean;
    /**
     * The server provides document link support.
     */
    documentLinkProvider?: DocumentLinkOptions;
    /**
     * The server provides execute command support.
     */
    executeCommandProvider?: ExecuteCommandOptions;
    /**
     * Experimental server capabilities.
     */
    experimental?: any;
  }
	/**
	 * The initialize request is sent from the client to the server.
	 * It is sent once as the request after starting up the server.
	 * The requests parameter is of type [InitializeParams](#InitializeParams)
	 * the response if of type [InitializeResult](#InitializeResult) of a Thenable that
	 * resolves to such.
	 */
  export namespace InitializeRequest {
    const type: RequestType<InitializeParams, InitializeResult, InitializeError, void>;
  }
	/**
	 * The initialize parameters
	 */
  export interface InitializeParams {
    /**
     * The process Id of the parent process that started
     * the server.
     */
    processId: number;
    /**
     * The rootPath of the workspace. Is null
     * if no folder is open.
     *
     * @deprecated in favour of rootUri.
     */
    rootPath?: string | null;
    /**
     * The rootUri of the workspace. Is null if no
     * folder is open. If both `rootPath` and `rootUri` are set
     * `rootUri` wins.
     */
    rootUri: string | null;
    /**
     * The capabilities provided by the client (editor or tool)
     */
    capabilities: ClientCapabilities;
    /**
     * User provided initialization options.
     */
    initializationOptions?: any;
    /**
     * The initial trace setting. If omitted trace is disabled ('off').
     */
    trace?: 'off' | 'messages' | 'verbose';
  }
	/**
	 * The result returned from an initilize request.
	 */
  export interface InitializeResult {
    /**
     * The capabilities the language server provides.
     */
    capabilities: ServerCapabilities;
    /**
     * Custom initialization results.
     */
    [custom: string]: any;
  }
	/**
	 * Known error codes for an `InitializeError`;
	 */
  export namespace InitializeError {
    /**
     * If the protocol version provided by the client can't be handled by the server.
     * @deprecated This initialize error got replaced by client capabilities. There is
     * no version handshake in version 3.0x
     */
    const unknownProtocolVersion: number;
  }
	/**
	 * The data type of the ResponseError if the
	 * initialize request fails.
	 */
  export interface InitializeError {
    /**
     * Indicates whether the client execute the following retry logic:
     * (1) show the message provided by the ResponseError to the user
     * (2) user selects retry or cancel
     * (3) if user selected retry the initialize method is sent again.
     */
    retry: boolean;
  }
  export interface InitializedParams {
  }
	/**
	 * The intialized notification is send from the client to the
	 * server after the client is fully initialized and the server
	 * is allowed to send requests from the server to the client.
	 */
  export namespace InitializedNotification {
    const type: NotificationType<InitializedParams, void>;
  }
	/**
	 * A shutdown request is sent from the client to the server.
	 * It is sent once when the client descides to shutdown the
	 * server. The only notification that is sent after a shudown request
	 * is the exit event.
	 */
  export namespace ShutdownRequest {
    const type: RequestType0<void, void, void>;
  }
	/**
	 * The exit event is sent from the client to the server to
	 * ask the server to exit its process.
	 */
  export namespace ExitNotification {
    const type: NotificationType0<void>;
  }
	/**
	 * The configuration change notification is sent from the client to the server
	 * when the client's configuration has changed. The notification contains
	 * the changed configuration as defined by the language client.
	 */
  export namespace DidChangeConfigurationNotification {
    const type: NotificationType<DidChangeConfigurationParams, DidChangeConfigurationRegistrationOptions>;
  }
  export interface DidChangeConfigurationRegistrationOptions {
    section?: string | string[];
  }
	/**
	 * The parameters of a change configuration notification.
	 */
  export interface DidChangeConfigurationParams {
    /**
     * The actual changed settings
     */
    settings: any;
  }
	/**
	 * The message type
	 */
  export namespace MessageType {
    /**
     * An error message.
     */
    const Error = 1;
    /**
     * A warning message.
     */
    const Warning = 2;
    /**
     * An information message.
     */
    const Info = 3;
    /**
     * A log message.
     */
    const Log = 4;
  }
  export type MessageType = 1 | 2 | 3 | 4;
	/**
	 * The parameters of a notification message.
	 */
  export interface ShowMessageParams {
    /**
     * The message type. See {@link MessageType}
     */
    type: MessageType;
    /**
     * The actual message
     */
    message: string;
  }
	/**
	 * The show message notification is sent from a server to a client to ask
	 * the client to display a particular message in the user interface.
	 */
  export namespace ShowMessageNotification {
    const type: NotificationType<ShowMessageParams, void>;
  }
  export interface MessageActionItem {
    /**
     * A short title like 'Retry', 'Open Log' etc.
     */
    title: string;
  }
  export interface ShowMessageRequestParams {
    /**
     * The message type. See {@link MessageType}
     */
    type: MessageType;
    /**
     * The actual message
     */
    message: string;
    /**
     * The message action items to present.
     */
    actions?: MessageActionItem[];
  }
	/**
	 * The show message request is sent from the server to the clinet to show a message
	 * and a set of options actions to the user.
	 */
  export namespace ShowMessageRequest {
    const type: RequestType<ShowMessageRequestParams, MessageActionItem, void, void>;
  }
	/**
	 * The log message notification is sent from the server to the client to ask
	 * the client to log a particular message.
	 */
  export namespace LogMessageNotification {
    const type: NotificationType<LogMessageParams, void>;
  }
	/**
	 * The log message parameters.
	 */
  export interface LogMessageParams {
    /**
     * The message type. See {@link MessageType}
     */
    type: MessageType;
    /**
     * The actual message
     */
    message: string;
  }
	/**
	 * The telemetry event notification is sent from the server to the client to ask
	 * the client to log telemetry data.
	 */
  export namespace TelemetryEventNotification {
    const type: NotificationType<any, void>;
  }
	/**
	 * The parameters send in a open text document notification
	 */
  export interface DidOpenTextDocumentParams {
    /**
     * The document that was opened.
     */
    textDocument: TextDocumentItem;
  }
	/**
	 * The document open notification is sent from the client to the server to signal
	 * newly opened text documents. The document's truth is now managed by the client
	 * and the server must not try to read the document's truth using the document's
	 * uri.
	 */
  export namespace DidOpenTextDocumentNotification {
    const type: NotificationType<DidOpenTextDocumentParams, TextDocumentRegistrationOptions>;
  }
	/**
	 * The change text document notification's parameters.
	 */
  export interface DidChangeTextDocumentParams {
    /**
     * The document that did change. The version number points
     * to the version after all provided content changes have
     * been applied.
     */
    textDocument: VersionedTextDocumentIdentifier;
    /**
     * The actual content changes. The content changes descibe single state changes
     * to the document. So if there are two content changes c1 and c2 for a document
     * in state S10 then c1 move the document to S11 and c2 to S12.
     */
    contentChanges: TextDocumentContentChangeEvent[];
  }
	/**
	 * Descibe options to be used when registered for text document change events.
	 */
  export interface TextDocumentChangeRegistrationOptions extends TextDocumentRegistrationOptions {
    /**
     * How documents are synced to the server.
     */
    syncKind: TextDocumentSyncKind;
  }
	/**
	 * The document change notification is sent from the client to the server to signal
	 * changes to a text document.
	 */
  export namespace DidChangeTextDocumentNotification {
    const type: NotificationType<DidChangeTextDocumentParams, TextDocumentChangeRegistrationOptions>;
  }
	/**
	 * The parameters send in a close text document notification
	 */
  export interface DidCloseTextDocumentParams {
    /**
     * The document that was closed.
     */
    textDocument: TextDocumentIdentifier;
  }
	/**
	 * The document close notification is sent from the client to the server when
	 * the document got closed in the client. The document's truth now exists
	 * where the document's uri points to (e.g. if the document's uri is a file uri
	 * the truth now exists on disk).
	 */
  export namespace DidCloseTextDocumentNotification {
    const type: NotificationType<DidCloseTextDocumentParams, TextDocumentRegistrationOptions>;
  }
	/**
	 * The parameters send in a save text document notification
	 */
  export interface DidSaveTextDocumentParams {
    /**
     * The document that was closed.
     */
    textDocument: VersionedTextDocumentIdentifier;
    /**
     * Optional the content when saved. Depends on the includeText value
     * when the save notifcation was requested.
     */
    text?: string;
  }
	/**
	 * Save registration options.
	 */
  export interface TextDocumentSaveRegistrationOptions extends TextDocumentRegistrationOptions, SaveOptions {
  }
	/**
	 * The document save notification is sent from the client to the server when
	 * the document got saved in the client.
	 */
  export namespace DidSaveTextDocumentNotification {
    const type: NotificationType<DidSaveTextDocumentParams, TextDocumentSaveRegistrationOptions>;
  }
	/**
	 * The parameters send in a will save text document notification.
	 */
  export interface WillSaveTextDocumentParams {
    /**
     * The document that will be saved.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The 'TextDocumentSaveReason'.
     */
    reason: TextDocumentSaveReason;
  }
	/**
	 * A document will save notification is sent from the client to the server before
	 * the document is actually saved.
	 */
  export namespace WillSaveTextDocumentNotification {
    const type: NotificationType<WillSaveTextDocumentParams, TextDocumentRegistrationOptions>;
  }
	/**
	 * A document will save request is sent from the client to the server before
	 * the document is actually saved. The request can return an array of TextEdits
	 * which will be applied to the text document before it is saved. Please note that
	 * clients might drop results if computing the text edits took too long or if a
	 * server constantly fails on this request. This is done to keep the save fast and
	 * reliable.
	 */
  export namespace WillSaveTextDocumentWaitUntilRequest {
    const type: RequestType<WillSaveTextDocumentParams, TextEdit[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * The watched files notification is sent from the client to the server when
	 * the client detects changes to file watched by the lanaguage client.
	 */
  export namespace DidChangeWatchedFilesNotification {
    const type: NotificationType<DidChangeWatchedFilesParams, void>;
  }
	/**
	 * The watched files change notification's parameters.
	 */
  export interface DidChangeWatchedFilesParams {
    /**
     * The actual file events.
     */
    changes: FileEvent[];
  }
	/**
	 * The file event type
	 */
  export namespace FileChangeType {
    /**
     * The file got created.
     */
    const Created = 1;
    /**
     * The file got changed.
     */
    const Changed = 2;
    /**
     * The file got deleted.
     */
    const Deleted = 3;
  }
  export type FileChangeType = 1 | 2 | 3;
	/**
	 * An event describing a file change.
	 */
  export interface FileEvent {
    /**
     * The file's uri.
     */
    uri: string;
    /**
     * The change type.
     */
    type: FileChangeType;
  }
	/**
	 * Descibe options to be used when registered for text document change events.
	 */
  export interface DidChangeWatchedFilesRegistrationOptions {
    /**
     * The watchers to register.
     */
    watchers: FileSystemWatcher[];
  }
  export interface FileSystemWatcher {
    /**
     * The  glob pattern to watch
     */
    globPattern: string;
    /**
     * The kind of events of interest. If omitted it defaults
     * to WatchKind.Create | WatchKind.Change | WatchKind.Delete
     * which is 7.
     */
    kind?: number;
  }
  export namespace WatchKind {
    /**
     * Interested in create events.
     */
    const Create = 1;
    /**
     * Interested in change events
     */
    const Change = 2;
    /**
     * Interested in delete events
     */
    const Delete = 4;
  }
	/**
	 * Diagnostics notification are sent from the server to the client to signal
	 * results of validation runs.
	 */
  export namespace PublishDiagnosticsNotification {
    const type: NotificationType<PublishDiagnosticsParams, void>;
  }
	/**
	 * The publish diagnostic notification's parameters.
	 */
  export interface PublishDiagnosticsParams {
    /**
     * The URI for which diagnostic information is reported.
     */
    uri: string;
    /**
     * An array of diagnostic information items.
     */
    diagnostics: Diagnostic[];
  }
	/**
	 * Completion registration options.
	 */
  export interface CompletionRegistrationOptions extends TextDocumentRegistrationOptions, CompletionOptions {
  }
	/**
	 * Request to request completion at a given text document position. The request's
	 * parameter is of type [TextDocumentPosition](#TextDocumentPosition) the response
	 * is of type [CompletionItem[]](#CompletionItem) or [CompletionList](#CompletionList)
	 * or a Thenable that resolves to such.
	 */
  export namespace CompletionRequest {
    const type: RequestType<TextDocumentPositionParams, CompletionList | CompletionItem[], void, CompletionRegistrationOptions>;
  }
	/**
	 * Request to resolve additional information for a given completion item.The request's
	 * parameter is of type [CompletionItem](#CompletionItem) the response
	 * is of type [CompletionItem](#CompletionItem) or a Thenable that resolves to such.
	 */
  export namespace CompletionResolveRequest {
    const type: RequestType<CompletionItem, CompletionItem, void, void>;
  }
	/**
	 * Request to request hover information at a given text document position. The request's
	 * parameter is of type [TextDocumentPosition](#TextDocumentPosition) the response is of
	 * type [Hover](#Hover) or a Thenable that resolves to such.
	 */
  export namespace HoverRequest {
    const type: RequestType<TextDocumentPositionParams, Hover, void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Signature help registration options.
	 */
  export interface SignatureHelpRegistrationOptions extends TextDocumentRegistrationOptions, SignatureHelpOptions {
  }
  export namespace SignatureHelpRequest {
    const type: RequestType<TextDocumentPositionParams, SignatureHelp, void, SignatureHelpRegistrationOptions>;
  }
	/**
	 * A request to resolve the defintion location of a symbol at a given text
	 * document position. The request's parameter is of type [TextDocumentPosition]
	 * (#TextDocumentPosition) the response is of type [Definition](#Definition) or a
	 * Thenable that resolves to such.
	 */
  export namespace DefinitionRequest {
    const type: RequestType<TextDocumentPositionParams, Definition, void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Parameters for a [ReferencesRequest](#ReferencesRequest).
	 */
  export interface ReferenceParams extends TextDocumentPositionParams {
    context: ReferenceContext;
  }
	/**
	 * A request to resolve project-wide references for the symbol denoted
	 * by the given text document position. The request's parameter is of
	 * type [ReferenceParams](#ReferenceParams) the response is of type
	 * [Location[]](#Location) or a Thenable that resolves to such.
	 */
  export namespace ReferencesRequest {
    const type: RequestType<ReferenceParams, Location[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Request to resolve a [DocumentHighlight](#DocumentHighlight) for a given
	 * text document position. The request's parameter is of type [TextDocumentPosition]
	 * (#TextDocumentPosition) the request reponse is of type [DocumentHighlight[]]
	 * (#DocumentHighlight) or a Thenable that resolves to such.
	 */
  export namespace DocumentHighlightRequest {
    const type: RequestType<TextDocumentPositionParams, DocumentHighlight[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * A request to list all symbols found in a given text document. The request's
	 * parameter is of type [TextDocumentIdentifier](#TextDocumentIdentifier) the
	 * response is of type [SymbolInformation[]](#SymbolInformation) or a Thenable
	 * that resolves to such.
	 */
  export namespace DocumentSymbolRequest {
    const type: RequestType<DocumentSymbolParams, SymbolInformation[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * A request to list project-wide symbols matching the query string given
	 * by the [WorkspaceSymbolParams](#WorkspaceSymbolParams). The response is
	 * of type [SymbolInformation[]](#SymbolInformation) or a Thenable that
	 * resolves to such.
	 */
  export namespace WorkspaceSymbolRequest {
    const type: RequestType<WorkspaceSymbolParams, SymbolInformation[], void, void>;
  }
	/**
	 * Params for the CodeActionRequest
	 */
  export interface CodeActionParams {
    /**
     * The document in which the command was invoked.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The range for which the command was invoked.
     */
    range: Range;
    /**
     * Context carrying additional information.
     */
    context: CodeActionContext;
  }
	/**
	 * A request to provide commands for the given text document and range.
	 */
  export namespace CodeActionRequest {
    const type: RequestType<CodeActionParams, Command[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Params for the Code Lens request.
	 */
  export interface CodeLensParams {
    /**
     * The document to request code lens for.
     */
    textDocument: TextDocumentIdentifier;
  }
	/**
	 * Code Lens registration options.
	 */
  export interface CodeLensRegistrationOptions extends TextDocumentRegistrationOptions, CodeLensOptions {
  }
	/**
	 * A request to provide code lens for the given text document.
	 */
  export namespace CodeLensRequest {
    const type: RequestType<CodeLensParams, CodeLens[], void, CodeLensRegistrationOptions>;
  }
	/**
	 * A request to resolve a command for a given code lens.
	 */
  export namespace CodeLensResolveRequest {
    const type: RequestType<CodeLens, CodeLens, void, void>;
  }
  export interface DocumentFormattingParams {
    /**
     * The document to format.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The format options
     */
    options: FormattingOptions;
  }
	/**
	 * A request to to format a whole document.
	 */
  export namespace DocumentFormattingRequest {
    const type: RequestType<DocumentFormattingParams, TextEdit[], void, TextDocumentRegistrationOptions>;
  }
  export interface DocumentRangeFormattingParams {
    /**
     * The document to format.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The range to format
     */
    range: Range;
    /**
     * The format options
     */
    options: FormattingOptions;
  }
	/**
	 * A request to to format a range in a document.
	 */
  export namespace DocumentRangeFormattingRequest {
    const type: RequestType<DocumentRangeFormattingParams, TextEdit[], void, TextDocumentRegistrationOptions>;
  }
  export interface DocumentOnTypeFormattingParams {
    /**
     * The document to format.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The position at which this request was send.
     */
    position: Position;
    /**
     * The character that has been typed.
     */
    ch: string;
    /**
     * The format options.
     */
    options: FormattingOptions;
  }
	/**
	 * Format document on type options
	 */
  export interface DocumentOnTypeFormattingRegistrationOptions extends TextDocumentRegistrationOptions, DocumentOnTypeFormattingOptions {
  }
	/**
	 * A request to format a document on type.
	 */
  export namespace DocumentOnTypeFormattingRequest {
    const type: RequestType<DocumentOnTypeFormattingParams, TextEdit[], void, DocumentOnTypeFormattingRegistrationOptions>;
  }
  export interface RenameParams {
    /**
     * The document to rename.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The position at which this request was sent.
     */
    position: Position;
    /**
     * The new name of the symbol. If the given name is not valid the
     * request must return a [ResponseError](#ResponseError) with an
     * appropriate message set.
     */
    newName: string;
  }
	/**
	 * A request to rename a symbol.
	 */
  export namespace RenameRequest {
    const type: RequestType<RenameParams, WorkspaceEdit, void, TextDocumentRegistrationOptions>;
  }
  export interface DocumentLinkParams {
    /**
     * The document to provide document links for.
     */
    textDocument: TextDocumentIdentifier;
  }
	/**
	 * Document link registration options
	 */
  export interface DocumentLinkRegistrationOptions extends TextDocumentRegistrationOptions, DocumentLinkOptions {
  }
	/**
	 * A request to provide document links
	 */
  export namespace DocumentLinkRequest {
    const type: RequestType<DocumentLinkParams, DocumentLink[], void, DocumentLinkRegistrationOptions>;
  }
	/**
	 * Request to resolve additional information for a given document link. The request's
	 * parameter is of type [DocumentLink](#DocumentLink) the response
	 * is of type [DocumentLink](#DocumentLink) or a Thenable that resolves to such.
	 */
  export namespace DocumentLinkResolveRequest {
    const type: RequestType<DocumentLink, DocumentLink, void, void>;
  }
  export interface ExecuteCommandParams {
    /**
     * The identifier of the actual command handler.
     */
    command: string;
    /**
     * Arguments that the command should be invoked with.
     */
    arguments?: any[];
  }
	/**
	 * Execute command registration options.
	 */
  export interface ExecuteCommandRegistrationOptions extends ExecuteCommandOptions {
  }
	/**
	 * A request send from the client to the server to execute a command. The request might return
	 * a workspace edit which the client will apply to the workspace.
	 */
  export namespace ExecuteCommandRequest {
    const type: RequestType<ExecuteCommandParams, any, void, ExecuteCommandRegistrationOptions>;
  }
	/**
	 * The parameters passed via a apply workspace edit request.
	 */
  export interface ApplyWorkspaceEditParams {
    /**
     * The edits to apply.
     */
    edit: WorkspaceEdit;
  }
	/**
	 * A reponse returned from the apply workspace edit request.
	 */
  export interface ApplyWorkspaceEditResponse {
    /**
     * Indicates whether the edit was applied or not.
     */
    applied: boolean;
  }
	/**
	 * A request sent from the server to the client to modified certain resources.
	 */
  export namespace ApplyWorkspaceEditRequest {
    const type: RequestType<ApplyWorkspaceEditParams, ApplyWorkspaceEditResponse, void, void>;
  }

}
declare module 'vscode-languageserver-protocol/protocol.configuration.proposed' {
  import { RequestType, RequestHandler, HandlerResult, CancellationToken } from 'vscode-jsonrpc';
  export interface ConfigurationClientCapabilities {
    /**
     * The workspace client capabilities
     */
    workspace: {
      /**
      * The client supports `workspace/configuration` requests.
      */
      configuration?: boolean;
    };
  }
	/**
	 * The 'workspace/configuration' request is sent from the server to the client to fetch a certain
	 * configuration setting.
	 */
  export namespace ConfigurationRequest {
    const type: RequestType<ConfigurationParams, any[], void, void>;
    type HandlerSignature = RequestHandler<ConfigurationParams, any[], void>;
    type MiddlewareSignature = (params: ConfigurationParams, token: CancellationToken, next: HandlerSignature) => HandlerResult<any[], void>;
  }
  export interface ConfigurationItem {
    /**
     * The scope to get the configuration section for.
     */
    scopeUri?: string;
    /**
     * The configuration section asked for.
     */
    section?: string;
  }
	/**
	 * The parameters of a configuration request.
	 */
  export interface ConfigurationParams {
    items: ConfigurationItem[];
  }

}
declare module 'vscode-languageserver-protocol/protocol.workspaceFolders.proposed' {
  import { RequestType0, RequestHandler0, NotificationType, NotificationHandler, HandlerResult, CancellationToken } from 'vscode-jsonrpc';
  export interface WorkspaceFoldersInitializeParams {
    /**
     * The actual configured workspace folders.
     */
    workspaceFolders: WorkspaceFolder[] | null;
  }
  export interface WorkspaceFoldersClientCapabilities {
    /**
     * The workspace client capabilities
     */
    workspace: {
      /**
       * The client has support for workspace folders
       */
      workspaceFolders?: boolean;
    };
  }
  export interface WorkspaceFolder {
    /**
     * The associated URI for this workspace folder.
     */
    uri: string;
    /**
     * The name of the workspace folder. Defaults to the
     * uri's basename.
     */
    name: string;
  }
	/**
	 * The `workspace/workspaceFolders` is sent from the server to the client to fetch the open workspace folders.
	 */
  export namespace WorkspaceFoldersRequest {
    const type: RequestType0<WorkspaceFolder[] | null, void, void>;
    type HandlerSignature = RequestHandler0<WorkspaceFolder[] | null, void>;
    type MiddlewareSignature = (token: CancellationToken, next: HandlerSignature) => HandlerResult<WorkspaceFolder[] | null, void>;
  }
	/**
	 * The `workspace/didChangeWorkspaceFolders` notification is sent from the client to the server when the workspace
	 * folder configuration changes.
	 */
  export namespace DidChangeWorkspaceFoldersNotification {
    const type: NotificationType<DidChangeWorkspaceFoldersParams, void>;
    type HandlerSignature = NotificationHandler<DidChangeWorkspaceFoldersParams>;
    type MiddlewareSignature = (params: DidChangeWorkspaceFoldersParams, next: HandlerSignature) => void;
  }
	/**
	 * The parameters of a `workspace/didChangeWorkspaceFolders` notification.
	 */
  export interface DidChangeWorkspaceFoldersParams {
    /**
     * The actual workspace folder change event.
     */
    event: WorkspaceFoldersChangeEvent;
  }
	/**
	 * The workspace folder change event.
	 */
  export interface WorkspaceFoldersChangeEvent {
    /**
     * The array of added workspace folders
     */
    added: WorkspaceFolder[];
    /**
     * The array of the removed workspace folders
     */
    removed: WorkspaceFolder[];
  }

}
declare module 'vscode-languageserver-protocol/protocol.colorProvider.proposed' {
  import { RequestType } from 'vscode-jsonrpc';
  import { TextDocumentRegistrationOptions } from 'vscode-languageserver-protocol/protocol';
  import { TextDocumentIdentifier, Range, TextEdit } from 'vscode-languageserver-types';
  export interface ColorProviderOptions {
  }
  export interface ServerCapabilities {
    /**
     * The server provides color provider support.
     */
    colorProvider?: ColorProviderOptions;
  }
	/**
	 * Parameters for a [DocumentColorRequest](#DocumentColorRequest).
	 */
  export interface DocumentColorParams {
    /**
     * The text document.
     */
    textDocument: TextDocumentIdentifier;
  }
	/**
	 * A request to list all color symbols found in a given text document. The request's
	 * parameter is of type [DocumentColorParams](#DocumentColorParams) the
	 * response is of type [ColorInformation[]](#ColorInformation) or a Thenable
	 * that resolves to such.
	 */
  export namespace DocumentColorRequest {
    const type: RequestType<DocumentColorParams, ColorInformation[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Parameters for a [ColorPresentationRequest](#ColorPresentationRequest).
	 */
  export interface ColorPresentationParams {
    /**
     * The text document.
     */
    textDocument: TextDocumentIdentifier;
    /**
     * The color information to request presentations for.
     */
    colorInfo: ColorInformation;
  }
	/**
	 * A request to list all presentation for a color. The request's
	 * parameter is of type [ColorPresentationParams](#ColorPresentationParams) the
	 * response is of type [ColorInformation[]](#ColorInformation) or a Thenable
	 * that resolves to such.
	 */
  export namespace ColorPresentationRequest {
    const type: RequestType<ColorPresentationParams, ColorPresentation[], void, TextDocumentRegistrationOptions>;
  }
	/**
	 * Represents a color in RGBA space.
	 */
  export interface Color {
    /**
     * The red component of this color in the range [0-1].
     */
    readonly red: number;
    /**
     * The green component of this color in the range [0-1].
     */
    readonly green: number;
    /**
     * The blue component of this color in the range [0-1].
     */
    readonly blue: number;
    /**
     * The alpha component of this color in the range [0-1].
     */
    readonly alpha: number;
  }
	/**
	 * Represents a color range from a document.
	 */
  export interface ColorInformation {
    /**
     * The range in the document where this color appers.
     */
    range: Range;
    /**
     * The actual color value for this color range.
     */
    color: Color;
  }
  export interface ColorPresentation {
    /**
     * The label of this color presentation. It will be shown on the color
     * picker header. By default this is also the text that is inserted when selecting
     * this color presentation.
     */
    label: string;
    /**
     * An [edit](#TextEdit) which is applied to a document when selecting
     * this presentation for the color.  When `falsy` the [label](#ColorPresentation.label)
     * is used.
     */
    textEdit?: TextEdit;
    /**
     * An optional array of additional [text edits](#TextEdit) that are applied when
     * selecting this color presentation. Edits must not overlap with the main [edit](#ColorPresentation.textEdit) nor with themselves.
     */
    additionalTextEdits?: TextEdit[];
  }

}
declare module 'vscode-languageserver-protocol' {
  import { ErrorCodes, ResponseError, CancellationToken, CancellationTokenSource, Disposable, Event, Emitter, Trace, SetTraceNotification, LogTraceNotification, Message, NotificationMessage, RequestMessage, MessageType as RPCMessageType, RequestType, RequestType0, RequestHandler, RequestHandler0, GenericRequestHandler, StarRequestHandler, NotificationType, NotificationType0, NotificationHandler, NotificationHandler0, GenericNotificationHandler, StarNotificationHandler, MessageReader, MessageWriter, Logger, ConnectionStrategy, StreamMessageReader, StreamMessageWriter, IPCMessageReader, IPCMessageWriter, createClientPipeTransport, createServerPipeTransport, generateRandomPipeName, DataCallback, Tracer } from 'vscode-jsonrpc';
  export { ErrorCodes, ResponseError, CancellationToken, CancellationTokenSource, Disposable, Event, Emitter, Trace, SetTraceNotification, LogTraceNotification, Message, NotificationMessage, RequestMessage, RPCMessageType, RequestType, RequestType0, RequestHandler, RequestHandler0, GenericRequestHandler, StarRequestHandler, NotificationType, NotificationType0, NotificationHandler, NotificationHandler0, GenericNotificationHandler, StarNotificationHandler, MessageReader, MessageWriter, Logger, ConnectionStrategy, StreamMessageReader, StreamMessageWriter, IPCMessageReader, IPCMessageWriter, createClientPipeTransport, createServerPipeTransport, generateRandomPipeName, DataCallback, Tracer };
  export * from 'vscode-languageserver-types';
  export * from 'vscode-languageserver-protocol/protocol';
  import * as config from 'vscode-languageserver-protocol/protocol.configuration.proposed';
  import * as folders from 'vscode-languageserver-protocol/protocol.workspaceFolders.proposed';
  import * as color from 'vscode-languageserver-protocol/protocol.colorProvider.proposed';
  export namespace Proposed {
    type ConfigurationClientCapabilities = config.ConfigurationClientCapabilities;
    type ConfigurationParams = config.ConfigurationParams;
    type ConfigurationItem = config.ConfigurationItem;
    namespace ConfigurationRequest {
      const type: RequestType<config.ConfigurationParams, any[], void, void>;
      type HandlerSignature = config.ConfigurationRequest.HandlerSignature;
      type MiddlewareSignature = config.ConfigurationRequest.MiddlewareSignature;
    }
    type WorkspaceFoldersInitializeParams = folders.WorkspaceFoldersInitializeParams;
    type WorkspaceFoldersClientCapabilities = folders.WorkspaceFoldersClientCapabilities;
    type WorkspaceFolder = folders.WorkspaceFolder;
    type WorkspaceFoldersChangeEvent = folders.WorkspaceFoldersChangeEvent;
    type DidChangeWorkspaceFoldersParams = folders.DidChangeWorkspaceFoldersParams;
    namespace WorkspaceFoldersRequest {
      const type: RequestType0<folders.WorkspaceFolder[] | null, void, void>;
      type HandlerSignature = folders.WorkspaceFoldersRequest.HandlerSignature;
      type MiddlewareSignature = folders.WorkspaceFoldersRequest.MiddlewareSignature;
    }
    namespace DidChangeWorkspaceFoldersNotification {
      const type: NotificationType<folders.DidChangeWorkspaceFoldersParams, void>;
      type HandlerSignature = folders.DidChangeWorkspaceFoldersNotification.HandlerSignature;
      type MiddlewareSignature = folders.DidChangeWorkspaceFoldersNotification.MiddlewareSignature;
    }
    type ColorProviderOptions = color.ColorProviderOptions;
    type DocumentColorParams = color.DocumentColorParams;
    type ColorPresentationParams = color.ColorPresentationParams;
    type Color = color.Color;
    type ColorInformation = color.ColorInformation;
    type ColorPresentation = color.ColorPresentation;
    type ColorServerCapabilities = color.ServerCapabilities;
    const DocumentColorRequest: typeof color.DocumentColorRequest;
    const ColorPresentationRequest: typeof color.ColorPresentationRequest;
  }
  export interface ProtocolConnetion {
    /**
     * Sends a request and returns a promise resolving to the result of the request.
     *
     * @param type The type of request to sent.
     * @param token An optional cancellation token.
     * @returns A promise resolving to the request's result.
     */
    sendRequest<R, E, RO>(type: RequestType0<R, E, RO>, token?: CancellationToken): Thenable<R>;
    /**
     * Sends a request and returns a promise resolving to the result of the request.
     *
     * @param type The type of request to sent.
     * @param params The request's parameter.
     * @param token An optional cancellation token.
     * @returns A promise resolving to the request's result.
     */
    sendRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, params: P, token?: CancellationToken): Thenable<R>;
    /**
     * Sends a request and returns a promise resolving to the result of the request.
     *
     * @param method the request's method name.
     * @param token An optional cancellation token.
     * @returns A promise resolving to the request's result.
     */
    sendRequest<R>(method: string, token?: CancellationToken): Thenable<R>;
    /**
     * Sends a request and returns a promise resolving to the result of the request.
     *
     * @param method the request's method name.
     * @param params The request's parameter.
     * @param token An optional cancellation token.
     * @returns A promise resolving to the request's result.
     */
    sendRequest<R>(method: string, param: any, token?: CancellationToken): Thenable<R>;
    /**
     * Installs a request handler.
     *
     * @param type The request type to install the handler for.
     * @param handler The actual handler.
     */
    onRequest<R, E, RO>(type: RequestType0<R, E, RO>, handler: RequestHandler0<R, E>): void;
    /**
     * Installs a request handler.
     *
     * @param type The request type to install the handler for.
     * @param handler The actual handler.
     */
    onRequest<P, R, E, RO>(type: RequestType<P, R, E, RO>, handler: RequestHandler<P, R, E>): void;
    /**
     * Installs a request handler.
     *
     * @param methods The method name to install the handler for.
     * @param handler The actual handler.
     */
    onRequest<R, E>(method: string, handler: GenericRequestHandler<R, E>): void;
    /**
     * Sends a notification.
     *
     * @param type the notification's type to send.
     */
    sendNotification<RO>(type: NotificationType0<RO>): void;
    /**
     * Sends a notification.
     *
     * @param type the notification's type to send.
     * @param params the notification's parameters.
     */
    sendNotification<P, RO>(type: NotificationType<P, RO>, params?: P): void;
    /**
     * Sends a notification.
     *
     * @param method the notification's method name.
     */
    sendNotification(method: string): void;
    /**
     * Sends a notification.
     *
     * @param method the notification's method name.
     * @param params the notification's parameters.
     */
    sendNotification(method: string, params: any): void;
    /**
     * Installs a notification handler.
     *
     * @param type The notification type to install the handler for.
     * @param handler The actual handler.
     */
    onNotification<RO>(type: NotificationType0<RO>, handler: NotificationHandler0): void;
    /**
     * Installs a notification handler.
     *
     * @param type The notification type to install the handler for.
     * @param handler The actual handler.
     */
    onNotification<P, RO>(type: NotificationType<P, RO>, handler: NotificationHandler<P>): void;
    /**
     * Installs a notification handler.
     *
     * @param methods The method name to install the handler for.
     * @param handler The actual handler.
     */
    onNotification(method: string, handler: GenericNotificationHandler): void;
    /**
     * Enables tracing mode for the connection.
     */
    trace(value: Trace, tracer: Tracer, sendNotification?: boolean): void;
    /**
     * An event emitter firing when an error occurs on the connection.
     */
    onError: Event<[Error, Message | undefined, number | undefined]>;
    /**
     * An event emitter firing when the connection got closed.
     */
    onClose: Event<void>;
    /**
     * An event emiiter firing when the connection receives a notification that is not
     * handled.
     */
    onUnhandledNotification: Event<NotificationMessage>;
    /**
     * An event emitter firing when the connection got disposed.
     */
    onDispose: Event<void>;
    /**
     * Actively disposes the connection.
     */
    dispose(): void;
    /**
     * Turns the connection into listening mode
     */
    listen(): void;
  }
  export function createProtocolConnection(reader: MessageReader, writer: MessageWriter, logger: Logger, strategy?: ConnectionStrategy): ProtocolConnetion;

}

declare module 'vscode-languageserver-types' {
	/**
	 * Position in a text document expressed as zero-based line and character offset.
	 */
  export interface Position {
    /**
     * Line position in a document (zero-based).
     */
    line: number;
    /**
     * Character offset on a line in a document (zero-based). Assuming that the line is
     * represented as a string, the `character` value represents the gap between the
     * `character` and `character + 1`. Given the following line: 'a𐐀c', character 0 is
     * the gap between the start of the start and 'a' ('|a𐐀c'), character 1 is the gap
     * between 'a' and '𐐀' ('a|𐐀c') and character 2 is the gap between '𐐀' and 'b' ('a𐐀|c').
     *
     * The string 'a𐐀c' consist of 3 characters with valid character values being 0, 1, 2, 3
     * for that string. Note that the string encoded in UTF-16 is encoded using 4 code units
     * (the 𐐀 is encoded using two code units). The character offset is therefore encoding
     * independent.
     */
    character: number;
  }
	/**
	 * The Position namespace provides helper functions to work with
	 * [Position](#Position) literals.
	 */
  export namespace Position {
    /**
     * Creates a new Position literal from the given line and character.
     * @param line The position's line.
     * @param character The position's character.
     */
    function create(line: number, character: number): Position;
    /**
     * Checks whether the given liternal conforms to the [Position](#Position) interface.
     */
    function is(value: any): value is Position;
  }
	/**
	 * A range in a text document expressed as (zero-based) start and end positions.
	 */
  export interface Range {
    /**
     * The range's start position
     */
    start: Position;
    /**
     * The range's end position
     */
    end: Position;
  }
	/**
	 * The Range namespace provides helper functions to work with
	 * [Range](#Range) literals.
	 */
  export namespace Range {
    /**
     * Create a new Range liternal.
     * @param start The range's start position.
     * @param end The range's end position.
     */
    function create(start: Position, end: Position): Range;
    /**
     * Create a new Range liternal.
     * @param startLine The start line number.
     * @param startCharacter The start character.
     * @param endLine The end line number.
     * @param endCharacter The end character.
     */
    function create(startLine: number, startCharacter: number, endLine: number, endCharacter: number): Range;
    /**
     * Checks whether the given literal conforms to the [Range](#Range) interface.
     */
    function is(value: any): value is Range;
  }
	/**
	 * Represents a location inside a resource, such as a line
	 * inside a text file.
	 */
  export interface Location {
    uri: string;
    range: Range;
  }
	/**
	 * The Location namespace provides helper functions to work with
	 * [Location](#Location) literals.
	 */
  export namespace Location {
    /**
     * Creates a Location literal.
     * @param uri The location's uri.
     * @param range The location's range.
     */
    function create(uri: string, range: Range): Location;
    /**
     * Checks whether the given literal conforms to the [Location](#Location) interface.
     */
    function is(value: any): value is Location;
  }
	/**
	 * The diagnostic's serverity.
	 */
  export namespace DiagnosticSeverity {
    /**
     * Reports an error.
     */
    const Error: 1;
    /**
     * Reports a warning.
     */
    const Warning: 2;
    /**
     * Reports an information.
     */
    const Information: 3;
    /**
     * Reports a hint.
     */
    const Hint: 4;
  }
  export type DiagnosticSeverity = 1 | 2 | 3 | 4;
	/**
	 * Represents a diagnostic, such as a compiler error or warning. Diagnostic objects
	 * are only valid in the scope of a resource.
	 */
  export interface Diagnostic {
    /**
     * The range at which the message applies
     */
    range: Range;
    /**
     * The diagnostic's severity. Can be omitted. If omitted it is up to the
     * client to interpret diagnostics as error, warning, info or hint.
     */
    severity?: DiagnosticSeverity;
    /**
     * The diagnostic's code. Can be omitted.
     */
    code?: number | string;
    /**
     * A human-readable string describing the source of this
     * diagnostic, e.g. 'typescript' or 'super lint'.
     */
    source?: string;
    /**
     * The diagnostic's message.
     */
    message: string;
  }
	/**
	 * The Diagnostic namespace provides helper functions to work with
	 * [Diagnostic](#Diagnostic) literals.
	 */
  export namespace Diagnostic {
    /**
     * Creates a new Diagnostic literal.
     */
    function create(range: Range, message: string, severity?: DiagnosticSeverity, code?: number | string, source?: string): Diagnostic;
    /**
     * Checks whether the given literal conforms to the [Diagnostic](#Diagnostic) interface.
     */
    function is(value: any): value is Diagnostic;
  }
	/**
	 * Represents a reference to a command. Provides a title which
	 * will be used to represent a command in the UI and, optionally,
	 * an array of arguments which will be passed to the command handler
	 * function when invoked.
	 */
  export interface Command {
    /**
     * Title of the command, like `save`.
     */
    title: string;
    /**
     * The identifier of the actual command handler.
     */
    command: string;
    /**
     * Arguments that the command handler should be
     * invoked with.
     */
    arguments?: any[];
  }
	/**
	 * The Command namespace provides helper functions to work with
	 * [Command](#Command) literals.
	 */
  export namespace Command {
    /**
     * Creates a new Command literal.
     */
    function create(title: string, command: string, ...args: any[]): Command;
    /**
     * Checks whether the given literal conforms to the [Command](#Command) interface.
     */
    function is(value: any): value is Command;
  }
	/**
	 * A text edit applicable to a text document.
	 */
  export interface TextEdit {
    /**
     * The range of the text document to be manipulated. To insert
     * text into a document create a range where start === end.
     */
    range: Range;
    /**
     * The string to be inserted. For delete operations use an
     * empty string.
     */
    newText: string;
  }
	/**
	 * The TextEdit namespace provides helper function to create replace,
	 * insert and delete edits more easily.
	 */
  export namespace TextEdit {
    /**
     * Creates a replace text edit.
     * @param range The range of text to be replaced.
     * @param newText The new text.
     */
    function replace(range: Range, newText: string): TextEdit;
    /**
     * Creates a insert text edit.
     * @param psotion The position to insert the text at.
     * @param newText The text to be inserted.
     */
    function insert(position: Position, newText: string): TextEdit;
    /**
     * Creates a delete text edit.
     * @param range The range of text to be deleted.
     */
    function del(range: Range): TextEdit;
  }
	/**
	 * Describes textual changes on a text document.
	 */
  export interface TextDocumentEdit {
    /**
     * The text document to change.
     */
    textDocument: VersionedTextDocumentIdentifier;
    /**
     * The edits to be applied.
     */
    edits: TextEdit[];
  }
	/**
	 * The TextDocumentEdit namespace provides helper function to create
	 * an edit that manipulates a text document.
	 */
  export namespace TextDocumentEdit {
    /**
     * Creates a new `TextDocumentEdit`
     */
    function create(textDocument: VersionedTextDocumentIdentifier, edits: TextEdit[]): TextDocumentEdit;
    function is(value: any): value is TextDocumentEdit;
  }
	/**
	 * A workspace edit represents changes to many resources managed in the workspace. The edit
	 * should either provide `changes` or `documentChanges`. If documentChanges are present
	 * they are preferred over `changes` if the client can handle versioned document edits.
	 */
  export interface WorkspaceEdit {
    /**
     * Holds changes to existing resources.
     */
    changes?: {
      [uri: string]: TextEdit[];
    };
    /**
     * An array of `TextDocumentEdit`s to express changes to n different text documents
     * where each text document edit addresses a specific version of a text document.
     * Whether a client supports versioned document edits is expressed via
     * `WorkspaceClientCapabilites.workspaceEdit.documentChanges`.
     */
    documentChanges?: TextDocumentEdit[];
  }
	/**
	 * A change to capture text edits for existing resources.
	 */
  export interface TextEditChange {
    /**
     * Gets all text edits for this change.
     *
     * @return An array of text edits.
     */
    all(): TextEdit[];
    /**
     * Clears the edits for this change.
     */
    clear(): void;
    /**
     * Adds a text edit.
     * @param edit the text edit to add.
     */
    add(edit: TextEdit): void;
    /**
     * Insert the given text at the given position.
     *
     * @param position A position.
     * @param newText A string.
     */
    insert(position: Position, newText: string): void;
    /**
     * Replace the given range with given text for the given resource.
     *
     * @param range A range.
     * @param newText A string.
     */
    replace(range: Range, newText: string): void;
    /**
     * Delete the text at the given range.
     *
     * @param range A range.
     */
    delete(range: Range): void;
  }
	/**
	 * A workspace change helps constructing changes to a workspace.
	 */
  export class WorkspaceChange {
    private _workspaceEdit;
    private _textEditChanges;
    constructor(workspaceEdit?: WorkspaceEdit);
    /**
     * Returns the underlying [WorkspaceEdit](#WorkspaceEdit) literal
     * use to be returned from a workspace edit operation like rename.
     */
    readonly edit: WorkspaceEdit;
    /**
     * Returns the [TextEditChange](#TextEditChange) to manage text edits
     * for resources.
     */
    getTextEditChange(textDocument: VersionedTextDocumentIdentifier): TextEditChange;
    getTextEditChange(uri: string): TextEditChange;
  }
	/**
	 * A literal to identify a text document in the client.
	 */
  export interface TextDocumentIdentifier {
    /**
     * The text document's uri.
     */
    uri: string;
  }
	/**
	 * The TextDocumentIdentifier namespace provides helper functions to work with
	 * [TextDocumentIdentifier](#TextDocumentIdentifier) literals.
	 */
  export namespace TextDocumentIdentifier {
    /**
     * Creates a new TextDocumentIdentifier literal.
     * @param uri The document's uri.
     */
    function create(uri: string): TextDocumentIdentifier;
    /**
     * Checks whether the given literal conforms to the [TextDocumentIdentifier](#TextDocumentIdentifier) interface.
     */
    function is(value: any): value is TextDocumentIdentifier;
  }
	/**
	 * An identifier to denote a specific version of a text document.
	 */
  export interface VersionedTextDocumentIdentifier extends TextDocumentIdentifier {
    /**
     * The version number of this document.
     */
    version: number;
  }
	/**
	 * The VersionedTextDocumentIdentifier namespace provides helper functions to work with
	 * [VersionedTextDocumentIdentifier](#VersionedTextDocumentIdentifier) literals.
	 */
  export namespace VersionedTextDocumentIdentifier {
    /**
     * Creates a new VersionedTextDocumentIdentifier literal.
     * @param uri The document's uri.
     * @param uri The document's text.
     */
    function create(uri: string, version: number): VersionedTextDocumentIdentifier;
    /**
     * Checks whether the given literal conforms to the [VersionedTextDocumentIdentifier](#VersionedTextDocumentIdentifier) interface.
     */
    function is(value: any): value is VersionedTextDocumentIdentifier;
  }
	/**
	 * An item to transfer a text document from the client to the
	 * server.
	 */
  export interface TextDocumentItem {
    /**
     * The text document's uri.
     */
    uri: string;
    /**
     * The text document's language identifier
     */
    languageId: string;
    /**
     * The version number of this document (it will increase after each
     * change, including undo/redo).
     */
    version: number;
    /**
     * The content of the opened text document.
     */
    text: string;
  }
	/**
	 * The TextDocumentItem namespace provides helper functions to work with
	 * [TextDocumentItem](#TextDocumentItem) literals.
	 */
  export namespace TextDocumentItem {
    /**
     * Creates a new TextDocumentItem literal.
     * @param uri The document's uri.
     * @param uri The document's language identifier.
     * @param uri The document's version number.
     * @param uri The document's text.
     */
    function create(uri: string, languageId: string, version: number, text: string): TextDocumentItem;
    /**
     * Checks whether the given literal conforms to the [TextDocumentItem](#TextDocumentItem) interface.
     */
    function is(value: any): value is TextDocumentItem;
  }
	/**
	 * The kind of a completion entry.
	 */
  export namespace CompletionItemKind {
    const Text: 1;
    const Method: 2;
    const Function: 3;
    const Constructor: 4;
    const Field: 5;
    const Variable: 6;
    const Class: 7;
    const Interface: 8;
    const Module: 9;
    const Property: 10;
    const Unit: 11;
    const Value: 12;
    const Enum: 13;
    const Keyword: 14;
    const Snippet: 15;
    const Color: 16;
    const File: 17;
    const Reference: 18;
  }
  export type CompletionItemKind = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18;
	/**
	 * Defines whether the insert text in a completion item should be interpreted as
	 * plain text or a snippet.
	 */
  export namespace InsertTextFormat {
    /**
     * The primary text to be inserted is treated as a plain string.
     */
    const PlainText: 1;
    /**
     * The primary text to be inserted is treated as a snippet.
     *
     * A snippet can define tab stops and placeholders with `$1`, `$2`
     * and `${3:foo}`. `$0` defines the final tab stop, it defaults to
     * the end of the snippet. Placeholders with equal identifiers are linked,
     * that is typing in one will update others too.
     *
     * See also: https://github.com/Microsoft/vscode/blob/master/src/vs/editor/contrib/snippet/common/snippet.md
     */
    const Snippet: 2;
  }
  export type InsertTextFormat = 1 | 2;
	/**
	 * A completion item represents a text snippet that is
	 * proposed to complete text that is being typed.
	 */
  export interface CompletionItem {
    /**
     * The label of this completion item. By default
     * also the text that is inserted when selecting
     * this completion.
     */
    label: string;
    /**
     * The kind of this completion item. Based of the kind
     * an icon is chosen by the editor.
     */
    kind?: CompletionItemKind;
    /**
     * A human-readable string with additional information
     * about this item, like type or symbol information.
     */
    detail?: string;
    /**
     * A human-readable string that represents a doc-comment.
     */
    documentation?: string;
    /**
     * A string that shoud be used when comparing this item
     * with other items. When `falsy` the [label](#CompletionItem.label)
     * is used.
     */
    sortText?: string;
    /**
     * A string that should be used when filtering a set of
     * completion items. When `falsy` the [label](#CompletionItem.label)
     * is used.
     */
    filterText?: string;
    /**
     * A string that should be inserted a document when selecting
     * this completion. When `falsy` the [label](#CompletionItem.label)
     * is used.
     */
    insertText?: string;
    /**
     * The format of the insert text. The format applies to both the `insertText` property
     * and the `newText` property of a provided `textEdit`.
     */
    insertTextFormat?: InsertTextFormat;
    /**
     * An [edit](#TextEdit) which is applied to a document when selecting
     * this completion. When an edit is provided the value of
     * [insertText](#CompletionItem.insertText) is ignored.
     */
    textEdit?: TextEdit;
    /**
     * An optional array of additional [text edits](#TextEdit) that are applied when
     * selecting this completion. Edits must not overlap with the main [edit](#CompletionItem.textEdit)
     * nor with themselves.
     */
    additionalTextEdits?: TextEdit[];
    /**
     * An optional [command](#Command) that is executed *after* inserting this completion. *Note* that
     * additional modifications to the current document should be described with the
     * [additionalTextEdits](#CompletionItem.additionalTextEdits)-property.
     */
    command?: Command;
    /**
     * An data entry field that is preserved on a completion item between
     * a [CompletionRequest](#CompletionRequest) and a [CompletionResolveRequest]
     * (#CompletionResolveRequest)
     */
    data?: any;
  }
	/**
	 * The CompletionItem namespace provides functions to deal with
	 * completion items.
	 */
  export namespace CompletionItem {
    /**
     * Create a completion item and seed it with a label.
     * @param label The completion item's label
     */
    function create(label: string): CompletionItem;
  }
	/**
	 * Represents a collection of [completion items](#CompletionItem) to be presented
	 * in the editor.
	 */
  export interface CompletionList {
    /**
     * This list it not complete. Further typing results in recomputing this list.
     */
    isIncomplete: boolean;
    /**
     * The completion items.
     */
    items: CompletionItem[];
  }
	/**
	 * The CompletionList namespace provides functions to deal with
	 * completion lists.
	 */
  export namespace CompletionList {
    /**
     * Creates a new completion list.
     *
     * @param items The completion items.
     * @param isIncomplete The list is not complete.
     */
    function create(items?: CompletionItem[], isIncomplete?: boolean): CompletionList;
  }
	/**
	 * MarkedString can be used to render human readable text. It is either a markdown string
	 * or a code-block that provides a language and a code snippet. The language identifier
	 * is sematically equal to the optional language identifier in fenced code blocks in GitHub
	 * issues. See https://help.github.com/articles/creating-and-highlighting-code-blocks/#syntax-highlighting
	 *
	 * The pair of a language and a value is an equivalent to markdown:
	 * ```${language}
	 * ${value}
	 * ```
	 *
	 * Note that markdown strings will be sanitized - that means html will be escaped.
	 */
  export type MarkedString = string | {
    language: string;
    value: string;
  };
  export namespace MarkedString {
    /**
     * Creates a marked string from plain text.
     *
     * @param plainText The plain text.
     */
    function fromPlainText(plainText: string): MarkedString;
  }
	/**
	 * The result of a hover request.
	 */
  export interface Hover {
    /**
     * The hover's content
     */
    contents: MarkedString | MarkedString[];
    /**
     * An optional range
     */
    range?: Range;
  }
	/**
	 * Represents a parameter of a callable-signature. A parameter can
	 * have a label and a doc-comment.
	 */
  export interface ParameterInformation {
    /**
     * The label of this signature. Will be shown in
     * the UI.
     */
    label: string;
    /**
     * The human-readable doc-comment of this signature. Will be shown
     * in the UI but can be omitted.
     */
    documentation?: string;
  }
	/**
	 * The ParameterInformation namespace provides helper functions to work with
	 * [ParameterInformation](#ParameterInformation) literals.
	 */
  export namespace ParameterInformation {
    /**
     * Creates a new parameter information literal.
     *
     * @param label A label string.
     * @param documentation A doc string.
     */
    function create(label: string, documentation?: string): ParameterInformation;
  }
	/**
	 * Represents the signature of something callable. A signature
	 * can have a label, like a function-name, a doc-comment, and
	 * a set of parameters.
	 */
  export interface SignatureInformation {
    /**
     * The label of this signature. Will be shown in
     * the UI.
     */
    label: string;
    /**
     * The human-readable doc-comment of this signature. Will be shown
     * in the UI but can be omitted.
     */
    documentation?: string;
    /**
     * The parameters of this signature.
     */
    parameters?: ParameterInformation[];
  }
	/**
	 * The SignatureInformation namespace provides helper functions to work with
	 * [SignatureInformation](#SignatureInformation) literals.
	 */
  export namespace SignatureInformation {
    function create(label: string, documentation?: string, ...parameters: ParameterInformation[]): SignatureInformation;
  }
	/**
	 * Signature help represents the signature of something
	 * callable. There can be multiple signature but only one
	 * active and only one active parameter.
	 */
  export interface SignatureHelp {
    /**
     * One or more signatures.
     */
    signatures: SignatureInformation[];
    /**
     * The active signature. Set to `null` if no
     * signatures exist.
     */
    activeSignature: number | null;
    /**
     * The active parameter of the active signature. Set to `null`
     * if the active signature has no parameters.
     */
    activeParameter: number | null;
  }
	/**
	 * The definition of a symbol represented as one or many [locations](#Location).
	 * For most programming languages there is only one location at which a symbol is
	 * defined.
	 */
  export type Definition = Location | Location[];
	/**
	 * Value-object that contains additional information when
	 * requesting references.
	 */
  export interface ReferenceContext {
    /**
     * Include the declaration of the current symbol.
     */
    includeDeclaration: boolean;
  }
	/**
	 * A document highlight kind.
	 */
  export namespace DocumentHighlightKind {
    /**
     * A textual occurrance.
     */
    const Text: 1;
    /**
     * Read-access of a symbol, like reading a variable.
     */
    const Read: 2;
    /**
     * Write-access of a symbol, like writing to a variable.
     */
    const Write: 3;
  }
  export type DocumentHighlightKind = 1 | 2 | 3;
	/**
	 * A document highlight is a range inside a text document which deserves
	 * special attention. Usually a document highlight is visualized by changing
	 * the background color of its range.
	 */
  export interface DocumentHighlight {
    /**
     * The range this highlight applies to.
     */
    range: Range;
    /**
     * The highlight kind, default is [text](#DocumentHighlightKind.Text).
     */
    kind?: DocumentHighlightKind;
  }
	/**
	 * DocumentHighlight namespace to provide helper functions to work with
	 * [DocumentHighlight](#DocumentHighlight) literals.
	 */
  export namespace DocumentHighlight {
    /**
     * Create a DocumentHighlight object.
     * @param range The range the highlight applies to.
     */
    function create(range: Range, kind?: DocumentHighlightKind): DocumentHighlight;
  }
	/**
	 * A symbol kind.
	 */
  export namespace SymbolKind {
    const File: 1;
    const Module: 2;
    const Namespace: 3;
    const Package: 4;
    const Class: 5;
    const Method: 6;
    const Property: 7;
    const Field: 8;
    const Constructor: 9;
    const Enum: 10;
    const Interface: 11;
    const Function: 12;
    const Variable: 13;
    const Constant: 14;
    const String: 15;
    const Number: 16;
    const Boolean: 17;
    const Array: 18;
  }
  export type SymbolKind = 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18;
	/**
	 * Represents information about programming constructs like variables, classes,
	 * interfaces etc.
	 */
  export interface SymbolInformation {
    /**
     * The name of this symbol.
     */
    name: string;
    /**
     * The kind of this symbol.
     */
    kind: SymbolKind;
    /**
     * The location of this symbol.
     */
    location: Location;
    /**
     * The name of the symbol containing this symbol.
     */
    containerName?: string;
  }
  export namespace SymbolInformation {
    /**
     * Creates a new symbol information literal.
     *
     * @param name The name of the symbol.
     * @param kind The kind of the symbol.
     * @param range The range of the location of the symbol.
     * @param uri The resource of the location of symbol, defaults to the current document.
     * @param containerName The name of the symbol containg the symbol.
     */
    function create(name: string, kind: SymbolKind, range: Range, uri?: string, containerName?: string): SymbolInformation;
  }
	/**
	 * Parameters for a [DocumentSymbolRequest](#DocumentSymbolRequest).
	 */
  export interface DocumentSymbolParams {
    /**
     * The text document.
     */
    textDocument: TextDocumentIdentifier;
  }
	/**
	 * The parameters of a [WorkspaceSymbolRequest](#WorkspaceSymbolRequest).
	 */
  export interface WorkspaceSymbolParams {
    /**
     * A non-empty query string
     */
    query: string;
  }
	/**
	 * Contains additional diagnostic information about the context in which
	 * a [code action](#CodeActionProvider.provideCodeActions) is run.
	 */
  export interface CodeActionContext {
    /**
     * An array of diagnostics.
     */
    diagnostics: Diagnostic[];
  }
	/**
	 * The CodeActionContext namespace provides helper functions to work with
	 * [CodeActionContext](#CodeActionContext) literals.
	 */
  export namespace CodeActionContext {
    /**
     * Creates a new CodeActionContext literal.
     */
    function create(diagnostics: Diagnostic[]): CodeActionContext;
    /**
     * Checks whether the given literal conforms to the [CodeActionContext](#CodeActionContext) interface.
     */
    function is(value: any): value is CodeActionContext;
  }
	/**
	 * A code lens represents a [command](#Command) that should be shown along with
	 * source text, like the number of references, a way to run tests, etc.
	 *
	 * A code lens is _unresolved_ when no command is associated to it. For performance
	 * reasons the creation of a code lens and resolving should be done to two stages.
	 */
  export interface CodeLens {
    /**
     * The range in which this code lens is valid. Should only span a single line.
     */
    range: Range;
    /**
     * The command this code lens represents.
     */
    command?: Command;
    /**
     * An data entry field that is preserved on a code lens item between
     * a [CodeLensRequest](#CodeLensRequest) and a [CodeLensResolveRequest]
     * (#CodeLensResolveRequest)
     */
    data?: any;
  }
	/**
	 * The CodeLens namespace provides helper functions to work with
	 * [CodeLens](#CodeLens) literals.
	 */
  export namespace CodeLens {
    /**
     * Creates a new CodeLens literal.
     */
    function create(range: Range, data?: any): CodeLens;
    /**
     * Checks whether the given literal conforms to the [CodeLens](#CodeLens) interface.
     */
    function is(value: any): value is CodeLens;
  }
	/**
	 * Value-object describing what options formatting should use.
	 */
  export interface FormattingOptions {
    /**
     * Size of a tab in spaces.
     */
    tabSize: number;
    /**
     * Prefer spaces over tabs.
     */
    insertSpaces: boolean;
    /**
     * Signature for further properties.
     */
    [key: string]: boolean | number | string;
  }
	/**
	 * The FormattingOptions namespace provides helper functions to work with
	 * [FormattingOptions](#FormattingOptions) literals.
	 */
  export namespace FormattingOptions {
    /**
     * Creates a new FormattingOptions literal.
     */
    function create(tabSize: number, insertSpaces: boolean): FormattingOptions;
    /**
     * Checks whether the given literal conforms to the [FormattingOptions](#FormattingOptions) interface.
     */
    function is(value: any): value is FormattingOptions;
  }
	/**
	 * A document link is a range in a text document that links to an internal or external resource, like another
	 * text document or a web site.
	 */
  export class DocumentLink {
    /**
     * The range this link applies to.
     */
    range: Range;
    /**
     * The uri this link points to.
     */
    target?: string;
  }
	/**
	 * The DocumentLink namespace provides helper functions to work with
	 * [DocumentLink](#DocumentLink) literals.
	 */
  export namespace DocumentLink {
    /**
     * Creates a new DocumentLink literal.
     */
    function create(range: Range, target?: string): DocumentLink;
    /**
     * Checks whether the given literal conforms to the [DocumentLink](#DocumentLink) interface.
     */
    function is(value: any): value is DocumentLink;
  }
  export const EOL: string[];
	/**
	 * A simple text document. Not to be implemenented.
	 */
  export interface TextDocument {
    /**
     * The associated URI for this document. Most documents have the __file__-scheme, indicating that they
     * represent files on disk. However, some documents may have other schemes indicating that they are not
     * available on disk.
     *
     * @readonly
     */
    readonly uri: string;
    /**
     * The identifier of the language associated with this document.
     *
     * @readonly
     */
    readonly languageId: string;
    /**
     * The version number of this document (it will increase after each
     * change, including undo/redo).
     *
     * @readonly
     */
    readonly version: number;
    /**
     * Get the text of this document.
     *
     * @return The text of this document.
     */
    getText(): string;
    /**
     * Converts a zero-based offset to a position.
     *
     * @param offset A zero-based offset.
     * @return A valid [position](#Position).
     */
    positionAt(offset: number): Position;
    /**
     * Converts the position to a zero-based offset.
     *
     * The position will be [adjusted](#TextDocument.validatePosition).
     *
     * @param position A position.
     * @return A valid zero-based offset.
     */
    offsetAt(position: Position): number;
    /**
     * The number of lines in this document.
     *
     * @readonly
     */
    readonly lineCount: number;
  }
  export namespace TextDocument {
    /**
     * Creates a new ITextDocument literal from the given uri and content.
     * @param uri The document's uri.
     * @param languageId  The document's language Id.
     * @param content The document's content.
     */
    function create(uri: string, languageId: string, version: number, content: string): TextDocument;
    /**
     * Checks whether the given literal conforms to the [ITextDocument](#ITextDocument) interface.
     */
    function is(value: any): value is TextDocument;
  }
	/**
	 * Event to signal changes to a simple text document.
	 */
  export interface TextDocumentChangeEvent {
    /**
     * The document that has changed.
     */
    document: TextDocument;
  }
	/**
	 * Represents reasons why a text document is saved.
	 */
  export namespace TextDocumentSaveReason {
    /**
     * Manually triggered, e.g. by the user pressing save, by starting debugging,
     * or by an API call.
     */
    const Manual: 1;
    /**
     * Automatic after a delay.
     */
    const AfterDelay: 2;
    /**
     * When the editor lost focus.
     */
    const FocusOut: 3;
  }
  export type TextDocumentSaveReason = 1 | 2 | 3;
  export interface TextDocumentWillSaveEvent {
    /**
     * The document that will be saved
     */
    document: TextDocument;
    /**
     * The reason why save was triggered.
     */
    reason: TextDocumentSaveReason;
  }
	/**
	 * An event describing a change to a text document. If range and rangeLength are omitted
	 * the new text is considered to be the full content of the document.
	 */
  export interface TextDocumentContentChangeEvent {
    /**
     * The range of the document that changed.
     */
    range?: Range;
    /**
     * The length of the range that got replaced.
     */
    rangeLength?: number;
    /**
     * The new text of the document.
     */
    text: string;
  }

}
