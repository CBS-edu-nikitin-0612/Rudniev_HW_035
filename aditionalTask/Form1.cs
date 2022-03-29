using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aditionalTask
{
    public partial class Form1 : Form
    {
        Assembly assembly = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
            
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox.Text += "File  " + path + "  -  loaded" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                textBox.Text += "Info of assembly:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox.Text += "Type:  " + type.FullName + Environment.NewLine;
                    
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "Method: " + method.Name + ", return type = " + method.ReturnType + "\n";
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }

                    var fields = type.GetFields();
                    if (fields != null)
                    {
                        foreach (var field in fields)
                        {
                            string methStr = "Field: " + field.Name + ", type = " + field.FieldType + "\n";
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
