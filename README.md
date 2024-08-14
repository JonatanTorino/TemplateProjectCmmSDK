# TemplateProjectCmmSDK
Repositorio modelo para proyectos con D365 Commerce

## Installation

### Using Power Shell

Copy and past

```powershell
# Task 1: Clone the repository
$repositoryUrl = "https://github.com/JonatanTorino/TemplateProjectCmmSDK.git"
$localRepoPath = "K:\Repos\TemplateProjectCmmSDK"

# Clone or pull the repository
git clone $repositoryUrl $localRepoPath | Wait-Process
# En caso que existiera previamente la carpeta, por las dudas ejecuto un pull
Set-Location $localRepoPath
git pull

# Task 2: Execute the D365FO Models installation
.\InstallMetadataSymbolinkLink.ps1

```
