  //private variables messages
  private string mes;
  private string mes01;
  
  // get the local directory
  private string my_userpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
  
    //the contents of the registry file
  private static string[] unb_reg()
  {
    #region Registryvalues
    string l1 = @"Windows Registry Editor Version 5.00";
    string l2 = " ";
    string l3 = @"[HKEY_CLASSES_ROOT\*\shell\powershell]";
    string l4 = @"@=" + @"""Unblock Files""";
    string l5 = " ";
    string l6 = @"[HKEY_CLASSES_ROOT\*\shell\powershell\command]";
    string l7 = @"@=""C:\\\\Windows\\\\system32\\\\WindowsPowerShell\\\\v1.0\\\\powershell.exe Unblock-File  -LiteralPath '%L'""";
    #endregion
    string[] conc = {l1,l2,l3,l4,l5,l6,l7};
    return conc;
  }
