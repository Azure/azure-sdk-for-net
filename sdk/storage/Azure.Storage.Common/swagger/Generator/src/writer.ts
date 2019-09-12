// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

// IndentWriter provides helpful features for writing blocks of indented text
// (like source code, JSON, etc.).
export default class IndentWriter {
    // The buffer where text is written.  It is obtained by the user via
    // IndentWriter.toString().
    private _content = "";

    // Whether or not the last character written was a newline character
    // (which means the next line written should automatically add the
    // current indent depth).
    private _isNewline = true;

    // Gets or sets the text used as each indent character (i.e., could be
    // a single tab character or four space characters).  The default value
    // is four space characters.
    indentText = "    ";

    // Gets the depth of the current indent level.
    indent = 0;

    // A count of the number of write operations.
    private _version = 0;

    // Gets a count of the number of write operations.  This is a bit hacky
    // but allows you to pass an IndentWriter around and easily tell if it
    // has been modified outside of your code.
    get version(): number { return this._version; }

    // Initializes a new instance of the IndentWriter class.
    constructor() {
    }

    // Gets the text that has been written thus far.
    toString() { return this._content; }

    // Increase the indent level after writing the text representation of
    // the given values to the current line.  This would be used like:
    //     writer.pushScope("{");
    //     /* Write indented lines here */
    //     writer.popScope("}");
    pushScope(text?: string) {
        this.line(text);
        this.indent++;
    }

    // Decrease the indent level after writing the text representation of
    // the given values to the current line.  This would be used like:
    //     writer.PushScope("{");
    //     /* Write indented lines here */
    //     writer.PopScope("}");
    popScope(text?: string) {
        if (this.indent === 0) {
            throw `Cannot pop indent scope any further!`;
        }
        this.indent--;

        // Force the format string to be written on a new line, but don't
        // add an extra one if we just wrote a newline.
        if (!this._isNewline)
        {
            this.line();
        }

        if (text) {
            this.line(text);
        }
    }

    // Create a writer scope that will indent until the scope is disposed.
    // This is used like:
    //     writer.scope('{', '}', () => {
    //         /* Write indented lines here */
    ///    });
    //     /* Back to normal here */
    scope(
        startOrAction: string|undefined|(() => void),
        end?: string,
        action?: () => void) {

        let start: string|undefined = typeof startOrAction === 'string' ? startOrAction : undefined;
        action = typeof startOrAction === 'function' ? startOrAction : action;
        this.pushScope(start);
        if (action) {
            action();
        }
        this.popScope(end);
    }

    // Create a writer scope that will indent until the scope is disposed.
    // This is used like:
    //     writer.scopeAsync('{', '}', () => {
    //         await /* Write indented lines here */
    ///    });
    //     /* Back to normal here */
    async scopeAsync(
        startOrAction: string|undefined|(() => Promise<void>),
        end?: string,
        action?: () => Promise<void>) {
        
        let start: string|undefined = typeof startOrAction === 'string' ? startOrAction : undefined;
        action = typeof startOrAction === 'function' ? startOrAction : action;

        this.pushScope(start);
        if (action) {
            await action();
        }
        this.popScope(end);
    }

    // Writes an indent if needed.  This is used before each write
    // operation to ensure we're always indenting.  We don't need to indent
    // for a series of calls like Write("Foo"); Write("Bar"); but would
    // indent between a series like WriteLine("Foo"); Write("Bar");
    private writeIndentIfNeeded() {
        // If we had just written a full line
        if (this._isNewline) {
            // Then we'll write out the current indent depth before anything
            // else is written
            this._isNewline = false;
            for (let i = 0; i < this.indent; i++)
            {
                this._content += this.indentText;
            }
        }
    }

    // Write the text representation of the given values with indentation
    // as appropriate.
    write(text?: string) {        
        if (text) {
            this.writeIndentIfNeeded();
            this._content += text;
        }

        // Increment a global counter that can be used to track changes by
        // letting consumers verify whether any additional write operations
        // were called by other code.  Note that every write operation in
        // this class eventually calls this method so we can handle it in a
        // single location.
        this._version++;
    }

    // Write the text representation of the given values followed by a
    // newline, with indentation as appropriate.  This will force the next
    // write call to indent before anything else is written.
    line(text?: string) {
        this.write(text);
        this._content += '\n';

        // Track that we just wrote a line so the next write operation will
        // indent first
        this._isNewline = true;
    }

    // Creates a function that returns false the first time it's called and
    // true forever after.  It's useful in adding commas, etc., between items.
    static createFenceposter() {
        let required = false;
        return () => {
            const current = required;
            required = true;
            return current;
        };
    }
}
