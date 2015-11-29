//Unblocker public class
  public class Unblocker
  {
    //import external
    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteFile(string name);

    public static bool IsBlocked(string Name)
    {
      bool zone_bool;
      System.Security.Policy.Zone my_zone = System.Security.Policy.Zone.CreateFromUrl(Name);
      if (my_zone.SecurityZone != System.Security.SecurityZone.MyComputer)
      {
        zone_bool = true;
      }
      else
      {
        zone_bool = false;
      }

      return zone_bool;
    }

    public static bool UnblockFile(string Name)
    {
      return DeleteFile(Name + ":Zone.Identifier");
    }
  }
