using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class GroupInfo : Form
    {
        bool initialized = false;
        bool modified = false;

        public GroupInfo(DTO.ItemGroup item = null)
        {
            InitializeComponent();
            LoadData(item);
        }

        private void LoadData(DTO.ItemGroup item = null)
        {
            if (item != null)
            {
                tbID.Text = item.ID.ToString();
                tbName.Text = item.Name == null ? null : item.Name.ToString();
                tbDescription.Text = item.Description == null ? null : item.Description.ToString();
                dtpCreatedDate.Value = item.CreatedDate;

                label1.Text = "Edit Group";
            }
            else
            {
                label1.Text = "Create new Group";
            }

            initialized = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CloseForm())
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                DTO.ItemGroup item = new DTO.ItemGroup();

                item.Name = tbName.Text;
                item.Description = tbDescription.Text;
                item.CreatedDate = dtpCreatedDate.Value;

                if (tbID.Text.Length > 0)
                {
                    item.ID = Convert.ToInt64(tbID.Text);
                    BUS.GroupManager.EditGroup(item);
                }
                else
                {
                    BUS.GroupManager.AddGroup(item);
                }

                this.DialogResult = DialogResult.OK;
            }
            else this.DialogResult = DialogResult.OK;
        }

        private bool CloseForm()
        {
            bool return1 = false;
            if (modified)
            {
                DialogResult dg = MessageBox.Show("You has changed but not saved this data.\nAll data modifited from this form will be lost.\n\nAre you sure you want to cancel?",
                    this.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dg == DialogResult.Yes)
                    return1 = true;
            }
            else return1 = true;
            return return1;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (initialized) modified = true;
        }
    }
}
