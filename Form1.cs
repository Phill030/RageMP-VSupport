using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RageMP_VSupport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private protected string inputcontentXml { get; set; }
        private protected string inputSetup2Xml { get; set; }
        private protected string dir { get; set; }
        private protected string newModName { get; set; }
        private protected string gtaUtilPath { get; set; }
        private protected string texturesDir { get; set; }
        //metas
        private protected string metadataPath { get; set; }
        private protected string carcolsPath { get; set; }
        private protected string carvariationsPath { get; set; }
        private protected string handlingPath { get; set; }
        private protected string dlctextPath { get; set; }
        //Enabled
        private protected bool isUsingMeta { get; set; }
        private protected bool isUsingCarcols { get; set; }
        private protected bool isUsingCarvariations { get; set; }
        private protected bool isUsingHandling { get; set; }
        private protected bool isUsingdlctext { get; set; }

        private protected void copyFiles(string sourcePath, string targetPath)
        {
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            inputcontentXml = Properties.Resources.content;
            inputSetup2Xml = Properties.Resources.setup2;
            MessageBox.Show("This little sweet thing is still WORK IN PROGRESS! If you see any bugs then report them to my GitHub or on rage.mp -- Phill \nPS: dont ask me why i firstly made it in .NET 4.7.2 and then moved to v3.0", "IMPORTANT MESSAGE");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                dir = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog2.SelectedPath;
                texturesDir = folderBrowserDialog2.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GTAUtil.exe|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
                gtaUtilPath = openFileDialog1.FileName;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 50) foreach (string word in new List<string> { "ä", "ö", "ü", "ß", "@", "<", ".", ",", "-", " " }) newModName = textBox3.Text.Replace(word, "");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//metadata
            if (checkBox1.Checked)
            {
                button5.Visible = true;
            }
            else
            {
                button5.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {//carcols
            if (checkBox2.Checked)
            {
                button6.Visible = true;
            }
            else
            {
                button6.Visible = false;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {//variation
            if (checkBox3.Checked)
            {
                button7.Visible = true;
            }
            else
            {
                button7.Visible = false;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {//handling
            if (checkBox4.Checked)
            {
                button8.Visible = true;
            }
            else
            {
                button8.Visible = false;
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {//dlctext
            if (checkBox5.Checked)
            {
                button9.Visible = true;
            }
            else
            {
                button9.Visible = false;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {//metadata button
            openFileDialog2.Filter = "vehicles.meta|";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog2.FileName.Contains("vehicles.meta"))
                {
                    metadataPath = openFileDialog2.FileName;
                    button5.Enabled = false;
                    checkBox1.Enabled = false;
                    isUsingMeta = true;
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog3.Filter = "carcols.meta|";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog3.FileName.Contains("carcols.meta"))
                {
                    carcolsPath = openFileDialog3.FileName;
                    button6.Enabled = false;
                    checkBox2.Enabled = false;
                    isUsingCarcols = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog4.Filter = "carvariations.meta|";
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog4.FileName.Contains("carvariations.meta"))
                {
                    carvariationsPath = openFileDialog4.FileName;
                    button7.Enabled = false;
                    checkBox3.Enabled = false;
                    isUsingCarvariations = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openFileDialog5.Filter = "handling.meta|";
            if (openFileDialog5.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog5.FileName.Contains("handling.meta"))
                {
                    handlingPath = openFileDialog5.FileName;
                    button8.Enabled = false;
                    checkBox4.Enabled = false;
                    isUsingHandling = true;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog6.Filter = "dlctext.meta|";
            if (openFileDialog6.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog6.FileName.Contains("dlctext.meta"))
                {
                    dlctextPath = openFileDialog6.FileName;
                    button9.Enabled = false;
                    checkBox5.Enabled = false;
                    isUsingdlctext = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 50)
            {
                try
                {
                    if (dir != null)
                    {
                        DirectoryInfo d = Directory.CreateDirectory(dir + "/" + newModName.ToLower());
                        DirectoryInfo data1 = Directory.CreateDirectory(dir + "/" + d.Name + "/data");
                        DirectoryInfo x64 = Directory.CreateDirectory(dir + "/" + d.Name + "/x64");
                        DirectoryInfo data2 = Directory.CreateDirectory(dir + "/" + d.Name + "/" + x64.Name + "/data");
                        DirectoryInfo lang = Directory.CreateDirectory(dir + "/" + d.Name + "/" + x64.Name + "/" + data2.Name + "/lang");
                        DirectoryInfo vehicles = Directory.CreateDirectory(dir + "/" + d.Name + "/" + x64.Name + "/vehicles.rpf");

                        if (texturesDir.Length > 0)
                        {
                            copyFiles(texturesDir, vehicles.FullName);
                        }

                        if (isUsingMeta)
                        {
                            inputcontentXml = inputcontentXml.Replace("<!--vehicles<Item>", "<Item>");
                            inputcontentXml = inputcontentXml.Replace("</Item>vehicles-->", "</Item>");
                            inputcontentXml = inputcontentXml.Replace("<!--<Item>dlc_template:/data/vehicles.meta</Item>-->", "<Item>dlc_template:/data/vehicles.meta</Item>");
                            File.Copy(metadataPath, data1.FullName + "\\vehicles.meta");
                        }


                        if (isUsingCarcols)
                        {
                            inputcontentXml = inputcontentXml.Replace("<!--carcols<Item>", "<Item>");
                            inputcontentXml = inputcontentXml.Replace("</Item>carcols-->", "</Item>");
                            inputcontentXml = inputcontentXml.Replace("<!--<Item>dlc_template:/data/carcols.meta</Item>-->", "<Item>dlc_template:/data/carcols.meta</Item>");
                            File.Copy(carcolsPath, data1.FullName + "\\carcols.meta");
                        }


                        if (isUsingCarvariations)
                        {
                            inputcontentXml = inputcontentXml.Replace("<!--carvariations<Item>", "<Item>");
                            inputcontentXml = inputcontentXml.Replace("</Item>carvariations-->", "</Item>");
                            inputcontentXml = inputcontentXml.Replace("<!--<Item>dlc_template:/data/carvariations.meta</Item>-->", "<Item>dlc_template:/data/carvariations.meta</Item>");
                            File.Copy(carvariationsPath, data1.FullName + "\\carvariations.meta");
                        }


                        if (isUsingHandling)
                        {
                            inputcontentXml = inputcontentXml.Replace("<!--handling<Item>", "<Item>");
                            inputcontentXml = inputcontentXml.Replace("</Item>handling-->", "</Item>");
                            inputcontentXml = inputcontentXml.Replace("<!--<Item>dlc_template:/data/handling.meta</Item>-->", "<Item>dlc_template:/data/handling.meta</Item>");
                            File.Copy(handlingPath, data1.FullName + "\\handling.meta");
                        }


                        if (isUsingdlctext)
                        {
                            inputcontentXml = inputcontentXml.Replace("<!--dlctext<Item>", "<Item>");
                            inputcontentXml = inputcontentXml.Replace("</Item>dlctext-->", "</Item>");
                            inputcontentXml = inputcontentXml.Replace("<!--<Item>dlc_template:/data/dlctext.meta</Item>-->", "<Item>dlc_template:/data/dlctext.meta</Item>");
                            File.Copy(dlctextPath, data1.FullName + "\\dlctext.meta");
                        }

                        inputcontentXml = inputcontentXml.Replace("dlc_template", "dlc_" + newModName.ToLower());
                        inputcontentXml = inputcontentXml.Replace("TEMPLATE_AUTOGEN", newModName.ToUpper() + "_AUTOGEN");
                        File.WriteAllText(dir + "/" + d.Name + "/content.xml", inputcontentXml, System.Text.Encoding.UTF8);

                        inputSetup2Xml = inputSetup2Xml.Replace("dlc_template", "dlc_" + newModName.ToLower());
                        inputSetup2Xml = inputSetup2Xml.Replace("template", newModName.ToLower());
                        inputSetup2Xml = inputSetup2Xml.Replace("TEMPLATE_AUTOGEN", newModName.ToUpper() + "_AUTOGEN");
                        File.WriteAllText(dir + "/" + d.Name + "/setup2.xml", inputSetup2Xml, System.Text.Encoding.UTF8);




                        // GTAUTIL Fuck
                        System.Diagnostics.Process.Start(gtaUtilPath, "createarchive --input " + d.FullName.Replace(" / ", "\\") + " --output " + dir.Replace(" / ", "\\") + " --name dlc");


                        MessageBox.Show(null, "Well done! you can find your files now in the desired folder.", "Such a beast!", MessageBoxButtons.OK);
                    }
                }
                catch (NullReferenceException exe)
                {
                    MessageBox.Show(null, "There was an error. Reason: \n" + exe.Message, "ERROR");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
