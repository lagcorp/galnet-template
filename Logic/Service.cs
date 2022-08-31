using Galnet.Common;
using Galnet.Plugin.Base;

namespace Logic
{
    public class Service
    {
        public void Register(PluginService ps)
        {
            ps.AddPlugin(Hmm);
            ps.AddProvider(GetSomeHmms);
        }

        private List<string> GetSomeHmms(IContext context)
        {
            return new List<string>()
            {
                "one",
                "two",
                "three"
            };
        }

        private void Hmm(IContext context)
        {
            Console.WriteLine(context);
        }
    }
}