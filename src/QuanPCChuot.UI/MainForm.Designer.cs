
namespace QuanPCChuot.UI
{
    partial class MainForm
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
            this.pTab = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pContent = new System.Windows.Forms.Panel();
            this.billPanel = new System.Windows.Forms.Panel();
            this.btnNewBill = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbIDList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pLogin = new System.Windows.Forms.Panel();
            this.billMainForm1 = new QuanPCChuot.UI.Controls.BillMainForm();
            this.logManager = new QuanPCChuot.UI.Controls.LogManager();
            this.inventoryManager = new QuanPCChuot.UI.Controls.InventoryManager();
            this.groupManager = new QuanPCChuot.UI.Controls.GroupManager();
            this.billManager = new QuanPCChuot.UI.Controls.BillManager();
            this.accountManager = new QuanPCChuot.UI.Controls.AccountManager();
            this.login1 = new QuanPCChuot.UI.Controls.Login();
            this.pTab.SuspendLayout();
            this.pContent.SuspendLayout();
            this.billPanel.SuspendLayout();
            this.pLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTab
            // 
            this.pTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pTab.Controls.Add(this.button8);
            this.pTab.Controls.Add(this.button7);
            this.pTab.Controls.Add(this.button6);
            this.pTab.Controls.Add(this.button5);
            this.pTab.Controls.Add(this.button4);
            this.pTab.Controls.Add(this.button2);
            this.pTab.Controls.Add(this.button1);
            this.pTab.Location = new System.Drawing.Point(0, 0);
            this.pTab.Name = "pTab";
            this.pTab.Size = new System.Drawing.Size(274, 681);
            this.pTab.TabIndex = 0;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackColor = System.Drawing.Color.Gainsboro;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(0, 631);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(274, 50);
            this.button8.TabIndex = 0;
            this.button8.Text = "Logout";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.Gainsboro;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(0, 250);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(274, 50);
            this.button7.TabIndex = 0;
            this.button7.Text = "Log Viewer";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.Gainsboro;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(0, 200);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(274, 50);
            this.button6.TabIndex = 0;
            this.button6.Text = "Account Manager";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.Gainsboro;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(274, 50);
            this.button5.TabIndex = 0;
            this.button5.Text = "Group Manager";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(0, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(274, 50);
            this.button4.TabIndex = 0;
            this.button4.Text = "Inventory Manager";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(274, 50);
            this.button2.TabIndex = 0;
            this.button2.Text = "Bill Manager";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pending Bill Queue";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pContent
            // 
            this.pContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pContent.Controls.Add(this.billPanel);
            this.pContent.Controls.Add(this.logManager);
            this.pContent.Controls.Add(this.inventoryManager);
            this.pContent.Controls.Add(this.groupManager);
            this.pContent.Controls.Add(this.billManager);
            this.pContent.Controls.Add(this.accountManager);
            this.pContent.Location = new System.Drawing.Point(274, 0);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(910, 681);
            this.pContent.TabIndex = 0;
            // 
            // billPanel
            // 
            this.billPanel.Controls.Add(this.billMainForm1);
            this.billPanel.Controls.Add(this.btnNewBill);
            this.billPanel.Controls.Add(this.btnRefresh);
            this.billPanel.Controls.Add(this.cbIDList);
            this.billPanel.Controls.Add(this.label1);
            this.billPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billPanel.Location = new System.Drawing.Point(0, 0);
            this.billPanel.Name = "billPanel";
            this.billPanel.Size = new System.Drawing.Size(910, 681);
            this.billPanel.TabIndex = 5;
            // 
            // btnNewBill
            // 
            this.btnNewBill.Location = new System.Drawing.Point(490, 11);
            this.btnNewBill.Name = "btnNewBill";
            this.btnNewBill.Size = new System.Drawing.Size(108, 29);
            this.btnNewBill.TabIndex = 2;
            this.btnNewBill.Text = "Create new bill";
            this.btnNewBill.UseVisualStyleBackColor = true;
            this.btnNewBill.Click += new System.EventHandler(this.btnNewBill_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(395, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 29);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbIDList
            // 
            this.cbIDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbIDList.FormattingEnabled = true;
            this.cbIDList.Location = new System.Drawing.Point(73, 10);
            this.cbIDList.Name = "cbIDList";
            this.cbIDList.Size = new System.Drawing.Size(316, 29);
            this.cbIDList.TabIndex = 1;
            this.cbIDList.SelectedIndexChanged += new System.EventHandler(this.cbIDList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill ID";
            // 
            // pLogin
            // 
            this.pLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pLogin.Controls.Add(this.login1);
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(1184, 681);
            this.pLogin.TabIndex = 1;
            // 
            // billMainForm1
            // 
            this.billMainForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.billMainForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.billMainForm1.Location = new System.Drawing.Point(0, 45);
            this.billMainForm1.Name = "billMainForm1";
            this.billMainForm1.Size = new System.Drawing.Size(910, 636);
            this.billMainForm1.TabIndex = 3;
            // 
            // logManager
            // 
            this.logManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logManager.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logManager.Location = new System.Drawing.Point(0, 0);
            this.logManager.Name = "logManager";
            this.logManager.Size = new System.Drawing.Size(910, 681);
            this.logManager.TabIndex = 4;
            // 
            // inventoryManager
            // 
            this.inventoryManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryManager.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.inventoryManager.Location = new System.Drawing.Point(0, 0);
            this.inventoryManager.Name = "inventoryManager";
            this.inventoryManager.Size = new System.Drawing.Size(910, 681);
            this.inventoryManager.TabIndex = 3;
            // 
            // groupManager
            // 
            this.groupManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupManager.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupManager.Location = new System.Drawing.Point(0, 0);
            this.groupManager.Name = "groupManager";
            this.groupManager.Size = new System.Drawing.Size(910, 681);
            this.groupManager.TabIndex = 2;
            // 
            // billManager
            // 
            this.billManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billManager.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.billManager.Location = new System.Drawing.Point(0, 0);
            this.billManager.Name = "billManager";
            this.billManager.Size = new System.Drawing.Size(910, 681);
            this.billManager.TabIndex = 1;
            // 
            // accountManager
            // 
            this.accountManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountManager.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.accountManager.Location = new System.Drawing.Point(0, 0);
            this.accountManager.Name = "accountManager";
            this.accountManager.Size = new System.Drawing.Size(910, 681);
            this.accountManager.TabIndex = 0;
            // 
            // login1
            // 
            this.login1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.login1.Location = new System.Drawing.Point(396, 233);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(393, 214);
            this.login1.TabIndex = 0;
            this.login1.LoginReturn += new System.EventHandler<QuanPCChuot.UI.Controls.LoginEventArgs>(this.login1_LoginReturn);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.pContent);
            this.Controls.Add(this.pTab);
            this.Controls.Add(this.pLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quán PC Chuột";
            this.pTab.ResumeLayout(false);
            this.pContent.ResumeLayout(false);
            this.billPanel.ResumeLayout(false);
            this.billPanel.PerformLayout();
            this.pLogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTab;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pContent;
        private Controls.LogManager logManager;
        private Controls.InventoryManager inventoryManager;
        private Controls.GroupManager groupManager;
        private Controls.BillManager billManager;
        private Controls.AccountManager accountManager;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel pLogin;
        private Controls.Login login1;
        private System.Windows.Forms.Panel billPanel;
        private System.Windows.Forms.Button btnNewBill;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbIDList;
        private System.Windows.Forms.Label label1;
        private Controls.BillMainForm billMainForm1;
    }
}

