using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.GeoGen
{
    public static class FileOBJ
    {
        public static bool Save(
            Model model,
            string path)
        {
            if (model.Meshes.Count != 1 ||
                model.Meshes[0].Name == string.Empty)
            {
                return false;
            }

            Mesh mesh = model.Meshes[0];

            // Convert all content to a list of strings.
            List<string> dst = new List<string>();

            dst.Add("# Model created by GeometryGenerator by Theodore Bisson.");
            dst.Add(string.Format("o {0}", mesh.Name));

            dst.Add(string.Format("\n# {0} vertices", mesh.Vertices.Count));
            foreach (Vector3 v in mesh.Vertices)
            {
                dst.Add(string.Format("v {0} {1} {2}", v.X, v.Y, v.Z));
            }

            dst.Add(string.Format("\n# {0} normals", mesh.Normals.Count));
            foreach (Vector3 v in mesh.Normals)
            {
                dst.Add(string.Format("vn {0} {1} {2}", v.X, v.Y, v.Z));
            }

            dst.Add(string.Format("\n# {0} uvs", mesh.UVs.Count));
            foreach (Vector2 uv in mesh.UVs)
            {
                dst.Add(string.Format("vt {0} {1}", uv.X, uv.Y));
            }

            dst.Add(string.Format("\n# {0} faces", mesh.Faces.Count));
            foreach (Face f in mesh.Faces)
            {
                dst.Add(
                    string.Format("f {0}/{3}/{0} {1}/{4}/{1} {2}/{5}/{2}",
                    f.A + 1, f.B + 1, f.C + 1,
                    f.uvA + 1, f.uvB + 1, f.uvC + 1));
            }

            File.WriteAllLines(path, dst);

            return true;
        }
    }
}
