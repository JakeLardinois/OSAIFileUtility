using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace OSAIFileUtility
{
    /*Code taken from http://msdn.microsoft.com/en-us/library/ms993124.aspx */

    public class ItemFoundEventArgs : EventArgs
    {
        private int _index;
        public ItemFoundEventArgs(int index) { _index = index; }
        public int Index { get { return _index; } }
    }

    public delegate void ItemFoundEventHandler(object sender, ItemFoundEventArgs e);

    public class FindStrip: System.Windows.Forms.ToolStrip
    {
        private BindingSource _bindingSource;
        public event ItemFoundEventHandler ItemFound;
        public ToolStripLabel toolStripLabel1;
        public ToolStripTextBox tstbxSearchFor;
        public ToolStripLabel toolStripLabel2;
        public ToolStripComboBox tscbSearchIn;
        public ToolStripButton tsbFindNow;
        

        public BindingSource BindingSource
        {
            get { return _bindingSource; }
            set { _bindingSource = value; }
        }

        public FindStrip()
        {
            toolStripLabel1 = new ToolStripLabel();
            tstbxSearchFor = new ToolStripTextBox();
            toolStripLabel2 = new ToolStripLabel();
            tscbSearchIn = new ToolStripComboBox();
            tsbFindNow = new ToolStripButton();

            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tstbxSearchFor,
            this.toolStripLabel2,
            this.tscbSearchIn,
            this.tsbFindNow});
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Search for:";
            // 
            // tstbxSearchFor
            // 
            this.tstbxSearchFor.Name = "tstbxSearchFor";
            //this.tstbxSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tstbxSearchFor.Size = new System.Drawing.Size(225, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel2.Text = "Search in:";
            // 
            // tscbSearchIn
            // 
            this.tscbSearchIn.Name = "tscbSearchIn";
            this.tscbSearchIn.DropDownStyle = ComboBoxStyle.DropDownList;
            //this.tscbSearchIn.GotFocus += new System.EventHandler(this.tscbSearchIn_GotFocus);
            this.tscbSearchIn.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbFindNow
            // 
            this.tsbFindNow.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.tsbFindNow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindNow.Name = "tsbFindNow";
            this.tsbFindNow.Size = new System.Drawing.Size(62, 22);
            this.tsbFindNow.Text = "Find Now";
            //this.tsbFindNow.Alignment = ToolStripItemAlignment.Right;
            this.tsbFindNow.Click +=new EventHandler(tsbFindNow_Click);
        }

        protected virtual void OnItemFound(ItemFoundEventArgs e)
        {
            // Report find results
            if (ItemFound != null) ItemFound(this, e);
        }

        // Start find if Find Now button clicked
        private void tsbFindNow_Click(object sender, EventArgs e)
        {
            this.Find();
        }

        private void Find() {
            // Don't search if nothing specified to look for
            string find = this.tstbxSearchFor.Text;
            if( string.IsNullOrEmpty(find) ) return;

            // Don't search of a column isn't specified to search in
            string findIn = this.tscbSearchIn.Text;
            if( string.IsNullOrEmpty(findIn) ) return;
    
            // Get the PropertyDescriptor
            PropertyDescriptorCollection properties = ((ITypedList)_bindingSource).GetItemProperties(null);
            PropertyDescriptor property = properties[findIn];
            // Find a value in a column
            int index = _bindingSource.Find(property, find);

            this.OnItemFound(new ItemFoundEventArgs(index));
        }

        private void tscbSearchIn_GotFocus(object sender, EventArgs e)
        {

            // Bail if no data source
            if (_bindingSource == null) return;
            if (_bindingSource.DataSource == null) return;

            this.tscbSearchIn.Items.Clear();

            // Add column names to Search In list
            PropertyDescriptorCollection properties =
              ((ITypedList)_bindingSource).GetItemProperties(null);
            foreach (PropertyDescriptor property in properties)
            {
                this.tscbSearchIn.Items.Insert(0, property.Name);
            }

            // Select first column name in list, if column names were added
            if (this.tscbSearchIn.Items.Count > 0)
            {
                this.tscbSearchIn.SelectedIndex = 0;
            }
        }

        public void LoadSearchProperties()
        {

            // Bail if no data source
            if (_bindingSource == null) return;
            if (_bindingSource.DataSource == null) return;

            this.tscbSearchIn.Items.Clear();

            // Add column names to Search In list
            PropertyDescriptorCollection properties =
              ((ITypedList)_bindingSource).GetItemProperties(null);
            foreach (PropertyDescriptor property in properties)
            {
                this.tscbSearchIn.Items.Insert(0, property.Name);
            }

            // Select first column name in list, if column names were added
            if (this.tscbSearchIn.Items.Count > 0)
            {
                this.tscbSearchIn.SelectedIndex = properties.Count - 1;
            }
        }

    }
}
