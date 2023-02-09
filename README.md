# XAMPP multihost

If you ever want to host (and use) mutiple web sites in single XAMPP installation you can use this tool to 
create/delete multiple (virtual) hosts that will be accessible via browser.


## How to use it?

Get and copy xampp-multihost.exe into XAMPP directory (same location where xampp-control.exe is). 
Program is completely portable and it will find everything from its running directory.

In upper list box a list of defined virtual hosts is displayed.

To create new virtual host press "Create" and enter a hosts name. Program will:
- create an entry in /xampp/apache/conf/extra/httpd-vhosts.conf that describe vhost-name
```
<VirtualHost *:80>
    ServerName vhost-name
    DocumentRoot "/xampp/htdocs.vhost-name"
    <Directory "/xampp/htdocs.vhost-name">
        Options Indexes FollowSymLinks
        AllowOverride All
        Require all granted
    </Directory>
</VirtualHost>
```
- create an entry (if already not exist) in hosts file that point vhost-name to 127.0.0.1 
```
127.0.0.1   vhost-name
```
- create (if already not exist) /xampp/htdocs.vhost-name directory with default index.html inside

To delete virtual host, select an item in listbox and press "Delete". Program will ask you are you sure and if you confirm it will:
- delete entry in /xampp/apache/conf/extra/httpd-vhosts.conf that describe vhost-name
- it will also ask if you want to delete entry in hosts file
- it will NOT DELETE /xampp/htdocs.vhost-name directory !!!! (just in case)

If entry in list box is red that mean that there are no entry in hosts file associated with that virtual host. 
This could happened if you move your XAMPP on USB stick to some other PC. 
If you select this item a button "Add to hosts file" will apear. Pressing it you'll be able to add entry to hosts file.

**NOTE THAT IF YOU ADD/DELETE/MODIFY SOMETHING YOU'll NEED TO RESTART APACHE IN ORDER TO SEE THIS CHANGES**

## Why administrative rights?

To succesfully add virtual hosts that can be accessible via web browser, a web address must be added to your system somehow. Program 
use and modify hosts file (which is located into windows directory) to add virtual hosts entry and for that it need administrative rights

## How to compile? 

Load xampp-multihost.sln into Visual studio 2019 (or similar) and build it. Program use .NET Framework 4.6.1 and have no any other dependencies.

