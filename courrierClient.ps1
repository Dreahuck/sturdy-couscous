$dossier = Get-Location

function Remove-InvalidChars {
    param ($fileName)
    $invalidChars = [System.IO.Path]::GetInvalidFileNameChars()
    foreach ($char in $invalidChars) {
        $fileName = $fileName -replace [regex]::Escape($char), ''
    }
    return $fileName
}

Get-ChildItem -Path $dossier | ForEach-Object {
    $fichier = $_.Name
    
    if ($fichier -match "^(\d+)_Client(.+)$") {
        
        $idARecuperer = $matches[1]
        $nomClient = $matches[2]
        
        
        $nomClient = Remove-InvalidChars $nomClient

        
        $dateDerniereModif = $_.LastWriteTime.ToString("yyyyMMdd")

        
        $extension = $_.Extension

       
        $nouveauNom = "${dateDerniereModif}_COU_CourrierClient${nomClient}_${idARecuperer}${extension}"
        
        
        Rename-Item -Path $_.FullName -NewName (Join-Path $dossier $nouveauNom)
        Write-Host "Fichier $fichier renommé en $nouveauNom"
    }
}