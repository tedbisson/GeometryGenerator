using GeometryGenerator.Generator;
using GeometryGenerator.GeoGen;
using GeometryGenerator.Geometry;
using GeometryGenerator.Render;

namespace GeometryGenerator
{
    public partial class GeometryForm : Form
    {
        private Model m_model = new Model();
        private Renderer m_render;

        public GeometryForm()
        {
            InitializeComponent();
            m_model = new Model();
            c_stacks.Text = "32";
            c_slices.Text = "32";
            c_divisons.Text = "3";
            c_sectors.Text = "48";
            c_tracks.Text = "8";
            c_innerRadius.Text = "1.2";
            c_outerRadius.Text = "1.6";
            m_render = new Renderer(c_preview);

            Application.Idle += new EventHandler(OnIdle);
        }

        private void GeometryForm_Load(object sender, EventArgs e)
        {
            c_preview.BackColor = Color.Black;
            m_render.DrawModel(m_model);
        }

        private void OnCreateSphere(object sender, EventArgs e)
        {
            // Read the number of stacks and slices.
            int stacks = 0;
            int slices = 0;
            if (int.TryParse(c_stacks.Text, out stacks) == false ||
                int.TryParse(c_slices.Text, out slices) == false ||
                stacks < 2 || slices < 2)
            {
                MessageBox.Show(
                    "The number of stacks or slices is invalid, must be >= 2!",
                    "Invalid Sphere Characteristics",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create a new model and generate the sphere.
            m_model = new Model();
            m_model.Meshes.Add(SphereGen.Create(stacks, slices));

            // Redraw the model view.
            m_render.DrawModel(m_model);
        }

        private void OnCreateGeodesic(object sender, EventArgs e)
        {
            // Read the number of divisions.
            int divisions = 0;
            if (int.TryParse(c_divisons.Text, out divisions) == false ||
                divisions < 0)
            {
                MessageBox.Show(
                    "The number of divisions must not be negative!",
                    "Invalid Geodesic Characteristics",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create a new model and generate the geodesic.
            m_model = new Model();
            m_model.Meshes.Add(GeodesicGen.Create(divisions));

            // Redraw the model view.
            m_render.DrawModel(m_model);
        }

        private void c_createRing_Click(object sender, EventArgs e)
        {
            // Read the parameters
            int tracks = 0;
            int sectors = 0;
            float innerRadius = 0.0f;
            float outerRadius = 0.0f;
            if (int.TryParse(c_tracks.Text, out tracks) == false ||
                int.TryParse(c_sectors.Text, out sectors) == false ||
                float.TryParse(c_innerRadius.Text, out innerRadius) == false ||
                float.TryParse(c_outerRadius.Text, out outerRadius) == false)
            {
                MessageBox.Show(
                    "Unable to parse ring parameters!",
                    "Invalid Ring Characteristics",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Create a new model and generate the geodesic.
            m_model = new Model();
            m_model.Meshes.Add(
                RingGen.Create(
                    new RingGen.CreateParams(
                        tracks,
                        sectors,
                        innerRadius,
                        outerRadius)));

            // Redraw the model view.
            m_render.DrawModel(m_model);
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
                m_render.DrawModel(m_model);
            }
        }
    }
}
