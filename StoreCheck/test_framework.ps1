$reg = Get-ItemProperty -Path 'HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full'
Write-Host "Build: $($reg.Version)"
$release = $reg.Release
Write-Host "Release: $release / " -NoNewline
switch ($release) {
    '378389' { '.NET 4.5' }
    '378675' { '.NET 4.5.1' <# Win 8.1/2012 R2 #> }
    '378758' { '.NET 4.5.1' }
    '379893' { '.NET 4.5.2' }
    '393295' { '.NET 4.6' <# Win 10 #> }
    '393297' { '.NET 4.6' }
    '394254' { '.NET 4.6.1' <# Win 10 Nov Update #> }
    '394271' { '.NET 4.6.1' }
    '394802' { '.NET 4.6.2' <# Win 10 Anniversary Update / Win 2016 #> }
    '394806' { '.NET 4.6.2' }
    '460798' { '.NET 4.7' <#  Win 10 Creators Update #> }
    '460805' { '.NET 4.7' }
    '461308' { '.NET 4.7.1' <# Win 10 Fall Creators / Win Server 1709 #> }
    '461310' { '.NET 4.7.1' }
    '461808' { '.NET 4.7.2' <# Win 10 Apr 2018  / Win Server 1803 #> }
    '461814' { '.NET 4.7.2' }
    '528040' { '.NET 4.8' <# Win 10 May 2019 / Win 10 Nov 2019 #> }
    '528372' { '.NET 4.8' <# Win 10 May 2020 / Win 10 Oct 2020 / Win 10 May 2021 #> }
    '528449' { '.NET 4.8' <# Win 11 / Win 2022 #> }
    '528049' { '.NET 4.8' }
    Default { "Unknown - $release" }
}