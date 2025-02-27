using GeometryGenerator.Generators;
using GeometryGenerator.GeoGen;
using GeometryGenerator.Geometry;
using GeometryGenerator.Render;

namespace GeometryGenerator
{
    public partial class GeometryForm : Form
    {
        public static GeometryForm? MainForm = null;

        private Model m_model;
        private Renderer m_renderer;

        private Point m_lastMouse = Point.Empty;
        private bool m_trackingMouse = false;

        private List<IGenerator> m_geometries = new List<IGenerator>();
        private Panel? m_currentPanel = null;

        public GeometryForm()
        {
            MainForm = this;

            InitializeComponent();
            m_model = new Model();
            m_renderer = new Renderer(c_preview);

            Application.Idle += new EventHandler(OnIdle);

            c_geometries.Items.Clear();
            c_geometries.Items.Add(new Sphere());
            c_geometries.Items.Add(new Geodesic());
            c_geometries.Items.Add(new Disc());
            c_geometries.Items.Add(new Ring());
            c_geometries.Items.Add(new Icosohedron());
            c_geometries.Items.Add(new Tetrahedron());
            c_geometries.Items.Add(new Cube());
        }

        private void GeometryForm_Load(object sender, EventArgs e)
        {
            c_preview.BackColor = Color.Black;
            m_renderer.DrawModel(m_model);
        }

        private void OnSaveModel(object sender, EventArgs e)
        {
            // Is there anything to save?
            if (m_model.Meshes.Count == 0)
            {
                MessageBox.Show(
                    "The current model does not contain any content.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "OBJ File (*.obj)|*.obj";
            saveFileDialog.Title = "Select path to save file";
            saveFileDialog.DefaultExt = "obj";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (FileOBJ.Save(m_model, saveFileDialog.FileName) == true)
                {
                    MessageBox.Show(
                        "Model file saved!",
                        "File Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Error saving file!",
                        "File Not Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void OnIdle(object? sender, EventArgs e)
        {
            while (ApplicationExtensions.IsIdle() == true)
            {
                m_renderer.DrawModel(m_model);
            }
        }

        private void c_preview_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastMouse = e.Location;
            m_trackingMouse = true;
        }

        private void c_preview_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_trackingMouse == false)
            {
                return;
            }

            float angleDelta = 0.003f;
            m_renderer.Angle += angleDelta * (float)(e.Location.X - m_lastMouse.X);
            m_renderer.Elevation -= angleDelta * (float)(e.Location.Y - m_lastMouse.Y);
            m_lastMouse = e.Location;
        }

        private void c_preview_MouseUp(object sender, MouseEventArgs e)
        {
            m_trackingMouse = false;
        }

        private void c_preview_MouseLeave(object sender, EventArgs e)
        {
            m_trackingMouse = false;
        }

        private void c_preview_MouseWheel(object sender, MouseEventArgs e)
        {
            float zoomDelta = 0.1f;
            if (e.Delta < 0)
                zoomDelta = -zoomDelta;

            m_renderer.Zoom += zoomDelta;
        }

        private void c_geometries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IGenerator? currentGenerator = c_geometries.SelectedItem as IGenerator;
            if (currentGenerator == null)
                return;

            Panel optionsPanel = currentGenerator.GetOptionsPanel();

            if (m_currentPanel != optionsPanel)
            {
                if (m_currentPanel != null)
                {
                    Controls.Remove(m_currentPanel);
                }

                m_currentPanel = optionsPanel;
                optionsPanel.Location = new Point(c_geometries.Location.X, c_geometries.Location.Y + 40);
                Controls.Add(optionsPanel);

                m_model = currentGenerator.Create(currentGenerator.GetValues());

                m_renderer.ResetCamera();
            }
        }

        public void RebuildModel()
        {
            IGenerator? currentGenerator = c_geometries.SelectedItem as IGenerator;
            if (currentGenerator == null)
                return;

            m_model = currentGenerator.Create(currentGenerator.GetValues());
        }
    }
}
