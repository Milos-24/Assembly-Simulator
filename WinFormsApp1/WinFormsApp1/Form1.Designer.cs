
namespace Arh_Simulator
{
    partial class Simulator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputRTB = new System.Windows.Forms.RichTextBox();
            this.CompileBtn = new System.Windows.Forms.Button();
            this.DebugBtn = new System.Windows.Forms.Button();
            this.OutputRTB = new System.Windows.Forms.RichTextBox();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.ShowBtn = new System.Windows.Forms.Button();
            this.AddressCheckList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // InputRTB
            // 
            this.InputRTB.BackColor = System.Drawing.Color.LightSlateGray;
            this.InputRTB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputRTB.Location = new System.Drawing.Point(102, 12);
            this.InputRTB.Name = "InputRTB";
            this.InputRTB.Size = new System.Drawing.Size(623, 349);
            this.InputRTB.TabIndex = 0;
            this.InputRTB.Text = "Code:";
            this.InputRTB.TextChanged += new System.EventHandler(this.CodeRTB_TextChanged);
            // 
            // CompileBtn
            // 
            this.CompileBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CompileBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CompileBtn.Location = new System.Drawing.Point(12, 324);
            this.CompileBtn.Name = "CompileBtn";
            this.CompileBtn.Size = new System.Drawing.Size(84, 37);
            this.CompileBtn.TabIndex = 1;
            this.CompileBtn.Text = "Compile";
            this.CompileBtn.UseVisualStyleBackColor = false;
            this.CompileBtn.Click += new System.EventHandler(this.CompileBtn_Click);
            // 
            // DebugBtn
            // 
            this.DebugBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DebugBtn.Location = new System.Drawing.Point(12, 281);
            this.DebugBtn.Name = "DebugBtn";
            this.DebugBtn.Size = new System.Drawing.Size(84, 37);
            this.DebugBtn.TabIndex = 2;
            this.DebugBtn.Text = "Debug";
            this.DebugBtn.UseVisualStyleBackColor = false;
            this.DebugBtn.Click += new System.EventHandler(this.DebugBtn_Click);
            // 
            // OutputRTB
            // 
            this.OutputRTB.BackColor = System.Drawing.Color.LightSlateGray;
            this.OutputRTB.Location = new System.Drawing.Point(12, 367);
            this.OutputRTB.Name = "OutputRTB";
            this.OutputRTB.ReadOnly = true;
            this.OutputRTB.Size = new System.Drawing.Size(713, 65);
            this.OutputRTB.TabIndex = 3;
            this.OutputRTB.Text = "";
            this.OutputRTB.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ExecuteBtn.Location = new System.Drawing.Point(12, 238);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(84, 37);
            this.ExecuteBtn.TabIndex = 4;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = false;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // ShowBtn
            // 
            this.ShowBtn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ShowBtn.Location = new System.Drawing.Point(12, 195);
            this.ShowBtn.Name = "ShowBtn";
            this.ShowBtn.Size = new System.Drawing.Size(84, 37);
            this.ShowBtn.TabIndex = 5;
            this.ShowBtn.Text = "Show";
            this.ShowBtn.UseVisualStyleBackColor = false;
            this.ShowBtn.Click += new System.EventHandler(this.ShowBtn_Click);
            // 
            // AddressCheckList
            // 
            this.AddressCheckList.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AddressCheckList.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddressCheckList.FormattingEnabled = true;
            this.AddressCheckList.Location = new System.Drawing.Point(12, 12);
            this.AddressCheckList.Name = "AddressCheckList";
            this.AddressCheckList.Size = new System.Drawing.Size(84, 154);
            this.AddressCheckList.TabIndex = 6;
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(737, 444);
            this.Controls.Add(this.AddressCheckList);
            this.Controls.Add(this.ShowBtn);
            this.Controls.Add(this.ExecuteBtn);
            this.Controls.Add(this.OutputRTB);
            this.Controls.Add(this.DebugBtn);
            this.Controls.Add(this.CompileBtn);
            this.Controls.Add(this.InputRTB);
            this.Name = "Simulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputRTB;
        private System.Windows.Forms.Button CompileBtn;
        private System.Windows.Forms.Button DebugBtn;
        private System.Windows.Forms.RichTextBox OutputRTB;
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.Button ShowBtn;
        private System.Windows.Forms.CheckedListBox AddressCheckList;
    }
}

