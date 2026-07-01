# Rula.Persistence.Unity

Unity integration package for [Rula.Persistence repository](https://github.com/RuslanHetmanchyk/Rula.Persistence?utm_source=chatgpt.com).

This package provides Unity-specific implementations for:

* storage
* serialization
* logging
* time provider
* default `SaveManager` configuration

The package is designed to be installed through Unity Package Manager using a Git URL.

---

## Requirements

* Unity 2021.3 LTS or newer
* .NET Standard 2.1 compatible Unity runtime

---

# Installation

## Install via Git URL

Open:

```
Window → Package Manager
```

Click:

```
+
```

Select:

```
Add package from git URL
```

Enter:

```
https://github.com/RuslanHetmanchyk/Rula.Persistence.Unity.git
```

To install a specific version:

```
https://github.com/RuslanHetmanchyk/Rula.Persistence.Unity.git#v0.1.0
```

---

# Quick Start

Create a default configured `SaveManager`:

```csharp
using Rula.Persistence.Unity.Extensions;

var saveManager = SaveManagerFactory.CreateDefault();
```

The factory creates a complete Unity persistence pipeline:

* `PersistentDataStorage`
* `NewtonsoftSaveSerializer`
* `UnitySaveLogger`
* `UnityClock`

Example:

```csharp
var saveManager = SaveManagerFactory.CreateDefault();

await saveManager.SaveAsync("player-slot");

await saveManager.LoadAsync("player-slot");
```

---

# Basic Usage Sample

The package includes a complete usage example.

To import the sample:

```
Window
→ Package Manager
→ Rula Persistence Unity
→ Samples
→ Basic Usage
→ Import
```

The sample demonstrates:

* creating `SaveManager`
* registering saveable data
* saving player state
* loading player state
* using Unity UI with persistence

After importing, open:

```
Assets
└── Samples
    └── Rula.Persistence.Unity
        └── 0.1.0
            └── BasicUsage
                └── Scenes
                    └── BasicUsage.unity
```

---

# Package Structure

```
Rula.Persistence.Unity

Runtime
│
├── Plugins
│   ├── Rula.Persistence.dll
│   └── Newtonsoft.Json.dll
│
└── Unity
    │
    ├── Logging
    │   └── UnitySaveLogger
    │
    ├── Storage
    │   └── PersistentDataStorage
    │
    ├── Serialization
    │   └── NewtonsoftSaveSerializer
    │
    ├── Extensions
    │   └── SaveManagerFactory
    │
    └── UnityClock
```

---

# Architecture

The package follows a layered architecture.

```
Rula.Persistence
        |
        |
        v
Rula.Persistence.Unity

        |
        |
        +-- PersistentDataStorage
        |
        +-- NewtonsoftSaveSerializer
        |
        +-- UnitySaveLogger
        |
        +-- UnityClock
```

Core persistence logic remains independent from Unity.

The Unity package only provides platform-specific implementations.

---

# Development

## Local Development

Clone repository:

```
git clone https://github.com/RuslanHetmanchyk/Rula.Persistence.Unity.git
```

Open the package through Unity Package Manager:

```
Package Manager
→ Add package from disk
```

Select:

```
package.json
```

---

## Package Development Structure

### Runtime

Contains runtime code included in Unity builds.

```
Runtime
```

### Samples

Contains optional examples imported through Unity Package Manager.

```
Samples~
```

---

# Dependencies

Included inside the package:

* Rula.Persistence core library
* Newtonsoft.Json runtime dependency

No additional Unity packages are required.

---

# Versioning

Current version:

```
0.1.0
```

The package follows semantic versioning.

---

# License

MIT License
