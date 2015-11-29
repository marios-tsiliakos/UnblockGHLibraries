  private void RunScript(bool Run, bool Add)
  {

    #region checks
    if (Component.Params.Input[0].VolatileDataCount == 0)
    {
      Print("Connect a button component to the run input.");
    }
    if (Component.Params.Input[1].VolatileDataCount == 0)
    {
      Print("Default value is set to False / Connect a toggle component to the Add input if you want to change the default behaviour.");
    }
    #endregion

    if (Run == true)
    {
      //declare some variables
      string directory = my_userpath;
      string gh_libraries;
      string gh_user_object_lib;
      string registry_file;
      List <string> my_files;
      List <string> my_blocked_files;
      int block_counter;

      if (Add == true){
        // if true a right-click unblock option will appear in your registry
        UnblockRegistry(unb_reg(), directory, out registry_file);
        AddToRegistry(registry_file);
        File.Delete(registry_file);
        mes01 = ("Added a right-click unblock option to your local registry.Remember you have to manualy delete the key from your registry if you want to get rid of the extra option. It is located at HKEY_CLASSES_ROOT|*|shell|powershell,(delete the powershell keys).");
      }
      else{
        //else prompt for a right-click unblock option will appear in your registry
        mes01 = ("Turn the Add boolean to true to a install a right-click unblock option to your local registry.");
      }

      UnblockGHLibraries(directory, out gh_libraries, out gh_user_object_lib, out my_files, out block_counter, out my_blocked_files);
      mes = ("Found " + my_files.Count() + " add-ons in your local GH directory. Also found " + block_counter + " blocked add-ons , which will attempt to unblock.");

    }
    //output info
    Print(mes);
    Print(mes01);
