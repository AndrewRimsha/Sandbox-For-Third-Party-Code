# Sandbox
## GUI
The developed application allows you to run third-party code with limited rights both with a graphical interface and using the command line.
<br><br>
![Main Form](https://github.com/AndrewRimsha/Sandbox-For-Third-Party-Code/blob/main/screenshots/01_Main_Form.png "Main Form")
1. Textbox with the path to the program to be executed.
2. Button to open window to find the path to the program to be executed.
3. Textbox with (optional) the command used to supply any arguments required by the executing program.
4. Button to clear textbox with arguments (3).
5. List of permissions.
6. Flags for chosen permission in list of permissions (5).
7. Button to add permission with chosen flags (6).
8. Button to invert selected items in the list of applied permissions (11).
9. Button to unselect all items in the list of applied permissions (11).
10. Button to select all items in the list of applied permissions (11).
11. List of applied permissions.
12. Button to sort all items in the list of applied permissions (11).
13. Button to remove selected items in the list of applied permissions (11).
14. Button to remove all items in the list of applied permissions (11).
15. The output textbox for errors and text from the executed program.
16. Button to launch the executed program.
17. Button to exit from SandboxTool.

<br><br>
To use the SandboxTool GUI, follow the steps below:
![Using SandboxTool GUI](https://github.com/AndrewRimsha/Sandbox-For-Third-Party-Code/blob/main/screenshots/02_Using_SandBox_Tool.png "Using SandboxTool GUI")
1. Click button “Path” and specify the path to the program to be executed.
2. Enter the arguments to send to the program to execute (optional).
3. Click the "Launch" button to check the required permission.
4. In the output textbox, check the required permission and its flag.
5. Chose the required permission from step 4.
6. Chose the required flag from step 4.
7. Click button “Add” to add the permission to the list of applied permission _(only permissions with checked checkboxes are used when click the “Launch” button)_.

<br><br>
## CONSOLE COMMAND
<br>
<table class='tg'>
  <thead>
    <tr>
      <th>
        <b>C:\> [sandbox filepath] [program to execute filepath] -perm [permissions] -args [arguments]</b>
      </th>
    </tr>
  </thead>
</table>
<br>

<table>
  <thead>
    <tr>
      <th>-</th>
      <th><b>[sandbox filepath]</b></th>
      <th></th>
      <th>-</th>
      <th>the path to the SandboxTool, ending in “sandbox.exe” (surrounded quotation marks if the path contains spaces).</th>
    </tr>
    <tr>
      <th>-</th>
      <th><b>[program to execute filepath]</b></th>
      <th></th>
      <th>-</th>
      <th>the path to the program to be executed (surrounded quotation marks if the path contains spaces).</th>
    </tr>
    <tr>
      <th>-</th>
      <th><b>-perm</b></th>
      <th></th>
      <th>-</th>
      <th>(optional) the command used to apply permissions to the executing program.</th>
    </tr>
    <tr>
      <th></th>
      <th>▪</th>
      <th><b>[permissions]</b></th>
      <th>-</th>
      <th>one or more permissions names separated by spaces. If permission flag required path or name of machine use “;Path:[path]” – where the [path] is full path for argument.</th>
    </tr>
    <tr>
      <th>-</th>
      <th><b>-args</b></th>
      <th></th>
      <th>-</th>
      <th>(optional) the command used to supply any arguments required by the executing program.</th>
    </tr>
    <tr>
      <th></th>
      <th>▪</th>
      <th><b>[arguments]</b></th>
      <th>-</th>
      <th>one or more command line arguments required by the executing program.</th>
    </tr>
  </thead>
</table>

### Exception message
<br>
If the permissions are not enough, an exception message will be shown:
<table>
  <thead>
    <tr>
      <th>
        <b>Add: -perm FileIOPermission.Unrestricted <br><br>Message: Request for the permission of type 'System.Security.Permissions.FileIOPermission, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089' failed.</b>
      </th>
    </tr>
  </thead>
</table>
In this case it is necessary to add <b>FileIOPermission.Unrestricted</b>.
