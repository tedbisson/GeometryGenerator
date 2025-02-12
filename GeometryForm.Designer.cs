namespace GeometryGenerator
{
    partial class GeometryForm
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
            c_createSphere = new Button();
            c_createGeodesic = new Button();
            c_stacks = new TextBox();
            c_slices = new TextBox();
            c_divisons = new TextBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            c_preview = new Panel();
            c_saveModel = new Button();
            groupBox3 = new GroupBox();
            c_outerRadius = new TextBox();
            label6 = new Label();
            c_innerRadius = new TextBox();
            label7 = new Label();
            c_sectors = new TextBox();
            label5 = new Label();
            c_tracks = new TextBox();
            label4 = new Label();
            c_createRing = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // c_createSphere
            // 
            c_createSphere.Location = new Point(103, 125);
            c_createSphere.Name = "c_createSphere";
            c_createSphere.Size = new Size(112, 34);
            c_createSphere.TabIndex = 0;
            c_createSphere.Text = "Create";
            c_createSphere.UseVisualStyleBackColor = true;
            c_createSphere.Click += OnCreateSphere;
            // 
            // c_createGeodesic
            // 
            c_createGeodesic.Location = new Point(103, 98);
            c_createGeodesic.Name = "c_createGeodesic";
            c_createGeodesic.Size = new Size(112, 34);
            c_createGeodesic.TabIndex = 1;
            c_createGeodesic.Text = "Create";
            c_createGeodesic.UseVisualStyleBackColor = true;
            c_createGeodesic.Click += OnCreateGeodesic;
            // 
            // c_stacks
            // 
            c_stacks.Location = new Point(103, 47);
            c_stacks.Name = "c_stacks";
            c_stacks.Size = new Size(112, 31);
            c_stacks.TabIndex = 2;
            // 
            // c_slices
            // 
            c_slices.Location = new Point(103, 84);
            c_slices.Name = "c_slices";
            c_slices.Size = new Size(112, 31);
            c_slices.TabIndex = 3;
            // 
            // c_divisons
            // 
            c_divisons.Location = new Point(103, 57);
            c_divisons.Name = "c_divisons";
            c_divisons.Size = new Size(112, 31);
            c_divisons.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(c_stacks);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(c_createSphere);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(c_slices);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(241, 180);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Standard Sphere";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 90);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 7;
            label2.Text = "Slices";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 50);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 6;
            label1.Text = "Stacks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 60);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 8;
            label3.Text = "Divisons";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(c_divisons);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(c_createGeodesic);
            groupBox2.Location = new Point(12, 202);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(241, 198);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Geodesic Sphere";
            // 
            // c_preview
            // 
            c_preview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            c_preview.Location = new Point(270, 21);
            c_preview.Name = "c_preview";
            c_preview.Size = new Size(1283, 951);
            c_preview.TabIndex = 9;
            c_preview.MouseDown += c_preview_MouseDown;
            c_preview.MouseLeave += c_preview_MouseLeave;
            c_preview.MouseMove += c_preview_MouseMove;
            c_preview.MouseUp += c_preview_MouseUp;
            c_preview.MouseWheel += c_preview_MouseWheel;
            // 
            // c_saveModel
            // 
            c_saveModel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            c_saveModel.Location = new Point(38, 938);
            c_saveModel.Name = "c_saveModel";
            c_saveModel.Size = new Size(189, 34);
            c_saveModel.TabIndex = 10;
            c_saveModel.Text = "Save Model";
            c_saveModel.UseVisualStyleBackColor = true;
            c_saveModel.Click += OnSaveModel;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(c_outerRadius);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(c_innerRadius);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(c_sectors);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(c_tracks);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(c_createRing);
            groupBox3.Location = new Point(12, 410);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(241, 265);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ring";
            // 
            // c_outerRadius
            // 
            c_outerRadius.Location = new Point(103, 168);
            c_outerRadius.Name = "c_outerRadius";
            c_outerRadius.Size = new Size(112, 31);
            c_outerRadius.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 171);
            label6.Name = "label6";
            label6.Size = new Size(57, 25);
            label6.TabIndex = 14;
            label6.Text = "Outer";
            // 
            // c_innerRadius
            // 
            c_innerRadius.Location = new Point(103, 131);
            c_innerRadius.Name = "c_innerRadius";
            c_innerRadius.Size = new Size(112, 31);
            c_innerRadius.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(45, 134);
            label7.Name = "label7";
            label7.Size = new Size(52, 25);
            label7.TabIndex = 12;
            label7.Text = "Inner";
            // 
            // c_sectors
            // 
            c_sectors.Location = new Point(103, 94);
            c_sectors.Name = "c_sectors";
            c_sectors.Size = new Size(112, 31);
            c_sectors.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 97);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 10;
            label5.Text = "Sectors";
            // 
            // c_tracks
            // 
            c_tracks.Location = new Point(103, 57);
            c_tracks.Name = "c_tracks";
            c_tracks.Size = new Size(112, 31);
            c_tracks.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 60);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 8;
            label4.Text = "Tracks";
            // 
            // c_createRing
            // 
            c_createRing.Location = new Point(103, 209);
            c_createRing.Name = "c_createRing";
            c_createRing.Size = new Size(112, 34);
            c_createRing.TabIndex = 1;
            c_createRing.Text = "Create";
            c_createRing.UseVisualStyleBackColor = true;
            c_createRing.Click += c_createRing_Click;
            // 
            // GeometryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1565, 984);
            Controls.Add(groupBox3);
            Controls.Add(c_saveModel);
            Controls.Add(c_preview);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "GeometryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Geometry Generator";
            Load += GeometryForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button c_createSphere;
        private Button c_createGeodesic;
        private TextBox c_stacks;
        private TextBox c_slices;
        private TextBox c_divisons;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private GroupBox groupBox2;
        private Panel c_preview;
        private Button c_saveModel;
        private GroupBox groupBox3;
        private TextBox c_outerRadius;
        private Label label6;
        private TextBox c_innerRadius;
        private Label label7;
        private TextBox c_sectors;
        private Label label5;
        private TextBox c_tracks;
        private Label label4;
        private Button c_createRing;
    }
}
