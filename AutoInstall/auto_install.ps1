$urls = Get-Content (Join-Path $PSScriptRoot 'installinks.txt')
$dir = (Get-Location).Path
$i = 0
foreach($url in $urls){
	if(-not $url.Trim()){continue}
	$i++
	$name = "installer_$i" + [IO.Path]::GetExtension(([Uri]$url).AbsolutePath)
	Invoke-WebRequest $url -OutFile (Join-Path $dir $name)
}
