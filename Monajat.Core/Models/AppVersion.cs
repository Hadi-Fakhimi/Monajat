namespace Monajat.Core.Models
{
    public class AppVersion
    {
        public int Id { get; set; }
        public int VersionCode { get; set; }
        public string VersionName { get; set; }
        public bool ForceUpdate { get; set; }
        public string? Changelog { get; set; }
    }
}
