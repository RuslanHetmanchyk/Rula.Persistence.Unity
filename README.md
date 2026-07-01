# Rula.Persistence.Unity

Unity adapter package for [Rula.Persistence](https://github.com/RuslanHetmanchyk/Rula.Persistence).

This package provides Unity-specific implementations and integrations for the core persistence library.

The package is designed to be used as a Unity Package Manager (UPM) package and can be installed directly from a Git repository.

## Requirements

* Unity 2021.3 LTS or newer

## Installation

### Install via Git URL

Open Unity Package Manager:

```
Window → Package Manager → Add package from git URL...
```

Enter the repository URL:

```
https://github.com/RuslanHetmanchyk/Rula.Persistence.Unity.git
```

Unity will download and install the package automatically.

## Quick Start

Create a SaveManager with the default Unity configuration:

```csharp
using Rula.Persistence.Unity.Extensions;

var saveManager = SaveManagerFactory.CreateDefault();

## Local Development

For local package development, add the package from disk:

```
+
→ Add package from disk...
```

Select the `package.json` file located in the root directory of this repository.

This allows developing the package directly while testing it inside a Unity project.

## Package Structure

The package follows the standard Unity Package Manager structure:

```
Runtime/
└── Unity/
    ├── Serialization/
    ├── Storage/
    ├── Logging/
    └── Extensions/
```

## Architecture

`Rula.Persistence.Unity` contains only Unity-specific code.

Core persistence functionality is provided by the `Rula.Persistence` library and is intentionally kept separate from this package.

The Unity package acts as an adapter layer that integrates the core library with Unity-specific systems.

## License

MIT
