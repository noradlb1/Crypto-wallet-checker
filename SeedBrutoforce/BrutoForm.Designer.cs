namespace SeedBrutoforce
{
	// Token: 0x02000002 RID: 2
	public partial class BrutoForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002B70 File Offset: 0x00000D70
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002BA0 File Offset: 0x00000DA0
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::SeedBrutoforce.BrutoForm));
			this.richTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.richTextBox2 = new global::System.Windows.Forms.RichTextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.panel5 = new global::System.Windows.Forms.Panel();
			base.SuspendLayout();
			this.richTextBox1.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.richTextBox1.ForeColor = global::System.Drawing.Color.Green;
			this.richTextBox1.Location = new global::System.Drawing.Point(13, 255);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.None;
			this.richTextBox1.Size = new global::System.Drawing.Size(238, 91);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			this.richTextBox2.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.richTextBox2.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBox2.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 204);
			this.richTextBox2.ForeColor = global::System.Drawing.SystemColors.Menu;
			this.richTextBox2.Location = new global::System.Drawing.Point(12, 41);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.ReadOnly = true;
			this.richTextBox2.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.None;
			this.richTextBox2.Size = new global::System.Drawing.Size(239, 174);
			this.richTextBox2.TabIndex = 1;
			this.richTextBox2.Text = "";
			this.richTextBox2.WordWrap = false;
			this.button1.BackColor = global::System.Drawing.Color.DarkGreen;
			this.button1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new global::System.Drawing.Font("Tahoma", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.button1.ForeColor = global::System.Drawing.SystemColors.Control;
			this.button1.Location = new global::System.Drawing.Point(12, 366);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(239, 35);
			this.button1.TabIndex = 2;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.BackColor = global::System.Drawing.Color.Brown;
			this.button2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.button2.Enabled = false;
			this.button2.Font = new global::System.Drawing.Font("Tahoma", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.button2.ForeColor = global::System.Drawing.SystemColors.Control;
			this.button2.Location = new global::System.Drawing.Point(13, 407);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(238, 37);
			this.button2.TabIndex = 3;
			this.button2.Text = "STOP";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Tahoma", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label1.ForeColor = global::System.Drawing.Color.Green;
			this.label1.Location = new global::System.Drawing.Point(12, 234);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(65, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "found:0";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Tahoma", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label2.ForeColor = global::System.Drawing.SystemColors.InactiveCaptionText;
			this.label2.Location = new global::System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(74, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "checked:";
			this.timer1.Interval = 2000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.panel5.BackColor = global::System.Drawing.SystemColors.AppWorkspace;
			this.panel5.Location = new global::System.Drawing.Point(12, 352);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(239, 10);
			this.panel5.TabIndex = 12;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.AppWorkspace;
			base.ClientSize = new global::System.Drawing.Size(263, 449);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.richTextBox2);
			base.Controls.Add(this.richTextBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Location = new global::System.Drawing.Point(300, 50);
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(279, 669);
			base.Name = "BrutoForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Paid Software";
			base.FormClosed += new global::System.Windows.Forms.FormClosedEventHandler(this.BrutoForm_FormClosed);
			base.Load += new global::System.EventHandler(this.BrutoForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.RichTextBox richTextBox1;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.RichTextBox richTextBox2;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Panel panel5;
	}
}
