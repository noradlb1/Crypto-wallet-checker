namespace SeedBrutoforce
{
	// Token: 0x0200000A RID: 10
	public partial class ActivationForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000028 RID: 40 RVA: 0x00003A9C File Offset: 0x00001C9C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003ACC File Offset: 0x00001CCC
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::SeedBrutoforce.ActivationForm));
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.textBox1.BackColor = global::System.Drawing.SystemColors.ScrollBar;
			this.textBox1.Location = new global::System.Drawing.Point(12, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(230, 20);
			this.textBox1.TabIndex = 0;
			this.button1.BackColor = global::System.Drawing.Color.Green;
			this.button1.ForeColor = global::System.Drawing.SystemColors.Control;
			this.button1.Location = new global::System.Drawing.Point(268, 53);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(131, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Activate";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.label1.Location = new global::System.Drawing.Point(46, 26);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(156, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Your activation key:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(411, 115);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.textBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Location = new global::System.Drawing.Point(300, 50);
			base.Name = "ActivationForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Seed Brutoforce Activation";
			base.Load += new global::System.EventHandler(this.Form1_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000032 RID: 50
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.TextBox textBox1;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Label label1;
	}
}
