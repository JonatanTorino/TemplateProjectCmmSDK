param (
    [switch]$MustBuildModel
)

# Guarda la marca de tiempo de inicio
$inicio = Get-Date
Write-Host "Inicio: $inicio"

Import-Module d365fo.tools

$packagesLocalDirectory = "K:\AosService\PackagesLocalDirectory"
$metadata = Resolve-Path -Path ".\Metadata"

# Task 1: Listado de modelos
$modelList = Get-ChildItem -Path $metadata -Directory |  Select-Object -ExpandProperty Name

for ($i = 0; $i -lt $modelList.Count; $i++) {
    Write-Host "$($i + 1): $($modelList[$i])"
}

$selection = Read-Host "Seleccione un modelo (Ingrese el número)"

if ($selection -ge 1 -and $selection -le $modelList.Count) {
    $modelName = $modelList[$selection - 1]
    Write-Host "Ha seleccionado el modelo: $modelName"
}
else {
    Write-Host -ForegroundColor Red "Número de selección inválido. Inténtelo de nuevo."
}

if ([string]::IsNullOrEmpty($modelName))
{
    throw [System.IO.DirectoryNotFoundException] 
}

Write-Host
Write-Host
# Task 2: Create a symbolic link
Write-Host -ForegroundColor Yellow "Deteniendo todos los servicios de D365FO"
Stop-D365Environment


$targetPath = Join-Path $metadata -ChildPath $modelName
$linkPath = Join-Path $packagesLocalDirectory -ChildPath $modelName

Write-Host -ForegroundColor Blue "Remove existing directory if it exists $linkPath"
cmd /c rmdir /q /s $linkPath

Write-Host -ForegroundColor Blue "Create a symbolic link to $targetPath"
Write-Host
New-Item -ItemType SymbolicLink -Path $linkPath -Target $targetPath
Write-Host


# Task 3: Compile the model
if ($MustBuildModel) {
    Write-Host -ForegroundColor Green  "Executing the D365 module compile and sync command: $modelName"
    Invoke-D365ProcessModule -Module $modelName -ExecuteCompile -ExecuteSync
}

Write-Host -ForegroundColor Yellow "Iniciando el servicio del AOS de D365FO"
Start-D365Environment -Aos
Write-Host -ForegroundColor Yellow "Iniciando el servicio del BATCH de D365FO"
Start-D365Environment -Batch

# Guarda la marca de tiempo de finalización
$fin = Get-Date
# Imprime las marcas de tiempo y el tiempo transcurrido
Write-Host "Inicio: $inicio"
Write-Host "Final: $fin"
$tiempoTranscurrido = $fin - $inicio
Write-Host -ForegroundColor Magenta "Tiempo total transcurrido: $tiempoTranscurrido"
