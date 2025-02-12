using GeometryGenerator.Geometry;
using System.Numerics;

namespace GeometryGenerator.Render
{
    public class Renderer
    {
        public Vector3 Camera = new Vector3(0.0f, 0.0f, -3.0f);
        public float Angle = 0.0f;

        private Control m_control;
        private Image m_buffer = new Bitmap(2, 2);
        private Rectangle m_rect;
        private PointF m_center;
        private float m_zoom;

        private long m_lastTick = DateTime.Now.Ticks;

        public Renderer(Control container)
        {
            m_control = container;
        }

        public void DrawModel(Model model)
        {
            long tickNow = DateTime.Now.Ticks;
            TimeSpan delta = TimeSpan.FromTicks(tickNow - m_lastTick);
            m_lastTick = tickNow;
            Angle += (float)delta.TotalSeconds * 0.1f;
            if (Angle > MathF.Tau)
                Angle -= MathF.Tau;

            // Create or resize surface if needed.
            Graphics gfx = PrepareSurface();
            gfx.FillRectangle(Brushes.Black, m_rect);

            // Update the model transform.
            Matrix4x4 transform = Matrix4x4.CreateRotationY(Angle);

            // Draw each mesh in the model.
            foreach (Mesh mesh in model.Meshes)
            {
                foreach (Face face in mesh.Faces)
                {
                    // Get and transform each vertex in the face.
                    Vector3 A = TransformVertex(mesh.Vertices[face.A], transform);
                    Vector3 B = TransformVertex(mesh.Vertices[face.B], transform);
                    Vector3 C = TransformVertex(mesh.Vertices[face.C], transform);

                    if (FacePointsToCamera(A, B, C) == true)
                    {
                        // Project each of the vertices to the screen.
                        PointF a = new PointF(
                            m_center.X + m_zoom * (A.X - Camera.X) / (A.Z - Camera.Z),
                            m_center.Y + m_zoom * (A.Y - Camera.Y) / (A.Z - Camera.Z));
                        PointF b = new PointF(
                            m_center.X + m_zoom * (B.X - Camera.X) / (B.Z - Camera.Z),
                            m_center.Y + m_zoom * (B.Y - Camera.Y) / (B.Z - Camera.Z));
                        PointF c = new PointF(
                            m_center.X + m_zoom * (C.X - Camera.X) / (C.Z - Camera.Z),
                            m_center.Y + m_zoom * (C.Y - Camera.Y) / (C.Z - Camera.Z));

                        // Draw the edges of the triangle.
                        gfx.DrawLine(Pens.White, a, b);
                        gfx.DrawLine(Pens.White, b, c);
                        gfx.DrawLine(Pens.White, c, a);
                    }
                }
            }

            // Display rendered frame.
            m_control.CreateGraphics().DrawImage(m_buffer, 0, 0);
        }

        private bool FacePointsToCamera(Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 ab = b - a;
            Vector3 ac = c - a;
            Vector3 normal = Vector3.Cross(ab, ac);

            Vector3 center = new Vector3(
                (a.X + b.X + c.X) / 3.0f,
                (a.Y + b.Y + c.Y) / 3.0f,
                (a.Z + b.Z + c.Z) / 3.0f);
            Vector3 toCamera = Camera - center;

            float dot = Vector3.Dot(normal, toCamera);
            if (dot > 0.0f)
                return true;

            return false;
        }

        private Vector3 TransformVertex(Vector3 v, Matrix4x4 transform)
        {
            return new Vector3(
                transform.M11 * v.X + transform.M12 * v.Y + transform.M13 * v.Z,
                transform.M21 * v.X + transform.M22 * v.Y + transform.M23 * v.Z,
                transform.M31 * v.X + transform.M32 * v.Y + transform.M33 * v.Z);
        }

        private Graphics PrepareSurface()
        {
            if (m_buffer == null ||
                m_rect.Width != m_control.ClientRectangle.Width ||
                m_rect.Height != m_control.ClientRectangle.Height)
            {
                m_rect = m_control.ClientRectangle;
                m_center = new PointF(m_rect.Width / 2.0f, m_rect.Height / 2.0f);
                m_zoom = m_rect.Height * 0.8f;

                m_buffer = new Bitmap(m_rect.Width, m_rect.Height);
            }

            return Graphics.FromImage(m_buffer);
        }
    }
}
