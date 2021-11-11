
namespace week08
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
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.carButton = new System.Windows.Forms.Button();
            this.ballButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPick = new System.Windows.Forms.Button();
            this.presentButton = new System.Windows.Forms.Button();
            this.ribbonColorPick = new System.Windows.Forms.Button();
            this.boxColorPick = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.boxColorPick);
            this.mainPanel.Controls.Add(this.ribbonColorPick);
            this.mainPanel.Controls.Add(this.presentButton);
            this.mainPanel.Controls.Add(this.colorPick);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.ballButton);
            this.mainPanel.Controls.Add(this.carButton);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // carButton
            // 
            this.carButton.Location = new System.Drawing.Point(3, 334);
            this.carButton.Name = "carButton";
            this.carButton.Size = new System.Drawing.Size(108, 49);
            this.carButton.TabIndex = 0;
            this.carButton.Text = "CAR";
            this.carButton.UseVisualStyleBackColor = true;
            this.carButton.Click += new System.EventHandler(this.carButton_Click);
            // 
            // ballButton
            // 
            this.ballButton.Location = new System.Drawing.Point(3, 389);
            this.ballButton.Name = "ballButton";
            this.ballButton.Size = new System.Drawing.Size(108, 49);
            this.ballButton.TabIndex = 1;
            this.ballButton.Text = "BALL";
            this.ballButton.UseVisualStyleBackColor = true;
            this.ballButton.Click += new System.EventHandler(this.ballButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Coming next....";
            // 
            // colorPick
            // 
            this.colorPick.BackColor = System.Drawing.Color.Fuchsia;
            this.colorPick.Location = new System.Drawing.Point(117, 389);
            this.colorPick.Name = "colorPick";
            this.colorPick.Size = new System.Drawing.Size(87, 23);
            this.colorPick.TabIndex = 3;
            this.colorPick.UseVisualStyleBackColor = false;
            this.colorPick.Click += new System.EventHandler(this.button1_Click);
            // 
            // presentButton
            // 
            this.presentButton.Location = new System.Drawing.Point(3, 279);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(108, 49);
            this.presentButton.TabIndex = 4;
            this.presentButton.Text = "PRESENT";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.presentButton_Click);
            // 
            // ribbonColorPick
            // 
            this.ribbonColorPick.BackColor = System.Drawing.Color.Fuchsia;
            this.ribbonColorPick.Location = new System.Drawing.Point(117, 279);
            this.ribbonColorPick.Name = "ribbonColorPick";
            this.ribbonColorPick.Size = new System.Drawing.Size(87, 23);
            this.ribbonColorPick.TabIndex = 5;
            this.ribbonColorPick.UseVisualStyleBackColor = false;
            this.ribbonColorPick.Click += new System.EventHandler(this.button1_Click);
            // 
            // boxColorPick
            // 
            this.boxColorPick.BackColor = System.Drawing.Color.Lime;
            this.boxColorPick.Location = new System.Drawing.Point(117, 305);
            this.boxColorPick.Name = "boxColorPick";
            this.boxColorPick.Size = new System.Drawing.Size(87, 23);
            this.boxColorPick.TabIndex = 6;
            this.boxColorPick.UseVisualStyleBackColor = false;
            this.boxColorPick.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ballButton;
        private System.Windows.Forms.Button carButton;
        private System.Windows.Forms.Button colorPick;
        private System.Windows.Forms.Button boxColorPick;
        private System.Windows.Forms.Button ribbonColorPick;
        private System.Windows.Forms.Button presentButton;
    }
}

