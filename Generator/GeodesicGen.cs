using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Generator
{
    public static class GeodesicGen
    {
        /// <summary>
        /// Creates a geodesic sphere, starting with a unit icosphere and then
        /// subdividing the faces.
        /// 
        /// Sources:
        ///   https://danielsieger.com/blog/2021/01/03/generating-platonic-solids.html
        ///   https://danielsieger.com/blog/2021/03/27/generating-spheres.html 
        /// </summary>
        /// <param name="divisions">Number of subdivisons to perform.</param>
        /// <returns></returns>
        public static Mesh Create(int divisions)
        {
            Mesh mesh = BaseIcosohedron();
            mesh.Name = "Geodesic";

            for (int i = 0; i < divisions; ++i)
            {
                SubdivideFaces(mesh);
            }

            return mesh;
        }

        /// <summary>
        /// Iterates through each triangle face and divides it into 4 trangles with
        /// new vertices at the midpoint of each original edge. (New vertices are
        /// placed on the unit sphere.)
        /// </summary>
        /// <param name="mesh">The mesh on which to operate.</param>
        private static void SubdivideFaces(Mesh mesh)
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

        /// <summary>
        /// Mathematically generates an isocohedron.
        /// </summary>
        /// <returns>A mesh representing a unit icosohedron.</returns>
        private static Mesh BaseIcosohedron()
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

            return mesh;
        }
    }
}
