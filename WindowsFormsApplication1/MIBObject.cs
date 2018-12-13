using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
  public class MIBObject
  {
    /// <summary>
    /// Konstruktor dla dzieci mib-2
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Parent"></param>
    /// <param name="OID"></param>
    public MIBObject(string Name, string Parent, string OID)
    {
      name = Name;
      access = "";
      status = "";
      parent = Parent;
      oID = string.Concat("1.3.6.1.2.1.", OID);
      min = -1;
      max = -1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Syntax"></param>
    /// <param name="Access"></param>
    /// <param name="Status"></param>
    /// <param name="Parent"></param>
    /// <param name="OID"></param>
    public MIBObject(string Name, string Syntax, string Access, string Status, string Parent, string OID, string description)
    {
      name = Name;
      access = Access;
      status = Status;
      parent = Parent;
      this.description = description;

      oID = OID;
      min = -1;
      max = -1;

      RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline;
      // Pattern: xyz SIZE(0..255)
      string pattern_size = @"(?<syntax>\w*)\s*\((?<name>SIZE)\s*\((?<min>\d*)\.\.(?<max>\d*)\)\)";
      Match match_size = Regex.Match(Syntax, pattern_size, options);

      // Pattern: xyz (0..65535)
      string pattern_minmax = @"(?<syntax>\w*)\s*\((?<min>\d*)\.\.(?<max>\d*)\)";
      Match match_minmax = Regex.Match(Syntax, pattern_minmax, options);

      // Pattern: xyz { abc(1), efg(2) ... }
      string pattern_values = @"(?<name>\w*)\s*{(?<rest>(?<={)(.*?)(?=}))}";
      Match match_values = Regex.Match(Syntax, pattern_values, options);

      // If SIZE(min..max) -> set charMin and charMax
      if (match_size.Success == true)
      {
        syntax = match_size.Groups[1].Value.Replace("\n", "");
        min = Int32.Parse(match_size.Groups[3].Value.Replace("\n", ""));
        max = Int32.Parse(match_size.Groups[4].Value.Replace("\n", ""));

      }
      // If (min..max) -> set valMin and valMax
      else if (match_minmax.Success == true)
      {
        syntax = match_minmax.Groups[1].Value.Replace("\n", "");
        min = Int32.Parse(match_minmax.Groups[2].Value.Replace("\n", ""));
        max = Int32.Parse(match_minmax.Groups[3].Value.Replace("\n", ""));
      }
      // If { abc(1), efg(2) } then add values to listValues list
      else if (match_values.Success == true)
      {
        syntax = match_values.Groups[2].Value.Replace("\n", "");
        string pattern_stringint = @"(?<word>\w*)\((?<number>\d*)\)";
        foreach (Match stringint in Regex.Matches(Syntax, pattern_stringint, options))
        {
          string ValueString = stringint.Groups[1].Value.Replace("\n", "");
          String ValueInt = stringint.Groups[2].Value.Replace("\n", "");
          listValues.Add(new Values(ValueString, Int32.Parse(ValueInt)));
        }
      }
      // else
      else
      {
        syntax = Syntax;
      }
    }

    //pusty konstruktor
    public MIBObject()
    {
    }

    /// <summary>
    /// identyfikator MIB Object
    /// </summary>
    public string oid { get; set; }

    /// <summary>
    /// nazwa 
    /// </summary>
    public string name { get; set; }

    /// <summary>
    ///  Określamy, jakiego typu będzie wartość obiektu
    /// </summary>
    public string syntax { get; set; }

    /// <summary>
    /// Określają dostęp do obiektu
    /// </summary>
    public string access { get; set; }

    /// <summary>
    ///  Określa poziom implementacji obiektu
    /// </summary>
    public string status { get; set; }

    /// <summary>
    /// // Rodzic
    /// </summary>
    public string parent { get; set; }
    
    /// <summary>
    /// opis
    /// </summary>
    public string description { get; set; }

    /// <summary>
    /// Określa numer obiektu w poddrzewie
    /// </summary>
    public string oID { get; set; }

    /// <summary>
    /// Minimalny zakres wartości 
    /// </summary>
    public int min { get; set; }

    /// <summary>
    /// Maksymalny zakres wartości 
    /// </summary>
    public int max { get; set; }
     
    /// <summary>
    /// Lista zawierająca elementy wartosci
    /// </summary>
    public List<Values> listValues = new List<Values>();

    public struct Values
    {
      public Values(string Name, int Value)
      {
        name = Name;
        value = Value;
      }

      public int value { get; private set; }

      public string name { get; private set; }
    }
  }
}
