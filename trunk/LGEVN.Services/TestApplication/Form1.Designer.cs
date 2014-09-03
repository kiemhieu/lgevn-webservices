namespace TestApplication
{
    partial class Form1
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
            this.btnPR_RESPONSE_WS_EDI = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPR_RESPONSE_WS_EDI
            // 
            this.btnPR_RESPONSE_WS_EDI.Location = new System.Drawing.Point(99, 104);
            this.btnPR_RESPONSE_WS_EDI.Name = "btnPR_RESPONSE_WS_EDI";
            this.btnPR_RESPONSE_WS_EDI.Size = new System.Drawing.Size(217, 54);
            this.btnPR_RESPONSE_WS_EDI.TabIndex = 0;
            this.btnPR_RESPONSE_WS_EDI.Text = "CALL PR_RESPONSE_WS_EDI";
            this.btnPR_RESPONSE_WS_EDI.UseVisualStyleBackColor = true;
            this.btnPR_RESPONSE_WS_EDI.Click += new System.EventHandler(this.btnPR_RESPONSE_WS_EDI_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(180, 324);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(16, 13);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "...";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(99, 319);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Count data";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 410);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnPR_RESPONSE_WS_EDI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPR_RESPONSE_WS_EDI;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnTest;

    }
}

