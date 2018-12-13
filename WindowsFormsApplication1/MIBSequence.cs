using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{ 
  /// <summary>
  /// rodzaj struktury
  /// -> może zawierać elementy różnego typu 
  /// </summary>
  public class MIBSequence
  {
    /// <summary>
    /// Konstruktor nr 1 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Values"></param>
    public MIBSequence(string Name, string Values)
    {
      name = Name;            // name ::= SEQUENCE
      string min = "-1";      // Jeżeli brak to będzie -1
      string max = "-1";      // Jeżeli brak to będzie -1
      string _name, _type, pattern_minmax;

      RegexOptions options = RegexOptions.Singleline | RegexOptions.Multiline;
      string pattern_NameType = @"(?<name>\w*)\s*(?<type>\w*)(\,|(?<minmax>\s*\(\S*\)))+";

      foreach (Match m in Regex.Matches(Values, pattern_NameType, options))
      {
         _name = m.Groups[2].Value.Replace("\n", "");   // Ustaw [2] Name
         _type = m.Groups[3].Value.Replace("\n", "");   // Ustaw [3] Type

        // Jeżeli występuje min i max to ustaw wartości
        pattern_minmax = @"\((?<min>\d*)..(?<max>\d*)\)";
        Match minmax = Regex.Match(m.Groups[4].Value.Replace("\n", ""), pattern_minmax, options); // [4] MinMax
        if (minmax.Success == true)
        {
          min = (minmax.Groups[1].Value);  // [1] - min
          max = (minmax.Groups[2].Value);  // [2] - max
          sequenceValues.Add(new SequenceValues(_name, _type, min, max));
        }
        // W przeciwnym wypadku zostaw -1 i -1
        else
        {
          sequenceValues.Add(new SequenceValues(_name, _type, min, max));
        }
      }
    }

    /// <summary>
    /// Konstruktor nr 2 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Values"></param>
    public MIBSequence(string Name, string Values, string access, string status, string parent, string oid) : this(Name, Values)
    {
      // przepisanie parametrow do wlasciwosci obiektu 
      this.access = access;
      this.status = status;
      this.parent = parent;
      this.oid = oid;
    }

    public string name;     // nazwa sekwencji

    /// <summary>
    /// lista zmiennych sekwencji 
    /// </summary>
    public List<SequenceValues> sequenceValues = new List<SequenceValues>(); // elementy w sekwencji

    private string access;

    private string status;

    private string parent;

    private string oid;
  }

  /// <summary>
  /// obiekt reprezentujacy zmienna w obiekcie sekwencji 
  /// </summary>
  public class SequenceValues
  {
    /// <summary>
    /// Konstruktor do przypisania wartosci dla danej zmiennej 
    /// w sekwencji 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Type"></param>
    /// <param name="Min"></param>
    /// <param name="Max"></param>
    public SequenceValues(string Name, string Type, string Min, string Max)
    {
      name = Name;
      type = Type;
      min = Min;
      max = Max;
    }

    /// <summary>
    /// nazwa zmiennej 
    /// </summary>
    public string name;

    // <summary>
    /// typ zmiennej 
    /// </summary>
    public string type;

    /// <summary>
    /// Minimalna wartość okreslona w nawiasie po SIZE(MIN,MAX)
    /// </summary>
    public string min;

    /// <summary>
    /// Maksymalna wartość okreslona w nawiasie po SIZE(MIN,MAX)
    /// </summary>
    public string max;
  }
}