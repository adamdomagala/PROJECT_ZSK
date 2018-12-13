namespace WindowsFormsApplication1
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtMax = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtMin = new System.Windows.Forms.TextBox();
      this.txtStatus = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtAccess = new System.Windows.Forms.TextBox();
      this.txtSyntax = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.txtOID = new System.Windows.Forms.TextBox();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.Location = new System.Drawing.Point(6, 19);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(191, 295);
      this.treeView1.TabIndex = 0;
      this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.treeView1);
      this.groupBox1.Location = new System.Drawing.Point(6, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(238, 362);
      this.groupBox1.TabIndex = 1;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Struktura drzewa";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtMax);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.txtMin);
      this.groupBox2.Controls.Add(this.txtStatus);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.txtAccess);
      this.groupBox2.Controls.Add(this.txtSyntax);
      this.groupBox2.Controls.Add(this.label6);
      this.groupBox2.Controls.Add(this.label7);
      this.groupBox2.Controls.Add(this.txtOID);
      this.groupBox2.Controls.Add(this.txtName);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Location = new System.Drawing.Point(262, 14);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(323, 362);
      this.groupBox2.TabIndex = 2;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Wybrany element drzewa";
      // 
      // txtMax
      // 
      this.txtMax.Location = new System.Drawing.Point(62, 189);
      this.txtMax.Name = "txtMax";
      this.txtMax.ReadOnly = true;
      this.txtMax.Size = new System.Drawing.Size(236, 20);
      this.txtMax.TabIndex = 29;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 192);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(30, 13);
      this.label5.TabIndex = 28;
      this.label5.Text = "Max:";
      // 
      // txtMin
      // 
      this.txtMin.Location = new System.Drawing.Point(62, 163);
      this.txtMin.Name = "txtMin";
      this.txtMin.ReadOnly = true;
      this.txtMin.Size = new System.Drawing.Size(236, 20);
      this.txtMin.TabIndex = 27;
      // 
      // txtStatus
      // 
      this.txtStatus.Location = new System.Drawing.Point(62, 136);
      this.txtStatus.Name = "txtStatus";
      this.txtStatus.ReadOnly = true;
      this.txtStatus.Size = new System.Drawing.Size(236, 20);
      this.txtStatus.TabIndex = 26;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 163);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(27, 13);
      this.label3.TabIndex = 25;
      this.label3.Text = "Min:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(16, 139);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(40, 13);
      this.label4.TabIndex = 24;
      this.label4.Text = "Status:";
      // 
      // txtAccess
      // 
      this.txtAccess.Location = new System.Drawing.Point(62, 110);
      this.txtAccess.Name = "txtAccess";
      this.txtAccess.ReadOnly = true;
      this.txtAccess.Size = new System.Drawing.Size(236, 20);
      this.txtAccess.TabIndex = 23;
      // 
      // txtSyntax
      // 
      this.txtSyntax.Location = new System.Drawing.Point(62, 83);
      this.txtSyntax.Name = "txtSyntax";
      this.txtSyntax.ReadOnly = true;
      this.txtSyntax.Size = new System.Drawing.Size(236, 20);
      this.txtSyntax.TabIndex = 22;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(16, 113);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(45, 13);
      this.label6.TabIndex = 21;
      this.label6.Text = "Access:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(16, 86);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(42, 13);
      this.label7.TabIndex = 20;
      this.label7.Text = "Syntax:";
      // 
      // txtOID
      // 
      this.txtOID.Location = new System.Drawing.Point(62, 57);
      this.txtOID.Name = "txtOID";
      this.txtOID.ReadOnly = true;
      this.txtOID.Size = new System.Drawing.Size(236, 20);
      this.txtOID.TabIndex = 19;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(62, 30);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new System.Drawing.Size(236, 20);
      this.txtName.TabIndex = 18;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 60);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "OID:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(16, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(38, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "Name:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(6, 333);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Rozwiń węzły";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(108, 333);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "Zwiń";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(626, 397);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "Parser pliku MIB";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox txtMax;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtMin;
    private System.Windows.Forms.TextBox txtStatus;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtAccess;
    private System.Windows.Forms.TextBox txtSyntax;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtOID;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
  }
}

