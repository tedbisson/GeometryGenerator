using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generators
{
    /// <summary>
    /// Creates a geodesic sphere, starting with a unit icosphere and then
    /// subdividing the faces.
    /// 
    /// Sources:
    ///   https://danielsieger.com/blog/2021/01/03/generating-platonic-solids.html
    ///   https://danielsieger.com/blog/2021/03/27/generating-spheres.html 
    /// </summary>
    public class Geodesic : OptionsPanel, IGenerator
    {
        /// <summary>
        /// Descriptions for each of the fields that should be available in
        /// the options panel, needed to generate this geometry.   
        /// </summary>
        private OptionsPanel.Descriptor[] m_optionDescriptors =
        {
            new OptionsPanel.Descriptor("Divisions", 3, 0, 6, false, 1),
        };

        public Geodesic()
        {
            CreateFromDescriptors(m_optionDescriptors);
        }

        public override string ToString()
        {
            return "Geodesic";
        }

        public Model Create(Dictionary<string, float> optionValues)
        {
            // Extract the required creation values.
            int divisions = (int)optionValues["Divisions"];

            Icosohedron icosohedron = new Icosohedron();
            Model model = icosohedron.Create(new Dictionary<string, float>());
            Mesh mesh = model.Meshes[0];
            mesh.Name = "Geodesic";

            for (int i = 0; i < divisions; ++i)
            {
                SubdivideFaces(mesh);
            }

            return model;
        }

        /// <summary>
        /// Iterates through each triangle face and divides it into 4 trangles with
        /// new vertices at the midpoint of each original edge. (New vertices are
        /// placed on the unit sphere.)
        /// </summary>
        /// <param name="mesh">The mesh on which to operate.</param>
        private void SubdivideFaces(Mesh mesh)
        {
            List<Face> oldFaces = mesh.Faces;
            mesh.Faces = new List<Face>();

            foreach (Face face in oldFaces)
            {
                // Get each vertex.
                int a = face.A;
                int b = face.B;
                int c = face.C;

                // Divide each side of the original face.
                int d = mesh.AddVertex(Vector3.Normalize(mesh.Vertices[a] + mesh.Vertices[b]));
                int e = mesh.AddVertex(Vector3.Normalize(mesh.Vertices[b] + mesh.Vertices[c]));
                int f = mesh.AddVertex(Vector3.Normalize(mesh.Vertices[c] + mesh.Vertices[a]));

                // Add each new face.
                mesh.Faces.Add(new Face(a, d, f));
                mesh.Faces.Add(new Face(d, b, e));
                mesh.Faces.Add(new Face(f, e, c));
                mesh.Faces.Add(new Face(d, e, f));
            }
        }
    }
}
