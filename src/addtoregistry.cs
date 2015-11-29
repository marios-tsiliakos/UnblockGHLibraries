  //generate the registry file to add the right-click unblock option to your windows
  private static void UnblockRegistry(string[] a, string p, out string reg_file)
  {
    string[] my_text = a;
    string my_directory = p + @"\unblock_key.reg";
    if (!File.Exists(my_directory))
    {
      System.IO.File.WriteAllLines(my_directory, my_text);
    }
    reg_file = my_directory;
  }
  
    //add the generated key to the registry (subject to admin rights)
  private static void AddToRegistry(string d)
  {
    System.Diagnostics.Process regeditProcess = System.Diagnostics.Process.Start("regedit.exe", "\"" + d + "\"");
    regeditProcess.WaitForExit();
  }
  
