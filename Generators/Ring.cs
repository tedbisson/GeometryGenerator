using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    public class Ring : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Segments", 32, 3, 512, false, 1),
            new OptionsPanel.Descriptor("Width", 1.0f, 0.1f, 10.0f, true, 0.1f),
        };

        public Ring()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Ring";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int segments = (int)optionValues["Segments"];
            float width = optionValues["Width"];

            Mesh mesh = new Mesh("Ring");

            float deltaTheta = MathF.Tau / segments;

            // Create vertices around the ring.
            float theta = 0.0f;
            float dx = width / 2.0f;
            for (int i = 0; i < segments; ++i)
            {
                float y = MathF.Sin(theta);
                float z = MathF.Cos(theta);

                mesh.AddVertex(new Vector3(-dx, y, z));
                mesh.AddVertex(new Vector3(dx, y, z));

                theta += deltaTheta;
            }

            // Create the faces.
            for (int i = 0; i < segments - 1; ++i)
            {
                int a = i * 2;

                mesh.AddFace(new Face(a, a + 1, a + 3));
                mesh.AddFace(new Face(a, a + 3, a + 2));
            }
            {
                int a = (segments - 1) * 2;

                mesh.AddFace(new Face(a, a + 1, 1));
                mesh.AddFace(new Face(a, 1, 0));
            }

            return new Model(mesh);
        }
    }
}
