namespace BusNotifier {
    partial class ConfigurationDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmboRoute = new System.Windows.Forms.ComboBox();
            this.cmboStop = new System.Windows.Forms.ComboBox();
            this.chkEnableAlerts = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.and = new System.Windows.Forms.Label();
            this.nmAlertWhen = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tmStart = new System.Windows.Forms.DateTimePicker();
            this.tmEnd = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nmAlertWhen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Route";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(84, 194);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmboRoute
            // 
            this.cmboRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboRoute.FormattingEnabled = true;
            this.cmboRoute.Location = new System.Drawing.Point(56, 15);
            this.cmboRoute.Name = "cmboRoute";
            this.cmboRoute.Size = new System.Drawing.Size(184, 21);
            this.cmboRoute.TabIndex = 6;
            this.cmboRoute.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // cmboStop
            // 
            this.cmboStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboStop.FormattingEnabled = true;
            this.cmboStop.Location = new System.Drawing.Point(56, 47);
            this.cmboStop.Name = "cmboStop";
            this.cmboStop.Size = new System.Drawing.Size(184, 21);
            this.cmboStop.TabIndex = 7;
            // 
            // chkEnableAlerts
            // 
            this.chkEnableAlerts.AutoSize = true;
            this.chkEnableAlerts.Location = new System.Drawing.Point(13, 83);
            this.chkEnableAlerts.Name = "chkEnableAlerts";
            this.chkEnableAlerts.Size = new System.Drawing.Size(126, 17);
            this.chkEnableAlerts.TabIndex = 8;
            this.chkEnableAlerts.Text = "Enable Alert Balloons";
            this.chkEnableAlerts.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Between";
            // 
            // and
            // 
            this.and.AutoSize = true;
            this.and.Location = new System.Drawing.Point(14, 134);
            this.and.Name = "and";
            this.and.Size = new System.Drawing.Size(25, 13);
            this.and.TabIndex = 12;
            this.and.Text = "and";
            // 
            // nmAlertWhen
            // 
            this.nmAlertWhen.Location = new System.Drawing.Point(100, 162);
            this.nmAlertWhen.Name = "nmAlertWhen";
            this.nmAlertWhen.Size = new System.Drawing.Size(55, 20);
            this.nmAlertWhen.TabIndex = 13;
            this.nmAlertWhen.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Alert When ETA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "(minutes)";
            // 
            // tmStart
            // 
            this.tmStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tmStart.Location = new System.Drawing.Point(84, 107);
            this.tmStart.Name = "tmStart";
            this.tmStart.ShowUpDown = true;
            this.tmStart.Size = new System.Drawing.Size(102, 20);
            this.tmStart.TabIndex = 16;
            // 
            // tmEnd
            // 
            this.tmEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tmEnd.Location = new System.Drawing.Point(84, 134);
            this.tmEnd.Name = "tmEnd";
            this.tmEnd.ShowUpDown = true;
            this.tmEnd.Size = new System.Drawing.Size(102, 20);
            this.tmEnd.TabIndex = 17;
            // 
            // ConfigurationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 228);
            this.Controls.Add(this.tmEnd);
            this.Controls.Add(this.tmStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nmAlertWhen);
            this.Controls.Add(this.and);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkEnableAlerts);
            this.Controls.Add(this.cmboStop);
            this.Controls.Add(this.cmboRoute);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigurationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigurationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmAlertWhen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmboRoute;
        private System.Windows.Forms.ComboBox cmboStop;
        private System.Windows.Forms.CheckBox chkEnableAlerts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label and;
        private System.Windows.Forms.NumericUpDown nmAlertWhen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker tmStart;
        private System.Windows.Forms.DateTimePicker tmEnd;
    }
}