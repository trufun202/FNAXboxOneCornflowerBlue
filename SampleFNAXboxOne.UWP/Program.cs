using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFNAXboxOne.UWP
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
#if WINDOWS_UWP
        {
            // Temporary workaround until FACT is done
            //Environment.SetEnvironmentVariable("FNA_AUDIO_DISABLE_SOUND", "1");

            realArgs = args;
            SDL2.SDL.SDL_SetHint("SDL_WINRT_HANDLE_BACK_BUTTON", "1");
            SDL2.SDL.SDL_WinRT_mainFunction mainFunction = FakeMain;
            SDL2.SDL.SDL_WinRTRunApp(mainFunction, IntPtr.Zero);
        }

        static string[] realArgs;
        static int FakeMain(int argc, IntPtr[] argv)
        {
            RealMain(realArgs);
            return 0;
        }

        static void RealMain(string[] args)
#endif
        {
            using (MyGame game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
