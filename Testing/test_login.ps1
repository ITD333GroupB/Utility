param(
    [string]$BaseUrl = "http://localhost:5253",
    [string]$Username = "alice",
    [string]$Password = "Password123!"
)

$endpoint = "$BaseUrl/api/auth/login"
$payload = @{ Username = $Username; Password = $Password } | ConvertTo-Json

Write-Host "POST $endpoint" -ForegroundColor Cyan

try {
    $response = Invoke-RestMethod -Uri $endpoint -Method Post -ContentType "application/json" -Body $payload -ErrorAction Stop
    Write-Host "Status: Success" -ForegroundColor Green
    $response | ConvertTo-Json -Depth 5
}
catch {
    Write-Host "Status: Failed" -ForegroundColor Red
    if ($_.Exception.Response -and $_.Exception.Response.ContentLength -gt 0) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $errorContent = $reader.ReadToEnd()
        Write-Host "Response:" -ForegroundColor Yellow
        Write-Host $errorContent
    }
    else {
        Write-Host $_
    }
    exit 1
}
