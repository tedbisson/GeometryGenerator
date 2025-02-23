using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    public class Disc : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Sectors", 32, 3, 512),
            new OptionsPanel.Descriptor("Tracks", 4, 1, 128),
            new OptionsPanel.Descriptor("InnerRadius", 1.2f, 0.1f, 10.0f),
            new OptionsPanel.Descriptor("OuterRadius", 1.6f, 0.1f, 10.0f),
        };

        public Disc()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Disc";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int sectors = (int)optionValues["Sectors"];
            int tracks = (int)optionValues["Tracks"];
            float innerRadius = optionValues["InnerRadius"];
            float outerRadius = optionValues["OuterRadius"];

            Mesh mesh = new Mesh("Ring");

            float deltaTheta = MathF.Tau / sectors;
            float deltaRadius = (outerRadius - innerRadius) / tracks;

            // Create vertices around the ring.
            float radius = innerRadius;
            for (int track = 0; track <= tracks; ++track)
            {
                float theta = 0.0f;
                for (int sector = 0; sector < sectors; ++sector)
                {
                    Vector3 v = new Vector3(
                        radius * MathF.Sin(theta),
                        0.0f,
                        radius * MathF.Cos(theta));

                    mesh.AddVertex(v);

                    theta += deltaTheta;
                }

                radius += deltaRadius;
            }

            // Create faces.
            for (int track = 0; track < tracks; ++track)
            {
                for (int sector = 0; sector < sectors - 1; ++sector)
                {
                    int a = track * sectors + sector;
                    int b = a + 1;
                    int c = a + sectors;
                    int d = c + 1;

                    mesh.AddFace(new Face(a, b, c));
                    mesh.AddFace(new Face(a, c, b));

                    mesh.AddFace(new Face(b, d, c));
                    mesh.AddFace(new Face(b, c, d));
                }

                {
                    int a = track * sectors + sectors - 1;
                    int b = a + 1 - sectors;
                    int c = a + sectors;
                    int d = c + 1 - sectors;

                    mesh.AddFace(new Face(a, b, c));
                    mesh.AddFace(new Face(a, c, b));

                    mesh.AddFace(new Face(b, d, c));
                    mesh.AddFace(new Face(b, c, d));
                }

            }

            return new Model(mesh);
        }
    }
}
