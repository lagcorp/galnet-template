using Galnet.Common;
using Galnet.Plugin.Base;

namespace Logic
{
    public class Service
    {
        public void Register(PluginService ps)
        {
            ps.AddPlugin("Hmm", Hmm);
        }

        private void Hmm(IContext context)
        {
            Console.WriteLine(context);
        }
    }
}