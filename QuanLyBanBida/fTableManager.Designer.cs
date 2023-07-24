
namespace QuanLyBanBida
{
    partial class fTableManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_EndTime = new System.Windows.Forms.TextBox();
            this.txt_StartTime = new System.Windows.Forms.TextBox();
            this.cb_SwitchTable = new System.Windows.Forms.ComboBox();
            this.btn_SwitchTable = new System.Windows.Forms.Button();
            this.nm_Discount = new System.Windows.Forms.NumericUpDown();
            this.btn_Discount = new System.Windows.Forms.Button();
            this.btn_Checkout = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbfood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btn_AddFood = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinTaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(680, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 409);
            this.panel2.TabIndex = 3;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(468, 406);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 104;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 117;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_EndTime);
            this.panel3.Controls.Add(this.txt_StartTime);
            this.panel3.Controls.Add(this.cb_SwitchTable);
            this.panel3.Controls.Add(this.btn_SwitchTable);
            this.panel3.Controls.Add(this.nm_Discount);
            this.panel3.Controls.Add(this.btn_Discount);
            this.panel3.Controls.Add(this.btn_Checkout);
            this.panel3.Location = new System.Drawing.Point(683, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(474, 131);
            this.panel3.TabIndex = 4;
            // 
            // txt_EndTime
            // 
            this.txt_EndTime.Location = new System.Drawing.Point(239, 83);
            this.txt_EndTime.Name = "txt_EndTime";
            this.txt_EndTime.Size = new System.Drawing.Size(110, 22);
            this.txt_EndTime.TabIndex = 8;
            // 
            // txt_StartTime
            // 
            this.txt_StartTime.Location = new System.Drawing.Point(123, 83);
            this.txt_StartTime.Name = "txt_StartTime";
            this.txt_StartTime.Size = new System.Drawing.Size(110, 22);
            this.txt_StartTime.TabIndex = 7;
            // 
            // cb_SwitchTable
            // 
            this.cb_SwitchTable.FormattingEnabled = true;
            this.cb_SwitchTable.Location = new System.Drawing.Point(0, 55);
            this.cb_SwitchTable.Name = "cb_SwitchTable";
            this.cb_SwitchTable.Size = new System.Drawing.Size(113, 24);
            this.cb_SwitchTable.TabIndex = 4;
            // 
            // btn_SwitchTable
            // 
            this.btn_SwitchTable.Location = new System.Drawing.Point(0, 0);
            this.btn_SwitchTable.Name = "btn_SwitchTable";
            this.btn_SwitchTable.Size = new System.Drawing.Size(113, 40);
            this.btn_SwitchTable.TabIndex = 6;
            this.btn_SwitchTable.Text = "Chuyển bàn";
            this.btn_SwitchTable.UseVisualStyleBackColor = true;
            this.btn_SwitchTable.Click += new System.EventHandler(this.btn_SwitchTable_Click);
            // 
            // nm_Discount
            // 
            this.nm_Discount.Location = new System.Drawing.Point(361, 57);
            this.nm_Discount.Name = "nm_Discount";
            this.nm_Discount.Size = new System.Drawing.Size(113, 22);
            this.nm_Discount.TabIndex = 4;
            this.nm_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Discount
            // 
            this.btn_Discount.Location = new System.Drawing.Point(361, 0);
            this.btn_Discount.Name = "btn_Discount";
            this.btn_Discount.Size = new System.Drawing.Size(113, 40);
            this.btn_Discount.TabIndex = 5;
            this.btn_Discount.Text = "Giảm giá";
            this.btn_Discount.UseVisualStyleBackColor = true;
            // 
            // btn_Checkout
            // 
            this.btn_Checkout.Location = new System.Drawing.Point(186, 3);
            this.btn_Checkout.Name = "btn_Checkout";
            this.btn_Checkout.Size = new System.Drawing.Size(113, 56);
            this.btn_Checkout.TabIndex = 4;
            this.btn_Checkout.Text = "Thanh toán";
            this.btn_Checkout.UseVisualStyleBackColor = true;
            this.btn_Checkout.Click += new System.EventHandler(this.btn_Checkout_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbfood);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Controls.Add(this.nmFoodCount);
            this.panel4.Controls.Add(this.btn_AddFood);
            this.panel4.Location = new System.Drawing.Point(682, 483);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(474, 73);
            this.panel4.TabIndex = 5;
            // 
            // cbfood
            // 
            this.cbfood.FormattingEnabled = true;
            this.cbfood.Location = new System.Drawing.Point(1, 46);
            this.cbfood.Name = "cbfood";
            this.cbfood.Size = new System.Drawing.Size(312, 24);
            this.cbfood.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(0, 1);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(312, 24);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(332, 48);
            this.nmFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(137, 22);
            this.nmFoodCount.TabIndex = 3;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_AddFood
            // 
            this.btn_AddFood.Location = new System.Drawing.Point(332, 1);
            this.btn_AddFood.Name = "btn_AddFood";
            this.btn_AddFood.Size = new System.Drawing.Size(137, 44);
            this.btn_AddFood.TabIndex = 2;
            this.btn_AddFood.Text = "Gọi món";
            this.btn_AddFood.UseVisualStyleBackColor = true;
            this.btn_AddFood.Click += new System.EventHandler(this.btn_AddFood_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(12, 41);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(659, 652);
            this.flpTable.TabIndex = 4;
            this.flpTable.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTable_Paint);
            // 
            // txttongtien
            // 
            this.txttongtien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txttongtien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttongtien.ForeColor = System.Drawing.Color.Black;
            this.txttongtien.Location = new System.Drawing.Point(683, 451);
            this.txttongtien.Multiline = true;
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(474, 27);
            this.txttongtien.TabIndex = 2;
            this.txttongtien.Text = "Tổng tiền";
            this.txttongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1168, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thongTinTaiToolStripMenuItem
            // 
            this.thongTinTaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.dăngXuấtToolStripMenuItem});
            this.thongTinTaiToolStripMenuItem.Name = "thongTinTaiToolStripMenuItem";
            this.thongTinTaiToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thongTinTaiToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // dăngXuấtToolStripMenuItem
            // 
            this.dăngXuấtToolStripMenuItem.Name = "dăngXuấtToolStripMenuItem";
            this.dăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.dăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.dăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.ĐăngXuấtToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thongTinTaiToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1168, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 705);
            this.Controls.Add(this.txttongtien);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableManager";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_Discount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbfood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btn_AddFood;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.Button btn_Checkout;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btn_Discount;
        private System.Windows.Forms.NumericUpDown nm_Discount;
        private System.Windows.Forms.Button btn_SwitchTable;
        private System.Windows.Forms.ComboBox cb_SwitchTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongTinTaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dăngXuấtToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.TextBox txt_EndTime;
        private System.Windows.Forms.TextBox txt_StartTime;
    }
}