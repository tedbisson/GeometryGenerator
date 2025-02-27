using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    /// <summary>
    /// Creates a basic unit cube.
    /// 
    /// Sources:
    ///   https://danielsieger.com/blog/2021/01/03/generating-platonic-solids.html
    /// </summary>
    public class Cube : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
        };

        public Cube()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Cube";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            Mesh mesh = new Mesh("Cube");

            float a = 1.0f / MathF.Sqrt(3.0f);

            int v0 = mesh.AddVertex(new Vector3(-a, -a, -a));
            int v1 = mesh.AddVertex(new Vector3(a, -a, -a));
            int v2 = mesh.AddVertex(new Vector3(a, a, -a));
            int v3 = mesh.AddVertex(new Vector3(-a, a, -a));
            int v4 = mesh.AddVertex(new Vector3(-a, -a, a));
            int v5 = mesh.AddVertex(new Vector3(a, -a, a));
            int v6 = mesh.AddVertex(new Vector3(a, a, a));
            int v7 = mesh.AddVertex(new Vector3(-a, a, a));

            mesh.AddFace(new Face(v3, v2, v1));
            mesh.AddFace(new Face(v3, v1, v0));
            mesh.AddFace(new Face(v2, v6, v5));
            mesh.AddFace(new Face(v2, v5, v1));
            mesh.AddFace(new Face(v5, v6, v7));
            mesh.AddFace(new Face(v5, v7, v4));
            mesh.AddFace(new Face(v0, v4, v7));
            mesh.AddFace(new Face(v0, v7, v3));
            mesh.AddFace(new Face(v3, v7, v6));
            mesh.AddFace(new Face(v3, v6, v2));
            mesh.AddFace(new Face(v1, v5, v4));
            mesh.AddFace(new Face(v1, v4, v0));

            return new Model(mesh);
        }
    }
}
