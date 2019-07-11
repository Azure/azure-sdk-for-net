# This Script Creates the toc.yml file that groups the articles page
import os
import re
import sys

sourceDir = sys.argv[1]
articleDirPath = "{0}/docfx_project/articles".format(sourceDir)
articleTocPath = os.path.join(articleDirPath, 'toc.yml')

try:
    with open(articleTocPath, "w") as articlesToc:
        articlesToc.write('- name: Home\n')
        articlesToc.write('  href: intro.md\n')
        articlesToc.write('- name: General User Docs\n')
        articlesToc.write('  items:\n')

        # Articles
        for file in os.listdir(articleDirPath):
            if file.startswith('intro') or file.startswith('toc'):
                continue
            if not file.startswith('-'):
                articlesToc.write('    - name: {0}\n'.format(file[:-3]))
                articlesToc.write('      href: {0}\n'.format(file))

        articlesToc.write('- name: ReadMes\n')
        articlesToc.write('  items:\n')

        # For ReadMes
        for file in os.listdir(articleDirPath):
            if file.startswith('intro') or file.startswith('toc'):
                continue
            if file.startswith('-'):
                articlesToc.write('    - name: {0}\n'.format(file[1:-3]))
                articlesToc.write('      href: {0}\n'.format(file))
except IOError:
    print("Error: File does not appear to exist")