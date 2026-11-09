#!/usr/bin/env python3
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.
"""Compare complete, captured central ApiCompat baseline XML documents.

Input and output are JSON on stdio. Never execute PR content or resolve entities.
"""
import collections
import json
import re
import sys
import xml.etree.ElementTree as ET


def entries(content):
    if content is None:
        return []
    if not isinstance(content, str) or len(content.encode('utf-8')) > 4 * 1024 * 1024:
        raise ValueError('Invalid or oversized baseline')
    if re.search(r'<!\s*(?:DOCTYPE|ENTITY)\b', content, re.I):
        raise ValueError('DTD and entity declarations are not allowed')
    root = ET.fromstring(content, parser=ET.XMLParser(target=ET.TreeBuilder(insert_comments=True)))
    if root.tag != 'Suppressions':
        raise ValueError('Unexpected baseline root')
    result = []
    comment = None
    for node in root:
        if node.tag is ET.Comment:
            comment = (node.text or '').strip() or None
            continue
        if node.tag != 'Suppression' or node.attrib:
            raise ValueError('Unexpected baseline element')
        fields = []
        for field in node:
            if not isinstance(field.tag, str) or field.attrib or len(field):
                raise ValueError('Unsupported suppression field')
            fields.append((field.tag, (field.text or '').strip()))
        fields.sort()
        if len({name for name, _ in fields}) != len(fields):
            raise ValueError('Duplicate suppression field')
        if not fields or not any(k == 'DiagnosticId' and v for k, v in fields) or not any(k == 'Target' and v for k, v in fields):
            raise ValueError('Incomplete suppression entry')
        result.append((tuple(fields), comment))
        # A comment immediately before an entry is evidence of nearby context,
        # not proof that it explains every later entry in the document.
        comment = None
    return result


def compare(files):
    result = []
    for file in files:
        old = collections.Counter(entry for entry, _ in entries(file['base']))
        for entry, comment in entries(file['head']):
            if old[entry]:
                old[entry] -= 1
            else:
                result.append({'path': file['path'], 'fields': dict(entry), 'nearby_comment': comment})
    return result


if __name__ == '__main__':
    try:
        json.dump(compare(json.load(sys.stdin)), sys.stdout, ensure_ascii=True)
    except (ValueError, KeyError, ET.ParseError, TypeError) as error:
        print(f'Invalid baseline input: {error}', file=sys.stderr)
        sys.exit(1)
