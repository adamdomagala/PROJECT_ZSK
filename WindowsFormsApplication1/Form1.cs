using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    /// <summary>
    ///  Wykorzystanie mib.parent oraz mib.oID do określenia odpowiedniego oID
    /// </summary>
    /// <param name="MIBObjects"></param>
    /// <param name="name"></param>
    public void CreateSMITree(List<MIBObject> MIBObjects, string name)
    {
      foreach (var mib in MIBObjects)
      { 
        mib.oID = "123";
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    { 
      // Lista OBJECT IDENTIFIER:
      List<string> ObjecIdentifiertList = new List<string>();
      Parser.CreateOIList(ref ObjecIdentifiertList);

      foreach (var _object in ObjecIdentifiertList)
      {
        List<TreeNode> list = new List<TreeNode>();                     // Utwórz listę
        Parser.CreateSMITreeView(ref list, _object);                    // Szukaj elementy, które mają "_object" ustawiony jako parent
        TreeNode[] array = list.ToArray();                              // Zmień listę w tablicę
        TreeNode TreeNodeSystem = new TreeNode(_object, array);
        treeView1.Nodes.Add(TreeNodeSystem);
      }

    }
    
    /// <summary>
    /// Przypisz polom tekstowym wartosci z wybranego wezla utworzonego
    /// drzewa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
    {
      try
      {
        txtName.Text = "";
        txtOID.Text = "";
        txtSyntax.Text = "";
        txtAccess.Text = "";
        txtStatus.Text = "";
        txtMin.Text = "";
        txtMax.Text = "";

        // przypisz z  z wtbranego wezla drzewa kolejno
        // =>name ; 
        txtName.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "name");
        // =>oid ;
        txtOID.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "oid");
        // =>syntax ; 
        txtSyntax.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "syntax");
        // =>access ; 
        txtAccess.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "access");
        // =>status ; 
        txtStatus.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "status");
        // =>min ; 
        txtMin.Text = (Int32.Parse(Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text, "min")) == -1) ? "" : Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "min");
        // =>max
        txtMax.Text = (Int32.Parse(Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text, "max")) == -1) ? "" : Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "max");
        // => description
        Description.Text = Parser.wpiszWartoscWlasciwosciWPole(treeView1.SelectedNode.Text.ToString(), "description");
      }
      catch { }

    }

    private void button1_Click(object sender, EventArgs e)
    {
      treeView1.ExpandAll();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      treeView1.CollapseAll();
    }
  }
}
