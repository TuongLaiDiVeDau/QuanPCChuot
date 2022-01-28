
namespace QuanPCChuot.UI.Controls
{
    partial class BillMainForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbCusName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCusAddress = new System.Windows.Forms.TextBox();
            this.dgvPurchaseList = new System.Windows.Forms.DataGridView();
            this.cbInventoryItem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCount = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbDiscountType = new System.Windows.Forms.ComboBox();
            this.tbDiscountValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCusTel = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPurchased = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFinalPrice = new System.Windows.Forms.TextBox();
            this.tbTotalAmount = new System.Windows.Forms.TextBox();
            this.btnPurchaseCancel = new System.Windows.Forms.Button();
            this.btnSaveInformation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer name";
            // 
            // tbCusName
            // 
            this.tbCusName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCusName.Location = new System.Drawing.Point(429, 22);
            this.tbCusName.Name = "tbCusName";
            this.tbCusName.Size = new System.Drawing.Size(436, 23);
            this.tbCusName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer address";
            // 
            // tbCusAddress
            // 
            this.tbCusAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCusAddress.Location = new System.Drawing.Point(429, 51);
            this.tbCusAddress.Name = "tbCusAddress";
            this.tbCusAddress.Size = new System.Drawing.Size(654, 23);
            this.tbCusAddress.TabIndex = 1;
            // 
            // dgvPurchaseList
            // 
            this.dgvPurchaseList.AllowUserToAddRows = false;
            this.dgvPurchaseList.AllowUserToDeleteRows = false;
            this.dgvPurchaseList.AllowUserToResizeRows = false;
            this.dgvPurchaseList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPurchaseList.Location = new System.Drawing.Point(18, 203);
            this.dgvPurchaseList.Name = "dgvPurchaseList";
            this.dgvPurchaseList.RowHeadersVisible = false;
            this.dgvPurchaseList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseList.Size = new System.Drawing.Size(1115, 362);
            this.dgvPurchaseList.TabIndex = 2;
            this.dgvPurchaseList.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // cbInventoryItem
            // 
            this.cbInventoryItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInventoryItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbInventoryItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbInventoryItem.FormattingEnabled = true;
            this.cbInventoryItem.Location = new System.Drawing.Point(159, 21);
            this.cbInventoryItem.Name = "cbInventoryItem";
            this.cbInventoryItem.Size = new System.Drawing.Size(608, 23);
            this.cbInventoryItem.TabIndex = 3;
            this.cbInventoryItem.SelectedIndexChanged += new System.EventHandler(this.cbInventoryItem_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Select item to add";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Type number of items";
            // 
            // tbCount
            // 
            this.tbCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCount.Location = new System.Drawing.Point(159, 50);
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(396, 23);
            this.tbCount.TabIndex = 6;
            this.tbCount.Text = "0";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(773, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 52);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbDiscountType
            // 
            this.cbDiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDiscountType.FormattingEnabled = true;
            this.cbDiscountType.Items.AddRange(new object[] {
            "No discount",
            "By money",
            "By percent"});
            this.cbDiscountType.Location = new System.Drawing.Point(116, 61);
            this.cbDiscountType.Name = "cbDiscountType";
            this.cbDiscountType.Size = new System.Drawing.Size(216, 23);
            this.cbDiscountType.TabIndex = 3;
            this.cbDiscountType.SelectedIndexChanged += new System.EventHandler(this.cbDiscountType_SelectedIndexChanged);
            // 
            // tbDiscountValue
            // 
            this.tbDiscountValue.Location = new System.Drawing.Point(526, 61);
            this.tbDiscountValue.Name = "tbDiscountValue";
            this.tbDiscountValue.Size = new System.Drawing.Size(225, 23);
            this.tbDiscountValue.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCusTel);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.tbID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbCusName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbCusAddress);
            this.groupBox1.Location = new System.Drawing.Point(18, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1115, 89);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Information";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(884, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Telephone";
            // 
            // tbCusTel
            // 
            this.tbCusTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCusTel.Location = new System.Drawing.Point(951, 23);
            this.tbCusTel.Name = "tbCusTel";
            this.tbCusTel.Size = new System.Drawing.Size(132, 23);
            this.tbCusTel.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(93, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(207, 23);
            this.textBox2.TabIndex = 1;
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.SystemColors.Window;
            this.tbID.Location = new System.Drawing.Point(93, 23);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(207, 23);
            this.tbID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Bill status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID bill";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbInventoryItem);
            this.groupBox2.Controls.Add(this.btnDelAll);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.tbCount);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1115, 86);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item control";
            // 
            // btnDelAll
            // 
            this.btnDelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelAll.Location = new System.Drawing.Point(978, 21);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(105, 52);
            this.btnDelAll.TabIndex = 7;
            this.btnDelAll.Text = "Delete all items";
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(871, 21);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(101, 52);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Delete selected items";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(654, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(113, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(561, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Not larger than";
            // 
            // btnPurchased
            // 
            this.btnPurchased.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchased.Location = new System.Drawing.Point(1005, 712);
            this.btnPurchased.Name = "btnPurchased";
            this.btnPurchased.Size = new System.Drawing.Size(128, 35);
            this.btnPurchased.TabIndex = 7;
            this.btnPurchased.Text = "Make as Purchased";
            this.btnPurchased.UseVisualStyleBackColor = true;
            this.btnPurchased.Click += new System.EventHandler(this.btnPurchased_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbFinalPrice);
            this.groupBox3.Controls.Add(this.tbTotalAmount);
            this.groupBox3.Controls.Add(this.tbDiscountValue);
            this.groupBox3.Controls.Add(this.cbDiscountType);
            this.groupBox3.Location = new System.Drawing.Point(18, 571);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1115, 135);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discount Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Final Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Value by selected discount type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Discount?";
            // 
            // tbFinalPrice
            // 
            this.tbFinalPrice.Location = new System.Drawing.Point(116, 90);
            this.tbFinalPrice.Name = "tbFinalPrice";
            this.tbFinalPrice.ReadOnly = true;
            this.tbFinalPrice.Size = new System.Drawing.Size(216, 23);
            this.tbFinalPrice.TabIndex = 6;
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.Location = new System.Drawing.Point(116, 32);
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.ReadOnly = true;
            this.tbTotalAmount.Size = new System.Drawing.Size(216, 23);
            this.tbTotalAmount.TabIndex = 6;
            // 
            // btnPurchaseCancel
            // 
            this.btnPurchaseCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchaseCancel.Location = new System.Drawing.Point(857, 712);
            this.btnPurchaseCancel.Name = "btnPurchaseCancel";
            this.btnPurchaseCancel.Size = new System.Drawing.Size(142, 35);
            this.btnPurchaseCancel.TabIndex = 7;
            this.btnPurchaseCancel.Text = "Cancel this Purchase";
            this.btnPurchaseCancel.UseVisualStyleBackColor = true;
            this.btnPurchaseCancel.Click += new System.EventHandler(this.btnPurchaseCancel_Click);
            // 
            // btnSaveInformation
            // 
            this.btnSaveInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveInformation.Location = new System.Drawing.Point(731, 712);
            this.btnSaveInformation.Name = "btnSaveInformation";
            this.btnSaveInformation.Size = new System.Drawing.Size(120, 35);
            this.btnSaveInformation.TabIndex = 7;
            this.btnSaveInformation.Text = "Save Information";
            this.btnSaveInformation.UseVisualStyleBackColor = true;
            this.btnSaveInformation.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // BillMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPurchaseList);
            this.Controls.Add(this.btnSaveInformation);
            this.Controls.Add(this.btnPurchaseCancel);
            this.Controls.Add(this.btnPurchased);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "BillMainForm";
            this.Size = new System.Drawing.Size(1151, 764);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCusName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCusAddress;
        private System.Windows.Forms.DataGridView dgvPurchaseList;
        private System.Windows.Forms.ComboBox cbInventoryItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbDiscountType;
        private System.Windows.Forms.TextBox tbDiscountValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPurchased;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDelAll;
        private System.Windows.Forms.Button btnPurchaseCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTotalAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbFinalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCusTel;
        private System.Windows.Forms.Button btnSaveInformation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
    }
}
