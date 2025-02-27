using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    /// <summary>
    /// Creates a basic unit tetrahedron.
    /// 
    /// Sources:
    ///   https://danielsieger.com/blog/2021/01/03/generating-platonic-solids.html
    /// </summary>
    public class Tetrahedron : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
        };

        public Tetrahedron()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Tetrahedron";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            Mesh mesh = new Mesh("Tetrahedron");

            float a = 1.0f / 3.0f;
            float b = MathF.Sqrt(8.0f / 9.0f);
            float c = MathF.Sqrt(2.0f / 9.0f);
            float d = MathF.Sqrt(2.0f / 3.0f);

            int v0 = mesh.AddVertex(new Vector3(0, 0, 1));
            int v1 = mesh.AddVertex(new Vector3(-c, d, -a));
            int v2 = mesh.AddVertex(new Vector3(-c, -d, -a));
            int v3 = mesh.AddVertex(new Vector3(b, 0, -a));

            mesh.AddFace(new Face(v0, v1, v2));
            mesh.AddFace(new Face(v0, v2, v3));
            mesh.AddFace(new Face(v0, v3, v1));
            mesh.AddFace(new Face(v3, v2, v1));

            return new Model(mesh);
        }
    }
}
