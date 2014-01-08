using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeViewWithDrives();
        }
        
        private void PopulateTreeViewWithDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    DirectoryInfo info = new DirectoryInfo(drive.Name);
                    TreeNode driveNode= new TreeNode();
                    driveNode.Text = drive.Name;
                    //Adds FAKE child to driveNode
                    driveNode.Nodes.Add("");
                    treeView1.Nodes.Add(driveNode);
                }
            }
        }        

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                TreeNode parentNode = e.Node;
                DirectoryInfo di = new DirectoryInfo(parentNode.FullPath);
                parentNode.Nodes.Clear();
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    //Adds FAKE child to node
                    node.Nodes.Add("");
                    parentNode.Nodes.Add(node);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode selected = e.Node;
                string path = selected.FullPath;
                string[] Files = Directory.GetFiles(path);
                string[] Directories = Directory.GetDirectories(path);
                string[] subInfo = new string[3];

                listView1.Clear();

                listView1.Columns.Add("Name", 255);
                listView1.Columns.Add("Size", 100);
                listView1.Columns.Add("Type", 80);

                foreach (string dName in Directories)
                {
                    subInfo[0] = GetFileName(dName);
                    subInfo[1] = "";
                    subInfo[2] = "FOLDER";
                    ListViewItem dItems = new ListViewItem(subInfo);
                    listView1.Items.Add(dItems);

                }

                foreach (string fName in Files)
                {
                    subInfo[0] = GetFileName(fName);
                    subInfo[1] = GetSizeInfo(fName);
                    subInfo[2] = GetTypeInfo(fName);
                    ListViewItem fItem = new ListViewItem(subInfo);
                    listView1.Items.Add(fItem);
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        public string GetFileName(string path)
        {
            int Nameindex = path.LastIndexOf('\\');
            return path.Substring(Nameindex + 1);
        }

        public string GetTypeInfo(string path)
        {
            int Typeindex = path.LastIndexOf('.');
            string fType;
            if (Typeindex != -1)
            {
                fType = path.Substring(Typeindex + 1);
                fType = fType.ToUpper();               
            }
            else
            {
                fType = "FILE";
            }
            return fType;
        }

        public string GetSizeInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            long size = fi.Length;
            string txtsize = "";
            if (size < 1024)
            {
                txtsize = "byte";
            }
            else if (size > 1024)
            {
                size = size / 1024;
                txtsize = "kB";
            }
            if (size > 1024)
            {
                size = size / 1024;
                txtsize = "MB";
            }
            if (size > 1024)
            {
                size = size / 1024;
                txtsize = "GB";
            }
            return size + " " + txtsize;
        }

        //TEST
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show(e.Node.FullPath);
        }
    }    
}

