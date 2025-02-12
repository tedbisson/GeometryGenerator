using System.Numerics;

namespace GeometryGenerator.Geometry
{
    public class Mesh
    {
        public string Name = string.Empty;
        public List<Vector3> Vertices = new List<Vector3>();
        private List<Vector3> m_normals = new List<Vector3>();
        public List<Vector2> UVs = new List<Vector2>();
        public List<Face> Faces = new List<Face>();

        private Dictionary<Vector3, int> m_vertexMap = new Dictionary<Vector3, int>();
        private Dictionary<Vector2, int> m_uvMap = new Dictionary<Vector2, int>();

        public Mesh(string name)
        {
            Name = name;
        }

        public List<Vector3> Normals
        {
            get
            {
                if (m_normals.Count == 0)
                    return Vertices;
                return m_normals;
            }
        }

        /// <summary>
        /// Adds a vertex to the internal list of vertices.
        /// </summary>
        /// <param name="v">Vertex to add.</param>
        /// <returns>Index of the vertex after it was added, or -1 if there was an error.</returns>
        public int AddVertex(Vector3 v)
        {
            if (m_vertexMap.ContainsKey(v) == false)
            {
                Vertices.Add(v);
                m_vertexMap.Add(v, Vertices.Count() - 1);
            }

            return m_vertexMap[v];
        }

        public int AddNormal(Vector3 n)
        {
            m_normals.Add(n);
            return m_normals.Count() - 1;
        }

        public int AddUV(Vector2 uv)
        {
            if (m_uvMap.ContainsKey(uv) == false)
            {
                UVs.Add(uv);
                m_uvMap.Add(uv, UVs.Count() - 1);
            }

            return m_uvMap[uv];
        }

        public int AddFace(Face face)
        {
            Faces.Add(face);
            return Faces.Count() - 1;
        }
    }
}
