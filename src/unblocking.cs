  //method to unblock all the files in the Grasshopper libraries directory
  private static void UnblockGHLibraries(string path, out string return_gh_folder, out string return_user_objects, out List <string> dir_files, out int cnt, out List <string> bl_files)
  {
    string local_gh_dir = path + @"\AppData\Roaming\Grasshopper\Libraries";
    string local_gh_user_dir = path + @"\AppData\Roaming\Grasshopper\UserObjects";
    List <string> gh_files = new List <string>();
    int block_counter = 0;
    List <String> my_bl_files = new List<string>();
    if (Directory.Exists(local_gh_dir) && Directory.Exists(local_gh_user_dir))
    {
      string [] files1 = Directory.GetFiles(local_gh_dir, "*", SearchOption.AllDirectories);
      string [] files2 = Directory.GetFiles(local_gh_user_dir, "*", SearchOption.AllDirectories);
      string [] files = files1.Concat(files2).ToArray();

      foreach(string fileName in files)
      {
        gh_files.Add(fileName);
        bool blocked = Unblocker.IsBlocked(fileName);
        if (blocked)
        {
          block_counter++;
          my_bl_files.Add(fileName);
        }

        Unblocker.UnblockFile(fileName);
      }
    }
    else if ((!Directory.Exists(local_gh_user_dir)) && (!Directory.Exists(local_gh_dir)))
    {
      throw new DirectoryNotFoundException("Are you sure you have Grasshopper installed???? Your libraries directory doesn't seem to be in the right place");
    }
    return_gh_folder = local_gh_dir;
    return_user_objects = local_gh_user_dir;
    dir_files = gh_files;
    cnt = block_counter;
    bl_files = my_bl_files;
  }
