using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  /// <summary>
  /// Statyczna klasa ktora zawiera algorytm 
  /// Wczytujący plik na wejsciu 
  /// Rozparsowuje plik 
  /// </summary>
  public static class Parser
  {
    /// <summary>
    /// List przechowująca obiekty MIB
    /// </summary>
    public static List<MIBObject> ListaObiektówMIB { get; set; }

    // <summary>
    /// List przechowująca obiekty sekwencji
    /// </summary>
    public static List<MIBSequence> ListaSekwencji { get; set; }

    static Parser()
    {
      // utworzenie list obiektow mib i sekwencji
      ListaObiektówMIB = new List<MIBObject>();
      ListaSekwencji = new List<MIBSequence>();
      /// zaladowanie drzewa
      Zaladuj_i_Sparsuj();
    }

    public static void Zaladuj_i_Sparsuj()
    {
      // asekuracyjne czyszczenie listy obiektow MIB 
      ListaObiektówMIB.Clear();

      RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
      // Wzorzec do naszego OBJECT-TYPE (name,syntax,access,status,description,parent,oid)
      //string pattern_ObjectType = @"(?<name>\w*)\s*OBJECT-TYPE\s*SYNTAX\s*(?<syntax>.*?)ACCESS\s*(?<access>.*?)STATUS\s*(?<status>.*?)DESCRIPTION\s*\""(?<description>.*?)\""?\s*::=\s*[{]\s*(?<parent>.*?)\s*(?=\d)(?<id>.*?)\s*[}]";
      string wzorzec_ObjectType = @"(?<name>\w*)\s*OBJECT-TYPE\s*SYNTAX\s*(?<syntax>.*?)\s*ACCESS\s*(?<access>.*?)\s*STATUS\s*(?<status>.*?)\s*DESCRIPTION\s*\""(?<description>.*?)\""?\s*::=\s*[{]\s*(?<parent>.*?)\s*(?=\d)(?<id>.*?)\s*[}]";

      // Wzorzec Regex: SEQUENCE (name,values)
      string wzorzec_Sequence = @"(?<name>\w*)\s*\:\:\=\s*(?<sequence>SEQUENCE)\s*\{(?<values>.*?)\s*[}]";

      // Wzorzec do Naszego OID OBJECT IDENTIFIER (name, parent, oid)
      string wzorzec_ObjectIdentifier = @"^(?<name>\w*)\s*(?<oi>OBJECT\sIDENTIFIER)\s\:\:\=\s\{\s(?<parent>\S*)\s(?<oid>\d)\s\}";
      //@"^(?<name>\w*)\s*(?<oi>OBJECT\sIDENTIFIER)\s\:\:\=\s\{\s(?<parent>\S*)\s(?<oid>\d)\s\}$";

      string sciezkaDebug = Environment.CurrentDirectory; // System.Reflection.Assembly.GetExecutingAssembly().d;
                                                          // Opens a text file, reads all lines of the file into a string, and then closes the file.
      // sciezka znajduje sie w pliku Debug
      string sciezkaPliku = sciezkaDebug + "\\RFC1213-MIB.txt";// @"C:\RFC\RFC1213-MIB.txt";

      try
      {
        if (!File.Exists(sciezkaPliku))
          throw new FileNotFoundException();
      }
      catch (FileNotFoundException)
      {
        Environment.Exit(2);
      }
      catch (Exception ex)
      {
        Environment.Exit(2);
      }

      ///
      string text = File.ReadAllText(sciezkaPliku);
      /// Znajdz wszystkie fragmenty pasujace do wzorca object identifier
      var foundObjects = Regex.Matches(text, wzorzec_ObjectIdentifier, options);

      for (int i = 0; i < foundObjects.Count; i++)
      {
        var m = foundObjects[i] as Match;
        var d = new MIBObject()
        {
          // [1] Name
          name = m.Groups[1].Value.Replace("\n", ""),     
          parent = m.Groups[3].Value.Replace("\n", ""),//,    
          // [4] Oid
          oid = string.Concat("1.3.6.1.2.1.", m.Groups[4].Value.Replace("\n", ""))
        };
        ListaObiektówMIB.Add(d);
      }
      /// Znajdz wszystkie fragmenty pasujace do wzorca objectType
      var objectTypes = Regex.Matches(text, wzorzec_ObjectType, options);

      // pasujace obiekty do wzorca objectType dodaj do listy obiektów MIB 
      for (int i = 0; i < objectTypes.Count; i++)
      {
        // Wybierz z grupy wartosc druga  [1] Name
        string name = objectTypes[i].Groups[1].Value.Replace("\n", "");
        // Wybierz z grupy wartosc trzecia   [2] Syntax
        string syntax = objectTypes[i].Groups[2].Value.Replace("\n", "");
        // Wybierz z grupy wartosc czwarta  [3] Access
        string access = objectTypes[i].Groups[3].Value.Replace("\n", "");
        // Wybierz z grupy wartosc piata [4] Status
        string status = objectTypes[i].Groups[4].Value.Replace("\n", "");     
        // Wybierz z grupy wartosc szóstą [5] Desciption
        string parent = objectTypes[i].Groups[6].Value.Replace("\n", "");
        // Wybierz z grupy wartosc siódmą [6] Parent
                                                                           //string oid = m.Groups[7].Value.Replace("\n", "");       // [7] ID
        string parent_oid = getParentOID(objectTypes[i].Groups[6].Value.Replace("\n", ""));

        string oid = string.Concat(parent_oid, ".", objectTypes[i].Groups[7].Value.Replace("\n", ""));   //sequencesList.Add(new MIBSequence(name, values));

        ListaObiektówMIB.Add(new MIBObject(name, syntax, access, status, parent, oid));
      }

      // pasujace obiekty do wzorca sequence dodaj do listy obiektów MIB  
      foreach (Match m in Regex.Matches(text, wzorzec_Sequence, options))
      {
        string name = m.Groups[1].Value.Replace("\n", "");      // [1] Name
        string values = m.Groups[3].Value.Replace("\n", "");    // [3] Values
        ListaSekwencji.Add(new MIBSequence(name, values));
      }
    }

    // Wykorzystanie mib.parent do określenia odpowiedniego oID przy wyświetlaniu TreeView
    public static void CreateSMITreeView(ref List<TreeNode> list, string parent)
    {
      /// Wybierz tylko te ktorych parent jest rowny parent
      /// i utworz z nich liste
      list = ListaObiektówMIB
       .Where(mib => mib.parent == parent)
       .Select(mib => (new TreeNode(mib.name)))
       .ToList();
    }

    // Utworzenie list dzieci, które mają mib-2 jako parent
    public static void CreateOIList(ref List<string> list)
    {
      /// Wybierz tylko te ktorych parent jest rowny mib-2
      /// i utworz z nich liste
      list = ListaObiektówMIB
        .Where(mib => mib.parent == "mib-2")
        .Select(mib => mib.name)
        .ToList();
    }

    public static string displayText(string name, string value)
    {
      // name ; oid ; syntax ; access ; status ; min ; max
      var mib = ListaObiektówMIB.FirstOrDefault(o => o.name == name);
      if (mib != null)
      {
        switch (value)
        {
          case "name": return mib.name;
          case "oid": return mib.oID;
          case "syntax": return mib.syntax;
          case "access": return mib.access;
          case "status": return mib.status;
          case "min": return mib.min.ToString();
          case "max": return mib.max.ToString();
          default: return "";
        }
      }
      else
        return "";
    }

    /// <summary>
    ///  Szukanie object identyfikatora (oid) rodzica
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    private static string getParentOID(string parent)
    {
      // wybierz pierwszy element z listy ktorego nazwa jest rowna
      // parentowi 
      var element = ListaObiektówMIB
      .FirstOrDefault(mib => mib.name == parent);

      /// Sprawdz element i zwroc jego oid
      return element != null ? element.oid : "";
    }
  }
}
