﻿namespace _32ChannelUsbGpioDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gpiosetButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comportNumberbox = new System.Windows.Forms.TextBox();
            this.openportButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.gpioreadButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpiosetButton
            // 
            this.gpiosetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpiosetButton.Location = new System.Drawing.Point(8, 72);
            this.gpiosetButton.Margin = new System.Windows.Forms.Padding(4);
            this.gpiosetButton.Name = "gpiosetButton";
            this.gpiosetButton.Size = new System.Drawing.Size(139, 86);
            this.gpiosetButton.TabIndex = 8;
            this.gpiosetButton.Text = "Forward";
            this.gpiosetButton.UseVisualStyleBackColor = true;
            this.gpiosetButton.Click += new System.EventHandler(this.gpiosetButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gpioreadButton);
            this.groupBox1.Controls.Add(this.gpiosetButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comportNumberbox);
            this.groupBox1.Controls.Add(this.openportButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(335, 170);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter COM Port Number";
            // 
            // comportNumberbox
            // 
            this.comportNumberbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comportNumberbox.Location = new System.Drawing.Point(167, 36);
            this.comportNumberbox.Margin = new System.Windows.Forms.Padding(4);
            this.comportNumberbox.Multiline = true;
            this.comportNumberbox.Name = "comportNumberbox";
            this.comportNumberbox.Size = new System.Drawing.Size(154, 27);
            this.comportNumberbox.TabIndex = 1;
            // 
            // openportButton
            // 
            this.openportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openportButton.Location = new System.Drawing.Point(8, 20);
            this.openportButton.Margin = new System.Windows.Forms.Padding(4);
            this.openportButton.Name = "openportButton";
            this.openportButton.Size = new System.Drawing.Size(151, 44);
            this.openportButton.TabIndex = 0;
            this.openportButton.Text = "Open COM Port";
            this.openportButton.UseVisualStyleBackColor = true;
            this.openportButton.Click += new System.EventHandler(this.openportButton_Click);
            // 
            // gpioreadButton
            // 
            this.gpioreadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpioreadButton.Location = new System.Drawing.Point(155, 73);
            this.gpioreadButton.Margin = new System.Windows.Forms.Padding(4);
            this.gpioreadButton.Name = "gpioreadButton";
            this.gpioreadButton.Size = new System.Drawing.Size(139, 85);
            this.gpioreadButton.TabIndex = 8;
            this.gpioreadButton.Text = "Backward";
            this.gpioreadButton.UseVisualStyleBackColor = true;
            this.gpioreadButton.Click += new System.EventHandler(this.gpioreadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(705, 423);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(723, 470);
            this.MinimumSize = new System.Drawing.Size(723, 470);
            this.Name = "Form1";
            this.Text = "32 Channel Usb Gpio Module Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button gpiosetButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox comportNumberbox;
        private System.Windows.Forms.Button openportButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button gpioreadButton;
    }
}

