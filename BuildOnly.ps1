[CmdletBinding()]
Param(
	[Parameter(Mandatory=$True)] [string] $BuildConfiguration
)

# Install dnvm
& scripts/Install-Dnvm.ps1

# Restore projects
& scripts/Call-Dnu.ps1 restore .\MoviesInParis\src

# Build projects
& scripts/Call-Dnu.ps1 build .\MoviesInParis\src\MoviesInParis --configuration $BuildConfiguration 