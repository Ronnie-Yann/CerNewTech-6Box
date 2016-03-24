@echo off
echo 优化网络配置中....
netsh int ipv6 set prefix ::1/128 50 0
netsh int ipv6 set prefix ::/0 40 1
netsh int ipv6 set prefix 2002::/16 30 1
netsh int ipv6 set prefix ::/96 20 3
netsh int ipv6 set prefix ::ffff:0:0/96 10 4
netsh int ipv6 set prefix 2001::/32 5 1 
echo 网络配置优化完毕

Powershell.exe -executionpolicy UnRestricted -File  .\configipv4.ps1