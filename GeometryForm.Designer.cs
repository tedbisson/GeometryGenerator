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
            components = new System.ComponentModel.Container();
            c_preview = new Panel();
            c_saveModel = new Button();
            c_geometries = new ComboBox();
            c_create = new Button();
            imageList1 = new ImageList(components);
            SuspendLayout();
            // 
            // c_preview
            // 
            c_preview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            c_preview.Location = new Point(270, 21);
            c_preview.Name = "c_preview";
            c_preview.Size = new Size(1445, 940);
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
            c_saveModel.Location = new Point(38, 927);
            c_saveModel.Name = "c_saveModel";
            c_saveModel.Size = new Size(189, 34);
            c_saveModel.TabIndex = 10;
            c_saveModel.Text = "Save Model";
            c_saveModel.UseVisualStyleBackColor = true;
            c_saveModel.Click += OnSaveModel;
            // 
            // c_geometries
            // 
            c_geometries.FormattingEnabled = true;
            c_geometries.Location = new Point(12, 21);
            c_geometries.Name = "c_geometries";
            c_geometries.Size = new Size(241, 33);
            c_geometries.Sorted = true;
            c_geometries.TabIndex = 11;
            c_geometries.SelectionChangeCommitted += c_geometries_SelectionChangeCommitted;
            // 
            // c_create
            // 
            c_create.Location = new Point(121, 104);
            c_create.Name = "c_create";
            c_create.Size = new Size(126, 34);
            c_create.TabIndex = 12;
            c_create.Text = "Create";
            c_create.UseVisualStyleBackColor = true;
            c_create.Click += c_create_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // GeometryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1727, 973);
            Controls.Add(c_create);
            Controls.Add(c_geometries);
            Controls.Add(c_saveModel);
            Controls.Add(c_preview);
            Name = "GeometryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Geometry Generator";
            Load += GeometryForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Panel c_preview;
        private Button c_saveModel;
        private ComboBox c_geometries;
        private Button c_create;
        private ImageList imageList1;
    }
}
