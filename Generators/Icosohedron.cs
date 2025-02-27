using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    /// <summary>
    /// Creates a basic unit icosohedron.
    /// </summary>
    public class Icosohedron : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
        };

        public Icosohedron()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Icosohedron";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            Mesh mesh = new Mesh("Icosohedron");

            float phi = (1.0f + MathF.Sqrt(5.0f)) * 0.5f; // golden ratio
            float a = 1.0f;
            float b = 1.0f / phi;

            // Manually add each vertex.
            mesh.AddVertex(Vector3.Normalize(new Vector3(0, b, -a)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(b, a, 0)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(-b, a, 0)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(0, b, a)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(0, -b, a)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(-a, 0, b)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(0, -b, -a)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(a, 0, -b)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(a, 0, b)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(-a, 0, -b)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(b, -a, 0)));
            mesh.AddVertex(Vector3.Normalize(new Vector3(-b, -a, 0)));

            // Add all faces.
            mesh.AddFace(new Face(2, 1, 0));
            mesh.AddFace(new Face(2, 1, 0));
            mesh.AddFace(new Face(1, 2, 3));
            mesh.AddFace(new Face(5, 4, 3));
            mesh.AddFace(new Face(4, 8, 3));
            mesh.AddFace(new Face(7, 6, 0));
            mesh.AddFace(new Face(6, 9, 0));
            mesh.AddFace(new Face(11, 10, 4));
            mesh.AddFace(new Face(10, 11, 6));
            mesh.AddFace(new Face(9, 5, 2));
            mesh.AddFace(new Face(5, 9, 11));
            mesh.AddFace(new Face(8, 7, 1));
            mesh.AddFace(new Face(7, 8, 10));
            mesh.AddFace(new Face(2, 5, 3));
            mesh.AddFace(new Face(8, 1, 3));
            mesh.AddFace(new Face(9, 2, 0));
            mesh.AddFace(new Face(1, 7, 0));
            mesh.AddFace(new Face(11, 9, 6));
            mesh.AddFace(new Face(7, 10, 6));
            mesh.AddFace(new Face(5, 11, 4));
            mesh.AddFace(new Face(10, 8, 4));

            return new Model(mesh);
        }
    }
}
