"""Validate all GitHub links in sample-matrix.md by checking HTTP status codes."""

import re
import sys
import time
import argparse
from concurrent.futures import ThreadPoolExecutor, as_completed
from pathlib import Path
from urllib.request import Request, urlopen
from urllib.error import HTTPError, URLError


def extract_links(md_path: str) -> list[str]:
    """Extract all unique GitHub URLs from a markdown file."""
    content = Path(md_path).read_text(encoding="utf-8")
    urls = set(re.findall(r"https://github\.com/Azure/[^\s\)\],]+", content))
    return sorted(urls)


def check_link(url: str, retries: int = 2, backoff: float = 2.0) -> tuple[str, int | str]:
    """HEAD-request a URL and return (url, status_code or error string)."""
    for attempt in range(retries + 1):
        try:
            req = Request(url, method="HEAD", headers={"User-Agent": "link-checker/1.0"})
            with urlopen(req, timeout=15) as resp:
                return url, resp.status
        except HTTPError as exc:
            if exc.code == 429:
                wait = backoff * (2 ** attempt)
                print(f"  Rate-limited on {url}, retrying in {wait:.0f}s …")
                time.sleep(wait)
                continue
            return url, exc.code
        except URLError as exc:
            return url, str(exc.reason)
        except Exception as exc:
            return url, str(exc)
    return url, "rate-limited after retries"


def main() -> None:
    parser = argparse.ArgumentParser(description="Validate GitHub links in a markdown file.")
    parser.add_argument(
        "file",
        nargs="?",
        default=str(Path(__file__).with_name("sample-matrix.md")),
        help="Path to the markdown file (default: sample-matrix.md next to this script)",
    )
    parser.add_argument(
        "-j", "--jobs",
        type=int,
        default=5,
        help="Number of parallel requests (default: 5)",
    )
    args = parser.parse_args()

    md_path = args.file
    if not Path(md_path).exists():
        print(f"Error: file not found: {md_path}")
        sys.exit(2)

    urls = extract_links(md_path)
    print(f"Found {len(urls)} unique GitHub links in {md_path}\n")

    broken: list[tuple[str, int | str]] = []
    ok_count = 0

    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        futures = {pool.submit(check_link, url): url for url in urls}
        for i, future in enumerate(as_completed(futures), 1):
            url, status = future.result()
            if isinstance(status, int) and status < 400:
                ok_count += 1
            else:
                broken.append((url, status))
                print(f"  BROKEN ({status}): {url}")
            if i % 50 == 0:
                print(f"  … checked {i}/{len(urls)}")

    print(f"\n{'=' * 60}")
    print(f"Total links : {len(urls)}")
    print(f"OK          : {ok_count}")
    print(f"Broken      : {len(broken)}")

    if broken:
        print(f"\n{'─' * 60}")
        print("Broken links:")
        for url, status in sorted(broken):
            print(f"  [{status}] {url}")
        sys.exit(1)
    else:
        print("\nAll links are valid ✓")
        sys.exit(0)


if __name__ == "__main__":
    main()
