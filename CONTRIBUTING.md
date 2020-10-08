# Contributing to the project

Thanks for taking the time to contribute! :sparkles:

In this document you will find all the information you need to make sure the
project continues to be the high-quality product we want to be!

## Reporting issues

### Issues

When reporting a problem, be as specific as possible. Ideally, you should
provide an small snippet of code that reproduces the issue. Try to provide also
the following information:

- OS: Linux / Windows / Mac OS
- Runtime: .NET Framework, Mono, .NET Core
- Version of the product
- Stacktrace if any
- What's happening and what you expect to happen

### Features

If you want to ask for a new feature, first make sure it hasn't been reported
yet by using the search box in the issue tab. Make sure that the feature aligns
with the direction of the project.

## Pull Request

Before starting a pull request, create an issue requesting the feature you would
like to see and implement. If you are fixing a bug, create also an issue to be
able to track the problem. State that you would like to work on that. The team
will reply to the issue as soon as possible, discussing the proposal if needed.
This guarantee that later on the Pull Request we don't reject the proposal
without having a discussion first and we don't waste time.

In general, the process to create a pull request is:

1. Create an issue describing the bug or feature and state you would like to
   work on that.
2. The team will cheer you and/or discuss with you the issue.
3. Fork the project.
4. Clone your forked project and create a git branch.
5. Make the necessary code changes in as many commits as you want.
6. Create a pull request. After reviewing your changes and making any new
   commits if needed, the team will approve and merge it.

## Code Guidelines

We follow the following standard guidelines with custom changes:

- [Mono Code Guidelines](https://raw.githubusercontent.com/mono/website/gh-pages/community/contributing/coding-guidelines.md).
- [Microsoft Framework Design Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)
- [Microsoft C# Coding Convetions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).

As the
[mono team says](https://www.mono-project.com/community/contributing/coding-guidelines/#performance-and-readability):

- It is more important to be correct than to be fast.
- It is more important to be maintainable than to be fast.
- Fast code that is difficult to maintain is likely going to be looked down
  upon.

And don't miss
[The Zen of Python](https://www.python.org/dev/peps/pep-0020/#id3):

```plain
Beautiful is better than ugly.
Explicit is better than implicit.
Simple is better than complex.
Complex is better than complicated.
Flat is better than nested.
Sparse is better than dense.
Readability counts.
Special cases aren't special enough to break the rules.
Although practicality beats purity.
Errors should never pass silently.
Unless explicitly silenced.
In the face of ambiguity, refuse the temptation to guess.
There should be one-- and preferably only one --obvious way to do it.
Although that way may not be obvious at first unless you're Dutch.
Now is better than never.
Although never is often better than *right* now.
If the implementation is hard to explain, it's a bad idea.
If the implementation is easy to explain, it may be a good idea.
Namespaces are one honking great idea -- let's do more of those!
```

### Quality

We focus on code-quality to make ours and others life easier. For that reason:

- :heavy_check_mark: **DO** write documentation for any public type and field.
- :heavy_check_mark: **DO** write a test for all the possible code branches of
  your methods. Use a TDD approach.
- :heavy_check_mark: **DO** seek for compiler warning free code.
- :heavy_check_mark: **DO** make sure the CI pass.
