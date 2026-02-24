using ModSettings;

namespace GreatBareIsland
{
    internal class GreatBareIsland : JsonModSettings
    {

        [Name("Enable Great Bare Island")]
        [Description("Remove most cabins, trailers and houses.")]
        public bool greatBare = true;

        /*
        [Section("Debug")]

        [Name("Enable debug logging")]
        [Description("Enables debug information in the melon log. Only enable for troubleshooting reasons, or if you know what you're doing.")]
        public bool Debug = false;
        */

    }

    internal static class Settings
    {
        public static GreatBareIsland options;

        public static void OnLoad()
        {
            options = new GreatBareIsland();
            options.AddToModSettings("Great Bare Island", MenuType.Both);
        }
    }
}