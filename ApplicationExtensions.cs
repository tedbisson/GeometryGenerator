using System.Runtime.InteropServices;

namespace GeometryGenerator
{
    /// <summary>
    /// The Application.Idle event triggers only once when there are no messages
    /// in the message queue. In order to run a traditional game loop, an app
    /// must continue to examine the message queue to determine when to yield
    /// back to message handling.
    /// 
    /// To do this, use the Win32 function PeekMessage, which checks the queue
    /// and returns a copy of the next available message without removing it
    /// from the queue. Once a message is waiting, the app should exit it's
    /// Idle loop or the app will become unresponsive.
    /// 
    /// Source:
    ///   https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    /// </summary>
    public static class ApplicationExtensions
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Locaiton;
        };

        [DllImport("user32.dll")]
        private static extern int PeekMessage(
            out NativeMessage message,
            IntPtr window,
            uint filterMin,
            uint filterMax,
            uint remove);

        /// <summary>
        /// Checks the Windows message queue to see if a new message is ready for
        /// processing. If the queue is empty, the function returns true indicating
        /// the app is idle.
        /// 
        /// This is intended to be used inside an Application.Idle callback.
        /// Application.Idle += new EventHandler(OnIdle);
        /// private void OnIdle(object? sender, EventArgs e) {
        ///     while (Application.IsIdle() == true) {
        ///         ...
        ///     }
        /// }
        /// </summary>
        /// <returns>true - if the app is idle, false - if the app should continue
        /// normal message handling.</returns>
        public static bool IsIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }
    }
}
