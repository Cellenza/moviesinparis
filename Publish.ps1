[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True)] [string] $BuildConfiguration,
    [Parameter(Mandatory=$True)] [string] $packOutput
)
# Run tests
& scripts/Call-Dnu.ps1 publish .\MoviesInParis\src\MoviesInParis --out $packOutput --configuration $BuildConfiguration --wwwroot "wwwroot" --wwwroot-out "wwwroot"

