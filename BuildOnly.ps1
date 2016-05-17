[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True)] [string] $BuildConfiguration
)

#Install dnvm
& scripts/Install-Dnvm.ps1

# Build projects
& scripts/Call-Dnu.ps1 build .\MoviesInParis\src\MoviesInParis --configuration $BuildConfiguration 