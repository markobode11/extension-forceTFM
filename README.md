# UpgradeAssistant.Extension.ForceTFM

.NET Upgrade Assistant extension for forcing all assemblies to selected target framework.

## Overview

This extension is created by using Upgrade Assistants
extension system.

This extension forces Upgrade Assistant to target the same framework for all assemblies instead of, for instance,
Class Libraries targeting .netstandard2.0 after upgrade.

Note that upon adding this extension to Upgrade Assistant, the behavior of the tool already changes.

Similarly to the Upgrade Assistant, this extension allows you to specify TFM with one of three values:
* Current
* LTS
* Preview

Currently the default value for this extension is LTS.

Also like the Upgrade Assistant, all of these values currently point to .net6.0

If you wish to force all frameworks to something else then there is a [way](README.md#change-the-value-of-current-lts-or-preview) for that.

## Usage
 
### Prerequisites

Make sure the [Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) itself runs.

### Upgrade Path

NuGet can be added to the Upgrade Assistant via `upgrade-assistant extensions add UpgradeAssistant.Extension.ForceTFM`.
Upgrade Assistant running path will remain the same.

Extension can be removed via `upgrade-assistant extensions remove UpgradeAssistant.Extension.ForceTFM`

Cloned repository can be added as an extension via adding `--extension [path to dir containing ExtensionManifest and .dll file]` to the Upgrade Assistants running path.

### Choosing TFM

By default the extension targets LTS. If you wish to change that you can add `--option "ForceTFM:TFM=[VALUE]"` to the running path.

For example `--option "ForceTFM:TFM=Current"`

### Change the value of Current, LTS or Preview

If you wish to change the framework that the pointers point at you can add `--option "TFMOptionMap:[Pointer]=[VALUE]"` to the running path.

For example `--option "TFMOptionMap:Preview=.net7.0"`.

## Author
* **Marko Bode** - [markobode11](https://github.com/markobode11)
