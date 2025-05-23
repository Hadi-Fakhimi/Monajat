namespace Monajat.Core.DTOs.Response
{
    public class CheckForUpdateResponseDto
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public UpdateDataDto Data { get; set; }
        public List<OptionDto> Options { get; set; }

    }

    public class UpdateDataDto
    {
        public bool NewVersionAvailable { get; set; }
        public int NewVersionCode { get; set; }
        public string NewVersionName { get; set; }
        public bool ForceUpdate { get; set; }
        public string? ChangeLog { get; set; }
    }

    public class OptionDto
    {
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
